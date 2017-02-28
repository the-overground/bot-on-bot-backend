﻿using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using BotOnBot.Backend.DataModel;

namespace BotOnBot.Backend.Networking
{
    internal abstract class NetworkClient
    {
        internal event Action<NetworkClient> Closed;
        
        internal TcpClient TcpClient { get; private set; }

        protected NetworkClient(TcpClient client)
        {
            TcpClient = client;
        }

        protected async Task<string> ReadNextMessage()
        {
            var result = string.Empty;
            using (var sr = StreamFactory.CreateReader(TcpClient.GetStream()))
            {
                result = await sr.ReadLineAsync();
            }
            return result;
        }

        protected async Task WriteMessage(string message)
        {
            using (var sw = StreamFactory.CreateWriter(TcpClient.GetStream()))
            {
                await sw.WriteLineAsync(message);
            }
        }

        internal async Task Reject(string reason)
        {
            var messageModel = new RejectionResponseModel { Reason = reason };
            var message = Serializer.Serialize(messageModel);
            await WriteMessage(message);
            TcpClient.Dispose();

            Closed?.Invoke(this);
        }
    }
}
