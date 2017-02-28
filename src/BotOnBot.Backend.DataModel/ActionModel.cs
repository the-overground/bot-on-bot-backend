using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class ActionModel : ISerializable
    {
        [JsonProperty(PropertyName = "id")]
        public string Id;

        [JsonProperty(PropertyName = "ownerId")]
        public string OwnerId;

        [JsonProperty(PropertyName = "entityId")]
        public string EntityId;

        [JsonProperty(PropertyName = "command")]
        public string Command;

        public ISerializable Clone()
            => (ActionModel)MemberwiseClone();
    }
}
