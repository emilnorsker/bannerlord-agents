using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets;

public class RadioContainerWidget : Widget
{
	private int _selectedIndex;

	private Container _container;

	[Editor(false)]
	public int SelectedIndex
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
	public Container Container
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
	public RadioContainerWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ContainerOnPropertyChanged(PropertyOwnerObject owner, string propertyName, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ContainerOnEventFire(Widget owner, string eventName, object[] arguments)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ContainerUpdated(Container newContainer)
	{
		throw null;
	}
}
