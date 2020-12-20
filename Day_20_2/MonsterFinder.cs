using System;

namespace Day_20_2
{
    internal class MonsterFinder
    {
        private readonly bool[,] image;
        private readonly bool[,] monster;
        private readonly bool[,] isMonster;
        private readonly int imageWidth;
        private readonly int imageHeight;
        private readonly int monsterWidth;
        private readonly int monsterHeight;

        public MonsterFinder(bool[,] image)
        {
            this.image = image;
            this.imageWidth = image.GetUpperBound(1) + 1;
            this.imageHeight = image.GetUpperBound(0) + 1;

            var lines = System.IO.File.ReadAllLines("monster.txt");
            monster = new bool[lines.Length,lines[0].Length];

            for (var y = 0; y < lines.Length; y++)
            {
                for (var x = 0; x < lines[0].Length; x++)
                {
                    monster[y, x] = lines[y][x] == '#';
                }
            }
            this.monsterWidth = monster.GetUpperBound(1) + 1;
            this.monsterHeight = monster.GetUpperBound(0) + 1;

            this.isMonster = new bool[imageHeight,imageWidth];
        }

        public void CalculateRoughness()
        {
            for (var orientation = 0; orientation < 8; orientation++)
            {
                var monsterCount = CountMonsters();
                if (monsterCount > 0)
                {
                    break;
                }

                Console.WriteLine("rotate");
                ArrayHelper.RotateImage(image);
                if (orientation == 3)
                {
                    Console.WriteLine("flip");
                    ArrayHelper.Flip(image);
                }
            }
        }


        private int CountMonsters()
        {
            var monsterCount = 0;
            for (var sy = 0; sy < imageHeight - monsterHeight + 1; sy++)
            {
                for (var sx = 0; sx < imageWidth - monsterWidth + 1; sx++)
                {
                    var allMatch = true;
                    for (var y = 0; y < monsterHeight; y++)
                    {
                        for (var x = 0; x < monsterWidth; x++)
                        {
                            if (!monster[y, x])
                            {
                                continue;
                            }
                            if (!image[sy + y, sx + x])
                            {
                                allMatch = false;
                                break;
                            }
                        }
                    }
                    if (allMatch)
                    {
                        monsterCount++;
                        for (var y = 0; y < monsterHeight; y++)
                        {
                            for (var x = 0; x < monsterWidth; x++)
                            {
                                if (monster[y, x])
                                {
                                    isMonster[sy + y, sx + x] = true;
                                }
                            }
                        }
                    }
                }
            }

            if (monsterCount > 0)
            {
                var roughness = 0;
                for (var y = 0; y < imageHeight; y++)
                {
                    for (var x = 0; x < imageWidth; x++)
                    {
                        if (image[y, x])
                        {
                            roughness++;
                        }
                    }
                }

                var monsterpixels = 0;
                for (var y = 0; y < monsterHeight; y++)
                {
                    for (var x = 0; x < monsterWidth; x++)
                    {
                        if (monster[y, x])
                        {
                            monsterpixels++;
                        }
                    }
                }
                Console.WriteLine($"Water roughness: {roughness - monsterCount * monsterpixels}");
                Console.WriteLine($"Monsters: {monsterCount}");
                this.ShowImage(image, isMonster);
            }
            return monsterCount;
        }

        public void ShowImage(bool[,] image, bool[,] isMonster)
        {
            var width = image.GetUpperBound(1) + 1;
            var height = image.GetUpperBound(0) + 1;

            var color = Console.ForegroundColor;


            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (image[y, x])
                    {
                        if (isMonster[y, x])
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("O");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("#");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = color;
        }
    }
}