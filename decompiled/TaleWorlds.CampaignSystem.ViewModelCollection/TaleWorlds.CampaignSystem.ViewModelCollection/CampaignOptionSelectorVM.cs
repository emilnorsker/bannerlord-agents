using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection;

public class CampaignOptionSelectorVM : SelectorVM<SelectorItemVM>
{
	private bool _isEnabled;

	[DataSourceProperty]
	public bool IsEnabled
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
	public CampaignOptionSelectorVM(int selectedIndex, Action<SelectorVM<SelectorItemVM>> onChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignOptionSelectorVM(IEnumerable<string> list, int selectedIndex, Action<SelectorVM<SelectorItemVM>> onChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignOptionSelectorVM(IEnumerable<TextObject> list, int selectedIndex, Action<SelectorVM<SelectorItemVM>> onChange)
	{
		throw null;
	}
}
