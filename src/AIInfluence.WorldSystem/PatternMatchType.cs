using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AIInfluence.WorldSystem;

[JsonConverter(typeof(StringEnumConverter))]
public enum PatternMatchType
{
    Single,
    Consecutive,
    NonConsecutive
}
