using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_13_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var lines = System.IO.File.ReadAllLines("input.txt");
            var buses = ReadBuses(lines[1]);
            long X = 0;

            long pp = buses.Aggregate<Bus, long>(1, (current, t) => current * t.Mod);

            foreach (var t in buses)
            {
                var mod = t.Mod;
                var rest = mod - t.Rest;
                var m = pp / mod;
                var m1 = inv(m, mod);
                X += rest * m * m1;
                X %= pp;
            }

            Console.WriteLine(X);
        }

        private static long inv(long a, long m)
        {
            long x = 0, y = 0;
            long g = gcd(a, m, ref x, ref y);
            if (g != 1)
            {
                throw new Exception();
            }
            return (x % m + m) % m;
        }

        private static long gcd(long a, long b, ref long x, ref long y)
        {
            if (a == 0)
            {
                x = 0; y = 1;
                return b;
            }
            long x1 = 0, y1 = 0;
            long d = gcd(b % a, a, ref x1, ref y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }

        private static List<Bus> ReadBuses(string line)
        {
            var result = new List<Bus>();
            var buses = line.Split(",");

            for (int i = 0; i < buses.Length; i++)
            {
                if (buses[i] == "x") continue;
                var item = new Bus()
                {
                    Mod = Int32.Parse(buses[i]),
                    Rest = i
                };
                if (item.Rest > item.Mod)
                {
                    item.Rest %= item.Mod;
                }
                result.Add(item);
            }

            return result;
        }
    }

    public class Bus
    {
        public long Mod;
        public long Rest;
    }
}