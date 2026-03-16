using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.MountAndBlade;

public class CoreManaged : IManagedComponent
{
	private static CoreManaged _instance;

	private static ICallbackManager _callbackManager;

	private static readonly Dictionary<int, IntPtr> _engineApiPointers;

	private static Delegate _passManagedCoreCallbackMethodPointersMono;

	public string ManagedCallbacksDll
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CoreManaged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public static void Start()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IManagedComponent.OnStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<string, Type> CollectModuleAssemblyTypes(Assembly moduleAssembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void OnLoadCommonFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IManagedComponent.OnCustomCallbackMethodPassed(string name, Delegate method)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void Finalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IManagedComponent.OnApplicationTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void CheckSharedStructureSizes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void EngineApiMethodInterfaceInitializer(int id, IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void FillEngineApiPointers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void PassManagedCoreCallbackMethodPointers(Delegate methodDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CoreManaged()
	{
		throw null;
	}
}
