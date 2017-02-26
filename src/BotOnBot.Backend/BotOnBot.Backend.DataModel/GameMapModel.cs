using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GameMapModel : ISerializable
    {
        [JsonProperty(PropertyName = "tiles")]
        public TileModel[] Tiles;
    }
}
