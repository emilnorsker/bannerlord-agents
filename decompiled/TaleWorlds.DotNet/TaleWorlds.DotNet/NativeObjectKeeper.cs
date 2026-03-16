using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.DotNet;

internal class NativeObjectKeeper
{
	public int TimerToReleaseStrongRef;

	public GCHandle gcHandle;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NativeObjectKeeper()
	{
		throw null;
	}
}
