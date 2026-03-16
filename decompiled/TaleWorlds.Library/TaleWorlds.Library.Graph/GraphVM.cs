using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library.Graph;

public class GraphVM : ViewModel
{
	private MBBindingList<GraphLineVM> _lines;

	private string _horizontalAxisLabel;

	private string _verticalAxisLabel;

	private float _horizontalMinValue;

	private float _horizontalMaxValue;

	private float _verticalMinValue;

	private float _verticalMaxValue;

	[DataSourceProperty]
	public MBBindingList<GraphLineVM> Lines
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
	public string HorizontalAxisLabel
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
	public string VerticalAxisLabel
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
	public float HorizontalMinValue
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
	public float HorizontalMaxValue
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
	public float VerticalMinValue
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
	public float VerticalMaxValue
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
	public GraphVM(string horizontalAxisLabel, string verticalAxisLabel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Draw(IEnumerable<(GraphLineVM line, IEnumerable<GraphLinePointVM> points)> linesWithPoints, in Vec2 horizontalRange, in Vec2 verticalRange, float autoRangeHorizontalCoefficient = 1f, float autoRangeVerticalCoefficient = 1f, bool useAutoHorizontalRange = false, bool useAutoVerticalRange = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ExtendRangeToNearestMultipleOfCoefficient(float minValue, float maxValue, float coefficient, out float extendedMinValue, out float extendedMaxValue)
	{
		throw null;
	}
}
