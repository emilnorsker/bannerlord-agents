using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class DefaultMissionDeploymentPlan : IMissionDeploymentPlan
{
	private readonly Mission _mission;

	private readonly MBList<(Team team, DefaultTeamDeploymentPlan plan)> _teamDeploymentPlans;

	private readonly WorldFrame?[] _playerSpawnFrames;

	private FormationSceneSpawnEntry[,] _formationSceneSpawnEntries;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultMissionDeploymentPlan(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearDeploymentPlan(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearReinforcementPlan(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasPlayerSpawnFrame(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPlayerSpawnFrame(BattleSideEnum battleSide, out WorldPosition position, out Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HasSignificantMountedTroops(int footTroopCount, int mountedTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAddedTroops(Team team, bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTroops(Team team, FormationClass formationClass, int footTroopCount, int mountedTroopCount = 0, bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpawnWithHorses(Team team, bool spawnWithHorses)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeDefaultDeploymentPlans()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeDeploymentPlan(Team team, float spawnPathOffset = 0f, float targetOffset = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeReinforcementDeploymentPlan(Team team, float spawnPathOffset = 0f, float targetOffset = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RemakeDeploymentPlan(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionInsideDeploymentBoundaries(Team team, in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetClosestDeploymentBoundaryPosition(Team team, in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SupportsReinforcements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SupportsNavmesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathDeploymentBoundaryIntersection(Team team, in WorldPosition startPosition, in WorldPosition endPosition, out WorldPosition intersection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionInsideSiegeDeploymentBoundaries(in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetSpawnPathOffset(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTargetOffset(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTroopCount(Team team, bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IFormationDeploymentPlan GetFormationPlan(Team team, FormationClass fClass, bool isReinforcement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlanMade(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlanMade(Team team, out bool isFirstPlan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsReinforcementPlanMade(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInitialPlanSuitableForFormations(Team team, (int footTroopCount, int mountedTroopCount)[] troopDataPerFormationClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasDeploymentBoundaries(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetDeploymentFrame(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProjectPositionToDeploymentBoundaries(Team team, ref WorldPosition endPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<(string id, MBList<Vec2> points)> GetDeploymentBoundaries(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetMeanPosition(Team team, bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateReinforcementPlan(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetZoomFocusFrame(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetZoomOffset(Team team, float fovAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeDeploymentPlanAux(Team team, bool isReinforcement = false, float spawnOffset = 0f, float targetOffset = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReadSpawnEntitiesFromScene(bool isFieldBattle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReadSallyOutEntitiesFromScene(GameEntity sallyOutSetEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReadSiegeBattleEntitiesFromScene(Scene missionScene, BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DefaultTeamDeploymentPlan GetTeamPlan(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IMissionDeploymentPlan.IsPositionInsideDeploymentBoundaries(Team team, in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Vec2 IMissionDeploymentPlan.GetClosestDeploymentBoundaryPosition(Team team, in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IMissionDeploymentPlan.GetPathDeploymentBoundaryIntersection(Team team, in WorldPosition startPosition, in WorldPosition endPosition, out WorldPosition intersection)
	{
		throw null;
	}
}
