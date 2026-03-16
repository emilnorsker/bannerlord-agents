using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class SiegeMissionPreparationHandler : MissionLogic
{
	private enum SiegeMissionType
	{
		Assault,
		SallyOut,
		ReliefForce
	}

	private const string SallyOutTag = "sally_out";

	private const string AssaultTag = "siege_assault";

	private const string DamageDecalTag = "damage_decal";

	private float[] _wallHitPointPercentages;

	private bool _hasAnySiegeTower;

	private SiegeMissionType _siegeMissionType;

	private Scene MissionScene
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SiegeMissionPreparationHandler(bool isSallyOut, bool isReliefForceAttack, float[] wallHitPointPercentages, bool hasAnySiegeTower)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetUpScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ArrangeBesiegerDeploymentPointsAndMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ArrangeEntitiesForMissionType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ArrangeDestructedMeshes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WallSegment FindRightMostWall(List<WallSegment> wallList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ArrangeSiegeMachinesForNonAssaultMission()
	{
		throw null;
	}
}
