using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_21_2
{
    class Food
    {
        public List<string> Ingredients;
        public List<string> Allergens = new List<string>();

        public Food(string str)
        {
            var head = str;
            var pos = str.IndexOf("(contains");
            if (pos > 0)
            {
                head = str.Substring(0, pos).Trim();
            }
            this.Ingredients = head.Split(' ').ToList();
            if (pos > 0)
            {
                var tail = str.Substring(pos + 9);
                tail = tail.Substring(0, tail.Length - 1).Trim();
                this.Allergens = tail.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }
    }
}