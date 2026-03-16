using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public abstract class MissionMultiplayerGameModeBase : MissionNetwork
{
	public const int GoldCap = 2000;

	public const float PerkTickPeriod = 1f;

	public const float GameModeSystemTickPeriod = 0.25f;

	private float _lastPerkTickTime;

	private MultiplayerMissionAgentVisualSpawnComponent _agentVisualSpawnComponent;

	public MultiplayerTeamSelectComponent MultiplayerTeamSelectComponent;

	protected MissionLobbyComponent MissionLobbyComponent;

	protected MultiplayerGameNotificationsComponent NotificationsComponent;

	public MultiplayerRoundController RoundController;

	public MultiplayerWarmupComponent WarmupComponent;

	public MultiplayerTimerComponent TimerComponent;

	protected MissionMultiplayerGameModeBaseClient GameModeBaseClient;

	private float _gameModeSystemTickTimer;

	public abstract bool IsGameModeHidingAllAgentVisuals { get; }

	public abstract bool IsGameModeUsingOpposingTeams { get; }

	public virtual bool IsGameModeAllowChargeDamageOnFriendly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public SpawnComponent SpawnComponent
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

	protected bool CanGameModeSystemsTickThisFrame
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

	public abstract MultiplayerGameType GetMissionType();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool CheckIfOvertime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool CheckForWarmupEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool CheckForRoundEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool CheckForMatchEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool UseCultureSelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool UseRoundController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual Team GetWinnerTeam()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnPeerChangedTeam(NetworkCommunicator peer, Team oldTeam, Team newTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClearScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearPeerCounts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ShouldSpawnVisualsForServer(NetworkCommunicator spawningNetworkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleAgentVisualSpawning(NetworkCommunicator spawningNetworkPeer, AgentBuildData spawningAgentBuildData, int troopCountInFormation = 0, bool useCosmetics = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool AllowCustomPlayerBanners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual int GetScoreForKill(Agent killedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetTroopNumberMultiplierForMissingPlayer(MissionPeer spawningPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCurrentGoldForPeer(MissionPeer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeCurrentGoldForPeer(MissionPeer peer, int newAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleLateNewClientAfterLoadingFinished(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool CheckIfPlayerCanDespawn(MissionPeer missionPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Dictionary<string, string> GetUsedCosmeticsFromPeer(MissionPeer missionPeer, BasicCharacterObject selectedTroopCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddCosmeticItemsToEquipment(Equipment equipment, Dictionary<string, string> choosenCosmetics)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsClassAvailable(MultiplayerClassDivisions.MPHeroClass heroClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MissionMultiplayerGameModeBase()
	{
		throw null;
	}
}
