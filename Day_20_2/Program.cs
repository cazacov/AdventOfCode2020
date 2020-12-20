using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_20_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var images = LoadImages();
            var puzzle = new Puzzle(images);
            var image = puzzle.ArrangeTiles();
            puzzle.ShowImage(image);
            var monsterFinder = new MonsterFinder(image);
            monsterFinder.CalculateRoughness();
        }

        private static List<Image> LoadImages()
        {
            var images = new List<Image>();

            var lines = System.IO.File.ReadAllLines("input.txt");

            var acc = new List<string>();
            foreach (var line in lines)
            {
                if (line == String.Empty)
                {
                    if (acc.Count > 0)
                    {
                        images.Add(new Image(acc));
                    }

                    acc.Clear();
                }
                else
                {
                    acc.Add(line);
                }
            }

            if (acc.Any())
            {
                images.Add(new Image(acc));
            }

            return images;
        }
    }
}