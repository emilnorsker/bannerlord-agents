using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Core.ViewModelCollection.Information;

public class BasicTooltipViewModel : ViewModel
{
	private Func<string> _hintProperty;

	private Func<List<TooltipProperty>> _tooltipProperties;

	private Action _preBuiltTooltipCallback;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BasicTooltipViewModel(Func<string> hintTextDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BasicTooltipViewModel(Func<List<TooltipProperty>> tooltipPropertiesDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BasicTooltipViewModel(Action preBuiltTooltipCallback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BasicTooltipViewModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetToolipCallback(Func<List<TooltipProperty>> tooltipPropertiesDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGenericTooltipCallback(Action preBuiltTooltipCallback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHintCallback(Func<string> hintProperty)
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
}
