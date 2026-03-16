using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SandBox;

public abstract class GameplayCheatGroup : GameplayCheatBase
{
	public abstract IEnumerable<GameplayCheatBase> GetCheats();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GameplayCheatGroup()
	{
		throw null;
	}
}
