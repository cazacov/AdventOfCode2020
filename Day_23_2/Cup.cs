namespace Day_23_2
{
    public class Cup
    {
        public int Value;
        public Cup Next;

        public Cup(int val)
        {
            this.Value = val;
        }

        public override string ToString()
        {
            var result = $"{this.Value} -> ";
            if (this.Next == null)
            {
                result += "NULL";
            }
            else
            {
                result += this.Next.Value.ToString();
            }

            return result;
        }
    }
}