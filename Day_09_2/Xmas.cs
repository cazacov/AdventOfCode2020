using System;
using System.Collections.Generic;

namespace Day_09_2
{
    public class Xmas
    {
        private readonly int preamble;
        private List<long> numbers;
        private long[,] sets;

        public Xmas(List<long> numbers, int preamble)
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

        public void FindContiguousSet(in long targetNumber)
        {
            Console.WriteLine($"Looking for set of contiguous numbers summing to {targetNumber}");
            for (var len = 2; len < numbers.Count - preamble; len++)
            {
                Console.WriteLine($"Checking sum of length {len}");
                long sum = 0;
                for (int i = preamble; i < preamble + len; i++)
                {
                    sum += numbers[i];
                }
                if (sum == targetNumber)
                {
                    ShowSolution(len, preamble);
                    return;
                }
                for (int j = preamble+len; j < numbers.Count; j++)
                {
                    sum += numbers[j];
                    sum -= numbers[j - len];
                    if (sum == targetNumber)
                    {
                        ShowSolution(len, j-len + 1);
                        return;
                    }
                }
            }
        }

        private void ShowSolution(in int len, in int startIndex)
        {
            Console.WriteLine($"Solution found. Length {len}, start index {startIndex}");

            long min = Int64.MaxValue;
            long max = 0;

            long sum = 0;
            for (int j = 0; j < len; j++)
            {
                var n = numbers[startIndex + j];
                sum += n;
                Console.WriteLine($"{n}\t{sum}");
                if (n > max)
                {
                    max = n;
                }

                if (n < min)
                {
                    min = n;
                }
            }
            Console.WriteLine($"Encryption weakness: {min + max}");
        }
    }
}