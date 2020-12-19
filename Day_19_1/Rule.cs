using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_19_1
{
    public class Rule
    {
        public int N;

        public virtual bool Matches(string str)
        {
            throw new NotImplementedException();
        }
    }

    public class ExactRule : Rule
    {
        public string Str;
        public HashSet<string> matches = new HashSet<string>();
        public ExactRule(int n, string str)
        {
            this.N = n;
            this.Str = str;
            this.matches.Add(str);
        }

        public ExactRule(in int n, HashSet<string> hash)
        {
            this.N = n;
            this.Str = "JOIN";
            this.matches = hash;
        }

        public override bool Matches(string str)
        {
            return this.matches.Contains(str);
        }

        public override string ToString()
        {
            return this.Str;
        }
    }

    public class OptionsRule : Rule
    {
        public List<List<int>> Options;
        public List<ExactRule> rules = new List<ExactRule>();

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
    }
}