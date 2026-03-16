using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace NavalDLC.Missions.ShipControl;

public struct NavalVec
{
	private Vec2 _deltaPosition;

	private float _deltaOrientation;

	private float _deltaSpeed;

	public Vec2 DeltaPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float DeltaOrientation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float DeltaSpeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static NavalVec Zero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalVec(in Vec2 deltaPosition, float deltaRotation, float deltaSpeed = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalVec(in Vec2 deltaPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClampAngle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalVec operator +(in NavalVec vec1, in NavalVec vec2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalVec operator -(in NavalVec vec1, in NavalVec vec2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalVec operator *(in NavalVec vector, float scalar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalVec operator *(float scalar, in NavalVec vector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalVec operator *(in Vec3 vector, in NavalVec nVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalVec operator *(in NavalVec nVector, in Vec3 vector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalVec operator /(in NavalVec vector, float scalar)
	{
		throw null;
	}
}
