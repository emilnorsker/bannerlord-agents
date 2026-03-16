using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class MissionAgentSpawnLogic : MissionLogic, IMissionAgentSpawnLogic, IMissionBehavior
{
	internal struct FormationSpawnData
	{
		public int FootTroopCount;

		public int MountedTroopCount;

		public int NumTroops
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}
	}

	private class MissionSide
	{
		private readonly MissionAgentSpawnLogic _spawnLogic;

		private readonly BattleSideEnum _side;

		private readonly IMissionTroopSupplier _troopSupplier;

		private BannerBearerLogic _bannerBearerLogic;

		private readonly MBArrayList<Formation> _spawnedFormations;

		private bool _spawnWithHorses;

		private float _reinforcementBatchPriority;

		private int _reinforcementQuotaRequirement;

		private int _reinforcementBatchSize;

		private int _reinforcementsSpawnedInLastBatch;

		private int _numSpawnedTroops;

		private readonly List<IAgentOriginBase> _reservedTroops;

		private List<(Team team, List<IAgentOriginBase> origins)> _troopOriginsToSpawnPerTeam;

		private readonly (int currentTroopIndex, int troopCount)[] _reinforcementSpawnedUnitCountPerFormation;

		private readonly Dictionary<IAgentOriginBase, int> _reinforcementTroopFormationAssignments;

		public bool TroopSpawnActive
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

		public bool IsPlayerSide
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public bool ReinforcementSpawnActive
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

		public bool SpawnWithHorses
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public bool ReinforcementsNotifiedOnLastBatch
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

		public int NumberOfActiveTroops
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int ReinforcementQuotaRequirement
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int ReinforcementsSpawnedInLastBatch
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public float ReinforcementBatchSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public bool HasReservedTroops
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public float ReinforcementBatchPriority
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int ReservedTroopsCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public bool HasSpawnableReinforcements
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetNumberOfPlayerControllableTroops()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MissionSide(MissionAgentSpawnLogic spawnLogic, BattleSideEnum side, IMissionTroopSupplier troopSupplier, bool isPlayerSide)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int TryReinforcementSpawn()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void GetTeamFormationsSpawnData(out List<(Team team, FormationSpawnData[] formationSpawnData)> teamFormationsSpawnData)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ReserveTroops(int number)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BasicCharacterObject GetGeneralCharacter()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool CheckReinforcementBatch()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public IEnumerable<IAgentOriginBase> GetAllTroops()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int SpawnTroops(int number, bool isReinforcement)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSpawnWithHorses(bool spawnWithHorses)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int ComputeBalancedBatch(SpawnPhase activePhase)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int ComputeFixedBatch(SpawnPhase activePhase)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int ComputeWaveBatch(SpawnPhase activePhase)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetBannerBearerLogic(BannerBearerLogic bannerBearerLogic)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateReinforcementQuotaRequirement(int previousBatchSize)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetReinforcementsNotifiedOnLastBatch(bool value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ResetReinforcementSpawnedUnitCountsPerFormation()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSpawnTroops(bool spawnTroops)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int GetReservedTroopQuota(int index)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnInitialSpawnOver()
		{
			throw null;
		}
	}

	private class SpawnPhase
	{
		public int TotalSpawnNumber;

		public int InitialSpawnedNumber;

		public int InitialSpawnNumber;

		public int RemainingSpawnNumber;

		public int NumberActiveTroops;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnInitialTroopsSpawned()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SpawnPhase()
		{
			throw null;
		}
	}

	public delegate void OnPhaseChangedDelegate();

	private static int _maxNumberOfAgentsForMissionCache;

	private readonly OnPhaseChangedDelegate[] _onPhaseChanged;

	private readonly List<SpawnPhase>[] _phases;

	private readonly int[] _numberOfTroopsInTotal;

	private readonly int _battleSize;

	private bool _reinforcementSpawnEnabled;

	private bool _spawningReinforcements;

	private readonly BasicMissionTimer _globalReinforcementSpawnTimer;

	private ICustomReinforcementSpawnTimer _customReinforcementSpawnTimer;

	private float _globalReinforcementInterval;

	private MissionSpawnSettings _spawnSettings;

	private readonly MissionSide[] _missionSides;

	private BannerBearerLogic _bannerBearerLogic;

	private DefaultMissionDeploymentPlan _deploymentPlan;

	private List<BattleSideEnum> _sidesWhereSpawnOccured;

	private readonly MissionSide _playerSide;

	public static int MaxNumberOfAgentsForMission
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static int MaxNumberOfTroopsForMission
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NumberOfAgents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NumberOfRemainingTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NumberOfActiveDefenderTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NumberOfActiveAttackerTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NumberOfRemainingDefenderTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NumberOfRemainingAttackerTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int BattleSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsInitialSpawnOver
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsDeploymentOver
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ref readonly MissionSpawnSettings ReinforcementSpawnSettings
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal DefaultMissionDeploymentPlan DeploymentPlan
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int TotalSpawnNumber
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private SpawnPhase DefenderActivePhase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private SpawnPhase AttackerActivePhase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event Action<BattleSideEnum, int> OnReinforcementsSpawned
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

	public event Action<BattleSideEnum, int> OnInitialTroopsSpawned
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
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfPlayerControllableTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitWithSinglePhase(int defenderTotalSpawn, int attackerTotalSpawn, int defenderInitialSpawn, int attackerInitialSpawn, bool spawnDefenders, bool spawnAttackers, in MissionSpawnSettings spawnSettings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<IAgentOriginBase> GetAllTroopsForSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionAgentSpawnLogic(IMissionTroopSupplier[] suppliers, BattleSideEnum playerSide, Mission.BattleSizeType battleSizeType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomReinforcementSpawnTimer(ICustomReinforcementSpawnTimer timer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpawnTroops(BattleSideEnum side, bool spawnTroops, bool enforceSpawning = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpawnHorses(BattleSideEnum side, bool spawnHorses)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartSpawner(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopSpawner(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSideSpawnEnabled(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSideDeploymentOver(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetReinforcementInterval()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetReinforcementsSpawnEnabled(bool value, bool resetTimers = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTotalNumberOfTroopsForSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BasicCharacterObject GetGeneralCharacterOfSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetSpawnHorses(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckMinimumBatchQuotaRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckGlobalReinforcementBatch()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckCustomReinforcementBatch()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSideDepleted(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPhaseChangeAction(BattleSideEnum side, OnPhaseChangedDelegate onPhaseChanged)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Init(bool spawnDefenders, bool spawnAttackers, in MissionSpawnSettings reinforcementSpawnSettings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPhase(BattleSideEnum side, int totalSpawn, int initialSpawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PhaseTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckDeployment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeTeamPlans(Team team, FormationSpawnData[] formationsSpawnData, float spawnPathOffset = 0f, float targetOffset = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckReinforcementSpawn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NotifyReinforcementTroopsSpawned(BattleSideEnum battleSide, bool checkEmptyReserves = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OrderController_OnOrderIssued(OrderType orderType, MBReadOnlyList<Formation> appliedFormations, OrderController orderController, params object[] delegateParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetBattleSizeForActivePhase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SpawnPhase GetActivePhaseForSide(BattleSideEnum side)
	{
		throw null;
	}
}
