using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_22_2
{
    public class Deck
    {
        private Queue<int> cards = new Queue<int>();

        public Deck(IEnumerable<int> init)
        {
            this.cards = new Queue<int>(init);
        }

        public bool IsEmpty()
        {
            return this.cards.Count == 0;
        }

        public int PullTop()
        {
            return cards.Dequeue();
        }

        public void PushBottom(int value)
        {
            cards.Enqueue(value);
        }

        public string Fingerprint()
        {
            return String.Join(",", this.cards.Select(x => x.ToString()));
        }

        public Deck Copy()
        {
            return new Deck(this.cards.ToArray());
        }

        public int Count()
        {
            return this.cards.Count();
        }

        public string Score()
        {
            long result = 0;
            var data = this.cards.ToArray();

            for (int i = 0; i < cards.Count; i++)
            {
                result += data[i] * (cards.Count - i);
            }
            return result.ToString();
        }
    }
}