using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

internal class LibraryApplicationInterface
{
	internal static IManaged IManaged;

	internal static ITelemetry ITelemetry;

	internal static ILibrarySizeChecker ILibrarySizeChecker;

	internal static INativeArray INativeArray;

	internal static INativeObjectArray INativeObjectArray;

	internal static INativeStringHelper INativeStringHelper;

	internal static INativeString INativeString;

	private static Dictionary<string, object> _objects;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static T GetObject<T>() where T : class
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void SetObjects(Dictionary<string, object> objects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LibraryApplicationInterface()
	{
		throw null;
	}
}
