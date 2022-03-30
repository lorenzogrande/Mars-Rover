using System;
using System.Runtime.Serialization;

namespace Kata
{
    [Serializable]
    public class InvalidCommand : Exception
    {
        public InvalidCommand()
        {
        }

        public InvalidCommand(string message) : base(message)
        {
        }

        public InvalidCommand(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCommand(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}