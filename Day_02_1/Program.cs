using System;
using System.Linq;

namespace Day_02_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var texts = System.IO.File.ReadAllLines("input.txt");
            var passwords = texts.ToList().ConvertAll(t => new Password(t));
            Console.WriteLine(passwords.Count(x => x.IsValid()));
        }
    }
}
