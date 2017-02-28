using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class BotIdentificationModel : ISerializable
    {
        [JsonProperty(PropertyName = "name")]
        public string Name;
        
        [JsonProperty(PropertyName = "author")]
        public string Author;

        public ISerializable Clone()
            => (BotIdentificationModel)MemberwiseClone();
    }
}
