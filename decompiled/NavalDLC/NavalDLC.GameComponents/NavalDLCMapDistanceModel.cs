using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace NavalDLC.GameComponents;

public class NavalDLCMapDistanceModel : MapDistanceModel
{
	private Dictionary<NavigationType, INavigationCache> _navigationCaches;

	public override int RegionSwitchCostFromLandToSea
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int RegionSwitchCostFromSeaToLand
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override float MaximumSpawnDistanceForCompanionsAfterDisband
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCMapDistanceModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterDistanceCache(NavigationType navigationCapability, INavigationCache cacheToRegister)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetMaximumDistanceBetweenTwoConnectedSettlements(NavigationType navigationCapabilities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetLandRatioOfPathBetweenSettlements(Settlement fromSettlement, Settlement toSettlement, bool isFromPort, bool isTargetingPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDistance(Settlement fromSettlement, Settlement toSettlement, bool isFromPort = false, bool isTargetingPort = false, NavigationType navigationCapability = (NavigationType)3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDistance(Settlement fromSettlement, Settlement toSettlement, bool isFromPort, bool isTargetingPort, NavigationType navigationCapability, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetPortToGateDistanceForSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDistance(MobileParty fromMobileParty, Settlement toSettlement, bool isTargetingPort, NavigationType customCapability, out float estimatedLandRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDistance(MobileParty fromMobileParty, MobileParty toMobileParty, NavigationType customCapability, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool GetDistance(MobileParty fromMobileParty, MobileParty toMobileParty, NavigationType customCapability, float maxDistance, out float distance, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDistance(MobileParty fromMobileParty, in CampaignVec2 toPoint, NavigationType customCapability, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDistance(Settlement fromSettlement, in CampaignVec2 toPoint, bool isFromPort, NavigationType customCapability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool PathExistBetweenPoints(in CampaignVec2 fromPoint, in CampaignVec2 toPoint, NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override (Settlement, bool) GetClosestEntranceToFace(PathFaceRecord face, NavigationType navigationCapabilities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBReadOnlyList<Settlement> GetNeighborsOfFortification(Town town, NavigationType navigationCapabilities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetTransitionCostAdjustment(Settlement settlement1, bool isFromPort, Settlement settlement2, bool isTargetingPort, bool fromIsCurrentlyAtSea, bool toIsCurrentlyAtSea)
	{
		throw null;
	}
}
