using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

public static class CrashInformationCollector
{
	public class CrashInformation
	{
		public readonly string Id;

		public readonly MBReadOnlyList<(string, string)> Lines;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CrashInformation(string id, MBReadOnlyList<(string, string)> lines)
		{
			throw null;
		}
	}

	[AttributeUsage(AttributeTargets.Method)]
	public class CrashInformationProvider : Attribute
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public CrashInformationProvider()
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	public static string CollectInformation()
	{
		throw null;
	}
}
