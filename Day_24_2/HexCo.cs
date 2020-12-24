using System;
using System.Collections.Generic;

namespace Day_24_2
{
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
            return Equals((HexCo)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public int X = 0;
        public int Y = 0;

        public HexCo()
        {
            this.X = 0;
            this.Y = 0;
        }

        public HexCo(in int x, in int y)
        {
            this.X = x;
            this.Y = y;
        }

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
                var chars = 1;
                if (path.StartsWith("s") || path.StartsWith("n"))
                {
                    chars = 2;
                }
                result.Inc(path.Substring(0, chars));
                path = path.Substring(chars);
            }
            return result;
        }

        public IEnumerable<HexCo> Neighbors()
        {
            var result = new List<HexCo>
            {
                new HexCo(X + 1, Y),
                new HexCo(X + 1, Y - 1),
                new HexCo(X, Y - 1),
                new HexCo(X - 1, Y),
                new HexCo(X - 1, Y + 1),
                new HexCo(X, Y + 1)
            };
            return result;
        }
    }
}