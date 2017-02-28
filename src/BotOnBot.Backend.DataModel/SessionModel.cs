using System.Linq;
using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class SessionModel : NetworkResponseModel
    {
        public SessionModel()
        {
            ResponseStatus = ResponseStatusType.Ok.ToString();
        }

        [JsonProperty(PropertyName = "maxCarryCap")]
        public int MaximumCarryCapacity;

        [JsonProperty(PropertyName = "maxLemmings")]
        public int MaximumLemmingsPerPlayer;

        [JsonProperty(PropertyName = "tickDuration")]
        public int TickDuration;

        [JsonProperty(PropertyName = "botInfo")]
        public BotInformationModel[] BotInformation;

        [JsonProperty(PropertyName = "ownId")]
        public string YourId;

        [JsonProperty(PropertyName = "mapData")]
        public GameMapModel GameMap;

        public override ISerializable Clone()
        {
            var model = (SessionModel)MemberwiseClone();
            model.BotInformation = BotInformation.Select(a => (BotInformationModel)a.Clone()).ToArray();
            model.GameMap = (GameMapModel)GameMap.Clone();
            return model;
        }
    }
}
