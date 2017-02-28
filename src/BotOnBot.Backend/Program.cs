using System.Threading.Tasks;
using BotOnBot.Backend.Game;

internal static class Core
{
    internal static GameController Controller { get; private set; }

    internal static void Main(string[] args)
    {
        Controller = new GameController();
        Task.WaitAll(Controller.Run());
    }
}
