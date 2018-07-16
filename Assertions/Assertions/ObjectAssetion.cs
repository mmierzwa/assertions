using System;

namespace Assertions
{
    public class ObjectAssetion<T>
        where T : class
    {
        private readonly T _subject;

        public ObjectAssetion(T subject)
        {
            _subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }

        public ObjectStructureAssertion<T> Properties()
            => new ObjectStructureAssertion<T>(_subject);
    }
}