using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem;

public class FileDriver : ISaveDriver
{
	public const string SaveDirectoryName = "Game Saves";

	public static PlatformDirectoryPath SavePath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PlatformFilePath GetSaveFilePath(string fileName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Task<SaveResultWithMessage> Save(string saveName, int version, MetaData metaData, GameData gameData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaData LoadMetaData(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LoadData Load(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveGameFileInfo[] GetSaveGameFileInfos()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ApplicationVersion GetApplicationVersionOfMetaData(MetaData metaData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string[] GetSaveGameFileNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Delete(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSaveGameFileExists(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsWorkingAsync()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FileDriver()
	{
		throw null;
	}
}
