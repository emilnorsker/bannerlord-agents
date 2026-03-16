using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public static class ManagedDllFolder
{
	private static string _overridenFolder;

	public static string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OverrideManagedDllFolder(string overridenFolder)
	{
		throw null;
	}
}
