# MapGenerator2D — Procedural Restaurant Layout Generator

A lightweight, engine-agnostic C# library built with **.NET 9** for generating procedural 2D grid maps. Specifically designed for restaurant-themed roguelikes, management sims, or grid-based tactics games.

The core architecture follows clean OOP principles, decouples generation logic from rendering engines (like Unity or Godot), and ensures map configurations are fully deterministic based on custom seeds.

---

## Key Features

* **Engine-Agnostic Core:** Pure C# logic with zero external game engine dependencies. Easily integrates into Unity, Godot, or standalone console tools.
* **Design Patterns:** Built around the **Strategy Pattern** (`IMapGenerationStrategy`) for customizable generation algorithms and a **Factory** (`MapGeneratorFactory`) for simple API access.
* **Seed-Based Generation:** Deterministic daily layouts using customizable seed values.
* **Structured Domain Model:** Grid-based tile mapping support (`Floor`, `Wall`, `Partition`, `Table`).

---

## Tech Stack
- **Framework:** .NET 9 / C# 13
- **ORM:** Entity Framework Core 9.0
- **Database:** PostgreSQL 17
- **Patterns:** Factory Method, Strategy Pattern, Repository Pattern

## Persistence & Database Integration
The project uses EF Core with PostgreSQL to persist generated map instances along with their metadata.
- **`EnsureCreatedAsync()`** handles lightweight schema creation automatically.
- Maps are serialized into plain ASCII layout strings for efficient storage and inspection.

---

## Project Structure
```text
MapGenerator2D/
├── MapGenerator.Core/              # Domain logic & generation engine
│   ├── IMapGenerationStrategy.cs   # Strategy interface
│   ├── RestaurantLayoutStrategy.cs # Custom procedural layout logic
│   ├── MapGeneratorFactory.cs      # Factory entry point
│   ├── Map.cs                      # 2D Grid map representation
│   └── Tile.cs                     # Tile definitions & TileType enum
└── MapGenerator.ConsoleApp/
```
---
Usage Example:

using MapGenerator.Core;

// Generate a 25x20 restaurant layout for Day 13 seed
Map restaurantMap = MapGeneratorFactory.CreateRestaurantMap(width: 25, height: 20, daySeed: 13);

// Access grid tiles
Tile tile = restaurantMap.Tiles[5, 10];
Console.WriteLine($"Tile type at (5, 10): {tile.Type}");

---

## Output Preview (Console Visualizer)

```text
#########################
#.......................#
#..T..TP.TP.T..T..T..T..#
#.......................#
#.........T..T..T..T..T.#
#.......................#
#..TP.T..TP....T..T..T..#
#.......................#
#########################
```


//# — Wall / Perimeter

. — Walkable Floor

T — Table

P — Partition / Screen
