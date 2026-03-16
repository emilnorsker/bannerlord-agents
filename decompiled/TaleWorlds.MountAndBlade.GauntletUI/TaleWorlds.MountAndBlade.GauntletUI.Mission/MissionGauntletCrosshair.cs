using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD;

namespace TaleWorlds.MountAndBlade.GauntletUI.Mission;

[OverrideView(typeof(MissionCrosshair))]
public class MissionGauntletCrosshair : MissionBattleUIBaseView
{
	private GauntletLayer _layer;

	private CrosshairVM _dataSource;

	private GauntletMovieIdentifier _movie;

	private double[] _targetGadgetOpacities;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCreateView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDestroyView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSuspendView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnResumeView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool GetShouldArrowsBeVisible()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool GetShouldCrosshairBeVisible()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMissionScreenUsingCustomCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCombatLogGenerated(CombatLogData logData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillReloadDurationsFromActions(ref StackArray10FloatFloatTuple reloadPhases, int reloadPhaseCount, Agent mainAgent, ActionIndexCache reloadAction)
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletCrosshair()
	{
		throw null;
	}
}
