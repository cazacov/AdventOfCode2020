using System;
using System.Linq;

namespace Day_09_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = System.IO.File.ReadAllLines("input.txt").ToList().ConvertAll(s => Int64.Parse(s)).ToList();
            var xmas = new Xmas(numbers, 25);
            var targetNumber = xmas.FindFirstNotSum();
            Console.WriteLine($"Puzzle 1 solution: {targetNumber}");

            xmas.FindContiguousSet(targetNumber);
        }
    }
}