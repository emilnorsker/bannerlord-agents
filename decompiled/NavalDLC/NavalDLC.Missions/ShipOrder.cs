using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions;

public class ShipOrder
{
	public enum ShipMovementOrderEnum
	{
		Stop = 0,
		Move = 1,
		Retreat = 2,
		StaticOrderCount = 3,
		Follow = 3,
		Engage = 4,
		Skirmish = 5
	}

	private enum ShipIndependenceState
	{
		Independent,
		Connected,
		EnemyOnShip
	}

	private enum ShipDetachmentPriority
	{
		PlacementDetachment = 1,
		Oar,
		ControllerMachine,
		SiegeWeapon,
		ConnectionMachine
	}

	private const float BoardingDistance = 12f;

	private const float SkirmishDistance = 60f;

	private const float TimerDuration = 1f;

	private const float TargetCorrectionCheckDistance = 2f;

	private readonly QueryData<bool> _isEnemyOnShip;

	private readonly QueryData<MissionShip> _closestEnemyShip;

	private readonly MissionShip _ownerShip;

	private Vec2 _orderGlobalPosition;

	private Vec2 _orderGlobalDirection;

	private bool _inSkirmishPosition;

	private float _offsetDirection;

	private bool _autoSelectTargetShip;

	private Vec2 _offsetPosition;

	private Formation _ownerFormation;

	private NavalShipsLogic _navalShipsLogic;

	private bool _cutLooseOrderActive;

	private MissionShip _boardingTargetShip;

	private ShipIndependenceState _shipIndependenceState;

	private RandomTimer _detachmentTickTimer;

	private bool _oarLevelOverridden;

	private int _originalOarsmenLevel;

	private bool _isChargeOrderOverridden;

	private MBList<IFormationUnit> _availableUnitList;

	private Vec2 _lastCheckedOrderPosition;

	private bool _enforceSailUsage;

	private MissionTimer _orderTimer;

	private MissionTimer _placementDetachmentTimer;

	public MissionShip TargetShip
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

	public bool HasAIController
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAIControllableWithoutTroops
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

	public bool IsAIControllable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasStaticOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAutoSelectingTargetShip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int OarsmenLevel
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

	public bool TickDetachmentsNeeded
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

	public bool BoardAtWill
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

	public bool IsBoardingAvailable
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

	public ShipMovementOrderEnum MovementOrderEnum
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

	public MissionShip ClosestEnemyShip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsEnemyOnShip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool EnforceSailUsage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipOrder(MissionShip missionShip, Formation ownerFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeEnemyOnShipExpire()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnforcedSailUsage(bool enforce)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipCaptured(MissionShip ship1, MissionShip ship2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAIControllableWithoutTroops(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FormationJoinShip(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopUsingMachines(bool justStartedBurning)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FormationLeaveShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOarsmenLevelLocked()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOrderOarsmenLevel(int newOarsmenLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetOarsmenLevel(int newOarsmenLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsCuttingLoose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ToggleCutLoose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCutLoose(bool enable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsAttemptingBoarding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionShip GetBoardingTargetShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBoardingTargetShip(MissionShip missionShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipStopOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipMovementOrder(in Vec2 targetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipRetreatOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipSkirmishOrder(bool autoTargetClosest = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipFollowOrder(MissionShip shipToFollow, float offsetDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipMovementOrder(Vec2 targetPosition, in Vec2 targetDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipEngageOrder(bool autoTargetClosest = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipEngageOrder(MissionShip shipToEngage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipSkirmishOrder(MissionShip shipToSkirmish)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProjectOrderPositionToBoundaries(ref Vec2 orderPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent GetNextAgent(ref int currentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateStaticMovementOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickClimbingMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateDynamicMovementOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TrySelectBetterTargetShip(float decisionDistance = 4f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DecideOarsmenLevel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateFollowOrder(MissionShip shipToFollow, in Vec2 offsetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSkirmishOrder(MissionShip shipToSkirmish)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateEngageOrder(MissionShip shipToEngage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetStopShipAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTargetPosition(in Vec2 targetPosition, bool isForced = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTargetState(in Vec2 targetPosition, in Vec2 targetDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMovementTargetShip(MissionShip targetShip, in Vec2 positionOffset, float directionOffset = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ManageShipDetachments()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryTeleportShipAux(in Vec2 position, in Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetChargeOrder(bool applyToPlayerFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void JoinPlayerFormationToPlacementDetachment(bool isPlayersOrder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RefreshOrders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnOwnerShipRemoved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndChangeIndependenceState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipControllerChanged(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipRemoved(MissionShip ship)
	{
		throw null;
	}
}
