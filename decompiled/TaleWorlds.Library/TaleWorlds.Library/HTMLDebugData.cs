using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Library;

internal class HTMLDebugData
{
	private string _log;

	private string _currentTime;

	internal HTMLDebugCategory Info
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	private string Color
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private ConsoleColor ConsoleColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal HTMLDebugData(string log, HTMLDebugCategory info)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Print(FileStream fileStream, Encoding encoding, bool writeToConsole = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string TableCell(string innerText, string color)
	{
		throw null;
	}
}
