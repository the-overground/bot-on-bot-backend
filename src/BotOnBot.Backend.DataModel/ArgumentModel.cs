using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class ArgumentModel : ISerializable
    {
        [JsonProperty(PropertyName = "key")]
        public string Key;

        [JsonProperty(PropertyName = "value")]
        public string Value;

        public ISerializable Clone()
            => (ArgumentModel)MemberwiseClone();
    }
}
