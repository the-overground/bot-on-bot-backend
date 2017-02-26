using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ChangesModel : ISerializable
    {
        [JsonProperty(PropertyName = "tiles")]
        public TileModel[] Tiles;

        [JsonProperty(PropertyName = "currentTurn")]
        public int CurrentTurn;
    }
}
