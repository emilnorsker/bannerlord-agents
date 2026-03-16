using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Diamond.Lobby.LocalData;

public class TauntSlotDataContainer : MultiplayerLocalDataContainer<TauntSlotData>
{
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
	protected override PlatformFilePath GetCompatibilityFilePath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override List<TauntSlotData> DeserializeInCompatibilityMode(string serializedJson)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<TauntIndexData> GetTauntIndicesForPlayer(string playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTauntIndicesForPlayer(string playerId, List<TauntIndexData> tauntIndices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TauntSlotDataContainer()
	{
		throw null;
	}
}
