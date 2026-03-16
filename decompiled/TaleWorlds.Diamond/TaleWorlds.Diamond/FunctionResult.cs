using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TaleWorlds.Diamond;

[Serializable]
[KnownType("GetKnownTypes")]
[JsonConverter(typeof(FunctionResultJsonConverter))]
public abstract class FunctionResult
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	static FunctionResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected FunctionResult()
	{
		throw null;
	}
}
