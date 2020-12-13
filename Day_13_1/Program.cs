using System;
using System.Linq;

namespace Day_13_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var lines = System.IO.File.ReadAllLines("input.txt");
            int targetTime = Int32.Parse(lines[0]);
            var buses = lines[1].Split(",").Where(b => b != "x").ToList().ConvertAll(bus => Int32.Parse(bus));


            var wait = 0;

            do
            {
                var time = targetTime + wait;
                foreach (var bus in buses)
                {
                    if (time % bus == 0)
                    {
                        Console.WriteLine($"wait {wait} bus {bus}, result {bus * wait}");
                        return;
                    }
                }

                wait++;
            } while (true);

        }
    }
}
