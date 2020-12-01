using System;
using System.Linq;

namespace Day_01_1
{
    class Program
    {
        static int Main(string[] args)
        {
            var strings = System.IO.File.ReadAllLines(@"./input.txt").ToList();
            var numbers = strings.ConvertAll(s => Int32.Parse(s));
            numbers.Sort();

            foreach (var a in numbers)
            {
                foreach (var b in numbers)
                {
                    if (b == a)
                    {
                        continue;
                    }
                    if (b + a > 2020)
                    {
                        break;
                    }
                    foreach (var c in numbers)
                    {
                        if (c == a || c == b)
                        {
                            continue;
                        }
                        if (a + b + c == 2020)
                        {
                            Console.WriteLine($"{a}*{b}*{c}={a * b * c}");
                            return 0;
                        }
                        if (a + b + c > 2020)
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Done");
            return 1;
        }
    }
}
