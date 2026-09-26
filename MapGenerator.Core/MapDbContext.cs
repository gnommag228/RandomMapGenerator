using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MapGenerator.Core;

public class MapEntity
{
    public int Id { get; set; }
    public int Seed { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string LayoutData { get; set; } = string.Empty; 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class MapDbContext : DbContext
{
    public DbSet<MapEntity> Maps => Set<MapEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=map_generator_db;Username=postgres;Password=postgres");
    }
}
