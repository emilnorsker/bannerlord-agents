using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

internal class ManagedObjectOwner
{
	private const int PooledManagedObjectOwnerCount = 8192;

	private static readonly List<ManagedObjectOwner> _pool;

	private static readonly List<WeakReference> _managedObjectOwnerWeakReferences;

	private static readonly Dictionary<int, WeakReference> _managedObjectOwners;

	private static readonly HashSet<ManagedObjectOwner> _managedObjectOwnerReferences;

	private static int _lastId;

	private static readonly List<ManagedObjectOwner> _lastframedeletedManagedObjects;

	private static int _numberOfAliveManagedObjects;

	private static readonly List<ManagedObjectOwner> _lastframedeletedManagedObjectBuffer;

	private Type _typeInfo;

	private int _nativeId;

	private UIntPtr _ptr;

	private readonly WeakReference _managedObject;

	private readonly WeakReference _managedObjectLongReference;

	internal static int NumberOfAliveManagedObjects
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal int NativeId
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
	static ManagedObjectOwner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GarbageCollect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LogFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PreFinalizeManagedObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static ManagedObject GetManagedObjectWithId(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ManagedObjectGarbageCollected(ManagedObjectOwner owner, ManagedObject managedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static ManagedObjectOwner CreateManagedObjectOwner(UIntPtr ptr, ManagedObject managedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string GetAliveManagedObjectNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string GetAliveManagedObjectCreationCallstacks(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ManagedObjectOwner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Construct(UIntPtr ptr, ManagedObject managedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Destruct()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	~ManagedObjectOwner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ManagedObject TryGetManagedObject()
	{
		throw null;
	}
}
