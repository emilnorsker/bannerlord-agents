using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.CharacterCreation;

public class CharacterCreationStageSelectionBarListPanel : ListPanel
{
	private List<ButtonWidget> _stageButtonsList;

	private bool _buttonsInitialized;

	private ButtonWidget _stageButtonTemplate;

	private int _currentStageIndex;

	private int _totalStagesCount;

	private int _openedStageIndex;

	private string _fullButtonBrush;

	private string _emptyButtonBrush;

	private string _fullBrightButtonBrush;

	private Widget _barFillWidget;

	private Widget _barCanvasWidget;

	[Editor(false)]
	public ButtonWidget StageButtonTemplate
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
	public Widget BarFillWidget
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
	public Widget BarCanvasWidget
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
	public int CurrentStageIndex
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
	public int TotalStagesCount
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
	public int OpenedStageIndex
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
	public string FullButtonBrush
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
	public string EmptyButtonBrush
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
	public string FullBrightButtonBrush
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
	public CharacterCreationStageSelectionBarListPanel(UIContext context)
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
	private void RefreshButtonList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnStageSelection(Widget stageButton)
	{
		throw null;
	}
}
