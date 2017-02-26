using System;
using static Core;

namespace BotOnBot.Backend.Core
{
    internal static class ConsoleLogger
    {
        private const string GAME_EVENT_LOG = "[Turn: {0}, Time: {1}] {2}";

        internal static void LogGameEvent(string eventText)
        {
            var session = Controller.Session;
            var runtime = DateTime.UtcNow - session.StartTime;

            string output =
                $"[Turn: {session.CurrentTurn}, Time: {runtime.ToString()}] {eventText}";

            Console.WriteLine(output);
        }
    }
}
