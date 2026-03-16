using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade;

public sealed class LobbyGameStateMatchmakerClient : LobbyGameState
{
	private LobbyClient _gameClient;

	private int _playerIndex;

	private int _sessionKey;

	private string _address;

	private int _assignedPort;

	private string _multiplayerGameType;

	private string _scene;

	private LobbyGameClientHandler _lobbyGameClientHandler;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStartingParameters(LobbyGameClientHandler lobbyGameClientHandler, int playerIndex, int sessionKey, string address, int assignedPort, string multiplayerGameType, string scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void StartMultiplayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LobbyGameStateMatchmakerClient()
	{
		throw null;
	}
}
