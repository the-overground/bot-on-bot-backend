using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ActionModel : ISerializable
    {
        [JsonProperty(PropertyName = "id")]
        public string Id;

        [JsonProperty(PropertyName = "tileId")]
        public string TileId;

        [JsonProperty(PropertyName = "command")]
        public string Command;
    }
}
