namespace BotOnBot.Backend.Game
{
    internal sealed class GameController
    {
        private Session _session;

        internal static GameController Spawn()
        {
            var instance = new GameController()
            {
                _session = new Session()
            };
            return instance;
        }

        private GameController() { }
    }
}
