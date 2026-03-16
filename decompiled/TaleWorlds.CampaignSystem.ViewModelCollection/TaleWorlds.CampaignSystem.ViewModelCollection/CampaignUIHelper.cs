using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.CraftingSystem;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign.Order;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Generic;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Library.Information;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection;

public static class CampaignUIHelper
{
	[Flags]
	public enum IssueQuestFlags
	{
		None = 0,
		AvailableIssue = 1,
		ActiveIssue = 2,
		ActiveStoryQuest = 4,
		TrackedIssue = 8,
		TrackedStoryQuest = 0x10
	}

	public enum SortState
	{
		Default,
		Ascending,
		Descending
	}

	public class CharacterAttributeComparer : IComparer<CharacterAttribute>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(CharacterAttribute x, CharacterAttribute y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int ResolveEquality(CharacterAttribute x, CharacterAttribute y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CharacterAttributeComparer()
		{
			throw null;
		}
	}

	public class SkillObjectComparer : IComparer<SkillObject>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(SkillObject x, SkillObject y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int ResolveEquality(SkillObject x, SkillObject y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SkillObjectComparer()
		{
			throw null;
		}
	}

	public class MobilePartyPrecedenceComparer : IComparer<MobileParty>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(MobileParty x, MobileParty y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MobilePartyPrecedenceComparer()
		{
			throw null;
		}
	}

	public class ProductInputOutputEqualityComparer : IEqualityComparer<(ItemCategory, int)>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Equals((ItemCategory, int) x, (ItemCategory, int) y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetHashCode((ItemCategory, int) obj)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ProductInputOutputEqualityComparer()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetHeroTraits_003Ed__220 : IEnumerable<TraitObject>, IEnumerable, IEnumerator<TraitObject>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private TraitObject _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		TraitObject IEnumerator<TraitObject>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetHeroTraits_003Ed__220(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<TraitObject> IEnumerable<TraitObject>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	public static readonly IssueQuestFlags[] IssueQuestFlagsValues;

	private static readonly TextObject _changeStr;

	private static readonly TextObject _totalStr;

	private static readonly TextObject _noChangesStr;

	private static readonly TextObject _hitPointsStr;

	private static readonly TextObject _maxhitPointsStr;

	private static readonly TextObject _prosperityStr;

	private static readonly TextObject _hearthStr;

	private static readonly TextObject _dailyProductionStr;

	private static readonly TextObject _securityStr;

	private static readonly TextObject _criminalRatingStr;

	private static readonly TextObject _militiaStr;

	private static readonly TextObject _foodStr;

	private static readonly TextObject _foodItemsStr;

	private static readonly TextObject _livestockStr;

	private static readonly TextObject _armyCohesionStr;

	private static readonly TextObject _loyaltyStr;

	private static readonly TextObject _wallsStr;

	private static readonly TextObject _plusStr;

	private static readonly TextObject _heroesHealingRateStr;

	private static readonly TextObject _numTotalTroopsInTheArmyStr;

	private static readonly TextObject _garrisonStr;

	private static readonly TextObject _hitPoints;

	private static readonly TextObject _maxhitPoints;

	private static readonly TextObject _goldStr;

	private static readonly TextObject _resultGold;

	private static readonly TextObject _influenceStr;

	private static readonly TextObject _partyMoraleStr;

	private static readonly TextObject _partyFoodStr;

	private static readonly TextObject _partySpeedStr;

	private static readonly TextObject _partySizeLimitStr;

	private static readonly TextObject _viewDistanceFoodStr;

	private static readonly TextObject _battleReadyTroopsStr;

	private static readonly TextObject _patrolStr;

	private static readonly TextObject _woundedTroopsStr;

	private static readonly TextObject _prisonersStr;

	private static readonly TextObject _regularsHealingRateStr;

	private static readonly TextObject _learningRateStr;

	private static readonly TextObject _learningLimitStr;

	private static readonly TextObject _partyInventoryCapacityStr;

	private static readonly TextObject _partyInventoryCargoCapacityStr;

	private static readonly TextObject _partyInventoryLandCapacityStr;

	private static readonly TextObject _partyInventorySeaCapacityStr;

	private static readonly TextObject _partyInventoryWeightStr;

	private static readonly TextObject _partyInventoryCargoStr;

	private static readonly TextObject _partyInventoryLandWeightStr;

	private static readonly TextObject _partyInventorySeaWeightStr;

	private static readonly TextObject _partyTroopSizeLimitStr;

	private static readonly TextObject _partyPrisonerSizeLimitStr;

	private static readonly TextObject _inventorySkillTooltipTitle;

	private static readonly TextObject _mercenaryClanInfluenceStr;

	private static readonly TextObject _orderRequirementText;

	private static readonly TextObject _denarValueInfoText;

	private static readonly TextObject _prisonerOfText;

	private static readonly TextObject _attachedToText;

	private static readonly TextObject _inYourPartyText;

	private static readonly TextObject _travelingText;

	private static readonly TextObject _recoveringText;

	private static readonly TextObject _recentlyReleasedText;

	private static readonly TextObject _recentlyEscapedText;

	private static readonly TextObject _nearSettlementText;

	private static readonly TextObject _noDelayText;

	private static readonly TextObject _regroupingText;

	public static readonly MobilePartyPrecedenceComparer MobilePartyPrecedenceComparerInstance;

	public static readonly SkillObjectComparer SkillObjectComparerInstance;

	public static readonly CharacterAttributeComparer CharacterAttributeComparerInstance;

	private static readonly List<ItemObject.ItemTypeEnum> _itemObjectTypeSortIndices;

	private static readonly List<string> _attributeSortIndices;

	private static readonly List<string> _skillSortIndices;

	private static readonly List<string> _navalSkills;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddPropertyTitleWithValue(List<TooltipProperty> properties, string propertyName, float currentValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddPropertyTitleWithValue(List<TooltipProperty> properties, string propertyName, string currentValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddExplanation(List<TooltipProperty> properties, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddPropertyTitle(List<TooltipProperty> properties, string propertyName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddExplainedResultChange(List<TooltipProperty> properties, float changeValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddExplanedChange(List<TooltipProperty> properties, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddExplainedResultTotal(List<TooltipProperty> properties, float changeValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTooltipForAccumulatingProperty(string propertyName, float currentValue, ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTooltipForAccumulatingPropertyWithResult(string propertyName, float currentValue, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTooltipForgProperty(string propertyName, float currentValue, ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddSeperator(List<TooltipProperty> properties, bool onlyShowOnExtend = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddDoubleSeperator(List<TooltipProperty> properties, bool onlyShowOnExtend = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddExtendInfo(List<TooltipProperty> properties, bool onlyShowOnExtend = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddEmptyLine(List<TooltipProperty> properties, bool onlyShowOnExtend = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTownWallsTooltip(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetVillageMilitiaTooltip(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTownMilitiaTooltip(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTownFoodTooltip(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTownLoyaltyTooltip(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTownProsperityTooltip(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTownDailyProductionTooltip(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTownSecurityTooltip(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTownPatrolTooltip(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetVillageProsperityTooltip(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTownGarrisonTooltip(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetPartyTroopSizeLimitTooltip(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetPartyPrisonerSizeLimitTooltip(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetUsedHorsesTooltip(List<Tuple<EquipmentElement, int>> usedUpgradeHorsesHistory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetArmyCohesionTooltip(Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetArmyManCountTooltip(Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetDaysUntilNoFood(float totalFood, float foodChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetSettlementPropertyTooltip(Settlement settlement, string valueName, float value, ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetSettlementPropertyTooltipWithResult(Settlement settlement, string valueName, float value, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetArmyFoodTooltip(Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetClanWealthStatusText(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetClanProsperityTooltip(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<TooltipProperty> GetDiplomacySettlementStatComparisonTooltip(List<Settlement> settlements, string title, string emptyExplanation = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTruceOwnedSettlementsTooltip(List<Settlement> settlements, TextObject factionName, bool isTown)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetWarPrisonersTooltip(List<Hero> capturedPrisoners, TextObject factionName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetNormalizedWarProgressTooltip(ExplainedNumber warProgress, ExplainedNumber otherFactionWarProgress, float maxValue, TextObject faction1Name, TextObject faction2Name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetClanStrengthTooltip(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetCrimeTooltip(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetInfluenceTooltip(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetClanRenownTooltip(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TooltipTriggerVM GetDenarTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetPartyMoraleTooltip(MobileParty mainParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetPartyHealthTooltip(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetPlayerHitpointsTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetPartyFoodTooltip(MobileParty mainParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetPartySpeedTooltip(bool considerArmySpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetPartyWageTooltip(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetViewDistanceTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetMainPartyHealthTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetPartyInventoryCapacityTooltip(MobileParty party, bool forceLand = false, bool forceSea = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetPartyInventoryWeightTooltip(MobileParty party, bool forceLand = false, bool forceSea = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetPerkEffectText(PerkObject perk, bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetPerkRoleText(PerkObject perk, bool getSecondary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetCombinedPerkRoleText(PerkObject perk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetSiegeMachineTooltip(SiegeEngineType engineType, bool showDescription = true, int hoursUntilCompletion = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetSiegeMachineName(SiegeEngineType engineType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetSiegeMachineNameWithDesctiption(SiegeEngineType engineType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTroopConformityTooltip(TroopRosterElement troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetLearningRateTooltip(IReadOnlyPropertyOwner<CharacterAttribute> characterAttributes, int focusValue, int skillValue, SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTroopXPTooltip(TroopRosterElement troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetLearningLimitTooltip(IReadOnlyPropertyOwner<CharacterAttribute> characterAttributes, int focusValue, SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetSettlementConsumptionTooltip(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static StringItemWithHintVM GetCharacterTierData(CharacterObject character, bool isBig = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetSettlementProductionTooltip(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetHintTextFromReasons(List<TextObject> reasons)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string MergeTextObjectsWithNewline(List<TextObject> textObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetHoursAndDaysTextFromHourValue(int hours)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetTeleportationDelayText(Hero hero, PartyBase target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTimeOfDayAndResetCameraTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetTournamentChampionRewardsTooltip(Hero hero, Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static StringItemWithHintVM GetCharacterTypeData(CharacterObject character, bool isBig = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetHeroHealthTooltip(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetSiegeWallTooltip(int wallLevel, int wallHitpoints)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetGovernorPerksTooltipForHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static (TextObject titleText, TextObject bodyText) GetGovernorSelectionConfirmationPopupTexts(Hero currentGovernor, Hero newGovernor, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetHeroGovernorEffectsTooltip(Hero hero, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetEncounterPartyMoraleTooltip(List<MobileParty> parties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetCraftingTemplatePieceUnlockProgressHint(float progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<(string, TextObject)> GetWeaponFlagDetails(WeaponFlags weaponFlags, CharacterObject character = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<Tuple<string, TextObject>> GetItemFlagDetails(ItemFlags itemFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<(string, TextObject)> GetItemUsageSetFlagDetails(ItemObject.ItemUsageSetFlags flags, CharacterObject character = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<(string, TextObject)> GetFlagDetailsForWeapon(WeaponComponentData weapon, ItemObject.ItemUsageSetFlags itemUsageFlags, CharacterObject character = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetFormattedItemPropertyText(float propertyValue, bool typeRequiresInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetCraftingHeroTooltip(Hero hero, CraftingOrder order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetOrderCannotBeCompletedReasonTooltip(CraftingOrder order, ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetCraftingOrderDisabledReasonTooltip(Hero heroToCheck, CraftingOrder order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetOrdersDisabledReasonTooltip(MBBindingList<CraftingOrderItemVM> craftingOrders, Hero heroToCheck)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetCraftingOrderMissingPropertyWarningText(CraftingOrder order, ItemObject craftedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetInventoryCharacterTooltip(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetHeroOccupationName(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TooltipProperty GetSiegeMachineProgressLine(int hoursRemaining)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetCommaSeparatedText(TextObject label, IEnumerable<TextObject> texts)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetCommaNewlineSeparatedText(TextObject label, IEnumerable<TextObject> texts)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetHeroKingdomRank(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetHeroRank(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsSettlementInformationHidden(Settlement settlement, out TextObject disableReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsHeroInformationHidden(Hero hero, out TextObject disableReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPartyNameplateText(MobileParty party, bool includeAttachedParties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPartyNameplateText(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetValueChangeText(float originalValue, float valueChange, string valueFormat = "F0")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetUpgradeHint(int index, int numOfItems, int availableUpgrades, int upgradeCoinCost, bool hasRequiredPerk, PerkObject requiredPerk, CharacterObject character, TroopRosterElement troop, int partyGoldChangeAmount, bool areUpgradesDisabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetStackModifierString(TextObject allStackText, TextObject fiveStackText, bool canFiveStack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ConvertToHexColor(uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetMapScreenActionIsEnabledWithReason(out TextObject disabledReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetCanManageCurrentArmyWithReason(out TextObject disabledReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetClanSupportDisableReasonString(bool hasEnoughInfluence, bool isTargetMainClan, bool isMainClanMercenary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetClanExpelDisableReasonString(bool hasEnoughInfluence, bool isTargetMainClan, bool isTargetRulingClan, bool isMainClanMercenary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetArmyDisbandDisableReasonString(bool hasEnoughInfluence, bool isArmyInAnyEvent, bool isPlayerClanMercenary, bool isPlayerInThisArmy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetCreateNewPartyReasonString(bool haveEmptyPartySlots, bool haveAvailableHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetCraftingDisableReasonString(bool playerHasEnoughMaterials)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetAddFocusHintString(bool playerHasEnoughPoints, bool isMaxedSkill, int currentFocusAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetSkillEffectText(SkillEffect effect, int skillLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetMobilePartyBehaviorText(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetHeroBehaviorText(Hero hero, ITeleportationCampaignBehavior teleportationBehavior = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPartyLocationText(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Hero GetTeleportingLeaderHero(MobileParty party, ITeleportationCampaignBehavior teleportationBehavior)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Hero GetTeleportingGovernor(Settlement settlement, ITeleportationCampaignBehavior teleportationBehavior)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetHeroRelationToHeroText(Hero queriedHero, Hero baseHero, bool uppercaseFirst)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetAbbreviatedValueTextFromValue(int valueAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPartyDistanceByTimeText(float distance, float speed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPartyDistanceByTimeTextAbbreviated(float distance, float speed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CharacterCode GetCharacterCode(CharacterObject character, bool useCivilian = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTraitNameText(TraitObject traitObject, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTraitTooltipText(TraitObject traitObject, int traitValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTextForRole(PartyRole role)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetAttributeTypeSortIndex(CharacterAttribute attribute)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetSkillObjectTypeSortIndex(SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetSkillMeshId(SkillObject skill, bool useSmallestVariation = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetIsNavalSkill(SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetHeroCompareSortIndex(Hero x, Hero y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetHeroClanRoleText(Hero hero, Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetItemObjectTypeSortIndex(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetItemLockStringID(EquipmentElement equipmentElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTroopLockStringID(TroopRosterElement rosterElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<(IssueQuestFlags, TextObject, TextObject)> GetQuestStateOfHero(Hero queriedHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetQuestExplanationOfHero(IssueQuestFlags questType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<QuestBase> GetQuestsRelatedToHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<QuestBase> GetQuestsRelatedToParty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<(bool isHeroQuestGiver, QuestBase quest)> GetQuestsRelatedToSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsQuestRelatedToSettlement(QuestBase quest, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IssueQuestFlags GetIssueType(IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IssueQuestFlags GetQuestType(QuestBase quest, Hero queriedQuestGiver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetHeroTraits_003Ed__220))]
	public static IEnumerable<TraitObject> GetHeroTraits()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsItemUsageApplicable(WeaponComponentData weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string FloatToString(float x)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Tuple<bool, TextObject> GetIsStringApplicableForHeroName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Tuple<bool, string> IsStringApplicableForHeroName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Tuple<bool, TextObject> IsStringApplicableForItemName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CharacterObject GetVisualPartyLeader(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetChangeValueString(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<Hero> GetChildrenAndGrandchildrenOfHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CampaignUIHelper()
	{
		throw null;
	}
}
