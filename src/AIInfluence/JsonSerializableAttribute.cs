using System;

namespace AIInfluence;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
internal class JsonSerializableAttribute : Attribute
{
}
