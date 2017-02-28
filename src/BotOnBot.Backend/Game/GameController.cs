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

            var botListener = new BotListener();
            Task.Run(() => botListener.StartListening());
            var viewerListener = new ViewerListener();
            Task.Run(() => viewerListener.StartListening());
        }

        internal async void Start(IEnumerable<Bot> participatingBots)
        {
            ConsoleLogger.LogGameEvent("All competing bots connected. Starting game.");
            Session.Start(participatingBots.ToArray());

            var tasks = new List<Task>();
            foreach (var bot in Session.Participants)
            {
                tasks.Add(bot.Start(Session.GetData(bot)));
            }
            foreach (var viewer in Viewers)
            {
                tasks.Add(viewer.Start(Session.GetData()));
            }
            await Task.WhenAll(tasks);
            
            ConsoleLogger.LogGameEvent("Finished sending initial session data.");

            Started = true;
        }

        internal async Task AddViewer(Viewer viewer)
        {
            Viewers.Add(viewer);
            if (Started)
            {
                await viewer.Start(Session.GetData());
            }
        }
    }
}
