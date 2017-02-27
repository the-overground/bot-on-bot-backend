using System.IO;
using System.Text;

namespace BotOnBot.Backend.Networking
{
    internal static class StreamFactory
    {
        private const int DEFAULT_BUFFER_SIZE = 1024;

        internal static StreamReader CreateReader(Stream stream)
            => new StreamReader(stream, Encoding.UTF8, true, DEFAULT_BUFFER_SIZE, true);

        internal static StreamWriter CreateWriter(Stream stream)
            => new StreamWriter(stream, Encoding.UTF8, DEFAULT_BUFFER_SIZE, true);
    }
}
