using AIInfluence.Diplomacy;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Library;

namespace AIInfluence.Patches.Diplomacy;

[HarmonyPatch(typeof(ChangeKingdomAction))]
public static class PreventRejoiningPatch
{
	[HarmonyPrefix]
	[HarmonyPatch("ApplyByJoinToKingdom")]
	public static bool Prefix_ApplyByJoinToKingdom(Clan clan, Kingdom newKingdom, CampaignTime shouldStayInKingdomUntil, bool showNotification)
	{
		return CheckIfBanned(clan, newKingdom);
	}

	[HarmonyPrefix]
	[HarmonyPatch("ApplyByJoinToKingdomByDefection")]
	public static bool Prefix_ApplyByJoinToKingdomByDefection(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, CampaignTime shouldStayInKingdomUntil, bool showNotification)
	{
		return CheckIfBanned(clan, newKingdom);
	}

	[HarmonyPrefix]
	[HarmonyPatch("ApplyByJoinFactionAsMercenary")]
	public static bool Prefix_ApplyByJoinFactionAsMercenary(Clan clan, Kingdom newKingdom, CampaignTime shouldStayInKingdomUntil, int awardMultiplier, bool showNotification)
	{
		return CheckIfBanned(clan, newKingdom);
	}

	private static bool CheckIfBanned(Clan clan, Kingdom kingdom)
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		if (clan == null || kingdom == null)
		{
			return true;
		}
		if (clan == Clan.PlayerClan)
		{
			if (ExpelledClanSystem.Instance.IsClanBanned(kingdom, clan))
			{
				ExpelledClanSystem.Instance.PardonClan(kingdom, clan);
				DiplomacyLogger.Instance.Log($"[PREVENT_REJOINING] Player clan was banned from {kingdom.Name}, but automatically pardoned to allow rejoining");
			}
			return true;
		}
		if (ExpelledClanSystem.Instance.IsClanBanned(kingdom, clan))
		{
			string arg = ExpelledClanSystem.Instance.GetExpulsionRecord(kingdom, clan)?.Reason ?? "Expelled by ruler";
			DiplomacyLogger.Instance.Log($"[PREVENT_REJOINING] Blocked {clan.Name} from joining {kingdom.Name}. Reason: {arg}");
			if (kingdom == Clan.PlayerClan.Kingdom)
			{
				InformationManager.DisplayMessage(new InformationMessage($"{clan.Name} is banned from joining {kingdom.Name} ({arg})", Colors.Red));
			}
			return false;
		}
		return true;
	}
}
