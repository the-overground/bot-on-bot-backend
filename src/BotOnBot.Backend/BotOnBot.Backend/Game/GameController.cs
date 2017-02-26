using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotOnBot.Backend.Core;
using BotOnBot.Backend.Networking;

namespace BotOnBot.Backend.Game
{
    internal sealed class GameController
    {
        internal AI[] ParticipatingAIs { get; private set; }
        internal Session Session { get; private set; }
        internal bool IsRunning { get; private set; }
        
        internal void Initialize()
        {
            IsRunning = true;

            Session = new Session();

            ConsoleLogger.LogGameEvent($"Started game session | id: {Session.Id}");

            var aiListener = new AIListener();
            Task.Run(() => aiListener.StartListening());
        }

        internal void Start(IEnumerable<AI> participatingAIs)
        {
            ParticipatingAIs = participatingAIs.ToArray();

            Session.Start();

            var data = Session.GetData();
            foreach (var ai in ParticipatingAIs)
            {
                Task.Run(() => ai.Start(data));
            }
        }
    }
}
