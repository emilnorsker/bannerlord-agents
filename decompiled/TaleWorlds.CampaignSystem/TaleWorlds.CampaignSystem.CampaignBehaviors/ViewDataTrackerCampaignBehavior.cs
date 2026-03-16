using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class ViewDataTrackerCampaignBehavior : CampaignBehaviorBase, IViewDataTracker
{
	private readonly TextObject _characterNotificationText;

	private readonly TextObject _questNotificationText;

	private readonly TextObject _recruitNotificationText;

	private Dictionary<CharacterObject, int> _examinedPrisonerCharacterList;

	private int _numOfRecruitablePrisoners;

	private List<JournalLog> _unExaminedQuestLogs;

	private IReadOnlyList<JournalLog> _unExaminedQuestLogsReadOnly;

	private readonly Dictionary<JournalLog, JournalLogEntry> _unExaminedQuestLogJournalEntries;

	private bool _isUnExaminedQuestLogJournalEntriesDirty;

	private List<Army> _unExaminedArmies;

	private bool _isCharacterNotificationActive;

	private int _numOfPerks;

	private bool _isMapBarExtended;

	private List<string> _inventoryItemLocks;

	[SaveableField(21)]
	private Dictionary<int, Tuple<int, int>> _inventorySortPreferences;

	private int _partySortType;

	private bool _isPartySortAscending;

	private List<string> _partyTroopLocks;

	private List<string> _partyPrisonerLocks;

	private List<Hero> _encyclopediaBookmarkedHeroes;

	private List<ShipHull> _encyclopediaBookmarkedShips;

	private List<Clan> _encyclopediaBookmarkedClans;

	private List<Concept> _encyclopediaBookmarkedConcepts;

	private List<Kingdom> _encyclopediaBookmarkedKingdoms;

	private List<Settlement> _encyclopediaBookmarkedSettlements;

	private List<CharacterObject> _encyclopediaBookmarkedUnits;

	private QuestBase _questSelection;

	[SaveableField(51)]
	private int _questSortTypeSelection;

	private List<ItemRosterElement> _plunderItems;

	private List<Figurehead> _unexaminedFigureheads;

	public bool IsPartyNotificationActive
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

	public bool IsQuestNotificationActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IReadOnlyList<JournalLog> UnExaminedQuestLogs
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public List<Army> UnExaminedArmies
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NumOfKingdomArmyNotifications
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsCharacterNotificationActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IReadOnlyList<Figurehead> UnexaminedFigureheads
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ViewDataTrackerCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetPartyNotificationText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearPartyNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdatePartyNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePrisonerRecruitValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetQuestNotificationText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnQuestLogExamined(JournalLog log)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestLogAdded(QuestBase obj, bool hideInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnIssueLogAdded(IssueBase obj, bool hideInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateJournalLogEntries()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnArmyExamined(Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnArmyDispersed(Army arg1, Army.ArmyDispersionReason arg2, bool isPlayersArmy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewArmyCreated(Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearCharacterNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetCharacterNotificationText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroGainedSkill(Hero hero, SkillObject skill, int change = 1, bool shouldNotify = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroLevelledUp(Hero hero, bool shouldNotify)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetMapBarExtendedState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMapBarExtendedState(bool isExtended)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInventoryLocks(IEnumerable<string> locks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<string> GetInventoryLocks()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InventorySetSortPreference(int inventoryMode, int sortOption, int sortState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Tuple<int, int> InventoryGetSortPreference(int inventoryMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPartyTroopLocks(IEnumerable<string> locks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPartyPrisonerLocks(IEnumerable<string> locks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPartySortType(int sortType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsPartySortAscending(bool isAscending)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<string> GetPartyTroopLocks()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<string> GetPartyPrisonerLocks()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPartySortType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsPartySortAscending()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEncyclopediaBookmarkToItem(Hero item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEncyclopediaBookmarkToItem(ShipHull shipHull)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEncyclopediaBookmarkToItem(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEncyclopediaBookmarkToItem(Concept concept)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEncyclopediaBookmarkToItem(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEncyclopediaBookmarkToItem(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEncyclopediaBookmarkToItem(CharacterObject unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEncyclopediaBookmarkFromItem(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEncyclopediaBookmarkFromItem(ShipHull shipHull)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEncyclopediaBookmarkFromItem(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEncyclopediaBookmarkFromItem(Concept concept)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEncyclopediaBookmarkFromItem(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEncyclopediaBookmarkFromItem(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEncyclopediaBookmarkFromItem(CharacterObject unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEncyclopediaBookmarked(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEncyclopediaBookmarked(ShipHull shipHull)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEncyclopediaBookmarked(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEncyclopediaBookmarked(Concept concept)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEncyclopediaBookmarked(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEncyclopediaBookmarked(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEncyclopediaBookmarked(CharacterObject unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetQuestSelection(QuestBase selection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public QuestBase GetQuestSelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<ItemRosterElement> GetPlunderItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFigureheadUnlocked(Figurehead newFigurehead)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFigureheadExamined(Figurehead figurehead)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRaidCompleted(BattleSideEnum winnerSide, RaidEventComponent raidEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerPlunderedItems(MobileParty mobileParty, ItemRoster items)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetQuestSortTypeSelection(int questSortTypeSelection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetQuestSortTypeSelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}
}
