using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct Ray
{
	private Vec3 _origin;

	private Vec3 _direction;

	private float _maxDistance;

	public Vec3 Origin
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public Vec3 Direction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public float MaxDistance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public Vec3 EndPoint
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Ray(Vec3 origin, Vec3 direction, float maxDistance = float.MaxValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Ray(Vec3 origin, Vec3 direction, bool useDirectionLenForMaxDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset(Vec3 origin, Vec3 direction, float maxDistance = float.MaxValue)
	{
		throw null;
	}
}
