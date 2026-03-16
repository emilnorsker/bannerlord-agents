using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TaleWorlds.Diamond;

[Serializable]
[DataContract]
public abstract class LoginMessage : Message
{
	[DataMember]
	public PeerId PeerId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[JsonProperty]
	public AccessObject AccessObject
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
	public LoginMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected LoginMessage(PeerId peerId, AccessObject accessObject)
	{
		throw null;
	}
}
