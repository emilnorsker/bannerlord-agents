using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI.Layout;

public class StackLayout : ILayout
{
	private const int DragHoverAperture = 20;

	private readonly Dictionary<int, LayoutBox> _layoutBoxes;

	private Widget _parallelMeasureBasicChildWidget;

	private Vector2 _parallelMeasureBasicChildMeasureSpec;

	private AlignmentAxis _parallelMeasureBasicChildAlignmentAxis;

	private TWParallel.ParallelForAuxPredicate _parallelMeasureBasicChildDelegate;

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

	public LayoutMethod LayoutMethod
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ContainerItemDescription GetItemDescription(Widget owner, Widget child, int childIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vector2 MeasureChildren(Widget widget, Vector2 measureSpec, SpriteData spriteData, float renderScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnLayout(Widget widget, float left, float bottom, float right, float top)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetData(Vector2 vector2, int row)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SetData(ref Vector2 vector2, int row, float data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetIndexForDrop(Container widget, Vector2 draggedWidgetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelMeasureBasicChild(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vector2 MeasureLinear(Widget widget, Vector2 measureSpec, AlignmentAxis alignmentAxis)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelUpdateLayouts(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LayoutLinearHorizontalLocal(Widget widget, float left, float bottom, float right, float top)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LayoutLinearVertical(Widget widget, float left, float bottom, float right, float top)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vector2 GetDropGizmoPosition(Container widget, Vector2 draggedWidgetPosition)
	{
		throw null;
	}
}
