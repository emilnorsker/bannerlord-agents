using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.View.Map;

public class MapCameraView : MapView
{
	public enum CameraFollowMode
	{
		Free,
		FollowParty,
		MoveToPosition
	}

	public struct InputInformation
	{
		public bool IsMainPartyValid;

		public bool IsMapReady;

		public bool IsControlDown;

		public bool IsMouseActive;

		public bool CheatModeEnabled;

		public bool LeftMouseButtonPressed;

		public bool LeftMouseButtonDown;

		public bool LeftMouseButtonReleased;

		public bool MiddleMouseButtonDown;

		public bool RightMouseButtonDown;

		public bool RotateLeftKeyDown;

		public bool RotateRightKeyDown;

		public bool PartyMoveUpKey;

		public bool PartyMoveDownKey;

		public bool PartyMoveLeftKey;

		public bool PartyMoveRightKey;

		public bool CameraFollowModeKeyPressed;

		public bool LeftButtonDraggingMode;

		public bool IsInMenu;

		public bool RayCastForClosestEntityOrTerrainCondition;

		public float MapZoomIn;

		public float MapZoomOut;

		public float DeltaMouseScroll;

		public float MouseSensitivity;

		public float MouseMoveX;

		public float MouseMoveY;

		public float HorizontalCameraInput;

		public float RX;

		public float RY;

		public float RS;

		public float Dt;

		public Vec2 MousePositionPixel;

		public Vec2 ClickedPositionPixel;

		public Vec3 ClickedPosition;

		public Vec3 ProjectedPosition;

		public Vec3 WorldMouseNear;

		public Vec3 WorldMouseFar;
	}

	private const float VerticalHalfViewAngle = 0.34906584f;

	private Vec3 _cameraTarget;

	private float _distanceToIdealCameraTargetToStopCameraSoundEventsSquared;

	private int _cameraMoveSfxSoundEventId;

	private SoundEvent _cameraMoveSfxSoundEvent;

	private bool _doFastCameraMovementToTarget;

	private float _cameraElevation;

	private CampaignVec2 _lastUsedIdealCameraTarget;

	private CampaignVec2 _cameraAnimationTarget;

	private float _cameraAnimationStopDuration;

	private readonly Scene _mapScene;

	protected float _customMaximumCameraHeight;

	private MatrixFrame _cameraFrame;

	protected virtual CameraFollowMode CurrentCameraFollowMode
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

	public virtual float CameraFastMoveMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	protected virtual float CameraBearing
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

	protected virtual float MaximumCameraHeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected virtual float CameraBearingVelocity
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

	public virtual float CameraDistance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	protected virtual float TargetCameraDistance
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

	protected virtual float AdditionalElevation
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

	public virtual bool CameraAnimationInProgress
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public virtual bool ProcessCameraInput
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public virtual Camera Camera
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public virtual MatrixFrame CameraFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		protected set
		{
			throw null;
		}
	}

	protected virtual Vec3 IdealCameraTarget
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

	private static MapCameraView Instance
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapCameraView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnActivate(bool leftButtonDraggingMode, Vec3 clickedPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void SetCameraMode(CameraFollowMode cameraMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void ResetCamera(bool resetDistance, bool teleportToMainParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void TeleportCameraToMainParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void FastMoveCameraToMainParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void FastMoveCameraToPosition(CampaignVec2 target, bool isInMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFastMoveCameraMovementStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopCameraMovementSoundEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool IsCameraLockedToPlayerParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void StartCameraAnimation(CampaignVec2 targetPosition, float animationStopDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void SiegeEngineClick(MatrixFrame siegeEngineFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnExit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnEscapeMenuToggled(bool isOpened)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void HandleMouse(bool rightMouseButtonPressed, float verticalCameraInput, float mouseMoveY, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void HandleLeftMouseButtonClick(bool isMouseActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnSetMapSiegeOverlayState(bool isActive, bool isMapSiegeOverlayViewNull)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnRefreshMapSiegeOverlayRequired(bool isMapSiegeOverlayViewNull)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnBeforeTick(in InputInformation inputInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void UpdateMapCamera(bool _leftButtonDraggingMode, Vec3 _clickedPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual Vec3 GetCameraTargetForPosition(CampaignVec2 targetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual Vec3 GetCameraTargetForParty(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool GetMapCameraInput(InputInformation inputInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual MatrixFrame ComputeMapCamera(ref Vec3 cameraTarget, float cameraBearing, float cameraElevation, float cameraDistance, ref CampaignVec2 lastUsedIdealCameraTarget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual float CalculateCameraElevation(float cameraDistance)
	{
		throw null;
	}
}
