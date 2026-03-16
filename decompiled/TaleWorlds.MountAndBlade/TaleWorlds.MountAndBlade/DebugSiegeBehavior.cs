using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public static class DebugSiegeBehavior
{
	public enum DebugStateAttacker
	{
		None,
		DebugAttackersToBallistae,
		DebugAttackersToMangonels,
		DebugAttackersToBattlements
	}

	public enum DebugStateDefender
	{
		None,
		DebugDefendersToBallistae,
		DebugDefendersToMangonels,
		DebugDefendersToRam,
		DebugDefendersToTower
	}

	public static bool ToggleTargetDebug;

	public static DebugStateAttacker DebugAttackState;

	public static DebugStateDefender DebugDefendState;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SiegeDebug(UsableMachine usableMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DebugSiegeBehavior()
	{
		throw null;
	}
}
