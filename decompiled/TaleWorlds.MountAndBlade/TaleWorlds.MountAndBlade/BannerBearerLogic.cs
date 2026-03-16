using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class BannerBearerLogic : MissionLogic
{
	private class FormationBannerController
	{
		public enum BannerState
		{
			Initialized,
			OnAgent,
			OnGround
		}

		public struct BannerInstance
		{
			public readonly Agent BannerBearer;

			public readonly GameEntity Entity;

			private readonly BannerState State;

			public bool IsOnGround
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				get
				{
					throw null;
				}
			}

			public bool IsOnAgent
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				get
				{
					throw null;
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public BannerInstance(Agent bannerBearer, GameEntity entity, BannerState state)
			{
				throw null;
			}
		}

		private int _lastActiveBannerBearerCount;

		private bool _requiresAgentStatUpdate;

		private BannerBearerLogic _bannerLogic;

		private Mission _mission;

		private Dictionary<Agent, (GameEntity bannerEntity, float lastDistance)> _bannerSearchers;

		private readonly Dictionary<UIntPtr, BannerInstance> _bannerInstances;

		private MBList<Agent> _nearbyAllyAgentsListCache;

		public Formation Formation
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

		public ItemObject BannerItem
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

		public bool HasBanner
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public List<Agent> BannerBearers
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public List<GameEntity> BannersOnGround
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int NumberOfBannerBearers
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int NumberOfBanners
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public static float BannerSearchDistance
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FormationBannerController(Formation formation, ItemObject bannerItem, BannerBearerLogic bannerLogic, Mission mission)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetBannerItem(ItemObject bannerItem)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool HasBannerEntity(GameEntity bannerEntity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool HasBannerOnGround()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool HasActiveBannerBearers()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsBannerSearchingAgent(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetNumberOfActiveBannerBearers()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UpdateAgentStats(bool forceUpdate = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void RepositionFormation()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UpdateBannerSearchers()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UpdateBannerBearersForDeployment()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddBannerEntity(GameEntity entity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RemoveBannerEntity(WeakGameEntity entity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnBannerEntityPickedUp(GameEntity entity, Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnBannerEntityDropped(GameEntity entity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnBeforeFormationMovementOrderApplied(Formation formation, MovementOrder.MovementOrderEnum orderType)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnAfterArrangementOrderApplied(Formation formation, ArrangementOrder.ArrangementOrderEnum orderEnum)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Agent FindBestSearcherForBanner(GameEntity banner, out float distance)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<Agent> FindBannerBearableAgents(int count)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateBannerBearerArrangementPositions()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnAgentAdded(Formation formation, Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnAgentRemoved(Formation formation, Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CheckRequiresAgentStatUpdate()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddBannerSearcher(Agent searcher, GameEntity banner, float distance)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void RemoveBannerSearcher(Agent searcher)
		{
			throw null;
		}
	}

	public const float DefaultBannerBearerAgentDefensiveness = 1f;

	public const float BannerSearcherUpdatePeriod = 3f;

	private readonly Dictionary<UIntPtr, FormationBannerController> _bannerToFormationMap;

	private readonly Dictionary<Formation, FormationBannerController> _formationBannerData;

	private readonly Dictionary<Agent, Equipment> _initialSpawnEquipments;

	private readonly BasicMissionTimer _bannerSearcherUpdateTimer;

	private readonly List<FormationBannerController> _playerFormationsRequiringUpdate;

	private bool _isMissionEnded;

	public IMissionAgentSpawnLogic AgentSpawnLogic
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

	public event Action<Formation> OnBannerBearersUpdated
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

	public event Action<Agent, bool> OnBannerBearerAgentUpdated
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
	public BannerBearerLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFormationBanner(Formation formation, SpawnedItemEntity spawnedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasBannerOnGround(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BannerComponent GetActiveBanner(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<Agent> GetFormationBannerBearers(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemObject GetFormationBanner(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBannerSearchingAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMissingBannerCount(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Formation GetFormationFromBanner(SpawnedItemEntity spawnedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFormationBanner(Formation formation, ItemObject newBanner)
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
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnItemPickup(Agent agent, SpawnedItemEntity spawnedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnItemDrop(Agent agent, SpawnedItemEntity spawnedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentPanicked(Agent affectedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateAgent(Agent agent, bool willBecomeBannerBearer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent SpawnBannerBearer(IAgentOriginBase troopOrigin, bool isPlayerSide, Formation formation, bool spawnWithHorse, bool isReinforcement, int formationTroopCount, int formationTroopIndex, bool isAlarmed, bool wieldInitialWeapons, bool forceDismounted, Vec3? initialPosition, Vec2? initialDirection, string specialActionSetSuffix = null, bool useTroopClassForSpawn = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsBannerItem(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBannerEntity(FormationBannerController formationBannerController, GameEntity bannerEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveBannerEntity(FormationBannerController formationBannerController, WeakGameEntity bannerEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private FormationBannerController GetFormationControllerFromFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private FormationBannerController GetFormationControllerFromBannerEntity(WeakGameEntity bannerEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Equipment CreateBannerEquipmentForAgent(Agent agent, ItemObject bannerItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveBannerOfAgent(Agent agent)
	{
		throw null;
	}
}
