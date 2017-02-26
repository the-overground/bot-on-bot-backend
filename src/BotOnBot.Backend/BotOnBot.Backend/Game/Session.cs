using System;

namespace BotOnBot.Backend.Game
{
    /// <summary>
    /// Represents a game session that clients (AI/viewer) can connect to, identified by a random guid.
    /// </summary>
    internal class Session
    {
        private Guid _id;

        internal Session()
        {
            _id = Guid.NewGuid();
        }
    }
}
