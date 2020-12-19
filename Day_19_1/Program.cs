using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_19_1
{
    class Program
    {
        private static List<string> messages;
        private static List<Rule> rules;

        static void Main(string[] args)
        {
            ReadInput();

            var ruleMatcher = new RuleMatcher(rules);

            Console.WriteLine(ruleMatcher.CountMatches(messages));
        }

        static void ReadInput()
        {
            var lines = System.IO.File.ReadAllLines("input.txt");

            int pos = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == String.Empty)
                {
                    pos = i;
                    break;
                }
            }
            rules = ParseRules(lines.Take(pos));
            messages = lines.Skip(pos+1).ToList();
        }

        private static List<Rule> ParseRules(IEnumerable<string> lines)
        {
            var result = new Rule[lines.Count()];
            foreach (var line in lines)
            {
                Rule rule = new Rule();
                int p = line.IndexOf(":");
                int n = Int32.Parse(line.Substring(0, p));
                var tail = line.Substring(p + 2);
                if (tail[0] == '\"')
                {
                    rule = new ExactRule(n, new String(tail[1], 1));
                }
                else
                {
                    var options = new List<List<int>>();
                    var parts = tail.Split('|');
                    foreach (var part in parts)
                    {
                        options.Add(
                            part.
                                Trim()
                                .Split(' ')
                                .ToList()
                                .ConvertAll(x => Int32.Parse(x)));
                    }
                    rule = new OptionsRule(n, options);
                }
                result[n] = rule;
            }
            return result.ToList();
        }
    }
}
