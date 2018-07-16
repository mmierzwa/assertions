using System;
using System.Runtime.Serialization;

namespace Assertions
{
    public class ExpectationFailedExceptin : Exception
    {
        public ExpectationFailedExceptin()
        {
        }

        protected ExpectationFailedExceptin(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ExpectationFailedExceptin(string message) : base(message)
        {
        }

        public ExpectationFailedExceptin(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}