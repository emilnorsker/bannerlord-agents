using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Core;

public class MBFastRandomSelector<T>
{
	public struct IndexEntry
	{
		public ushort Index;

		public ushort Version;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public IndexEntry(ushort index, ushort version)
		{
			throw null;
		}
	}

	public const ushort MinimumCapacity = 32;

	public const ushort MaximumCapacity = ushort.MaxValue;

	private const ushort InitialVersion = 1;

	private const ushort MaximumVersion = ushort.MaxValue;

	private MBReadOnlyList<T> _list;

	private IndexEntry[] _indexArray;

	private ushort _currentVersion;

	public ushort RemainingCount
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
	public MBFastRandomSelector(ushort capacity = 32)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBFastRandomSelector(MBReadOnlyList<T> list, ushort capacity = 32)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(MBReadOnlyList<T> list)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Pack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SelectRandom(out T selection, Predicate<T> conditions = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryExpand()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReallocateIndexArray(ushort capacity)
	{
		throw null;
	}
}
