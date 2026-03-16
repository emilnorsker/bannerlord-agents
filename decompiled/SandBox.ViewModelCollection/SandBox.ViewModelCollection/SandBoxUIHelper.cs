using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace SandBox.ViewModelCollection;

public static class SandBoxUIHelper
{
	public enum SortState
	{
		Default,
		Ascending,
		Descending
	}

	public enum MapEventVisualTypes
	{
		None,
		Raid,
		Siege,
		Battle,
		Rebellion,
		SallyOut
	}

	public const float AgentMarkerWorldHeightOffset = 0.35f;

	private static readonly TextObject _soldStr;

	private static readonly TextObject _purchasedStr;

	private static readonly TextObject _itemTransactionStr;

	private static readonly TextObject _lootStr;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TooltipAddExplanation(List<TooltipProperty> properties, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetExplainedNumberTooltip(ref ExplainedNumber explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetBattleLootAwardTooltip(float lootPercentage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetFigureheadTooltip(Figurehead figurehead)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetSkillEffectText(SkillEffect effect, int skillLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetRecruitNotificationText(int recruitmentAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetItemSoldNotificationText(ItemRosterElement item, int itemAmount, bool fromHeroToSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetShipSoldNotificationText(Ship ship, int itemAmount, bool fromHeroToSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTroopGivenToSettlementNotificationText(int givenAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string GetItemsTradedNotificationText(List<(EquipmentElement, int)> items, bool isSelling)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetSiegeEngineInProgressTooltip(SiegeEngineConstructionProgress engineInProgress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetSiegeEngineTooltip(SiegeEngineType engine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetWallSectionTooltip(Settlement settlement, int wallIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPrisonersSoldNotificationText(int soldPrisonerAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetPartyHealthyCount(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPartyWoundedText(int woundedAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPartyPrisonerText(int prisonerAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetAllWoundedMembersAmount(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetAllPrisonerMembersAmount(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CharacterCode GetCharacterCode(CharacterObject character, bool useCivilian = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsHeroInformationHidden(Hero hero, out TextObject disableReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MapEventVisualTypes GetMapEventVisualTypeFromMapEvent(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetChangeValueString(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsAgentInVisibilityRangeApproximate(Agent seerAgent, Agent seenAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CanAgentBeAlarmed(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SandBoxUIHelper()
	{
		throw null;
	}
}
