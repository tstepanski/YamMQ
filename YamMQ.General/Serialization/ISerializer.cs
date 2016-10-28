namespace YamMQ.General.Serialization
{
    public interface ISerializer
    {
        string Serialize<T>(T objectToSerialize);
        T Deserialize<T>(string serializeObject);
    }
}