using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics;
using SandBox.View.Missions;
using SandBox.ViewModelCollection.Missions.MainAgentDetection;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace Sandobx.GauntletUI.Missions;

[OverrideView(typeof(MissionMainAgentDetectionView))]
public class GauntletMainAgentDetectionView : MissionMainAgentDetectionView
{
	private GauntletLayer _markersGauntletLayer;

	private GauntletLayer _losingTargetGauntletLayer;

	private GauntletLayer _detectionBarGauntletLayer;

	private MainAgentDetectionVM _detectionDataSource;

	private MissionDisguiseMarkersVM _markersDataSource;

	private MissionLosingTargetVM _losingTargetDataSource;

	private DisguiseMissionLogic _disguiseMissionLogic;

	private float _lastSuspicousLevel;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSuspicion(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateLosingTarget(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMarkers(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMainAgentDetectionView()
	{
		throw null;
	}
}
