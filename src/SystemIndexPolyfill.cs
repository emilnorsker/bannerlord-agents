// Polyfill System.Index and System.Range for net472
// Required for C# 8+ index-from-end (^n) and range (a..b) syntax.
#if !NET5_0_OR_GREATER && !NETCOREAPP3_0_OR_GREATER

namespace System
{
    internal readonly struct Index
    {
        private readonly int _value;
        public Index(int value, bool fromEnd = false) =>
            _value = fromEnd ? ~value : value;
        public static Index FromEnd(int value) => new Index(value, true);
        public int Value => _value < 0 ? ~_value : _value;
        public bool IsFromEnd => _value < 0;
        public int GetOffset(int length) => IsFromEnd ? length - Value : Value;
        public static implicit operator Index(int value) => new Index(value);
    }

    internal readonly struct Range
    {
        public Index Start { get; }
        public Index End { get; }
        public Range(Index start, Index end) { Start = start; End = end; }
    }
}

namespace System.Runtime.CompilerServices
{
    internal static class RuntimeHelpers
    {
        public static T[] GetSubArray<T>(T[] array, Range range)
        {
            var start = range.Start.IsFromEnd
                ? array.Length - range.Start.Value : range.Start.Value;
            var end = range.End.IsFromEnd
                ? array.Length - range.End.Value : range.End.Value;
            var result = new T[end - start];
            System.Array.Copy(array, start, result, 0, end - start);
            return result;
        }
    }
}

#endif
