using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator.Core
{
    public interface IMapGenerationStrategy
    {
        Map Generate(int width, int height, int seed);
    }
    public class RandomFillStrategy : IMapGenerationStrategy
    {
        public Map Generate(int width, int height, int seed)
        {
            Random random = new Random(seed);
            Map map = new Map(width, height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    map.Tiles[x, y].Type = TileType.Floor;
                }
            }
            for (int x = 0; x < width; x++)
            {
                map.Tiles[x, 0].Type = TileType.Wall;
                map.Tiles[x, height - 1].Type = TileType.Wall;
            }
            for (int y = 0; y < height; y++)
            {
                map.Tiles[0, y].Type = TileType.Wall;
                map.Tiles[width - 1, y].Type = TileType.Wall;
            }
            for (int x = 3; x < width - 3; x += 3)
            {
                for (int y = 3; y < height - 3; y += 3)
                {
                    if (random.NextDouble() < 0.8)
                    {
                        map.Tiles[x, y].Type = TileType.Table;
                        if (random.NextDouble() < 0.2 && x + 1 < width - 2)
                        {
                            map.Tiles[x + 1, y].Type = TileType.Partition;
                        }

                    }
                }
            }
            return map;
        }
    }



}
