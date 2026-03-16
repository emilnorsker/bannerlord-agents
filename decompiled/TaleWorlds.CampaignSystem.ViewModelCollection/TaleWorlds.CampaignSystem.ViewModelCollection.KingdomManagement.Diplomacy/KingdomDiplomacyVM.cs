using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.Diplomacy;

public class KingdomDiplomacyVM : KingdomCategoryVM
{
	private readonly Action<KingdomDecision> _forceDecision;

	private readonly Kingdom _playerKingdom;

	private bool _isChangingDiplomacyItem;

	private MBBindingList<KingdomWarItemVM> _playerWars;

	private MBBindingList<KingdomTruceItemVM> _playerTruces;

	private KingdomWarSortControllerVM _warsSortController;

	private KingdomDiplomacyItemVM _currentSelectedItem;

	private SelectorVM<SelectorItemVM> _behaviorSelection;

	private HintViewModel _showStatBarsHint;

	private HintViewModel _showWarLogsHint;

	private string _playerWarsText;

	private string _numOfPlayerWarsText;

	private string _otherWarsText;

	private string _numOfOtherWarsText;

	private string _warsText;

	private string _behaviorSelectionTitle;

	private bool _isDisplayingWarLogs;

	private bool _isDisplayingStatComparisons;

	private bool _isWar;

	private MBBindingList<KingdomDiplomacyProposalActionItemVM> _actions;

	[DataSourceProperty]
	public MBBindingList<KingdomWarItemVM> PlayerWars
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
	public bool IsDisplayingWarLogs
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
	public bool IsDisplayingStatComparisons
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
	public bool IsWar
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
	public string BehaviorSelectionTitle
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
	public MBBindingList<KingdomTruceItemVM> PlayerTruces
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
	public KingdomDiplomacyItemVM CurrentSelectedDiplomacyItem
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
	public KingdomWarSortControllerVM WarsSortController
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
	public string PlayerWarsText
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
	public string WarsText
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
	public string NumOfPlayerWarsText
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
	public string PlayerTrucesText
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
	public string NumOfPlayerTrucesText
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
	public SelectorVM<SelectorItemVM> BehaviorSelection
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
	public HintViewModel ShowStatBarsHint
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
	public HintViewModel ShowWarLogsHint
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
	public MBBindingList<KingdomDiplomacyProposalActionItemVM> Actions
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
	public KingdomDiplomacyVM(Action<KingdomDecision> forceDecision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshDiplomacyList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SelectKingdom(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSetCurrentDiplomacyItem(KingdomDiplomacyItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSetWarItem(KingdomWarItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSetPeaceItem(KingdomTruceItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsProposingWarEnabledWithReason(KingdomTruceItemVM item, float actionInfluenceCost, out TextObject disabledReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsProposingPeaceEnabledWithReason(KingdomWarItemVM item, float actionInfluenceCost, out TextObject disabledReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsProposingAllianceEnabledWithReason(KingdomTruceItemVM item, float actionInfluenceCost, out TextObject disabledReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsProposingTradeAgreementEnabledWithReason(KingdomTruceItemVM item, float actionInfluenceCost, out TextObject disabledReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetAreProposalActionsEnabledWithReason(float actionInfluenceCost, out TextObject disabledReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshCurrentWarVisuals(KingdomDiplomacyItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDiplomacyItemSelection(KingdomDiplomacyItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDeclareWar(KingdomTruceItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDeclarePeace(KingdomWarItemVM item, int tributeToPay, int tributeDurationInDays)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnStartAlliance(KingdomTruceItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnStartTradeAgreement(KingdomTruceItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteShowWarLogs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteShowStatComparisons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetDefaultSelectedItem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateBehaviorSelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBehaviorSelectionChanged(SelectorVM<SelectorItemVM> s)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateWarSupport(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateAllianceSupport(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculatePeaceSupport(IFaction faction, int dailyTributeToBePaid, int durationInDays)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateTradeAgreementSupport(IFaction faction)
	{
		throw null;
	}
}
