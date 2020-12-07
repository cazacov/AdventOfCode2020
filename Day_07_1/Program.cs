using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_07_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rules = ReadRules();

            var outer = new List<string>();
            ListOuter("shiny gold", outer, rules);
            Console.WriteLine(outer.Count);
        }

        private static void ListOuter(string bag, List<string> outer, List<Rule> rules)
        {
            foreach (var rule in rules)
            {
                if (rule.content.ContainsKey(bag))
                {
                    if (!outer.Contains(rule.bag))
                    {
                        outer.Add(rule.bag);
                    }
                    ListOuter(rule.bag, outer, rules);
                }
            }
        }

        private static List<Rule> ReadRules()
        {
            var lines = System.IO.File.ReadAllLines("input.txt").ToList();
            return lines.ConvertAll(line => Rule.FromString(line))
                .ToList();
        }
    }
}
