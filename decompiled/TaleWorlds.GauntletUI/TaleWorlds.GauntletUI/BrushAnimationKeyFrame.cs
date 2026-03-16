using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public class BrushAnimationKeyFrame
{
	public enum ValueType
	{
		Float,
		Color,
		Sprite
	}

	private ValueType _valueType;

	private float _valueAsFloat;

	private Color _valueAsColor;

	private Sprite _valueAsSprite;

	public float Time
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

	public int Index
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
	public BrushAnimationKeyFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeAsFloat(float time, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeAsColor(float time, Color value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeAsSprite(float time, Sprite value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetValueAsFloat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Color GetValueAsColor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Sprite GetValueAsSprite()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetValueAsObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BrushAnimationKeyFrame Clone()
	{
		throw null;
	}
}
