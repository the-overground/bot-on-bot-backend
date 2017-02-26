using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    public static class Serializer
    {
        public static string Serialize(ISerializable obj)
        {
            var serializer = new JsonSerializer();
            var result = string.Empty;

            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, obj);
                    }
                }

                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }

        public static T Deserialize<T>(string data) where T : ISerializable
        {
            T result = default(T);
            var serializer = new JsonSerializer();
            var buffer = Encoding.UTF8.GetBytes(data);

            using (MemoryStream stream = new MemoryStream(buffer))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        result = serializer.Deserialize<T>(reader);
                    }
                }
            }

            return result;
        }
    }
}
