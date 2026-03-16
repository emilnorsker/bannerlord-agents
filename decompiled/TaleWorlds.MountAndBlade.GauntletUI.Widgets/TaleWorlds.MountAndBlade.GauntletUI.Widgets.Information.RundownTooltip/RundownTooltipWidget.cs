using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.ExtraWidgets;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Information.RundownTooltip;

public class RundownTooltipWidget : TooltipWidget
{
	private enum ValueCategorization
	{
		None,
		LargeIsBetter,
		SmallIsBetter
	}

	private readonly Color _defaultValueColor;

	private readonly Color _negativeValueColor;

	private readonly Color _positiveValueColor;

	private bool _willRefreshThisFrame;

	private IReadOnlyList<float> _lastCheckedColumnWidths;

	private GridWidget _lineContainerWidget;

	private RundownColumnDividerCollectionWidget _dividerCollectionWidget;

	private int _valueCategorizationAsInt;

	[Editor(false)]
	public GridWidget LineContainerWidget
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

	[Editor(false)]
	public RundownColumnDividerCollectionWidget DividerCollectionWidget
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

	[Editor(false)]
	public int ValueCategorizationAsInt
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
	public RundownTooltipWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Refresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshOnNextLateUpdate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnLineContainerEventFire(Widget widget, string eventName, object[] args)
	{
		throw null;
	}
}
