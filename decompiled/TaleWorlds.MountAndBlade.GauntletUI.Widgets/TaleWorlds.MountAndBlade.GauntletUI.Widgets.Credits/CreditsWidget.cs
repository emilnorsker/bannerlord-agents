using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Credits;

public class CreditsWidget : Widget
{
	private float _currentOffset;

	private float _targetOffset;

	private float _doNotScrollTimer;

	private Widget _rootItemWidget;

	private float _scrollPixelsPerSecond;

	private float _manualScrollWaitTimer;

	[Editor(false)]
	public Widget RootItemWidget
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
	public float ScrollPixelsPerSecond
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
	public float ManualScrollWaitTimer
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
	public CreditsWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
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
	protected override void OnMouseScroll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRightStickMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnScroll(float scrollAmount)
	{
		throw null;
	}
}
