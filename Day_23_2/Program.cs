using System;

//#define PRINT

namespace Day_23_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new CupsGame("583976241");
            for (int i = 0; i < 10000000; i++)
            {
                game.PlayRound();
                if (game.Round % 100000 == 0)
                {
                    Console.WriteLine($"Rounds played: {game.Round}");
                }
            }
            game.LabelsAfterOne();
        }
    }
}
