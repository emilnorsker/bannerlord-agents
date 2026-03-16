using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.ViewModelCollection;

public class ActionCampaignOptionData : CampaignOptionData
{
	private Action _action;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ActionCampaignOptionData(string identifier, int priorityIndex, CampaignOptionEnableState enableState, Action action, Func<CampaignOptionDisableStatus> getIsDisabledWithReason = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignOptionDataType GetDataType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteAction()
	{
		throw null;
	}
}
