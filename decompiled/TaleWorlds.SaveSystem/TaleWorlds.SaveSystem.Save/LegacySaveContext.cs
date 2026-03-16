using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.SaveSystem.Definition;

namespace TaleWorlds.SaveSystem.Save;

public class LegacySaveContext : ISaveContext
{
	public struct SaveStatistics
	{
		private Dictionary<string, (int, int, int, long)> _typeStatistics;

		private Dictionary<string, (int, int, int, int, long)> _containerStatistics;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SaveStatistics(Dictionary<string, (int, int, int, long)> typeStatistics, Dictionary<string, (int, int, int, int, long)> containerStatistics)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public (int, int, int, long) GetObjectCounts(string key)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public (int, int, int, int, long) GetContainerCounts(string key)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public long GetContainerSize(string key)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<string> GetTypeKeys()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<string> GetContainerKeys()
		{
			throw null;
		}
	}

	private List<object> _childObjects;

	private Dictionary<object, int> _idsOfChildObjects;

	private List<object> _childContainers;

	private Dictionary<object, int> _idsOfChildContainers;

	private List<string> _strings;

	private Dictionary<string, int> _idsOfStrings;

	private List<object> _temporaryCollectedObjects;

	private object _locker;

	private static Dictionary<string, (int, int, int, long)> _typeStatistics;

	private static Dictionary<string, (int, int, int, int, long)> _containerStatistics;

	private Queue<object> _objectsToIterate;

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

	public GameData SaveData
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

	public static bool EnableSaveStatistics
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveStatistics GetStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LegacySaveContext(DefinitionContext definitionContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectContainerObjects(ContainerType containerType, object parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectObjects(object parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddStrings(List<string> texts)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddOrGetStringId(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetObjectId(object target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetContainerId(object target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetStringId(string target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SaveStringTo(SaveEntryFolder stringsFolder, int id, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Save(object target, MetaData metaData, out string errorMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SaveSingleObject(ArchiveConcurrentSerializer headerSerializer, byte[][] objectData, int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SaveSingleContainer(ArchiveConcurrentSerializer headerSerializer, byte[][] containerData, int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetContainerName(Type t)
	{
		throw null;
	}
}
