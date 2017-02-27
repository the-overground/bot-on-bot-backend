using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using BotOnBot.Backend.Core;
using BotOnBot.Backend.Game;
using static Core;

namespace BotOnBot.Backend.Networking
{
    internal sealed class BotListener : NetworkListener
    {
        private const int PORT = 1337;
        private const int MAX_BOTS = 1;
        
        public BotListener()
            : base(PORT)
        { }

        protected override async Task AddClient(TcpClient client)
        {
            var botClient = new BotClient(client);
            await botClient.ListenForInitialMessage();
            _clients.Add(botClient);

            ConsoleLogger.LogGameEvent($"Client connected from {client.Client.RemoteEndPoint.ToString()}!");
            if (_clients.Count == MAX_BOTS)
            {
                StopListening();
                Controller.Start(_clients.Select((c, i) => new Bot((BotClient)c)));
            }
        }
    }
}
