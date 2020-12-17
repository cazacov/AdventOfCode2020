using System;

namespace Day_17_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Conway4D();
            game.Init("input.txt");

            for (var i = 0; i < 6; i++)
            {
                game.Next();
                Console.WriteLine("New generation");
            }
            Console.WriteLine(game.ActiveCells());
        }
    }
}
