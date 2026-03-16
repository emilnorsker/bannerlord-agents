using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class ConsoleMatchStartEndHandler : MissionNetwork
{
	private enum MatchState
	{
		NotPlaying,
		Playing
	}

	private MissionMultiplayerGameModeBaseClient _gameModeClient;

	private MultiplayerMissionAgentVisualSpawnComponent _visualSpawnComponent;

	private MatchState _matchState;

	private bool _inGameCheckActive;

	private float _playingCheckTimer;

	private List<VirtualPlayer> _activeOtherPlayers;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AgentVisualSpawnComponentOnOnMyAgentVisualSpawned()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTeamChange(NetworkCommunicator peer, Team previousTeam, Team newTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentBuild(Agent agent, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConsoleMatchStartEndHandler()
	{
		throw null;
	}
}
