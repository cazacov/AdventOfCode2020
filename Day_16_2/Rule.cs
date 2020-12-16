namespace Day_16_2
{
    public class Rule
    {
        protected bool Equals(Rule other)
        {
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        
        public readonly string Name;
        private readonly int from1;
        private readonly int to1;
        private readonly int from2;
        private readonly int to2;

        public Rule(string name, int from1, int to1, int from2, int to2)
        {
            this.Name = name;
            this.from1 = from1;
            this.to1 = to1;
            this.from2 = from2;
            this.to2 = to2;
        }

        public override string ToString()
        {
            return $"{Name} {from1}-{to1} or {from2}-{to2}";
        }

        public bool InRange(in int field)
        {
            return field >= from1 && field <= to1 || field >= from2 && field <= to2;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rule) obj);
        }
    }
}