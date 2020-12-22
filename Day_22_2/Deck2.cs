using System;
using System.Collections.Generic;

namespace Day_22_2
{
    public class Deck2 : IDeck
    {
        private const int BUF_SIZE = 64;

        private int[] cards = new int[BUF_SIZE];
        private int head = 0;
        private int tail = 0;

        public Deck2()
        {

        }

        public Deck2(List<int> init)
        {
            foreach (var card in init)
            {
                this.PushBottom(card);
            }
        }
        
        public bool IsEmpty()
        {
            return head == tail;
        }

        public int PullTop()
        {
            var result = cards[tail];
            tail++;
            tail &= 0x3F;
            return result;
        }

        public void PushBottom(int value)
        {
            cards[head] = value;
            head++;
            head &= 0x3F;
        }

        public string Fingerprint()
        {
            //return this.ToString();

            int size = (head + BUF_SIZE - tail) & 0x3F;
            var result = new char[size];

            var ptr = tail;
            for (int i = 0; i < size; i++)
            {
                result[i] = (char) (32 + cards[ptr]);
                ptr++;
                ptr &= 0x3F;
            }
            return new String(result);
        }

        public IDeck Copy(int count)
        {
            var result = new Deck2();
            var ptr = tail;
            for (int i = 0; i < count; i++)
            {
                result.cards[i] = cards[ptr];
                ptr++;
                ptr &= 0x3F;
            }
            result.head = count;
            return result;
        }

        public int Count()
        {
            return (head + BUF_SIZE - tail) & 0x3F;
        }

        public string Score()
        {
            long score = 0;
            int size = (head + BUF_SIZE - tail) & 0x3F;
            var ptr = tail;
            for (int i = 0; i < size; i++)
            {
                var val = cards[ptr];
                score += cards[ptr] * (size - i);
                ptr++;
                ptr &= 0x3F;
            }
            return score.ToString();
        }

        public override string ToString()
        {
            string result = String.Empty;
            int size = (head + BUF_SIZE - tail) & 0x3F;
            var ptr = tail;
            for (int i = 0; i < size; i++)
            {
                if (result != String.Empty)
                {
                    result += ",";
                }
                result += cards[ptr];
                ptr++;
                ptr &= 0x3F;
            }
            return result;
        }
    }
}
