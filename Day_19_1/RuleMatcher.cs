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

            var result = 0;
            foreach (var message in messages)
            {
                if (rules[0].Matches(message))
                {
                    result++;
                }
            }
            return result;
        }

        private void PreprocessRules(List<Rule> list)
        {
            bool optimized = true;

            while (optimized)
            {
                optimized = false;
                for (int i = 0; i < rules.Count; i++)
                {
                    var rule = rules[i];
                    if (rule is ExactRule)
                    {
                        continue;
                    }

                    var opRule = rule as OptionsRule;
                    if (opRule.Options.Count == 0)
                    {
                        var hash = new HashSet<string>();
                        foreach (var r in opRule.rules)
                        {
                            hash.Add(r.Str);
                        }
                        var newRule = new ExactRule(i, hash);
                        rules[i] = newRule;
                        optimized = true;
                    }
                    else
                    {
                        for (int j = 0; j < opRule.Options.Count; j++)
                        {
                            var option = opRule.Options[j];
                            bool allExact = true;
                            var hash = new HashSet<string>();
                            for (var k = 0; k < option.Count; k++)
                            {
                                if (!(rules[option[k]] is ExactRule))
                                {
                                    allExact = false;
                                    break;
                                }
                                else
                                {
                                    hash.UnionWith((rules[option[k]] as ExactRule).matches);
                                }
                            }
                            if (allExact)
                            {
                                opRule.rules.Add(new ExactRule(-1, hash));
                                opRule.Options.RemoveAt(j);
                            }
                        }
                    }
                }

            }
        }
    }
}