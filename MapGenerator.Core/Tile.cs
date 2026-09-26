using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator.Core
{
    public class Tile
    {
        public TileType Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Tile(TileType type, int x, int y)
        {
            Type = type;
            X = x;
            Y = y;
        }
    }
}
