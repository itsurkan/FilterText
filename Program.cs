using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestSymbolFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, double> freq = new Dictionary<char, double>();

            // get file content
            var content = GetFileContent(@"source.txt");

            if (content.Length == 0)
            {
                Console.WriteLine("File is empty or does not exist");
                Console.ReadKey();
                return;
            }
            freq = GetSybmolsCount(content);

            // average symbols count
            var avg = content.Length / freq.Count;

            // remove qrequentcy used symbols
            char[] separators = freq.Where(k => k.Value > avg).Select(k => k.Key).ToArray();

            string[] temp = content.Split(separators, StringSplitOptions.None);
            content = String.Join("", temp);

            Console.WriteLine(content);
            Console.ReadKey();
        }

        private static Dictionary<char, double> GetSybmolsCount(string content)
        {
            var dict = new Dictionary<char, double>();
            for (int i = 0; i < content.Length; i++)
            {
                if (!dict.ContainsKey(content[i]))
                    dict.Add(content[i], 1);
                else
                    dict[content[i]]++;
            }
            return dict;
        }

        private static string GetFileContent(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return string.Empty;
        }
    }
}
