using System.Runtime.CompilerServices;
using NavalDLC.Missions.Deployment;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

public class NavalCustomBattleWindAndWaveLogic : MissionLogic
{
	private NavalCustomBattleWindConfig.Direction _windDirection;

	private TerrainType _terrainType;

	private NavalDeploymentMissionController _navalDeploymentMissionController;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalCustomBattleWindAndWaveLogic(NavalCustomBattleWindConfig.Direction windDirection, TerrainType terrainType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAfterSetupTeams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSceneWindDirection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSceneWaterStrength()
	{
		throw null;
	}
}
