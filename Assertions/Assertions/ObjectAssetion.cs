using System;
using System.Linq.Expressions;

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

        public ObjectStructureAssertion<T> PropertiesWithout(params Expression<Func<T, object>>[] excluded)
            => new ObjectStructureAssertion<T>(_subject)
                .Without(excluded);
    }
}