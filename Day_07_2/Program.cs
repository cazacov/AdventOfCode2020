using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_07_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rules = ReadRules();

            var outer = new List<string>();
            var processed = new List<string>();
            int count = CountInner("shiny gold", outer, rules, processed);

            Console.WriteLine(count);
        }

        private static int CountInner(string bag, List<string> outer, List<Rule> rules, List<string> processed)
        {
            var result = 0;
            var rule = rules.First(r => r.bag == bag);

            foreach (var nested in rule.content)
            {
                result += nested.Value;
                result += CountInner(nested.Key, outer, rules, processed) * nested.Value;
            }
            return result;
        }

        private static List<Rule> ReadRules()
        {
            var result = new List<Rule>();
            var lines = System.IO.File.ReadAllLines("input.txt");

            foreach (var s in lines)
            {
                result.Add(Rule.FromString(s));
            }
            return result;
        }
    }
}
