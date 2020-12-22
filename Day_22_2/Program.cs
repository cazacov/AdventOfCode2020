using System;

namespace Day_22_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            int rounds = 0;
            while (game.Play())
            {
                rounds++;
                if (rounds % 1000 == 0)
                {
                    Console.WriteLine($"{rounds} {game.player1.Count} {game.player2.Count}");
                }
            }
            Console.WriteLine(game.WinnerScore());
        }
    }
}
