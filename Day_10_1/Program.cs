using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var adapters = System.IO.File.ReadAllLines("input.txt")
                .ToList()
                .ConvertAll(x => Int32.Parse(x))
                .ToList();

            adapters.Add(adapters.Max() + 3);
            adapters.Sort();

            int dif1 = 0;
            int dif3 = 0;

            int voltage = 0;
            int chainLength = 0;

            foreach (var adapter in adapters)
            {
                if (adapter - voltage == 1)
                {
                    dif1++;
                }
                else if (adapter - voltage == 3)
                {
                    dif3++;
                }
                voltage = adapter;
            }
            Console.WriteLine(dif1*dif3);
        }
    }
}
