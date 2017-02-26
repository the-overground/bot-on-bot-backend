using System;
using System.Collections.Generic;
using System.Text;
using BotOnBot.Backend.DataModel;

namespace BotOnBot.Backend.Game.GameObjects
{
    internal sealed class Tile
    {
        private readonly TileModel _dataModel;

        public Tile(TileModel dataModel)
        {
            _dataModel = dataModel;
        }
    }
}
