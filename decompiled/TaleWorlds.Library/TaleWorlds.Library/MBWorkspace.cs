using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class MBWorkspace<T> where T : IMBCollection, new()
{
	private bool _isBeingUsed;

	private T _workspace;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T StartUsingWorkspace()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopUsingWorkspace()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetWorkspace()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBWorkspace()
	{
		throw null;
	}
}
