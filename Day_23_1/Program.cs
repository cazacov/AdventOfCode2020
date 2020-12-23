using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_23_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new CupsGame("583976241");
            for (int i = 0; i < 100; i++)
            {
                game.PlayRound();
            }
            Console.WriteLine(game.LabelsAfterOne());
        }
    }

    class CupsGame
    {
        public List<int> Cups;
        private int currentPos;
        private int round = 0;

        public CupsGame(string input)
        {
            this.Cups = new List<int>();
            Cups.AddRange(input.ToCharArray().Select(s => Int32.Parse(s.ToString())));
            this.currentPos = 0;
        }

        public void PlayRound()
        {
            round++;
            int curValue = Cups[currentPos];

            Console.WriteLine($"-- move {round} --");
            Console.WriteLine($"cups: {String.Join(" ", this.Cups)}, current {curValue} in position {currentPos}");
            int getPos = currentPos + 1;
            List<int> movedCups = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                if (getPos >= Cups.Count)
                {
                    getPos = 0;
                }
                movedCups.Add(Cups[getPos]);
                Cups.RemoveAt(getPos);
            }
            Console.WriteLine($"pick up: {String.Join(" ", movedCups)}");

            var destCups = this.Cups.Where(c => c < curValue).ToList();
            if (!destCups.Any())
            {
                destCups = this.Cups;
            }
            int destValue = destCups.Max();
            Console.WriteLine($"destination: {destValue}\n");

            int destPos = Cups.IndexOf(destValue) + 1;

            Cups.InsertRange(destPos, movedCups);

            currentPos = Cups.IndexOf(curValue);
            currentPos++;
            if (currentPos >= Cups.Count)
            {
                currentPos = 0;
            }
        }

        public string LabelsAfterOne()
        {
            var result = "";
            var pos = this.Cups.IndexOf(1) + 1;

            for (int i = 0; i < this.Cups.Count - 1; i++)
            {
                if (pos >= this.Cups.Count)
                {
                    pos = 0;
                }
                result += this.Cups[pos];
                pos++;
            }
            return result;
        }
    }
}
