using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;
using TaleWorlds.Library.EventSystem;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public class EventManager
{
	public const int MinParallelUpdateCount = 64;

	private const int DirtyCount = 2;

	private const float DragStartThreshold = 100f;

	private const float ScrollScale = 0.4f;

	public Rectangle2D AreaRectangle;

	private List<Action> _onAfterFinalizedCallbacks;

	private Widget _focusedWidget;

	private Widget _hoveredView;

	private List<Widget> _mouseOveredViews;

	private Widget _dragHoveredView;

	private Widget _latestMouseDownWidget;

	private Widget _latestMouseUpWidget;

	private Widget _latestMouseAlternateDownWidget;

	private Widget _latestMouseAlternateUpWidget;

	private int _measureDirty;

	private int _layoutDirty;

	private bool _positionsDirty;

	private const int _stickMovementScaleAmount = 3000;

	private Vector2 _lastClickPosition;

	private bool _mouseIsDown;

	private bool _mouseAlternateIsDown;

	private Vector2 _dragOffset;

	private Widget _draggedWidgetPreviousParent;

	private int _draggedWidgetIndex;

	private DragCarrierWidget _dragCarrier;

	private object _lateUpdateActionLocker;

	private Dictionary<int, List<UpdateAction>> _lateUpdateActions;

	private Dictionary<int, List<UpdateAction>> _lateUpdateActionsRunning;

	private Dictionary<WidgetContainer.ContainerType, WidgetContainer> _widgetContainers;

	private const int UpdateActionOrderCount = 5;

	private volatile bool _doingParallelTask;

	private TwoDimensionDrawContext _drawContext;

	private readonly TWParallel.ParallelForWithDtAuxPredicate ParallelUpdateWidgetPredicate;

	private readonly TWParallel.ParallelForWithDtAuxPredicate UpdateBrushesWidgetPredicate;

	private float _lastSetFrictionValue;

	private bool _isOnScreenKeyboardRequested;

	public Func<bool> OnGetIsHitThisFrame;

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

	public Vec2 UsableArea
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

	public float LeftUsableAreaStart
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

	public float TopUsableAreaStart
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

	public Vector2 PageSize
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

	public static TaleWorlds.Library.EventSystem.EventManager UIEventManager
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

	public Vector2 MousePositionInReferenceResolution
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsControllerActive
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

	public UIContext Context
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

	public Widget FocusedWidget
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

	public Widget HoveredView
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public List<Widget> MouseOveredViews
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public Widget DragHoveredView
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public Widget DraggedWidget
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

	public Vector2 DraggedWidgetPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Widget LatestMouseDownWidget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public Widget LatestMouseUpWidget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public Widget LatestMouseAlternateDownWidget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public Widget LatestMouseAlternateUpWidget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public Vector2 MousePosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong LocalFrameNumber
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsDragging
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float DeltaMouseScroll
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RightStickVerticalScrollAmount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RightStickHorizontalScrollAmount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal float CachedDt
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

	public event Action OnDragStarted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action OnDragEnded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action OnFocusedWidgetChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal EventManager(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAfterFinalizedCallback(Action callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnContextActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnContextDeactivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnWidgetConnectedToRoot(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnWidgetDisconnectedFromRoot(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RegisterWidgetForEvent(WidgetContainer.ContainerType type, Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UnRegisterWidgetForEvent(WidgetContainer.ContainerType type, Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnWidgetVisualDefinitionChanged(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MeasureAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LayoutAll(float left, float bottom, float right, float top)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void CalculateCanvas(Vector2 pageSize, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RecalculateCanvas()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void MouseDown()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void MouseUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void MouseAlternateDown()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void MouseAlternateUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void MouseScroll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RightStickMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearFocus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CancelAndReturnDrag()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearDragObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void MouseMove()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsPointInsideMeasuredArea(Widget w, Vector2 p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPointInsideUsableArea(Vector2 p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Widget GetWidgetAtMousePositionForEvent(GauntletEvent gauntletEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Widget GetWidgetAtPositionForEvent(GauntletEvent gauntletEvent, Vector2 pointerPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DispatchEvent(Widget selectedWidget, GauntletEvent gauntletEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HitTest(Widget widget, Vector2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool FocusTest(Widget root)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool AnyWidgetsAt(Widget widget, Vector2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CollectEnableWidgetsAt(Widget widget, Vector2 position, List<Widget> widgets)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CollectVisibleWidgetsAt(Widget widget, Vector2 position, List<Widget> widgets)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ManualAddRange(List<Widget> list, LinkedList<Widget> linked_list)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelUpdateWidget(int startInclusive, int endExclusive, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ParallelUpdateWidgets(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Update(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void DefragContainers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ParallelUpdateBrushes(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UpdateBrushes(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateBrushesWidget(int startInclusive, int endExclusive, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddLateUpdateAction(Widget owner, Action<float> action, int order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void LateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateDragCarrier()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHoveredView(Widget view)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BeginDragging(Widget draggedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Widget ReleaseDraggedWidget()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Render(TwoDimensionContext twoDimensionContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetMeasureDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetLayoutDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetPositionsDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsHitThisFrame()
	{
		throw null;
	}
}
