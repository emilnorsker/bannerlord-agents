using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public static class AssemblyLoader
{
	private static List<Assembly> _loadedAssemblies;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static AssemblyLoader()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Assembly LoadFrom(string assemblyFile, bool show_error = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
	{
		throw null;
	}
}
