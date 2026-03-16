using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TaleWorlds.Diamond.Rest;

[Serializable]
[DataContract]
public class DisconnectMessage : RestRequestMessage
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public DisconnectMessage()
	{
		throw null;
	}
}
