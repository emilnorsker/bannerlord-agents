using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem;

public class CampaignTickCacheDataStore
{
	private struct PartyTickCachePerParty
	{
		internal MobileParty MobileParty;

		internal MobileParty.CachedPartyVariables LocalVariables;
	}

	private class MobilePartyComparer : IComparer<MobileParty>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(MobileParty x, MobileParty y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MobilePartyComparer()
		{
			throw null;
		}
	}

	private PartyTickCachePerParty[] _cacheData;

	private MobileParty[] _gridChangeMobilePartyList;

	private MobileParty[] _exitingSettlementMobilePartyList;

	private MobileParty[] _navigationTransitionedMobilePartyList;

	private int[] _movingPartyIndices;

	private int _currentFrameMovingPartyCount;

	private int[] _stationaryPartyIndices;

	private int _currentFrameStationaryPartyCount;

	private int[] _transitioningArmyLeaderPartyIndices;

	private int _currentFrameTransitioningArmyLeaderCount;

	private int[] _transitioningPartyIndices;

	private int _currentFrameTransitioningCount;

	private int[] _movingArmyLeaderPartyIndices;

	private int _currentFrameMovingArmyLeaderCount;

	private int[] _stationaryArmyLeaderPartyIndices;

	private int _currentFrameStationaryArmyLeaderCount;

	private int _currentTotalMobilePartyCapacity;

	private int _gridChangeCount;

	private int _exitingSettlementCount;

	private int _navigationTransitionedCount;

	private float _currentDt;

	private float _currentRealDt;

	private readonly TWParallel.ParallelForAuxPredicate _parallelInitializeCachedPartyVariablesPredicate;

	private readonly TWParallel.ParallelForAuxPredicate _parallelCacheTargetPartyVariablesAtFrameStartPredicate;

	private readonly TWParallel.ParallelForAuxPredicate _parallelArrangePartyIndicesPredicate;

	private readonly TWParallel.ParallelForAuxPredicate _parallelTickMovingArmiesPredicate;

	private readonly TWParallel.ParallelForAuxPredicate _parallelTickTransitioningArmiesPredicate;

	private readonly TWParallel.ParallelForAuxPredicate _parallelTickTransitioningPredicate;

	private readonly TWParallel.ParallelForAuxPredicate _parallelTickMovingPartiesPredicate;

	private readonly TWParallel.ParallelForAuxPredicate _parallelTickStationaryPartiesPredicate;

	private readonly TWParallel.ParallelForAuxPredicate _parallelCheckExitingSettlementsPredicate;

	private readonly TWParallel.ParallelForAuxPredicate _parallelTickStationaryArmyLeaderPredicate;

	private readonly MobilePartyComparer _mobilePartyComparer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal CampaignTickCacheDataStore()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ValidateMobilePartyTickDataCache(int currentTotalMobilePartyCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCacheArrays()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitializeDataCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelTickTransitioningArmyLeaders(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelTickTransitioningParties(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelCheckExitingSettlements(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelInitializeCachedPartyVariables(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelCacheTargetPartyVariablesAtFrameStart(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelArrangePartyIndices(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelTickMovingArmies(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelTickMovingParties(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelTickStationaryParties(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelTickStationaryArmyLeaderParties(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RealTick(float dt, float realDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateVisibilitiesAroundMainParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateVisibilitiesBasedOnPoint(CampaignVec2 point, float mainPartyVisibilityRange)
	{
		throw null;
	}
}
