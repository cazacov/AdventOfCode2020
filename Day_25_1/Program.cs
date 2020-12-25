using System;

namespace Day_25_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var timesCard = FindLoopSize(14012298);
            var timesDoor = FindLoopSize(74241);
            Console.WriteLine(TransformSubjNumber(74241, timesCard));
        }

        public static long TransformSubjNumber(long subject, long times)
        {
            long result = 1;
            for (int i = 0; i < times; i++)
            {
                result *= subject;
                result %= 20201227;
            }
            return result;
        }

        public static long FindLoopSize(long publicKey)
        {
            var times = 0;
            var result = 1;
            while (result != publicKey)
            {
                times++;
                result *= 7;
                result %= 20201227;
            }
            return times;
        }
    }

    
}
