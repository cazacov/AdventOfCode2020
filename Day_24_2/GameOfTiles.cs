using System.Collections.Generic;
using System.Linq;

namespace Day_24_2
{
    internal class GameOfTiles
    {
        private Dictionary<HexCo, bool> tiles;

        public GameOfTiles(Dictionary<HexCo, bool> tiles)
        {
            this.tiles = tiles;
        }

        public int CountBlack()
        {
            return tiles.Count(pair => pair.Value);
        }

        public void NextGen()
        {
            var nextgen = new Dictionary<HexCo, bool>();

            var minx = tiles.Where(_ => _.Value).Min(c => c.Key.X) - 1;
            var miny = tiles.Where(_ => _.Value).Min(c => c.Key.Y) - 1;
            var maxx = tiles.Where(_ => _.Value).Max(c => c.Key.X) + 1;
            var maxy = tiles.Where(_ => _.Value).Max(c => c.Key.Y) + 1;

            for (var x = minx; x <= maxx; x++)
            {
                for (var y = miny; y <= maxy; y++)
                {
                    var tile = new HexCo(x,y);
                    var isBlack = tiles.ContainsKey(tile) && tiles[tile];

                    var count = tile.Neighbors().Count(next => tiles.ContainsKey(next) && tiles[next]);

                    if (isBlack)
                    {
                        if (count == 0 || count > 2)
                        {
                            nextgen[tile] = false;
                        }
                        else 
                        {
                            nextgen[tile] = true;
                        }
                    } 
                    else {  // white
                        if (count == 2)
                        {
                            nextgen[tile] = true;
                        }
                        else
                        {
                            nextgen[tile] = false;
                        }
                    }

                }
            }
            this.tiles = nextgen;
        }
    }
}