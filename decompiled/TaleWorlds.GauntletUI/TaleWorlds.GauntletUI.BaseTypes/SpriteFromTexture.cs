using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI.BaseTypes;

internal class SpriteFromTexture : Sprite
{
	private Texture _texture;

	public override Texture Texture
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Vec2 GetMinUvs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Vec2 GetMaxUvs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpriteFromTexture(Texture texture, int width, int height)
	{
		throw null;
	}
}
