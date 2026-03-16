using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

internal class EngineManaged : IManagedComponent
{
	private static EngineManaged _instance;

	private static Dictionary<int, IntPtr> _engineApiPointers;

	private static ICallbackManager _callbackManager;

	private static Delegate PassManagedEngineCallbackMethodPointersMono;

	public string ManagedCallbacksDll
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EngineManaged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IManagedComponent.OnStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IManagedComponent.OnCustomCallbackMethodPassed(string name, Delegate method)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IManagedComponent.OnApplicationTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void EngineApiMethodInterfaceInitializer(int id, IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void CheckSharedStructureSizes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void FillEngineApiPointers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void PassManagedEngineCallbackMethodPointers(Delegate methodDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static EngineManaged()
	{
		throw null;
	}
}
