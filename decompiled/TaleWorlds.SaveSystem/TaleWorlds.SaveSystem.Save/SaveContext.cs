using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem.Definition;

namespace TaleWorlds.SaveSystem.Save;

public class SaveContext : ISaveContext
{
	private struct SaveDataSizeRecord
	{
		public int HeaderSize;

		public int StringSize;

		public int ObjectSize;

		public int ContainerSize;
	}

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

	private static SaveDataSizeRecord SizeRecord;

	private List<object> _childObjects;

	private Dictionary<object, int> _idsOfChildObjects;

	private List<object> _childContainers;

	private Dictionary<object, int> _idsOfChildContainers;

	private List<string> _strings;

	private Dictionary<string, int> _idsOfStrings;

	private List<object> _temporaryCollectedObjects;

	private ObjectSaveData[] _objectSaveDataList;

	private ContainerSaveData[] _containerSaveDataList;

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
	public SaveContext(DefinitionContext definitionContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SaveDataSizeRecord CollectSaveDatas()
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
	private static void SaveStringTo(BinaryWriter stringWriter, int id, string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetStringSizeInBytes(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetStringSizeWithOverhead(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Save(object target, MetaData metaData, out string errorMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[][] WriteObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[][] WriteContainers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static byte[] WriteHeaders(ObjectSaveData[] objects, ContainerSaveData[] containers, int headerSize, int stringCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static byte[] WriteAllStrings(List<string> strings, int stringSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void WriteConfigEntry(BinaryWriter headerWriter, int objects, int strings, int containers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void WriteStringsEntry(BinaryWriter headerWriter, int strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetConfigEntrySize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetStringFolderSize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectSaveDataForObject(int id, ref SaveDataSizeRecord headerSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectSaveDataForContainer(int id, ref SaveDataSizeRecord headerSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SaveSingleObject(byte[][] objectData, int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SaveSingleContainer(byte[][] containerData, int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetContainerName(Type t)
	{
		throw null;
	}
}
