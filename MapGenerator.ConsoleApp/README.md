
# MapGenerator.ConsoleApp

# RandomMapGenerator

A small C#/.NET solution that procedurally generates 2D grid-based restaurant floor plans and persists them to a PostgreSQL database via Entity Framework Core.

## What it does

- Generates a rectangular grid map made of tiles: `Wall`, `Floor`, `Table`, and `Partition`
- Uses a seeded random generator, so the same seed always produces the same layout — generation is fully reproducible
- Places walls around the border, then scatters tables (and occasional partitions next to some of them) across the floor
- Saves each generated map to a PostgreSQL database as a serialized ASCII layout, along with its seed and dimensions
- Prints the generated map directly to the console as ASCII art

## Project structure

This is a Visual Studio solution (`MapGenerator.Core.sln`) with two projects:

| Project | Description |
|---|---|
| `MapGenerator.Core` | Class library with the domain model, generation logic, and EF Core persistence |
| `MapGenerator.ConsoleApp` | Console app that generates a random map, saves it, and prints it |

### MapGenerator.Core

- **`TileType`** — enum of the four possible tile kinds (`Wall`, `Floor`, `Table`, `Partition`)
- **`Tile`** — a single grid cell (type + coordinates)
- **`Map`** — the grid itself (`Tile[,]`), initialized as all-floor
- **`IMapGenerationStrategy`** / **`RandomFillStrategy`** — the generation algorithm, implemented as a Strategy pattern so alternative generation algorithms can be swapped in without changing the rest of the code
- **`MapBuilder`** — entry point (`MapBuilder.CreateRestaurantMap(width, height, seed)`) that runs the strategy and returns a finished `Map`
- **`MapDbContext`** / **`MapEntity`** — EF Core context and the persisted representation of a map
- **`MapRepository`** — serializes a `Map` into an ASCII string and saves it via EF Core (`SaveMapAsync`)

### MapGenerator.ConsoleApp

Picks a random width, height, and seed, builds a map, saves it to PostgreSQL, and renders it straight to the console.

## Requirements

- .NET 9 SDK
- A running PostgreSQL server

By default the app connects using:

```
Host=localhost;Port=5432;Database=map_generator_db;Username=postgres;Password=postgres
```

If your local setup differs, update the connection string in `MapGenerator.Core/MapDbContext.cs`.

## Running it

```bash
git clone https://github.com/gnommag228/RandomMapGenerator.git
cd RandomMapGenerator
dotnet run --project MapGenerator.ConsoleApp
```

Each run:
1. Picks a random width, height, and seed
2. Generates a map and saves it to PostgreSQL
3. Prints the seed that was used
4. Renders the map to the console

## Example output

```
Map successfully generated and saved to PostgreSQL! Number of seed 482
############################
#..........................#
#....T..........P...........#
#...........................#
#.......T....................#
############################
```

(`#` = wall, `.` = floor, `T` = table, `P` = partition)

## Status

Personal learning project, built while studying C#, Entity Framework Core, and object-oriented design patterns (Strategy).
