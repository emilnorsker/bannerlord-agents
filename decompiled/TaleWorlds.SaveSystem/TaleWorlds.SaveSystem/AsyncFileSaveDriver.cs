using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem;

public class AsyncFileSaveDriver : ISaveDriver
{
	private FileDriver _saveDriver;

	private Task _currentNonSaveTask;

	private Task<SaveResultWithMessage> _currentSaveTask;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AsyncFileSaveDriver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WaitPreviousTask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<SaveResultWithMessage> ISaveDriver.Save(string saveName, int version, MetaData metaData, GameData gameData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	SaveGameFileInfo[] ISaveDriver.GetSaveGameFileInfos()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	string[] ISaveDriver.GetSaveGameFileNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	MetaData ISaveDriver.LoadMetaData(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	LoadData ISaveDriver.Load(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool ISaveDriver.Delete(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool ISaveDriver.IsSaveGameFileExists(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool ISaveDriver.IsWorkingAsync()
	{
		throw null;
	}
}
