using BotOnBot.Backend.Game;

internal static class Core
{
    internal static GameController Controller { get; private set; }

    internal static void Main(string[] args)
    {
        Controller = new GameController();
        Controller.Initialize();

        while (Controller.IsRunning)
        { }
    }
}
