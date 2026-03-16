using System.Runtime.CompilerServices;
using SandBox.BoardGames.Pawns;

namespace SandBox.BoardGames;

public struct TileBaseInformation
{
	public PawnBase PawnOnTile;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TileBaseInformation(ref PawnBase pawnOnTile)
	{
		throw null;
	}
}
