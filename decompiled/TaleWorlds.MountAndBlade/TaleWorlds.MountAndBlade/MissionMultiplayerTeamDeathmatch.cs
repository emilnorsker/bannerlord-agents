using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class MissionMultiplayerTeamDeathmatch : MissionMultiplayerGameModeBase
{
	public const int MaxScoreToEndMatch = 1023000;

	private const int FirstSpawnGold = 120;

	private const int RespawnGold = 100;

	private MissionScoreboardComponent _missionScoreboardComponent;

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
	public MissionMultiplayerTeamDeathmatch()
	{
		throw null;
	}
}
