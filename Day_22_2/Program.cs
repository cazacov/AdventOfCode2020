using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day_22_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input.txt").ToList();
            List<int> cards1;
            List<int> cards2;
            cards1 = lines.Skip(1).Take(25).ToList().ConvertAll<int>(c => Int32.Parse(c)).ToList();
            cards2 = lines.Skip(28).Take(25).ToList().ConvertAll<int>(c => Int32.Parse(c)).ToList();

            var cache = new Dictionary<string, bool>();

            var sw = new Stopwatch();
            sw.Start();
            var game = new Game(new Deck2(cards1), new Deck2(cards2));
            game.Play();
            Console.WriteLine(game.WinnerScore());
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        }
    }
}
