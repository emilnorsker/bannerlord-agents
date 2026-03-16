using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library.Information;

public class TooltipTriggerVM : ViewModel
{
	private Type _linkedTooltipType;

	private object[] _args;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TooltipTriggerVM(Type linkedTooltipType, params object[] args)
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
