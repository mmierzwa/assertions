using System;

namespace Assertions
{
    public class NumberAssertions<T> where T : struct
    {
        private T _subject;

        public NumberAssertions(T subject)
        {
            if (!(subject is IComparable))
                throw new ArgumentException("Parameter is not an numeric type", nameof(subject));
            
            _subject = subject;
        }

        public void Eq(T arg)
        {
            if (!_subject.Equals(arg))
                throw new ExpectationFailedExceptin($"{_subject} is different than {arg}");
        }
    }
}