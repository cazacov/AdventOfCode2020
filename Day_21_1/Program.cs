using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_21_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var foods = new List<Food>();
            var lines = System.IO.File.ReadAllLines("input.txt");

            foods = lines.ToList().ConvertAll(l => new Food(l)).ToList();

        }
    }
}
