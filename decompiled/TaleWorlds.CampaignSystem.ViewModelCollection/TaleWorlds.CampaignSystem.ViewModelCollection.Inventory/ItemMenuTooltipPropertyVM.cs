using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;

public class ItemMenuTooltipPropertyVM : TooltipProperty
{
	private HintViewModel _propertyHint;

	[DataSourceProperty]
	public HintViewModel PropertyHint
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
	public ItemMenuTooltipPropertyVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemMenuTooltipPropertyVM(string definition, string value, int textHeight, bool onlyShowWhenExtended = false, HintViewModel propertyHint = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemMenuTooltipPropertyVM(string definition, Func<string> _valueFunc, int textHeight, bool onlyShowWhenExtended = false, HintViewModel propertyHint = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemMenuTooltipPropertyVM(Func<string> _definitionFunc, Func<string> _valueFunc, int textHeight, bool onlyShowWhenExtended = false, HintViewModel propertyHint = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemMenuTooltipPropertyVM(Func<string> _definitionFunc, Func<string> _valueFunc, object[] valueArgs, int textHeight, bool onlyShowWhenExtended = false, HintViewModel propertyHint = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemMenuTooltipPropertyVM(string definition, string value, int textHeight, Color color, bool onlyShowWhenExtended = false, HintViewModel propertyHint = null, TooltipPropertyFlags propertyFlags = TooltipPropertyFlags.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemMenuTooltipPropertyVM(string definition, Func<string> _valueFunc, int textHeight, Color color, bool onlyShowWhenExtended = false, HintViewModel propertyHint = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemMenuTooltipPropertyVM(Func<string> _definitionFunc, Func<string> _valueFunc, int textHeight, Color color, bool onlyShowWhenExtended = false, HintViewModel propertyHint = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemMenuTooltipPropertyVM(TooltipProperty property, HintViewModel propertyHint = null)
	{
		throw null;
	}
}
