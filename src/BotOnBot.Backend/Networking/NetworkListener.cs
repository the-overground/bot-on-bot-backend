using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using BotOnBot.Backend.Core;
using BotOnBot.Backend.DataModel;

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

        internal async Task StartListening()
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
        
        internal void StopListeningTo(NetworkClient client)
        {
            _clients.Remove(client);
        }

        protected virtual async Task AddClient(TcpClient client) { }

        internal static string ResponseStatusToString(ResponseStatusType status)
            => status.ToString().ToUpperInvariant();
    }
}
