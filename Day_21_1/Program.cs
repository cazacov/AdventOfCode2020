using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_21_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var foods = new List<Food>();
            var lines = System.IO.File.ReadAllLines("input.txt");

            foods = lines.ToList().ConvertAll(l => new Food(l)).ToList();

            var allAllergens = foods.SelectMany(f => f.Allergens).Distinct().ToList();
            var allIngredients = foods.SelectMany(f => f.Ingredients).Distinct().ToList();

            var alergToIng = new Dictionary<string, HashSet<string>>();
            foreach (var allergen in allAllergens)
            {
                var set = new HashSet<string>(allIngredients);
                alergToIng[allergen] = set;
            }

            foreach (var food in foods)
            {
                foreach (var allergen in food.Allergens)
                {
                    alergToIng[allergen].RemoveWhere(i => !food.Ingredients.Contains(i));
                }
            }

            var canContain = new HashSet<string>();
            foreach (var pair in alergToIng)
            {
                canContain.UnionWith(pair.Value);
                Console.WriteLine($"{pair.Key} can be contained in {String.Join(",", pair.Value)}");
            }

            var cannotContain = new HashSet<string>(allIngredients);
            cannotContain.RemoveWhere(ing => canContain.Contains(ing));

            var count = 0;
            foreach (var food in foods)
            {
                count += food.Ingredients.Count(i => cannotContain.Contains(i));
            }
            Console.WriteLine(count);
         }
    }
}
