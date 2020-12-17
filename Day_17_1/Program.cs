using System;

namespace Day_17_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Conway3D();
            game.Init("input.txt");

            for (var i = 0; i < 6; i++)
            {
                game.Next();
            }

            Console.WriteLine(game.ActiveCells());
        }
    }
}
