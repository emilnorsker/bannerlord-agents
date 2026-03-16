using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace Sandbox.View.GameStates;

public class PreloadState : GameState
{
	public readonly string SaveToLoad;

	public readonly int LoadDelayInFrames;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PreloadState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PreloadState(string saveName)
	{
		throw null;
	}
}
