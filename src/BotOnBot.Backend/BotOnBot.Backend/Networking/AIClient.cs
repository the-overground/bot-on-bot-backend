using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using BotOnBot.Backend.DataModel;

namespace BotOnBot.Backend.Networking
{
    internal sealed class AIClient : NetworkClient
    {
        internal AIInformationModel DataModel { get; private set; }

        internal AIClient(TcpClient client)
            : base(client)
        { }
        
        internal async Task ListenForInitialMessage()
        {
            // read id data from the stream first:
            string idData = await ReadNextMessage();
            var idModel = Serializer.Deserialize<AIIdentificationModel>(idData);
            DataModel = new AIInformationModel
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
