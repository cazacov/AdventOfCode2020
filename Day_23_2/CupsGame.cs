using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_23_2
{
    class CupsGame
    {
        public int Round = 0;
        private Cup currentCup;
        public int[] TakeValues;
        public Dictionary<int, Cup> CupMap { get; set; }
        public int MaxValue;

        public CupsGame(string input)
        {
            var cups = new List<int>();
            cups.AddRange(input.ToCharArray().Select(s => Int32.Parse((string) s.ToString())));
            cups.AddRange(Enumerable.Range(10, 1000000-9));
            this.CupMap = new Dictionary<int, Cup>();

            var head = new Cup(0);
            var current = head;
            this.MaxValue = 0;
            foreach (var cup in  cups)
            {
                if (cup > MaxValue)
                {
                    MaxValue = cup;
                }
                var next = new Cup(cup);
                this.CupMap[cup] = next;
                current.Next = next;
                current = next;
            }
            current.Next = head.Next;
            currentCup = head.Next;
            this.TakeValues = new int[3];
        }

        public void PlayRound()
        {
            Round++;
            var takeCup = currentCup.Next;
            var nextCup = currentCup.Next;
            for (int i = 0; i < 3; i++)
            {
                TakeValues[i] = nextCup.Value;
                nextCup = nextCup.Next;
            }
            currentCup.Next = nextCup;


            var destLabel = 0;
            for (var i = 1; i <= 4; i++)
            {
                destLabel = currentCup.Value - i;
                if (destLabel <= 0)
                {
                    destLabel = MaxValue + destLabel;
                }
                if (TakeValues.Contains(destLabel))
                {
                    continue;
                }
                break;
            }

            var destination = CupMap[destLabel];
            var nextAfter = destination.Next;
            destination.Next = takeCup;
            takeCup.Next.Next.Next = nextAfter;
            currentCup = currentCup.Next;
        }

        public void LabelsAfterOne()
        {
            Console.WriteLine("\nCups after one with label '1'");

            var current = CupMap[1].Next;
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
            Console.WriteLine($"Factor or the top two = {(long)CupMap[1].Next.Value * CupMap[1].Next.Next.Value}");
        }
    }
}