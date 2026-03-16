using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.Core.ViewModelCollection.Selector;

public class SelectorItemVM : ViewModel
{
	private TextObject _s;

	private TextObject _hintObj;

	private string _stringItem;

	private HintViewModel _hint;

	private bool _canBeSelected;

	private bool _isSelected;

	[DataSourceProperty]
	public string StringItem
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
	public bool CanBeSelected
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
	public HintViewModel Hint
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
	public bool IsSelected
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
	public SelectorItemVM(TextObject s)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SelectorItemVM(string s)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SelectorItemVM(TextObject s, TextObject hint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SelectorItemVM(string s, TextObject hint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}
}
