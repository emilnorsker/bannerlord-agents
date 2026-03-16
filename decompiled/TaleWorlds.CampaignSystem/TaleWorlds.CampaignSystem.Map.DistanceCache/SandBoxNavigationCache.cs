using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.Map.DistanceCache;

public class SandBoxNavigationCache : NavigationCache<Settlement>, MapDistanceModel.INavigationCache
{
	private readonly int[] _excludedFaceIds;

	private readonly int _regionSwitchCostTo0;

	private readonly int _regionSwitchCostTo1;

	private IMapScene MapSceneWrapper
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandBoxNavigationCache(MobileParty.NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Settlement GetCacheElement(string settlementId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override NavigationCacheElement<Settlement> GetCacheElement(Settlement settlement, bool isPortUsed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float MapDistanceModel.INavigationCache.GetSettlementToSettlementDistanceWithLandRatio(Settlement settlement1, bool isAtSea1, Settlement settlement2, bool isAtSea2, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetSceneXmlCrcValues(out uint sceneXmlCrc, out uint sceneNavigationMeshCrc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override int GetNavMeshFaceCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Vec2 GetNavMeshFaceCenterPosition(int faceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override PathFaceRecord GetFaceRecordAtIndex(int faceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override int GetRegionSwitchCostTo0()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override int GetRegionSwitchCostTo1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override int[] GetExcludedFaceIds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetRealDistanceAndLandRatioBetweenSettlements(NavigationCacheElement<Settlement> settlement1, NavigationCacheElement<Settlement> settlement2, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void GetFaceRecordForPoint(Vec2 position, out bool isOnRegion1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CheckBeingNeighbor(List<Settlement> settlementsToConsider, Settlement settlement1, Settlement settlement2, bool useGate1, bool useGate2, out float distance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetRealPathDistanceFromPositionToSettlement(Vec2 checkPosition, PathFaceRecord currentFaceRecord, float maxDistanceToLookForPathDetection, Settlement currentSettlementToLook, out bool isPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override IEnumerable<Settlement> GetClosestSettlementsToPositionInCache(Vec2 checkPosition, List<Settlement> settlements)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override List<Settlement> GetAllRegisteredSettlements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizeInitialization()
	{
		throw null;
	}
}
