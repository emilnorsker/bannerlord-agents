using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace ManagedCallbacks;

public class CallbackManager : ICallbackManager
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Delegate[] GetDelegates()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Dictionary<string, object> GetScriptingInterfaceObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFunctionPointer(int id, IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckSharedStructureSizes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CallbackManager()
	{
		throw null;
	}
}
