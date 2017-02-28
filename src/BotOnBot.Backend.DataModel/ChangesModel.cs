using System.Linq;
using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class ChangesModel : NetworkResponseModel
    {
        public ChangesModel()
        {
            ResponseStatus = ResponseStatusType.Ok.ToString();
        }

        [JsonProperty(PropertyName = "tiles")]
        public TileModel[] Tiles;

        [JsonProperty(PropertyName = "actions")]
        public ActionModel[] Actions;

        [JsonProperty(PropertyName = "gameState")]
        public string GameState;

        [JsonProperty(PropertyName = "currentTurn")]
        public int CurrentTurn;

        public override ISerializable Clone()
        {
            var model = (ChangesModel)MemberwiseClone();
            model.Tiles = Tiles.Select(t => (TileModel)t.Clone()).ToArray();
            model.Actions = Actions.Select(a => (ActionModel)a.Clone()).ToArray();
            return model;
        }
    }
}
