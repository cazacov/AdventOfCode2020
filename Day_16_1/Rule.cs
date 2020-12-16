namespace Day_16_1
{
    public class Rule
    {
        public string Name;
        public int from1;
        public int to1;
        public int from2;
        public int to2;

        public override string ToString()
        {
            return $"{Name} {from1}-{to1} or {from2}-{to2}";
        }

        public bool InRange(in int field)
        {
            return field >= from1 && field <= to1 || field>=from2 && field<= to2;
        }
    }
}