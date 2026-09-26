using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator.Core;

public class MapRepository
{
    public async Task SaveMapAsync(Map map, int seed)
    {
        using var db = new MapDbContext();

       
        await db.Database.EnsureCreatedAsync();

        string layout = SerializeMap(map);

        var entity = new MapEntity
        {
            Seed = seed,
            Width = map.Width,
            Height = map.Height,
            LayoutData = layout
        };

        db.Maps.Add(entity);
        await db.SaveChangesAsync();
    }

    
    private string SerializeMap(Map map)
    {
        var sb = new StringBuilder();
        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                var tile = map.Tiles[x, y];
                char symbol = tile.Type switch
                {
                    TileType.Wall => '#',
                    TileType.Floor => '.',
                    TileType.Table => 'T',
                    TileType.Partition => 'P',
                    _ => ' '
                };
                sb.Append(symbol);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}