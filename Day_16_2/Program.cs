using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_16_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input.txt").ToList();
            var rules = ParseRules(lines.Take(20));
            var myTicket = ParseTickets(lines.Skip(22).Take(1)).First();
            var nearbyTickets = ParseTickets(lines.Skip(25)).ToList();
            var validTickets = nearbyTickets.Where(t => t.ErrorRate(rules) == 0).ToList();
            validTickets.Add(myTicket);

            var candidates = AssignCandidates(rules, validTickets);

            Console.WriteLine("\nFinal candidates:");
            foreach (var pair in candidates)
            {
                Console.WriteLine($"Field position {pair.Key}\tPossible rules are: {String.Join(",", pair.Value.Select(x => x.Name))}");
            }

            var departurePositions =
                candidates
                    .Where(c => c.Value.Any(f => f.Name.StartsWith("departure")))
                    .Select(p => p.Key);

            var result = departurePositions
                .Aggregate<int, long>(1, (current, pos) => current * (long) myTicket.Fields[pos]);
         
            Console.WriteLine($"\nProduct of departure fields: {result}");
        }

        private static Dictionary<int, List<Rule>> AssignCandidates(List<Rule> rules, List<Ticket> validTickets)
        {
            Console.WriteLine("\nAssigning rules");
            var candidates = new Dictionary<int, List<Rule>>();
            for (int pos = 0; pos < rules.Count; pos++)
            {
                var cr = new List<Rule>();
                Console.WriteLine($"Position {pos}");
                foreach (var rule in rules)
                {
                    if (validTickets.All(t => rule.InRange(t.Fields[pos])))
                    {
                        cr.Add(rule);
                        Console.WriteLine($"\t{rule.Name}");
                    }
                }
                candidates[pos] = cr;
            }

            Console.WriteLine("\nSimplifying assigned rules");
            var isSimplified = true;
            while (isSimplified)
            {
                isSimplified = false;
                for (var i = 0; i < candidates.Count; i++)
                {
                    if (candidates[i].Count == 1)
                    {
                        var rule = candidates[i].First();
                        for (var j = 0; j < candidates.Count; j++)
                        {
                            if (i == j)
                            {
                                continue;
                            }
                            if (!candidates[j].Contains(rule))
                            {
                                continue;
                            }

                            candidates[j].Remove(rule);
                            Console.WriteLine($"Removed rule {rule.Name} from position {j}");
                            isSimplified = true;
                        }
                    }
                }
            }
            return candidates;
        }

        private static IEnumerable<Ticket> ParseTickets(IEnumerable<string> lines)
        {
            var result = lines.ToList().ConvertAll(line => 
                new Ticket(
                    line.Split(',')
                        .ToList()
                        .ConvertAll(int.Parse)));
            return result;
        }

        private static List<Rule> ParseRules(IEnumerable<string> lines)
        {
            var result = new List<Rule>();
            foreach (var line in lines)
            {
                var r = new Regex(@"(.*): (\d*)-(\d*) or (\d*)-(\d*)");
                var m = r.Match(line);
                if (!m.Success)
                {
                    throw new ArgumentOutOfRangeException($"Unsupported input format: {line}");
                }
                if (m.Groups.Count != 6)
                {
                    throw new ArgumentOutOfRangeException($"Unsupported input format: {line}");
                }

                result.Add(new Rule(
                    m.Groups[1].Value,
                    int.Parse(m.Groups[2].Value),
                    int.Parse(m.Groups[3].Value),
                    int.Parse(m.Groups[4].Value),
                    int.Parse(m.Groups[5].Value)));
            }
            return result;
        }
    }
}
