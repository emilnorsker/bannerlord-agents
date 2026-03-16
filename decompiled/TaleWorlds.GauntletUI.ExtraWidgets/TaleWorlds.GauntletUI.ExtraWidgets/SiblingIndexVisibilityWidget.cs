using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.GauntletUI.ExtraWidgets;

public class SiblingIndexVisibilityWidget : Widget
{
	public enum WatchTypes
	{
		Equal,
		BiggerThan,
		BiggerThanEqual,
		LessThan,
		LessThanEqual,
		Odd,
		Even
	}

	private Widget _widgetToWatch;

	private int _indexToBeVisible;

	public WatchTypes WatchType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public int IndexToBeVisible
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
	public Widget WidgetToWatch
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
	public SiblingIndexVisibilityWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateVisibility()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnWidgetToWatchParentEventFired(Widget arg1, string arg2, object[] arg3)
	{
		throw null;
	}
}
