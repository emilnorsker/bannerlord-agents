using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public struct MovementOrder
{
	public enum MovementOrderEnum
	{
		Invalid = 0,
		AttackEntity = 1,
		Charge = 2,
		ChargeToTarget = 3,
		Follow = 4,
		FollowEntity = 5,
		Move = 7,
		Retreat = 8,
		Stop = 9,
		Advance = 10,
		FallBack = 11
	}

	public enum MovementStateEnum
	{
		Charge,
		Hold,
		Retreat,
		StandGround
	}

	public enum Side
	{
		Front,
		Rear,
		Left,
		Right
	}

	private enum FollowState
	{
		Stop,
		Depart,
		Move,
		Arrive
	}

	public static readonly MovementOrder MovementOrderNull;

	public static readonly MovementOrder MovementOrderCharge;

	public static readonly MovementOrder MovementOrderRetreat;

	public static readonly MovementOrder MovementOrderStop;

	public static readonly MovementOrder MovementOrderAdvance;

	public static readonly MovementOrder MovementOrderFallBack;

	private FollowState _followState;

	private float _departStartTime;

	public readonly MovementOrderEnum OrderEnum;

	private Func<Formation, WorldPosition> _positionLambda;

	private WorldPosition _position;

	private WorldPosition _getPositionResultCache;

	private WorldPosition _engageTargetPositionCache;

	private float _engageTargetPositionOffset;

	private bool _getPositionIsNavmeshlessCache;

	private WorldPosition _getPositionFirstSectionCache;

	public GameEntity TargetEntity;

	private readonly Timer _tickTimer;

	private WorldPosition _lastPosition;

	public readonly bool _isFacingDirection;

	public Formation TargetFormation
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

	public Agent _targetAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public OrderType OrderType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MovementStateEnum MovementState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MovementOrder(MovementOrderEnum orderEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MovementOrder(MovementOrderEnum orderEnum, Formation targetFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WorldPosition ComputeAttackEntityWaitPosition(Formation formation, WeakGameEntity targetEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MovementOrder(MovementOrderEnum orderEnum, GameEntity targetEntity, bool surroundEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MovementOrder(MovementOrderEnum orderEnum, Agent targetAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MovementOrder(MovementOrderEnum orderEnum, GameEntity targetEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MovementOrder(MovementOrderEnum orderEnum, WorldPosition position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(in MovementOrder m, MovementOrder obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(in MovementOrder m, MovementOrder obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MovementOrder MovementOrderChargeToTarget(Formation targetFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MovementOrder MovementOrderFollow(Agent targetAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MovementOrder MovementOrderFollowEntity(GameEntity targetEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MovementOrder MovementOrderMove(WorldPosition position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MovementOrder MovementOrderAttackEntity(GameEntity targetEntity, bool surroundEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetMovementOrderDefensiveness(MovementOrderEnum orderEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetMovementOrderDefensivenessChange(MovementOrderEnum previousOrderEnum, MovementOrderEnum nextOrderEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void RetreatAux(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static WorldPosition GetAlternatePositionForNavmeshlessOrOutOfBoundsPosition(Formation f, WorldPosition originalPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetPositionAuxFollow(Formation f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetPosition(Formation f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetTargetVelocity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition CreateNewOrderWorldPositionMT(Formation f, WorldPosition.WorldPositionEnforcedCache worldPositionEnforcedCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetPositionCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AreOrdersPracticallySame(MovementOrder m1, MovementOrder m2, bool isAIControlled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnApply(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCancel(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnUnitJoinOrLeave(Formation formation, Agent unit, bool isJoining)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsApplicable(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsInstance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Tick(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickOccasionally(Formation formation, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnArrangementChanged(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Advance(Formation formation, float distance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FallBack(Formation formation, float distance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (Agent, float) GetBestAgent(List<Agent> candidateAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (Agent, float) GetWorstAgent(List<Agent> currentAgents, int requiredAgentCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MovementOrder GetSubstituteOrder(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2 GetDirectionAux(Formation f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WorldPosition GetPositionAux(Formation f, WorldPosition.WorldPositionEnforcedCache worldPositionEnforcedCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CancelChargeOrder(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MovementOrder()
	{
		throw null;
	}
}
