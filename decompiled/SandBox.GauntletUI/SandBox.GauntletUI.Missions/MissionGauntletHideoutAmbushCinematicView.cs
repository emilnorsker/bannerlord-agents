using System.Runtime.CompilerServices;
using SandBox.View.Missions;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Missions;

[OverrideView(typeof(MissionHideoutAmbushCinematicView))]
public class MissionGauntletHideoutAmbushCinematicView : MissionHideoutAmbushCinematicView
{
	private class HideoutAmbushCutsceneGauntletLayer : GauntletLayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public HideoutAmbushCutsceneGauntletLayer(int localOrder, bool shouldClear = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool HitTest()
		{
			throw null;
		}
	}

	private HideoutAmbushCutsceneGauntletLayer _gauntletLayer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletHideoutAmbushCinematicView()
	{
		throw null;
	}

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
	protected override void SetPlayerMovementEnabled(bool isPlayerMovementEnabled)
	{
		throw null;
	}
}
