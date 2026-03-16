using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI.BaseTypes;

public class ButtonWidget : ImageWidget
{
	private enum ButtonClickState
	{
		None,
		HandlingClick,
		HandlingAlternateClick
	}

	protected const float _maxDoubleClickDeltaTimeInSeconds = 0.5f;

	protected float _lastClickTime;

	private ButtonClickState _clickState;

	private ButtonType _buttonType;

	public List<Action<Widget>> ClickEventHandlers;

	private Widget _toggleIndicator;

	private bool _isSelected;

	private bool _dominantSelectedState;

	[Editor(false)]
	public ButtonType ButtonType
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

	public bool IsToggle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsRadio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[Editor(false)]
	public Widget ToggleIndicator
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
	public bool IsSelected
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
	public bool DominantSelectedState
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
	protected override bool OnPreviewMousePressed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RefreshState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Refresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowHideToggle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ButtonWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMousePressed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMouseReleased()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsPointInsideMeasuredAreaAndCheckIfVisible()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMouseAlternatePressed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMouseAlternateReleased()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void HandleClick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void HandleAlternateClick()
	{
		throw null;
	}
}
