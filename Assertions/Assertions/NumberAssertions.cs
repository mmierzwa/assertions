using System;

namespace Assertions
{
    public class NumberAssertions<T> where T : struct, IComparable
    {
        private T _subject;

        public NumberAssertions(T subject)
        {
            _subject = subject;
        }

        public void Eq(T arg)
        {
            if (!_subject.Equals(arg))
                throw new ExpectationFailedExceptin($"{_subject} is different than {arg}");
        }

        public void IsGreater(T arg)
        {
            if (_subject.CompareTo(arg) < 0)
                throw new ExpectationFailedExceptin($"{_subject} is not greater than {arg}");
        }
    }
}