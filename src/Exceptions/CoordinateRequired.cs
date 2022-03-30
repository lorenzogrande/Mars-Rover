using System;
using System.Runtime.Serialization;

namespace Kata
{
    [Serializable]
    internal class CoordinateRequired : Exception
    {
        public CoordinateRequired()
        {
        }

        public CoordinateRequired(string message) : base(message)
        {
        }

        public CoordinateRequired(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CoordinateRequired(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}