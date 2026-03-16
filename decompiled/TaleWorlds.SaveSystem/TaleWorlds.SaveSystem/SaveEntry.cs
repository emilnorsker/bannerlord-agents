using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem;

public class SaveEntry
{
	private byte[] _data;

	public byte[] Data
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public EntryId Id
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

	public int FolderId
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
	public SaveEntry()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveEntry CreateFrom(int entryFolderId, EntryId entryId, byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveEntry CreateNew(SaveEntryFolder parentFolder, EntryId entryId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BinaryReader GetBinaryReader()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillFrom(BinaryWriter writer)
	{
		throw null;
	}
}
