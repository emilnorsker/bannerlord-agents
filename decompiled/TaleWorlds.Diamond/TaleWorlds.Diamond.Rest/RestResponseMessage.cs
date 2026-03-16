using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TaleWorlds.Diamond.Rest;

[Serializable]
[DataContract]
public abstract class RestResponseMessage : RestData
{
	public abstract Message GetMessage();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected RestResponseMessage()
	{
		throw null;
	}
}
