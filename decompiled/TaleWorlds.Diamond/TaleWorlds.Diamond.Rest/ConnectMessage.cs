using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TaleWorlds.Diamond.Rest;

[Serializable]
[DataContract]
public class ConnectMessage : RestRequestMessage
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConnectMessage()
	{
		throw null;
	}
}
