using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;
using TaleWorlds.SaveSystem.Load;

namespace TaleWorlds.Core;

public static class MBSaveLoad
{
	private const int MaxNumberOfAutoSaveFiles = 3;

	private static ISaveDriver _saveDriver;

	private static int AutoSaveIndex;

	private static string DefaultSaveGamePrefix;

	private static string AutoSaveNamePrefix;

	private static GameTextManager _textProvider;

	private static bool DoNotShowSaveErrorAgain;

	public static char ModuleVersionSeperator
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static char ModuleCodeSeperator
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ApplicationVersion LastLoadedGameVersion
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

	public static ApplicationVersion CurrentVersion
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public static bool IsUpdatingGameVersion
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static int NumberOfCurrentSaves
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

	public static string ActiveSaveSlotName
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
	private static string GetAutoSaveName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void IncrementAutoSaveIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void InitializeAutoSaveIndex(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetSaveDriver(ISaveDriver saveDriver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveGameFileInfo[] GetSaveFiles(Func<SaveGameFileInfo, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsSaveGameFileExists(string saveFileName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string[] GetSaveFileNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LoadResult LoadSaveGameData(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveGameFileInfo GetSaveFileWithName(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void QuickSaveCurrentGame(CampaignSaveMetaDataArgs campaignMetaData, Action<(SaveResult, string)> onSaveCompleted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AutoSaveCurrentGame(CampaignSaveMetaDataArgs campaignMetaData, Action<(SaveResult, string)> onSaveCompleted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SaveAsCurrentGame(CampaignSaveMetaDataArgs campaignMetaData, string saveName, Action<(SaveResult, string)> onSaveCompleted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OverwriteSaveAux(CampaignSaveMetaDataArgs campaignMetaData, string saveName, Action<(SaveResult, string)> onSaveCompleted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DeleteSaveGame(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize(GameTextManager localizedTextProvider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnNewGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnGameDestroy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnStartGame(LoadResult loadResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsSaveFileNameReserved(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetNextAvailableSaveName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OverwriteSaveFile(MetaData metaData, string name, Action<SaveResult> onSaveCompleted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ShowErrorFromResult(SaveResult result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SaveGame(string saveName, MetaData metaData, Action<SaveResult> onSaveCompleted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static MetaData GetSaveMetaData(CampaignSaveMetaDataArgs data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetMaxNumberOfSaves()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsMaxNumberOfSavesReached()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MBSaveLoad()
	{
		throw null;
	}
}
