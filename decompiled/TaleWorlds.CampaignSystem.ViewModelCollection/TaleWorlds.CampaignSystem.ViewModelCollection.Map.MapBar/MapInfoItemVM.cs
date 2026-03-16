using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Library.Information;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Map.MapBar;

public class MapInfoItemVM : ViewModel
{
	public readonly string ItemId;

	private readonly BasicTooltipViewModel _tooltip;

	private readonly TooltipTriggerVM _tooltipTrigger;

	private bool _hasWarning;

	private int _intValue;

	private float _floatValue;

	private string _visualId;

	private string _value;

	[DataSourceProperty]
	public bool HasWarning
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
	public int IntValue
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
	public float FloatValue
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
	public string VisualId
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
	public string Value
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
	public MapInfoItemVM(string itemId, Func<List<TooltipProperty>> getTooltip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapInfoItemVM(string itemId, TooltipTriggerVM tooltipTrigger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteBeginHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteEndHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOverriddenVisualId(string visualId)
	{
		throw null;
	}
}
