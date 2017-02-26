using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BotOnBot.Backend.Game
{
    internal sealed class AI
    {
        private readonly TcpClient _client;
        private bool _sentSession = false;

        internal AI(TcpClient client)
        {
            _client = client;
        }

        internal async Task SendGameSession(string data)
        {
            using (StreamWriter sw = new StreamWriter(_client.GetStream()))
            {
                await sw.WriteAsync(data);
            }

            _sentSession = true;
        }
    }
}
