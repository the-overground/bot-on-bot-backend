using System.Net.Sockets;

namespace BotOnBot.Backend.Networking
{
    internal abstract class NetworkClient
    {
        internal TcpClient TcpClient { get; private set; }

        protected NetworkClient(TcpClient client)
        {
            TcpClient = client;
        }
    }
}
