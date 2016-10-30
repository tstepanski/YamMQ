using Newtonsoft.Json;
using YamMQ.General.Serialization;

namespace YamMQ.SimpleClient
{
    internal sealed class SimpleSerializer : ISerializer
    {
        private SimpleSerializer()
        {
        }

        public static ISerializer Instance { get; } = new SimpleSerializer();

        public string Serialize<T>(T objectToSerialize) => JsonConvert.SerializeObject(objectToSerialize);
        public T Deserialize<T>(string serializeObject) => JsonConvert.DeserializeObject<T>(serializeObject);
    }
}