using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public class Style : IDataSource
{
	private int _localVersion;

	private bool _isFontColorChanged;

	private bool _isTextGlowColorChanged;

	private bool _isTextOutlineColorChanged;

	private bool _isTextOutlineAmountChanged;

	private bool _isTextGlowRadiusChanged;

	private bool _isTextBlurChanged;

	private bool _isTextShadowOffsetChanged;

	private bool _isTextShadowAngleChanged;

	private bool _isTextColorFactorChanged;

	private bool _isTextAlphaFactorChanged;

	private bool _isTextHueFactorChanged;

	private bool _isTextSaturationFactorChanged;

	private bool _isTextValueFactorChanged;

	private bool _isFontChanged;

	private bool _isFontStyleChanged;

	private bool _isFontSizeChanged;

	private Color _fontColor;

	private Color _textGlowColor;

	private Color _textOutlineColor;

	private float _textOutlineAmount;

	private float _textGlowRadius;

	private float _textBlur;

	private float _textShadowOffset;

	private float _textShadowAngle;

	private float _textColorFactor;

	private float _textAlphaFactor;

	private float _textHueFactor;

	private float _textSaturationFactor;

	private float _textValueFactor;

	private Font _font;

	private FontStyle _fontStyle;

	private int _fontSize;

	private string _animationToPlayOnBegin;

	private Dictionary<string, StyleLayer> _layers;

	private MBList<StyleLayer> _layersWithIndex;

	public Style DefaultStyle
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

	[Editor(false)]
	public string Name
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

	private uint DefaultStyleVersion
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public long Version
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[Editor(false)]
	public string AnimationToPlayOnBegin
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public int LayerCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public StyleLayer DefaultLayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[Editor(false)]
	public StyleAnimationMode AnimationMode
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

	[Editor(false)]
	public Color FontColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public Color TextGlowColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public Color TextOutlineColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public float TextOutlineAmount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public float TextGlowRadius
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public float TextBlur
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public float TextShadowOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public float TextShadowAngle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public float TextColorFactor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public float TextAlphaFactor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public float TextHueFactor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public float TextSaturationFactor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public float TextValueFactor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public Font Font
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public FontStyle FontStyle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public int FontSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Style(IEnumerable<BrushLayer> layers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillFrom(Style style)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddLayer(StyleLayer layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveLayer(string layerName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StyleLayer GetLayer(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StyleLayer GetLayer(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StyleLayer[] GetLayers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextMaterial CreateTextMaterial(TwoDimensionDrawContext drawContext)
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
	public void SetAsDefaultStyle()
	{
		throw null;
	}
}
