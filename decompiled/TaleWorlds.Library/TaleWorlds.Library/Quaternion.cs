using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

[Serializable]
public struct Quaternion
{
	public float W;

	public float X;

	public float Y;

	public float Z;

	public float this[int i]
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

	public bool IsIdentity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsUnit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Quaternion Identity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quaternion(float x, float y, float z, float w)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(Quaternion a, Quaternion b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(Quaternion a, Quaternion b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion operator +(Quaternion a, Quaternion b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion operator -(Quaternion a, Quaternion b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion operator *(Quaternion a, float b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion operator *(float s, Quaternion v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion operator *(Quaternion a, Quaternion b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion operator /(Quaternion v, float s)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float Normalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float SafeNormalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float NormalizeWeighted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetToRotationX(float angle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetToRotationY(float angle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetToRotationZ(float angle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Flip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quaternion TransformToParent(Quaternion q)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quaternion TransformToLocal(Quaternion q)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quaternion TransformToLocalWithoutNormalize(Quaternion q)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion Slerp(Quaternion from, Quaternion to, float t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion Lerp(Quaternion from, Quaternion to, float t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mat3 Mat3FromQuaternion(Quaternion quat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion QuaternionFromEulerAngles(float yaw, float pitch, float roll)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion QuaternionFromMat3(Mat3 m)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AxisAngleFromQuaternion(out Vec3 axis, out float angle, Quaternion quat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion QuaternionFromAxisAngle(Vec3 axis, float angle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 EulerAngleFromQuaternion(Quaternion quat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion FindShortestArcAsQuaternion(Vec3 v0, Vec3 v1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float Dotp4(Quaternion q2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mat3 ToMat3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool InverseDirection(Quaternion q2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quaternion Conjugate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quaternion Inverse()
	{
		throw null;
	}
}
