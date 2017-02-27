﻿using System.Linq;
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

        public ISerializable Clone()
        {
            var model = (SessionModel)MemberwiseClone();
            model.AIInformation = AIInformation.Select(a => (AIInformationModel)a.Clone()).ToArray();
            model.GameMap = (GameMapModel)GameMap.Clone();
            return model;
        }
    }
}
