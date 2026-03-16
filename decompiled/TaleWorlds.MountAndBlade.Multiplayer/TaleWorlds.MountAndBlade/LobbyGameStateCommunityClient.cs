using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public sealed class LobbyGameStateCommunityClient : LobbyGameState
{
	private CommunityClient _communityClient;

	private string _address;

	private int _port;

	private int _peerIndex;

	private int _sessionKey;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStartingParameters(CommunityClient communityClient, string address, int port, int peerIndex, int sessionKey)
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
	protected override void OnDisconnectedFromServer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LobbyGameStateCommunityClient()
	{
		throw null;
	}
}
