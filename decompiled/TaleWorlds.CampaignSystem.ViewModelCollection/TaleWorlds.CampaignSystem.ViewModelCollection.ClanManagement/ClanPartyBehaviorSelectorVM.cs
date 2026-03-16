using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;

public class ClanPartyBehaviorSelectorVM : SelectorVM<SelectorItemVM>
{
	private bool _canUseActions;

	private HintViewModel _actionsDisabledHint;

	[DataSourceProperty]
	public bool CanUseActions
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

	[DataSourceProperty]
	public HintViewModel ActionsDisabledHint
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
	public ClanPartyBehaviorSelectorVM(int selectedIndex, Action<SelectorVM<SelectorItemVM>> onChange)
	{
		throw null;
	}
}
