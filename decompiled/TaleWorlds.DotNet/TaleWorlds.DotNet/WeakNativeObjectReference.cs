using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

public sealed class WeakNativeObjectReference
{
	private readonly UIntPtr _pointer;

	private readonly Func<NativeObject> _constructor;

	private readonly WeakReference _weakReferenceCache;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakNativeObjectReference(NativeObject nativeObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ManualInvalidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NativeObject GetNativeObject()
	{
		throw null;
	}
}
public sealed class WeakNativeObjectReference<T> where T : NativeObject
{
	private readonly UIntPtr _pointer;

	private WeakReference<T> _weakReferenceCache;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakNativeObjectReference(T nativeObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ManualInvalidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NativeObject GetNativeObject()
	{
		throw null;
	}
}
