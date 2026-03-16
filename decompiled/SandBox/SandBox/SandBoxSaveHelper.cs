using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;
using TaleWorlds.SaveSystem.Load;

namespace SandBox;

public static class SandBoxSaveHelper
{
	public enum SaveHelperState
	{
		Start,
		Inquiry,
		LoadGame
	}

	public readonly struct ModuleCheckResult
	{
		public readonly string ModuleId;

		public readonly ModuleCheckResultType Type;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ModuleCheckResult(string moduleId, ModuleCheckResultType type)
		{
			throw null;
		}
	}

	private static readonly ApplicationVersion SaveResetVersion;

	private static readonly TextObject _moduleMismatchInquiryTitle;

	private static readonly TextObject _errorTitle;

	private static readonly TextObject _saveLoadingProblemText;

	private static readonly TextObject _saveResetVersionProblemText;

	private static bool _isInquiryActive;

	public static event Action<SaveHelperState> OnStateChange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TryLoadSave(SaveGameFileInfo saveInfo, Action<LoadResult> onStartGame, Action onCancel = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBReadOnlyList<ModuleCheckResult> CheckMetaDataCompatibilityErrors(MetaData fileMetaData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetIsDisabledWithReason(SaveGameFileInfo saveGameFileInfo, out TextObject reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetModuleNameFromModuleId(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void LoadGameAction(SaveGameFileInfo saveInfo, Action<LoadResult> onStartGame, Action onCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SandBoxSaveHelper()
	{
		throw null;
	}
}
