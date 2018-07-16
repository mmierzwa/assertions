using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Assertions.Utilities
{
    internal static class TypeUtils
    {
        public static string GetPropertyName<T>(Expression<Func<T, object>> propertyExpression) where T : class
        {
            var member = ((MemberExpression) propertyExpression.Body).Member;
            return ((PropertyInfo) member).Name;
        }

        public static IEnumerable<PropertyValue> GetPropertiesWithValues(Type type, object source,
            IEnumerable<string> excludedPropertiesNames)
            => type
                .GetProperties()
                .Select(property => new PropertyValue(property.Name, property.GetValue(source)))
                .Where(property => !excludedPropertiesNames.Contains(property.Name));
    }
}