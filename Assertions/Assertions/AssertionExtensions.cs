using System;

namespace Assertions
{
    public static class AssertionExtensions
    {
        public static NumberAssertion<int> Expect(this int subject)
            => new NumberAssertion<int>(subject);
        
        public static ActionAssertion Expect(this Action action)
            => new ActionAssertion(action);
        
        public static ObjectAssetion<T> Expect<T>(this T obj) where T : class
            => new ObjectAssetion<T>(obj);
    }
}