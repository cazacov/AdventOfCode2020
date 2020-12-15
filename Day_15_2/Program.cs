namespace Day_15_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new MemoryGame();
            game.Init("input.txt");

            while (game.Turn <= 30000000)
            {
                game.NextTurn();
            }
        }
    }
}
