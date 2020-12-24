using System;
using System.Collections.Generic;

namespace Day_24_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input.txt");
            var tiles = new Dictionary<HexCo, bool>();
            foreach (var line in lines)
            {
                var hex = HexCo.GoPath(line);
                if (!tiles.ContainsKey(hex))
                {
                    tiles[hex] = true;
                }
                else
                {
                    tiles[hex] = !tiles[hex];
                }
            }

            var game = new GameOfTiles(tiles);
            Console.WriteLine($"Initial state: {game.CountBlack()}");
            for (int i = 0; i < 100; i++)
            {
                game.NextGen();
                Console.WriteLine($"{i} - {game.CountBlack()}");
            }
        }
    }
}
