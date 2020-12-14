using System.Collections.Generic;

namespace Day_14_2
{
    public class Ram
    {
        private readonly Dictionary<long, long> storage = new Dictionary<long, long>();

        public void Write(long addr, long value)
        {
            this.storage[addr] = value;
        }

        public long SumRam()
        {
            var result = 0L;
            foreach (var pair in this.storage)
            {
                result += pair.Value;
            }
            return result;
        }
    }
}