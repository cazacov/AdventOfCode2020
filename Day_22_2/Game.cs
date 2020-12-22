//#define PRINT 

using System.Collections.Generic;
using System;

namespace Day_22_2
{
    public class Game
    {
        public static long n = 0;
        public Deck player1;
        public Deck player2;
        private HashSet<string> previousRounds = new HashSet<string>();

        public Game(Deck cards1, Deck cards2)
        {
            this.player1 = cards1;
            this.player2 = cards2;
        }

        public bool Play()
        {
            bool gameResult;
            do
            {
                var state = player1.Fingerprint() + "-" + player2.Fingerprint();

                if (previousRounds.Contains(state))
                {
                    gameResult = true;
                    break;
                }
                previousRounds.Add(state);

#if (PRINT)
                Console.WriteLine($"\n{state}");
#endif

                var card1 = player1.PullTop();
                var card2 = player2.PullTop();

                if (card1 <= player1.Count() && card2 <= player2.Count())
                {
                    var subGame = new Game(player1.Copy(), player2.Copy());
#if (PRINT)
                    Console.WriteLine("#### Playing sub-game");
#endif
                    gameResult = subGame.Play();
#if (PRINT)
                    var winner = gameResult ? "Player 1" : "Player 2";
                    Console.WriteLine($"#### Sub-game result: {winner}");
#endif
                }
                else
                {
                    gameResult = card1 > card2;
                }

#if (PRINT)
                if (gameResult)
                {
                    Console.WriteLine("Player 1 wins");
                }
                else
                {
                    Console.WriteLine("Player 2 wins");
                }
#endif
                if (gameResult)
                {
                    player1.PushBottom(card1);
                    player1.PushBottom(card2);
                }
                else
                {
                    player2.PushBottom(card2);
                    player2.PushBottom(card1);
                }
            } while (!player1.IsEmpty() && !player2.IsEmpty());

            n++;
            if (n % 1000 == 0)
            {
                Console.WriteLine(n);
            }
            return gameResult;
        }

        public string WinnerScore()
        {
            var cards = player1.IsEmpty() ? player2 : player1;
            return cards.Score();
        }
    }
}