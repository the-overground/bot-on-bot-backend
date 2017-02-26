using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotOnBot.Backend.Core;
using BotOnBot.Backend.Networking;

namespace BotOnBot.Backend.Game
{
    internal sealed class GameController
    {
        private AI[] _participatingAIs;

        internal Session Session { get; private set; }
        internal bool IsRunning { get; private set; }
        
        internal void Initialize()
        {
            IsRunning = true;

            Session = new Session();
            Session.Initialize();

            ConsoleLogger.LogGameEvent($"Started game session | id: {Session.Id}");

            var aiListener = new AIListener();
            Task.Run(() => aiListener.StartListening());
        }

        internal void Start(IEnumerable<AI> participatingAIs)
        {
            _participatingAIs = participatingAIs.ToArray();

            var data = Session.GetData();
            foreach (var ai in _participatingAIs)
            {
                Task.Run(() => ai.SendGameSession(data));
            }
        }
    }
}
