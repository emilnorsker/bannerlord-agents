using System.Reflection;
using System.Runtime.CompilerServices;

namespace TaleWorlds.ModuleManager;

public static class Extensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Assembly[] GetActiveReferencingGameAssembliesSafe(this Assembly assembly)
	{
		throw null;
	}
}
