using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.ClassLoadout;

public class AlternativeUsageItemOptionVM : SelectorItemVM
{
	private int _index;

	private SelectorVM<AlternativeUsageItemOptionVM> _parentSelector;

	private string _usageType;

	[DataSourceProperty]
	public string UsageType
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
	public AlternativeUsageItemOptionVM(string usageType, TextObject s, TextObject hint, SelectorVM<AlternativeUsageItemOptionVM> parentSelector, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSelection()
	{
		throw null;
	}
}
