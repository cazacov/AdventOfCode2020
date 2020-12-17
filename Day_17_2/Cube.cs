using System;

namespace Day_17_2
{
    public class Cube
    {
        public int X;
        public int Y;
        public int Z;
        public int W;

        public Cube(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        protected bool Equals(Cube other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cube)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, W);
        }

        public override string ToString()
        {
            return $"{X},{Y},{Z},{W}";
        }
    }
}