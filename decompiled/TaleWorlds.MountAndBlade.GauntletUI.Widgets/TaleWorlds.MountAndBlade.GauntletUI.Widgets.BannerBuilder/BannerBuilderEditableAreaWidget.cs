using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.BannerBuilder;

public class BannerBuilderEditableAreaWidget : Widget
{
	private enum BuilderMode
	{
		None,
		Rotating,
		Positioning,
		HorizontalResizing,
		VerticalResizing,
		RightCornerResizing
	}

	private enum WidgetPlacementType
	{
		Horizontal,
		Vertical,
		Max
	}

	private enum EdgeResizeType
	{
		Top,
		Right
	}

	private bool _initialized;

	private Vec2 _centerOfSigil;

	private Vec2 _sizeOfSigil;

	private float _positionLimitMin;

	private float _positionLimitMax;

	private float _areaScale;

	private const int _sizeLimitMin = 2;

	private int _sizeLimitMax;

	private BuilderMode _currentMode;

	private Vector2 _latestMousePosition;

	private Vector2 _resizeStartMousePosition;

	private Widget _resizeStartWidget;

	private Vec2 _resizeStartSize;

	private bool _isLayerPattern;

	private Vec2 _positionValue;

	private Vec2 _sizeValue;

	private float _rotationValue;

	private int _editableAreaSize;

	private int _totalAreaSize;

	public ButtonWidget DragWidgetTopRight
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

	public ButtonWidget DragWidgetRight
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

	public ButtonWidget DragWidgetTop
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

	public ButtonWidget RotateWidget
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

	public BannerTableauWidget BannerTableauWidget
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

	public Widget EditableAreaVisualWidget
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

	public int LayerIndex
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

	public bool IsMirrorActive
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
	public bool IsLayerPattern
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
	public Vec2 PositionValue
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
	public Vec2 SizeValue
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
	public float RotationValue
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
	public int EditableAreaSize
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
	public int TotalAreaSize
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
	public BannerBuilderEditableAreaWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateRequiredValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePositioning()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleRotation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleForEdge(EdgeResizeType resizeType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleForCorner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleCursor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateEditableAreaVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ButtonWidget GetWidgetFor(EdgeResizeType edgeResizeType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePositionOfWidget(Widget widget, WidgetPlacementType placementType, float directionFromCenter, float distanceFromCenterModifier, float distanceFromEdgesModifier = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyPositionOffsetToWidget(Widget widget, Vec2 pos, float additionalModifier = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnIsLayerPatternChanged(bool isLayerPattern)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPositionChanged(Vec2 newPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSizeChanged(Vec2 newSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRotationChanged(float newRotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vec2 DirFromAngle(float angle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float AngleFromDir(Vec2 directionVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float AngleOffsetForEdge(EdgeResizeType edge)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float AngleOffsetForCorner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vec2 TransformToParent(Vec2 a, Vec2 b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vector2 TransformToParent(Vector2 a, Vec2 b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vector2 TransformToParent(Vec2 a, Vector2 b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vector2 TransformToParent(Vector2 a, Vector2 b)
	{
		throw null;
	}
}
