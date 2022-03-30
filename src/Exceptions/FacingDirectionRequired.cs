using System;
using System.Runtime.Serialization;

namespace Kata
{
    [Serializable]
    internal class FacingDirectionRequired : Exception
    {
        public FacingDirectionRequired()
        {
        }

        public FacingDirectionRequired(string message) : base(message)
        {
        }

        public FacingDirectionRequired(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FacingDirectionRequired(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}