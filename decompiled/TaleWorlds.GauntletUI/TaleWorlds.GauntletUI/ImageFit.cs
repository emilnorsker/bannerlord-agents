using System.Numerics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI;

public class ImageFit
{
	public enum ImageFitTypes : byte
	{
		StretchToFit,
		Cover,
		Contain
	}

	public enum ImageHorizontalAlignments : byte
	{
		Left,
		Center,
		Right
	}

	public enum ImageVerticalAlignments : byte
	{
		Top,
		Center,
		Bottom
	}

	public ImageFitTypes Type
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public ImageHorizontalAlignments HorizontalAlignment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public ImageVerticalAlignments VerticalAlignment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float OffsetX
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float OffsetY
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ImageFit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ImageFitResult GetFittedRectangle(in Vector2 containerSize, in Vector2 imageSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ImageFitResult GetRectangleForCover(in Vector2 containerSize, in Vector2 imageSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ImageFitResult GetRectangleForContain(in Vector2 containerSize, in Vector2 imageSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetImageAlignment(in Vector2 containerSize, in Vector2 imageSize, out float x, out float y)
	{
		throw null;
	}
}
