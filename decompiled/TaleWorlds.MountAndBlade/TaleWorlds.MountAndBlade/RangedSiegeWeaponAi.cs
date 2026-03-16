using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.DividableTasks;

namespace TaleWorlds.MountAndBlade;

public abstract class RangedSiegeWeaponAi : UsableMachineAIBase
{
	public class ThreatSeeker
	{
		private FindMostDangerousThreat _getMostDangerousThreat;

		private const float SingleUnitThreatValue = 3f;

		private const float InsideWallsThreatMultiplier = 3f;

		private Threat _currentThreat;

		private Agent _targetAgent;

		public RangedSiegeWeapon Weapon;

		public List<Vec3> WeaponPositions;

		private readonly List<ITargetable> _potentialTargetObjects;

		private readonly List<ICastleKeyPosition> _referencePositions;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ThreatSeeker(RangedSiegeWeapon weapon)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Threat PrepareTargetFromTask()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool UpdateThreatSeekerTask()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void PrepareThreatSeekerTask(Action lastAction)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Release()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<Threat> GetAllThreats()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static float GetTargetValueOfFormation(Formation formation, IEnumerable<ICastleKeyPosition> referencePositions)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TargetFlags GetTargetFlagsOfFormation()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static float GetPositionMultiplierOfFormation(Formation formation, IEnumerable<ICastleKeyPosition> referencePositions)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static float GetMinimumDistanceBetweenPositions(Vec3 position, IEnumerable<ICastleKeyPosition> referencePositions, out ICastleKeyPosition closestCastlePosition)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Threat GetMaxThreat(List<ICastleKeyPosition> castleKeyPositions)
		{
			throw null;
		}
	}

	private const float TargetEvaluationDelay = 0.5f;

	private const int MaxTargetEvaluationCount = 4;

	public const string ForceTargetEntityTag = "attackMe";

	private readonly ThreatSeeker _threatSeeker;

	private Threat _target;

	private float _delayTimer;

	private float _delayDuration;

	private int _cannotShootCounter;

	private readonly Timer _targetEvaluationTimer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RangedSiegeWeaponAi(RangedSiegeWeapon rangedSiegeWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(Agent agentToCompareTo, Formation formationToCompareTo, Team potentialUsersTeam, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void UpdateAim(RangedSiegeWeapon rangedSiegeWeapon, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTargetFromThreatSeeker()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FindNextTarget()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AfterTick(Agent agentToCompareTo, Formation formationToCompareTo, Team potentialUsersTeam, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTargetingTimer()
	{
		throw null;
	}
}
