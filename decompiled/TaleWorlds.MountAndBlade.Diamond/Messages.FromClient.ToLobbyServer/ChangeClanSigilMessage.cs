using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace Messages.FromClient.ToLobbyServer;

[Serializable]
[MessageDescription("Client", "LobbyServer", true)]
public class ChangeClanSigilMessage : Message
{
	[JsonProperty]
	public string NewSigil
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
	public ChangeClanSigilMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChangeClanSigilMessage(string newSigil)
	{
		throw null;
	}
}
