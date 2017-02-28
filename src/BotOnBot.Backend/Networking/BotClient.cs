using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using BotOnBot.Backend.DataModel;

namespace BotOnBot.Backend.Networking
{
    internal sealed class BotClient : NetworkClient
    {
        internal BotInformationModel DataModel { get; private set; }

        internal BotClient(TcpClient client)
            : base(client)
        { }

        internal async Task ListenForInitialMessage()
        {
            // read id data from the stream first:
            string idData = await ReadNextMessage();
            var idModel = Serializer.Deserialize<BotIdentificationModel>(idData);
            DataModel = new BotInformationModel
            {
                Id = Guid.NewGuid().ToString(),
                Author = idModel.Author,
                Name = idModel.Name
            };
        }

        internal async Task SendSessionData(string sessionData)
        {
            await WriteMessage(sessionData);
        }
    }
}
