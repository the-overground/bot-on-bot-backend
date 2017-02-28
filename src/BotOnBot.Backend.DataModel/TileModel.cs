using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class TileModel : ISerializable
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
        
        public ISerializable Clone()
        {
            var model = (TileModel)MemberwiseClone();
            model.Entity = (EntityModel)Entity?.Clone();
            return model;
        }
    }
}
