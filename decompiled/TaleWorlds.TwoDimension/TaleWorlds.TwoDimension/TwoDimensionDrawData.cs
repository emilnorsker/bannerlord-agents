using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

internal struct TwoDimensionDrawData
{
	private bool _scissorTestEnabled;

	private ScissorTestInfo _scissorTestInfo;

	private SimpleMaterial _imageMaterial;

	private ImageDrawObject _imageDrawObject;

	private TextMaterial _textMaterial;

	private TextDrawObject _textDrawObject;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TwoDimensionDrawData(bool scissorTestEnabled, in ScissorTestInfo scissorTestInfo, SimpleMaterial imageMaterial, in ImageDrawObject imageDrawObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TwoDimensionDrawData(bool scissorTestEnabled, in ScissorTestInfo scissorTestInfo, TextMaterial textMaterial, in TextDrawObject textDrawObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrawTo(TwoDimensionContext twoDimensionContext, int layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateVisualRect()
	{
		throw null;
	}
}
