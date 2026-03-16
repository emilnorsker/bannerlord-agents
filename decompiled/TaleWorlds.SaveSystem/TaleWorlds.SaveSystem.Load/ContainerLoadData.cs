using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.SaveSystem.Definition;

namespace TaleWorlds.SaveSystem.Load;

internal class ContainerLoadData
{
	private SaveId _saveId;

	private int _elementCount;

	private ContainerType _containerType;

	private ElementLoadData[] _keys;

	private ElementLoadData[] _values;

	private Dictionary<int, ObjectLoadData> _childStructs;

	public int Id
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public object Target
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public LoadContext Context
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ContainerDefinition TypeDefinition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ContainerHeaderLoadData ContainerHeaderLoadData
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
	public ContainerLoadData(ContainerHeaderLoadData headerLoadData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private FolderId[] GetChildStructNames(SaveEntryFolder saveEntryFolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeReaders(SaveEntryFolder saveEntryFolder)
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
	private static Assembly GetAssemblyByName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static object GetDefaultObject(SaveId saveId, LoadContext context, bool getValueId = false)
	{
		throw null;
	}
}
