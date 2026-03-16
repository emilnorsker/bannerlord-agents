using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond.Lobby.LocalData;

public class MatchHistoryDataContainer : MultiplayerLocalDataContainer<MatchHistoryData>
{
	private const int MaxMatchCountPerMatchType = 10;

	private List<MatchHistoryData> _matchesToRemove;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatchHistoryDataContainer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override string GetSaveDirectoryName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override string GetSaveFileName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBeforeRemoveEntry(MatchHistoryData item, out bool canRemoveEntry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBeforeAddEntry(MatchHistoryData item, out bool canAddEntry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override List<MatchHistoryData> DeserializeInCompatibilityMode(string serializedJson)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetHistoryData(string matchId, out MatchHistoryData historyData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<MatchHistoryData> GetOldestMatches(string matchType, int count = 1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetEntryCountOfMatchType(string matchType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void PrintDebugLog(string text)
	{
		throw null;
	}
}
