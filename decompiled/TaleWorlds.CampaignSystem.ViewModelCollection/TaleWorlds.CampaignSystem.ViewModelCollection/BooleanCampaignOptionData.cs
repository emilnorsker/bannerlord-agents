using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.ViewModelCollection;

public class BooleanCampaignOptionData : CampaignOptionData
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public BooleanCampaignOptionData(string identifier, int priorityIndex, CampaignOptionEnableState enableState, Func<float> getValue, Action<float> setValue, Func<CampaignOptionDisableStatus> getIsDisabledWithReason = null, bool isRelatedToDifficultyPreset = false, Func<float, CampaignOptionsDifficultyPresets> onGetDifficultyPresetFromValue = null, Func<CampaignOptionsDifficultyPresets, float> onGetValueFromDifficultyPreset = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignOptionDataType GetDataType()
	{
		throw null;
	}
}
