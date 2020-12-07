using System;
using System.Collections.Generic;

namespace Day_07_1
{
    public class Rule
    {
        public string bag;
        public Dictionary<string, int> content = new Dictionary<string, int>();

        internal static Rule FromString(string s)
        {
            var result = new Rule();
            var pos = s.IndexOf(" bags contain ");
            result.bag = s.Substring(0, pos);
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
