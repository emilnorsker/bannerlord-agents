using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics;
using SandBox.View.Missions;
using SandBox.ViewModelCollection.Missions;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Missions;

[OverrideView(typeof(MissionQuestBarView))]
public class MissionGauntletQuestBarView : MissionQuestBarView
{
	private const float MinProgressValue = 0f;

	private const float MaxProgressValue = 1f;

	private GauntletLayer _gauntletLayer;

	private MissionQuestBarVM _dataSource;

	private IMissionProgressTracker _missionProgressTracker;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletQuestBarView()
	{
		throw null;
	}
}
