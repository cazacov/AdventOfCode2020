using System;

namespace Day_01_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var known_numbers = new System.Collections.Generic.HashSet<int>();


            using (var file = new System.IO.StreamReader(@"./input.txt"))
            {
                String line;

                while ((line = file.ReadLine()) != null)
                {
                    int n = Int32.Parse(line);
                    int complement = 2020 - n;
                    if (known_numbers.Contains(complement))
                    {
                        Console.WriteLine($"{complement} + {n} = 2020, {complement}*{n}={complement * n}");
                        break;
                    }
                    else
                    {
                        known_numbers.Add(n);
                    }
                }
            }
            Console.WriteLine("Done");
        }
    }
}
