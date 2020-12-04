using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_04_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var passwords = ReadPasswords();
            Console.WriteLine(passwords.Count(p => p.IsValid && p.IsPresent));
        }

        private static List<Passport> ReadPasswords()
        {
            var strings = System.IO.File.ReadAllLines("input.txt");
            var result = new List<Passport>();

            var blocks = ParseBlocks(strings);
            foreach (var block in blocks)
            {
                result.Add(new Passport(block));
            }
            return result;
        }

        private static List<string> ParseBlocks(string[] strings)
        {
            var result = new List<string>();

            var block = String.Empty;
            foreach (var str in strings)
            {
                if (str == String.Empty)
                {
                    result.Add(block.Trim());
                    block = String.Empty;
                }
                else
                {
                    block += " " + str;
                }
            }
            if (block != String.Empty)
            {
                result.Add(block.Trim());
            }
            return result;
        }
    }
}
