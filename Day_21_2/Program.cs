using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_21_2
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
                alergToIng[allergen] = new HashSet<string>(allIngredients);
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

            var count = foods
                .Sum(food => 
                    food.Ingredients.Count(i => cannotContain.Contains(i)));
            Console.WriteLine($"Ingredients cannot possibly contain any of the allergens appear {count} times");

            bool improved;
            do
            {
                improved = false;
                foreach (var pair in alergToIng.Where(pp => pp.Value.Count == 1))
                {
                    var toBeRemoved = pair.Value.First();
                    foreach (var pair2 in alergToIng)
                    {
                        if (pair2.Key != pair.Key)
                        {
                            improved |= pair2.Value.RemoveWhere(s => s == toBeRemoved) > 0;
                        }
                    }
                    if (improved)
                    {
                        break;
                    }
                }
            } while (improved);

            var result = String.Join(",",
                alergToIng
                    .OrderBy(p => p.Key)
                    .Select(pp => pp.Value.First()));
            Console.WriteLine($"Canonical dangerous ingredient list: {result}");
         }
    }
}
