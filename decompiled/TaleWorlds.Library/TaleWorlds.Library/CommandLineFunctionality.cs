using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public static class CommandLineFunctionality
{
	private class CommandLineFunction
	{
		public Func<List<string>, string> CommandLineFunc;

		public List<CommandLineFunction> Children;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CommandLineFunction(Func<List<string>, string> commandlinefunc)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string Call(List<string> objects)
		{
			throw null;
		}
	}

	public class CommandLineArgumentFunction : Attribute
	{
		public string Name;

		public string GroupName;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CommandLineArgumentFunction(string name, string groupname)
		{
			throw null;
		}
	}

	private static Dictionary<string, CommandLineFunction> AllFunctions;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckAssemblyReferencesThis(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<string> CollectCommandLineFunctions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HasFunctionForCommand(string command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string CallFunction(string concatName, string concatArguments, out bool found)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string CallFunction(string concatName, List<string> argList, out bool found)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CommandLineFunctionality()
	{
		throw null;
	}
}
