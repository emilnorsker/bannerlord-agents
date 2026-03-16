using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Map.Notification;

public class MapNotificationContainerWidget : Widget
{
	private List<Widget> _newChildren;

	private TextWidget _moreTextWidget;

	private BrushWidget _moreTextWidgetContainer;

	private int _maxAmountOfNotificationsToShow;

	[Editor(false)]
	public BrushWidget MoreTextWidgetContainer
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
	public TextWidget MoreTextWidget
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
	public int MaxAmountOfNotificationsToShow
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
	public MapNotificationContainerWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineNavigationIndicies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnChildAdded(Widget child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnAfterChildRemoved(Widget child, int previousIndexOfChild)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineChildrenVisibility()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineMoreTextStatus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float DetermineChildTargetYOffset(Widget child, int childIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float LocalLerp(float start, float end, float delta)
	{
		throw null;
	}
}
