using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day_14_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var comuter = new Computer();
            Console.WriteLine(comuter.SumRam());
            
        }
    }

    public class Computer
    {
        public List<long> RAM;
        public long AndMask;
        public long OrMask;

        public Computer()
        {
            var lines = System.IO.File.ReadAllLines("input.txt");
            this.RAM = new List<long>();
            foreach (var str in lines)
            {
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
            SetAddr(addr, val);
        }

        private void SetAddr(in int addr, in long val)
        {
            while (addr >= this.RAM.Count)
            {
                this.RAM.Add(0);
            }
            this.RAM[addr] = (val & this.AndMask) | this.OrMask;
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

        public long SumRam()
        {
            var result = 0L;
            foreach (var r in this.RAM)
            {
                result += r;
            }
            return result;
        }
    }
}
