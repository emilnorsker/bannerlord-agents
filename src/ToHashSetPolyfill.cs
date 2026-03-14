// Polyfill for IEnumerable<T>.ToHashSet() missing in net472/netstandard2.0
namespace System.Linq
{
    internal static class EnumerableExtensionsPolyfill
    {
        public static System.Collections.Generic.HashSet<T> ToHashSet<T>(
            this System.Collections.Generic.IEnumerable<T> source) =>
            new System.Collections.Generic.HashSet<T>(source);
    }
}
