using System;

namespace Day_03_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map();
            map.ReadFromFile("input.txt");

            Console.WriteLine(
                map.TreeCount(1, 1)
                * map.TreeCount(3, 1)
                * map.TreeCount(5, 1)
                * map.TreeCount(7, 1)
                * map.TreeCount(1, 2));
        }
    }
}
