using System.Runtime.CompilerServices;
using NavalDLC.Storyline.MissionControllers;
using NavalDLC.View.MissionViews;
using NavalDLC.View.MissionViews.Storyline;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.GauntletUI.MissionViews;

[OverrideView(typeof(Quest5SetPieceBattleMissionView))]
public class MissionGauntletQuest5SetPieceBattleMissionView : Quest5SetPieceBattleMissionView
{
	private bool _disableOrderUI;

	private bool _isOrderUIDisabled;

	private bool _disableShipMarkers;

	private bool _isShipMarkersDisabled;

	private bool _disableStealthBar;

	private bool _isStealthBarDisabled;

	private bool _disableNameMarkers;

	private bool _isNameMarkersDisabled;

	private bool _disableAgentBanners;

	private bool _isAgentBannersDisabled;

	private bool _disableShipHighlights;

	private bool _isShipHighlightsDisabled;

	private bool _isShipCameraUpdatedAtTheStartOfApproachPhase;

	private bool _isShipCameraUpdatedAtTheStartOfPhase3;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnConversationEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void PassMissionStateOnTick(Quest5SetPieceBattleMissionController.Quest5SetPieceBattleMissionState currentState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleOrderUISuspendStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleShipMarkersSuspendStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleStealthBarSuspendStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleNameMarkersSuspendStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleAgentBannerSuspendStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleShipHighlightSuspendStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMissionViewVisibility<T>(bool isVisible) where T : MissionView
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetActiveCameraModeForShip(MissionShipControlView.CameraModes mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletQuest5SetPieceBattleMissionView()
	{
		throw null;
	}
}
