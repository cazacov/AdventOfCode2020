using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_05_1
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = System.IO.File.ReadAllLines("input.txt").ToList();
            var seats = input.ConvertAll(str => new Seat(str));
            Console.WriteLine(seats.Max(seat => seat.Id));
        }
    }
}