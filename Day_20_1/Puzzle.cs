using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Day_20_1
{
    class Puzzle
    {
        private readonly List<Image> images;

        public Puzzle(List<Image> images)
        {
            this.images = images;
        }

        public void ArrangeTiles()
        {
            var map = new [] { 2, 3, 0, 1 };

            var positions = new List<ImagePos>();
            positions.Add(new ImagePos(images[0], 0));

            var unarranged = images.Skip(1).ToList();


            ImagePos newPos = null;
            do
            {
                newPos = null;
                foreach (var pos in positions)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        var n = pos.Neighbors[i];
                        if (n == null)
                        {
                            int otherIndex = map[i];
                            foreach (var image in unarranged)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    if (pos.Image.Borders[pos.Orientation][i] == Image.ReverseBits(image.Borders[j][otherIndex]))
                                    {
                                        newPos = new ImagePos(image, j);
                                        pos.SetNeighbor(newPos, i);
                                        break;
                                    }
                                }
                                if (newPos != null)
                                {
                                    break;
                                }
                            }
                            if (newPos != null)
                            {
                                break;
                            }
                        }

                        if (newPos != null)
                        {
                            break;
                        }
                    }
                    if (newPos != null)
                    {
                        break;
                    }
                }

                if (newPos != null)
                {
                    unarranged.Remove(newPos.Image);
                    positions.Add(newPos);
                }
            } while (newPos != null);
            Console.WriteLine($"Unarranged left: {unarranged.Count}");


            var minx = positions.Min(_ => _.X);
            var miny = positions.Min(_ => _.Y);
            var maxx = positions.Max(_ => _.X);
            var maxy = positions.Max(_ => _.Y);

            long result = 1;

            var topLeft = positions.FirstOrDefault(p => p.X == minx && p.Y == miny);
            Console.WriteLine($"Top-left {topLeft.Image.Id}");
            result *= topLeft.Image.Id;

            var topRight = positions.FirstOrDefault(p => p.X == maxx && p.Y == miny);
            Console.WriteLine($"Top-right {topRight.Image.Id}");
            result *= topRight.Image.Id;

            var bottomLeft = positions.FirstOrDefault(p => p.X == minx && p.Y == maxy);
            Console.WriteLine($"Bottom-left {bottomLeft.Image.Id}");
            result *= bottomLeft.Image.Id;

            var bottomRight = positions.FirstOrDefault(p => p.X == maxx && p.Y == maxy);
            Console.WriteLine($"Bottom-right {bottomRight.Image.Id}");
            result *= bottomRight.Image.Id;



            Console.WriteLine(result);
        }

        private ImagePos GoDirection(ImagePos pos, int direction)
        {
            if (pos.Neighbors[direction] == null)
            {
                return pos;
            }
            else
            {
                return GoDirection(pos.Neighbors[direction], direction);
            }
        }
    }
}