using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class HumanAIComponent : AgentComponent
{
	[EngineStruct("behavior_values_struct", false, null)]
	public struct BehaviorValues
	{
		public float y1;

		public float x2;

		public float y2;

		public float x3;

		public float y3;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetValueAt(float x)
		{
			throw null;
		}
	}

	public enum AISimpleBehaviorKind
	{
		GoToPos,
		Melee,
		Ranged,
		ChargeHorseback,
		RangedHorseback,
		AttackEntityMelee,
		AttackEntityRanged,
		Count
	}

	public enum BehaviorValueSet
	{
		Default,
		DefensiveArrangementMove,
		Follow,
		DefaultMove,
		Charge,
		DefaultDetached,
		Overriden
	}

	public enum UsableObjectInterestKind
	{
		None,
		MovingTo,
		Defending,
		Count
	}

	private const float AvoidPickUpIfLookAgentIsCloseDistance = 20f;

	private const float AvoidPickUpIfLookAgentIsCloseDistanceSquared = 400f;

	private const float ClosestMountSearchRangeSq = 6400f;

	public static bool FormationSpeedAdjustmentEnabled;

	private readonly BehaviorValues[] _behaviorValues;

	private bool _hasNewBehaviorValues;

	private readonly WeakGameEntity[] _tempPickableEntities;

	private readonly UIntPtr[] _pickableItemsId;

	private SpawnedItemEntity _itemToPickUp;

	private readonly MissionTimer _itemPickUpTickTimer;

	private bool _disablePickUpForAgent;

	private readonly MissionTimer _mountSearchTimer;

	private UsableMissionObject _objectOfInterest;

	private UsableObjectInterestKind _objectInterestKind;

	private BehaviorValueSet _lastBehaviorValueSet;

	private bool _shouldCatchUpWithFormation;

	private bool _forceDisableItemPickup;

	private float _scriptedFrameTimer;

	public Agent FollowedAgent
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

	public bool ShouldCatchUpWithFormation
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

	public bool IsDefending
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasTimedScriptedFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HumanAIComponent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OverrideBehaviorParams(AISimpleBehaviorKind behavior, float y1, float x2, float y2, float x3, float y3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetBehaviorParams(AISimpleBehaviorKind behavior, float y1, float x2, float y2, float x3, float y3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SyncBehaviorParamsIfNecessary()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisablePickUpForAgentIfNeeded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ItemPickupTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent FindClosestMountAvailable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent FindReservedMount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ReserveMount(Agent mount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UnreserveMount(Agent mount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnComponentRemoved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInImportantCombatAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsAnyConsumableDepleted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SpawnedItemEntity SelectPickableItem(Vec3 bMin, Vec3 bMax)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ItemPickupDone(SpawnedItemEntity spawnedItemEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RequestMoveToItem(SpawnedItemEntity item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UsableMissionObject GetCurrentlyMovingGameObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetCurrentlyMovingGameObject(UsableMissionObject objectOfInterest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UsableMissionObject GetCurrentlyDefendingGameObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetCurrentlyDefendingGameObject(UsableMissionObject objectOfInterest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MoveToUsableGameObject(UsableMissionObject usedObject, IDetachment detachment, Agent.AIScriptedFrameFlags scriptedFrameFlags = Agent.AIScriptedFrameFlags.NoAttack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MoveToClear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartDefendingGameObject(UsableMissionObject usedObject, IDetachment detachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopDefendingGameObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInterestedInAnyGameObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInterestedInGameObject(UsableMissionObject usableMissionObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FollowAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetDesiredSpeedInFormation(bool isCharging)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetFormationFrame(out WorldPosition formationPosition, out Vec2 formationDirection, out float speedLimit, out bool limitIsMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdjustSpeedLimit(Agent agent, float desiredSpeed, bool limitIsMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ParallelUpdateFormationMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRetreating()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDismount(Agent mount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBehaviorValueSet(BehaviorValueSet behaviorValueSet)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshBehaviorValues(MovementOrder.MovementOrderEnum movementOrder, ArrangementOrder.ArrangementOrderEnum arrangementOrder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceDisablePickUpForAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScriptedPositionAndDirectionTimed(Vec2 position, float directionAsRotationInRadians, float duration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableTimedScriptedMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static HumanAIComponent()
	{
		throw null;
	}
}
