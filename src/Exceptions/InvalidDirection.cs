using System;
using System.Runtime.Serialization;

namespace Kata
{
    [Serializable]
    internal class InvalidDirection : Exception
    {
        public InvalidDirection()
        {
        }

        public InvalidDirection(string message) : base(message)
        {
        }

        public InvalidDirection(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDirection(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}