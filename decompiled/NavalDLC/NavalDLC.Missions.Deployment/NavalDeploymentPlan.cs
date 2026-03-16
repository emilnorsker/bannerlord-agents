using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Deployment;

public class NavalDeploymentPlan
{
	public const float HorizontalShipGap = 20f;

	public const float DeployZoneMinimumWidth = 400f;

	public const float RiverSceneDeployZoneFixedWidth = 200f;

	public const float DeployZoneForwardMargin = 50f;

	public const float DeployZoneBackwardMargin = 100f;

	public readonly Team Team;

	public readonly SpawnPathData SpawnPathData;

	private readonly Mission _mission;

	private int _planCount;

	private bool _isRiverScene;

	private readonly NavalFormationDeploymentPlan[] _formationPlans;

	private MatrixFrame _deploymentFrame;

	private float _deploymentWidth;

	private float _deploymentDepth;

	private MBList<Vec2> _meanBoundaryPositions;

	private readonly MBList<(string id, MBList<Vec2> points)> _deploymentBoundaries;

	public int PlanCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsPlanMade
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

	public float SpawnPathOffset
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

	public bool HasDeploymentBoundaries
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

	public int TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MatrixFrame DeploymentFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float DeploymentWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float DeploymentDepth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<(string, MBList<Vec2>)> DeploymentBoundaries
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalDeploymentPlan CreatePlan(Mission mission, Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private NavalDeploymentPlan(Mission mission, Team team, SpawnPathData spawnPathData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAddedShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearPlan()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddShip(FormationClass formationClass, IShipOrigin shipOrigin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RemoveShip(FormationClass formationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeDeploymentPlan(float spawnPathOffset, float targetOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalFormationDeploymentPlan GetFormationPlan(FormationClass fClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetFormationDeploymentFrame(FormationClass fClass, out MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionInsideDeploymentBoundaries(in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetClosestBoundaryPosition(in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlanNavalBattleDeploymentFromSpawnPath(float pathOffset, float targetOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlanDeploymentZone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeployShips(Vec2 deployPosition, Vec2 deployDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBList<Vec2> ComputeDeploymentBoundariesFromMissionBoundaries(ICollection<Vec2> missionBoundaries)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDeploymentBoundaryPoint(MBList<Vec2> deploymentBoundaries, Vec2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2 ClampRayToMissionBoundaries(MBList<Vec2> boundaries, Vec2 origin, Vec2 direction, float maxLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateDeploymentFrameZ()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Vec2 GetMeanBoundaryPosition(int boundaryIndex = 0)
	{
		throw null;
	}
}
