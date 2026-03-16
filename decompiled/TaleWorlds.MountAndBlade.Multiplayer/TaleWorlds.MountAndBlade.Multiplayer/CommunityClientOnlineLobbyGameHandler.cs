using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade.Multiplayer;

public class CommunityClientOnlineLobbyGameHandler : ICommunityClientHandler
{
	public LobbyState LobbyState
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
	public CommunityClientOnlineLobbyGameHandler(LobbyState lobbyState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICommunityClientHandler.OnQuitFromGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICommunityClientHandler.OnJoinCustomGameResponse(string address, int port, PlayerJoinGameResponseDataFromHost response)
	{
		throw null;
	}
}
