using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TaleWorlds.Diamond.Rest;

[Serializable]
[DataContract]
public class RestObjectResponseMessage : RestResponseMessage
{
	[DataMember]
	private Message _message;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Message GetMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RestObjectResponseMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RestObjectResponseMessage(Message message)
	{
		throw null;
	}
}
