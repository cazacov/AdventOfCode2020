﻿using System;
using System.Collections.Generic;

namespace Day_17_2
{
    public class Conway4D
    {
        private HashSet<Cube> cells = new HashSet<Cube>();
        public void Init(string fileName)
        {
            var lines = System.IO.File.ReadAllLines(fileName);
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (var x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#')
                    {
                        cells.Add(new Cube(x, y, 0, 0));
                    }
                }
            }
        }


        public void Next()
        {
            var next = new HashSet<Cube>();
            GetExtreme(cells, out var min, out var max);

            for (var x = min.X - 1; x <= max.X + 1; x++)
            {
                for (var y = min.Y - 1; y <= max.Y + 1; y++)
                {
                    for (var z = min.Z - 1; z <= max.Z + 1; z++)
                    {
                        for (var w = min.W - 1; w <= max.W + 1; w++)
                        {
                            bool newState;
                            var current = new Cube(x, y, z, w);
                            var count = CountNeighbors(current, cells);
                            if (cells.Contains(current))
                            {
                                newState = (count == 2 || count == 3);
                            }
                            else
                            {
                                newState = count == 3;
                            }

                            if (newState)
                            {
                                next.Add(current);
                            }
                        }
                    }
                }
            }
            cells = next;
        }

        private int CountNeighbors(Cube cube, ICollection<Cube> hashSet)
        {
            int count = 0;
            for (var xx = -1; xx < 2; xx++)
            {
                for (var yy = -1; yy < 2; yy++)
                {
                    for (var zz = -1; zz < 2; zz++)
                    {
                        for (var ww = -1; ww < 2; ww++)
                        {
                            if (xx == 0 && yy == 0 && zz == 0 && ww == 0)
                            {
                                continue;
                            }
                            var c = new Cube(cube.X + xx, cube.Y + yy, cube.Z + zz, cube.W + ww);
                            if (hashSet.Contains(c))
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }

        private void GetExtreme(HashSet<Cube> hashSet, out Cube min, out Cube max)
        {
            min = new Cube(Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue);
            max = new Cube(Int32.MinValue, Int32.MinValue, Int32.MinValue, Int32.MinValue);

            foreach (var cell in hashSet)
            {
                if (cell.X > max.X) max.X = cell.X;
                if (cell.Y > max.Y) max.Y = cell.Y;
                if (cell.Z > max.Z) max.Z = cell.Z;
                if (cell.W > max.W) max.W = cell.W;

                if (cell.X < min.X) min.X = cell.X;
                if (cell.Y < min.Y) min.Y = cell.Y;
                if (cell.Z < min.Z) min.Z = cell.Z;
                if (cell.W < min.W) min.W = cell.W;
            }

        }

        public int ActiveCells()
        {
            return cells.Count;
        }
    }
}