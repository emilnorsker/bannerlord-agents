using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Party;

public class PartyHeaderToggleWidget : ToggleButtonWidget
{
	private int _latestChildCount;

	private ListPanel _listPanel;

	private ButtonWidget _transferButtonWidget;

	private BrushWidget _collapseIndicator;

	private bool _isRelevant;

	private bool _blockInputsWhenDisabled;

	public bool AutoToggleTransferButtonState
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
	public ListPanel ListPanel
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
	public ButtonWidget TransferButtonWidget
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
	public BrushWidget CollapseIndicator
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
	public bool IsRelevant
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
	public bool BlockInputsWhenDisabled
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
	public PartyHeaderToggleWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnClick(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnListSizeChange(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnListSizeChange(Widget parentWidget, Widget addedWidget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetState(string stateName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ListPanelUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TransferButtonUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollapseIndicatorUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCollapseIndicator()
	{
		throw null;
	}
}
