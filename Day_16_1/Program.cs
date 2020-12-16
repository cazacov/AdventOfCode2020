using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_16_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input.txt").ToList();
            var rules = ParseRules(lines.Take(20));
            var myTicket = ParseTickets(lines.Skip(22).Take(1)).First();
            var nearbyTickets = ParseTickets(lines.Skip(25)).ToList();

            var result = nearbyTickets.Sum(t =>
                t.Fields
                    .Where(f => !rules.Any(r => r.InRange(f))) // No one rule can be applied
                    .Sum()
            );

            Console.WriteLine(result);
        }

        private static IEnumerable<Ticket> ParseTickets(IEnumerable<string> lines)
        {
            var result = new List<Ticket>();
            foreach (var line in lines)
            {
                result.Add(new Ticket()
                {
                    Fields = line.Split(',').ToList().ConvertAll(x => int.Parse(x)).ToList()
                });
            }
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
                result.Add(new Rule()
                {
                    Name = m.Groups[1].Value,
                    from1 = int.Parse(m.Groups[2].Value),
                    to1 = int.Parse(m.Groups[3].Value),
                    from2 = int.Parse(m.Groups[4].Value),
                    to2 = int.Parse(m.Groups[5].Value)
                });
            }
            return result;
        }
    }
}
