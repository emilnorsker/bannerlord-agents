using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.Map.DistanceCache;

public abstract class NavigationCache<T> where T : ISettlementDataHolder
{
	private Dictionary<NavigationCacheElement<T>, Dictionary<NavigationCacheElement<T>, (float, float)>> _settlementToSettlementDistanceWithLandRatio;

	private Dictionary<T, MBReadOnlyList<T>> _fortificationNeighbors;

	private Dictionary<int, NavigationCacheElement<T>> _closestSettlementsToFaceIndices;

	protected const float AgentRadius = 0.3f;

	protected const float ExtraCostMultiplierForNeighborDetection = 2f;

	public float MaximumDistanceBetweenTwoConnectedSettlements
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	protected MobileParty.NavigationType _navigationType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected NavigationCache(MobileParty.NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void FinalizeCacheInitialization()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CopyTo<T1>(NavigationCache<T1> source, NavigationCache<T> target) where T1 : ISettlementDataHolder
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<T> GetNeighbors(T settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetClosestSettlementToFaceIndex(int faceId, out bool isAtSea)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GenerateCacheData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected float GetSettlementToSettlementDistanceWithLandRatio(NavigationCacheElement<T> settlement1, NavigationCacheElement<T> settlement2, out float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SetSettlementToSettlementDistanceWithLandRatio(NavigationCacheElement<T> settlement1, NavigationCacheElement<T> settlement2, float distance, float landRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddNeighbor(T settlement1, T settlement2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SetClosestSettlementToFaceIndex(int faceId, NavigationCacheElement<T> settlement)
	{
		throw null;
	}

	protected abstract float GetRealDistanceAndLandRatioBetweenSettlements(NavigationCacheElement<T> settlement1, NavigationCacheElement<T> settlement2, out float landRatio);

	protected abstract T GetCacheElement(string settlementId);

	protected abstract NavigationCacheElement<T> GetCacheElement(T settlement, bool isPortUsed);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected float GetLandRatioOfPath(NavigationPath path, Vec2 startPosition)
	{
		throw null;
	}

	protected abstract void GetFaceRecordForPoint(Vec2 position, out bool isOnRegion1);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void GenerateClosestSettlementToFaceCache()
	{
		throw null;
	}

	protected abstract int GetNavMeshFaceCount();

	protected abstract Vec2 GetNavMeshFaceCenterPosition(int faceIndex);

	protected abstract PathFaceRecord GetFaceRecordAtIndex(int faceIndex);

	protected abstract int[] GetExcludedFaceIds();

	protected abstract int GetRegionSwitchCostTo0();

	protected abstract int GetRegionSwitchCostTo1();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void GenerateSettlementToSettlementDistanceCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddClosestEntrancePairBase(T settlement1, bool isPort1, T settlement2, bool isPort2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void GenerateNeighborSettlementsCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckNeighbourAux(List<T> settlementsToConsider, T settlement1, T settlement2, bool useGate1, bool useGate2, ref float distance, ref bool isNeighbour)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected bool CheckBeingNeighbor(List<T> settlementsToConsider, T settlement1, T settlement2)
	{
		throw null;
	}

	protected abstract List<T> GetAllRegisteredSettlements();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected List<T> GetUpdatedSettlementsForNeighborDetection(List<T> settlements)
	{
		throw null;
	}

	protected abstract bool CheckBeingNeighbor(List<T> settlementsToConsider, T settlement1, T settlement2, bool useGate1, bool useGate2, out float foundDistance);

	protected abstract float GetRealPathDistanceFromPositionToSettlement(Vec2 checkPosition, PathFaceRecord currentFaceRecord, float maxDistanceToLookForPathDetection, T currentSettlementToLook, out bool isPort);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected T GetClosestSettlementToPosition(Vec2 checkPosition, PathFaceRecord currentFaceRecord, int[] excludedFaceIds, List<T> settlementRecords, int regionSwitchCostTo0, int regionSwitchCostTo1, float minPathScoreEverFound, out bool isPort)
	{
		throw null;
	}

	protected abstract IEnumerable<T> GetClosestSettlementsToPositionInCache(Vec2 checkPosition, List<T> settlements);

	public abstract void GetSceneXmlCrcValues(out uint sceneXmlCrc, out uint sceneNavigationMeshCrc);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetSettlementsDistanceCacheFileForCapability(string moduleId, out string filePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Serialize(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deserialize(string path)
	{
		throw null;
	}
}
