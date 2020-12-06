using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_06_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = new List<string>();
            var lines = System.IO.File.ReadAllLines("input.txt");

            var str = String.Empty;

            foreach(var s in lines)
            {
                if (s == String.Empty)
                {
                    var g = str.ToCharArray().Distinct();
                    groups.Add(new string(g.ToArray()));
                    str = "";
                }
                else
                {
                    str += s;
                }
            }
            Console.WriteLine(groups.Sum(x => x.Length));
        }
    }
}
