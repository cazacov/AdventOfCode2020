using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_19_1
{
    public class Rule
    {
        public int N;

        public bool DoesMatch(string str, Dictionary<string, MatchCache> cache)
        {
            MatchCache cacheItem;

            if (cache.ContainsKey(str))
            {
                cacheItem = cache[str];
            }
            else
            {
                cacheItem = new MatchCache();
                cache[str] = cacheItem;
            }

            if (cacheItem.Yes.Contains(this.N))
            {
                return true;
            }

            if (cacheItem.No.Contains(this.N))
            {
                return false;
            }

            var result = this.Matches(str, cache);
            if (result)
            {
                cacheItem.Yes.Add(this.N);
            }
            else
            {
                cacheItem.No.Add((this.N));
            }

            return result;
        }

        protected virtual bool Matches(string str, Dictionary<string, MatchCache> cache)
        {
            throw new NotImplementedException();
        }
    }

    public class ExactRule : Rule
    {
        public string Str;
        public ExactRule(int n, string str)
        {
            this.N = n;
            this.Str = str;
        }

        protected override bool Matches(string str, Dictionary<string, MatchCache> cache)
        {
            return str == this.Str;
        }

        public override string ToString()
        {
            return this.Str;
        }
    }

    public class OptionsRule : Rule
    {
        public List<List<int>> Options;
        public List<List<Rule>> ruleSets;

        public OptionsRule(int n, List<List<int>> options)
        {
            this.N = n;
            this.Options = options;
        }

        public override string ToString()
        {
            return String.Join(" | ",
                this.Options.Select(o => String.Join(" ", o.Select(op => op.ToString()))));
        }

        protected override bool Matches(string str, Dictionary<string, MatchCache> cache)
        {
            if (str == String.Empty)
            {
                return false;
            }
            foreach (var ruleSet in this.ruleSets)
            {
                if (MatchesRuleSet(str, ruleSet, cache))
                {
                    return true;
                }
            }
            return false;
        }

        private bool MatchesRuleSet(string str, List<Rule> ruleSet, Dictionary<string, MatchCache> cache)
        {
            if (str.Length == 1) {
                if (ruleSet.Count == 1)
                {
                    return ruleSet[0].DoesMatch(str, cache);
                }
                else
                {
                    return false;
                }
            }

            if (ruleSet.Count == 1)
            {
                return ruleSet[0].DoesMatch(str, cache);
            }

            if (ruleSet.Count > 2)
            {
                throw new ApplicationException("Unsupported");
            }
            for (int i = 1; i < str.Length; i++)
            {
                var head = str.Substring(0, i);
                var tail = str.Substring(i);
                if (ruleSet[0].DoesMatch(head, cache) && ruleSet[1].DoesMatch(tail, cache))
                {
                    return true;
                }
            }
            return false;
        }
    }
}