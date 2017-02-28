using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using BotOnBot.Backend.Game;
using static Core;

namespace BotOnBot.Backend.Networking
{
    internal sealed class ViewerListener : NetworkListener
    {
        internal const int PORT = 1338;
        private const string REJECT_REASON_TOO_MANY_CLIENTS = "Too many viewer clients have connected.";

        public ViewerListener()
            : base(PORT)
        { }

        protected override async Task AddClient(TcpClient client)
        {
            var viewerClient = new ViewerClient(client);
            viewerClient.Closed += ClientDisconnected;

            // if we already have a local viewer client and another one
            // wants to get added, it gets rejected.
            if (viewerClient.IsLocalhost && CheckForLocalViewer())
            {
                await viewerClient.Reject(REJECT_REASON_TOO_MANY_CLIENTS);
            }
            else
            {
                _clients.Add(viewerClient);

                var viewer = new Viewer(viewerClient);
                await Controller.AddViewer(viewer);
            }
        }

        private bool CheckForLocalViewer()
            => _clients.Any(c => ((ViewerClient)c).IsLocalhost);
    }
}
