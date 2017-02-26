using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using BotOnBot.Backend.Core;

namespace BotOnBot.Backend.Networking
{
    internal abstract class NetworkListener
    {
        private readonly int _port;
        protected readonly List<TcpClient> _clients = new List<TcpClient>();

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
                AddClient(client);
            }
        }

        internal void StopListening()
        {
            _listener.Stop();
            _isListening = false;
        }

        protected virtual void AddClient(TcpClient client)
        {
            _clients.Add(client);
        }
    }
}
