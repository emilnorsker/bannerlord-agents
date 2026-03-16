using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.SaveSystem.Definition;

namespace TaleWorlds.SaveSystem.Load;

public class ObjectLoadData
{
	private short _propertyCount;

	private List<PropertyLoadData> _propertyValues;

	private List<FieldLoadData> _fieldValues;

	private List<MemberLoadData> _memberValues;

	private SaveId _saveId;

	private List<ObjectLoadData> _childStructs;

	private short _childStructCount;

	public int Id
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

	public LoadContext Context
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

	public TypeDefinition TypeDefinition
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
	public object GetDataBySaveId(int localSaveId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetMemberValueBySaveId(int localSaveId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetFieldValueBySaveId(int localSaveId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetPropertyValueBySaveId(int localSaveId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasMember(int localSaveId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ObjectLoadData(LoadContext context, int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ObjectLoadData(ObjectHeaderLoadData headerLoadData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeReaders(SaveEntryFolder saveEntryFolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateStruct()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillCreatedObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Read()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillObject()
	{
		throw null;
	}
}
