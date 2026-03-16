using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.MountAndBlade.View.MissionViews.Order;
using TaleWorlds.MountAndBlade.ViewModelCollection;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.View.Screens;

[GameStateScreen(typeof(MissionState))]
public class MissionScreen : ScreenBase, IMissionSystemHandler, IGameStateListener, IMissionScreen, IMissionListener, IChatLogHandlerScreen
{
	public delegate void OnSpectateAgentDelegate(Agent followedAgent);

	public delegate List<Agent> GatherCustomAgentListToSpectateDelegate(Agent forcedAgentToInclude);

	public const int LoadingScreenFramesLeftInitial = 15;

	private const float LookUpLimit = MathF.PI * 5f / 14f;

	private const float LookDownLimit = -1.3659099f;

	public const float FirstPersonNearClippingDistance = 0.065f;

	public const float ThirdPersonNearClippingDistance = 0.1f;

	public const float FarClippingDistance = 12500f;

	private const float HoldTimeForCameraToggle = 0.5f;

	public const float MinCameraAddedDistance = 0.7f;

	public const float MinCameraDistanceHardLimit = 0.48f;

	public const float DefaultViewAngle = 65f;

	public const float MaxCameraAddedDistance = 2.4f;

	private const int _cheatTimeSpeedRequestId = 1121;

	private const string AttackerCameraEntityTag = "strategyCameraAttacker";

	private const string DefenderCameraEntityTag = "strategyCameraDefender";

	private const string CameraHeightLimiterTag = "camera_height_limiter";

	public Func<BasicCharacterObject> GetSpectatedCharacter;

	private GatherCustomAgentListToSpectateDelegate _gatherCustomAgentListToSpectate;

	private float _cameraRayCastOffset;

	private bool _forceCanZoom;

	private readonly Vec3[] _cameraNearPlanePoints;

	private readonly Vec3[] _cameraBoxPoints;

	private Vec3 _cameraTarget;

	private float _cameraBearingDelta;

	private float _cameraElevationDelta;

	private float _cameraSpecialTargetAddedBearing;

	private float _cameraSpecialCurrentAddedBearing;

	private float _cameraSpecialTargetAddedElevation;

	private float _cameraSpecialCurrentAddedElevation;

	private Vec3 _cameraSpecialTargetPositionToAdd;

	private Vec3 _cameraSpecialCurrentPositionToAdd;

	private float _cameraSpecialTargetDistanceToAdd;

	private float _cameraSpecialCurrentDistanceToAdd;

	private bool _cameraAddSpecialMovement;

	private bool _cameraAddSpecialPositionalMovement;

	private bool _cameraApplySpecialMovementsInstantly;

	private float _cameraSpecialCurrentFOV;

	private float _cameraSpecialTargetFOV;

	private float _cameraTargetAddedHeight;

	private float _cameraDeploymentHeightToAdd;

	private float _lastCameraAddedDistance;

	private float _cameraAddedElevation;

	private float _cameraHeightLimit;

	private float _currentViewBlockingBodyCoeff;

	private float _targetViewBlockingBodyCoeff;

	private bool _applySmoothTransitionToVirtualEyeCamera;

	private Vec3 _cameraSpeed;

	private float _cameraSpeedMultiplier;

	private bool _cameraSmoothMode;

	private bool _fixCamera;

	private int _shiftSpeedMultiplier;

	private bool _tickEditor;

	private bool _playerDeploymentCancelled;

	private bool _isDeactivated;

	private bool _zoomToggled;

	private float _zoomAmount;

	private float _cameraToggleStartTime;

	private bool _displayingDialog;

	private MissionMainAgentController _missionMainAgentController;

	private ICameraModeLogic _missionCameraModeLogic;

	private MissionLobbyComponent _missionLobbyComponent;

	private readonly List<object> _objectsWithActiveRadialMenu;

	private bool _isPlayerAgentAdded;

	private bool _isRenderingStarted;

	private bool _onSceneRenderingStartedCalled;

	private int _loadingScreenFramesLeft;

	private bool _resetDraggingMode;

	private bool _rightButtonDraggingMode;

	private Vec2 _clickedPositionPixel;

	private Agent _agentToFollowOverride;

	private Agent _lastFollowedAgent;

	private bool _isGamepadActive;

	private readonly MissionViewsContainer _missionViewsContainer;

	private MissionState _missionState;

	public bool LockCameraMovement
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

	public OrderFlag OrderFlag
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public Camera CombatCamera
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

	public Camera CustomCamera
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float CameraBearing
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float MaxCameraZoom
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

	public float CameraElevation
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

	public float CameraResultDistanceToTarget
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

	public float CameraViewAngle
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

	public bool IsPhotoModeEnabled
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

	public bool IsConversationActive
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

	public bool IsDeploymentActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public SceneLayer SceneLayer
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

	public SceneView SceneView
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Mission Mission
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

	public bool IsCheatGhostMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public bool IsRadialMenuActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IInputContext InputManager
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsOrderMenuOpen
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsTransferMenuOpen
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Agent LastFollowedAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public IAgentVisual LastFollowedAgentVisuals
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public override bool MouseVisible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool PhotoModeRequiresMouse
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

	public bool IsFocusLost
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

	public bool IsMissionTickable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event OnSpectateAgentDelegate OnSpectateAgentFocusIn
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event OnSpectateAgentDelegate OnSpectateAgentFocusOut
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionScreen(MissionState missionState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void InitializeMissionView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnResume()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFocusChangeOnGameWindow(bool focusGained)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IMissionScreen.GetCameraElevation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOrderFlagVisibility(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetFollowText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetFollowPartyText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SetDisplayDialog(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IMissionScreen.GetDisplayDialog()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOpeningEscapeMenuOnFocusChangeAllowed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPhotoModeAllowed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetExtraCameraParameters(bool newForceCanZoom, float newCameraRayCastStartingPointOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomAgentListToSpectateGatherer(GatherCustomAgentListToSpectateDelegate gatherer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateFreeCamera(MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ActivateMissionView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Mission_OnMainAgentChanged(Agent oldAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Mission_OnBeforeAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMainAgentWeaponChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetMaxCameraZoom()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IEnumerable<MissionBehavior> AddDefaultMissionBehaviorsTo(Mission mission, IEnumerable<MissionBehavior> behaviors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSkinsXMLChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSceneRenderingStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("fix_camera_toggle", "mission")]
	public static string ToggleFixedMissionCamera(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetFixedMissionCameraActive(bool active)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("set_shift_camera_speed", "mission")]
	public static string SetShiftCameraSpeed(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("set_camera_position", "mission")]
	public static string SetCameraPosition(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForUpdateCamera(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateDragData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCamera(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool CanToggleCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool CanViewCharacter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsViewingCharacter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetCameraFrameToMapView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleUserInputDebug()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleUserInput(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetCameraToggleProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleUserInputCheatMode(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMissionView(MissionView missionView)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ScreenPointToWorldRay(Vec2 screenPoint, out Vec3 rayBegin, out Vec3 rayEnd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetProjectedMousePositionOnGround(out Vec3 groundPosition, out Vec3 groundNormal, BodyFlags excludeBodyOwnerFlags, bool checkOccludedSurface)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetProjectedMousePositionOnWater(out Vec3 waterPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CancelQuickPositionOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool MissionStartedRendering()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetOrderFlagPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetOrderFlagFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ActivateLoadingScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterRadialMenuObject<T>(T radialMenuOwnerObject) where T : class
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnregisterRadialMenuObject(object radialMenuOwnerObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeRequiresMouse(bool isRequired)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeEnabled(bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetConversationActive(bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCameraLockState(bool isLocked)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterView(MissionView missionView)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnregisterView(MissionView missionView)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void TeleportMainAgentToCameraFocusForCheat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IAgentVisual GetPlayerAgentVisuals(MissionPeer lobbyPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAgentToFollow(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpectatorData GetSpectatingData(Vec3 currentCameraPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent FindNextCameraAttachableAgent(Agent currentAgent, SpectatorCameraTypes cameraLockMode, int iterationDirection, Vec3 currentCameraPosition)
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
	void IMissionSystemHandler.OnMissionAfterStarting(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionSystemHandler.OnMissionLoadingFinished(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionSystemHandler.BeforeMissionTick(Mission mission, float realDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreViewsReady()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CameraTick(Mission mission, float realDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionSystemHandler.UpdateCamera(Mission mission, float realDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void AfterMissionTick(Mission mission, float realDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionSystemHandler.AfterMissionTick(Mission mission, float realDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerable<MissionBehavior> IMissionSystemHandler.OnAddBehaviors(IEnumerable<MissionBehavior> behaviors, Mission mission, string missionName, bool addDefaultMissionBehaviors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleInputs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEscape()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IMissionSystemHandler.RenderIsReady()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnEquipItemsFromSpawnEquipmentBegin(Agent agent, CreationType creationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnEquipItemsFromSpawnEquipment(Agent agent, CreationType creationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnConversationCharacterChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnMissionModeChange(MissionMode oldMissionMode, bool atStart)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnResetMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnDeploymentPlanMade(Team team, bool isFirstPlan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateNewBearingAndElevationForFirstPerson(Agent agentToFollow, float oldCameraBearing, float oldCameraElevation, float cameraBearingDelta, float cameraElevationDelta, out float newBearing, out float newElevation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyBannerTextureToMesh(Mesh armorMesh, Texture bannerTexture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IChatLogHandlerScreen.TryUpdateChatLogLayerParameters(ref bool isTeamChatAvailable, ref bool inputEnabled, ref bool isToggleChatHintAvailable, ref bool isMouseVisible, ref InputContext inputContext)
	{
		throw null;
	}
}
