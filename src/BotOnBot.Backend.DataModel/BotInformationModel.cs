﻿using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class BotInformationModel : ISerializable
    {
        [JsonProperty(PropertyName = "name")]
        public string Name;

        [JsonProperty(PropertyName = "id")]
        public string Id;

        [JsonProperty(PropertyName = "author")]
        public string Author;

        public ISerializable Clone()
            => (BotInformationModel)MemberwiseClone();
    }
}
