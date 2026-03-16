using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace NavalDLC.DWA;

public struct DWAAgentState
{
	public Vec2 Position;

	public float PositionZ;

	public Vec2 Direction;

	public Vec2 LinearVelocity;

	public float AngularVelocity;

	public float LinearAcceleration;

	public float AngularAcceleration;

	public Vec2 ShapeOffset;

	public Vec2 ShapeHalfSize;

	public Vec2 ShapeCenter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxExtent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MinExtent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 Position3D
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}
}
