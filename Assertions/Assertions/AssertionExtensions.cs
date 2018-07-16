namespace Assertions
{
    public static class AssertionExtensions
    {
        public static NumberAssertions<T> Expect<T>(this T subject) where T : struct
            => new NumberAssertions<T>(subject);
    }
}