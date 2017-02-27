using System.Net.Sockets;
using System.Threading.Tasks;

namespace BotOnBot.Backend.Networking
{
    internal sealed class ViewerClient : NetworkClient
    {
        internal ViewerClient(TcpClient client)
            : base(client)
        { }

        internal async Task SendSessionData(string sessionData)
        {
            await WriteMessage(sessionData);
        }
    }
}
