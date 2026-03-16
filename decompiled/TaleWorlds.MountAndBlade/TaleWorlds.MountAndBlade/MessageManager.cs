using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public static class MessageManager
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DisplayMessage(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DisplayMessage(string message, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	public static void DisplayDebugMessage(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DisplayMultilineMessage(string message, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EraseMessageLines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetMessageManager(MessageManagerBase messageManager)
	{
		throw null;
	}
}
