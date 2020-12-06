using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_06_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = new List<string>();
            var lines = System.IO.File.ReadAllLines("input.txt");

            var str = "abcdefghijklmnopqrstuvwxyz";

            foreach (var s in lines)
            {
                if (s == String.Empty)
                {
                    var g = str.ToCharArray().Distinct();
                    groups.Add(new string(g.ToArray()));
                    str = "abcdefghijklmnopqrstuvwxyz";
                }
                else
                {
                    var nl = String.Empty;
                    foreach(var ch in s)
                    {
                        if (str.Contains(ch))
                        {
                            nl += ch;
                        }
                    }
                    str = nl;
                }
            }
            Console.WriteLine(groups.Sum(x => x.Length));
        }
    }
}
