using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Multiplayer.Lobby.Armory;

public class TauntCircleActionSelectorWidget : CircleActionSelectorWidget
{
	private Widget _currentNavigationTarget;

	private int _currentSelectedIndex;

	private int _tauntSlotNavigationTrialCount;

	private Widget _fallbackNavigationWidget;

	public Widget FallbackNavigationWidget
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
	public TauntCircleActionSelectorWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSelectedIndexChanged(int selectedIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetCurrentNavigationTarget(Widget target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NavigationUpdate(float dt)
	{
		throw null;
	}
}
