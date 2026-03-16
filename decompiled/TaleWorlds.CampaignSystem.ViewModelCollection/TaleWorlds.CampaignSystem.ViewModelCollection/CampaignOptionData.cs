using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection;

public abstract class CampaignOptionData : ICampaignOptionData
{
	private int _priorityIndex;

	private string _identifier;

	private bool _isRelatedToDifficultyPreset;

	private CampaignOptionEnableState _enableState;

	private TextObject _name;

	private TextObject _description;

	private Func<CampaignOptionDisableStatus> _getIsDisabledWithReason;

	protected Func<float> _getValue;

	protected Action<float> _setValue;

	protected Func<float, CampaignOptionsDifficultyPresets> _onGetDifficultyPresetFromValue;

	protected Func<CampaignOptionsDifficultyPresets, float> _onGetValueFromDifficultyPreset;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignOptionData(string identifier, int priorityIndex, CampaignOptionEnableState enableState, Func<float> getValue, Action<float> setValue, Func<CampaignOptionDisableStatus> getIsDisabledWithReason = null, bool isRelatedToDifficultyPreset = false, Func<float, CampaignOptionsDifficultyPresets> onGetDifficultyPresetFromValue = null, Func<CampaignOptionsDifficultyPresets, float> onGetValueFromDifficultyPreset = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetNameOfOption(string optionIdentifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetDescriptionOfOption(string optionIdentifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckIsPlayStation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPriorityIndex()
	{
		throw null;
	}

	public abstract CampaignOptionDataType GetDataType();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsRelatedToDifficultyPreset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetValueFromDifficultyPreset(CampaignOptionsDifficultyPresets preset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignOptionDisableStatus GetIsDisabledWithReason()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetIdentifier()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignOptionEnableState GetEnableState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetDescription()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetValue(float value)
	{
		throw null;
	}
}
