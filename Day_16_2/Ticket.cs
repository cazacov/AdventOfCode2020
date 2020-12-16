using System.Collections.Generic;
using System.Linq;

namespace Day_16_2
{
    public class Ticket
    {
        public readonly List<int> Fields;

        public Ticket(IEnumerable<int> fields)
        {
            this.Fields =  new List<int>();
            Fields.AddRange(fields);
        }

        public int ErrorRate(List<Rule> rules)
        {
            return Fields
                .Where(field => !rules.Any(r => r.InRange(field)))
                .Sum();
        }
    }
}