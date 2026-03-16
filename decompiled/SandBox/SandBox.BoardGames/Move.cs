using System.Runtime.CompilerServices;
using SandBox.BoardGames.Pawns;
using SandBox.BoardGames.Tiles;

namespace SandBox.BoardGames;

public struct Move
{
	public static readonly Move Invalid;

	public PawnBase Unit;

	public TileBase GoalTile;

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Move(PawnBase unit, TileBase goalTile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Move()
	{
		throw null;
	}
}
