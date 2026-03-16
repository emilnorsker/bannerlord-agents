using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.ViewModelCollection.Port;
using SandBox.View;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace NavalDLC.GauntletUI.Screens;

[GameStateScreen(typeof(PortState))]
public class GauntletPortScreen : ScreenBase, IGameStateListener, IChangeableScreen
{
	private struct CameraParameters
	{
		public float Azimuth;

		public float Inclination;

		public float Distance;

		public float Deviation;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CameraParameters(float azimuth, float inclination, float distance, float deviation)
		{
			throw null;
		}
	}

	private struct StaticCameraParameters
	{
		public float HorizontalRotationSensitivity;

		public float VerticalRotationSensitivity;

		public float ZoomSensitivity;

		public float SensitivityMappingMultiplier;

		public float DeviationSensitivityAtMinDistance;

		public float DeviationSensitivityAtMaxDistance;

		public float MinCameraInclination;

		public float MaxCameraInclinationAtMinDistance;

		public float MaxCameraInclinationAtMaxDistance;

		public float MinCameraDistance;

		public float MaxCameraDistance;

		public float MinCameraDistanceWhileInspectingPiece;

		public float CameraDeviationLimit;

		public float FocusDistanceAtMinDistance;

		public float FocusDistanceAtMaxDistance;

		public float ExtraHeightAtMinDistance;

		public float ExtraHeightAtMaxDistance;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StaticCameraParameters(float horizontalRotationSensitivity, float verticalRotationSensitivity, float zoomSensitivity, float sensitivityMappingMultiplier, float deviationSensitivityAtMinDistance, float deviationSensitivityAtMaxDistance, float minCameraInclination, float maxCameraInclinationAtMinDistance, float maxCameraInclinationAtMaxDistance, float minCameraDistance, float maxCameraDistance, float minCameraDistanceWhileInspectingPiece, float cameraDeviationLimit, float focusDistanceAtMinDistance, float focusDistanceAtMaxDistance, float extraHeightAtMinDistance, float extraHeightAtMaxDistance)
		{
			throw null;
		}
	}

	private struct PortShipVisualInfo
	{
		public GameEntity VisualEntity;

		public Vec3 InitialPosition;

		public Vec3 VisualCenterPosition;

		public bool IsHidden;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PortShipVisualInfo(GameEntity visualEntity, Vec3 initialPosition, Vec3 visualCenterPosition, bool isHidden = false)
		{
			throw null;
		}
	}

	private SceneLayer _sceneLayer;

	private Scene _scene;

	private readonly PortState _portState;

	private GauntletLayer _gauntletLayer;

	private PortVM _dataSource;

	private GameEntity _shipSpawnPositionEntity;

	private readonly Dictionary<Ship, PortShipVisualInfo> _shipVisualInfos;

	private PortShipVisualInfo _currentShipVisualInfo;

	private SpriteCategory _portCategory;

	private SpriteCategory _shipPiecesCategory;

	private SpriteCategory _clanCategory;

	private SpriteCategory _characterdeveloperCategory;

	private Camera _sceneCamera;

	private SoundEvent _underwaterSoundEvent;

	private IViewDataTracker _viewDataTracker;

	private readonly bool _isInSettlementPort;

	private bool _isInitialized;

	private bool _isControllingCamera;

	private int _framesToWaitAfterInit;

	private CameraParameters _targetCameraValues;

	private CameraParameters _currentCameraValues;

	private CameraParameters _previousCameraValues;

	private readonly CameraParameters _initialCameraValues;

	private readonly StaticCameraParameters _staticCameraValues;

	private Vec3 _currentCameraTargetPosition;

	private GameEntity _currentSelectedSlotCameraEntity;

	private Vec3 _shipForwardDirection;

	private Vec3 _shipSideDirection;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletPortScreen(PortState portState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroyScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeShipVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnShipVisual(Ship ship, Vec3 position, float rotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RotateOars(GameEntity visualShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RotateSails(GameEntity visualShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetPositionOffsetForIndex(int i, bool isOppositeSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetExtraRotationInRadiansForIndex(int i, bool isOppositeSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetVisualCenterOffsetForShip(GameEntity shipEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RecalculateShipVisibilities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ShouldShipBeHidden(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RecalculateShipPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RecalculateShipPosition(Ship ship, Vec3 position, float rotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshShipVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshShipVisual(ShipItemVM shipItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipSelected(Ship shipItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRostersRefreshed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnUpgradeSlotSelected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FreeCameraFromUpgradeSlot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetCameraAzimuthForSlot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetCameraInclinationForSlotType(string slotType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetCameraDistanceForSlotType(string slotType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickDataSourceInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHotKeyPressedInAnyLayer(string hotkey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHotKeyReleasedInAnyLayer(string hotkey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsGameKeyPressedInAnyLayer(int gameKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickSceneInput(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IChangeableScreen.AnyUnsavedChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IChangeableScreen.CanChangesBeApplied()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IChangeableScreen.ApplyChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IChangeableScreen.ResetChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCamera(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float LerpAngleWithMax(float current, float target, float amount, float maxAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 LerpVec3WithMax(Vec3 current, Vec3 target, float amount, float maxAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetCameraTargetPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetStableSlotPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NormalizeControllerInputForDeadZone(ref float inputValue, float controllerDeadZone)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleCameraCollision(Vec3 cameraTargetPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleIsCameraUnderwater()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetCamera(bool isInstant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleShipEntityVisibilities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetTargetMinDistance()
	{
		throw null;
	}
}
