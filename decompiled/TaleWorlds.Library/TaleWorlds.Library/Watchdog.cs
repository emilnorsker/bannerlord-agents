using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class Watchdog
{
	public string WatchdogMutexName;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Watchdog(bool use_coreclr, string dumpdir)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetDumpDirectory(string Path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DetachAndClose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LogProperty(string FileName, string GroupName, string Key, string Value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool Attached()
	{
		throw null;
	}
}
