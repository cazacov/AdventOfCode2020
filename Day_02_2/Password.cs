using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_02_1
{
    public class Password {
        readonly char policyChar;
        readonly int policyLow;
        readonly int policyHigh;
        readonly string password;

        public Password(string rawText)
        {
            var r = new Regex(@"(\d*)-(\d*) (\w*): (\w*)");
            var m = r.Match(rawText);
            if (!m.Success)
            {
                throw new ArgumentOutOfRangeException($"Unsupported input format: {rawText}");
            }
            if (m.Groups.Count != 5)
            {
                throw new ArgumentOutOfRangeException($"Unsupported input format: {rawText}");
            }
            policyLow = int.Parse(m.Groups[1].Value);
            policyHigh = int.Parse(m.Groups[2].Value);
            policyChar = m.Groups[3].Value.First();
            password = m.Groups[4].Value;
        }

        internal bool IsValid()
        {
            bool firstValid = password.Length >= policyLow && password[policyLow - 1] == policyChar;
            bool secondValid = password.Length >= policyHigh && password[policyHigh - 1] == policyChar;

            return firstValid ^ secondValid;
        }
    }
}
