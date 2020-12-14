using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day_14_2
{
    public class Computer
    {
        public long AndMask;
        public long OrMask;
        private string rawMask;
        private List<RamValue> ramValues = new List<RamValue>();

        public Computer()
        {
            var lines = System.IO.File.ReadAllLines("input.txt");
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
            this.ramValues.Add(new RamValue()
            {
                xMask = xMask,
                addrMask = resAddr,
                value = val
            });
        }

        public long SumRamValues()
        {
            UpdateCollisions();

            var collistions = 0;
            for (int i = 0; i < ramValues.Count; i++)
            {
                for (int j = 0; j < ramValues.Count; j++)
                {
                    if (i == j) continue;
                    if (ramValues[i].addrMask == ramValues[j].addrMask 
                        && (ramValues[i].xMask & ramValues[j].xMask) > 0)
                    {
                        collistions++;
                    }
                }
            }

            if (collistions > 0)
            {
                throw new Exception("OMFG");
            }

            long sum = 0;
            foreach (var ramValue  in ramValues)
            {
                var bits = CountBits(ramValue.xMask);
                if (bits > 0)
                {
                    sum += ramValue.value * (1L << (bits));
                }
            }
            return sum;
        }

        private int CountBits(long val)
        {
            var result = 0;
            while (val > 0)
            {
                if ((val & 1) > 0)
                {
                    result++;
                }
                val >>= 1;
            }
            return result;
        }

        private void UpdateCollisions()
        {
            for (int i = ramValues.Count - 1; i > 0; i--)
            {
                for (int j = i-1; j >= 0; j--)
                {
                    if (ramValues[i].addrMask == ramValues[j].addrMask)
                    {
                        ramValues[j].xMask &= ~ramValues[i].xMask;
                    }
                }
            }
        }


        private void SetMask(string mask)
        {
            this.rawMask = mask;

            var andM = mask;
            andM = andM.Replace("X", "1");
            AndMask = Convert.ToInt64(andM, 2);

            var orM = mask;
            orM = orM.Replace("X", "0");
            OrMask = Convert.ToInt64(orM, 2);
        }
    }
}