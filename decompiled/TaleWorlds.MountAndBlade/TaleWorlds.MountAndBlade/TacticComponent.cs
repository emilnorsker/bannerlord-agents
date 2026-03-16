using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public abstract class TacticComponent
{
	public static readonly int MoveHornSoundIndex;

	public static readonly int AttackHornSoundIndex;

	public static readonly int RetreatHornSoundIndex;

	protected int _AIControlledFormationCount;

	protected bool IsTacticReapplyNeeded;

	private bool _areFormationsCreated;

	protected Formation _mainInfantry;

	protected Formation _archers;

	protected Formation _leftCavalry;

	protected Formation _rightCavalry;

	protected Formation _rangedCavalry;

	private float _hornCooldownExpireTime;

	private const float HornCooldownTime = 10f;

	public Team Team
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

	protected MBList<Formation> FormationsIncludingSpecialAndEmpty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected MBList<Formation> FormationsIncludingEmpty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected bool AreFormationsCreated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected TacticComponent(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static TacticComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnCancel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnApply()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void TickOccasionally()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetUnitCountByAttackType(Formation formation, out int unitCount, out int rangedCount, out int semiRangedCount, out int nonRangedCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected static float GetFormationGroupEffectivenessOverOrder(IEnumerable<Formation> formationGroup, OrderType orderType, IOrderable targetObject = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected static float GetFormationEffectivenessOverOrder(Formation formation, OrderType orderType, IOrderable targetObject = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	protected internal virtual void DebugTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetAvailableUnitCount(Formation formation, IEnumerable<(Formation, UsableMachine, int)> appliedCombinations)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetVacantSlotCount(UsableMachine weapon, IEnumerable<(Formation, UsableMachine, int)> appliedCombinations)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected List<Formation> ConsolidateFormations(List<Formation> formationsToBeConsolidated, int neededCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected static float CalculateNotEngagingTacticalAdvantage(TeamQuerySystem team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SplitFormationClassIntoGivenNumber(Func<Formation, bool> formationClass, int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool CheckAndSetAvailableFormationsChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetTactic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AssignTacticFormations1121()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected static List<Formation> ChooseAndSortByPriority(IEnumerable<Formation> formations, Func<Formation, bool> isEligible, Func<Formation, bool> isPrioritized, Func<Formation, float> score)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void ManageFormationCounts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ManageFormationCounts(int infantryCount, int rangedCount, int cavalryCount, int rangedCavalryCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void StopUsingAllMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void StopUsingAllRangedSiegeWeapons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SoundTacticalHorn(int soundCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetDefaultBehaviorWeights(Formation f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual float GetTacticWeight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected bool CheckAndDetermineFormation(ref Formation formation, Func<Formation, bool> isEligible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual bool ResetTacticalPositions()
	{
		throw null;
	}
}
