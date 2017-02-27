using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotOnBot.Backend.Core;
using BotOnBot.Backend.Networking;

namespace BotOnBot.Backend.Game
{
    internal sealed class GameController
    {
        internal List<Viewer> Viewers { get; } = new List<Viewer>();
        internal Session Session { get; private set; }
        /// <summary>
        /// If the controller is running the game loop.
        /// </summary>
        internal bool IsRunning { get; private set; }
        /// <summary>
        /// If the game session has started.
        /// </summary>
        internal bool Started { get; private set; }
        
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
            Session.Start(participatingAIs.ToArray());

            foreach (var ai in Session.Participants)
            {
                Task.Run(() => ai.Start(Session.GetData(ai)));
            }

            Started = true;
        }

        internal async Task AddViewer(Viewer viewer)
        {
            Viewers.Add(viewer);
            if (Started)
            {
                await viewer.Start();
            }
        }
    }
}
