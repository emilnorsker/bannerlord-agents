using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.GauntletInput;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public class UIContext
{
	public enum MouseCursors
	{
		System,
		Default,
		Attack,
		Move,
		HorizontalResize,
		VerticalResize,
		DiagonalRightResize,
		DiagonalLeftResize,
		Rotate,
		Custom,
		Disabled,
		RightClickLink
	}

	private class DebugWidgetTreeNode
	{
		private readonly TwoDimensionContext _context;

		private readonly Widget _current;

		private readonly List<DebugWidgetTreeNode> _children;

		private readonly string _fullIDPath;

		private readonly string _displayedName;

		private readonly int _depth;

		private bool _isShowingArea;

		private string ID
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DebugWidgetTreeNode(TwoDimensionContext context, Widget current, int depth)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddChildren()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void DebugDraw()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void DrawProperties()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void DrawChildren()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void DrawArea()
		{
			throw null;
		}
	}

	private readonly float ReferenceHeight;

	private readonly float InverseReferenceHeight;

	private readonly float ReferenceAspectRatio;

	private const float ReferenceAspectRatioCoeff = 0.98f;

	private readonly GauntletInputContext _uiInputContext;

	private readonly IInputContext _inputContext;

	private bool _initializedWithExistingResources;

	private bool _previousFrameMouseEnabled;

	private bool _isMouseEnabled;

	private bool IsDebugWidgetInformationFroze;

	private DebugWidgetTreeNode _currentRootNode;

	public MouseCursors ActiveCursorOfContext
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

	public bool IsDynamicScaleEnabled
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

	public float ScaleModifier
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

	public bool IsActive
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

	public float ContextAlpha
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

	public float Scale
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

	public float CustomScale
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

	public float CustomInverseScale
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

	public string CurrentLanugageCode
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

	public Random UIRandom
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

	public float InverseScale
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

	public EventManager EventManager
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

	public Widget Root
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ResourceDepot ResourceDepot
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TwoDimensionContext TwoDimensionContext
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

	public IEnumerable<Brush> Brushes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Brush DefaultBrush
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public SpriteData SpriteData
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

	public BrushFactory BrushFactory
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

	public FontFactory FontFactory
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

	public IReadonlyInputContext InputContext
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IGamepadNavigationContext GamepadNavigation
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

	public ulong LocalFrameNumber
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
	public UIContext(TwoDimensionContext twoDimensionContext, IInputContext inputContext, SpriteData spriteData, FontFactory fontFactory, BrushFactory brushFactory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIContext(TwoDimensionContext twoDimensionContext, IInputContext inputContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Brush GetBrush(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshResources(SpriteData spriteData, FontFactory fontFactory, BrushFactory brushFactory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Activate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeGamepadNavigation(IGamepadNavigationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateScale()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnOnScreenkeyboardTextInputDone(string inputText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnOnScreenKeyboardCanceled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HitTest(Widget root, Vector2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HitTest(Widget root)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool FocusTest(Widget root)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsMouseEnabled(bool isMouseEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateInput(InputType handleInputs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMovieLoaded(string movieName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMovieReleased(string movieName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReleaseMouseWithoutClick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrawWidgetDebugInfo()
	{
		throw null;
	}
}
