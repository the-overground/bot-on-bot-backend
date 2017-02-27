using System.Net.Sockets;
using System.Threading.Tasks;

namespace BotOnBot.Backend.Networking
{
    internal abstract class NetworkClient
    {
        protected TcpClient TcpClient { get; private set; }

        protected NetworkClient(TcpClient client)
        {
            TcpClient = client;
        }

        protected async Task<string> ReadNextMessage()
        {
            var result = string.Empty;
            using (var sr = StreamFactory.CreateReader(TcpClient.GetStream()))
            {
                result = await sr.ReadLineAsync();
            }
            return result;
        }

        protected async Task WriteMessage(string message)
        {
            using (var sw = StreamFactory.CreateWriter(TcpClient.GetStream()))
            {
                await sw.WriteLineAsync(message);
            }
        }
    }
}
