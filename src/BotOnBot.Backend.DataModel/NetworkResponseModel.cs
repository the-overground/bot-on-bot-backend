using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class NetworkResponseModel : ISerializable
    {
        [JsonProperty(PropertyName = "status")]
        public string ResponseStatus { get; protected set; }

        public virtual ISerializable Clone()
            => (ISerializable)MemberwiseClone();
    }
}
