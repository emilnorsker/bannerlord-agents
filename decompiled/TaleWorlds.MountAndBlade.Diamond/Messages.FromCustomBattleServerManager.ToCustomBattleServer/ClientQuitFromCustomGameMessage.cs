using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;
using TaleWorlds.PlayerServices;

namespace Messages.FromCustomBattleServerManager.ToCustomBattleServer;

[Serializable]
[MessageDescription("CustomBattleServerManager", "CustomBattleServer", true)]
public class ClientQuitFromCustomGameMessage : Message
{
	[JsonProperty]
	public PlayerId PlayerId
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
	public ClientQuitFromCustomGameMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClientQuitFromCustomGameMessage(PlayerId playerId)
	{
		throw null;
	}
}
