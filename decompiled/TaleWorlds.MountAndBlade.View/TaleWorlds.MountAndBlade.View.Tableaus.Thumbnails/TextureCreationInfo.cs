using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

public struct TextureCreationInfo
{
	public bool IsValid;

	public bool CreatedNewTexture;

	public bool UsingExistingTexture;

	public Texture Texture;

	public bool IsSuccess
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsFail
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextureCreationInfo WithNewTexture(Texture texture = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextureCreationInfo WithExistingTexture(Texture texture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextureCreationInfo Fail()
	{
		throw null;
	}
}
