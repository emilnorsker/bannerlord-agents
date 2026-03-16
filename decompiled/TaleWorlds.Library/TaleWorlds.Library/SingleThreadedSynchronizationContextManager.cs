using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public static class SingleThreadedSynchronizationContextManager
{
	private static SingleThreadedSynchronizationContext _synchronizationContext;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Tick()
	{
		throw null;
	}
}
