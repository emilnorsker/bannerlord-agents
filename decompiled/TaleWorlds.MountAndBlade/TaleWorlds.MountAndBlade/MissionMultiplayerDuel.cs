using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade.Network.Messages;

namespace TaleWorlds.MountAndBlade;

public class MissionMultiplayerDuel : MissionMultiplayerGameModeBase
{
	private class DuelInfo
	{
		private enum ChallengerType
		{
			None = -1,
			Requester,
			Requestee,
			NumChallengerType
		}

		private struct Challenger
		{
			public readonly MissionPeer MissionPeer;

			public readonly NetworkCommunicator NetworkPeer;

			public Agent DuelingAgent
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

			public Agent MountAgent
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

			public int KillCountInDuel
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
			public Challenger(MissionPeer missionPeer)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void OnDuelPreparation(Team duelingTeam)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void OnDuelEnded()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IncreaseWinCount()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void SetAgents(Agent agent)
			{
				throw null;
			}
		}

		private const float DuelStartCountdown = 3f;

		private readonly Challenger[] _challengers;

		private ChallengerType _winnerChallengerType;

		public MissionPeer RequesterPeer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public MissionPeer RequesteePeer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int DuelAreaIndex
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

		public TroopType DuelAreaTroopType
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

		public MissionTime Timer
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

		public Team DuelingTeam
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

		public bool Started
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

		public bool ChallengeEnded
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

		public MissionPeer ChallengeWinnerPeer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public MissionPeer ChallengeLoserPeer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DuelInfo(MissionPeer requesterPeer, MissionPeer requesteePeer, KeyValuePair<int, TroopType> duelAreaPair)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void DecideRoundWinner()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnDuelPreparation(Team duelTeam)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnDuelStarted()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnDuelEnding()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnDuelEnded()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnAgentBuild(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsDuelStillValid(bool doNotCheckAgent = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsPeerInThisDuel(MissionPeer peer)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UpdateDuelAreaIndex(KeyValuePair<int, TroopType> duelAreaPair)
		{
			throw null;
		}
	}

	public delegate void OnDuelEndedDelegate(MissionPeer winnerPeer, TroopType troopType);

	public const float DuelRequestTimeOutInSeconds = 10f;

	private const int MinBountyGain = 100;

	private const string AreaBoxTagPrefix = "area_box";

	private const string AreaFlagTagPrefix = "area_flag";

	public const int NumberOfDuelAreas = 16;

	public const float DuelEndInSeconds = 2f;

	private const float DuelRequestTimeOutServerToleranceInSeconds = 0.5f;

	private const float CorpseFadeOutTimeInSeconds = 1f;

	private List<GameEntity> _duelAreaFlags;

	private List<VolumeBox> _areaBoxes;

	private List<DuelInfo> _duelRequests;

	private List<DuelInfo> _activeDuels;

	private List<DuelInfo> _endingDuels;

	private List<DuelInfo> _restartingDuels;

	private List<DuelInfo> _restartPreparationDuels;

	private readonly Queue<Team> _deactiveDuelTeams;

	private List<KeyValuePair<MissionPeer, TroopType>> _peersAndSelections;

	private VolumeBox[] _cachedSelectedVolumeBoxes;

	private KeyValuePair<int, TroopType>[] _cachedSelectedAreaFlags;

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

	public event OnDuelEndedDelegate OnDuelEnded
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
	public override MultiplayerGameType GetMissionType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AddRemoveMessageHandlers(GameNetwork.NetworkMessageHandlerRegistererContainer registerer)
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
	private bool HandleClientEventDuelRequest(NetworkCommunicator peer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventDuelRequestAccepted(NetworkCommunicator peer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventDuelRequestChangePreferredTroopType(NetworkCommunicator peer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CheckIfPlayerCanDespawn(MissionPeer missionPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerDespawn(MissionPeer missionPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DuelRequestReceived(MissionPeer requesterPeer, MissionPeer requesteePeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private KeyValuePair<int, TroopType> GetNextAvailableDuelAreaIndex(Agent requesterAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DuelRequestAccepted(Agent requesterAgent, Agent requesteeAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Team ActivateAndGetDuelTeam()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeactivateDuelTeam(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHavingDuel(MissionPeer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsThereARequestBetweenPeers(MissionPeer requesterAgent, MissionPeer requesteeAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckDuelsToStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckDuelRequestTimeouts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForRestartingDuels()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckEndedDuels()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckRestartPreparationDuels()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PrepareDuel(DuelInfo duel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartDuel(DuelInfo duel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EndDuel(DuelInfo duel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TroopType GetAgentTroopType(Agent requesterAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CleanSpawnedEntitiesInDuelArea(int duelAreaIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleEndedChallenge(DuelInfo duel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetDuelAreaIndexIfDuelTeam(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentBuild(Agent agent, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleLateNewClientAfterSynchronized(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleEarlyPlayerDisconnect(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandlePlayerDisconnect(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPeerSelectedPreferredTroopType(MissionPeer missionPeer, TroopType troopType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionMultiplayerDuel()
	{
		throw null;
	}
}
