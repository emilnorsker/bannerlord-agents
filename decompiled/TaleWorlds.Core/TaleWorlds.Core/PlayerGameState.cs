using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public abstract class PlayerGameState : GameState
{
	private VirtualPlayer _peer;

	public VirtualPlayer Peer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected PlayerGameState()
	{
		throw null;
	}
}
