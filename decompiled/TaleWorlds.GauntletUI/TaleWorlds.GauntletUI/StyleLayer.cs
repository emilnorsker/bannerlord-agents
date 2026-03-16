using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public class StyleLayer : IBrushLayerData, IDataSource
{
	private uint _localVersion;

	private bool _isImageFitTypeChanged;

	private bool _isImageFitHorizontalAlignmentChanged;

	private bool _isImageFitVerticalAlignmentChanged;

	private bool _isSpriteChanged;

	private bool _isColorChanged;

	private bool _isColorFactorChanged;

	private bool _isAlphaFactorChanged;

	private bool _isHueFactorChanged;

	private bool _isSaturationFactorChanged;

	private bool _isValueFactorChanged;

	private bool _isIsHiddenChanged;

	private bool _isXOffsetChanged;

	private bool _isYOffsetChanged;

	private bool _isRotationChanged;

	private bool _isExtendLeftChanged;

	private bool _isExtendRightChanged;

	private bool _isExtendTopChanged;

	private bool _isExtendBottomChanged;

	private bool _isOverridenWidthChanged;

	private bool _isOverridenHeightChanged;

	private bool _isWidthPolicyChanged;

	private bool _isHeightPolicyChanged;

	private bool _isHorizontalFlipChanged;

	private bool _isVerticalFlipChanged;

	private bool _isOverlayMethodChanged;

	private bool _isOverlaySpriteChanged;

	private bool _isUseOverlayAlphaAsMaskChanged;

	private bool _isOverlayXOffsetChanged;

	private bool _isOverlayYOffsetChanged;

	private bool _isUseRandomBaseOverlayXOffset;

	private bool _isUseRandomBaseOverlayYOffset;

	private ImageFit.ImageFitTypes _imageFitType;

	private ImageFit.ImageHorizontalAlignments _imageFitHorizontalAlignment;

	private ImageFit.ImageVerticalAlignments _imageFitVerticalAlignment;

	private Sprite _sprite;

	private Color _color;

	private float _colorFactor;

	private float _alphaFactor;

	private float _hueFactor;

	private float _saturationFactor;

	private float _valueFactor;

	private bool _isHidden;

	private bool _useOverlayAlphaAsMask;

	private float _xOffset;

	private float _yOffset;

	private float _rotation;

	private float _extendLeft;

	private float _extendRight;

	private float _extendTop;

	private float _extendBottom;

	private float _overridenWidth;

	private float _overridenHeight;

	private BrushLayerSizePolicy _widthPolicy;

	private BrushLayerSizePolicy _heightPolicy;

	private bool _horizontalFlip;

	private bool _verticalFlip;

	private BrushOverlayMethod _overlayMethod;

	private Sprite _overlaySprite;

	private float _overlayXOffset;

	private float _overlayYOffset;

	private bool _useRandomBaseOverlayXOffset;

	private bool _useRandomBaseOverlayYOffset;

	public BrushLayer SourceLayer
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

	public uint Version
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[Editor(false)]
	public string Name
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
	public Sprite Sprite
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
	public ImageFit.ImageFitTypes ImageFitType
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
	public ImageFit.ImageHorizontalAlignments ImageFitHorizontalAlignment
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
	public ImageFit.ImageVerticalAlignments ImageFitVerticalAlignment
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
	public Color Color
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
	public float ColorFactor
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
	public float AlphaFactor
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
	public float HueFactor
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
	public float SaturationFactor
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
	public float ValueFactor
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
	public bool IsHidden
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
	public bool UseOverlayAlphaAsMask
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
	public float XOffset
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
	public float YOffset
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
	public float Rotation
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
	public float ExtendLeft
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
	public float ExtendRight
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
	public float ExtendTop
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
	public float ExtendBottom
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
	public float OverridenWidth
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
	public float OverridenHeight
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
	public BrushLayerSizePolicy WidthPolicy
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

	public BrushLayerSizePolicy HeightPolicy
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
	public bool HorizontalFlip
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
	public bool VerticalFlip
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
	public BrushOverlayMethod OverlayMethod
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
	public Sprite OverlaySprite
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
	public float OverlayXOffset
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
	public float OverlayYOffset
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
	public bool UseRandomBaseOverlayXOffset
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
	public bool UseRandomBaseOverlayYOffset
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
	public StyleLayer(BrushLayer brushLayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static StyleLayer CreateFrom(StyleLayer source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillFrom(StyleLayer source)
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
	public bool GetIsValueChanged(BrushAnimationProperty.BrushAnimationPropertyType propertyType)
	{
		throw null;
	}
}
