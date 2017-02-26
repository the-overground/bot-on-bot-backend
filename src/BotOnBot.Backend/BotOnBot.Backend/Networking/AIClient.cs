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
            using (var sr = StreamFactory.CreateReader(TcpClient.GetStream()))
            {
                string idData = await sr.ReadLineAsync();
                var idModel = Serializer.Deserialize<AIIdentificationModel>(idData);
                DataModel = new AIInformationModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Author = idModel.Author,
                    Name = idModel.Name
                };
            }
        }
    }
}
