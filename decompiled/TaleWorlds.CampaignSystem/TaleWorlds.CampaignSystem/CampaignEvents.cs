using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Helpers;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.BarterSystem;
using TaleWorlds.CampaignSystem.BarterSystem.Barterables;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.CampaignSystem.CraftingSystem;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Incidents;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Buildings;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem;

public class CampaignEvents : CampaignEventReceiver
{
	private readonly MbEvent _onPlayerBodyPropertiesChangedEvent;

	private readonly MbEvent<BarterData> _barterablesRequested;

	private readonly MbEvent<Hero, bool> _heroLevelledUp;

	private readonly MbEvent<BanditPartyComponent, Hideout> _onHomeHideoutChangedEvent;

	private readonly MbEvent<Hero, SkillObject, int, bool> _heroGainedSkill;

	private readonly MbEvent _onCharacterCreationIsOverEvent;

	private readonly MbEvent<Hero, bool> _onHeroCreated;

	private readonly MbEvent<Hero, Occupation> _heroOccupationChangedEvent;

	private readonly MbEvent<Hero> _onHeroWounded;

	private readonly MbEvent<Hero, Hero, List<Barterable>> _onBarterAcceptedEvent;

	private readonly MbEvent<Hero, Hero, List<Barterable>> _onBarterCanceledEvent;

	private readonly MbEvent<Hero, Hero, int, bool, ChangeRelationAction.ChangeRelationDetail, Hero, Hero> _heroRelationChanged;

	private readonly MbEvent<QuestBase, bool> _questLogAddedEvent;

	private readonly MbEvent<IssueBase, bool> _issueLogAddedEvent;

	private readonly MbEvent<Clan, bool> _clanTierIncrease;

	private readonly MbEvent<Clan, Kingdom, Kingdom, ChangeKingdomAction.ChangeKingdomActionDetail, bool> _clanChangedKingdom;

	private readonly MbEvent<Clan, Kingdom, Kingdom> _onClanDefected;

	private readonly MbEvent<Clan, bool> _onClanCreatedEvent;

	private readonly MbEvent<Hero, MobileParty> _onHeroJoinedPartyEvent;

	private readonly MbEvent<(Hero, PartyBase), (Hero, PartyBase), (int, string), bool> _heroOrPartyTradedGold;

	private readonly MbEvent<(Hero, PartyBase), (Hero, PartyBase), ItemRosterElement, bool> _heroOrPartyGaveItem;

	private readonly MbEvent<MobileParty> _banditPartyRecruited;

	private readonly MbEvent<KingdomDecision, bool> _kingdomDecisionAdded;

	private readonly MbEvent<KingdomDecision, bool> _kingdomDecisionCancelled;

	private readonly MbEvent<KingdomDecision, DecisionOutcome, bool> _kingdomDecisionConcluded;

	private readonly MbEvent<MobileParty> _partyAttachedParty;

	private readonly MbEvent<MobileParty> _nearbyPartyAddedToPlayerMapEvent;

	private readonly MbEvent<Army> _armyCreated;

	private readonly MbEvent<Army, Army.ArmyDispersionReason, bool> _armyDispersed;

	private readonly MbEvent<Army, IMapPoint> _armyGathered;

	private readonly MbEvent<Hero, PerkObject> _perkOpenedEvent;

	private readonly MbEvent<Hero, PerkObject> _perkResetEvent;

	private readonly MbEvent<TraitObject, int> _playerTraitChangedEvent;

	private readonly MbEvent<Village, Village.VillageStates, Village.VillageStates, MobileParty> _villageStateChanged;

	private readonly MbEvent<MobileParty, Settlement, Hero> _settlementEntered;

	private readonly MbEvent<MobileParty, Settlement, Hero> _afterSettlementEntered;

	private readonly MbEvent<MobileParty, Settlement, Hero> _beforeSettlementEntered;

	private readonly MbEvent<Town, CharacterObject, CharacterObject> _mercenaryTroopChangedInTown;

	private readonly MbEvent<Town, int, int> _mercenaryNumberChangedInTown;

	private readonly MbEvent<Alley, Hero, Hero> _alleyOwnerChanged;

	private readonly MbEvent<Alley, TroopRoster> _alleyOccupiedByPlayer;

	private readonly MbEvent<Alley> _alleyClearedByPlayer;

	private readonly MbEvent<Hero, Hero, Romance.RomanceLevelEnum> _romanticStateChanged;

	private readonly MbEvent<Hero, Hero, bool> _beforeHeroesMarried;

	private readonly MbEvent<int, Town> _playerEliminatedFromTournament;

	private readonly MbEvent<Town> _playerStartedTournamentMatch;

	private readonly MbEvent<Town> _tournamentStarted;

	private readonly MbEvent<IFaction, IFaction, DeclareWarAction.DeclareWarDetail> _warDeclared;

	private readonly MbEvent<CharacterObject, MBReadOnlyList<CharacterObject>, Town, ItemObject> _tournamentFinished;

	private readonly MbEvent<Town> _tournamentCancelled;

	private readonly MbEvent<PartyBase, PartyBase, object, bool> _battleStarted;

	private readonly MbEvent<Settlement, Clan> _rebellionFinished;

	private readonly MbEvent<Town, bool> _townRebelliousStateChanged;

	private readonly MbEvent<Settlement, Clan> _rebelliousClanDisbandedAtSettlement;

	private readonly MbEvent<MobileParty, ItemRoster> _itemsLooted;

	private readonly MbEvent<MobileParty, PartyBase> _mobilePartyDestroyed;

	private readonly MbEvent<MobileParty> _mobilePartyCreated;

	private readonly MbEvent<IInteractablePoint> _mapInteractableCreated;

	private readonly MbEvent<IInteractablePoint> _mapInteractableDestroyed;

	private readonly MbEvent<MobileParty, bool> _mobilePartyQuestStatusChanged;

	private readonly MbEvent<Hero, Hero, KillCharacterAction.KillCharacterActionDetail, bool> _heroKilled;

	private readonly MbEvent<Hero, Hero, KillCharacterAction.KillCharacterActionDetail, bool> _onBeforeHeroKilled;

	private readonly MbEvent<Hero, int> _childEducationCompleted;

	private readonly MbEvent<Hero> _heroComesOfAge;

	private readonly MbEvent<Hero> _heroGrowsOutOfInfancyEvent;

	private readonly MbEvent<Hero> _heroReachesTeenAgeEvent;

	private readonly MbEvent<Hero, Hero> _characterDefeated;

	private readonly MbEvent<Kingdom, Clan> _rulingClanChanged;

	private readonly MbEvent<PartyBase, Hero> _heroPrisonerTaken;

	private readonly MbEvent<Hero, PartyBase, IFaction, EndCaptivityDetail, bool> _heroPrisonerReleased;

	private readonly MbEvent<Hero, bool> _characterBecameFugitiveEvent;

	private readonly MbEvent<Hero> _playerMetHero;

	private readonly MbEvent<Hero> _playerLearnsAboutHero;

	private readonly MbEvent<Hero, int, bool> _renownGained;

	private readonly MbEvent<IFaction, float> _crimeRatingChanged;

	private readonly MbEvent<Hero> _newCompanionAdded;

	private readonly MbEvent<IMission> _afterMissionStarted;

	private readonly MbEvent<MenuCallbackArgs> _gameMenuOpened;

	private readonly MbEvent<MenuCallbackArgs> _afterGameMenuInitializedEvent;

	private readonly MbEvent<MenuCallbackArgs> _beforeGameMenuOpenedEvent;

	private readonly MbEvent<IFaction, IFaction, MakePeaceAction.MakePeaceDetail> _makePeace;

	private readonly MbEvent<Kingdom> _kingdomDestroyed;

	private readonly ReferenceMBEvent<Kingdom, bool> _canKingdomBeDiscontinued;

	private readonly MbEvent<Kingdom> _kingdomCreated;

	private readonly MbEvent<Village> _villageBecomeNormal;

	private readonly MbEvent<Village> _villageBeingRaided;

	private readonly MbEvent<Village> _villageLooted;

	private readonly MbEvent<Hero, RemoveCompanionAction.RemoveCompanionDetail> _companionRemoved;

	private readonly MbEvent<IAgent> _onAgentJoinedConversationEvent;

	private readonly MbEvent<IEnumerable<CharacterObject>> _onConversationEnded;

	private readonly MbEvent<MapEvent> _mapEventEnded;

	private readonly MbEvent<MapEvent, PartyBase, PartyBase> _mapEventStarted;

	private readonly MbEvent<Settlement, FlattenedTroopRoster, Hero, bool> _prisonersChangeInSettlement;

	private readonly MbEvent<Hero, BoardGameHelper.BoardGameState> _onPlayerBoardGameOver;

	private readonly MbEvent<Hero> _onRansomOfferedToPlayer;

	private readonly MbEvent<Hero> _onRansomOfferCancelled;

	private readonly MbEvent<IFaction, int, int> _onPeaceOfferedToPlayer;

	private readonly MbEvent<Kingdom, Kingdom> _onTradeAgreementSignedEvent;

	private readonly MbEvent<IFaction> _onPeaceOfferResolved;

	private readonly MbEvent<Hero, Hero> _onMarriageOfferedToPlayerEvent;

	private readonly MbEvent<Hero, Hero> _onMarriageOfferCanceledEvent;

	private readonly MbEvent<Kingdom> _onVassalOrMercenaryServiceOfferedToPlayerEvent;

	private readonly MbEvent<Kingdom> _onVassalOrMercenaryServiceOfferCanceledEvent;

	private readonly MbEvent<Clan, StartMercenaryServiceAction.StartMercenaryServiceActionDetails> _onMercenaryServiceStartedEvent;

	private readonly MbEvent<Clan, EndMercenaryServiceAction.EndMercenaryServiceActionDetails> _onMercenaryServiceEndedEvent;

	private readonly MbEvent<IMission> _onMissionStartedEvent;

	private readonly MbEvent _beforeMissionOpenedEvent;

	private readonly MbEvent<PartyBase> _onPartyRemovedEvent;

	private readonly MbEvent<PartyBase> _onPartySizeChangedEvent;

	private readonly MbEvent<Settlement, bool, Hero, Hero, Hero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail> _onSettlementOwnerChangedEvent;

	private readonly MbEvent<Town, Hero, Hero> _onGovernorChangedEvent;

	private readonly MbEvent<MobileParty, Settlement> _onSettlementLeftEvent;

	private readonly MbEvent _weeklyTickEvent;

	private readonly MbEvent _dailyTickEvent;

	private readonly MbEvent<MobileParty> _dailyTickPartyEvent;

	private readonly MbEvent<Town> _dailyTickTownEvent;

	private readonly MbEvent<Settlement> _dailyTickSettlementEvent;

	private readonly MbEvent<Hero> _dailyTickHeroEvent;

	private readonly MbEvent<Clan> _dailyTickClanEvent;

	private readonly MbEvent<List<CampaignTutorial>> _collectAvailableTutorialsEvent;

	private readonly MbEvent<string> _onTutorialCompletedEvent;

	private readonly MbEvent<Town, Building, int> _onBuildingLevelChangedEvent;

	private readonly MbEvent _hourlyTickEvent;

	private readonly MbEvent _quarterHourlyTickEvent;

	private readonly MbEvent<MobileParty> _hourlyTickPartyEvent;

	private readonly MbEvent<Settlement> _hourlyTickSettlementEvent;

	private readonly MbEvent<Clan> _hourlyTickClanEvent;

	private readonly MbEvent<float> _tickEvent;

	private readonly MbEvent<CampaignGameStarter> _onSessionLaunchedEvent;

	private readonly MbEvent<CampaignGameStarter> _onAfterSessionLaunchedEvent;

	public const int OnNewGameCreatedPartialFollowUpEventMaxIndex = 100;

	private readonly MbEvent<CampaignGameStarter> _onNewGameCreatedEvent;

	private readonly MbEvent<CampaignGameStarter, int> _onNewGameCreatedPartialFollowUpEvent;

	private readonly MbEvent<CampaignGameStarter> _onNewGameCreatedPartialFollowUpEndEvent;

	private readonly MbEvent<CampaignGameStarter> _onGameEarlyLoadedEvent;

	private readonly MbEvent<CampaignGameStarter> _onGameLoadedEvent;

	private readonly MbEvent _onGameLoadFinishedEvent;

	private readonly MbEvent<MobileParty, PartyThinkParams> _aiHourlyTickEvent;

	private readonly MbEvent<MobileParty> _tickPartialHourlyAiEvent;

	private readonly MbEvent<MobileParty> _onPartyJoinedArmyEvent;

	private readonly MbEvent<MobileParty> _onPartyRemovedFromArmyEvent;

	private readonly MbEvent _onPlayerArmyLeaderChangedBehaviorEvent;

	private readonly MbEvent<IMission> _onMissionEndedEvent;

	private readonly MbEvent<MobileParty> _onQuarterDailyPartyTick;

	private readonly MbEvent<MapEvent> _onPlayerBattleEndEvent;

	private readonly MbEvent<CharacterObject, int> _onUnitRecruitedEvent;

	private readonly MbEvent<Hero> _onChildConceived;

	private readonly MbEvent<Hero, List<Hero>, int> _onGivenBirthEvent;

	private readonly MbEvent<float> _missionTickEvent;

	private MbEvent _armyOverlaySetDirty;

	private readonly MbEvent<int> _playerDesertedBattle;

	private MbEvent<PartyBase> _partyVisibilityChanged;

	private readonly MbEvent<Track> _trackDetectedEvent;

	private readonly MbEvent<Track> _trackLostEvent;

	private readonly MbEvent<Dictionary<string, int>> _locationCharactersAreReadyToSpawn;

	private readonly ReferenceMBEvent<MatrixFrame> _onBeforePlayerAgentSpawn;

	private readonly MbEvent _onPlayerAgentSpawned;

	private readonly MbEvent _locationCharactersSimulatedSpawned;

	private readonly MbEvent<CharacterObject, CharacterObject, int> _playerUpgradedTroopsEvent;

	private readonly MbEvent<CharacterObject, CharacterObject, PartyBase, WeaponComponentData, bool, int> _onHeroCombatHitEvent;

	private readonly MbEvent<CharacterObject> _characterPortraitPopUpOpenedEvent;

	private CampaignTimeControlMode _timeControlModeBeforePopUpOpened;

	private readonly MbEvent _characterPortraitPopUpClosedEvent;

	private readonly MbEvent<Hero> _playerStartTalkFromMenu;

	private readonly MbEvent<GameMenu, GameMenuOption> _gameMenuOptionSelectedEvent;

	private readonly MbEvent<CharacterObject> _playerStartRecruitmentEvent;

	private readonly MbEvent<Hero, Hero> _onBeforePlayerCharacterChangedEvent;

	private readonly MbEvent<Hero, Hero, MobileParty, bool> _onPlayerCharacterChangedEvent;

	private readonly MbEvent<Hero, Hero> _onClanLeaderChangedEvent;

	private readonly MbEvent<SiegeEvent> _onSiegeEventStartedEvent;

	private readonly MbEvent _onPlayerSiegeStartedEvent;

	private readonly MbEvent<SiegeEvent> _onSiegeEventEndedEvent;

	private readonly MbEvent<MobileParty, Settlement, SiegeAftermathAction.SiegeAftermath, Clan, Dictionary<MobileParty, float>> _siegeAftermathAppliedEvent;

	private readonly MbEvent<MobileParty, Settlement, BattleSideEnum, SiegeEngineType, SiegeBombardTargets> _onSiegeBombardmentHitEvent;

	private readonly MbEvent<MobileParty, Settlement, BattleSideEnum, SiegeEngineType, bool> _onSiegeBombardmentWallHitEvent;

	private readonly MbEvent<MobileParty, Settlement, BattleSideEnum, SiegeEngineType> _onSiegeEngineDestroyedEvent;

	private readonly MbEvent<List<TradeRumor>, Settlement> _onTradeRumorIsTakenEvent;

	private readonly MbEvent<Hero> _onCheckForIssueEvent;

	private readonly MbEvent<IssueBase, IssueBase.IssueUpdateDetails, Hero> _onIssueUpdatedEvent;

	private readonly MbEvent<MobileParty, TroopRoster> _onTroopsDesertedEvent;

	private readonly MbEvent<Hero, Settlement, Hero, CharacterObject, int> _onTroopRecruitedEvent;

	private readonly MbEvent<Hero, Settlement, TroopRoster> _onTroopGivenToSettlementEvent;

	private readonly MbEvent<PartyBase, PartyBase, ItemRosterElement, int, Settlement> _onItemSoldEvent;

	private readonly MbEvent<MobileParty, Town, List<(EquipmentElement, int)>> _onCaravanTransactionCompletedEvent;

	private readonly MbEvent<PartyBase, PartyBase, TroopRoster> _onPrisonerSoldEvent;

	private readonly MbEvent<MobileParty> _onPartyDisbandStartedEvent;

	private readonly MbEvent<MobileParty, Settlement> _onPartyDisbandedEvent;

	private readonly MbEvent<MobileParty> _onPartyDisbandCanceledEvent;

	private readonly MbEvent<PartyBase, PartyBase> _hideoutSpottedEvent;

	private readonly MbEvent<Settlement> _hideoutDeactivatedEvent;

	private readonly MbEvent<Hero, Hero, float> _heroSharedFoodWithAnotherHeroEvent;

	private readonly MbEvent<List<(ItemRosterElement, int)>, List<(ItemRosterElement, int)>, bool> _playerInventoryExchangeEvent;

	private readonly MbEvent<ItemRoster> _onItemsDiscardedByPlayerEvent;

	private readonly MbEvent<Tuple<PersuasionOptionArgs, PersuasionOptionResult>> _persuasionProgressCommittedEvent;

	private readonly MbEvent<QuestBase, QuestBase.QuestCompleteDetails> _onQuestCompletedEvent;

	private readonly MbEvent<QuestBase> _onQuestStartedEvent;

	private readonly MbEvent<ItemObject, Settlement, int> _itemProducedEvent;

	private readonly MbEvent<ItemObject, Settlement, int> _itemConsumedEvent;

	private readonly MbEvent<MobileParty> _onPartyConsumedFoodEvent;

	private readonly MbEvent<Hero, Hero, KillCharacterAction.KillCharacterActionDetail, bool> _onBeforeMainCharacterDiedEvent;

	private readonly MbEvent<IssueBase> _onNewIssueCreatedEvent;

	private readonly MbEvent<IssueBase, Hero> _onIssueOwnerChangedEvent;

	private readonly MbEvent _onGameOverEvent;

	private readonly MbEvent<Settlement, MobileParty, bool, MapEvent.BattleTypes> _siegeCompletedEvent;

	private readonly MbEvent<Settlement, MobileParty, bool, MapEvent.BattleTypes> _afterSiegeCompletedEvent;

	private readonly MbEvent<SiegeEvent, BattleSideEnum, SiegeEngineType> _siegeEngineBuiltEvent;

	private readonly MbEvent<BattleSideEnum, RaidEventComponent> _raidCompletedEvent;

	private readonly MbEvent<BattleSideEnum, ForceVolunteersEventComponent> _forceVolunteersCompletedEvent;

	private readonly MbEvent<BattleSideEnum, ForceSuppliesEventComponent> _forceSuppliesCompletedEvent;

	private readonly MbEvent<BattleSideEnum, HideoutEventComponent> _hideoutBattleCompletedEvent;

	private readonly MbEvent<Clan> _onClanDestroyedEvent;

	private readonly MbEvent<ItemObject, ItemModifier, bool> _onNewItemCraftedEvent;

	private readonly MbEvent<CraftingPiece> _craftingPartUnlockedEvent;

	private readonly MbEvent<Workshop> _onWorkshopInitializedEvent;

	private readonly MbEvent<Workshop, Hero> _onWorkshopOwnerChangedEvent;

	private readonly MbEvent<Workshop> _onWorkshopTypeChangedEvent;

	private readonly MbEvent _onBeforeSaveEvent;

	private readonly MbEvent _onSaveStartedEvent;

	private readonly MbEvent<bool, string> _onSaveOverEvent;

	private readonly MbEvent<FlattenedTroopRoster> _onPrisonerTakenEvent;

	private readonly MbEvent<FlattenedTroopRoster> _onPrisonerReleasedEvent;

	private readonly MbEvent<FlattenedTroopRoster> _onMainPartyPrisonerRecruitedEvent;

	private readonly MbEvent<MobileParty, FlattenedTroopRoster, Settlement> _onPrisonerDonatedToSettlementEvent;

	private readonly MbEvent<Hero, EquipmentElement> _onEquipmentSmeltedByHero;

	private readonly MbEvent<int> _onPlayerTradeProfit;

	private readonly MbEvent<Hero, Clan> _onHeroChangedClan;

	private readonly MbEvent<Hero, HeroGetsBusyReasons> _onHeroGetsBusy;

	private readonly MbEvent<PartyBase, ItemRoster> _onCollectLootItems;

	private readonly MbEvent<PartyBase, PartyBase, ItemRoster> _onLootDistributedToPartyEvent;

	private readonly MbEvent<Hero, Settlement, MobileParty, TeleportHeroAction.TeleportationDetail> _onHeroTeleportationRequestedEvent;

	private readonly MbEvent<MobileParty> _onPartyLeaderChangeOfferCanceledEvent;

	private readonly MbEvent<MobileParty, Hero> _onPartyLeaderChangedEvent;

	private readonly MbEvent<Clan, float> _onClanInfluenceChangedEvent;

	private readonly MbEvent<CharacterObject> _onPlayerPartyKnockedOrKilledTroopEvent;

	private readonly MbEvent<DefaultClanFinanceModel.AssetIncomeType, int> _onPlayerEarnedGoldFromAssetEvent;

	private readonly MbEvent<Clan, IFaction> _onClanEarnedGoldFromTributeEvent;

	private readonly MbEvent _onMainPartyStarving;

	private readonly MbEvent<Town, bool> _onPlayerJoinedTournamentEvent;

	private readonly MbEvent<Hero> _onHeroUnregisteredEvent;

	private readonly MbEvent _onConfigChanged;

	private readonly MbEvent<Town, CraftingOrder, ItemObject, Hero> _onCraftingOrderCompleted;

	private readonly MbEvent<Hero, Crafting.RefiningFormula> _onItemsRefined;

	private readonly MbEvent<Dictionary<Hero, int>> _onHeirSelectionRequested;

	private readonly MbEvent<Hero> _onHeirSelectionOver;

	private readonly MbEvent<MobileParty> _onMobilePartyRaftStateChanged;

	private readonly MbEvent<CharacterCreationManager> _onCharacterCreationInitialized;

	private readonly MbEvent<PartyBase, Ship, DestroyShipAction.ShipDestroyDetail> _onShipDestroyedEvent;

	private readonly MbEvent<Ship, PartyBase, ChangeShipOwnerAction.ShipOwnerChangeDetail> _onShipOwnerChangedEvent;

	private readonly MbEvent<Ship, Settlement> _onShipRepairedEvent;

	private readonly MbEvent<Ship, Settlement> _onShipCreatedEvent;

	private readonly MbEvent<Figurehead> _onFigureheadUnlockedEvent;

	private readonly MbEvent<MobileParty, Army> _onPartyLeftArmyEvent;

	private readonly MbEvent<PartyBase> _onPartyAddedToMapEventEvent;

	private readonly MbEvent<Incident> _onIncidentResolvedEvent;

	private readonly MbEvent<MobileParty> _onMobilePartyNavigationStateChangedEvent;

	private readonly MbEvent<MobileParty> _onMobilePartyJoinedToSiegeEventEvent;

	private readonly MbEvent<MobileParty> _onMobilePartyLeftSiegeEventEvent;

	private readonly MbEvent<SiegeEvent> _onBlockadeActivatedEvent;

	private readonly MbEvent<SiegeEvent> _onBlockadeDeactivatedEvent;

	private readonly MbEvent<MapMarker> _onMapMarkerCreatedEvent;

	private readonly MbEvent<MapMarker> _onMapMarkerRemovedEvent;

	private readonly MbEvent<Kingdom, Kingdom> _onAllianceStartedEvent;

	private readonly MbEvent<Kingdom, Kingdom> _onAllianceEndedEvent;

	private readonly MbEvent<Kingdom, Kingdom, Kingdom> _onCallToWarAgreementStartedEvent;

	private readonly MbEvent<Kingdom, Kingdom, Kingdom> _onCallToWarAgreementEndedEvent;

	private readonly ReferenceMBEvent<Hero, bool> _canHeroLeadPartyEvent;

	private readonly ReferenceMBEvent<Hero, bool> _canMarryEvent;

	private readonly ReferenceMBEvent<Hero, bool> _canHeroEquipmentBeChangedEvent;

	private readonly ReferenceMBEvent<Hero, bool> _canBeGovernorOrHavePartyRoleEvent;

	private readonly ReferenceMBEvent<Hero, KillCharacterAction.KillCharacterActionDetail, bool> _canHeroDieEvent;

	private readonly ReferenceMBEvent<Hero, bool> _canPlayerMeetWithHeroAfterConversationEvent;

	private readonly ReferenceMBEvent<Hero, bool> _canHeroBecomePrisonerEvent;

	private readonly ReferenceMBEvent<Hero, bool> _canMoveToSettlementEvent;

	private readonly ReferenceMBEvent<Hero, bool> _canHaveCampaignIssues;

	private readonly ReferenceMBEvent<Settlement, object, int> _isSettlementBusy;

	private readonly MbEvent<IFaction> _onMapEventContinuityNeedsUpdate;

	private static CampaignEvents Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnPlayerBodyPropertiesChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<BarterData> BarterablesRequested
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, bool> HeroLevelledUp
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<BanditPartyComponent, Hideout> OnHomeHideoutChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, SkillObject, int, bool> HeroGainedSkill
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnCharacterCreationIsOverEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, bool> HeroCreated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Occupation> HeroOccupationChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> HeroWounded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero, List<Barterable>> OnBarterAcceptedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero, List<Barterable>> OnBarterCanceledEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero, int, bool, ChangeRelationAction.ChangeRelationDetail, Hero, Hero> HeroRelationChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<QuestBase, bool> QuestLogAddedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IssueBase, bool> IssueLogAddedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Clan, bool> ClanTierIncrease
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Clan, Kingdom, Kingdom, ChangeKingdomAction.ChangeKingdomActionDetail, bool> OnClanChangedKingdomEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Clan, Kingdom, Kingdom> OnClanDefectedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Clan, bool> OnClanCreatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, MobileParty> OnHeroJoinedPartyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<(Hero, PartyBase), (Hero, PartyBase), (int, string), bool> HeroOrPartyTradedGold
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<(Hero, PartyBase), (Hero, PartyBase), ItemRosterElement, bool> HeroOrPartyGaveItem
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> BanditPartyRecruited
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<KingdomDecision, bool> KingdomDecisionAdded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<KingdomDecision, bool> KingdomDecisionCancelled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<KingdomDecision, DecisionOutcome, bool> KingdomDecisionConcluded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> PartyAttachedAnotherParty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> NearbyPartyAddedToPlayerMapEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Army> ArmyCreated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Army, Army.ArmyDispersionReason, bool> ArmyDispersed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Army, IMapPoint> ArmyGathered
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, PerkObject> PerkOpenedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, PerkObject> PerkResetEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<TraitObject, int> PlayerTraitChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Village, Village.VillageStates, Village.VillageStates, MobileParty> VillageStateChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Settlement, Hero> SettlementEntered
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Settlement, Hero> AfterSettlementEntered
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Settlement, Hero> BeforeSettlementEnteredEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Town, CharacterObject, CharacterObject> MercenaryTroopChangedInTown
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Town, int, int> MercenaryNumberChangedInTown
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Alley, Hero, Hero> AlleyOwnerChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Alley, TroopRoster> AlleyOccupiedByPlayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Alley> AlleyClearedByPlayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero, Romance.RomanceLevelEnum> RomanticStateChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero, bool> BeforeHeroesMarried
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<int, Town> PlayerEliminatedFromTournament
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Town> PlayerStartedTournamentMatch
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Town> TournamentStarted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IFaction, IFaction, DeclareWarAction.DeclareWarDetail> WarDeclared
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CharacterObject, MBReadOnlyList<CharacterObject>, Town, ItemObject> TournamentFinished
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Town> TournamentCancelled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase, PartyBase, object, bool> BattleStarted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Settlement, Clan> RebellionFinished
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Town, bool> TownRebelliosStateChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Settlement, Clan> RebelliousClanDisbandedAtSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, ItemRoster> ItemsLooted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, PartyBase> MobilePartyDestroyed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> MobilePartyCreated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IInteractablePoint> MapInteractableCreated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IInteractablePoint> MapInteractableDestroyed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, bool> MobilePartyQuestStatusChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero, KillCharacterAction.KillCharacterActionDetail, bool> HeroKilledEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero, KillCharacterAction.KillCharacterActionDetail, bool> BeforeHeroKilledEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, int> ChildEducationCompletedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> HeroComesOfAgeEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> HeroGrowsOutOfInfancyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> HeroReachesTeenAgeEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero> CharacterDefeated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Kingdom, Clan> RulingClanChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase, Hero> HeroPrisonerTaken
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, PartyBase, IFaction, EndCaptivityDetail, bool> HeroPrisonerReleased
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, bool> CharacterBecameFugitiveEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> OnPlayerMetHeroEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> OnPlayerLearnsAboutHeroEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, int, bool> RenownGained
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IFaction, float> CrimeRatingChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> NewCompanionAdded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IMission> AfterMissionStarted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MenuCallbackArgs> GameMenuOpened
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MenuCallbackArgs> AfterGameMenuInitializedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MenuCallbackArgs> BeforeGameMenuOpenedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IFaction, IFaction, MakePeaceAction.MakePeaceDetail> MakePeace
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Kingdom> KingdomDestroyedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<Kingdom, bool> CanKingdomBeDiscontinuedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Kingdom> KingdomCreatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Village> VillageBecomeNormal
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Village> VillageBeingRaided
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Village> VillageLooted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, RemoveCompanionAction.RemoveCompanionDetail> CompanionRemoved
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IAgent> OnAgentJoinedConversationEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IEnumerable<CharacterObject>> ConversationEnded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MapEvent> MapEventEnded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MapEvent, PartyBase, PartyBase> MapEventStarted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Settlement, FlattenedTroopRoster, Hero, bool> PrisonersChangeInSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, BoardGameHelper.BoardGameState> OnPlayerBoardGameOverEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> OnRansomOfferedToPlayerEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> OnRansomOfferCancelledEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IFaction, int, int> OnPeaceOfferedToPlayerEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Kingdom, Kingdom> OnTradeAgreementSignedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IFaction> OnPeaceOfferResolvedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero> OnMarriageOfferedToPlayerEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero> OnMarriageOfferCanceledEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Kingdom> OnVassalOrMercenaryServiceOfferedToPlayerEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Kingdom> OnVassalOrMercenaryServiceOfferCanceledEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Clan, StartMercenaryServiceAction.StartMercenaryServiceActionDetails> OnMercenaryServiceStartedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Clan, EndMercenaryServiceAction.EndMercenaryServiceActionDetails> OnMercenaryServiceEndedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IMission> OnMissionStartedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent BeforeMissionOpenedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase> OnPartyRemovedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase> OnPartySizeChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Settlement, bool, Hero, Hero, Hero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail> OnSettlementOwnerChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Town, Hero, Hero> OnGovernorChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Settlement> OnSettlementLeftEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent WeeklyTickEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent DailyTickEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> DailyTickPartyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Town> DailyTickTownEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Settlement> DailyTickSettlementEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> DailyTickHeroEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Clan> DailyTickClanEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<List<CampaignTutorial>> CollectAvailableTutorialsEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<string> OnTutorialCompletedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Town, Building, int> OnBuildingLevelChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent HourlyTickEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent QuarterHourlyTickEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> HourlyTickPartyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Settlement> HourlyTickSettlementEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Clan> HourlyTickClanEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<float> TickEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CampaignGameStarter> OnSessionLaunchedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CampaignGameStarter> OnAfterSessionLaunchedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CampaignGameStarter> OnNewGameCreatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CampaignGameStarter, int> OnNewGameCreatedPartialFollowUpEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CampaignGameStarter> OnNewGameCreatedPartialFollowUpEndEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CampaignGameStarter> OnGameEarlyLoadedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CampaignGameStarter> OnGameLoadedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnGameLoadFinishedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, PartyThinkParams> AiHourlyTickEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> TickPartialHourlyAiEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> OnPartyJoinedArmyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> PartyRemovedFromArmyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnPlayerArmyLeaderChangedBehaviorEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IMission> OnMissionEndedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> OnQuarterDailyPartyTick
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MapEvent> OnPlayerBattleEndEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CharacterObject, int> OnUnitRecruitedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> OnChildConceivedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, List<Hero>, int> OnGivenBirthEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<float> MissionTickEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent ArmyOverlaySetDirtyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<int> PlayerDesertedBattleEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase> PartyVisibilityChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Track> TrackDetectedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Track> TrackLostEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Dictionary<string, int>> LocationCharactersAreReadyToSpawnEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<MatrixFrame> BeforePlayerAgentSpawnEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent PlayerAgentSpawned
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent LocationCharactersSimulatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CharacterObject, CharacterObject, int> PlayerUpgradedTroopsEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CharacterObject, CharacterObject, PartyBase, WeaponComponentData, bool, int> OnHeroCombatHitEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CharacterObject> CharacterPortraitPopUpOpenedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent CharacterPortraitPopUpClosedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> PlayerStartTalkFromMenu
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<GameMenu, GameMenuOption> GameMenuOptionSelectedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CharacterObject> PlayerStartRecruitmentEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero> OnBeforePlayerCharacterChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero, MobileParty, bool> OnPlayerCharacterChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero> OnClanLeaderChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<SiegeEvent> OnSiegeEventStartedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnPlayerSiegeStartedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<SiegeEvent> OnSiegeEventEndedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Settlement, SiegeAftermathAction.SiegeAftermath, Clan, Dictionary<MobileParty, float>> OnSiegeAftermathAppliedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Settlement, BattleSideEnum, SiegeEngineType, SiegeBombardTargets> OnSiegeBombardmentHitEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Settlement, BattleSideEnum, SiegeEngineType, bool> OnSiegeBombardmentWallHitEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Settlement, BattleSideEnum, SiegeEngineType> OnSiegeEngineDestroyedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<List<TradeRumor>, Settlement> OnTradeRumorIsTakenEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> OnCheckForIssueEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IssueBase, IssueBase.IssueUpdateDetails, Hero> OnIssueUpdatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, TroopRoster> OnTroopsDesertedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Settlement, Hero, CharacterObject, int> OnTroopRecruitedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Settlement, TroopRoster> OnTroopGivenToSettlementEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase, PartyBase, ItemRosterElement, int, Settlement> OnItemSoldEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Town, List<(EquipmentElement, int)>> OnCaravanTransactionCompletedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase, PartyBase, TroopRoster> OnPrisonerSoldEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> OnPartyDisbandStartedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Settlement> OnPartyDisbandedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> OnPartyDisbandCanceledEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase, PartyBase> OnHideoutSpottedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Settlement> OnHideoutDeactivatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero, float> OnHeroSharedFoodWithAnotherHeroEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<List<(ItemRosterElement, int)>, List<(ItemRosterElement, int)>, bool> PlayerInventoryExchangeEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<ItemRoster> OnItemsDiscardedByPlayerEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Tuple<PersuasionOptionArgs, PersuasionOptionResult>> PersuasionProgressCommittedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<QuestBase, QuestBase.QuestCompleteDetails> OnQuestCompletedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<QuestBase> OnQuestStartedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<ItemObject, Settlement, int> OnItemProducedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<ItemObject, Settlement, int> OnItemConsumedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> OnPartyConsumedFoodEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Hero, KillCharacterAction.KillCharacterActionDetail, bool> OnBeforeMainCharacterDiedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IssueBase> OnNewIssueCreatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IssueBase, Hero> OnIssueOwnerChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnGameOverEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Settlement, MobileParty, bool, MapEvent.BattleTypes> SiegeCompletedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Settlement, MobileParty, bool, MapEvent.BattleTypes> AfterSiegeCompletedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<SiegeEvent, BattleSideEnum, SiegeEngineType> SiegeEngineBuiltEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<BattleSideEnum, RaidEventComponent> RaidCompletedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<BattleSideEnum, ForceVolunteersEventComponent> ForceVolunteersCompletedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<BattleSideEnum, ForceSuppliesEventComponent> ForceSuppliesCompletedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static MbEvent<BattleSideEnum, HideoutEventComponent> OnHideoutBattleCompletedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Clan> OnClanDestroyedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<ItemObject, ItemModifier, bool> OnNewItemCraftedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CraftingPiece> CraftingPartUnlockedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Workshop> WorkshopInitializedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Workshop, Hero> WorkshopOwnerChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Workshop> WorkshopTypeChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnBeforeSaveEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnSaveStartedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<bool, string> OnSaveOverEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<FlattenedTroopRoster> OnPrisonerTakenEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<FlattenedTroopRoster> OnPrisonerReleasedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<FlattenedTroopRoster> OnMainPartyPrisonerRecruitedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, FlattenedTroopRoster, Settlement> OnPrisonerDonatedToSettlementEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, EquipmentElement> OnEquipmentSmeltedByHeroEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<int> OnPlayerTradeProfitEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Clan> OnHeroChangedClanEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, HeroGetsBusyReasons> OnHeroGetsBusyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase, ItemRoster> OnCollectLootsItemsEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase, PartyBase, ItemRoster> OnLootDistributedToPartyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Settlement, MobileParty, TeleportHeroAction.TeleportationDetail> OnHeroTeleportationRequestedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> OnPartyLeaderChangeOfferCanceledEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Hero> OnPartyLeaderChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Clan, float> OnClanInfluenceChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CharacterObject> OnPlayerPartyKnockedOrKilledTroopEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<DefaultClanFinanceModel.AssetIncomeType, int> OnPlayerEarnedGoldFromAssetEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Clan, IFaction> OnClanEarnedGoldFromTributeEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnMainPartyStarvingEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Town, bool> OnPlayerJoinedTournamentEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> OnHeroUnregisteredEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnConfigChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Town, CraftingOrder, ItemObject, Hero> OnCraftingOrderCompletedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero, Crafting.RefiningFormula> OnItemsRefinedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Dictionary<Hero, int>> OnHeirSelectionRequestedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Hero> OnHeirSelectionOverEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<CharacterCreationManager> OnCharacterCreationInitializedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> OnMobilePartyRaftStateChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase, Ship, DestroyShipAction.ShipDestroyDetail> OnShipDestroyedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Ship, PartyBase, ChangeShipOwnerAction.ShipOwnerChangeDetail> OnShipOwnerChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Ship, Settlement> OnShipRepairedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Ship, Settlement> OnShipCreatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Figurehead> OnFigureheadUnlockedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty, Army> OnPartyLeftArmyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase> OnPartyAddedToMapEventEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Incident> OnIncidentResolvedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> OnMobilePartyNavigationStateChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> OnMobilePartyJoinedToSiegeEventEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MobileParty> OnMobilePartyLeftSiegeEventEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<SiegeEvent> OnBlockadeActivatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<SiegeEvent> OnBlockadeDeactivatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MapMarker> OnMapMarkerCreatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MapMarker> OnMapMarkerRemovedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Kingdom, Kingdom> OnAllianceStartedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Kingdom, Kingdom> OnAllianceEndedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Kingdom, Kingdom, Kingdom> OnCallToWarAgreementStartedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Kingdom, Kingdom, Kingdom> OnCallToWarAgreementEndedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<Hero, bool> CanHeroLeadPartyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<Hero, bool> CanHeroMarryEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<Hero, bool> CanHeroEquipmentBeChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<Hero, bool> CanBeGovernorOrHavePartyRoleEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<Hero, KillCharacterAction.KillCharacterActionDetail, bool> CanHeroDieEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<Hero, bool> CanPlayerMeetWithHeroAfterConversationEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<Hero, bool> CanHeroBecomePrisonerEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<Hero, bool> CanMoveToSettlementEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<Hero, bool> CanHaveCampaignIssuesEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ReferenceIMBEvent<Settlement, object, int> IsSettlementBusyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<IFaction> OnMapEventContinuityNeedsUpdateEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RemoveListeners(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerBodyPropertiesChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBarterablesRequested(BarterData args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroLevelledUp(Hero hero, bool shouldNotify = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHomeHideoutChanged(BanditPartyComponent banditPartyComponent, Hideout oldHomeHideout)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroGainedSkill(Hero hero, SkillObject skill, int change = 1, bool shouldNotify = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCharacterCreationIsOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroCreated(Hero hero, bool isBornNaturally = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroOccupationChanged(Hero hero, Occupation oldOccupation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroWounded(Hero woundedHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBarterAccepted(Hero offererHero, Hero otherHero, List<Barterable> barters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBarterCanceled(Hero offererHero, Hero otherHero, List<Barterable> barters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroRelationChanged(Hero effectiveHero, Hero effectiveHeroGainedRelationWith, int relationChange, bool showNotification, ChangeRelationAction.ChangeRelationDetail detail, Hero originalHero, Hero originalGainedRelationWith)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnQuestLogAdded(QuestBase quest, bool hideInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnIssueLogAdded(IssueBase issue, bool hideInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClanTierChanged(Clan clan, bool shouldNotify = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomAction.ChangeKingdomActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClanDefected(Clan clan, Kingdom oldKingdom, Kingdom newKingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClanCreated(Clan clan, bool isCompanion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroJoinedParty(Hero hero, MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroOrPartyTradedGold((Hero, PartyBase) giver, (Hero, PartyBase) recipient, (int, string) goldAmount, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroOrPartyGaveItem((Hero, PartyBase) giver, (Hero, PartyBase) receiver, ItemRosterElement itemRosterElement, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBanditPartyRecruited(MobileParty banditParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnKingdomDecisionAdded(KingdomDecision decision, bool isPlayerInvolved)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnKingdomDecisionCancelled(KingdomDecision decision, bool isPlayerInvolved)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnKingdomDecisionConcluded(KingdomDecision decision, DecisionOutcome chosenOutcome, bool isPlayerInvolved)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyAttachedAnotherParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnNearbyPartyAddedToPlayerMapEvent(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnArmyCreated(Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnArmyDispersed(Army army, Army.ArmyDispersionReason reason, bool isPlayersArmy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnArmyGathered(Army army, IMapPoint gatheringPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPerkOpened(Hero hero, PerkObject perk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPerkReset(Hero hero, PerkObject perk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerTraitChanged(TraitObject trait, int previousLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnVillageStateChanged(Village village, Village.VillageStates oldState, Village.VillageStates newState, MobileParty raiderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBeforeSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMercenaryTroopChangedInTown(Town town, CharacterObject oldTroopType, CharacterObject newTroopType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMercenaryNumberChangedInTown(Town town, int oldNumber, int newNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAlleyOccupiedByPlayer(Alley alley, TroopRoster troops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAlleyOwnerChanged(Alley alley, Hero newOwner, Hero oldOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAlleyClearedByPlayer(Alley alley)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRomanticStateChanged(Hero hero1, Hero hero2, Romance.RomanceLevelEnum romanceLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBeforeHeroesMarried(Hero hero1, Hero hero2, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerEliminatedFromTournament(int round, Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerStartedTournamentMatch(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTournamentStarted(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnWarDeclared(IFaction faction1, IFaction faction2, DeclareWarAction.DeclareWarDetail declareWarDetail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTournamentFinished(CharacterObject winner, MBReadOnlyList<CharacterObject> participants, Town town, ItemObject prize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTournamentCancelled(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnStartBattle(PartyBase attackerParty, PartyBase defenderParty, object subject, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRebellionFinished(Settlement settlement, Clan oldOwnerClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TownRebelliousStateChanged(Town town, bool rebelliousState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRebelliousClanDisbandedAtSettlement(Settlement settlement, Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnItemsLooted(MobileParty mobileParty, ItemRoster items)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMobilePartyDestroyed(MobileParty mobileParty, PartyBase destroyerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMobilePartyCreated(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMapInteractableCreated(IInteractablePoint interactable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMapInteractableDestroyed(IInteractablePoint interactable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMobilePartyQuestStatusChanged(MobileParty party, bool isUsedByQuest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroKilled(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBeforeHeroKilled(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnChildEducationCompleted(Hero hero, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroComesOfAge(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroGrowsOutOfInfancy(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroReachesTeenAge(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCharacterDefeated(Hero winner, Hero loser)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRulingClanChanged(Kingdom kingdom, Clan newRulingClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroPrisonerTaken(PartyBase capturer, Hero prisoner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroPrisonerReleased(Hero prisoner, PartyBase party, IFaction capturerFaction, EndCaptivityDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCharacterBecameFugitive(Hero hero, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerMetHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerLearnsAboutHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRenownGained(Hero hero, int gainedRenown, bool doNotNotify)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCrimeRatingChanged(IFaction kingdom, float deltaCrimeAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnNewCompanionAdded(Hero newCompanion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterMissionStarted(IMission iMission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameMenuOpened(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterGameMenuInitialized(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void BeforeGameMenuOpened(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMakePeace(IFaction side1Faction, IFaction side2Faction, MakePeaceAction.MakePeaceDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnKingdomDestroyed(Kingdom destroyedKingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanKingdomBeDiscontinued(Kingdom kingdom, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnKingdomCreated(Kingdom createdKingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnVillageBecomeNormal(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnVillageBeingRaided(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnVillageLooted(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCompanionRemoved(Hero companion, RemoveCompanionAction.RemoveCompanionDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentJoinedConversation(IAgent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnConversationEnded(IEnumerable<CharacterObject> characters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMapEventStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPrisonersChangeInSettlement(Settlement settlement, FlattenedTroopRoster prisonerRoster, Hero prisonerHero, bool takenFromDungeon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerBoardGameOver(Hero opposingHero, BoardGameHelper.BoardGameState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRansomOfferedToPlayer(Hero captiveHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRansomOfferCancelled(Hero captiveHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPeaceOfferedToPlayer(IFaction opponentFaction, int tributeAmount, int tributeDurationInDays)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTradeAgreementSigned(Kingdom kingdom, Kingdom other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPeaceOfferResolved(IFaction opponentFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMarriageOfferedToPlayer(Hero suitor, Hero maiden)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMarriageOfferCanceled(Hero suitor, Hero maiden)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnVassalOrMercenaryServiceOfferedToPlayer(Kingdom offeredKingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnVassalOrMercenaryServiceOfferCanceled(Kingdom offeredKingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMercenaryServiceStarted(Clan mercenaryClan, StartMercenaryServiceAction.StartMercenaryServiceActionDetails details)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMercenaryServiceEnded(Clan mercenaryClan, EndMercenaryServiceAction.EndMercenaryServiceActionDetails details)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionStarted(IMission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void BeforeMissionOpened()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyRemoved(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartySizeChanged(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGovernorChanged(Town fortification, Hero oldGovernor, Hero newGovernor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSettlementLeft(MobileParty party, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void WeeklyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DailyTickParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DailyTickTown(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DailyTickSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DailyTickHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DailyTickClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CollectAvailableTutorials(ref List<CampaignTutorial> tutorials)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTutorialCompleted(string tutorial)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBuildingLevelChanged(Town town, Building building, int levelChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void QuarterHourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void HourlyTickParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void HourlyTickSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void HourlyTickClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSessionStart(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterSessionStart(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnNewGameCreated(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameEarlyLoaded(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameLoaded(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AiHourlyTick(MobileParty party, PartyThinkParams partyThinkParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TickPartialHourlyAi(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyJoinedArmy(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyRemovedFromArmy(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerArmyLeaderChangedBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionEnded(IMission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void QuarterDailyPartyTick(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerBattleEnd(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUnitRecruited(CharacterObject character, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnChildConceived(Hero mother)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGivenBirth(Hero mother, List<Hero> aliveChildren, int stillbornCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void MissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnArmyOverlaySetDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerDesertedBattle(int sacrificedMenCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyVisibilityChanged(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TrackDetected(Track track)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TrackLost(Track track)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void LocationCharactersAreReadyToSpawn(Dictionary<string, int> unusedUsablePointCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBeforePlayerAgentSpawn(ref MatrixFrame spawnFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerAgentSpawned()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void LocationCharactersSimulated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerUpgradedTroops(CharacterObject upgradeFromTroop, CharacterObject upgradeToTroop, int number)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroCombatHit(CharacterObject attackerTroop, CharacterObject attackedTroop, PartyBase party, WeaponComponentData usedWeapon, bool isFatal, int xp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCharacterPortraitPopUpOpened(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCharacterPortraitPopUpClosed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerStartTalkFromMenu(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameMenuOptionSelected(GameMenu gameMenu, GameMenuOption gameMenuOption)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerStartRecruitment(CharacterObject recruitTroopCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBeforePlayerCharacterChanged(Hero oldPlayer, Hero newPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerCharacterChanged(Hero oldPlayer, Hero newPlayer, MobileParty newMainParty, bool isMainPartyChanged)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClanLeaderChanged(Hero oldLeader, Hero newLeader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSiegeEventStarted(SiegeEvent siegeEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerSiegeStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSiegeEventEnded(SiegeEvent siegeEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSiegeAftermathApplied(MobileParty attackerParty, Settlement settlement, SiegeAftermathAction.SiegeAftermath aftermathType, Clan previousSettlementOwner, Dictionary<MobileParty, float> partyContributions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSiegeBombardmentHit(MobileParty besiegerParty, Settlement besiegedSettlement, BattleSideEnum side, SiegeEngineType weapon, SiegeBombardTargets target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSiegeBombardmentWallHit(MobileParty besiegerParty, Settlement besiegedSettlement, BattleSideEnum side, SiegeEngineType weapon, bool isWallCracked)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSiegeEngineDestroyed(MobileParty besiegerParty, Settlement besiegedSettlement, BattleSideEnum side, SiegeEngineType destroyedEngine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTradeRumorIsTaken(List<TradeRumor> newRumors, Settlement sourceSettlement = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCheckForIssue(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnIssueUpdated(IssueBase issue, IssueBase.IssueUpdateDetails details, Hero issueSolver = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTroopsDeserted(MobileParty mobileParty, TroopRoster desertedTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTroopRecruited(Hero recruiterHero, Settlement recruitmentSettlement, Hero recruitmentSource, CharacterObject troop, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTroopGivenToSettlement(Hero giverHero, Settlement recipientSettlement, TroopRoster roster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnItemSold(PartyBase receiverParty, PartyBase payerParty, ItemRosterElement itemRosterElement, int number, Settlement currentSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCaravanTransactionCompleted(MobileParty caravanParty, Town town, List<(EquipmentElement, int)> itemRosterElements)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPrisonerSold(PartyBase sellerParty, PartyBase buyerParty, TroopRoster prisoners)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyDisbandStarted(MobileParty disbandParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyDisbanded(MobileParty disbandParty, Settlement relatedSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyDisbandCanceled(MobileParty disbandParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHideoutSpotted(PartyBase party, PartyBase hideoutParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHideoutDeactivated(Settlement hideout)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroSharedFoodWithAnother(Hero supporterHero, Hero supportedHero, float influence)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerInventoryExchange(List<(ItemRosterElement, int)> purchasedItems, List<(ItemRosterElement, int)> soldItems, bool isTrading)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnItemsDiscardedByPlayer(ItemRoster discardedItems)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPersuasionProgressCommitted(Tuple<PersuasionOptionArgs, PersuasionOptionResult> progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnQuestCompleted(QuestBase quest, QuestBase.QuestCompleteDetails detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnQuestStarted(QuestBase quest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnItemProduced(ItemObject itemObject, Settlement settlement, int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnItemConsumed(ItemObject itemObject, Settlement settlement, int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyConsumedFood(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBeforeMainCharacterDied(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnNewIssueCreated(IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnIssueOwnerChanged(IssueBase issue, Hero oldOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SiegeCompleted(Settlement siegeSettlement, MobileParty attackerParty, bool isWin, MapEvent.BattleTypes battleType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterSiegeCompleted(Settlement siegeSettlement, MobileParty attackerParty, bool isWin, MapEvent.BattleTypes battleType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SiegeEngineBuilt(SiegeEvent siegeEvent, BattleSideEnum side, SiegeEngineType siegeEngineType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RaidCompleted(BattleSideEnum winnerSide, RaidEventComponent raidEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ForceVolunteersCompleted(BattleSideEnum winnerSide, ForceVolunteersEventComponent forceVolunteersEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ForceSuppliesCompleted(BattleSideEnum winnerSide, ForceSuppliesEventComponent forceSuppliesEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHideoutBattleCompleted(BattleSideEnum winnerSide, HideoutEventComponent hideoutEventComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClanDestroyed(Clan destroyedClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnNewItemCrafted(ItemObject itemObject, ItemModifier overriddenItemModifier, bool isCraftingOrderItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CraftingPartUnlocked(CraftingPiece craftingPiece)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnWorkshopInitialized(Workshop workshop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnWorkshopOwnerChanged(Workshop workshop, Hero oldOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnWorkshopTypeChanged(Workshop workshop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBeforeSave()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSaveStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSaveOver(bool isSuccessful, string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPrisonerTaken(FlattenedTroopRoster roster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPrisonerReleased(FlattenedTroopRoster roster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMainPartyPrisonerRecruited(FlattenedTroopRoster roster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPrisonerDonatedToSettlement(MobileParty donatingParty, FlattenedTroopRoster donatedPrisoners, Settlement donatedSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnEquipmentSmeltedByHero(Hero hero, EquipmentElement smeltedEquipmentElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerTradeProfit(int profit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroChangedClan(Hero hero, Clan oldClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroGetsBusy(Hero hero, HeroGetsBusyReasons heroGetsBusyReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCollectLootItems(PartyBase winnerParty, ItemRoster gainedLoots)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnLootDistributedToParty(PartyBase winnerParty, PartyBase defeatedParty, ItemRoster lootedItems)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroTeleportationRequested(Hero hero, Settlement targetSettlement, MobileParty targetParty, TeleportHeroAction.TeleportationDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyLeaderChangeOfferCanceled(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyLeaderChanged(MobileParty mobileParty, Hero oldLeader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClanInfluenceChanged(Clan clan, float change)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerPartyKnockedOrKilledTroop(CharacterObject strikedTroop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerEarnedGoldFromAsset(DefaultClanFinanceModel.AssetIncomeType incomeType, int incomeAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClanEarnedGoldFromTribute(Clan receiverClan, IFaction payingFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMainPartyStarving()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerJoinedTournament(Town town, bool isParticipant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroUnregistered(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnConfigChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCraftingOrderCompleted(Town town, CraftingOrder craftingOrder, ItemObject craftedItem, Hero completerHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnItemsRefined(Hero hero, Crafting.RefiningFormula refineFormula)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeirSelectionRequested(Dictionary<Hero, int> heirApparents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeirSelectionOver(Hero selectedHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMobilePartyRaftStateChanged(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCharacterCreationInitialized(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnShipDestroyed(PartyBase owner, Ship ship, DestroyShipAction.ShipDestroyDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnShipOwnerChanged(Ship ship, PartyBase oldOwner, ChangeShipOwnerAction.ShipOwnerChangeDetail changeDetail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnShipRepaired(Ship ship, Settlement repairPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnShipCreated(Ship ship, Settlement createdSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFigureheadUnlocked(Figurehead figurehead)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyLeftArmy(MobileParty party, Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPartyAddedToMapEvent(PartyBase partyBase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnIncidentResolved(Incident incident)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMobilePartyNavigationStateChanged(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMobilePartyJoinedToSiegeEvent(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMobilePartyLeftSiegeEvent(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBlockadeActivated(SiegeEvent siegeEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBlockadeDeactivated(SiegeEvent siegeEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMapMarkerCreated(MapMarker mapMarker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMapMarkerRemoved(MapMarker mapMarker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAllianceStarted(Kingdom kingdom1, Kingdom kingdom2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAllianceEnded(Kingdom kingdom1, Kingdom kingdom2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCallToWarAgreementStarted(Kingdom callingKingdom, Kingdom calledKingdom, Kingdom kingdomToCallToWarAgainst)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCallToWarAgreementEnded(Kingdom callingKingdom, Kingdom calledKingdom, Kingdom kingdomToCallToWarAgainst)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHeroLeadParty(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHeroMarry(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHeroEquipmentBeChanged(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanBeGovernorOrHavePartyRole(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHeroDie(Hero hero, KillCharacterAction.KillCharacterActionDetail causeOfDeath, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanPlayerMeetWithHeroAfterConversation(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHeroBecomePrisoner(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanMoveToSettlement(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHaveCampaignIssues(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void IsSettlementBusy(Settlement settlement, object asker, ref int priority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMapEventContinuityNeedsUpdate(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignEvents()
	{
		throw null;
	}
}
