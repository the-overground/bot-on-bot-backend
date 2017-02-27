using System.Threading.Tasks;
using BotOnBot.Backend.Core;
using BotOnBot.Backend.Networking;

namespace BotOnBot.Backend.Game
{
    internal sealed class Viewer
    {
        private readonly ViewerClient _client;
        private bool _sentSessionData = false;

        internal Viewer(ViewerClient client)
        {
            _client = client;
        }

        internal async Task Start(string sessionData)
        {
            ConsoleLogger.LogGameEvent($"Send session data to new viewer.");
            await _client.SendSessionData(sessionData);
        }
    }
}
