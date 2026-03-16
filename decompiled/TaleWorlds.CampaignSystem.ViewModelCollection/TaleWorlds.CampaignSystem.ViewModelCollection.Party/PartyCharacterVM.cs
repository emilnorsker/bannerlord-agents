using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Generic;
using TaleWorlds.Core.ViewModelCollection.ImageIdentifiers;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Party;

public class PartyCharacterVM : ViewModel
{
	public static bool IsShiftingDisabled;

	public static Action<PartyCharacterVM, bool> ProcessCharacterLock;

	public static Action<PartyCharacterVM> SetSelected;

	public static Action<PartyCharacterVM, int, int, PartyScreenLogic.PartyRosterSide> OnTransfer;

	public static Action<PartyCharacterVM> OnShift;

	public static Action<PartyCharacterVM> OnFocus;

	public readonly PartyScreenLogic.PartyRosterSide Side;

	public readonly PartyScreenLogic.TroopType Type;

	protected readonly PartyVM _partyVm;

	protected readonly PartyScreenLogic _partyScreenLogic;

	protected readonly bool _initIsTroopTransferable;

	private Tuple<bool, TextObject> _partyCharacterTalkPermission;

	private TroopRosterElement _troop;

	private CharacterObject _character;

	private string _name;

	private string _strNumOfUpgradableTroop;

	private string _strNumOfRecruitableTroop;

	private string _troopID;

	private string _upgradeCostText;

	private string _recruitMoraleCostText;

	private MBBindingList<UpgradeTargetVM> _upgrades;

	private CharacterImageIdentifierVM _code;

	private BasicTooltipViewModel _transferHint;

	private BasicTooltipViewModel _recruitPrisonerHint;

	private BasicTooltipViewModel _executePrisonerHint;

	private BasicTooltipViewModel _heroHealthHint;

	private HintViewModel _talkHint;

	private int _transferAmount;

	private int _index;

	private int _numOfReadyToUpgradeTroops;

	private int _numOfUpgradeableTroops;

	private int _numOfRecruitablePrisoners;

	private int _maxXP;

	private int _currentXP;

	private int _maxConformity;

	private int _currentConformity;

	private BasicTooltipViewModel _troopXPTooltip;

	private BasicTooltipViewModel _troopConformityTooltip;

	private bool _isHero;

	private bool _isMainHero;

	private bool _isPrisoner;

	private bool _isPrisonerOfPlayer;

	private bool _isRecruitablePrisoner;

	private bool _isUpgradableTroop;

	private bool _isTroopTransferrable;

	private bool _isHeroPrisonerOfPlayer;

	private bool _isTroopUpgradable;

	private StringItemWithHintVM _tierIconData;

	private bool _hasEnoughGold;

	private bool _anyUpgradeHasRequirement;

	private StringItemWithHintVM _typeIconData;

	private bool _isRecruitButtonsHiglighted;

	private bool _isTransferButtonHiglighted;

	private bool _isFormationEnabled;

	private PartyTradeVM _tradeData;

	private bool _isTroopRecruitable;

	private bool _isExecutable;

	private bool _isLocked;

	private HintViewModel _lockHint;

	private bool _isTalkableCharacter;

	private bool _canTalk;

	private bool _isSelected;

	public TroopRoster Troops
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

	public string StringId
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

	public TroopRosterElement Troop
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

	public CharacterObject Character
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
	public bool IsFormationEnabled
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
	public string TransferString
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsTroopUpgradable
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
	public bool IsTroopRecruitable
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
	public bool IsRecruitablePrisoner
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
	public bool IsUpgradableTroop
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
	public bool IsExecutable
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
	public int NumOfReadyToUpgradeTroops
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
	public int NumOfUpgradeableTroops
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
	public int NumOfRecruitablePrisoners
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
	public int MaxXP
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
	public int CurrentXP
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
	public int CurrentConformity
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
	public int MaxConformity
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
	public BasicTooltipViewModel TroopXPTooltip
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
	public BasicTooltipViewModel TroopConformityTooltip
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
	public BasicTooltipViewModel TransferHint
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
	public bool IsRecruitButtonsHiglighted
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
	public bool IsTransferButtonHiglighted
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
	public string StrNumOfUpgradableTroop
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
	public string StrNumOfRecruitableTroop
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
	public string TroopID
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
	public string UpgradeCostText
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
	public string RecruitMoraleCostText
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
	public int Index
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
	public int TransferAmount
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
	public bool IsTroopTransferrable
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
	public string Name
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
	public string TroopNum
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsHeroWounded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public int HeroHealth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public int Number
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public int WoundedCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public BasicTooltipViewModel RecruitPrisonerHint
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
	public CharacterImageIdentifierVM Code
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
	public BasicTooltipViewModel ExecutePrisonerHint
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
	public MBBindingList<UpgradeTargetVM> Upgrades
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
	public BasicTooltipViewModel HeroHealthHint
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
	public bool IsHero
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
	public bool IsMainHero
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
	public bool IsPrisoner
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
	public bool IsPrisonerOfPlayer
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
	public bool IsHeroPrisonerOfPlayer
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
	public bool AnyUpgradeHasRequirement
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
	public StringItemWithHintVM TierIconData
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
	public StringItemWithHintVM TypeIconData
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
	public bool HasEnoughGold
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
	public bool IsTalkableCharacter
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
	public bool CanTalk
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
	public HintViewModel TalkHint
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
	public PartyTradeVM TradeData
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
	public bool IsLocked
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
	public HintViewModel LockHint
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PartyCharacterVM(PartyScreenLogic partyScreenLogic, PartyVM partyVm, TroopRoster troops, int index, PartyScreenLogic.TroopType type, PartyScreenLogic.PartyRosterSide side, bool isTroopTransferrable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateTalkable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPartyCharacterTalkPermissionResult(bool isAvailable, TextObject reasonStr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetTransferHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetRecruitHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckTransferAmountDefaultValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSetSelected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteTalk()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateTradeData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateRecruitable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTradeApplyTransaction(int amount, bool isIncreasing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeUpgrades()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTransferred()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ThrowOnPropertyChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyTransfer(int transferAmount, PartyScreenLogic.PartyRosterSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteTransfer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteTransferAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSetFocused()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSetUnfocused()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteTransferSingle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteResetTrade()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Upgrade(int upgradeIndex, int maxUpgradeCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FocusUpgrade(UpgradeTargetVM upgrade)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RecruitAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteRecruitTroop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteExecuteTroop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteOpenTroopEncyclopedia()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CharacterCode GetCharacterCode(CharacterObject character, PartyScreenLogic.TroopType type, PartyScreenLogic.PartyRosterSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMoraleCost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsUpgradeButtonHighlighted(bool isHighlighted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumOfCategoryItemPartyHas(ItemRoster items, ItemCategory itemCategory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PartyCharacterVM()
	{
		throw null;
	}
}
