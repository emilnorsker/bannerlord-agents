using System.Runtime.CompilerServices;
using SandBox.View.Missions;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Missions;

[OverrideView(typeof(EavesdroppingMissionCameraView))]
public class MissionGauntletEavesdroppingCameraView : EavesdroppingMissionCameraView
{
	private class EavesdroppingGauntletLayer : GauntletLayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public EavesdroppingGauntletLayer(int localOrder, bool shouldClear = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool HitTest()
		{
			throw null;
		}
	}

	private EavesdroppingGauntletLayer _gauntletLayer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletEavesdroppingCameraView()
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
