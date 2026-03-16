using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TaleWorlds.Diamond.Rest;

[Serializable]
[DataContract]
public class RestObjectFunctionResult : RestFunctionResult
{
	[DataMember]
	private FunctionResult _functionResult;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override FunctionResult GetFunctionResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RestObjectFunctionResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RestObjectFunctionResult(FunctionResult functionResult)
	{
		throw null;
	}
}
