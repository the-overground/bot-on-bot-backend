using System.Collections.Generic;
using System.Linq;
using BotOnBot.Backend.DataModel;
using static System.Math;

namespace BotOnBot.Backend.Game
{
    internal static class GameMap
    {
        internal static SessionModel FilterModelForAI(AI ai, SessionModel dataModel)
        {
            Point[] ownedTilePositions =
                dataModel.GameMap.Tiles
                    .Where(t => t.Entity != null && t.Entity.OwnerId == ai.Id)
                    .Select(t => new Point(t.X, t.Y)).ToArray();

            var filteredPositions = new List<Point>();
            foreach (var tilePosition in ownedTilePositions)
            {
                for (int x = -4; x < 5; x++)
                {
                    for (int y = -4; y < 5; y++)
                    {
                        var total = Abs(x) + Abs(y);
                        if (total <= 5)
                        {
                            var newPos = new Point(x, y) + tilePosition;
                            if (!filteredPositions.Contains(newPos) &&
                                dataModel.GameMap.Tiles.Any(t => t.X == newPos.X && t.Y == newPos.Y))
                            {
                                filteredPositions.Add(newPos);
                            }
                        }
                    }
                }
            }

            var model = (SessionModel)dataModel.Clone();
            model.GameMap.Tiles = model.GameMap.Tiles.Where(t => filteredPositions.Contains(new Point(t.X, t.Y))).ToArray();

            return model;
        }
    }
}
