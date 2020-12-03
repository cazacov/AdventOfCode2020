using System.Linq;

namespace Day_03_2
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
                    map[y, x++] = (ch == '#');
                }
                y++;
            }
        }

        public bool HasTree(int x, int y)
        {
            x %= this.Width;
            return y < Height && map[y, x];
        }

        public long TreeCount(int slope_x, int slope_y)
        {
            var counter = 0L;
            var x = 0;
            var y = 0;
            while (y < Height)
            {
                if (HasTree(x, y))
                {
                    counter++;
                }
                x += slope_x;
                y += slope_y;
            }
            return counter;
        }
    }
}
