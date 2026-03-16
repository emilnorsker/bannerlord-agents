using System.Runtime.CompilerServices;

namespace SandBox;

public abstract class GameplayCheatItem : GameplayCheatBase
{
	public abstract void ExecuteCheat();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GameplayCheatItem()
	{
		throw null;
	}
}
