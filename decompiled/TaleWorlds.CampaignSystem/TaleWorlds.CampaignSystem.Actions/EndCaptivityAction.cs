using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Roster;

namespace TaleWorlds.CampaignSystem.Actions;

public static class EndCaptivityAction
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Hero prisoner, EndCaptivityDetail detail, Hero facilitatior = null, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByReleasedAfterBattle(Hero character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByRansom(Hero character, Hero facilitator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByPeace(Hero character, Hero facilitator = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByEscape(Hero character, Hero facilitator = null, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByDeath(Hero character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByReleasedByChoice(FlattenedTroopRoster troopRoster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByReleasedByChoice(Hero character, Hero facilitator = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByReleasedByCompensation(Hero character)
	{
		throw null;
	}
}
