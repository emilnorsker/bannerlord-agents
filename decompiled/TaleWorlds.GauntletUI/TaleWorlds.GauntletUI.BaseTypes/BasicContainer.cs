using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI.BaseTypes;

public class BasicContainer : Container
{
	public override Predicate<Widget> AcceptDropPredicate
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

	public override bool IsDragHovering
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BasicContainer(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Vector2 GetDropGizmoPosition(Vector2 draggedWidgetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetIndexForDrop(Vector2 draggedWidgetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnChildSelected(Widget widget)
	{
		throw null;
	}
}
