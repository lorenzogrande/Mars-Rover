using System;
using System.Runtime.Serialization;

namespace Kata
{
    [Serializable]
    public class InvalidMove : Exception
    {
        public InvalidMove()
        {
        }

        public InvalidMove(string message) : base(message)
        {
        }

        public InvalidMove(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidMove(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}