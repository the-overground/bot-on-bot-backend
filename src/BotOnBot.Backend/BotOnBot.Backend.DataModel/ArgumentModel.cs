using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ArgumentModel : ISerializable
    {
        [JsonProperty(PropertyName = "key")]
        public string Key;

        [JsonProperty(PropertyName = "value")]
        public string Value;
    }
}
