using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_10_2
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

            int voltage = 0;
            int chainLength = 0;

            Dictionary<int, int> chains = new Dictionary<int, int>();
            foreach (var adapter in adapters)
            {
                if (adapter - voltage == 1)
                {
                    chainLength++;
                }
                else if (adapter - voltage == 3)
                {
                    if (chainLength > 0)
                    {
                        if (!chains.ContainsKey(chainLength))
                        {
                            chains[chainLength] = 0;
                        }
                        chains[chainLength] = chains[chainLength] + 1;
                        Console.WriteLine($"Chain of 1s of the length {chainLength}");
                        chainLength = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Oups!");
                }
                voltage = adapter;
            }
            if (chainLength > 0)
            {
                chains[chainLength] = chains[chainLength] + 1;
                Console.WriteLine($"Chain of 1s of the length {chainLength}");
            }

            long waysCount = 1;
            foreach (var pair in chains)
            {
                chainLength = pair.Key;
                var count = pair.Value;
                while (count-- > 0)
                {
                    waysCount *= WayCount(chainLength);
                }
            }
            Console.WriteLine(waysCount);
        }

        public static int WayCount(int chainLength)
        {
            switch (chainLength)
            {
                case 0:
                    return 1;
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 4;
                case 4:
                    return 7;
            }
            return 1;
        }
    }
}