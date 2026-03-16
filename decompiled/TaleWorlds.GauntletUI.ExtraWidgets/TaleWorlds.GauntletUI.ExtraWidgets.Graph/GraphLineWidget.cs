using System;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.GauntletUI.ExtraWidgets.Graph;

public class GraphLineWidget : Widget
{
	public Action<GraphLineWidget, GraphLinePointWidget> OnPointAdded;

	private Widget _pointContainerWidget;

	public string LineBrushStateName
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

	public Widget PointContainerWidget
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
	public GraphLineWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPointContainerEventFire(Widget widget, string eventName, object[] eventArgs)
	{
		throw null;
	}
}
