using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade;

public sealed class LobbyGameStateCustomGameClient : LobbyGameState
{
	private LobbyClient _gameClient;

	private string _address;

	private int _port;

	private int _peerIndex;

	private int _sessionKey;

	private Timer _inactivityTimer;

	private static readonly float InactivityThreshold;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStartingParameters(LobbyClient gameClient, string address, int port, int peerIndex, int sessionKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void StartMultiplayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LobbyGameStateCustomGameClient()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LobbyGameStateCustomGameClient()
	{
		throw null;
	}
}
