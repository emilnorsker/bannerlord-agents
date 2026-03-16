using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public struct BrushLayerState : IBrushAnimationState, IDataSource
{
	public Color Color;

	public float ColorFactor;

	public float AlphaFactor;

	public float HueFactor;

	public float SaturationFactor;

	public float ValueFactor;

	public float OverlayXOffset;

	public float OverlayYOffset;

	public float XOffset;

	public float YOffset;

	public float Rotation;

	public float ExtendRight;

	public float ExtendTop;

	public float ExtendBottom;

	public float ExtendLeft;

	public Sprite Sprite;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillFrom(IBrushLayerData styleLayer)
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
	public void LerpFrom(BrushLayerState start, IBrushLayerData end, float ratio)
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
	public static void SetValueAsLerpOfValues(ref BrushLayerState currentState, in BrushAnimationKeyFrame startValue, in BrushAnimationKeyFrame endValue, BrushAnimationProperty.BrushAnimationPropertyType propertyType, float ratio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IBrushAnimationState.SetValueAsColor(BrushAnimationProperty.BrushAnimationPropertyType propertyType, in Color value)
	{
		throw null;
	}
}
