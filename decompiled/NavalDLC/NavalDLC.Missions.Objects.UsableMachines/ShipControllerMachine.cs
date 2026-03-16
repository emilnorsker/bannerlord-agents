using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Objects.UsableMachines;

public class ShipControllerMachine : UsableMachine
{
	public const float CaptureTime = 3f;

	private const string ControllerEntityName = "controller";

	private const string HandTargetEntityName = "hand_position";

	private const string CameraTargetEntityName = "camera_target";

	private const string ShoulderCameraTargetEntityName = "shoulder_camera_target";

	private const string FrontCameraTargetEntityName = "front_camera_target";

	private const string RudderRotationEntityTag = "rudder_rotation_entity";

	public GameEntity _rudderRotationEntity;

	private MatrixFrame _rudderRotationEntityInitialLocalFrame;

	private GameEntity _cameraTargetEntity;

	private GameEntity _shoulderCameraTargetEntity;

	private GameEntity _frontCameraTargetEntity;

	private ActionIndexCache _shipControlActionIndex;

	private ActionIndexCache _shipCaptureActionIndex;

	private TextObject _overridenDescriptionForActiveEnemyShipControllerMachine;

	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	[EditableScriptComponentVariable(true, "")]
	private Vec3 _cameraOffset;

	[EditableScriptComponentVariable(true, "")]
	private string _shipControlAction;

	[EditableScriptComponentVariable(true, "")]
	private Vec3 _shoulderCameraOffset;

	[EditableScriptComponentVariable(true, "")]
	private string _shipCaptureAction;

	[EditableScriptComponentVariable(true, "")]
	private Vec3 _frontCameraOffset;

	[EditableScriptComponentVariable(true, "")]
	private float _shoulderCameraDistance;

	[EditableScriptComponentVariable(true, "")]
	private bool _isLeftHandOnly;

	[EditableScriptComponentVariable(true, "")]
	private float _frontCameraDistance;

	[EditableScriptComponentVariable(true, "")]
	private bool _isRightHandOnly;

	[EditableScriptComponentVariable(true, "")]
	private float _cameraFovMultiplier;

	[EditableScriptComponentVariable(true, "")]
	private float _frontCameraFovMultiplier;

	[EditableScriptComponentVariable(true, "")]
	private float _shoulderCameraFovMultiplier;

	private float _captureTimer;

	public MissionShip AttachedShip
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

	public GameEntity ControllerEntity
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

	public GameEntity HandTargetEntity
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

	public float CaptureTimer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 BackCameraOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 ShoulderCameraOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 FrontCameraOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float ShoulderCameraDistance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float FrontCameraDistance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float BackCameraFovMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float ShoulderCameraFovMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float FrontCameraFovMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 BackCameraTargetLocalPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 ShoulderCameraTargetLocalPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 FrontCameraTargetLocalPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckControllerMachineFlags(bool editMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnsureStandingPointComponents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPilotAssignedDuringSpawn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipCapturedByAgent(Agent captorAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetDetachmentWeightAux(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateVisualizer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool ShouldAutoLeaveDetachmentWhenDisabled(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAttachedShipVacant()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOverridenDescriptionForActiveEnemyShipControllerMachine(TextObject description)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipControllerMachine()
	{
		throw null;
	}
}
