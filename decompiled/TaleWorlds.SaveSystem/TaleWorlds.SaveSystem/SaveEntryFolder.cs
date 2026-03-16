using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem;

public class SaveEntryFolder
{
	private Dictionary<FolderId, SaveEntryFolder> _saveEntryFolders;

	private Dictionary<EntryId, SaveEntry> _entries;

	public int GlobalId
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

	public int ParentGlobalId
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

	public FolderId FolderId
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

	public Dictionary<EntryId, SaveEntry>.ValueCollection ChildEntries
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Dictionary<FolderId, SaveEntryFolder>.ValueCollection ChildFolders
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<SaveEntry> GetAllEntries()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveEntryFolder CreateRootFolder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveEntryFolder(SaveEntryFolder parent, int globalId, FolderId folderId, int entryCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveEntryFolder(int parentGlobalId, int globalId, FolderId folderId, int entryCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEntry(SaveEntry saveEntry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveEntry GetEntry(EntryId entryId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddChildFolderEntry(SaveEntryFolder saveEntryFolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal SaveEntryFolder GetChildFolder(FolderId folderId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveEntry CreateEntry(EntryId entryId)
	{
		throw null;
	}
}
