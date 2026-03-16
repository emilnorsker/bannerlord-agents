using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

[Serializable]
public struct Transformation
{
	public Vec3 Origin;

	public Mat3 Rotation;

	public Vec3 Scale;

	public static Transformation Identity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MatrixFrame AsMatrixFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Transformation(Vec3 origin, Mat3 rotation, Vec3 scale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Transformation CreateFromMatrixFrame(MatrixFrame matrixFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Transformation CreateFromRotation(Mat3 rotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 TransformToParent(Vec3 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Transformation TransformToParent(Transformation t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 TransformToLocal(Vec3 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Transformation TransformToLocal(Transformation t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Rotate(float radian, Vec3 axis)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(Transformation t1, Transformation t2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyScale(Vec3 vec3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(Transformation t1, Transformation t2)
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
	public override string ToString()
	{
		throw null;
	}
}
