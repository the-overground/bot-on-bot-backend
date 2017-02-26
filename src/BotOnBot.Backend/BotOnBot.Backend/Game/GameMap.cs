using System;
using System.Collections.Generic;
using BotOnBot.Backend.DataModel;
using BotOnBot.Backend.Game.GameObjects;
using static Core;

namespace BotOnBot.Backend.Game
{
    internal sealed class GameMap
    {
        private const int MAP_SIZE = 64;

        internal static GameMapModel GenerateModel(int seed)
        {
            var random = new Random(seed);
            var model = new GameMapModel();
            
            var tiles = new List<TileModel>();
            
            for (int x = 0; x < MAP_SIZE; x++)
            {
                for (int y = 0; y < MAP_SIZE; y++)
                {
                    if (x == 4 && y == 4)
                    {
                        tiles.Add(new TileModel
                        {
                            X = x,
                            Y = y,
                            Id = Guid.NewGuid().ToString(),
                            Type = TileType.Ground.ToString(),
                            Entity = CreateBase(Controller.ParticipatingAIs[0])
                        });
                    }
                    else if (x == MAP_SIZE - 4 && y == MAP_SIZE - 4)
                    {
                        tiles.Add(new TileModel
                        {
                            X = x,
                            Y = y,
                            Id = Guid.NewGuid().ToString(),
                            Type = TileType.Ground.ToString(),
                            Entity = CreateBase(Controller.ParticipatingAIs[0])
                        });
                    }
                    else
                    {
                        tiles.Add(new TileModel
                        {
                            X = x,
                            Y = y,
                            Id = Guid.NewGuid().ToString(),
                            Type = TileType.Ground.ToString(),
                            Entity = null
                        });
                    }
                }
            }
            model.Tiles = tiles.ToArray();

            return model;
        }

        private static EntityModel CreateBase(AI owner)
            => new EntityModel
            {
                Id = Guid.NewGuid().ToString(),
                HP = 100,
                OwnerId = owner.Id,
                Rotation = 0,
                Type = EntityType.Building.ToString(),
                Arguments = new[]
                {
                    new ArgumentModel
                    {
                        Key = "buildingType",
                        Value = BuildingType.Base.ToString()
                    }
                }
            };
    }
}
