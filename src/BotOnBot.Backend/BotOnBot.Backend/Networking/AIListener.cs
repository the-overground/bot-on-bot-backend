using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using BotOnBot.Backend.Core;
using BotOnBot.Backend.DataModel;
using BotOnBot.Backend.Game;
using static Core;

namespace BotOnBot.Backend.Networking
{
    internal sealed class AIListener : NetworkListener
    {
        private const int AI_PORT = 1337;
        private const int MAX_PLAYERS = 1;

        private List<AIInformationModel> _informationModels = new List<AIInformationModel>();

        public AIListener()
            : base(AI_PORT)
        { }

        protected override async Task AddClient(TcpClient client)
        {
            var aiClient = new AIClient(client);
            await aiClient.ListenForInitialMessage();
            _clients.Add(aiClient);

            ConsoleLogger.LogGameEvent($"Client connected from {client.Client.RemoteEndPoint.ToString()}!");
            if (_clients.Count == MAX_PLAYERS)
            {
                StopListening();
                Controller.Start(_clients.Select((c, i) => new AI((AIClient)c)));
            }
        }
    }
}
