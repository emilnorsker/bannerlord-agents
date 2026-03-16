using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.DotNet;

public abstract class ManagedObject
{
	private class ManagedObjectKeeper
	{
		internal int TimerToReleaseStrongRef;

		internal GCHandle gcHandle;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ManagedObjectKeeper()
		{
			throw null;
		}
	}

	private const int ManagedObjectFirstReferencesTickCount = 200;

	private static Dictionary<int, ManagedObjectKeeper> _managedObjectKeepReferences;

	private static int _totalCreatedObjectCount;

	private ManagedObjectOwner _managedObjectOwner;

	private int forcedMemory;

	internal ManagedObjectOwner ManagedObjectOwner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal UIntPtr Pointer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void FinalizeManagedObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddUnmanagedMemoryPressure(int size)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ManagedObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ManagedObject(UIntPtr ptr, bool createManagedObjectOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetOwnerManagedObject(ManagedObjectOwner owner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	~ManagedObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HandleManagedObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ManagedObjectFetched(ManagedObject managedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static int GetAliveManagedObjectCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static string GetAliveManagedObjectNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static string GetCreationCallstack(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetManagedId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal string GetClassOfObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}
}
