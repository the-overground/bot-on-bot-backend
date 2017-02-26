using System.Linq;
using System.Net.Sockets;
using BotOnBot.Backend.Core;
using BotOnBot.Backend.Game;
using static Core;

namespace BotOnBot.Backend.Networking
{
    internal sealed class AIListener : NetworkListener
    {
        private const int AI_PORT = 1337;
        private const int MAX_PLAYERS = 1;

        public AIListener()
            : base(AI_PORT)
        { }

        protected override void AddClient(TcpClient client)
        {
            base.AddClient(client);

            ConsoleLogger.LogGameEvent($"Client connected from {client.Client.RemoteEndPoint.ToString()}!");
            if (_clients.Count == MAX_PLAYERS)
            {
                StopListening();
                Controller.Start(_clients.Select(c => new AI(c)));
            }
        }
    }
}
