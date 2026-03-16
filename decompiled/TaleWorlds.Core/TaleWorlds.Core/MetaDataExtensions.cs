using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.Core;

public static class MetaDataExtensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static DateTime GetCreationTime(this MetaData metaData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string[] GetModules(this MetaData metaData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ApplicationVersion GetModuleVersion(this MetaData metaData, string moduleName)
	{
		throw null;
	}
}
