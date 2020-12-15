using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day_15_1
{
    public class MemoryGame
    {
        private readonly List<Number> history = new List<Number>();
        public long turn = 0;
        private Number lastSpoken;

        public void Init(string fileName)
        {
            var lines = System.IO.File.ReadAllLines(fileName);
            var numbers = lines[0].Split(",").ToList().ConvertAll(x => Int64.Parse(x));
            foreach (var n in numbers)
            {
                SayNumber(n);
            }
        }

        private void SayNumber(long n)
        {
            turn++;
            var prev = history.FirstOrDefault(num => num.N == n);
            if (prev == null)
            {
                prev = new Number()
                {
                    N = n,
                };
                history.Add(prev);
            }

            prev.prev = prev.last;
            prev.last = turn;
            lastSpoken = prev;

            Console.WriteLine($"{turn} -> {n}");
        }

        public long NextTurn()
        {
            if (lastSpoken.prev == 0)
            {
                SayNumber(0);
            }
            else
            {
                SayNumber(lastSpoken.last - lastSpoken.prev);
            }
            return lastSpoken.N;
        }
    }
}
