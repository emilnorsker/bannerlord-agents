using System.Runtime.CompilerServices;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD.FormationMarker;

namespace TaleWorlds.MountAndBlade.GauntletUI.Mission.Singleplayer;

[OverrideView(typeof(MissionFormationMarkerUIHandler))]
public class MissionGauntletFormationMarker : MissionBattleUIBaseView
{
	private MissionFormationMarkerVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private MissionFormationTargetSelectionHandler _formationTargetHandler;

	private MBReadOnlyList<Formation> _focusedFormationsCache;

	private readonly Vec3 _heightOffset;

	private float _fadeOutTimer;

	private bool _showDistanceTexts;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletFormationMarker()
	{
		throw null;
	}

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
	private void OnManagedOptionChanged(ManagedOptionsType optionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateShowDistanceTexts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMarkerPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshTargetProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFormationFocusedFromHandler(MBReadOnlyList<Formation> focusedFormations)
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
