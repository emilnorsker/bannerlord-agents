using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public class StonePile : UsableMachine, IDetachment
{
	[DefineSynchedMissionObjectType(typeof(StonePile))]
	public struct StonePileRecord : ISynchedMissionObjectReadableRecord
	{
		public int ReadAmmoCount
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
		public StonePileRecord(int readAmmoCount)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ReadFromNetwork(ref bool bufferReadValid)
		{
			throw null;
		}
	}

	private class ThrowingPoint
	{
		public struct StackArray8ThrowingPoint
		{
			private ThrowingPoint _element0;

			private ThrowingPoint _element1;

			private ThrowingPoint _element2;

			private ThrowingPoint _element3;

			private ThrowingPoint _element4;

			private ThrowingPoint _element5;

			private ThrowingPoint _element6;

			private ThrowingPoint _element7;

			public const int Length = 8;

			public ThrowingPoint this[int index]
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				get
				{
					throw null;
				}
				[MethodImpl(MethodImplOptions.NoInlining)]
				set
				{
					throw null;
				}
			}
		}

		private const float CachedCanUseAttackEntityUpdateInterval = 1f;

		public StandingPointWithVolumeBox StandingPoint;

		public StandingPointWithWeaponRequirement AmmoPickUpPoint;

		public StandingPointWithWeaponRequirement WaitingPoint;

		public Timer EnemyInRangeTimer;

		public GameEntity AttackEntity;

		public float AttackEntityNearbyAgentsCheckRadius;

		private float _cachedCanUseAttackEntityExpireTime;

		private bool _cachedCanUseAttackEntity;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool CanUseAttackEntity()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ThrowingPoint()
		{
			throw null;
		}
	}

	private struct VolumeBoxTimerPair
	{
		public VolumeBox VolumeBox;

		public Timer Timer;
	}

	private const string ThrowingTargetTag = "throwing_target";

	private const string ThrowingPointTag = "throwing";

	private const string WaitingPointTag = "wait_to_throw";

	private const float EnemyInRangeTimerDuration = 0.5f;

	private const float EnemyWaitTimeLimit = 3f;

	private const float ThrowingTargetRadius = 1.31f;

	public int StartingAmmoCount;

	public string GivenItemID;

	[EditableScriptComponentVariable(true, "")]
	private float _givenItemRange;

	private ItemObject _givenItem;

	private List<GameEntity> _throwingTargets;

	private List<ThrowingPoint> _throwingPoints;

	private List<VolumeBoxTimerPair> _volumeBoxTimerPairs;

	private Timer _tickOccasionallyTimer;

	public int AmmoCount
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

	public bool HasThrowingPointUsed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual BattleSideEnum Side
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MaxUserCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected StonePile()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ConsumeAmmo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAmmo(int ammoLeft)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void CheckAmmo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMissionReset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterMissionStart()
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
	public override bool IsInRangeToCheckAlternativePoints(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override StandingPoint GetBestPointAlternativeTo(StandingPoint standingPoint, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickOccasionally()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReleaseAllUserAgentsAndFormations(BattleSideEnum sideFilterForAIControlledAgents, bool disableForNonAIControlledAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateThrowingPointAttackEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ShouldStandAtWaitingPoint(ThrowingPoint throwingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool UpdateThrowingPointIfHasAnyInteractingAgent(ThrowingPoint throwingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void WriteToNetwork()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float? IDetachment.GetWeightOfAgentAtNextSlot(List<(Agent, float)> candidates, out Agent match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float? IDetachment.GetWeightOfAgentAtNextSlot(List<Agent> candidates, out Agent match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override StandingPoint GetSuitableStandingPointFor(BattleSideEnum side, Agent agent = null, List<Agent> agents = null, List<(Agent, float)> agentValuePairs = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetDetachmentWeightAux(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void UpdateAmmoMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanShootAtEntity(Agent agent, WeakGameEntity entity, bool canShootEvenIfRayCastHitsNothing = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<WeakGameEntity> GetEnemySiegeWeapons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsThrowingPointAssignable(ThrowingPoint throwingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AssignAgentToStandingPoint(StandingPoint standingPoint, Agent agent)
	{
		throw null;
	}
}
