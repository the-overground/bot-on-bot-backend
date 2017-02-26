using System;
using static Core;

namespace BotOnBot.Backend.Core
{
    internal static class ConsoleLogger
    {
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
