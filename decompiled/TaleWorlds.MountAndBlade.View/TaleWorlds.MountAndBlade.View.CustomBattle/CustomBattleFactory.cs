using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.View.CustomBattle;

public static class CustomBattleFactory
{
	private static readonly List<Type> _providers;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RegisterProvider<T>() where T : ICustomBattleProvider, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartCustomBattleWithProvider<T>() where T : ICustomBattleProvider, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartCustomBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetProviderCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<ICustomBattleProvider> CollectProviders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ICustomBattleProvider CollectNextProvider(Type currentProviderType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CustomBattleFactory()
	{
		throw null;
	}
}
