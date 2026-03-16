using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public abstract class AsyncRunner
{
	public abstract void Run();

	public abstract void SyncTick();

	public abstract void OnRemove();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected AsyncRunner()
	{
		throw null;
	}
}
