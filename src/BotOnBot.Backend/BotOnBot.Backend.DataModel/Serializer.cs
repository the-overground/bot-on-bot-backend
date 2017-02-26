using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    public static class Serializer
    {
        public static string Serialize(ISerializable obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T Deserialize<T>(string data) where T : ISerializable
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
