using System;
using System.Runtime.Serialization;

namespace Kata
{
    [Serializable]
    internal class InvalidPlanetLength : Exception
    {
        public InvalidPlanetLength()
        {
        }

        public InvalidPlanetLength(string message) : base(message)
        {
        }

        public InvalidPlanetLength(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPlanetLength(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}