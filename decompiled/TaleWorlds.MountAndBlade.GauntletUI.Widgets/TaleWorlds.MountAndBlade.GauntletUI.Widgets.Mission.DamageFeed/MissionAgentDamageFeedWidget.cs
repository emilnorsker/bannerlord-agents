using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Mission.DamageFeed;

public class MissionAgentDamageFeedWidget : Widget
{
	private int _speedUpWidgetLimit;

	private readonly Queue<MissionAgentDamageFeedItemWidget> _feedItemQueue;

	private MissionAgentDamageFeedItemWidget _activeFeedItem;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionAgentDamageFeedWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnChildAdded(Widget child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBeforeChildRemoved(Widget child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSpeedModifiers()
	{
		throw null;
	}
}
