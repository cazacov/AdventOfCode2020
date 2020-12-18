using System;

namespace Day_18_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input.txt");
            var s = 0L;
            foreach (var line in lines)
            {
                var calculator = new Calculator(line);
                s += calculator.Evaluate();
            }
            Console.WriteLine(s);
        }

       
    }
}
