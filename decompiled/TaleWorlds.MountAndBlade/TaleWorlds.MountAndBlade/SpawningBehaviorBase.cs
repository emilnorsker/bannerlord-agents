using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public abstract class SpawningBehaviorBase
{
	public delegate void OnSpawningEndedEventDelegate();

	private const float SecondsToWaitForEachMountBeforeSelectingToFadeOut = 30f;

	private const float SecondsToWaitBeforeNextMountCleanup = 5f;

	private static readonly int _maxAgentCount;

	private static readonly int _agentCountThreshold;

	protected MissionMultiplayerGameModeBase GameMode;

	protected SpawnComponent SpawnComponent;

	private bool _equipmentUpdatingExpired;

	protected bool IsSpawningEnabled;

	protected Timer SpawnCheckTimer;

	protected float SpawningEndDelay;

	protected float SpawningDelayTimer;

	private bool _hasCalledSpawningEnded;

	protected MissionLobbyComponent MissionLobbyComponent;

	protected MissionLobbyEquipmentNetworkComponent MissionLobbyEquipmentNetworkComponent;

	private List<AgentBuildData> _agentsToBeSpawnedCache;

	private MissionTime _nextTimeToCleanUpMounts;

	private int[] _botsCountForSides;

	protected MultiplayerMissionAgentVisualSpawnComponent AgentVisualSpawnComponent
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

	protected Mission Mission
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected event Action<MissionPeer> OnAllAgentsFromPeerSpawnedFromVisuals
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

	protected event Action<MissionPeer> OnPeerSpawnedFromVisuals
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

	public event OnSpawningEndedEventDelegate OnSpawningEnded
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
	public virtual void Initialize(SpawnComponent spawnComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AreAgentsSpawning()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ResetSpawnCounts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ResetSpawnTimers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void RequestStartSpawnSession()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RequestStopSpawnSession()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRemainingAgentsInvulnerable()
	{
		throw null;
	}

	protected abstract void SpawnAgents();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected BodyProperties GetBodyProperties(MissionPeer missionPeer, BasicCultureObject cultureLimit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SpawnBot(Team agentTeam, BasicCultureObject cultureLimit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPeerEquipmentUpdated(MissionPeer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool CanUpdateSpawnEquipment(MissionPeer missionPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ToggleUpdatingSpawnEquipment(bool canUpdate)
	{
		throw null;
	}

	public abstract bool AllowEarlyAgentVisualsDespawning(MissionPeer missionPeer);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual int GetMaximumReSpawnPeriodForPeer(MissionPeer peer)
	{
		throw null;
	}

	protected abstract bool IsRoundInProgress();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnClearScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected SpawningBehaviorBase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SpawningBehaviorBase()
	{
		throw null;
	}
}
