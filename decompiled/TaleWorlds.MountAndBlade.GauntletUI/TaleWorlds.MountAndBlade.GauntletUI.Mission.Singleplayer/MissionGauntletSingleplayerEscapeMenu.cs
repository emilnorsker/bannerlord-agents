using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Source.Missions;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;
using TaleWorlds.MountAndBlade.ViewModelCollection.EscapeMenu;

namespace TaleWorlds.MountAndBlade.GauntletUI.Mission.Singleplayer;

[OverrideView(typeof(MissionSingleplayerEscapeMenu))]
public class MissionGauntletSingleplayerEscapeMenu : MissionGauntletEscapeMenuBase
{
	private MissionOptionsComponent _missionOptionsComponent;

	private bool _isIronmanMode;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletSingleplayerEscapeMenu(bool isIronmanMode)
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
	private void OnManagedOptionChanged(ManagedOptionsType changedManagedOptionsType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFocusChangeOnGameWindow(bool focusGained)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSceneRenderingStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override List<EscapeMenuItemVM> GetEscapeMenuItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Tuple<bool, TextObject> GetIsPhotoModeDisabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnExitToMainMenu()
	{
		throw null;
	}
}
