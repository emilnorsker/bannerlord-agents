using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond.MultiplayerBadges;

public abstract class GameBadgeTracker
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnPlayerJoin(PlayerData playerData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnKill(KillData killData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnStartingNextBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GameBadgeTracker()
	{
		throw null;
	}
}
