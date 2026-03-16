using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem;

public class SaveHandler
{
	private readonly struct SaveArgs
	{
		public enum SaveMode
		{
			SaveAs,
			QuickSave,
			AutoSave
		}

		public readonly SaveMode Mode;

		public readonly string Name;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SaveArgs(SaveMode mode, string name)
		{
			throw null;
		}
	}

	private enum SaveSteps
	{
		PreSave = 0,
		Saving = 2,
		AwaitingCompletion = 3
	}

	private SaveSteps _saveStep;

	private static readonly CultureInfo _invariantCulture;

	private Queue<SaveArgs> SaveArgsQueue;

	private DateTime _lastAutoSaveTime;

	public IMainHeroVisualSupplier MainHeroVisualSupplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public bool IsSaving
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string IronmanModSaveName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool _isAutoSaveEnabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private double _autoSavePriorityTimeLimit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int AutoSaveInterval
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void QuickSaveCurrentGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveAs(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryAutoSave(bool isPriority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CampaignTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SaveTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSaveCompleted((SaveResult, string) result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SignalAutoSave()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSaveStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSaveEnded(bool isSaveSuccessful, string newSaveGameName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSaveArgs(SaveArgs.SaveMode saveType, string saveName = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceAutoSave()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignSaveMetaDataArgs GetSaveMetaData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SaveHandler()
	{
		throw null;
	}
}
