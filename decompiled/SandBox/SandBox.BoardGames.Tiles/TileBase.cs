using System.Runtime.CompilerServices;
using SandBox.BoardGames.Objects;
using SandBox.BoardGames.Pawns;
using TaleWorlds.Engine;

namespace SandBox.BoardGames.Tiles;

public abstract class TileBase
{
	public PawnBase PawnOnTile;

	private bool _showTile;

	private float _tileFadeTimer;

	private const float TileFadeDuration = 0.2f;

	public GameEntity Entity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public BoardGameDecal ValidMoveDecal
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected TileBase(GameEntity entity, BoardGameDecal decal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVisibility(bool isVisible)
	{
		throw null;
	}
}
