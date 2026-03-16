using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem;

internal class ArchiveSerializer : IArchiveContext
{
	private BinaryWriter _writer;

	private int _entryCount;

	private int _folderCount;

	private List<SaveEntryFolder> _folders;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArchiveSerializer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SerializeEntry(SaveEntry entry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SerializeFolder(SaveEntryFolder folder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveEntryFolder CreateFolder(SaveEntryFolder parentFolder, FolderId folderId, int entryCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] FinalizeAndGetBinaryData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] GetBinaryDataDebug()
	{
		throw null;
	}
}
