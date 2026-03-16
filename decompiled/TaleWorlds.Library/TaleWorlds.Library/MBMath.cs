using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public static class MBMath
{
	[CompilerGenerated]
	private sealed class _003CDistributeShares_003Ed__17<T> : IEnumerable<(T, int)>, IEnumerable, IEnumerator<(T, int)>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private (T, int) _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> stakeHolders;

		public IEnumerable<T> _003C_003E3__stakeHolders;

		private Func<T, int> shareFunction;

		public Func<T, int> _003C_003E3__shareFunction;

		private int totalAward;

		public int _003C_003E3__totalAward;

		private List<(T, int)> _003CsharesList_003E5__2;

		private int _003CremainingShares_003E5__3;

		private int _003CremaingAward_003E5__4;

		private int _003Ci_003E5__5;

		(T, int) IEnumerator<(T, int)>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CDistributeShares_003Ed__17(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<(T, int)> IEnumerable<(T, int)>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	public const float TwoPI = System.MathF.PI * 2f;

	public const float PI = System.MathF.PI;

	public const float HalfPI = System.MathF.PI / 2f;

	public const float E = System.MathF.E;

	public const float DegreesToRadians = System.MathF.PI / 180f;

	public const float RadiansToDegrees = 180f / System.MathF.PI;

	public const float Epsilon = 1E-05f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float ToRadians(this float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float ToDegrees(this float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ApproximatelyEqualsTo(this float f, float comparedValue, float epsilon = 1E-05f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ApproximatelyEquals(float first, float second, float epsilon = 1E-05f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsValidValue(float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ClampIndex(int value, int minValue, int maxValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ClampInt(int value, int minValue, int maxValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float ClampFloat(float value, float minValue, float maxValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClampUnit(ref float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetNumberOfBitsToRepresentNumber(uint value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CDistributeShares_003Ed__17<>))]
	public static IEnumerable<(T, int)> DistributeShares<T>(int totalAward, IEnumerable<T> stakeHolders, Func<T, int> shareFunction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetNumberOfBitsToRepresentNumber(ulong value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float Lerp(float valueFrom, float valueTo, float amount, float minimumDifference = 1E-05f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float LinearExtrapolation(float valueFrom, float valueTo, float amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 Lerp(Vec3 vecFrom, Vec3 vecTo, float amount, float minimumDifference)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 Lerp(Vec2 vecFrom, Vec2 vecTo, float amount, float minimumDifference)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float Map(float input, float inputMinimum, float inputMaximum, float outputMinimum, float outputMaximum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mat3 Lerp(ref Mat3 matFrom, ref Mat3 matTo, float amount, float minimumDifference)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float LerpRadians(float valueFrom, float valueTo, float amount, float minChange, float maxChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float SplitLerp(float value1, float value2, float value3, float cutOff, float amount, float minimumDifference)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float InverseLerp(float valueFrom, float valueTo, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float SmoothStep(float edge0, float edge1, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float BilinearLerp(float topLeft, float topRight, float botLeft, float botRight, float x, float y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetSmallestDifferenceBetweenTwoAngles(float fromAngle, float toAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float ClampAngle(float angle, float restrictionCenter, float restrictionRange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float WrapAngle(float angle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float WrapAngleSafe(float angle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsBetween(float numberToCheck, float bottom, float top)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsBetween(int value, int minValue, int maxValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsBetweenInclusive(float numberToCheck, float bottom, float top)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static uint ColorFromRGBA(float red, float green, float blue, float alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Color HSBtoRGB(float hue, float saturation, float brightness, float outputAlpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 RGBtoHSB(Color rgb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 GammaCorrectRGB(float gamma, Vec3 rgb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetSignedDistanceOfPointToLineSegment(in Vec2 lineSegmentBegin, in Vec2 lineSegmentEnd, in Vec2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDistanceSquareOfPointToLineSegment(in Vec2 lineSegmentBegin, in Vec2 lineSegmentEnd, Vec2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 ProjectPointOntoLine(Vec2 point, Vec2 lineStart, Vec2 lineEnd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 ClampToAxisAlignedRectangle(Vec2 point, Vec2 lineStart, Vec2 lineEnd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetRayPlaneIntersectionPoint(in Vec3 planeNormal, in Vec3 planeCenter, in Vec3 rayOrigin, in Vec3 rayDirection, out float t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool PointLiesAheadOfPlane(in Vec3 planeNormal, in Vec3 planeCenter, in Vec3 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 GetClosestPointOnLineSegmentToPoint(in Vec2 lineSegmentBegin, in Vec2 lineSegmentEnd, in Vec2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 GetClosestPointOnLineSegmentToPoint(in Vec3 lineSegmentBegin, in Vec3 lineSegmentEnd, in Vec3 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckLineToLineSegmentIntersection(Vec2 lineOrigin, Vec2 lineDirection, Vec2 segmentA, Vec2 segmentB, out float t, out Vec2 intersect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IntersectLineSegmentWithTriangle(in Vec3 segStart, in Vec3 segEnd, in Vec3 triA, in Vec3 triB, in Vec3 triC)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IntersectLineSegmentWithBoundingBox(in Vec3 start, in Vec3 end, in Vec3 min, in Vec3 max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckLineSegmentToLineSegmentIntersection(Vec2 segment1Start, Vec2 segment1End, Vec2 segment2Start, Vec2 segment2End)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckPointInsidePolygon(in Vec2 v0, in Vec2 v1, in Vec2 v2, in Vec2 v3, in Vec2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckPolygonIntersection(Vec2[] polygon1, Vec2[] polygon2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckPolygonLineSegmentIntersection(MBList<Vec2> polygon, Vec2 segmentStart, Vec2 segmentEnd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IntersectRayWithPolygon(Vec2 rayOrigin, Vec2 rayDir, MBList<Vec2> polygon, out Vec2 intersectionPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ToOrdinal(int number)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int IndexOfMax<T>(MBReadOnlyList<T> array, Func<T, int> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T MaxElement<T>(IEnumerable<T> collection, Func<T, float> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static (T, T) MaxElements2<T>(IEnumerable<T> collection, Func<T, float> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static (T, T, T) MaxElements3<T>(IEnumerable<T> collection, Func<T, float> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static (T, T, T, T) MaxElements4<T>(IEnumerable<T> collection, Func<T, float> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static (T, T, T, T, T) MaxElements5<T>(IEnumerable<T> collection, Func<T, float> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IList<T> TopologySort<T>(IEnumerable<T> source, Func<T, IEnumerable<T>> getDependencies)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Visit<T>(T item, Func<T, IEnumerable<T>> getDependencies, List<T> sorted, Dictionary<T, bool> visited)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 FindPlaneLineIntersectionPointWithNormal(Vec3 planeP1, Vec3 planeNormal, Vec3 mouseP1, Vec3 mouseP2, out bool exceptionZero)
	{
		throw null;
	}
}
