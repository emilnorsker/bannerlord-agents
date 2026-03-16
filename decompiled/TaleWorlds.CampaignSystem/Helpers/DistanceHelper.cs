using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace Helpers;

public static class DistanceHelper
{
	public const int BirdFlyDistanceSquaredThresholdForMobilePartyToMobilePartyDistance = 2500;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromSettlementToSettlement(Settlement fromSettlement, Settlement toSettlement, MobileParty.NavigationType navCapabilities, out bool isFromPort, out bool isTargetingPort, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float FindClosestDistanceFromSettlementToSettlementForMobileParty(MobileParty mobileParty, Settlement toSettlement, MobileParty.NavigationType navCapabilities, out bool isFromPort, out bool isTargetingPort, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromSettlementToSettlement(Settlement fromSettlement, Settlement toSettlement, MobileParty.NavigationType navCapabilities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromSettlementToSettlement(Settlement fromSettlement, Settlement toSettlement, MobileParty.NavigationType navCapabilities, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromMobilePartyToSettlement(MobileParty fromMobileParty, Settlement toSettlement, MobileParty.NavigationType navCapabilities, out bool isTargetingPort, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromMobilePartyToSettlement(MobileParty fromMobileParty, Settlement toSettlement, MobileParty.NavigationType navCapabilities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromMobilePartyToSettlement(MobileParty fromMobileParty, Settlement toSettlement, MobileParty.NavigationType navCapabilities, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool FindClosestDistanceFromMobilePartyToSettlement(MobileParty fromMobileParty, Settlement toSettlement, MobileParty.NavigationType navCapabilities, float maxDistance, out float distance, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool FindClosestDistanceFromSettlementToSettlement(Settlement fromSettlement, Settlement toSettlement, MobileParty.NavigationType navCapabilities, float maxDistance, out float distance, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool FindClosestDistanceFromMobilePartyToMobileParty(MobileParty from, MobileParty to, MobileParty.NavigationType navigationType, float maxDistance, out float distance, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromMobilePartyToMobileParty(MobileParty from, MobileParty to, MobileParty.NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromMobilePartyToMobileParty(MobileParty from, MobileParty to, MobileParty.NavigationType navigationType, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromSettlementToPoint(Settlement fromSettlement, CampaignVec2 point, MobileParty.NavigationType navCapabilities, out bool isFromPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromMapPointToSettlement(IMapPoint mapPoint, Settlement toSettlement, MobileParty.NavigationType navCapabilities, out bool isTargetingPort, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromSettlementToPoint(Settlement fromSettlement, CampaignVec2 point, MobileParty.NavigationType navCapabilities, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float FindClosestDistanceFromSettlementToPointForMobileParty(MobileParty mobileParty, CampaignVec2 point, MobileParty.NavigationType navCapabilities, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromMobilePartyToPoint(MobileParty fromMobileParty, CampaignVec2 point, MobileParty.NavigationType navCapabilities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromMobilePartyToPoint(MobileParty fromMobileParty, CampaignVec2 point, MobileParty.NavigationType navCapabilities, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestDistanceFromMapPointToSettlement(IMapPoint mapPoint, Settlement toSettlement, MobileParty.NavigationType navCapabilities, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDistanceBetweenMobilePartyToMobileParty(MobileParty fromMobileParty, MobileParty toMobileParty, MobileParty.NavigationType customCapability, out float landRatio)
	{
		throw null;
	}
}
