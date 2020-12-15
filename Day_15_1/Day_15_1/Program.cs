using System;

namespace Day_15_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new MemoryGame();
            game.Init("input.txt");

            while (game.turn <= 2020)
            {
                var n = game.NextTurn();
            }
        }
    }
}
