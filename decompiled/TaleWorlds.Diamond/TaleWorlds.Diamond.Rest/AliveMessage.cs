using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TaleWorlds.Diamond.Rest;

[Serializable]
[DataContract]
public class AliveMessage : RestRequestMessage
{
	[DataMember]
	public SessionCredentials SessionCredentials
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AliveMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[JsonConstructor]
	public AliveMessage(SessionCredentials sessionCredentials)
	{
		throw null;
	}
}
