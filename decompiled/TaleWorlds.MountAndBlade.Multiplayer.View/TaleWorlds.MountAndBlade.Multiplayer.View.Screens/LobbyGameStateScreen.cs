using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.Multiplayer.View.Screens;

[GameStateScreen(typeof(LobbyGameStateMatchmakerClient))]
[GameStateScreen(typeof(LobbyGameStatePlayerBasedCustomServer))]
public class LobbyGameStateScreen : ScreenBase, IGameStateListener
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public LobbyGameStateScreen(LobbyGameState lobbyGameState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnFinalize()
	{
		throw null;
	}
}
