
using MapGenerator.Core;
namespace MapGenerator.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Random random = new Random();

            int width = random.Next(20, 30);
            int height = random.Next(15, 25);

            int seed = random.Next(1, 1000); 

            Map restaurantMap = MapBuilder.CreateRestaurantMap(width, height, seed);
            var repository = new MapRepository();
            await repository.SaveMapAsync(restaurantMap, seed: seed);

            Console.WriteLine("Map successfully generated and saved to PostgreSQL! Number of seed" + " " + seed);

            for (int y = 0; y < restaurantMap.Height; y++)
            {
                for (int x = 0; x < restaurantMap.Width; x++)
                {
                   Tile tile = restaurantMap.Tiles[x, y];

                  char symbol = tile.Type switch
                  {
                        TileType.Wall => '#',
                        TileType.Table => 'T',
                        TileType.Partition => 'P',
                        TileType.Floor => '.',
                        _ => ' '
                  };
                    
                    Console.Write(symbol);
                }
                Console.WriteLine();
                
            }
            Console.ReadLine();

          
        }
    }
}
