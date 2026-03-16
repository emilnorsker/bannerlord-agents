using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

public static class CallbackDebugTool
{
	private class CallbackLog
	{
		public long CallCount;

		public string FuncName;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CallbackLog()
		{
			throw null;
		}
	}

	private static Dictionary<string, CallbackLog> Logs;

	private static ulong FrameCount;

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG_MORE")]
	public static void AddLog([CallerMemberName] string memberName = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG_MORE")]
	public static void FrameEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG_MORE")]
	public static void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ShowResults()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CallbackDebugTool()
	{
		throw null;
	}
}
