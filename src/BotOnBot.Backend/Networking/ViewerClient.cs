using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using BotOnBot.Backend.DataModel;

namespace BotOnBot.Backend.Networking
{
    internal sealed class ViewerClient : NetworkClient
    {
        private static readonly IPEndPoint _localhostViewerEndPoint
            = new IPEndPoint(IPAddress.Loopback, ViewerListener.PORT);

        internal ViewerClient(NetworkListener creator, TcpClient client)
            : base(creator, client)
        { }

        internal async Task SendSessionData(string sessionData)
        {
            await WriteMessage(sessionData);
        }

        internal bool IsLocalhost
            => TcpClient.Client.RemoteEndPoint == _localhostViewerEndPoint;
    }
}
