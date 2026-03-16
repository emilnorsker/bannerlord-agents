using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem.Definition;
using TaleWorlds.SaveSystem.Load;
using TaleWorlds.SaveSystem.Save;

namespace TaleWorlds.SaveSystem;

public static class SaveManager
{
	public const string SaveFileExtension = "sav";

	private const int CurrentVersion = 1;

	private static DefinitionContext _definitionContext;

	internal static ApplicationVersion OperatingVersion;

	private static bool _isLoading;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeGlobalDefinitionContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<Type> CheckSaveableTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveOutput Save(object target, MetaData metaData, string saveName, ISaveDriver driver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ShouldResolveConflicts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MetaData LoadMetaData(string saveName, ISaveDriver driver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LoadResult Load(string saveName, ISaveDriver driver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LoadResult Load(string saveName, ISaveDriver driver, bool loadAsLateInitialize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SaveManager()
	{
		throw null;
	}
}
