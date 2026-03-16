using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Objects;

namespace TaleWorlds.MountAndBlade;

public class MissionMultiplayerSiege : MissionMultiplayerGameModeBase, IAnalyticsFlagInfo, IMissionBehavior
{
	private class ObjectiveSystem
	{
		private class ObjectiveContributor
		{
			public readonly MissionPeer Peer;

			public float Contribution
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
			public ObjectiveContributor(MissionPeer peer, float initialContribution)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IncreaseAmount(float deltaContribution)
			{
				throw null;
			}
		}

		private readonly Dictionary<GameEntity, List<ObjectiveContributor>[]> _objectiveContributorMap;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ObjectiveSystem()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool RegisterObjective(GameEntity entity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddContributionForObjective(GameEntity objectiveEntity, MissionPeer contributorPeer, float contribution)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<KeyValuePair<MissionPeer, float>> GetAllContributorsForSideAndClear(GameEntity objectiveEntity, BattleSideEnum side)
		{
			throw null;
		}
	}

	public delegate void OnDestructableComponentDestroyedDelegate(DestructableComponent destructableComponent, ScriptComponentBehavior attackerScriptComponentBehaviour, MissionPeer[] contributors);

	public delegate void OnObjectiveGoldGainedDelegate(MissionPeer peer, int goldGain);

	public const int NumberOfFlagsInGame = 7;

	public const int NumberOfFlagsAffectingMoraleInGame = 6;

	public const int MaxMorale = 1440;

	public const int StartingMorale = 360;

	private const int FirstSpawnGold = 120;

	private const int FirstSpawnGoldForEarlyJoin = 160;

	private const int RespawnGold = 100;

	private const float ObjectiveCheckPeriod = 0.25f;

	private const float MoraleTickTimeInSeconds = 1f;

	public const int MaxMoraleGainPerFlag = 90;

	private const int MoraleBoostOnFlagRemoval = 90;

	private const int MoraleDecayInTick = -1;

	private const int MoraleDecayOnDefenderInTick = -6;

	public const int MoraleGainPerFlag = 1;

	public const int GoldBonusOnFlagRemoval = 35;

	public const string MasterFlagTag = "keep_capture_point";

	private int[] _morales;

	private Agent _masterFlagBestAgent;

	private FlagCapturePoint _masterFlag;

	private Team[] _capturePointOwners;

	private int[] _capturePointRemainingMoraleGains;

	private float _dtSumCheckMorales;

	private float _dtSumObjectiveCheck;

	private ObjectiveSystem _objectiveSystem;

	private (IMoveableSiegeWeapon, Vec3)[] _movingObjectives;

	private (RangedSiegeWeapon, Agent)[] _lastReloadingAgentPerRangedSiegeMachine;

	private MissionMultiplayerSiegeClient _gameModeSiegeClient;

	private MultiplayerWarmupComponent _warmupComponent;

	private Dictionary<GameEntity, List<DestructableComponent>> _childDestructableComponents;

	private bool _firstTickDone;

	public override bool IsGameModeHidingAllAgentVisuals
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool IsGameModeUsingOpposingTeams
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<FlagCapturePoint> AllCapturePoints
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

	public event OnDestructableComponentDestroyedDelegate OnDestructableComponentDestroyed
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

	public event OnObjectiveGoldGainedDelegate OnObjectiveGoldGained
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
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static DestructableComponent GetDestructableCompoenentClosestToTheRoot(GameEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RangedSiegeMachineOnAgentLoadsMachine(RangedSiegeWeapon siegeWeapon, Agent reloadingAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestructableComponentOnHitTaken(DestructableComponent destructableComponent, Agent attackerAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestructableComponentOnDestroyed(DestructableComponent destructableComponent, Agent attackerAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MultiplayerGameType GetMissionType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool UseRoundController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckMorales(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CheckForMatchEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Team GetWinnerTeam()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetMoraleGain(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Team GetFlagOwnerTeam(FlagCapturePoint flag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckObjectives(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickFlags(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickObjectives(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnWarmupEnding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CheckForWarmupEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleEarlyNewClientAfterLoadingFinished(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleNewClientAfterSynchronized(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPeerChangedTeam(NetworkCommunicator peer, Team oldTeam, Team newTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleNewClientAfterLoadingFinished(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClearScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionMultiplayerSiege()
	{
		throw null;
	}
}
