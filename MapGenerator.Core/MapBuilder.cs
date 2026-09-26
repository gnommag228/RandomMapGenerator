using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator.Core
{
    public static class MapBuilder
    {public static Map CreateRestaurantMap(int width, int height, int daySeed)
        {
            IMapGenerationStrategy strategy = new RandomFillStrategy();
            return strategy.Generate(width, height, daySeed);
        }


    }
}
