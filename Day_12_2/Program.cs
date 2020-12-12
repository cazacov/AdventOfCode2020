using System;
using System.Linq;

namespace Day_12_2
{
    class Program
    {
        static void Main(string[] args)
        {

            var lines = System.IO.File.ReadAllLines("input.txt");
            var steps = lines.ToList().ConvertAll(l => new Step(l)).ToList();

            var navigation = new Navigation();
            navigation.Go(steps);
            
            Console.WriteLine(Math.Abs(navigation.PosX) + Math.Abs(navigation.PosY));
        }
    }
}
