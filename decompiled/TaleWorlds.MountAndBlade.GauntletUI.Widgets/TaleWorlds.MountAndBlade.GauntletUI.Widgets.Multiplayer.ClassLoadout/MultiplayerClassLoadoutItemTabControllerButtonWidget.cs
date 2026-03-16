using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Multiplayer.ClassLoadout;

public class MultiplayerClassLoadoutItemTabControllerButtonWidget : ButtonWidget
{
	private readonly List<MultiplayerItemTabButtonWidget> _itemTabs;

	private float _targetPositionXOffset;

	private MultiplayerClassLoadoutItemTabListPanel _itemTabList;

	private Widget _cursorWidget;

	private float _animationSpeed;

	[DataSourceProperty]
	public MultiplayerClassLoadoutItemTabListPanel ItemTabList
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
	public Widget CursorWidget
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
	public float AnimationSpeed
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
	public MultiplayerClassLoadoutItemTabControllerButtonWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnConnectedToRoot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDisconnectedFromRoot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TabWidgetPropertyChanged(PropertyOwnerObject sender, string propertyName, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ItemTabListInitialized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SelectedTabChanged(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateTargetPosition(int selectedIndex, int activeTabCount)
	{
		throw null;
	}
}
