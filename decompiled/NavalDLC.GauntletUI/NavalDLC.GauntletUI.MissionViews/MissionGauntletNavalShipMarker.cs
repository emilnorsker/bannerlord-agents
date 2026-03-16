using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using NavalDLC.View.MissionViews;
using NavalDLC.ViewModelCollection.HUD.ShipMarker;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.GauntletUI.MissionViews;

[OverrideView(typeof(NavalMissionShipMarkerUIHandler))]
public class MissionGauntletNavalShipMarker : MissionBattleUIBaseView
{
	private NavalShipMarkersVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private NavalShipTargetSelectionHandler _shipTargetHandler;

	private NavalShipsLogic _navalShipsLogic;

	private MBReadOnlyList<MissionShip> _focusedShipsCache;

	private readonly Vec3 _heightOffset;

	private float _fadeOutTimer;

	private bool _showDistanceTexts;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletNavalShipMarker()
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
	private void RefreshShipTargetProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipFocusedFromHandler(MBReadOnlyList<MissionShip> focusedShips)
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
