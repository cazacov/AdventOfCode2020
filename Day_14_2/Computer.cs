using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day_14_2
{
    public class Computer
    {
        public long AndMask;
        public long OrMask;
        public Ram Ram = new Ram();
        
        public Computer()
        {
            ReadProgram("input.txt");
        }

        private void ReadProgram(string fileName)
        {
            var lines = System.IO.File.ReadAllLines(fileName);
            // CalculateFloats
            foreach (var str in lines)
            {
                if (str.Trim() == String.Empty)
                {
                    break;
                }
                if (str.StartsWith("mask"))
                {
                    SetMask(str.Substring(7));
                }
                else
                {
                    SetRam(str);
                }
            }
        }

        private void SetRam(string str)
        {
            var r = new Regex(@"mem\[(\d*)\] = (\d*)");
            var m = r.Match(str);
            if (!m.Success)
            {
                throw new ArgumentOutOfRangeException($"Unsupported input format: {str}");
            }
            if (m.Groups.Count != 3)
            {
                throw new ArgumentOutOfRangeException($"Unsupported input format: {str}");
            }
            var addr = int.Parse(m.Groups[1].Value);
            var val = Int64.Parse(m.Groups[2].Value);
            AddRamValues(addr, val);
        }
         
        private void AddRamValues(long addr, long val)
        {
            var xMask = AndMask ^ OrMask;
            var resAddr = (addr | OrMask) & (~xMask);

            List<int> bits = new List<int>();

            for (int i = 0; i < 36; i++)
            {
                if ((xMask & (1L << i)) != 0)
                {
                    bits.Add(i);
                }
            }

            for (long n = 0; n < (1 << bits.Count); n++)
            {
                var mask = 0L;
                for (int i = 0; i < bits.Count; i++)
                {
                    mask |= ((n >> i) & 0x01) << bits[i];
                }
                this.Ram.Write(mask | resAddr, val);
            }
        }

        private void SetMask(string mask)
        {
            var andM = mask;
            andM = andM.Replace("X", "1");
            AndMask = Convert.ToInt64(andM, 2);

            var orM = mask;
            orM = orM.Replace("X", "0");
            OrMask = Convert.ToInt64(orM, 2);
        }
    }
}