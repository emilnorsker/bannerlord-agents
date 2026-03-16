using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem;

internal class ArchiveConcurrentSerializer : IArchiveContext
{
	private int _entryCount;

	private int _folderCount;

	private object _locker;

	private Dictionary<int, BinaryWriter> _writers;

	private ConcurrentBag<SaveEntryFolder> _folders;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArchiveConcurrentSerializer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SerializeFolderConcurrent(SaveEntryFolder folder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveEntryFolder CreateFolder(SaveEntryFolder parentFolder, FolderId folderId, int entryCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SerializeEntryConcurrent(SaveEntry entry, BinaryWriter writer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] FinalizeAndGetBinaryDataConcurrent()
	{
		throw null;
	}
}
