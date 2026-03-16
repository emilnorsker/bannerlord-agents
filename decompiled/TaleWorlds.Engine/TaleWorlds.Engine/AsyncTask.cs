using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineClass("rglManaged_concurrent_task")]
public sealed class AsyncTask : NativeObject, ITask
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal AsyncTask(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AsyncTask CreateWithDelegate(ManagedDelegate function, bool isBackground)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITask.Invoke()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITask.Wait()
	{
		throw null;
	}
}
