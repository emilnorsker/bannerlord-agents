using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class SandBoxMissionSpawnHandler : MissionLogic
{
	protected MissionAgentSpawnLogic _missionAgentSpawnLogic;

	protected MapEvent _mapEvent;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected static MissionSpawnSettings CreateSandBoxBattleWaveSpawnSettings()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandBoxMissionSpawnHandler()
	{
		throw null;
	}
}
