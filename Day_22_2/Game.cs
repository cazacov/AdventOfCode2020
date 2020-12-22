//#define PRINT 

using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System;

namespace Day_22_2
{
    public class Game
    {
        public List<int> player1;
        public List<int> player2;
        private HashSet<string> previousRounds = new HashSet<string>();

        public Game(List<int> cards1, List<int> cards2)
        {
            this.player1 = cards1;
            this.player2 = cards2;
        }

        public bool Play(Dictionary<string, bool> cache)
        {
            bool gameResult;
            var str1 = String.Join(",", player1.Select(x => x.ToString()));
            var str2 = String.Join(",", player2.Select(x => x.ToString()));
            var str = str1 + "-" + str2;

            if (cache.ContainsKey(str))
            {
                return cache[str];
            }

            do
            {
                var state1 = String.Join(",", player1.Select(x => x.ToString()));
                var state2 = String.Join(",", player2.Select(x => x.ToString()));
                var state = state1 + "-" + state2;

                if (previousRounds.Contains(state))
                {
                    gameResult = true;
                    break;
                }
                previousRounds.Add(state);

#if (PRINT)
                Console.WriteLine($"\n{state}");
#endif

                var card1 = player1[0];
                var card2 = player2[0];

                if (card1 <= player1.Count - 1
                    && card2 <= player2.Count - 1)
                {
                    var subGame = new Game(
                        player1.GetRange(1, player1.Count - 1),
                        player2.GetRange(1, player2.Count - 1));
#if (PRINT)
                    Console.WriteLine("#### Playing sub-game");
#endif
                    gameResult = subGame.Play(cache);
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
                player1.RemoveAt(0);
                player2.RemoveAt(0);
                if (gameResult)
                {
                    player1.Add(card1);
                    player1.Add(card2);
                }
                else
                {
                    player2.Add(card2);
                    player2.Add(card1);
                }
            } while (player1.Count > 0 && player2.Count > 0);
            cache[str] = gameResult;
            return gameResult;
        }

        public string WinnerScore()
        {
            var cards = player1.Any() ? player1 : player2;

            BigInteger result = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                result += cards[i] * (cards.Count - i);
            }

            return result.ToString();
        }
    }
}