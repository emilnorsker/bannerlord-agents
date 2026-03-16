using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class CubicBezier
{
	private readonly double _x1;

	private readonly double _y1;

	private readonly double _x2;

	private readonly double _y2;

	private readonly double _y0;

	private readonly double _y3;

	private const int NewtonIterations = 4;

	private const double NewtonMinSlope = 0.001;

	private const double SubdivisionPrecision = 1E-07;

	private const int SubdivisionMaxIterations = 10;

	private const int KSplineTableSize = 11;

	private const double KSampleStepSize = 0.1;

	private readonly double[] _sampleValues;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CubicBezier CreateEase(double controlPoint1X, double controlPoint1Y, double controlPoint2X, double controlPoint2Y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CubicBezier CreateYBeginToYEndWithRelativeControlDirs(double yBegin, double yEnd, double controlDir1X, double controlDir1Y, double controlDir2X, double controlDir2Y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CubicBezier CreateYBeginToYEnd(double yBegin, double yEnd, double controlPoint1X, double controlPoint1Y, double controlPoint2X, double controlPoint2Y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CubicBezier(double x1, double y1, double x2, double y2, double yBegin = 0.0, double yEnd = 1.0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public double Sample(double x)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool AlmostEq(double a, double b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static double AY(double aA0, double aA1, double aA2, double aA3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static double A(double aA1, double aA2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static double BY(double aA0, double aA1, double aA2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static double B(double aA1, double aA2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static double CY(double aA0, double aA1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static double C(double aA1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static double DY(double aA0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static double CalcBezierY(double aT, double aA0, double aA1, double aA2, double aA3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static double CalcBezierX(double aT, double aA1, double aA2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static double GetSlopeX(double aT, double aA1, double aA2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static double BinarySubdivide(double aX, double aA, double aB, double mX1, double mX2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private double NewtonRaphsonIterate(double aX, double aGuessT, double mX1, double mX2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private double GetTForX(double aX)
	{
		throw null;
	}
}
