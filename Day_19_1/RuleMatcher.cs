using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_19_1
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
            PreprocessRules(rules);
            Dictionary<string, MatchCache> cache = new Dictionary<string, MatchCache>();

            var result = 0;
            foreach (var message in messages)
            {
                Console.WriteLine($"Checking message {message}");
                if (rules[0].DoesMatch(message, cache))
                {
                    result++;
                }
            }
            return result;
        }

        private void PreprocessRules(List<Rule> list)
        {
            foreach (var t in rules)
            {
                var rule = t as OptionsRule;
                if (rule == null)
                {
                    continue;
                }

                rule.ruleSets = new List<List<Rule>>();
                foreach (var option in rule.Options)
                {
                    rule.ruleSets.Add(option.Select(idx => rules[idx]).ToList());
                }
            }
        }
    }
}