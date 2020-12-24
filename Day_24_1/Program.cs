using System;
using System.Collections.Generic;

namespace Day_24_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input.txt");
            Dictionary<HexCo, bool> tiles = new Dictionary<HexCo, bool>();
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

            int result = 0;
            foreach (var pair in tiles)
            {
                if (pair.Value)
                {
                    result++;
                }
            }
            Console.WriteLine(result);
        }
    }

    class HexCo
    {
        protected bool Equals(HexCo other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HexCo) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public int X = 0;
        public int Y = 0;

        public void Inc(string dir)
        {
            switch (dir)
            {
                case "e":
                    X++;
                    break;
                case "se":
                    X++;
                    Y--;
                    break;
                case "sw":
                    Y--;
                    break;
                case "w":
                    X--;
                    break;
                case "nw":
                    X--;
                    Y++;
                    break;
                case "ne":
                    Y++;
                    break;
            }
        }

        public static HexCo GoPath(string path)
        {
            var result = new HexCo();

            while (path != String.Empty)
            {
                int chars = 1;
                if (path.StartsWith("s") || path.StartsWith("n"))
                {
                    chars = 2;
                }
                result.Inc(path.Substring(0, chars));
                path = path.Substring(chars);
            }

            return result;
        }

    }
}
