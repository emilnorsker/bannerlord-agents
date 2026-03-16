using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI.BaseTypes;

public class ScrollablePanel : Widget
{
	protected class ScrollbarInterpolationController
	{
		private ScrollbarWidget _scrollbar;

		private float _targetValue;

		private float _duration;

		private bool _isInterpolating;

		private float _interpolationInitialValue;

		private float _timer;

		public bool IsInterpolating
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ScrollbarInterpolationController()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetControlledScrollbar(ScrollbarWidget scrollbar)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void StartInterpolation(float targetValue, float duration)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void StopInterpolation()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetValue()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Tick(float dt)
		{
			throw null;
		}
	}

	public class AutoScrollParameters
	{
		public float TopOffset;

		public float BottomOffset;

		public float LeftOffset;

		public float RightOffset;

		public float HorizontalScrollTarget;

		public float VerticalScrollTarget;

		public float InterpolationTime;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AutoScrollParameters(float topOffset = 0f, float bottomOffset = 0f, float leftOffset = 0f, float rightOffset = 0f, float horizontalScrollTarget = -1f, float verticalScrollTarget = -1f, float interpolationTime = 0f)
		{
			throw null;
		}
	}

	private Widget _innerPanel;

	protected bool _canScrollHorizontal;

	protected bool _canScrollVertical;

	public float ControllerScrollSpeed;

	public float MouseScrollSpeed;

	public AlignmentAxis MouseScrollAxis;

	private float _verticalScrollVelocity;

	private float _horizontalScrollVelocity;

	private bool _horizontalScrollbarChangedThisFrame;

	private bool _verticalScrollbarChangedThisFrame;

	protected float _scrollOffset;

	protected ScrollbarInterpolationController _verticalScrollbarInterpolationController;

	protected ScrollbarInterpolationController _horizontalScrollbarInterpolationController;

	private List<ScrollablePanelFixedHeaderWidget> _fixedHeaders;

	private ScrollbarWidget _horizontalScrollbar;

	private ScrollbarWidget _verticalScrollbar;

	private bool _autoHideScrollBars;

	private bool _autoHideScrollBarHandle;

	private bool _autoAdjustScrollbarHandleSize;

	private bool _onlyAcceptScrollEventIfCanScroll;

	private bool _reverseInitialScrollBarAlignment;

	public Widget ClipRect
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

	public Widget InnerPanel
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

	public ScrollbarWidget ActiveScrollbar
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool UpdateScrollbarVisibility
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

	public Widget FixedHeader
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

	public Widget ScrolledHeader
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
	public bool AutoHideScrollBars
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
	public bool AutoHideScrollBarHandle
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
	public bool AutoAdjustScrollbarHandleSize
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
	public bool OnlyAcceptScrollEventIfCanScroll
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
	public bool ReverseInitialScrollBarAlignment
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

	public ScrollbarWidget HorizontalScrollbar
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

	public ScrollbarWidget VerticalScrollbar
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

	public event Action<float> OnScroll
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
	public ScrollablePanel(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetTweenSpeed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnPreviewMouseScroll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnPreviewRightStickMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMouseScroll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnRightStickMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StopAllInterpolations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnInnerPanelChildAddedEventFire(Widget widget, string eventName, object[] eventArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnInnerPanelValueChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFixedHeaderPropertyChangedEventFire(Widget widget, string eventName, object[] eventArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshFixedHeaders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdjustVerticalScrollBar()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdjustHorizontalScrollBar()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SetActiveCursor(UIContext.MouseCursors cursor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateScrollInterpolation(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateScrollablePanel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected float GetScrollYValueForWidget(Widget widget, float widgetTargetYValue, float offset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected float GetScrollXValueForWidget(Widget widget, float widgetTargetXValue, float offset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float InverseLerp(float fromValue, float toValue, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ScrollToChild(Widget targetWidget, AutoScrollParameters scrollParameters = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVerticalScrollTarget(float targetValue, float interpolationDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHorizontalScrollTarget(float targetValue, float interpolationDuration)
	{
		throw null;
	}
}
