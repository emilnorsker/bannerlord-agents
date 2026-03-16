using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade;

public abstract class MultiplayerGameMode
{
	public string Name
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
	protected MultiplayerGameMode(string name)
	{
		throw null;
	}

	public abstract void JoinCustomGame(JoinGameData joinGameData);

	public abstract void StartMultiplayerGame(string scene);
}
