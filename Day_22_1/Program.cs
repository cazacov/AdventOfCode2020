using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day_22_1
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
                    Console.WriteLine($"{rounds} {String.Join(" - ", game.players.Select(x => x.ToString()))}");
                }
            }
            Console.WriteLine(game.WinnerScore());
        }
    }

    public class Game
    {
        public List<Player> players = new List<Player>();

        public Game()
        {
            var lines = System.IO.File.ReadAllLines("input.txt").ToList();
            var player1 = new Player(lines.Skip(1).Take(25));
            players.Add(player1);
            var player2 = new Player(lines.Skip(28).Take(25));
            players.Add(player2);
        }

        public bool Play()
        {
            var player1 = players[0];
            var player2 = players[1];
            var card1 = player1.Cards[0];
            var card2 = player2.Cards[0];
            player1.Cards.RemoveAt(0);
            player2.Cards.RemoveAt(0);

            if (card1 > card2)
            {
                player1.Cards.Add(card1);
                player1.Cards.Add(card2);
            }
            else
            {
                player2.Cards.Add(card2);
                player2.Cards.Add(card1);
            }

            return player1.Cards.Count > 0 && player2.Cards.Count > 0;
        }

        public string WinnerScore()
        {
            var cards = new List<int>();
            var player1 = players[0];
            var player2 = players[1];
            if (player1.Cards.Any())
            {
                cards = player1.Cards;
            }
            else
            {
                cards = player2.Cards;
            }

            BigInteger result = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                result += cards[i] * (cards.Count - i);
            }

            return result.ToString();
        }
    }

    public class Player
    {
        public List<int> Cards;

        public Player(IEnumerable<string> cards)
        {
            this.Cards = cards.ToList().ConvertAll(c => Int32.Parse(c)).ToList();
        }
    }
}
