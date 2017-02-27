using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AIIdentificationModel : ISerializable
    {
        [JsonProperty(PropertyName = "name")]
        public string Name;
        
        [JsonProperty(PropertyName = "author")]
        public string Author;

        public ISerializable Clone()
            => (AIIdentificationModel)MemberwiseClone();
    }
}
