using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond.Lobby.LocalData;

public class FavoriteServerDataContainer : MultiplayerLocalDataContainer<FavoriteServerData>
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
	public bool TryGetServerData(GameServerEntry serverEntry, out FavoriteServerData favoriteServerData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FavoriteServerDataContainer()
	{
		throw null;
	}
}
