using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Network.Messages;
using TaleWorlds.MountAndBlade.Objects;

namespace TaleWorlds.MountAndBlade;

public class MissionMultiplayerFlagDomination : MissionMultiplayerGameModeBase, IAnalyticsFlagInfo, IMissionBehavior
{
	public const int NumberOfFlagsInGame = 3;

	public const float MoraleRoundPrecision = 0.01f;

	public const int DefaultGoldAmountForTroopSelectionForSkirmish = 300;

	public const int MaxGoldAmountToCarryOverForSkirmish = 80;

	private const int MaxGoldAmountToCarryOverForSurvivalForSkirmish = 30;

	public const int InitialGoldAmountForTroopSelectionForBattle = 200;

	public const int DefaultGoldAmountForTroopSelectionForBattle = 120;

	public const int MaxGoldAmountToCarryOverForBattle = 110;

	private const int MaxGoldAmountToCarryOverForSurvivalForBattle = 20;

	private const float MoraleGainOnTick = 0.000625f;

	private const float MoralePenaltyPercentageIfNoPointsCaptured = 0.1f;

	private const float MoraleTickTimeInSeconds = 0.25f;

	public const float TimeTillFlagRemovalForPriorInfoInSeconds = 30f;

	public const float PointRemovalTimeInSecondsForBattle = 210f;

	public const float PointRemovalTimeInSecondsForCaptain = 180f;

	public const float PointRemovalTimeInSecondsForSkirmish = 120f;

	public const float MoraleMultiplierForEachFlagForBattle = 0.75f;

	public const float MoraleMultiplierForEachFlagForCaptain = 1f;

	private const float MoraleMultiplierOnLastFlagForBattle = 3.5f;

	private static int _defaultGoldAmountForTroopSelection;

	private static int _maxGoldAmountToCarryOver;

	private static int _maxGoldAmountToCarryOverForSurvival;

	private const float MoraleMultiplierOnLastFlagForCaptainSkirmish = 2f;

	public const float MoraleMultiplierForEachFlagForSkirmish = 2f;

	private readonly float _pointRemovalTimeInSeconds;

	private readonly float _moraleMultiplierForEachFlag;

	private readonly float _moraleMultiplierOnLastFlag;

	private Team[] _capturePointOwners;

	private bool _flagRemovalOccured;

	private float _nextTimeToCheckForPointRemoval;

	private MissionMultiplayerGameModeFlagDominationClient _gameModeFlagDominationClient;

	private float _morale;

	private readonly MultiplayerGameType _gameType;

	private int[] _agentCountsOnSide;

	private (int, int)[] _defenderAttackerCountsInFlagArea;

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

	public float MoraleRounded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool GameModeUsesSingleSpawning
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool UseGold()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool AllowCustomPlayerBanners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool UseRoundController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionMultiplayerFlagDomination(MultiplayerGameType gameType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MultiplayerGameType GetMissionType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AddRemoveMessageHandlers(GameNetwork.NetworkMessageHandlerRegistererContainer registerer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPeerChangedTeam(NetworkCommunicator peer, Team oldTeam, Team newTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPreparationStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForPlayersSpawningAsBots()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetMoraleGain(out float moraleGain)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTimeUntilBattleSideVictory(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckMorales()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckRemovingOfPoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int RemoveCapturePoint(FlagCapturePoint capToRemove)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClearScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CheckIfOvertime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CheckForWarmupEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CheckForRoundEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool UseCultureSelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnWarmupEnding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRoundEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentBuild(Agent agent, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleRoundEnd(CaptureTheFlagCaptureResultEnum roundResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPostRoundEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleEarlyPlayerDisconnect(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPreTeamChanged(NetworkCommunicator peer, Team currentTeam, Team newTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPreparationEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckPlayerBeingDetached()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int PlayerDistanceToFormation(MissionPeer missionPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakePlayerFormationFollowPlayer(NetworkCommunicator peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakePlayerFormationCharge(NetworkCommunicator peer)
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
	private bool HandleClientEventRequestForfeitSpawn(NetworkCommunicator peer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForfeitSpawning(NetworkCommunicator peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetWinnerTeam(int winnerTeamNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfAttackersAroundFlag(FlagCapturePoint capturePoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Team GetFlagOwnerTeam(FlagCapturePoint flag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetTroopNumberMultiplierForMissingPlayer(MissionPeer spawningPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleNewClientAfterLoadingFinished(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionMultiplayerFlagDomination()
	{
		throw null;
	}
}
