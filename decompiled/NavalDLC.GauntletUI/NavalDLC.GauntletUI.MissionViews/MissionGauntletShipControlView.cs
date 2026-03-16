using System;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using NavalDLC.View.MissionViews;
using NavalDLC.ViewModelCollection.Missions.ShipControl;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.GauntletUI.Mission;
using TaleWorlds.MountAndBlade.GauntletUI.Mission.Singleplayer;
using TaleWorlds.MountAndBlade.View;

namespace NavalDLC.GauntletUI.MissionViews;

[OverrideView(typeof(MissionShipControlView))]
public class MissionGauntletShipControlView : MissionShipControlView
{
	[Flags]
	public enum ShipControlFeatureFlags
	{
		ShipFocus = 1,
		ShipSelection = 2,
		AttemptBoarding = 4,
		ToggleOarsmen = 8,
		ToggleSails = 0x10,
		CutLoose = 0x20,
		BallistaOrder = 0x40,
		ShootBallista = 0x80,
		ChangeCamera = 0x100
	}

	private GauntletLayer _gauntletLayer;

	private MissionShipControlVM _dataSource;

	private MissionGauntletSingleplayerOrderUIHandler _orderUIHandler;

	private MissionGauntletCrosshair _crosshairView;

	private NavalMissionShipHighlightView _shipHighlightView;

	private MissionGauntletNavalAgentStatus _agentStatusView;

	private MissionShip _playerControlledShip;

	private MissionShip _focusedShip;

	private bool _playerControlledShipHasHybridSails;

	private bool _isAnyBridgeActive;

	private const float AttemptBoardingDistance = 50f;

	private const float SelectShipDistance = 300f;

	public ShipControlFeatureFlags SuspendedFeatures
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
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
	public void SuspendFeature(ShipControlFeatureFlags feature)
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
	public void ResumeFeature(ShipControlFeatureFlags feature)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFeatureSuspended(ShipControlFeatureFlags feature)
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
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateHitPoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreDisplayMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisplayCommandForSelectedFormations(TextObject command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateFocusedShip(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckFocusableShip(MissionShip focusableShip, Vec3 playerShipPosition, float enemyFocusDistance, float friendlyFocusDistance, MatrixFrame cameraFrame, Vec2 screenCenter, ref Vec3 hitScreenPosition, ref float closestDistance, float focusRadius, ref MissionShip closestShip, out bool directHitFound)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetFocusedShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetShipFocusPosition(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateShipValues(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vec2 GetProjection(Vec2 from, Vec2 to)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetControlKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshControlKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetCanAttemptBoarding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsAttemptBoardingTemporarilyBlocked()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetCanChangeCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetCanCutLoose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsCutLooseTemporarilyBlocked()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetCanSelectShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetCanToggleOarsmen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetCanToggleSail()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetCanToggleRangedWeaponOrderMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetCanShootBallista()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletShipControlView()
	{
		throw null;
	}
}
