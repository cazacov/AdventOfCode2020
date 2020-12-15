using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_15_2
{
    public class MemoryGame
    {
        private readonly Dictionary<long, Number> history = new Dictionary<long, Number>();
        public long Turn = 0;
        private Number lastSpoken;

        public void Init(string fileName)
        {
            var lines = System.IO.File.ReadAllLines(fileName);
            var numbers = lines[0].Split(",").ToList().ConvertAll(long.Parse);
            foreach (var n in numbers)
            {
                SayNumber(n);
            }
        }

        private void SayNumber(long n)
        {
            Turn++;
            Number prev;
            if (!history.ContainsKey(n))
            {
                prev = new Number()
                {
                    N = n,
                };
                history[n] = prev;
            }
            else
            {
                prev = history[n];
            }
            prev.PrevTurn = prev.LastTurn;
            prev.LastTurn = Turn;
            lastSpoken = prev;
            if (Turn % 1000 == 0)
            {
                Console.WriteLine($"{Turn} -> {n}");
            }
        }

        public long NextTurn()
        {
            if (lastSpoken.PrevTurn == 0)
            {
                SayNumber(0);
            }
            else
            {
                SayNumber(lastSpoken.LastTurn - lastSpoken.PrevTurn);
            }
            return lastSpoken.N;
        }
    }
}
