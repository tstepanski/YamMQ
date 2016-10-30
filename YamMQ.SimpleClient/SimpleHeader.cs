using YamMQ.General.Network;

namespace YamMQ.SimpleClient
{
    public sealed class SimpleHeader : IHeader
    {
        public SimpleHeader(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }
    }
}