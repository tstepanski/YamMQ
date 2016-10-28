using System;

namespace YamMQ.General.Types
{
    public interface IMessage
    {
        Guid Id { get; }
    }
}