using System;

namespace Assertions.Utilities
{
    internal struct PropertyValue : IEquatable<PropertyValue>
    {
        public string Name { get; }
        public object Value { get; }

        public PropertyValue(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public bool Equals(PropertyValue other)
        {
            return string.Equals(Name, other.Name) && Equals(Value, other.Value);
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
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }
    }
}