using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace SandBox.BoardGames.Pawns;

public class PawnKonane : PawnBase
{
	public int X;

	public int Y;

	public int PrevX;

	public int PrevY;

	public override bool IsPlaced
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PawnKonane(GameEntity entity, bool playerOne)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Reset()
	{
		throw null;
	}
}
