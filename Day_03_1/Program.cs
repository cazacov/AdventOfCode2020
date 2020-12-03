using System;
using System.Linq;

namespace Day_03_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map();
            map.ReadFromFile("input.txt");

            var counter = 0;
            var x = 0;
            foreach (var y in Enumerable.Range(0,map.Height))
            {
                if (map.HasTree(x, y))
                {
                    counter++;
                }
                x += 3;
            }
            Console.WriteLine(counter);
        }
    }
}
