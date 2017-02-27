using System.Net.Sockets;
using System.Threading.Tasks;
using BotOnBot.Backend.Game;
using static Core;

namespace BotOnBot.Backend.Networking
{
    internal sealed class ViewerListener : NetworkListener
    {
        private const int VIEWER_PORT = 1338;

        public ViewerListener()
            : base(VIEWER_PORT)
        { }

        protected override async Task AddClient(TcpClient client)
        {
            var viewerClient = new ViewerClient(client);
            _clients.Add(viewerClient);

            var viewer = new Viewer(viewerClient);
            await Controller.AddViewer(viewer);
        }
    }
}
