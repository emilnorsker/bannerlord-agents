using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Starter.Library;

public class Program
{
	private delegate void ControllerDelegate(Delegate currentDomainInitializer);

	private delegate void InitializerDelegate(Delegate argument);

	private delegate void StartMethodDelegate(string args);

	private static string[] _args;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void WriteErrorLog(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int Starter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[STAThread]
	public static int Main(string[] args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Program()
	{
		throw null;
	}
}
