using System;
using System.Collections.Generic;
using AIInfluence.Diplomacy;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Localization;

namespace AIInfluence;

public static class WarHandler
{
	public static void DeclareWar(Hero npc, AIInfluenceBehavior behavior)
	{
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		if (npc == null || behavior == null)
		{
			behavior?.LogMessage("[ERROR] DeclareWar: NPC or behavior is null.");
			return;
		}
		string text = ((object)npc.Name)?.ToString() ?? "Unknown";
		Clan playerClan = Clan.PlayerClan;
		Clan clan = npc.Clan;
		if (clan == null)
		{
			behavior.LogMessage("[ERROR] DeclareWar: " + text + " has no clan.");
			return;
		}
		IFaction mapFaction = clan.MapFaction;
		Hero leader;
		IFaction targetFaction;
		string text2;
		if (mapFaction != null && mapFaction.IsKingdomFaction)
		{
			leader = clan.MapFaction.Leader;
			targetFaction = clan.MapFaction;
			text2 = "kingdom";
		}
		else
		{
			leader = clan.Leader;
			targetFaction = (IFaction)(object)clan;
			text2 = "clan";
		}
		if (leader == null)
		{
			behavior.LogMessage("[ERROR] DeclareWar: No leader found for " + text2 + " of " + text + ".");
			return;
		}
		if (text2 == "kingdom" && playerClan.MapFaction != null && playerClan.MapFaction.IsAtWarWith(targetFaction))
		{
			behavior.LogMessage($"[DEBUG] DeclareWar: {playerClan.Name} is already at war with {targetFaction.Name} led by {leader.Name}.");
			return;
		}
		if (text2 == "clan" && playerClan.IsAtWarWith(targetFaction))
		{
			behavior.LogMessage($"[DEBUG] DeclareWar: {playerClan.Name} is already at war with {targetFaction.Name} led by {leader.Name}.");
			return;
		}
		try
		{
			behavior.LogMessage($"[DEBUG] Before DeclareWar: playerClan={playerClan.Name}, target={targetFaction.Name} led by {leader.Name}, IsAtWarWith={playerClan.IsAtWarWith(targetFaction)}");
			DiplomacyPatches.WithBypass(delegate
			{
				DeclareWarAction.ApplyByDefault(targetFaction, (IFaction)(object)playerClan);
			});
			string text3 = ((object)new TextObject("{=AIInfluence_WarDeclared}{FACTION_NAME} ({LEADER_NAME}) declares war on you!", new Dictionary<string, object>
			{
				{ "FACTION_NAME", targetFaction.Name },
				{ "LEADER_NAME", leader.Name }
			})).ToString();
			behavior.LogMessage($"[DEBUG] {targetFaction.Name} declared war on {playerClan.Name}. Now IsAtWarWith={playerClan.IsAtWarWith(targetFaction)}");
		}
		catch (Exception ex)
		{
			behavior.LogMessage($"[ERROR] DeclareWar failed for {leader.Name} of {targetFaction.Name}: {ex.Message}\n{ex.StackTrace}");
		}
	}
}
