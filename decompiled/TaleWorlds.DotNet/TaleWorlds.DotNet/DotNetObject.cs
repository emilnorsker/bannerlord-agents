using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.DotNet;

public class DotNetObject
{
	private struct DotNetObjectReferenceCounter
	{
		internal int ReferenceCount;

		internal long CreationFrame;

		internal DotNetObject DotNetObject;
	}

	private class DotNetObjectKeeper
	{
		internal DotNetObject DotNetObject;

		internal int TimerToReleaseStrongRef;

		internal GCHandle gcHandle;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DotNetObjectKeeper()
		{
			throw null;
		}
	}

	private static readonly object Locker;

	private const int DotnetObjectFirstReferencesTickCount = 200;

	private static long _frameNo;

	private static Dictionary<int, DotNetObjectKeeper> DotnetKeepReferences;

	private static readonly Dictionary<int, DotNetObjectReferenceCounter> DotnetObjectReferences;

	private static int _totalCreatedObjectCount;

	private readonly int _objectId;

	private static int _numberOfAliveDotNetObjects;

	internal static int NumberOfAliveDotNetObjects
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DotNetObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected DotNetObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	~DotNetObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static int GetAliveDotNetObjectCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void IncreaseReferenceCount(int dotnetObjectId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void DecreaseReferenceCount(int dotnetObjectId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static DotNetObject GetManagedObjectWithId(int dotnetObjectId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetManagedId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static string GetAliveDotNetObjectNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HandleDotNetObjects()
	{
		throw null;
	}
}
