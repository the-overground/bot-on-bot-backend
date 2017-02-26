using System.Threading.Tasks;
using BotOnBot.Backend.Core;
using BotOnBot.Backend.DataModel;
using BotOnBot.Backend.Networking;

namespace BotOnBot.Backend.Game
{
    internal sealed class AI
    {
        private readonly AIClient _client;
        private AIInformationModel _dataModel;
        private bool _sentSession = false;

        internal string Id => _dataModel.Id;

        internal AI(AIClient client)
        {
            _client = client;
            _dataModel = _client.DataModel;
        }

        internal async Task Start(string sessionData)
        {
            ConsoleLogger.LogGameEvent($"Send session data to new AI ({_dataModel.Name} by {_dataModel.Author}).");

            using (var sw = StreamFactory.CreateWriter(_client.TcpClient.GetStream()))
            {
                await sw.WriteLineAsync(sessionData);
            }

            _sentSession = true;
        }
    }
}
