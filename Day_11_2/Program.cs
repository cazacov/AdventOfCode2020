using System;

namespace Day_11_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameOfSeats();
            int gen = 0;

            while (game.NextGen())
            {
                game.PrintMap();
                Console.WriteLine($"Generation {++gen}\n\n\n");
            }
            Console.WriteLine(game.OccupiedCount());
        }
    }

    public class GameOfSeats
    {
        public char[,] map;
        private readonly int height;
        private readonly int width;

        public GameOfSeats()
        {
            var s = System.IO.File.ReadAllLines("input.txt");
            map = new char[s.Length, s[0].Length];
            this.height = s.Length;
            this.width = s[0].Length;

            var y = 0;
            foreach (var str in s)
            {
                var x = 0;
                foreach (var ch in str.ToCharArray())
                {
                    map[y, x] = ch;
                    x++;
                }
                y++;
            }
        }

        public bool NextGen()
        {
            var wasChanged = false;
            var nextMap = new char[this.height, this.width];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var occupied = CalculateOccupied(x, y);
                    nextMap[y, x] = map[y, x];
                    switch (map[y, x])
                    {
                        case 'L':
                            if (occupied == 0)
                            {
                                nextMap[y, x] = '#';
                                wasChanged = true;
                            }
                            break;
                        case '#':
                            if (occupied >= 5)
                            {
                                nextMap[y, x] = 'L';
                                wasChanged = true;
                            }
                            break;
                    }
                }
            }

            this.map = nextMap;
            return wasChanged;
        }

        private int CalculateOccupied(int x, int y)
        {
            var occupied = 0;
            for (var dx = -1; dx <= 1; dx++)
            {
                for (var dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) continue;
                    var xx = x;
                    var yy = y;
                    do
                    {
                        xx += dx;
                        yy += dy;
                        if (xx < 0) break;
                        if (xx >= width) break;
                        if (yy < 0) break;
                        if (yy >= height) break;
                        if (map[yy, xx] == '#')
                        {
                            occupied++;
                            break;
                        }

                        if (map[yy, xx] == 'L')
                        {
                            break;
                        }
                    } while (true);
                }
            }
            return occupied;
        }

        public int OccupiedCount()
        {
            var cnt = 0;
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (map[y, x] == '#')
                    {
                        cnt++;
                    }
                }
            }
            return cnt;
        }

        public void PrintMap()
        {
            for (var y = 0; y < height; y++)
            {
                var s = String.Empty;
                for (var x = 0; x < width; x++)
                {
                    s += new string(map[y, x], 1);
                }
                Console.WriteLine(s);
            }
        }
    }
}
