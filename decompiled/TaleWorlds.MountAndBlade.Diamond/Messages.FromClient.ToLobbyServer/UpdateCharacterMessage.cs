using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Core;
using TaleWorlds.Diamond;

namespace Messages.FromClient.ToLobbyServer;

[Serializable]
[MessageDescription("Client", "LobbyServer", true)]
public class UpdateCharacterMessage : Message
{
	[JsonProperty]
	public BodyProperties BodyProperties
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

	[JsonProperty]
	public bool IsFemale
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
	public UpdateCharacterMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UpdateCharacterMessage(BodyProperties bodyProperties, bool isFemale)
	{
		throw null;
	}
}
