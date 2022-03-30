using System;
using System.Runtime.Serialization;

namespace Kata
{
    [Serializable]
    internal class RoverRequired : Exception
    {
        public RoverRequired()
        {
        }

        public RoverRequired(string message) : base(message)
        {
        }

        public RoverRequired(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RoverRequired(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}