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

        public ViewerListener()
            : base(PORT)
        { }

        protected override async Task AddClient(TcpClient client)
        {
            var viewerClient = new ViewerClient(client);

            // if we already have a local viewer client and another one
            // wants to get added, it gets rejected.
            if (viewerClient.IsLocalhost && CheckForLocalViewer())
            {
                RejectClientConnection(client);
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
