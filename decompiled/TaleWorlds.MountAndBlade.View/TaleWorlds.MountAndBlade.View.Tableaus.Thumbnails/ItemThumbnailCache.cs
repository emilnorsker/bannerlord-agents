using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

public class ItemThumbnailCache : ThumbnailCache<ItemThumbnailCreationData>
{
	private struct CustomPoseParameters
	{
		public enum Alignment
		{
			Center,
			Top,
			Bottom
		}

		public string CameraTag;

		public string FrameTag;

		public float DistanceModifier;

		public Alignment FocusAlignment;
	}

	private int _itemTableauGPUAllocationIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemThumbnailCache(int capacity)
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
	protected override TextureCreationInfo OnCreateTexture(ItemThumbnailCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnReleaseTexture(ItemThumbnailCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetRenderIdToUse(ItemThumbnailCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity CreateItemBaseEntity(ItemObject item, Scene scene, ref Camera camera)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetItemPoseAndCamera(ItemObject item, Scene scene, ref Camera camera, ref MatrixFrame itemFrame, ref MatrixFrame itemFrame1, ref MatrixFrame itemFrame2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity AddItem(Scene scene, ItemObject item, MatrixFrame itemFrame, MatrixFrame itemFrame1, MatrixFrame itemFrame2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetItemPoseAndCameraForCraftedItem(ItemObject item, Scene scene, ref Camera camera, ref MatrixFrame itemFrame, ref MatrixFrame itemFrame1, ref MatrixFrame itemFrame2)
	{
		throw null;
	}
}
