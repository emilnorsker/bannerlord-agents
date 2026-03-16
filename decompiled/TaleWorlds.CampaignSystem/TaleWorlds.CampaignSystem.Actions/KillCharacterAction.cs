using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Actions;

public static class KillCharacterAction
{
	public enum KillCharacterActionDetail
	{
		None,
		Murdered,
		DiedInLabor,
		DiedOfOldAge,
		DiedInBattle,
		WoundedInBattle,
		Executed,
		ExecutionAfterMapEvent,
		Lost
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Hero victim, Hero killer, KillCharacterActionDetail actionDetail, bool showNotification, bool isForced = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByOldAge(Hero victim, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByWounds(Hero victim, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByBattle(Hero victim, Hero killer, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByMurder(Hero victim, Hero killer = null, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyInLabor(Hero lostMother, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByExecution(Hero victim, Hero executer, bool showNotification = true, bool isForced = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByExecutionAfterMapEvent(Hero victim, Hero executer, bool showNotification = true, bool isForced = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByRemove(Hero victim, bool showNotification = false, bool isForced = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByDeathMark(Hero victim, bool showNotification = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByDeathMarkForced(Hero victim, bool showNotification = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByPlayerIllness()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void MakeDead(Hero victim, bool disbandVictimParty = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Clan SelectHeirClanForKingdom(Kingdom kingdom, bool exceptRulingClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TextObject CreateObituary(Hero hero, KillCharacterActionDetail detail)
	{
		throw null;
	}
}
