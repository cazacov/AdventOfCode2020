using System;
using Day_20_2;

namespace Day_20_1
{
    internal class MonsterFinder
    {
        private readonly bool[,] image;
        private readonly bool[,] monster;
        private int iw;
        private int ih;
        private int mw;
        private int mh;

        public MonsterFinder(bool[,] image)
        {
            this.image = image;
            this.iw = image.GetUpperBound(1) + 1;
            this.ih = image.GetUpperBound(0) + 1;

            var lines = System.IO.File.ReadAllLines("monster.txt");
            monster = new bool[lines.Length,lines[0].Length];

            for (var y = 0; y < lines.Length; y++)
            {
                for (var x = 0; x < lines[0].Length; x++)
                {
                    monster[y, x] = lines[y][x] == '#';
                }
            }
            this.mw = monster.GetUpperBound(1) + 1;
            this.mh = monster.GetUpperBound(0) + 1;
        }

        public void CalculateRoughness()
        {
            int monsterCount = 0;
            for (int i = 0; i < 8; i++)
            {
                monsterCount = CountMonsters();
                Console.WriteLine($"Monsters: {monsterCount}");
                if (monsterCount > 0)
                {
                    break;
                }

                Console.WriteLine("rotate");
                ArrayHelper.RotateImage(image);
                if (i == 3)
                {
                    Console.WriteLine("flip");
                    ArrayHelper.Flip(image);
                }

            }
            Console.WriteLine($"Monsters: {monsterCount}");
        }


        private int CountMonsters()
        {
            var monsterCount = 0;
            for (var sy = 0; sy < ih - mh + 1; sy++)
            {
                for (var sx = 0; sx < iw - mw + 1; sx++)
                {
                    bool allMatch = true;
                    for (var y = 0; y < mh; y++)
                    {
                        for (var x = 0; x < mw; x++)
                        {
                            var match = monster[y, x] && image[sy + y, sx + x];
                            if (!match)
                            {
                                allMatch = false;
                                break;
                            }
                        }
                    }

                    if (allMatch)
                    {
                        monsterCount++;
                    }
                }
            }

            return monsterCount;
        }
    }
}