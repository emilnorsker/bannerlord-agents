using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.DotNet;

internal class ManagedObjectKeeper
{
	public int TimerToReleaseStrongRef;

	public GCHandle gcHandle;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ManagedObjectKeeper()
	{
		throw null;
	}
}
