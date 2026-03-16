using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection;

public class CampaignOptionsControllerVM : ViewModel
{
	private class CampaignOptionComparer : IComparer<CampaignOptionItemVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(CampaignOptionItemVM x, CampaignOptionItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CampaignOptionComparer()
		{
			throw null;
		}
	}

	private const string _difficultyPresetsId = "DifficultyPresets";

	internal const int AutosaveDisableValue = -1;

	private SelectionCampaignOptionData _difficultyPreset;

	private Dictionary<string, CampaignOptionItemVM> _optionItems;

	private bool _isUpdatingPresetData;

	private List<CampaignOptionItemVM> _difficultyPresetRelatedOptions;

	private MBBindingList<CampaignOptionItemVM> _options;

	[DataSourceProperty]
	public MBBindingList<CampaignOptionItemVM> Options
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignOptionsControllerVM(MBBindingList<CampaignOptionItemVM> options)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnOptionChanged(CampaignOptionItemVM optionVM)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePresetData(CampaignOptionItemVM changedOption)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CampaignOptionsDifficultyPresets FindOptionPresetForValue(ICampaignOptionData option)
	{
		throw null;
	}
}
