using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

[Serializable]
public struct Mat3
{
	public Vec3 s;

	public Vec3 f;

	public Vec3 u;

	public Vec3 this[int i]
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

	public static Mat3 Identity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mat3(in Vec3 s, in Vec3 f, in Vec3 u)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mat3(float sx, float sy, float sz, float fx, float fy, float fz, float ux, float uy, float uz)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateAboutSide(float a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateAboutForward(float a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateAboutUp(float a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateAboutAnArbitraryVector(in Vec3 v, float a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOrthonormal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLeftHanded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool NearlyEquals(in Mat3 rhs, float epsilon = 1E-05f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 TransformToParent(in Vec3 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 TransformToParent(in Vec2 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 TransformToLocal(in Vec3 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 TransformToLocal(in Vec2 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mat3 TransformToParent(in Mat3 m)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mat3 TransformToLocal(in Mat3 m)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Orthonormalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OrthonormalizeAccordingToForwardAndKeepUpAsZAxis()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mat3 GetUnitRotation(float removedScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 MakeUnit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsUnit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyScaleLocal(float scaleAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyScaleLocal(in Vec3 scaleAmountXYZ)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasScale()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetScaleVector()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetScaleVectorSquared()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ToQuaternion(out Quaternion quat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quaternion ToQuaternion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mat3 Lerp(in Mat3 m1, in Mat3 m2, float alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mat3 LerpNonOrthogonal(in Mat3 m1, in Mat3 m2, float alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mat3 CreateMat3WithForward(in Vec3 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mat3 CreateDiagonalMat3(in Vec3 diagonalData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetEulerAngles()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mat3 Transpose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mat3 operator *(in Mat3 v, float a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(in Mat3 m1, in Mat3 m2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(in Mat3 m1, in Mat3 m2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
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
	public bool IsIdentity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsZero()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsUniformScaled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyEulerAngles(in Vec3 eulerAngles)
	{
		throw null;
	}
}
