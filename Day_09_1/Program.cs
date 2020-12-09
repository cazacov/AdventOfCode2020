using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_09_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = System.IO.File.ReadAllLines("input.txt").ToList().ConvertAll(s => Int64.Parse(s)).ToList();
            var xmas = new XMAS(numbers, 25);
            Console.WriteLine($"Puzzle 1 solution: {xmas.FindFirstNotSum()}");
        }
    }

    public class XMAS
    {
        private readonly int preamble;
        private List<long> numbers;

        public XMAS(List<long> numbers, int preamble)
        {
            this.preamble = preamble;
            this.numbers = numbers;
        }

        public long FindFirstNotSum()
        {
            var i = this.preamble;
            while (i < numbers.Count)
            {
                var target = numbers[i];
                if (!IsSum(i, target))
                {
                    return target;
                }
                Console.WriteLine(i);
                i++;
            }
            throw new Exception("Cannot find the number");
        }

        private bool IsSum(int i, long target)
        {
            for (int j = i - preamble; j < i; j++)
            {
                var c1 = numbers[j];
                if (c1 > target)
                {
                    continue;
                }

                for (var k = i - preamble; k < i; k++)
                {
                    if (k == j)
                    {
                        continue;
                    }

                    if (numbers[k] + c1 == target)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
