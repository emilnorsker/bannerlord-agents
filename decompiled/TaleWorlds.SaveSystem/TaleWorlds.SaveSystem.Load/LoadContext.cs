using System;
using System.Runtime.CompilerServices;
using TaleWorlds.SaveSystem.Definition;

namespace TaleWorlds.SaveSystem.Load;

public class LoadContext
{
	private int _objectCount;

	private int _stringCount;

	private int _containerCount;

	private ObjectHeaderLoadData[] _objectHeaderLoadDatas;

	private ContainerHeaderLoadData[] _containerHeaderLoadDatas;

	private string[] _strings;

	public static bool EnableLoadStatistics
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public object RootObject
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

	public DefinitionContext DefinitionContext
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

	public ISaveDriver Driver
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
	public LoadContext(DefinitionContext definitionContext, ISaveDriver driver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static ObjectLoadData CreateLoadData(LoadData loadData, int i, ObjectHeaderLoadData header)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Load(LoadData loadData, bool loadAsLateInitialize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal LoadCallbackInitializator CreateLoadCallbackInitializator(LoadData loadData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string LoadString(ArchiveDeserializer saveArchive, int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryConvertType(Type sourceType, Type targetType, ref object data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ObjectHeaderLoadData GetObjectWithId(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ContainerHeaderLoadData GetContainerWithId(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetStringWithId(int id)
	{
		throw null;
	}
}
