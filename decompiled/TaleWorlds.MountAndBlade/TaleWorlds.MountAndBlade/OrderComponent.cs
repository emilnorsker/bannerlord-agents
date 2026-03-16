using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public abstract class OrderComponent
{
	private readonly Timer _tickTimer;

	protected Func<Formation, Vec3> Position;

	protected Func<Formation, Vec2> Direction;

	private Vec2 _previousDirection;

	public abstract OrderType OrderType { get; }

	protected internal virtual bool CanStack
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected internal virtual bool CancelsPreviousDirectionOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected internal virtual bool CancelsPreviousArrangementOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetDirection(Formation f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void CopyPositionAndDirectionFrom(OrderComponent order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected OrderComponent(float tickTimerDuration = 0.5f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool Tick(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	protected virtual void TickDebug(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void TickOccasionally(Formation formation, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnApply(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnCancel(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnUnitJoinOrLeave(Agent unit, bool isJoining)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual bool IsApplicable(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual MovementOrder GetSubstituteOrder(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnArrangementChanged(Formation formation)
	{
		throw null;
	}
}
