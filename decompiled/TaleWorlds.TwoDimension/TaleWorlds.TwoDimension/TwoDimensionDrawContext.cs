using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

public class TwoDimensionDrawContext
{
	private List<ScissorTestInfo> _scissorStack;

	private bool _scissorTestEnabled;

	private bool _circularMaskEnabled;

	private float _circularMaskRadius;

	private float _circularMaskSmoothingRadius;

	private Vector2 _circularMaskCenter;

	private List<TwoDimensionDrawData> _drawData;

	private MaterialPool<SimpleMaterial> _simpleMaterialPool;

	private MaterialPool<TextMaterial> _textMaterialPool;

	public bool ScissorTestEnabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CircularMaskEnabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vector2 CircularMaskCenter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CircularMaskRadius
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CircularMaskSmoothingRadius
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ScissorTestInfo CurrentScissor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TwoDimensionDrawContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SimpleMaterial CreateSimpleMaterial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextMaterial CreateTextMaterial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PushScissor(in Rectangle2D newScissorRectangle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PopScissor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDiscardedByAnyScissor(in Rectangle2D rect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCircualMask(Vector2 position, float radius, float smoothingRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearCircualMask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateVisualMatricesAux(int startIndexInclusive, int endIndexInclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrawTo(TwoDimensionContext twoDimensionContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrawSprite(Sprite sprite, SimpleMaterial material, in Rectangle2D rectangle, float scale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Draw(SimpleMaterial material, in ImageDrawObject drawObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Draw(TextMaterial material, in TextDrawObject drawObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Draw(Text text, TextMaterial materialOriginal, in Rectangle2D parentRectangle, in Rectangle2D rectangle)
	{
		throw null;
	}
}
