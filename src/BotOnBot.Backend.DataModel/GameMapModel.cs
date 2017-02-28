using System.Linq;
using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class GameMapModel : ISerializable
    {
        [JsonProperty(PropertyName = "tiles")]
        public TileModel[] Tiles;

        public ISerializable Clone()
        {
            var model = (GameMapModel)MemberwiseClone();
            model.Tiles = Tiles.Select(t => (TileModel)t.Clone()).ToArray();
            return model;
        }
    }
}
