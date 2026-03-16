using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects.UsableMachines;
using NavalDLC.Missions.ShipInput;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View.MissionViews;

public class MissionShipControlView : MissionBattleUIBaseView
{
	public enum CameraModes
	{
		Back,
		Shoulder,
		Front,
		NumPositions
	}

	protected SailInput SailControl;

	protected NavalShipsLogic NavalShipsLogic;

	private Vec3 _lastCameraOffset;

	private float _lastCameraFovMultiplier;

	private bool _wasOrderMenuOpenLastFrame;

	protected bool IsAimingWithRangedWeapon;

	private float _backCameraDistanceMultiplier;

	private float _lastForwardKeyPressTime;

	private float _lastBackwardKeyPressTime;

	private int _lastAccelerationAxisInput;

	public CameraModes ActiveCameraMode
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

	public ShipControllerMachine ControllerMachine
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

	protected bool IsAimingWithRangedWeaponAndAllowed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected bool IsAimingWithRangedWeaponAllowed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected bool IsDisplayingADialog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected RangedSiegeWeapon RangedSiegeWeapon
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
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnObjectUsed(Agent userAgent, UsableMissionObject usedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnObjectStoppedBeingUsed(Agent userAgent, UsableMissionObject usedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static UsableMachine GetUsableMachineFromPoint(StandingPoint standingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickRowerInput(Vec2 inputVec, out RowerLongitudinalInput longitudinalRowerControl, out RowerLongitudinalInput longitudinalControlDoubleTap, out RowerLateralInput lateralRowerControl)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float TickRudderInput(Vec2 inputVec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleShipControls(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSailInput(SailInput sailInput)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetActiveCameraMode(CameraModes mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleShipCamera(float dt)
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
	public MissionShipControlView()
	{
		throw null;
	}
}
