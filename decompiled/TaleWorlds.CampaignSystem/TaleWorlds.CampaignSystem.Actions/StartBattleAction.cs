using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.Actions;

public static class StartBattleAction
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(PartyBase attackerParty, PartyBase defenderParty, object subject, MapEvent.BattleTypes battleType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Apply(PartyBase attackerParty, PartyBase defenderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyStartBattle(MobileParty attackerParty, MobileParty defenderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyStartRaid(MobileParty attackerParty, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyStartSallyOut(Settlement settlement, MobileParty defenderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyStartAssaultAgainstWalls(MobileParty attackerParty, Settlement settlement)
	{
		throw null;
	}
}
