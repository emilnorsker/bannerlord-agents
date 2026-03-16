using System.Runtime.CompilerServices;
using StoryMode.View.Missions;
using StoryMode.ViewModelCollection.Missions;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace StoryMode.GauntletUI.Missions;

[OverrideView(typeof(MissionTrainingFieldObjectiveView))]
public class MissionGauntletTrainingFieldObjectiveView : MissionView
{
	private TrainingFieldObjectivesVM _dataSource;

	private GauntletLayer _layer;

	private float _beginningTime;

	private bool _isTimerActive;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletTrainingFieldObjectiveView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BeginTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float EndTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPhotoModeActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPhotoModeDeactivated()
	{
		throw null;
	}
}
