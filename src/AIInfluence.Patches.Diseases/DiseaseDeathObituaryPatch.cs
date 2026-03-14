using System.Collections.Generic;
using AIInfluence.Diseases;
using HarmonyLib;
using Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using KillCharacterAction = TaleWorlds.CampaignSystem.Actions.KillCharacterAction;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch(typeof(TaleWorlds.CampaignSystem.Actions.KillCharacterAction), "CreateObituary")]
public static class DiseaseDeathObituaryPatch
{
	[HarmonyPostfix]
	public static void Postfix(Hero hero, KillCharacterActionDetail detail, ref TextObject __result)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		try
		{
			if (hero == null || (int)detail != 3 || !DiseaseManager.PendingDiseaseDeathNames.TryGetValue(((MBObjectBase)hero).StringId, out var value))
			{
				return;
			}
			TextObject val;
			if (hero.IsLord)
			{
				if (hero.Clan != null && hero.Clan.IsMinorFaction)
				{
					val = new TextObject("{=L7qd6qfv}{CHARACTER.FIRSTNAME} was a member of the {CHARACTER.FACTION}. {FURTHER_DETAILS}.", (Dictionary<string, object>)null);
				}
				else if (hero.Clan != null && hero.Clan.Leader == hero)
				{
					val = new TextObject("{=mfYzCeGR}{CHARACTER.NAME} was {TITLE} of the {CHARACTER_FACTION_SHORT}. {FURTHER_DETAILS}.", (Dictionary<string, object>)null);
					val.SetTextVariable("CHARACTER_FACTION_SHORT", hero.MapFaction.InformalName);
					val.SetTextVariable("TITLE", HeroHelper.GetTitleInIndefiniteCase(hero));
				}
				else
				{
					val = new TextObject("{=uWdj1X2c}{CHARACTER.NAME} was a member of the {CHARACTER_FACTION_SHORT}. {FURTHER_DETAILS}.", (Dictionary<string, object>)null);
					val.SetTextVariable("CHARACTER_FACTION_SHORT", hero.MapFaction.InformalName);
					val.SetTextVariable("TITLE", HeroHelper.GetTitleInIndefiniteCase(hero));
				}
			}
			else if (hero.HomeSettlement != null)
			{
				val = new TextObject("{=YNXK352h}{CHARACTER.NAME} was a prominent {.%}{PROFESSION}{.%} from {HOMETOWN}. {FURTHER_DETAILS}.", (Dictionary<string, object>)null);
				val.SetTextVariable("PROFESSION", HeroHelper.GetCharacterTypeName(hero));
				val.SetTextVariable("HOMETOWN", hero.HomeSettlement.Name);
			}
			else
			{
				val = new TextObject("{=!}{FURTHER_DETAILS}.", (Dictionary<string, object>)null);
			}
			StringHelpers.SetCharacterProperties("CHARACTER", hero.CharacterObject, val, true);
			TextObject val2 = new TextObject("{=AIInfluence_DiseaseObituary}{?CHARACTER.GENDER}She{?}He{\\?} died from {DISEASE_NAME} in {YEAR} at the age of {CHARACTER.AGE}. {?CHARACTER.GENDER}She{?}He{\\?} was reputed to be {REPUTATION}", (Dictionary<string, object>)null);
			StringHelpers.SetCharacterProperties("CHARACTER", hero.CharacterObject, val2, true);
			val2.SetTextVariable("DISEASE_NAME", value);
			val2.SetTextVariable("REPUTATION", CharacterHelper.GetReputationDescription(hero.CharacterObject));
			CampaignTime now = CampaignTime.Now;
			val2.SetTextVariable("YEAR", (now).GetYear.ToString());
			val.SetTextVariable("FURTHER_DETAILS", val2);
			__result = val;
		}
		catch
		{
		}
	}
}
