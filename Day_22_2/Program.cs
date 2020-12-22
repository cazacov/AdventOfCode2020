using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_22_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input.txt").ToList();
//            var cards1 = new List<int> {9,2,6,3,1};
//            var cards2 = new List<int> { 5, 8, 4, 7, 10 };

            var cards1 = lines.Skip(1).Take(25).ToList().ConvertAll<int>(c => Int32.Parse(c)).ToList();
            var cards2 = lines.Skip(28).Take(25).ToList().ConvertAll<int>(c => Int32.Parse(c)).ToList();

            var cache = new Dictionary<string, bool>();
            var game = new Game(cards1, cards2);
            game.Play(cache);
            Console.WriteLine(game.WinnerScore());
        }
    }
}
