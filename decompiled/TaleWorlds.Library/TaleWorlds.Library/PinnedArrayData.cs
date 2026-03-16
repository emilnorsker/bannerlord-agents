using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.Library;

public struct PinnedArrayData<T>
{
	private static IntPtr _unmanagedCache;

	private GCHandle _handle;

	public bool Pinned
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

	public IntPtr Pointer
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

	public T[] Array
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

	public T[,] Array2D
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

	public GCHandle Handle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PinnedArrayData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PinnedArrayData(T[] array, bool manualPinning = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PinnedArrayData(T[,] array, bool manualPinning = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckIfTypeRequiresManualPinning(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		throw null;
	}
}
