using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_19_2
{
    public class RuleMatcher
    {
        private readonly List<Rule> rules;

        public RuleMatcher(List<Rule> rules)
        {
            this.rules = rules;
        }

        public int CountMatches(List<string> messages)
        {
            rules[8] = new SequenceRule(8, rules[42]);
            rules[11] = new SplitRule(11, rules[42], rules[31]);
            PreprocessRules(rules);
            Dictionary<string, MatchCache> cache = new Dictionary<string, MatchCache>();

            var result = 0;
            foreach (var message in messages)
            {
                
                if (rules[0].DoesMatch(message, cache))
                {
                    result++;
                    Console.WriteLine($"YES - {message}");
                }
                else
                {
                    Console.WriteLine($"NO  - {message}");
                }
            }
            return result;
        }

        private void PreprocessRules(List<Rule> list)
        {
            foreach (var t in rules)
            {
                if (t is OptionsRule rule)
                {
                    rule.ruleSets = new List<List<Rule>>();
                    foreach (var option in rule.Options)
                    {
                        rule.ruleSets.Add(option.Select(idx => rules[idx]).ToList());
                    }
                }
            }
        }
    }
}