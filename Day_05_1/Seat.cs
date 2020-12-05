using System;

namespace Day_05_1
{
    internal class Seat
    {
        public Seat(string str)
        {
            str = str.Replace("F", "0");
            str = str.Replace("B", "1");
            str = str.Replace("R", "1");
            str = str.Replace("L", "0");
            this.Id = Convert.ToInt32(str, 2);
        }

        public int Id { get; private set; }
    }
}