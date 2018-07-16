using System;

namespace Assertions
{
    public class ActionAssertion
    {
        private readonly Action _subject;

        public ActionAssertion(Action subject)
        {
            _subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }

        public void RaiseError()
        {
            try
            {
                _subject();
            }
            catch
            {
                return;
            }

            throw new ExpectationFailedExceptin("Expected method invocation to throw an exception, but none was thrown");
        }
    }
}