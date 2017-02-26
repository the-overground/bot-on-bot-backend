﻿using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TileModel : ISerializable
    {
        [JsonProperty(PropertyName = "id")]
        public string Id;

        [JsonProperty(PropertyName = "entity")]
        public EntityModel Entity;

        [JsonProperty(PropertyName = "type")]
        public string Type;

        [JsonProperty(PropertyName = "x")]
        public int X;

        [JsonProperty(PropertyName = "y")]
        public int Y;
    }
}
