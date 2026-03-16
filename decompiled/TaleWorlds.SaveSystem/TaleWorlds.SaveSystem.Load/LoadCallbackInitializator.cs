using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem.Load;

internal class LoadCallbackInitializator
{
	private ObjectHeaderLoadData[] _objectHeaderLoadDatas;

	private int _objectCount;

	private LoadData _loadData;

	private Dictionary<int, ObjectLoadData> _objectLoadDatas;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LoadCallbackInitializator(LoadData loadData, ObjectHeaderLoadData[] objectHeaderLoadDatas, int objectCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AfterInitializeObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ObjectLoadData GetObjectLoadData(ObjectHeaderLoadData objectHeaderLoadData, int i)
	{
		throw null;
	}
}
