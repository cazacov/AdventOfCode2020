using System;

namespace Day_12_2
{
    public class Step
    {
        public char Direction;
        public int Distance;

        public Step(string str)
        {
            this.Direction = str[0];
            this.Distance = Int32.Parse(str.Substring(1));
        }
    }
}