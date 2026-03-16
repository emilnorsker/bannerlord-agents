using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI.Layout;

public class GridLayout : ILayout
{
	public GridVerticalLayoutMethod VerticalLayoutMethod
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

	public GridHorizontalLayoutMethod HorizontalLayoutMethod
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

	public GridDirection Direction
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

	public IReadOnlyList<float> RowHeights
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

	public IReadOnlyList<float> ColumnWidths
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GridLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Vector2 ILayout.MeasureChildren(Widget widget, Vector2 measureSpec, SpriteData spriteData, float renderScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILayout.OnLayout(Widget widget, float left, float bottom, float right, float top)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCellSizes(GridWidget gridWidget, int rowCount, int usedRowCount, int columnCount, int usedColumnCount, float totalWidth, float totalHeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateRowColumnIndices(int visibleIndex, int rowCount, int columnCount, out int row, out int column)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateRowColumnCounts(GridWidget gridWidget, GridDirection direction, int visibleChildrenCount, out int rowCount, out int usedRowCount, out int columnCount, out int usedColumnCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetElement(IReadOnlyList<float> elements, int index)
	{
		throw null;
	}
}
