using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.ViewModelCollection;

public class NumericCampaignOptionData : CampaignOptionData
{
	public float MinValue
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

	public float MaxValue
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

	public bool IsDiscrete
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
	public NumericCampaignOptionData(string identifier, int priorityIndex, CampaignOptionEnableState enableState, Func<float> getValue, Action<float> setValue, float minValue, float maxValue, bool isDiscrete, Func<CampaignOptionDisableStatus> getIsDisabledWithReason = null, bool isRelatedToDifficultyPreset = false, Func<float, CampaignOptionsDifficultyPresets> onGetDifficultyPresetFromValue = null, Func<CampaignOptionsDifficultyPresets, float> onGetValueFromDifficultyPreset = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignOptionDataType GetDataType()
	{
		throw null;
	}
}
