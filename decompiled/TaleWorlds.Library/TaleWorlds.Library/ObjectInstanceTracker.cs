using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class ObjectInstanceTracker
{
	private static Dictionary<string, List<WeakReference>> TrackedInstances;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RegisterTrackedInstance(string name, WeakReference instance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckBlacklistedTypeCounts(Dictionary<string, int> typeNameCounts, ref string outputLog)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ObjectInstanceTracker()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ObjectInstanceTracker()
	{
		throw null;
	}
}
