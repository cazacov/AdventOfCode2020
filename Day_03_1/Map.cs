using System.Linq;

namespace Day_03_1
{
    public class Map
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        private bool[,] map;

        public void ReadFromFile(string fileName)
        {
            var strings = System.IO.File.ReadAllLines(fileName);
            this.Height = strings.Length;
            this.Width = strings.First().Length;
            this.map = new bool[Height, Width];

            var y = 0;
            foreach (var str in strings)
            {
                var x = 0;
                foreach (var ch in str.ToCharArray())
                {
                    map[y,x++] = (ch == '#');
                }
                y++;
            }
        }

        public bool HasTree(int x, int y)
        {
            x %= this.Width;
            return y < Height && map[y, x];
        }
    }
}
