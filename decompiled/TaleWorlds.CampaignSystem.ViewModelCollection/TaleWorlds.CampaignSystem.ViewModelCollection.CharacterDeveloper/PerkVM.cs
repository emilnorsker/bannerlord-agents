using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;

public class PerkVM : ViewModel
{
	public enum PerkStates
	{
		None = -1,
		NotEarned,
		EarnedButNotSelected,
		InSelection,
		EarnedAndActive,
		EarnedAndNotActive,
		EarnedPreviousPerkNotSelected
	}

	public enum PerkAlternativeType
	{
		NoAlternative,
		FirstAlternative,
		SecondAlternative
	}

	public readonly PerkObject Perk;

	private readonly Action<PerkVM> _onStartSelection;

	private readonly Action<PerkVM> _onSelectionOver;

	private readonly Func<PerkObject, bool> _getIsPerkSelected;

	private readonly Func<PerkObject, bool> _getIsPreviousPerkSelected;

	private readonly bool _isAvailable;

	private readonly Concept _perkConceptObj;

	private bool _isInSelection;

	private PerkStates _currentState;

	private string _levelText;

	private string _perkId;

	private string _backgroundImage;

	private BasicTooltipViewModel _hint;

	private int _level;

	private int _alternativeType;

	private int _perkState;

	private bool _isTutorialHighlightEnabled;

	private bool _hasAlternativeAndSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public PerkStates CurrentState
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

	public bool IsInSelection
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsTutorialHighlightEnabled
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

	[DataSourceProperty]
	public BasicTooltipViewModel Hint
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

	[DataSourceProperty]
	public int Level
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

	[DataSourceProperty]
	public int PerkState
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

	[DataSourceProperty]
	public int AlternativeType
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

	[DataSourceProperty]
	public string LevelText
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

	[DataSourceProperty]
	public string BackgroundImage
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

	[DataSourceProperty]
	public string PerkId
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
	public PerkVM(PerkObject perk, bool isAvailable, PerkAlternativeType alternativeType, Action<PerkVM> onStartSelection, Action<PerkVM> onSelectionOver, Func<PerkObject, bool> getIsPerkSelected, Func<PerkObject, bool> getIsPreviousPerkSelected)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteShowPerkConcept()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteStartSelection()
	{
		throw null;
	}
}
