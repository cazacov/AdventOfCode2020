using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day_22_2
{
    public class Deck
    {
        private List<int> cards = new List<int>();

        public Deck(List<int> init)
        {
            cards.AddRange(init);
        }

        public bool IsEmpty()
        {
            return this.cards.Count == 0;
        }

        public int PullTop()
        {
            var result = cards[0];
            cards.RemoveAt(0);
            return result;
        }

        public void PushBottom(int value)
        {
            cards.Add(value);
        }

        public string Fingerprint()
        {
            return String.Join("-", this.cards.Select(x => x.ToString()));
        }

        public Deck Copy()
        {
            return new Deck(this.cards);
        }

        public int Count()
        {
            return this.cards.Count();
        }

        public string Score()
        {
            long result = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                result += cards[i] * (cards.Count - i);
            }
            return result.ToString();
        }
    }
}