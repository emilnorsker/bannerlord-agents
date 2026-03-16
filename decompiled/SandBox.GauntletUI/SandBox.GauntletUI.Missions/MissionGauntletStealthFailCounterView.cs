using System.Runtime.CompilerServices;
using SandBox.Missions;
using SandBox.View.Missions;
using SandBox.ViewModelCollection.Missions.NameMarker.Targets.Hideout;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Missions;

[OverrideView(typeof(MissionStealthFailCounterView))]
public class MissionGauntletStealthFailCounterView : MissionStealthFailCounterView
{
	private GauntletLayer _countdownLayer;

	private MissionStealthFailCounterVM _countdownCounterVM;

	private StealthFailCounterMissionLogic _stealthFailCounterMissionLogic;

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
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletStealthFailCounterView()
	{
		throw null;
	}
}
