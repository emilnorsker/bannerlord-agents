using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

public class CraftingPieceThumbnailCache : ThumbnailCache<CraftingPieceCreationData>
{
	private int _itemTableauGPUAllocationIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CraftingPieceThumbnailCache(int capacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override TextureCreationInfo OnCreateTexture(CraftingPieceCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnReleaseTexture(CraftingPieceCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity CreateCraftingPieceBaseEntity(CraftingPiece craftingPiece, string ItemType, Scene scene, ref Camera camera)
	{
		throw null;
	}
}
