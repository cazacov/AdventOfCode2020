using System;

namespace Day_17_1
{
    public class Cube
    {
        public int X;
        public int Y;
        public int Z;

        public Cube(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        protected bool Equals(Cube other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cube) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }
}