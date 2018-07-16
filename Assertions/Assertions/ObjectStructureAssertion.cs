using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Assertions.Utilities;

namespace Assertions
{
    public class ObjectStructureAssertion<T> where T : class
    {
        private readonly T _subject;
        private IEnumerable<string> _excludedPropertiesNames = new List<string>();

        public ObjectStructureAssertion(T subject)
        {
            _subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }

        internal ObjectStructureAssertion<T> Without(Expression<Func<T, object>>[] excluded)
        {
            _excludedPropertiesNames = excluded.Select(TypeUtils.GetPropertyName);
            return this;
        }

        public void Eq<TSecond>(TSecond obj) where TSecond : class
        {
            var subjectProperties = TypeUtils.GetPropertiesWithValues(typeof(T), _subject, _excludedPropertiesNames);
            var comparedProperties = TypeUtils.GetPropertiesWithValues(typeof(TSecond), obj, _excludedPropertiesNames);

            var propertiesMatch = subjectProperties.All(subjectProperty =>
                comparedProperties.Any(subjectProperty.Equals));
            
            if (!propertiesMatch)
                throw new ExpectationFailedException("Subject object properties does not match compared object");
        }
    }
}