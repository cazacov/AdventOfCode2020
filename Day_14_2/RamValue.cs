using System;

namespace Day_14_2
{
    public class RamValue
    {
        public long value;
        public long addrMask;
        public long xMask;

        public override string ToString()
        {
            return $"Addr: {Convert.ToString(addrMask, 2)}   X: {Convert.ToString(xMask, 2)}   Value: {value}";
        }
    }
}