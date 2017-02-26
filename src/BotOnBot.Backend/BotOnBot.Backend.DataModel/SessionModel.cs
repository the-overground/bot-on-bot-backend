using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SessionModel : ISerializable
    {
        [JsonProperty(PropertyName = "maxCarryCap")]
        public int MaximumCarryCapacity;

        [JsonProperty(PropertyName = "maxLemmings")]
        public int MaximumLemmingsPerPlayer;

        [JsonProperty(PropertyName = "tickDuration")]
        public int TickDuration;

        [JsonProperty(PropertyName = "aiInfo")]
        public AIInformationModel[] AIInformation;

        [JsonProperty(PropertyName = "ownId")]
        public string YourId;

        [JsonProperty(PropertyName = "mapData")]
        public GameMapModel GameMap;
    }
}
