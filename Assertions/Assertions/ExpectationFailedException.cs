using System;
using System.Runtime.Serialization;

namespace Assertions
{
    public class ExpectationFailedException : Exception
    {
        public ExpectationFailedException()
        {
        }

        protected ExpectationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ExpectationFailedException(string message) : base(message)
        {
        }

        public ExpectationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}