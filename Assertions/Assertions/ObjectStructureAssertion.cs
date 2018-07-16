using System;
using System.Collections.Generic;
using System.Linq;

namespace Assertions
{
    public class ObjectStructureAssertion<T> where T : class
    {
        private readonly T _subject;

        public ObjectStructureAssertion(T subject)
        {
            _subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }

        public void Eq<TSecond>(TSecond obj) where TSecond : class
        {
            var subjectProperties = GetPropertiesWithValues(typeof(T), _subject);
            var comparedProperties = GetPropertiesWithValues(typeof(TSecond), obj);

            var propertiesMatch = subjectProperties.All(subjectProperty =>
                comparedProperties.Any(subjectProperty.Equals));
            
            if (!propertiesMatch)
                throw new ExpectationFailedExceptin("Subject object properties does not match compared object");
        }

        private static IEnumerable<PropertyValue> GetPropertiesWithValues(Type type, object obj)
            => type
                .GetProperties()
                .Select(property => new PropertyValue(property.Name, property.GetValue(obj)));
        
        private struct PropertyValue : IEquatable<PropertyValue>
        {
            private readonly string _name;
            private readonly object _value;

            public PropertyValue(string name, object value)
            {
                _name = name;
                _value = value;
            }

            public bool Equals(PropertyValue other)
            {
                return string.Equals(_name, other._name) && Equals(_value, other._value);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is PropertyValue value && Equals(value);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((_name != null ? _name.GetHashCode() : 0) * 397) ^ (_value != null ? _value.GetHashCode() : 0);
                }
            }
        }
    }
}