using System;
using System.Runtime.Serialization;

namespace Kata
{
    [Serializable]
    public class PlanetRequired : Exception
    {
        public PlanetRequired()
        {
        }

        public PlanetRequired(string message) : base(message)
        {
        }

        public PlanetRequired(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlanetRequired(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}