using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.DotNet;

public abstract class NativeObject
{
	private class NativeObjectKeeper
	{
		internal int TimerToReleaseStrongRef;

		internal GCHandle gcHandle;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NativeObjectKeeper()
		{
			throw null;
		}
	}

	private const int NativeObjectFirstReferencesTickCount = 10;

	private static List<EngineClassTypeDefinition> _typeDefinitions;

	private static List<ConstructorInfo> _constructors;

	private static List<NativeObjectKeeper> _nativeObjectKeepReferences;

	private static volatile int _numberOfAliveNativeObjects;

	private bool _manualInvalidated;

	public UIntPtr Pointer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected NativeObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Construct(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	~NativeObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ManualInvalidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static NativeObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HandleNativeObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static int GetAliveNativeObjectCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static string GetAliveNativeObjectNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetTypeDefinitionId(string typeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool DoesNativeObjectDefinedAssembly(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Obsolete]
	protected void AddUnmanagedMemoryPressure(int size)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static NativeObject CreateNativeObjectWrapper(NativeObjectPointer nativeObjectPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static T CreateNativeObjectWrapper<T>(NativeObjectPointer nativeObjectPointer) where T : NativeObject
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(NativeObject a, NativeObject b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(NativeObject a, NativeObject b)
	{
		throw null;
	}
}
