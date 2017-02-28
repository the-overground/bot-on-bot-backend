using System.Linq;
using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ChangesModel : ISerializable
    {
        [JsonProperty(PropertyName = "tiles")]
        public TileModel[] Tiles;

        [JsonProperty(PropertyName = "actions")]
        public ActionModel[] Actions;

        [JsonProperty(PropertyName = "gameState")]
        public string GameState;

        [JsonProperty(PropertyName = "currentTurn")]
        public int CurrentTurn;

        public ISerializable Clone()
        {
            var model = (ChangesModel)MemberwiseClone();
            model.Tiles = Tiles.Select(t => (TileModel)t.Clone()).ToArray();
            model.Actions = Actions.Select(a => (ActionModel)a.Clone()).ToArray();
            return model;
        }
    }
}
