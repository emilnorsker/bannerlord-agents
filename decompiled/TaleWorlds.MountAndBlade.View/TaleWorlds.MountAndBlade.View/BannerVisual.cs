using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

namespace TaleWorlds.MountAndBlade.View;

public class BannerVisual : IBannerVisual
{
	public Banner Banner
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
	public BannerVisual(Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ValidateCreateTableauTextures()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture GetTableauTextureSmall(in BannerDebugInfo debugInfo, Action<Texture> setAction, bool isTableauOrNineGrid = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture GetTableauTextureLarge(in BannerDebugInfo debugInfo, Action<Texture> setAction, bool isTableauOrNineGrid = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture GetTableauTextureLarge(in BannerDebugInfo debugInfo, Action<Texture> setAction, out BannerTextureCreationData creationData, bool isTableauOrNineGrid = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MatrixFrame GetMeshMatrix(ref Mesh mesh, float marginLeft, float marginTop, float width, float height, bool mirrored, float rotation, float deltaZ)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaMesh ConvertToMultiMesh()
	{
		throw null;
	}
}
