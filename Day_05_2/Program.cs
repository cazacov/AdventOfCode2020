using System;
using System.Linq;

namespace Day_05_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt").ToList();
            var seats = input.ConvertAll(str => new Seat(str));

            var min = seats.Min(seat => seat.Id);
            var max = seats.Max(seat => seat.Id);

            foreach (var id in Enumerable.Range(min, max - min + 1))
            {
                if (!seats.Any(seat => seat.Id == id))
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}