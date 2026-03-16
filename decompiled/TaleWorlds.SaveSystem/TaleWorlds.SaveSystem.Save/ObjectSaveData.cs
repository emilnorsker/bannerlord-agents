using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem.Definition;

namespace TaleWorlds.SaveSystem.Save;

internal class ObjectSaveData
{
	private Dictionary<PropertyInfo, PropertySaveData> _propertyValues;

	private Dictionary<FieldInfo, FieldSaveData> _fieldValues;

	private List<MemberSaveData> _stringMembers;

	private TypeDefinition _typeDefinition;

	private Dictionary<MemberDefinition, ObjectSaveData> _childStructs;

	public int ObjectId
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

	public ISaveContext Context
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

	public object Target
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

	public Type Type
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

	public bool IsClass
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

	internal int PropertyCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal int FieldCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal int ChildCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetFolderCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ObjectSaveData(ISaveContext context, int objectId, object target, bool isClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetEntryCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CollectMembers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CollectStringsInto(List<string> collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CollectStrings()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CollectStructs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveHeaderTo(SaveEntryFolder parentFolder, IArchiveContext archiveContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveHeaderFolderTo(BinaryWriter headerWriter, int folderId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveHeaderDataTo(BinaryWriter headerWriter, int folderId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetHeaderDataSize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetHeaderSize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetDataSize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveDataFolder(BinaryWriter writer, int parentFolderId, ref int folderId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveTo(BinaryWriter writer, ref int folderId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveTo(SaveEntryFolder parentFolder, IArchiveContext archiveContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WriteHeader(BinaryWriter writer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WriteMemberEntry(BinaryWriter writer, VariableSaveData data, int parentFolderId, int id, SaveEntryExtension extension)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetMemberEntrySize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GetChildObjectFrom(ISaveContext context, object target, MemberDefinition memberDefinition, List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<object> GetChildObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetChildObjects(ISaveContext context, TypeDefinition typeDefinition, object target, List<object> collectedObjects)
	{
		throw null;
	}
}
