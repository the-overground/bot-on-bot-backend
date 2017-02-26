using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EntityModel : ISerializable
    {
        [JsonProperty(PropertyName = "id")]
        public string Id;

        [JsonProperty(PropertyName = "ownerId")]
        public string OwnerId;

        [JsonProperty(PropertyName = "type")]
        public string Type;

        [JsonProperty(PropertyName = "hp")]
        public int HP;

        [JsonProperty(PropertyName = "rotation")]
        public int Rotation;

        [JsonProperty(PropertyName = "args")]
        public ArgumentModel[] Arguments;
    }
}
