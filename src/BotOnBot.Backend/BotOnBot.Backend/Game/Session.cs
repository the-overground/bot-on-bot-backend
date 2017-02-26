using System;
using BotOnBot.Backend.DataModel;

namespace BotOnBot.Backend.Game
{
    /// <summary>
    /// Represents a game session that clients (AI/viewer) can connect to, identified by a random guid.
    /// </summary>
    internal class Session
    {
        private SessionModel _dataModel;

        internal string Id { get; private set; }
        internal int CurrentTurn { get; private set; }

        internal DateTime StartTime { get; private set; }

        internal Session()
        {
            Id = Guid.NewGuid().ToString();
            _dataModel = new SessionModel
            {
                MaximumCarryCapacity = 10,
                MaximumLemmingsPerPlayer = 20,
                TickDuration = 3000,
                AIInformation = new AIInformationModel[] { },
                YourId = "",
            };
            CurrentTurn = 1;
        }

        internal void Initialize()
        {
            StartTime = DateTime.UtcNow;
        }

        internal string GetData()
        {
            return Serializer.Serialize(_dataModel);
        }
    }
}
