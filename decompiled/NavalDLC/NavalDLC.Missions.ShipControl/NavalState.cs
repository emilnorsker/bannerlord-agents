using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace NavalDLC.Missions.ShipControl;

public struct NavalState
{
	private Vec2 _position;

	private float _orientation;

	private float _speed;

	public Vec2 Position
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Orientation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 Direction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Speed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static NavalState Zero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalState(in Vec2 position, float orientation, float speed = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalState(in Vec2 position, in Vec2 direction, float speed = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalState(in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalState operator +(in NavalState state, in NavalVec vector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalState operator -(in NavalState state, in NavalVec vector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalVec operator -(in NavalState toState, in NavalState fromState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetDirection(in Vec2 targetDirection)
	{
		throw null;
	}
}
