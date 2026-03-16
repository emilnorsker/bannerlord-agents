using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class DefaultTeamDeploymentPlan
{
	public const float DeployZoneMinimumWidth = 100f;

	public const float DeployZoneForwardMargin = 10f;

	public const float DeployZoneExtraWidthPerTroop = 1.5f;

	public const string DefenderSiegeDeploymentFrameEntityTag = "defender_infantry";

	public const string AttackerSiegeDeploymentFrameEntityTag = "attacker_infantry";

	public readonly Team Team;

	private readonly Mission _mission;

	private readonly DefaultDeploymentPlan _initialPlan;

	private bool _spawnWithHorses;

	private readonly List<DefaultDeploymentPlan> _reinforcementPlans;

	private DefaultDeploymentPlan _currentReinforcementPlan;

	private readonly MBList<(string id, MBList<Vec2> points)> _deploymentBoundaries;

	private MatrixFrame _deploymentFrame;

	public bool SpawnWithHorses
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<(string id, MBList<Vec2> points)> DeploymentBoundaries
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultTeamDeploymentPlan(Mission mission, Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpawnWithHorses(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeDeploymentPlan(FormationSceneSpawnEntry[,] formationSceneSpawnEntries, bool isReinforcement = false, float spawnPathOffset = 0f, float targetOffset = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateReinforcementPlans()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearPlan(bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAddedTroops(bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTroops(FormationClass formationClass, int footTroopCount, int mountedTroopCount, bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFirstPlan(bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlanMade(bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetSpawnPathOffset(bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTargetOffset(bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTroopCount(bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetDeploymentFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasDeploymentBoundaries()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IFormationDeploymentPlan GetFormationPlan(FormationClass fClass, bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetMeanPosition(bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInitialPlanSuitableForFormations((int, int)[] troopDataPerFormationClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionInsideDeploymentBoundaries(in Vec2 position, out (string id, MBList<Vec2> points) containingBoundaryTuple)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetClosestDeploymentBoundaryPosition(in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathDeploymentBoundaryIntersection(in WorldPosition startPosition, in WorldPosition endPosition, out WorldPosition intersection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlanDeploymentZone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeDeploymentZone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetDeploymentZoneFromMissionBoundaries()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static MBList<Vec2> ComputeDeploymentBoundariesFromMissionBoundaries(ICollection<Vec2> missionBoundaries, ref MatrixFrame deploymentFrame, float desiredWidth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddDeploymentBoundaryPoint(MBList<Vec2> deploymentBoundaries, Vec2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vec2 ClampRayToMissionBoundaries(MBList<Vec2> boundaries, Vec2 origin, Vec2 direction, float maxLength)
	{
		throw null;
	}
}
