using System.Threading.Tasks;
using BotOnBot.Backend.Core;
using BotOnBot.Backend.DataModel;
using BotOnBot.Backend.Networking;

namespace BotOnBot.Backend.Game
{
    internal sealed class Bot
    {
        private readonly BotClient _client;

        internal BotInformationModel DataModel { get; private set; }
        internal string Id => DataModel.Id;

        internal Bot(BotClient client)
        {
            _client = client;
            DataModel = _client.DataModel;
        }

        internal async Task Start(string sessionData)
        {
            ConsoleLogger.LogGameEvent($"Send session data to new Bot (\"{DataModel.Name}\" by \"{DataModel.Author}\").");
            await _client.SendSessionData(sessionData);
        }
    }
}
