using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.BoardGames.Pawns;

public class PawnPuluc : PawnBase
{
	public enum MovementState
	{
		MovingForward,
		MovingBackward,
		ChangingDirection
	}

	public MovementState State;

	public PawnPuluc CapturedBy;

	public Vec3 SpawnPos;

	public bool IsInSpawn;

	public bool IsTopPawn;

	private static float _height;

	private int _x;

	public float Height
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override Vec3 PosBeforeMoving
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool IsPlaced
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int X
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

	public List<PawnPuluc> PawnsBelow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public bool InPlay
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PawnPuluc(GameEntity entity, bool playerOne)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AddGoalPosition(Vec3 goal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void MovePawnToGoalPositions(bool instantMove, float speed, bool dragged = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetPawnAtPosition(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EnableCollisionBody()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DisableCollisionBody()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MovePawnBackToSpawn(bool instantMove, float speed, bool fake = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PawnPuluc()
	{
		throw null;
	}
}
