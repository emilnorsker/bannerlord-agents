using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI.BaseTypes;

public abstract class Container : Widget
{
	public List<Action<Widget>> SelectEventHandlers;

	public List<Action<Widget, Widget>> ItemAddEventHandlers;

	public List<Action<Widget, Widget>> ItemRemoveEventHandlers;

	public List<Action<Widget>> ItemAfterRemoveEventHandlers;

	private int _intValue;

	private bool _currentlyChangingIntValue;

	public bool ShowSelection;

	private int _dragHoverInsertionIndex;

	private List<ContainerItemDescription> _itemDescriptions;

	private bool _clearSelectedOnRemoval;

	public ContainerItemDescription DefaultItemDescription
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public abstract Predicate<Widget> AcceptDropPredicate { get; set; }

	public int IntValue
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

	public abstract bool IsDragHovering { get; }

	public int DragHoverInsertionIndex
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
	public bool ClearSelectedOnRemoval
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

	public abstract Vector2 GetDropGizmoPosition(Vector2 draggedWidgetPosition);

	public abstract int GetIndexForDrop(Vector2 draggedWidgetPosition);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected Container(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSelected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override bool OnDrop()
	{
		throw null;
	}

	public abstract void OnChildSelected(Widget widget);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ContainerItemDescription GetItemDescription(string id, int index)
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
	protected override void OnAfterChildRemoved(Widget child, int previousIndexOfChild)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddItemDescription(ContainerItemDescription itemDescription)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScrollablePanel FindParentPanel()
	{
		throw null;
	}
}
