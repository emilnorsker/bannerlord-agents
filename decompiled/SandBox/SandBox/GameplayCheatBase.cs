using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace SandBox;

public abstract class GameplayCheatBase
{
	public abstract TextObject GetName();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GameplayCheatBase()
	{
		throw null;
	}
}
