using System;
using System.Collections.Generic;

namespace Day_07_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rules = ReadRules();

            var outer = new List<string>();
            var processed = new List<string>();
            ListOuter("shiny gold", outer, rules, processed);
            Console.WriteLine(outer.Count);
        }

        private static void ListOuter(string bag, List<string> outer, List<Rule> rules, List<string> processed)
        {
            foreach (var rule in rules)
            {
                if (rule.content.ContainsKey(bag))
                {
                    if (!outer.Contains(rule.bug))
                    {
                        outer.Add(rule.bug);
                    }
                    if (!processed.Contains(rule.bug))
                    {
                        processed.Add(rule.bug);
                        ListOuter(rule.bug, outer, rules, processed);
                    }

                }
            }
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

    public class Rule
    {
        public string bug;
        public Dictionary<string, int> content = new Dictionary<string, int>();

        internal static Rule FromString(string s)
        {
            var result = new Rule();
            var pos = s.IndexOf(" bags contain ");
            result.bug = s.Substring(0, pos);
            var tail = s.Substring(pos + 14, s.Length - pos - 14 - 1);
            if (tail == "no other bags")
            {
                result.content.Clear();
            }
            else
            {
                var parts = tail.Split(",".ToCharArray());
                foreach (var part in parts)
                {
                    var p = part.Trim();
                    var count = Int32.Parse(p.Substring(0, 1));
                    var bpos = part.IndexOf("bag");
                    var key = p.Substring(2, bpos - 3).Trim();
                    result.content.Add(key, count);
                }
            }
            return result;            
        }
    }
}
