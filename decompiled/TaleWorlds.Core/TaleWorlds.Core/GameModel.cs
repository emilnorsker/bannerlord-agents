using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public abstract class GameModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GameModel()
	{
		throw null;
	}
}
