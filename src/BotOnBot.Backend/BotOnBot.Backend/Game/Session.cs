using System;
using System.Linq;
using BotOnBot.Backend.DataModel;

namespace BotOnBot.Backend.Game
{
    /// <summary>
    /// Represents a game session that clients (Bot/viewer) can connect to, identified by a random guid.
    /// </summary>
    internal class Session
    {
        private SessionModel _dataModel;

        internal Bot[] Participants { get; private set; }
        internal string Id { get; private set; }
        internal int CurrentTurn { get; private set; }

        internal DateTime StartTime { get; private set; }

        internal Session()
        {
            Id = Guid.NewGuid().ToString();
            CurrentTurn = 1;
            StartTime = DateTime.UtcNow;

            _dataModel = new SessionModel
            {
                MaximumCarryCapacity = 10,
                MaximumLemmingsPerPlayer = 20,
                TickDuration = 3000,
                BotInformation = new BotInformationModel[0],
                YourId = ""
            };
        }

        internal void Start(Bot[] bots)
        {
            Participants = bots;
            _dataModel.BotInformation = bots.Select(a => a.DataModel).ToArray();

            // generate the map from the id here: 
            _dataModel.GameMap = MapFactory.GenerateModel(Id.GetHashCode());
        }
        
        /// <summary>
        /// Returns the session data for a particular bot.
        /// </summary>
        internal string GetData(Bot bot)
        {
            var filteredModel = GameMap.FilterModelForBot(bot, _dataModel);
            filteredModel.YourId = bot.Id;
            return Serializer.Serialize(filteredModel);
        }

        /// <summary>
        /// Returns the entire map data for viewer clients.
        /// </summary>
        internal string GetData()
        {
            return Serializer.Serialize(_dataModel);
        }
    }
}
