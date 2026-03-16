using System.Runtime.CompilerServices;
using SandBox.View.Map;
using TaleWorlds.Engine;
using TaleWorlds.GauntletUI;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI;

public class MapConversationTextureProvider : TextureProvider
{
	private MapConversationTableau _mapConversationTableau;

	private Texture _texture;

	private Texture _providedTexture;

	public object Data
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public bool IsEnabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapConversationTextureProvider()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Clear(bool clearNextFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckTexture()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Texture OnGetTextureForRender(TwoDimensionContext twoDimensionContext, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetTargetSize(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt)
	{
		throw null;
	}
}
