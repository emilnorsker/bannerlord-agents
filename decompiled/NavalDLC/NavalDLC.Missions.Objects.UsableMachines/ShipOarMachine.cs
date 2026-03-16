using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.ShipActuators;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Objects.UsableMachines;

public class ShipOarMachine : UsableMachine, IShipOarScriptComponent
{
	private GameEntity _oarEntity;

	private MatrixFrame _handTargetLocalFrame;

	private MatrixFrame _oarExtractedEntitialFrame;

	private MatrixFrame _oarRetractedEntitialFrame;

	private MissionOar _oar;

	private float _lastIdleTime;

	private ActionIndexCache _rowIdleActionIndex;

	private ActionIndexCache _rowLoopActionIndex;

	private ActionIndexCache _rowDeathActionIndex;

	private ActionIndexCache _rowSitDownActionIndex;

	private ActionIndexCache _rowStandUpActionIndex;

	private bool _isPilotSitting;

	private Agent _lastPilotAgent;

	private (float, StopUsingGameObjectFlags) _pilotRemovalTime;

	private readonly List<GameEntity> _disablingAttachmentRampEntities;

	private BoundingBox _oarMachineBaseBoundingBox;

	[EditableScriptComponentVariable(true, "")]
	private string _rowIdleAction;

	[EditableScriptComponentVariable(true, "")]
	private string _rowLoopAction;

	[EditableScriptComponentVariable(true, "")]
	private string _rowDeathAction;

	[EditableScriptComponentVariable(true, "")]
	private string _rowSitDownAction;

	[EditableScriptComponentVariable(true, "")]
	private string _rowStandUpAction;

	public ResetAnimationOnStopUsageComponent ResetAnimationOnStopUsageComponent
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

	public override bool IsFocusable
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
	public void InitializeOar(MissionOar oar)
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
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ArrangeOarBoundingBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBoundingBoxValidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckOarMachineFlags(bool editMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSlowDownPhaseForDuration(float slowDownMultiplier, float slowDownDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterRampEntityDisablingOar(GameEntity rampEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeregisterRampEntityDisablingOar(GameEntity rampEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool ShouldAutoLeaveDetachmentWhenDisabled(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPilotAssignedDuringSpawn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartDelayedPilotRemoval(StopUsingGameObjectFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTickParallel2(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnOarDestroyed(DestructableComponent target, Agent attackerAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetDetachmentWeightAux(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject)
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
	public ShipOarMachine()
	{
		throw null;
	}
}
