using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI;

public class BrushAnimationProperty
{
	public enum BrushAnimationPropertyType
	{
		Name,
		ColorFactor,
		Color,
		AlphaFactor,
		HueFactor,
		SaturationFactor,
		ValueFactor,
		FontColor,
		OverlayXOffset,
		OverlayYOffset,
		TextGlowColor,
		TextOutlineColor,
		TextOutlineAmount,
		TextGlowRadius,
		TextBlur,
		TextShadowOffset,
		TextShadowAngle,
		TextColorFactor,
		TextAlphaFactor,
		TextHueFactor,
		TextSaturationFactor,
		TextValueFactor,
		Sprite,
		IsHidden,
		XOffset,
		YOffset,
		Rotation,
		OverridenWidth,
		OverridenHeight,
		WidthPolicy,
		HeightPolicy,
		HorizontalFlip,
		VerticalFlip,
		OverlayMethod,
		OverlaySprite,
		ExtendLeft,
		ExtendRight,
		ExtendTop,
		ExtendBottom,
		UseRandomBaseOverlayXOffset,
		UseRandomBaseOverlayYOffset,
		Font,
		FontStyle,
		FontSize
	}

	public BrushAnimationPropertyType PropertyType;

	private List<BrushAnimationKeyFrame> _keyFrames;

	public string LayerName
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

	public IEnumerable<BrushAnimationKeyFrame> KeyFrames
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Count
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BrushAnimationProperty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BrushAnimationKeyFrame GetFrameAfter(float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BrushAnimationKeyFrame GetFrameAt(int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BrushAnimationProperty Clone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillFrom(BrushAnimationProperty collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddKeyFrame(BrushAnimationKeyFrame keyFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveKeyFrame(BrushAnimationKeyFrame keyFrame)
	{
		throw null;
	}
}
