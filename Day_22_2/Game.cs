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

        public Game()
        {
            var lines = System.IO.File.ReadAllLines("input.txt").ToList();
            player1 = lines.Skip(1).Take(25).ToList().ConvertAll<int>(c => Int32.Parse(c)).ToList();
            player2 = lines.Skip(28).Take(25).ToList().ConvertAll<int>(c => Int32.Parse(c)).ToList();
        }

        public bool Play()
        {
            bool isWinnerFirst = IsWinnerFirst(this.player1, this.player2);
            var card1 = player1[0];
            var card2 = player2[0];
            player1.RemoveAt(0);
            player2.RemoveAt(0);

            if (isWinnerFirst)
            {
                player1.Add(card1);
                player1.Add(card2);
            }
            else
            {
                player2.Add(card2);
                player2.Add(card1);
            }
            return player1.Count > 0 && player2.Count > 0;
        }

        private bool IsWinnerFirst(List<int> player1, List<int> player2)
        {
            var card1 = player1[0];
            var card2 = player2[0];
            return card1 > card2;
        }

        public string WinnerScore()
        {
            var cards = new List<int>();
            if (player1.Any())
            {
                cards = player1;
            }
            else
            {
                cards = player2;
            }

            BigInteger result = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                result += cards[i] * (cards.Count - i);
            }

            return result.ToString();
        }
    }
}