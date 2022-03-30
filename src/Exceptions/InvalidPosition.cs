using System;
using System.Runtime.Serialization;

namespace Kata
{
    [Serializable]
    public class InvalidPosition : Exception
    {
        public InvalidPosition()
        {
        }

        public InvalidPosition(string message) : base(message)
        {
        }

        public InvalidPosition(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPosition(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}