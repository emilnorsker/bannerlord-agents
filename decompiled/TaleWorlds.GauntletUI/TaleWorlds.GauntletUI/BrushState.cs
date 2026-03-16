using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public struct BrushState : IBrushAnimationState, IDataSource
{
	public Color FontColor;

	public Color TextGlowColor;

	public Color TextOutlineColor;

	public float TextOutlineAmount;

	public float TextGlowRadius;

	public float TextBlur;

	public float TextShadowOffset;

	public float TextShadowAngle;

	public float TextColorFactor;

	public float TextAlphaFactor;

	public float TextHueFactor;

	public float TextSaturationFactor;

	public float TextValueFactor;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillFrom(Style style)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LerpFrom(BrushState start, Style end, float ratio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IBrushAnimationState.FillFrom(IDataSource source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IBrushAnimationState.LerpFrom(IBrushAnimationState start, IDataSource end, float ratio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetValueAsFloat(BrushAnimationProperty.BrushAnimationPropertyType propertyType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Color GetValueAsColor(BrushAnimationProperty.BrushAnimationPropertyType propertyType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Sprite GetValueAsSprite(BrushAnimationProperty.BrushAnimationPropertyType propertyType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetValueAsFloat(BrushAnimationProperty.BrushAnimationPropertyType propertyType, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetValueAsColor(BrushAnimationProperty.BrushAnimationPropertyType propertyType, in Color value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetValueAsSprite(BrushAnimationProperty.BrushAnimationPropertyType propertyType, Sprite value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextMaterial CreateTextMaterial(TwoDimensionDrawContext drawContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IBrushAnimationState.SetValueAsColor(BrushAnimationProperty.BrushAnimationPropertyType propertyType, in Color value)
	{
		throw null;
	}
}
