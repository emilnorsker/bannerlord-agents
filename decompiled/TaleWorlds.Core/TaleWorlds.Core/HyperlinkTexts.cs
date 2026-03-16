using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.Core;

public static class HyperlinkTexts
{
	private enum ConsoleType
	{
		Xbox,
		Ps4,
		Ps5
	}

	public const string GoldIcon = "{=!}<img src=\"General\\Icons\\Coin@2x\" extend=\"8\">";

	public const string MoraleIcon = "{=!}<img src=\"General\\Icons\\Morale@2x\" extend=\"8\">";

	public const string InfluenceIcon = "{=!}<img src=\"General\\Icons\\Influence@2x\" extend=\"7\">";

	public const string IssueAvailableIcon = "{=!}<img src=\"General\\Icons\\icon_issue_available_square\" extend=\"4\">";

	public const string IssueActiveIcon = "{=!}<img src=\"General\\Icons\\icon_issue_active_square\" extend=\"4\">";

	public const string TrackedIssueIcon = "{=!}<img src=\"General\\Icons\\issue_target_icon\" extend=\"4\">";

	public const string QuestAvailableIcon = "{=!}<img src=\"General\\Icons\\icon_quest_available_square\" extend=\"4\">";

	public const string QuestActiveIcon = "{=!}<img src=\"General\\Icons\\icon_issue_active_square\" extend=\"4\">";

	public const string StoryQuestActiveIcon = "{=!}<img src=\"General\\Icons\\icon_story_quest_active_square\" extend=\"4\">";

	public const string TrackedStoryQuestIcon = "{=!}<img src=\"General\\Icons\\quest_target_icon\" extend=\"4\">";

	public const string InPrisonIcon = "{=!}<img src=\"Clan\\Status\\icon_inprison\">";

	public const string ChildIcon = "{=!}<img src=\"Clan\\Status\\icon_ischild\">";

	public const string PregnantIcon = "{=!}<img src=\"Clan\\Status\\icon_pregnant\">";

	public const string IllIcon = "{=!}<img src=\"Clan\\Status\\icon_terminallyill\">";

	public const string HeirIcon = "{=!}<img src=\"Clan\\Status\\icon_heir\">";

	public const string UnreadIcon = "{=!}<img src=\"MapMenuUnread2x\">";

	public const string UnselectedPerkIcon = "{=!}<img src=\"CharacterDeveloper\\UnselectedPerksIcon\" extend=\"2\">";

	public const string HorseIcon = "{=!}<img src=\"StdAssets\\ItemIcons\\Mount\" extend=\"16\">";

	public const string CrimeIcon = "{=!}<img src=\"SPGeneral\\MapOverlay\\Settlement\\icon_crime\" extend=\"16\">";

	public const string UpgradeAvailableIcon = "{=!}<img src=\"PartyScreen\\upgrade_icon\" extend=\"5\">";

	public const string FocusIcon = "{=!}<img src=\"CharacterDeveloper\\cp_icon\">";

	public static Func<bool> IsPlayStationGamepadActive;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetSettlementHyperlinkText(string link, TextObject settlementName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetKingdomHyperlinkText(string link, TextObject kingdomName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetHeroHyperlinkText(string link, TextObject heroName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetConceptHyperlinkText(string link, TextObject conceptName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetClanHyperlinkText(string link, TextObject clanName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetShipHyperlinkText(string link, TextObject shipHullName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetUnitHyperlinkText(string link, TextObject unitName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetGenericHyperlinkText(string link, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetGenericImageText(string meshId, int extend = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetKeyHyperlinkText(string keyID, float overrideExtendScale = 1f)
	{
		throw null;
	}
}
