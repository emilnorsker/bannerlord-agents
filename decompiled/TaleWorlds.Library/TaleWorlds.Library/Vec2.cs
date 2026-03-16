using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

[Serializable]
public struct Vec2
{
	public float x;

	public float y;

	public static readonly Vec2 Side;

	public static readonly Vec2 Forward;

	public static readonly Vec2 One;

	public static readonly Vec2 Zero;

	public static readonly Vec2 Invalid;

	public float X
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Y
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Length
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LengthSquared
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RotationInRadians
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2(float a, float b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2(Vec2 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2(Vector2 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 ToVec3(float z = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static explicit operator Vector2(Vec2 vec2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static implicit operator Vec2(Vector2 vec2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float Normalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 Normalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClampMagnitude(float min, float max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WindingOrder GetWindingOrder(Vec2 first, Vec2 second, Vec2 third)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float CCW(Vec2 va, Vec2 vb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(Vec2 v1, Vec2 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(Vec2 v1, Vec2 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 operator -(Vec2 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 operator +(Vec2 v1, Vec2 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 operator -(Vec2 v1, Vec2 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 operator *(Vec2 v, float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 operator *(float f, Vec2 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 operator /(float f, Vec2 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 operator /(Vec2 v, float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsUnit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsNonZero()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool NearlyEquals(Vec2 v, float epsilon = 1E-05f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateCCW(float angleInRadians)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float DotProduct(Vec2 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float DotProduct(Vec2 va, Vec2 vb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 ElementWiseProduct(Vec2 va, Vec2 vb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 FromRotation(float rotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 TransformToLocalUnitF(Vec2 a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 TransformToParentUnitF(Vec2 a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 TransformToLocalUnitFLeftHanded(Vec2 a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 TransformToParentUnitFLeftHanded(Vec2 a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 RightVec()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 LeftVec()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 Max(Vec2 v1, Vec2 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 Max(Vec2 v1, float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 Min(Vec2 v1, Vec2 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 Min(Vec2 v1, float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float DistanceSquared(Vec2 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float Distance(Vec2 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float DistanceToLine(Vec2 line1, Vec2 line2, Vec2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float DistanceToLineSegmentSquared(Vec2 line1, Vec2 line2, Vec2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float DistanceToLineSegment(Vec2 v, Vec2 w, out Vec2 closestPointOnLineSegment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float DistanceSquaredToLineSegment(Vec2 v, Vec2 w, out Vec2 closestPointOnLineSegment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 Abs(Vec2 vec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 Lerp(Vec2 v1, Vec2 v2, float alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 Slerp(Vec2 start, Vec2 end, float percent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float AngleBetween(Vec2 vector2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float Determinant(in Vec2 vec1, in Vec2 vec2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Vec2()
	{
		throw null;
	}
}
