using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace SandBox.BoardGames.Pawns;

public class PawnTablut : PawnBase
{
	public int X;

	public int Y;

	public override bool IsPlaced
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PawnTablut(GameEntity entity, bool playerOne)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Reset()
	{
		throw null;
	}
}
