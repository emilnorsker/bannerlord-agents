using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.TwoDimension;

public class SpriteGeneric : Sprite
{
	public override Texture Texture
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public SpritePart SpritePart
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
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
	public SpriteGeneric(string name, SpritePart spritePart, in SpriteNinePatchParameters ninePatchParameters)
	{
		throw null;
	}
}
