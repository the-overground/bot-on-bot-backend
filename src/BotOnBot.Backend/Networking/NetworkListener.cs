using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using BotOnBot.Backend.Core;

namespace BotOnBot.Backend.Networking
{
    internal abstract class NetworkListener
    {
        private readonly int _port;
        protected readonly List<NetworkClient> _clients = new List<NetworkClient>();

        private TcpListener _listener;
        private bool _isListening;

        protected NetworkListener(int port)
        {
            _port = port;
            _isListening = false;
        }

        internal async void StartListening()
        {
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Start();
            _isListening = true;

            ConsoleLogger.LogGameEvent($"Starting listening on port {_port}");

            while (_isListening)
            {
                var client = await _listener.AcceptTcpClientAsync();
                await AddClient(client);
            }
        }

        internal void StopListening()
        {
            _listener.Stop();
            _isListening = false;
        }

        protected async Task RejectClientConnection(TcpClient client)
        {
            // send rejection notice:
            using (var sw = StreamFactory.CreateWriter(client.GetStream()))
            {
                await sw.WriteLineAsync("REJECTED");
            }

            // close stream and dispose resources.
            client.Dispose();
        }

        protected virtual async Task AddClient(TcpClient client) { }
    }
}
