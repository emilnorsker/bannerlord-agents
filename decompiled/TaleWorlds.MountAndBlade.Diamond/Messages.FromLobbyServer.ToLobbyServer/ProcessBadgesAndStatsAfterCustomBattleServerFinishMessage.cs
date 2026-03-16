using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;
using TaleWorlds.MountAndBlade.Diamond;
using TaleWorlds.PlayerServices;

namespace Messages.FromLobbyServer.ToLobbyServer;

[Serializable]
[MessageDescription("CustomBattleServerManager", "CustomBattleServerManager", true)]
public class ProcessBadgesAndStatsAfterCustomBattleServerFinishMessage : Message
{
	[JsonProperty]
	public List<BadgeDataEntry> BadgeDataEntries
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
	public PlayerId[] PlayerIds
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
	public ProcessBadgesAndStatsAfterCustomBattleServerFinishMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ProcessBadgesAndStatsAfterCustomBattleServerFinishMessage(List<BadgeDataEntry> badgeDataEntries, PlayerId[] playerIds)
	{
		throw null;
	}
}
