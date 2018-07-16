using System;

namespace Assertions
{
    public class NumberAssertion<T> where T : struct, IComparable
    {
        private T _subject;
        private bool _isNegated;

        public NumberAssertion(T subject)
        {
            _subject = subject;
        }

        public void Eq(T arg)
        {
            if (!(_subject.Equals(arg) ^ _isNegated))
                throw new ExpectationFailedException($"{_subject} is different than {arg}");
        }

        public void IsGreater(T arg)
        {
            if (_subject.CompareTo(arg) < 0 ^ _isNegated)
                throw new ExpectationFailedException($"{_subject} is not greater than {arg}");
        }

        public NumberAssertion<T> Not()
        {
            _isNegated = !_isNegated;
            return this;
        }
    }
}