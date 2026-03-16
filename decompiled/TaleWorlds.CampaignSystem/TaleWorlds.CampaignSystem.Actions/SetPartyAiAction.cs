using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.Actions;

public static class SetPartyAiAction
{
	private enum SetPartyAiActionDetail
	{
		GoToSettlement,
		PatrolAroundSettlement,
		PatrolAroundPoint,
		RaidSettlement,
		BesiegeSettlement,
		EngageParty,
		GoAroundParty,
		DefendParty,
		EscortParty,
		MoveToNearestLand
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(MobileParty owner, Settlement settlement, MobileParty mobileParty, CampaignVec2 position, SetPartyAiActionDetail detail, MobileParty.NavigationType navigationType, bool isFromPort, bool isTargetingPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetActionForVisitingSettlement(MobileParty owner, Settlement settlement, MobileParty.NavigationType navigationType, bool isFromPort, bool isTargetingPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetActionForPatrollingAroundSettlement(MobileParty owner, Settlement settlement, MobileParty.NavigationType navigationType, bool isFromPort, bool isTargetingPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetActionForPatrollingAroundPoint(MobileParty owner, CampaignVec2 position, MobileParty.NavigationType navigationType, bool isFromPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetActionForRaidingSettlement(MobileParty owner, Settlement settlement, MobileParty.NavigationType navigationType, bool isFromPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetActionForBesiegingSettlement(MobileParty owner, Settlement settlement, MobileParty.NavigationType navigationType, bool isFromPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetActionForEngagingParty(MobileParty owner, MobileParty mobileParty, MobileParty.NavigationType navigationType, bool isFromPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetActionForGoingAroundParty(MobileParty owner, MobileParty mobileParty, MobileParty.NavigationType navigationType, bool isFromPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetActionForDefendingSettlement(MobileParty owner, Settlement settlement, MobileParty.NavigationType navigationType, bool isFromPort, bool isTargetingPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetActionForEscortingParty(MobileParty owner, MobileParty mobileParty, MobileParty.NavigationType navigationType, bool isFromPort, bool isTargetingPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetActionForMovingToNearestLand(MobileParty owner, Settlement settlement)
	{
		throw null;
	}
}
