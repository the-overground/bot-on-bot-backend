using System.Threading.Tasks;
using BotOnBot.Backend.Core;
using BotOnBot.Backend.DataModel;
using BotOnBot.Backend.Networking;

namespace BotOnBot.Backend.Game
{
    internal sealed class AI
    {
        private readonly AIClient _client;

        internal AIInformationModel DataModel { get; private set; }
        internal string Id => DataModel.Id;

        internal AI(AIClient client)
        {
            _client = client;
            DataModel = _client.DataModel;
        }

        internal async Task Start(string sessionData)
        {
            ConsoleLogger.LogGameEvent($"Send session data to new AI (\"{DataModel.Name}\" by \"{DataModel.Author}\").");
            await _client.SendSessionData(sessionData);
        }
    }
}
