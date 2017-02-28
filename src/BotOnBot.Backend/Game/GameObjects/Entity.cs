using BotOnBot.Backend.Core;
using BotOnBot.Backend.DataModel;

namespace BotOnBot.Backend.Game.GameObjects
{
    public abstract class Entity
    {
        protected EntityModel _dataModel;

        internal EntityType EntityType => EnumParser.Parse<EntityType>(_dataModel.Type);

        //internal (int x, int y) Position => (_dataModel.)
    }
}
