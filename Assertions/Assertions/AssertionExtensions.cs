using System;

namespace Assertions
{
    public static class AssertionExtensions
    {
        public static NumberAssertion<T> Expect<T>(this T subject) where T : struct, IComparable
            => new NumberAssertion<T>(subject);
        
        public static ActionAssertion Expect(this Action action)
            => new ActionAssertion(action);
    }
}