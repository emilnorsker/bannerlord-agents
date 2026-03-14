using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AIInfluence.Behaviors.AIActions;
using AIInfluence.Diplomacy;
using AIInfluence.DynamicEvents;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.SettlementCombat;

public class CombatPromptGenerator
{
	private readonly AIInfluenceBehavior _behavior;

	public CombatPromptGenerator(AIInfluenceBehavior behavior)
	{
		_behavior = behavior;
	}

	public string GenerateSituationAnalysisPrompt(ActiveCombat combat)
	{
		StringBuilder stringBuilder = new StringBuilder();
		SettlementCombatLogger instance = SettlementCombatLogger.Instance;
		instance.Log("=== GenerateSituationAnalysisPrompt ===");
		Settlement settlement = combat.Settlement;
		instance.Log("  Settlement: " + (((settlement == null) ? null : ((object)settlement.Name)?.ToString()) ?? "NULL"));
		Hero triggerNPC = combat.TriggerNPC;
		instance.Log("  TriggerNPC: " + (((triggerNPC == null) ? null : ((object)triggerNPC.Name)?.ToString()) ?? "NULL"));
		instance.Log($"  TriggerType: {combat.TriggerType}");
		instance.Log($"  TriggerResponse length: {((!string.IsNullOrEmpty(combat.TriggerResponse)) ? combat.TriggerResponse.Length : 0)}");
		instance.Log("  Context: " + ((combat.TriggerContext != null) ? "Present" : "NULL"));
		if (combat.TriggerContext != null)
		{
			instance.Log($"  ConversationHistory count: {combat.TriggerContext.ConversationHistory?.Count ?? 0}");
		}
		string gameLanguage = MBTextManager.ActiveTextLanguage ?? "English";
		stringBuilder.AppendLine();
		AppendWorldInfo(stringBuilder);
		AppendAllKingdoms(stringBuilder);
		AppendActiveDynamicEvents(stringBuilder);
		AppendSettlementInfo(stringBuilder, combat.Settlement);
		AppendParticipantsInfo(stringBuilder, combat);
		AppendPlayerCompanionsInfo(stringBuilder, combat);
		AppendDialogHistory(stringBuilder, combat.TriggerContext);
		AppendSettlementNotables(stringBuilder, combat.Settlement);
		AppendNearbyWitnesses(stringBuilder);
		AppendNearbyLords(stringBuilder, combat);
		stringBuilder.AppendLine("# SETTLEMENT COMBAT SITUATION ANALYSIS");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("You are an AI analyzing a conflict that has broken out in a settlement.");
		stringBuilder.AppendLine("Your task is to determine:");
		stringBuilder.AppendLine("1. Who is the aggressor and who is the defender");
		stringBuilder.AppendLine("2. Who witnessed the event");
		stringBuilder.AppendLine();
		AppendAnalysisInstructions(stringBuilder, combat.Settlement);
		AppendResponseFormat(stringBuilder, gameLanguage);
		return stringBuilder.ToString();
	}

	public string GeneratePostCombatEventPrompt(ActiveCombat combat, CombatResult result)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = MBTextManager.ActiveTextLanguage ?? "English";
		stringBuilder.Append(GenerateInternalThoughtsSection());
		stringBuilder.AppendLine("# POST-COMBAT EVENT GENERATION");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("IMPORTANT: Game language is " + text + ". The event description MUST be in " + text + ".");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("A violent conflict has concluded in a settlement. Create a dynamic event describing the aftermath and consequences.");
		stringBuilder.AppendLine();
		AppendWorldInfo(stringBuilder);
		AppendAllKingdoms(stringBuilder);
		AppendPlayerContext(stringBuilder, combat);
		AppendActiveDynamicEvents(stringBuilder);
		AppendFirstAnalysisHistory(stringBuilder, combat);
		AppendCombatSummary(stringBuilder, combat, result);
		AppendCombatStatistics(stringBuilder, result);
		AppendVillageAftermath(stringBuilder, combat, result);
		AppendEventCreationInstructions(stringBuilder, text);
		return stringBuilder.ToString();
	}

	private string GenerateInternalThoughtsSection()
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableDynamicEventsInternalThoughts)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("### CRITICAL: Internal Thought Process (REQUIRED BEFORE CREATING EVENT) ###");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**PRIVATE reasoning process for creating a realistic and impactful post-combat event.**");
		stringBuilder.AppendLine();
		string value = WorldInfoManager.Instance?.ReadEventsGeneratorRules();
		bool flag = !string.IsNullOrEmpty(value);
		if (flag)
		{
			stringBuilder.AppendLine("**OVERRIDE RULES (ABSOLUTE PRIORITY - CHECK IN STEP 7)**");
			stringBuilder.AppendLine("The player has set custom event rules that OVERRIDE all other instructions:");
			stringBuilder.AppendLine(value);
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("**STEP 0: VERIFY COMBAT FACTS (MANDATORY)**");
		stringBuilder.AppendLine("Before reasoning, verify the ACTUAL OUTCOME from combat statistics:");
		stringBuilder.AppendLine("- Who was the aggressor? Who defended?");
		stringBuilder.AppendLine("- How many defenders arrived? (simple defenders, militia, guards, lords)");
		stringBuilder.AppendLine("- What were the actual casualties on both sides?");
		stringBuilder.AppendLine("- Were civilians killed? How many? (men, women, children)");
		stringBuilder.AppendLine("- Was the player captured, evacuated, or victorious?");
		stringBuilder.AppendLine("- What did the player do AFTER combat? (loot, burn, leave peacefully)");
		stringBuilder.AppendLine("- **CRITICAL:** Combat statistics = REALITY. First analysis description = initial situation (may differ from outcome).");
		stringBuilder.AppendLine("- Format: internal_thoughts starts with 'FACT CHECK:' + verified facts from combat statistics.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 1: PLAYER INVOLVEMENT DETERMINATION**");
		stringBuilder.AppendLine("- **CRITICAL:** `player_involved` is determined SOLELY from the DIALOGUE in the first analysis.");
		stringBuilder.AppendLine("- Check 'Player Involved (from first analysis)' — this was set based on whether the Trigger NPC recognized the player during the dialogue.");
		stringBuilder.AppendLine("- If the Trigger NPC treated the player as a stranger in dialogue → player_involved = false (even if combat happened).");
		stringBuilder.AppendLine("- If the Trigger NPC knew the player's name/clan/identity → player_involved = true.");
		stringBuilder.AppendLine("- EXCEPTION: Even if first analysis says player_involved = true, if ALL witnesses (including the NPC) are dead and NO lords arrived → the player may remain unidentified (player_involved = false).");
		stringBuilder.AppendLine("- If lords arrived and they are AGAINST the player → they saw the player, so player_involved = true regardless.");
		stringBuilder.AppendLine("- DO NOT determine recognition from combat statistics alone. Recognition comes from DIALOGUE, not from fighting.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 2: EVENT SEVERITY ASSESSMENT**");
		stringBuilder.AppendLine("- Total casualties (killed + wounded)? Scale: <10=minor, 10-50=notable, 50-200=major, 200+=catastrophic.");
		stringBuilder.AppendLine("- Civilian casualties? Any women/children killed? This dramatically increases severity.");
		stringBuilder.AppendLine("- Were important characters (lords, heroes) killed or wounded?");
		stringBuilder.AppendLine("- Was a settlement burned/looted? Economic damage?");
		stringBuilder.AppendLine("- This determines: importance (1-10), type (military/local/political), spread_speed.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 3: POLITICAL AND DIPLOMATIC IMPLICATIONS**");
		stringBuilder.AppendLine("- Which kingdom owns the settlement? Which kingdom does the player belong to?");
		stringBuilder.AppendLine("- Are these kingdoms at war, allied, or neutral?");
		stringBuilder.AppendLine("- Did lords from other kingdoms participate? This involves their kingdoms.");
		stringBuilder.AppendLine("- Should this trigger a diplomatic response? (lord wounded/killed = almost certainly yes)");
		stringBuilder.AppendLine("- kingdoms_involved = ONLY kingdoms of actual participants, NOT troop cultures.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 4: NARRATIVE PLANNING**");
		stringBuilder.AppendLine("- What is the main narrative angle? (slaughter, heroic defense, failed raid, burning, etc.)");
		stringBuilder.AppendLine("- What emotional tone? (horror, anger, grief, triumph, fear)");
		stringBuilder.AppendLine("- Which specific details from combat make the story vivid? (lord wounded, civilians killed, etc.)");
		stringBuilder.AppendLine("- Description should be in game language, reference characters by NAME (not string_ids).");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 5: ECONOMIC CONSEQUENCES**");
		stringBuilder.AppendLine("- Settlement penalty: how severe? Consider casualties, looting, burning.");
		stringBuilder.AppendLine("- Village: 1-20 hearth/day penalty. Town/Castle: 10-50 prosperity/day.");
		stringBuilder.AppendLine("- Duration: 3-25 days based on severity.");
		stringBuilder.AppendLine("- Burned village = maximum penalty. Minor skirmish = minimal penalty.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 6: INFORMATION SPREAD**");
		stringBuilder.AppendLine("- Who should know? All NPCs? Only lords? Only nearby notables?");
		stringBuilder.AppendLine("- How fast does news travel? Major events with many witnesses = fast.");
		stringBuilder.AppendLine("- applicable_npcs: [\"all\"] for catastrophic events, [\"lords\", \"village_notables\"] for local events.");
		stringBuilder.AppendLine();
		if (flag)
		{
			stringBuilder.AppendLine("**STEP 7: VERIFY OVERRIDE RULES COMPLIANCE (MANDATORY)**");
			stringBuilder.AppendLine("- Does the event violate ANY custom rule? Do values comply with restrictions?");
			stringBuilder.AppendLine("- If violated → MUST change. ABSOLUTE PRIORITY over other logic.");
			stringBuilder.AppendLine("- In internal_thoughts: acknowledge violation → explain adjustment → modify.");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("**STEP 8: OUTPUT STRUCTURE**");
		stringBuilder.AppendLine("JSON MUST include:");
		stringBuilder.AppendLine("- `internal_thoughts` (500-1500 characters): PRIVATE reasoning from all steps above" + (flag ? " + rule compliance check" : "") + ".");
		if (flag)
		{
			stringBuilder.AppendLine("  - Example: \"FACT CHECK: Player attacked village, 500+ killed, lord wounded. REASONING: Catastrophic event, but Override Rules limit importance to 7. Adjusting.\"");
		}
		stringBuilder.AppendLine("- Other fields: id, type, description, player_involved, kingdoms_involved, etc.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**CRITICAL RULES:**");
		stringBuilder.AppendLine("- **MANDATORY:** internal_thoughts starts with 'FACT CHECK:' + facts from combat statistics");
		stringBuilder.AppendLine("- **FORBIDDEN:** Do NOT confuse first analysis situation with actual combat outcome");
		stringBuilder.AppendLine("- **FORBIDDEN:** Do NOT invent casualties or events not in the statistics");
		stringBuilder.AppendLine("- internal_thoughts = PRIVATE (helps reasoning, players don't see)");
		stringBuilder.AppendLine("- Event = internal thoughts + verified facts from combat statistics");
		stringBuilder.AppendLine("- Use exact string_id in JSON (\"battania\", NOT \"Battania\")");
		if (flag)
		{
			stringBuilder.AppendLine("- **MANDATORY:** Event MUST comply with Override Rules. If conflict → Rules WIN");
		}
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}

	private void AppendPlayerContext(StringBuilder sb, ActiveCombat combat)
	{
		sb.AppendLine("## Player Context");
		try
		{
			Hero mainHero = Hero.MainHero;
			if (mainHero == null)
			{
				sb.AppendLine("- Player information unavailable");
				sb.AppendLine();
				return;
			}
			sb.AppendLine($"- Player: {mainHero.Name} (string_id:main_hero)");
			if (mainHero.Clan != null)
			{
				sb.AppendLine($"- Clan: {mainHero.Clan.Name} (id:{((MBObjectBase)mainHero.Clan).StringId})");
			}
			if (mainHero.MapFaction != null)
			{
				IFaction mapFaction = mainHero.MapFaction;
				Kingdom val = (Kingdom)(object)((mapFaction is Kingdom) ? mapFaction : null);
				if (val != null)
				{
					sb.AppendLine($"- Kingdom: {val.Name} (id:{((MBObjectBase)val).StringId})");
					if (combat?.Settlement != null)
					{
						IFaction mapFaction2 = combat.Settlement.MapFaction;
						Kingdom val2 = (Kingdom)(object)((mapFaction2 is Kingdom) ? mapFaction2 : null);
						if (val2 != null)
						{
							sb.AppendLine($"- Settlement's Kingdom: {val2.Name} (id:{((MBObjectBase)val2).StringId})");
							bool flag = val.IsAtWarWith((IFaction)(object)val2);
							bool flag2 = val == val2;
							bool flag3 = !flag2 && AllianceSystem.Instance != null && AllianceSystem.Instance.AreAllied(val, val2);
							string text = (flag ? "AT WAR" : (flag2 ? "SAME KINGDOM" : (flag3 ? "ALLIED" : "NEUTRAL/PEACE")));
							sb.AppendLine("- Player-Settlement kingdom relation: " + text);
						}
					}
					goto IL_019b;
				}
			}
			sb.AppendLine("- Kingdom: None (independent/mercenary)");
			goto IL_019b;
			IL_019b:
			if (combat?.Settlement != null)
			{
				Clan ownerClan = combat.Settlement.OwnerClan;
				Hero val3 = ((ownerClan != null) ? ownerClan.Leader : null);
				if (val3 != null)
				{
					int relation = mainHero.GetRelation(val3);
					sb.AppendLine($"- Settlement owner: {val3.Name} (id:{((MBObjectBase)val3).StringId}), Relation with player: {relation}");
				}
			}
			MobileParty mainParty = MobileParty.MainParty;
			int? obj;
			if (mainParty == null)
			{
				obj = null;
			}
			else
			{
				TroopRoster memberRoster = mainParty.MemberRoster;
				obj = ((memberRoster != null) ? new int?(memberRoster.TotalManCount) : ((int?)null));
			}
			int? num = obj;
			int valueOrDefault = num.GetValueOrDefault();
			sb.AppendLine($"- Player party size: {valueOrDefault}");
		}
		catch (Exception ex)
		{
			sb.AppendLine("- Error reading player context: " + ex.Message);
		}
		sb.AppendLine();
	}

	private void AppendVillageAftermath(StringBuilder sb, ActiveCombat combat, CombatResult result)
	{
		try
		{
			if (combat?.Settlement != null && combat.Settlement.IsVillage && (result == null || !result.PlayerCaptured))
			{
				sb.AppendLine();
				sb.AppendLine("## Village Aftermath");
				string text = ((combat.VillageLooted && combat.VillageBurned) ? "player looted and burned the village after the combat" : (combat.VillageLooted ? "player looted the village after the combat (took supplies and goods)" : ((!combat.VillageBurned) ? "player left the village intact after the combat (no looting or burning)" : "player burned the village after the combat (the village should appear burning/looted on the world map)")));
				sb.AppendLine("- PlayerActionOnVillage: " + text + ".");
				sb.AppendLine();
			}
		}
		catch
		{
		}
	}

	private void AppendSettlementInfo(StringBuilder sb, Settlement settlement)
	{
		sb.AppendLine("## Settlement Information");
		sb.AppendLine($"- Name: {settlement.Name} (id:{((MBObjectBase)settlement).StringId})");
		sb.AppendLine("- Type: " + GetSettlementType(settlement));
		sb.Append("- Location: ");
		List<Settlement> source = ((IEnumerable<Settlement>)Settlement.All).Where(delegate(Settlement s)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (s != null && s != settlement)
			{
				CampaignVec2 position = s.Position;
				result = (((position).Distance(settlement.Position) <= 15f) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).OrderBy(delegate(Settlement s)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			CampaignVec2 position = s.Position;
			return (position).Distance(settlement.Position);
		}).Take(5)
			.ToList();
		if (source.Any())
		{
			sb.AppendLine("Near " + string.Join(", ", source.Select(delegate(Settlement s)
			{
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_001a: Unknown result type (might be due to invalid IL or missing references)
				TextObject name = s.Name;
				CampaignVec2 position = s.Position;
				return $"{name} ({(position).Distance(settlement.Position):F1}f)";
			})));
		}
		else
		{
			sb.AppendLine("Remote location, no settlements nearby");
		}
		Hero owner = settlement.Owner;
		TextObject arg = ((owner != null) ? owner.Name : null);
		Hero owner2 = settlement.Owner;
		sb.AppendLine($"- Owner: {arg} (id:{((owner2 != null) ? ((MBObjectBase)owner2).StringId : null)})");
		CultureObject culture = settlement.Culture;
		TextObject arg2 = ((culture != null) ? ((BasicCultureObject)culture).Name : null);
		CultureObject culture2 = settlement.Culture;
		sb.AppendLine($"- Culture: {arg2} (id:{((culture2 != null) ? ((MBObjectBase)culture2).StringId : null)})");
		IFaction mapFaction = settlement.MapFaction;
		TextObject arg3 = ((mapFaction != null) ? mapFaction.Name : null);
		IFaction mapFaction2 = settlement.MapFaction;
		sb.AppendLine($"- Kingdom: {arg3} (id:{((mapFaction2 != null) ? mapFaction2.StringId : null)})");
		if (settlement.IsTown)
		{
			sb.AppendLine($"- Prosperity: {settlement.Town.Prosperity:F0}");
			sb.AppendLine($"- Security: {settlement.Town.Security:F0}");
			MobileParty garrisonParty = ((Fief)settlement.Town).GarrisonParty;
			int? obj;
			if (garrisonParty == null)
			{
				obj = null;
			}
			else
			{
				TroopRoster memberRoster = garrisonParty.MemberRoster;
				obj = ((memberRoster != null) ? new int?(memberRoster.TotalManCount) : ((int?)null));
			}
			int? num = obj;
			sb.AppendLine($"- Garrison: {num.GetValueOrDefault()} troops");
		}
		else if (settlement.IsCastle)
		{
			Town town = settlement.Town;
			int? obj2;
			if (town == null)
			{
				obj2 = null;
			}
			else
			{
				MobileParty garrisonParty2 = ((Fief)town).GarrisonParty;
				if (garrisonParty2 == null)
				{
					obj2 = null;
				}
				else
				{
					TroopRoster memberRoster2 = garrisonParty2.MemberRoster;
					obj2 = ((memberRoster2 != null) ? new int?(memberRoster2.TotalManCount) : ((int?)null));
				}
			}
			int? num = obj2;
			sb.AppendLine($"- Garrison: {num.GetValueOrDefault()} troops");
		}
		else if (settlement.IsVillage)
		{
			sb.AppendLine($"- Hearth: {settlement.Village.Hearth:F0}");
			MilitiaPartyComponent militiaPartyComponent = settlement.MilitiaPartyComponent;
			int? obj3;
			if (militiaPartyComponent == null)
			{
				obj3 = null;
			}
			else
			{
				MobileParty mobileParty = ((PartyComponent)militiaPartyComponent).MobileParty;
				if (mobileParty == null)
				{
					obj3 = null;
				}
				else
				{
					TroopRoster memberRoster3 = mobileParty.MemberRoster;
					obj3 = ((memberRoster3 != null) ? new int?(memberRoster3.TotalManCount) : ((int?)null));
				}
			}
			int? num = obj3;
			sb.AppendLine($"- Militia: {num.GetValueOrDefault()} troops");
		}
		sb.AppendLine();
	}

	private void AppendParticipantsInfo(StringBuilder sb, ActiveCombat combat)
	{
		sb.AppendLine("## Participants and Witnesses Information");
		sb.AppendLine();
		SettlementCombatLogger instance = SettlementCombatLogger.Instance;
		if (combat.TriggerNPC != null)
		{
			Hero triggerNPC = combat.TriggerNPC;
			sb.AppendLine("NPC:");
			sb.AppendLine($"- Name: {triggerNPC.Name} (id:{((MBObjectBase)triggerNPC).StringId})");
			CultureObject culture = triggerNPC.Culture;
			TextObject arg = ((culture != null) ? ((BasicCultureObject)culture).Name : null);
			CultureObject culture2 = triggerNPC.Culture;
			sb.AppendLine($"- Culture: {arg} (id:{((culture2 != null) ? ((MBObjectBase)culture2).StringId : null)})");
			Clan clan = triggerNPC.Clan;
			TextObject arg2 = ((clan != null) ? clan.Name : null);
			Clan clan2 = triggerNPC.Clan;
			sb.AppendLine($"- Clan: {arg2} (id:{((clan2 != null) ? ((MBObjectBase)clan2).StringId : null)})");
			IFaction mapFaction = triggerNPC.MapFaction;
			TextObject arg3 = ((mapFaction != null) ? mapFaction.Name : null);
			IFaction mapFaction2 = triggerNPC.MapFaction;
			sb.AppendLine($"- Kingdom: {arg3} (id:{((mapFaction2 != null) ? mapFaction2.StringId : null)})");
			NPCContext triggerContext = combat.TriggerContext;
			if (triggerContext != null)
			{
				sb.AppendLine("- Does NPC know player?: " + (triggerContext.IsPlayerKnown ? "YES" : "NO"));
			}
			else
			{
				sb.AppendLine("- Does NPC know player?: Unknown/Not established");
			}
			sb.AppendLine();
		}
		else
		{
			instance.Log("WARNING: TriggerNPC is NULL - this might cause issues!");
			sb.AppendLine("NPC:");
			sb.AppendLine("- No specific NPC involved (general conflict)");
			sb.AppendLine();
		}
		sb.AppendLine("Player:");
		sb.AppendLine($"- Name: {Hero.MainHero.Name} (id:main_hero)");
		CultureObject culture3 = Hero.MainHero.Culture;
		TextObject arg4 = ((culture3 != null) ? ((BasicCultureObject)culture3).Name : null);
		CultureObject culture4 = Hero.MainHero.Culture;
		sb.AppendLine($"- Culture: {arg4} (id:{((culture4 != null) ? ((MBObjectBase)culture4).StringId : null)})");
		Clan clan3 = Hero.MainHero.Clan;
		TextObject arg5 = ((clan3 != null) ? clan3.Name : null);
		Clan clan4 = Hero.MainHero.Clan;
		sb.AppendLine($"- Clan: {arg5} (id:{((clan4 != null) ? ((MBObjectBase)clan4).StringId : null)})");
		IFaction mapFaction3 = Hero.MainHero.MapFaction;
		TextObject arg6 = ((mapFaction3 != null) ? mapFaction3.Name : null);
		IFaction mapFaction4 = Hero.MainHero.MapFaction;
		sb.AppendLine($"- Kingdom: {arg6} (id:{((mapFaction4 != null) ? mapFaction4.StringId : null)})");
		if (Mission.Current != null)
		{
			PlayerReinforcementMissionLogic missionBehavior = Mission.Current.GetMissionBehavior<PlayerReinforcementMissionLogic>();
			if (missionBehavior != null)
			{
				int summonedTroopsCount = missionBehavior.GetSummonedTroopsCount();
				string summonedTroopsInfo = missionBehavior.GetSummonedTroopsInfo();
				sb.AppendLine($"- Summoned troops with player: {summonedTroopsCount} ({summonedTroopsInfo})");
			}
			else
			{
				sb.AppendLine("- Summoned troops with player: none");
			}
		}
		if (combat.Settlement.Owner != null)
		{
			int relation = Hero.MainHero.GetRelation(combat.Settlement.Owner);
			sb.AppendLine($"- Relation with settlement owner ({combat.Settlement.Owner.Name}): {relation}");
		}
		if (combat.Settlement.MapFaction != null && Hero.MainHero.MapFaction != null)
		{
			bool flag = FactionManager.IsAtWarAgainstFaction(Hero.MainHero.MapFaction, combat.Settlement.MapFaction);
			bool flag2 = GameVersionCompatibility.IsAlliedWithFaction(Hero.MainHero.MapFaction, combat.Settlement.MapFaction);
			if (Hero.MainHero.MapFaction == combat.Settlement.MapFaction)
			{
				sb.AppendLine("- Relation with settlement kingdom: SAME KINGDOM");
			}
			else if (flag)
			{
				sb.AppendLine("- Relation with settlement kingdom: AT WAR");
			}
			else if (flag2)
			{
				sb.AppendLine("- Relation with settlement kingdom: ALLIED");
			}
			else
			{
				sb.AppendLine("- Relation with settlement kingdom: NEUTRAL");
			}
		}
		sb.AppendLine();
	}

	private void AppendPlayerCompanionsInfo(StringBuilder sb, ActiveCombat combat)
	{
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		sb.AppendLine("## Player Companions Present");
		if (combat.PlayerCompanions == null || !combat.PlayerCompanions.Any())
		{
			sb.AppendLine("- None detected. Assume player acts alone unless allies arrive during the confrontation.");
			sb.AppendLine();
			return;
		}
		sb.AppendLine($"Total accompanying heroes: {combat.PlayerCompanions.Count}");
		foreach (Hero playerCompanion in combat.PlayerCompanions)
		{
			if (playerCompanion == null)
			{
				continue;
			}
			NPCContext nPCContextByStringId = _behavior.GetNPCContextByStringId(((MBObjectBase)playerCompanion).StringId);
			int num = (int)playerCompanion.GetRelationWithPlayer();
			string text = ((num >= 0) ? $"+{num}" : num.ToString(CultureInfo.InvariantCulture));
			string text2 = ((nPCContextByStringId != null) ? nPCContextByStringId.TrustLevel.ToString("F2", CultureInfo.InvariantCulture) : "unknown");
			bool flag = AIActionManager.Instance?.IsActionActive(playerCompanion, "follow_player") ?? false;
			bool flag2 = playerCompanion.CompanionOf == Clan.PlayerClan;
			List<string> list = new List<string>();
			if (playerCompanion.Clan != null)
			{
				list.Add($"Clan: {playerCompanion.Clan.Name} (id:{((MBObjectBase)playerCompanion.Clan).StringId})");
			}
			else
			{
				list.Add("Clan: none");
			}
			if (playerCompanion.MapFaction != null)
			{
				list.Add($"Kingdom: {playerCompanion.MapFaction.Name} (id:{playerCompanion.MapFaction.StringId})");
			}
			else
			{
				list.Add("Kingdom: none");
			}
			Settlement settlement = combat.Settlement;
			if (((settlement != null) ? settlement.MapFaction : null) != null && playerCompanion.MapFaction != null)
			{
				if (playerCompanion.MapFaction == combat.Settlement.MapFaction)
				{
					list.Add("Shares loyalty with the settlement's kingdom");
				}
				else
				{
					list.Add($"Different kingdom from settlement ({combat.Settlement.MapFaction.Name})");
				}
			}
			if (flag2)
			{
				list.Add("Member of the player's clan");
			}
			if (playerCompanion == Hero.MainHero.Spouse)
			{
				list.Add("Player's spouse");
			}
			string recentDialogueSummary = GetRecentDialogueSummary(nPCContextByStringId, 15);
			CultureObject culture = playerCompanion.Culture;
			string arg = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown";
			sb.AppendLine($"- {playerCompanion.Name} (id:{((MBObjectBase)playerCompanion).StringId})");
			sb.AppendLine($"  * Culture: {arg} | Occupation: {playerCompanion.Occupation} | Age: {playerCompanion.Age:F0}");
			sb.AppendLine("  * Allegiance: " + string.Join("; ", list));
			sb.AppendLine("  * Relationship with player: " + text + " | Trust: " + text2 + " | Currently " + (flag ? "actively following" : "nearby without active follow command"));
			sb.AppendLine("  * Recent dialogue context: " + recentDialogueSummary);
		}
		sb.AppendLine();
	}

	private void AppendSettlementNotables(StringBuilder sb, Settlement settlement)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		sb.AppendLine("Settlement Notables (Important Persons):");
		try
		{
			MBReadOnlyList<Hero> notables = settlement.Notables;
			if (notables != null && ((IEnumerable<Hero>)notables).Any())
			{
				foreach (Hero item in (List<Hero>)(object)notables)
				{
					TextObject name = item.Name;
					string stringId = ((MBObjectBase)item).StringId;
					CharacterObject characterObject = item.CharacterObject;
					sb.AppendLine($"- {name} (id:{stringId}) - {((characterObject != null) ? new Occupation?(characterObject.Occupation) : ((Occupation?)null))}");
				}
			}
			else
			{
				sb.AppendLine("- No notables in this settlement");
			}
		}
		catch (Exception ex)
		{
			sb.AppendLine("- Error reading notables: " + ex.Message);
		}
		sb.AppendLine();
	}

	private void AppendNearbyWitnesses(StringBuilder sb)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Invalid comparison between Unknown and I4
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Invalid comparison between Unknown and I4
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		sb.AppendLine("Nearby Witnesses");
		try
		{
			if (Mission.Current == null || Agent.Main == null)
			{
				sb.AppendLine("- Cannot determine witnesses (no active mission)");
				sb.AppendLine();
				return;
			}
			Vec3 playerPosition = Agent.Main.Position;
			float witnessDistance = 15f;
			PlayerReinforcementMissionLogic missionBehavior = Mission.Current.GetMissionBehavior<PlayerReinforcementMissionLogic>();
			List<Agent> list = ((IEnumerable<Agent>)Mission.Current.Agents).Where(delegate(Agent a)
			{
				//IL_001c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0021: Unknown result type (might be due to invalid IL or missing references)
				//IL_0025: Unknown result type (might be due to invalid IL or missing references)
				int result;
				if (a != null && a.IsHuman && a.IsActive() && a != Agent.Main)
				{
					Vec3 position2 = a.Position;
					result = (((position2).Distance(playerPosition) <= witnessDistance) ? 1 : 0);
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}).ToList();
			if (list.Any())
			{
				List<Agent> list2 = new List<Agent>();
				int num = 0;
				int num2 = 0;
				foreach (Agent item in list)
				{
					if (missionBehavior != null && missionBehavior.IsSummonedTroop(item))
					{
						continue;
					}
					BasicCharacterObject character = item.Character;
					CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
					if (val != null && ((BasicCharacterObject)val).IsHero)
					{
						list2.Add(item);
					}
					else if (val != null)
					{
						if ((int)val.Occupation == 7 || (int)val.Occupation == 2)
						{
							num2++;
						}
						else
						{
							num++;
						}
					}
				}
				if (list2.Any())
				{
					sb.AppendLine("Important witnesses (notables/heroes):");
					foreach (Agent item2 in list2.Take(10))
					{
						string arg = item2.Name?.ToString() ?? "Unknown";
						BasicCharacterObject character2 = item2.Character;
						string arg2 = ((character2 != null) ? ((MBObjectBase)character2).StringId : null) ?? "unknown";
						Vec3 position = item2.Position;
						float num3 = (position).Distance(playerPosition);
						sb.AppendLine($"- {arg} (id:{arg2}) - {num3:F1}m away");
					}
				}
				if (num > 0 || num2 > 0)
				{
					sb.AppendLine("Common witnesses (no unique IDs):");
					if (num > 0)
					{
						sb.AppendLine($"- {num} civilians nearby");
					}
					if (num2 > 0)
					{
						sb.AppendLine($"- {num2} soldiers/guards nearby");
					}
				}
			}
			else
			{
				sb.AppendLine("- No witnesses nearby");
			}
		}
		catch (Exception ex)
		{
			sb.AppendLine("- Error finding witnesses: " + ex.Message);
		}
		sb.AppendLine();
	}

	private void AppendDialogHistory(StringBuilder sb, NPCContext context)
	{
		SettlementCombatLogger instance = SettlementCombatLogger.Instance;
		sb.AppendLine("## Dialog History (NPC and Player)");
		if (context == null)
		{
			instance.Log("WARNING: NPCContext is NULL in AppendDialogHistory!");
			sb.AppendLine("- No context available");
			sb.AppendLine();
			return;
		}
		if (context.ConversationHistory == null || !context.ConversationHistory.Any())
		{
			instance.Log($"WARNING: ConversationHistory is empty or NULL (Count: {context.ConversationHistory?.Count ?? 0})");
			sb.AppendLine("- No dialog history");
			sb.AppendLine();
			return;
		}
		int count = Math.Max(0, context.ConversationHistory.Count - 50);
		List<string> list = context.ConversationHistory.Skip(count).ToList();
		instance.Log($"AppendDialogHistory: Adding {list.Count} messages");
		foreach (string item in list)
		{
			sb.AppendLine("- " + item);
		}
		sb.AppendLine();
	}

	private void AppendWorldInfo(StringBuilder sb)
	{
		sb.AppendLine("## World Context");
		try
		{
			string value = WorldInfoManager.Instance.ReadWorldInfo();
			if (!string.IsNullOrEmpty(value))
			{
				sb.AppendLine(value);
			}
		}
		catch (Exception ex)
		{
			sb.AppendLine("- Error reading world info: " + ex.Message);
		}
		sb.AppendLine();
		sb.AppendLine("- Current time of day: " + GetTimeOfDay());
		sb.AppendLine();
	}

	private void AppendAllKingdoms(StringBuilder sb)
	{
		sb.AppendLine("## All Kingdoms in Calradia");
		try
		{
			List<Kingdom> list = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => k != null && !k.IsEliminated).ToList();
			if (list.Any())
			{
				foreach (Kingdom item in list)
				{
					sb.AppendLine($"- {item.Name} (id:{((MBObjectBase)item).StringId})");
					Hero leader = item.Leader;
					TextObject arg = ((leader != null) ? leader.Name : null);
					Hero leader2 = item.Leader;
					sb.AppendLine($"  - Ruler: {arg} (id:{((leader2 != null) ? ((MBObjectBase)leader2).StringId : null)})");
					CultureObject culture = item.Culture;
					TextObject arg2 = ((culture != null) ? ((BasicCultureObject)culture).Name : null);
					CultureObject culture2 = item.Culture;
					sb.AppendLine($"  - Culture: {arg2} (id:{((culture2 != null) ? ((MBObjectBase)culture2).StringId : null)})");
				}
			}
			else
			{
				sb.AppendLine("- No kingdoms found");
			}
		}
		catch (Exception ex)
		{
			sb.AppendLine("- Error reading kingdoms: " + ex.Message);
		}
		sb.AppendLine();
	}

	private void AppendFirstAnalysisHistory(StringBuilder sb, ActiveCombat combat)
	{
		sb.AppendLine("## Conflict History (from First Analysis)");
		sb.AppendLine();
		if (combat?.Analysis == null)
		{
			sb.AppendLine("- No analysis data available");
			sb.AppendLine();
			return;
		}
		CombatSituationAnalysis analysis = combat.Analysis;
		sb.AppendLine("### Basic Conflict Information:");
		sb.AppendLine($"- Location: {combat.Settlement.Name} (id:{((MBObjectBase)combat.Settlement).StringId})");
		string text = "Unknown";
		if (analysis.AggressorStringId == "main_hero")
		{
			Hero mainHero = Hero.MainHero;
			text = ((mainHero == null) ? null : ((object)mainHero.Name)?.ToString()) ?? "Player";
		}
		else
		{
			Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == analysis.AggressorStringId));
			if (val != null)
			{
				text = ((object)val.Name)?.ToString() ?? "Unknown";
			}
		}
		sb.AppendLine("- Aggressor: " + text + " (string_id:" + analysis.AggressorStringId + ")");
		string text2 = "Unknown";
		Hero val2 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == analysis.DefenderStringId));
		if (val2 != null)
		{
			text2 = ((object)val2.Name)?.ToString() ?? "Unknown";
		}
		else
		{
			Hero val3 = ((IEnumerable<Settlement>)Settlement.All).SelectMany((Settlement s) => (IEnumerable<Hero>)s.Notables).FirstOrDefault((Func<Hero, bool>)((Hero n) => n != null && ((MBObjectBase)n).StringId == analysis.DefenderStringId));
			if (val3 != null)
			{
				text2 = ((object)val3.Name)?.ToString() ?? "Unknown";
			}
		}
		sb.AppendLine("- Defender: " + text2 + " (string_id:" + analysis.DefenderStringId + ")");
		if (analysis.Witnesses != null && analysis.Witnesses.Any())
		{
			sb.AppendLine("- Witnesses: " + string.Join(", ", analysis.Witnesses));
		}
		else
		{
			sb.AppendLine("- Witnesses: None identified");
		}
		sb.AppendLine($"- Player Involved (from first analysis): {analysis.PlayerInvolved}");
		sb.AppendLine();
		sb.AppendLine("### Situation Description (from first analysis):");
		sb.AppendLine("\"" + analysis.SituationDescription + "\"");
		sb.AppendLine();
		sb.AppendLine("### Expected Defender Response (from first analysis):");
		sb.AppendLine($"- Defenders Required: {analysis.NeedsDefenders}");
		if (analysis.NeedsDefenders)
		{
			sb.AppendLine("- Defender Strength: Handled automatically by the mod (numeric fields were set to 0 on purpose).");
			if (analysis.Lords != null && analysis.Lords.Any())
			{
				sb.AppendLine("- Lords expected to intervene:");
				foreach (LordIntervention lord in analysis.Lords)
				{
					Hero val4 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == lord.StringId));
					string text3 = ((val4 == null) ? null : ((object)val4.Name)?.ToString()) ?? lord.StringId;
					sb.AppendLine("  - " + text3 + " (id:" + lord.StringId + ")");
					sb.AppendLine("    - Side: " + lord.Side);
					sb.AppendLine("    - Reason: \"" + lord.InterventionReason + "\"");
					sb.AppendLine("    - Arrival phrase: \"" + lord.ArrivalPhrase + "\"");
				}
			}
			else
			{
				sb.AppendLine("- Lords: None expected");
			}
		}
		else
		{
			sb.AppendLine("- No defenders were required for this situation");
		}
		sb.AppendLine();
		sb.AppendLine("### Civilian Phrases (from first analysis):");
		if (analysis.CivilianPhrasesMalePanic != null && analysis.CivilianPhrasesMalePanic.Any())
		{
			sb.AppendLine("- Panicking men shouted: " + string.Join(", ", analysis.CivilianPhrasesMalePanic.Select((string p) => "\"" + p + "\"")));
		}
		if (analysis.CivilianPhrasesMaleFight != null && analysis.CivilianPhrasesMaleFight.Any())
		{
			sb.AppendLine("- Fighting men shouted: " + string.Join(", ", analysis.CivilianPhrasesMaleFight.Select((string p) => "\"" + p + "\"")));
		}
		if (analysis.CivilianPhrasesFemale != null && analysis.CivilianPhrasesFemale.Any())
		{
			sb.AppendLine("- Women shouted: " + string.Join(", ", analysis.CivilianPhrasesFemale.Select((string p) => "\"" + p + "\"")));
		}
		if (analysis.CivilianPhrasesChild != null && analysis.CivilianPhrasesChild.Any())
		{
			sb.AppendLine("- Children shouted: " + string.Join(", ", analysis.CivilianPhrasesChild.Select((string p) => "\"" + p + "\"")));
		}
		if (analysis.NotablePhrases != null && analysis.NotablePhrases.Any())
		{
			sb.AppendLine("- Notable persons shouted:");
			foreach (KeyValuePair<string, List<string>> notablePhrase in analysis.NotablePhrases)
			{
				sb.AppendLine("  - " + notablePhrase.Key + ": " + string.Join(", ", notablePhrase.Value.Select((string p) => "\"" + p + "\"")));
			}
		}
		sb.AppendLine();
	}

	private void AppendActiveDynamicEvents(StringBuilder sb)
	{
		sb.AppendLine("## Active Dynamic Events");
		try
		{
			List<DynamicEvent> activeEvents = DynamicEventsManager.Instance.GetActiveEvents();
			if (activeEvents != null && activeEvents.Any())
			{
				foreach (DynamicEvent item in activeEvents.Take(10))
				{
					sb.AppendLine("- [" + item.Type + "] " + item.Description);
					sb.AppendLine($"  (id:{item.Id}, importance:{item.Importance}, age:{item.DaysSinceCreation} days)");
				}
			}
			else
			{
				sb.AppendLine("- No active dynamic events");
			}
		}
		catch (Exception ex)
		{
			sb.AppendLine("- Error reading dynamic events: " + ex.Message);
		}
		sb.AppendLine();
	}

	private void AppendNearbyLords(StringBuilder sb, ActiveCombat combat)
	{
		sb.AppendLine("## Nearby Lords");
		try
		{
			Settlement settlement = combat.Settlement;
			var list = (from x in ((IEnumerable<MobileParty>)MobileParty.All).Where(delegate(MobileParty mp)
				{
					//IL_0029: Unknown result type (might be due to invalid IL or missing references)
					//IL_002e: Unknown result type (might be due to invalid IL or missing references)
					//IL_0037: Unknown result type (might be due to invalid IL or missing references)
					int result;
					if (mp != null && mp.IsLordParty && mp.LeaderHero != null && !mp.LeaderHero.IsDead && mp.CurrentSettlement == null)
					{
						CampaignVec2 position = mp.Position;
						result = (((position).Distance(settlement.Position) <= 12f) ? 1 : 0);
					}
					else
					{
						result = 0;
					}
					return (byte)result != 0;
				}).Select(delegate(MobileParty mp)
				{
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					//IL_000c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0015: Unknown result type (might be due to invalid IL or missing references)
					Hero leaderHero = mp.LeaderHero;
					CampaignVec2 position = mp.Position;
					return new
					{
						Lord = leaderHero,
						Distance = (position).Distance(settlement.Position),
						TroopCount = mp.MemberRoster.TotalManCount
					};
				})
				orderby x.Distance
				select x).ToList();
			if (list.Any())
			{
				foreach (var item in list)
				{
					float distance = item.Distance;
					Hero lord = item.Lord;
					sb.AppendLine($"### {lord.Name} (id:{((MBObjectBase)lord).StringId})");
					CultureObject culture = lord.Culture;
					TextObject arg = ((culture != null) ? ((BasicCultureObject)culture).Name : null);
					CultureObject culture2 = lord.Culture;
					sb.AppendLine($"- Culture: {arg} (id:{((culture2 != null) ? ((MBObjectBase)culture2).StringId : null)})");
					Clan clan = lord.Clan;
					TextObject arg2 = ((clan != null) ? clan.Name : null);
					Clan clan2 = lord.Clan;
					sb.AppendLine($"- Clan: {arg2} (id:{((clan2 != null) ? ((MBObjectBase)clan2).StringId : null)})");
					IFaction mapFaction = lord.MapFaction;
					TextObject arg3 = ((mapFaction != null) ? mapFaction.Name : null);
					IFaction mapFaction2 = lord.MapFaction;
					sb.AppendLine($"- Kingdom: {arg3} (id:{((mapFaction2 != null) ? mapFaction2.StringId : null)})");
					string text = "Unknown";
					if (lord.MapFaction == settlement.MapFaction)
					{
						text = "Allied (same kingdom)";
					}
					else if (lord.MapFaction != null && settlement.MapFaction != null)
					{
						text = (FactionManager.IsAtWarAgainstFaction(lord.MapFaction, settlement.MapFaction) ? "Enemy (at war)" : ((!GameVersionCompatibility.IsAlliedWithFaction(lord.MapFaction, settlement.MapFaction)) ? "Neutral" : "Allied"));
					}
					sb.AppendLine("- Relation with settlement kingdom: " + text);
					if (lord.MapFaction != null)
					{
						bool flag = settlement.MapFaction != null && FactionManager.IsAtWarAgainstFaction(lord.MapFaction, settlement.MapFaction);
						sb.AppendLine("- At war with settlement's kingdom: " + (flag ? "YES" : "NO"));
						bool flag2 = Hero.MainHero.MapFaction != null && FactionManager.IsAtWarAgainstFaction(lord.MapFaction, Hero.MainHero.MapFaction);
						sb.AppendLine("- At war with player's kingdom: " + (flag2 ? "YES" : "NO"));
					}
					int relation = lord.GetRelation(Hero.MainHero);
					sb.AppendLine($"- Relation with player: {relation}");
					if (combat.TriggerNPC != null)
					{
						int relation2 = lord.GetRelation(combat.TriggerNPC);
						sb.AppendLine($"- Relation with {combat.TriggerNPC.Name}: {relation2}");
					}
					sb.AppendLine($"- Distance: {distance:F1} map units");
					sb.AppendLine($"- Troops: {item.TroopCount}");
					AppendLordDialogHistory(sb, lord);
					sb.AppendLine();
				}
			}
			else
			{
				sb.AppendLine("- No lords nearby within 12 map units");
			}
		}
		catch (Exception ex)
		{
			sb.AppendLine("- Error finding nearby lords: " + ex.Message);
		}
		sb.AppendLine();
	}

	private void AppendLordDialogHistory(StringBuilder sb, Hero lord)
	{
		try
		{
			NPCContext orCreateNPCContext = _behavior.GetOrCreateNPCContext(lord);
			if (orCreateNPCContext != null && orCreateNPCContext.ConversationHistory != null && orCreateNPCContext.ConversationHistory.Any())
			{
				sb.AppendLine("  Recent dialog with player:");
				int count = Math.Max(0, orCreateNPCContext.ConversationHistory.Count - 25);
				List<string> list = orCreateNPCContext.ConversationHistory.Skip(count).ToList();
				{
					foreach (string item in list)
					{
						sb.AppendLine("    - " + item);
					}
					return;
				}
			}
			sb.AppendLine("  Recent dialog: None");
		}
		catch
		{
			sb.AppendLine("  Recent dialog: Error reading");
		}
	}

	private void AppendAnalysisInstructions(StringBuilder sb, Settlement settlement)
	{
		sb.AppendLine("## Analysis Instructions");
		sb.AppendLine();
		sb.AppendLine("1. Aggressor & Defender");
		sb.AppendLine("   - Determine who initiated the violence (`aggressor_string_id`).");
		sb.AppendLine("   - Determine who is defending themselves (`defender_string_id`).");
		sb.AppendLine();
		sb.AppendLine("2. Witnesses");
		sb.AppendLine("   - Identify potential witnesses near the scene.");
		sb.AppendLine("   - ONLY include string_ids of IMPORTANT witnesses (notables/heroes from 'Important witnesses' list above).");
		sb.AppendLine();
		sb.AppendLine("3. Defense Response");
		sb.AppendLine("   - Return ONLY the boolean `needs_defenders` (true/false).");
		sb.AppendLine("   - Do NOT add, describe, or hint at defender numbers, unit types, or arrival timing. The game handles everything.");
		sb.AppendLine("   - CHECK CONTEXT FIRST: If both parties explicitly agree to a contained duel (1-on-1, no allies) or the confrontation happens quietly where no one can raise alarm (no witnesses, secluded spot), set `needs_defenders = false` even if the topic is serious.");
		sb.AppendLine("   - If the aggressor strikes while unseen (e.g., assassination, stealth kill) and there are no witnesses to call for help, keep `needs_defenders = false`.");
		sb.AppendLine("   - Only request defenders when someone could realistically alert guards/militia or the settlement would naturally mobilize reinforcements.");
		sb.AppendLine();
		sb.AppendLine("4. Civilian Panic");
		sb.AppendLine("   - Return the boolean `civilian_panic` (true/false).");
		sb.AppendLine("   - CRITICAL: If `needs_defenders = true`, then `civilian_panic = true` ALWAYS.");
		sb.AppendLine("   - If `needs_defenders = false`, determine `civilian_panic` based on:");
		sb.AppendLine("     * Was the violence public and witnessed by civilians? → `civilian_panic = true`");
		sb.AppendLine("     * Was it a quiet assassination/killing with no civilian witnesses? → `civilian_panic = false`");
		sb.AppendLine("     * Did civilians see the violence or its consequences (blood, body)? → `civilian_panic = true`");
		sb.AppendLine("   - When `civilian_panic = true`: Generate all civilian phrases (panic, fight, female, child) and notable phrases.");
		sb.AppendLine("   - When `civilian_panic = false`: Do NOT generate civilian phrases (use empty arrays) and do NOT generate notable phrases (use empty object {}).");
		sb.AppendLine();
		sb.AppendLine("5. Lords");
		sb.AppendLine("   - IMPORTANT: Lords from settlement's kingdom should USUALLY come to defend their settlement!");
		sb.AppendLine("   - Lords from ENEMY kingdoms may come to attack or support attackers.");
		sb.AppendLine("   - For EACH lord who will intervene, you MUST determine:");
		sb.AppendLine("     * Which side they support (\"player_side\" or \"npc_side\") based on:");
		sb.AppendLine("       - Kingdom allegiances (lords defend their kingdom's settlements!)");
		sb.AppendLine("       - Wars between kingdoms");
		sb.AppendLine("       - Personal relations with player and NPC");
		sb.AppendLine("       - Previous dialog history");
		sb.AppendLine("       - Cultural and clan ties");
		sb.AppendLine("     * Internal reason for intervention (not shown to player).");
		sb.AppendLine("     * What the lord will say when arriving (shown to player).");
		sb.AppendLine();
		sb.AppendLine("6. Determining `player_involved` (Is Player's Identity Known?)");
		sb.AppendLine("   - IMPORTANT: Determine `player_involved` ONLY from the conversation between the PLAYER and the MAIN NPC of this scene (Trigger NPC in the 'Participants' section).");
		sb.AppendLine("   - DO NOT use recent dialogue history with nearby lords to decide if the player was recognized. Lord dialogues are used ONLY to decide their stance (support player / support settlement / stay neutral).");
		sb.AppendLine("   - Analyze the dialog history between player and the Trigger NPC. If this NPC knows player's name, clan, origin → `player_involved = TRUE`, but if the NPC knows the player yet the NPC was killed and there are no witnesses and no information → `player_involved = FALSE`.");
		sb.AppendLine("   - Even if you (as AI) know this is the player, if the Trigger NPC in the dialog treated them as a stranger and didn't recognize them – set `player_involved = FALSE`!");
		sb.AppendLine("   - CRITICAL: If you set `player_involved = FALSE`:");
		sb.AppendLine("     * DO NOT use player's name in the description, it must be WITHOUT identifying the player.");
		sb.AppendLine();
		sb.AppendLine("7. Reactions to the Situation");
		sb.AppendLine("   - Generate UNIQUE random phrases for each group:");
		sb.AppendLine("     * Panicking men's phrases panic, fear.");
		sb.AppendLine("     * Fighting men's phrases for those who will join the fight.");
		sb.AppendLine("     * Women's phrases panic, fear, protection of children.");
		sb.AppendLine("     * Children's phrases crying, screaming, confusion.");
		sb.AppendLine("     * Notable persons phrases: ONLY for notables/heroes from 'Settlement Notables' and 'Important witnesses' sections (generate 2 unique phrases for EACH notable/hero, use their string_id as key).");
		sb.AppendLine();
		sb.AppendLine("8. Player Companions Standing with You");
		sb.AppendLine("   - Review the 'Player Companions Present' section.");
		sb.AppendLine("   - For EACH companion listed decide if they will: support the player (`support_player`), side against them (`oppose_player`), or refuse to fight (`stay_out`).");
		sb.AppendLine("   - Base your choice on their loyalties, recent promises, trust toward the player, and the settlement's faction.");
		sb.AppendLine("   - Neutral/peaceful stance means they disengage and should NOT fight for either side.");
		sb.AppendLine();
	}

	private void AppendResponseFormat(StringBuilder sb, string gameLanguage)
	{
		sb.AppendLine("## Response Format");
		sb.AppendLine();
		sb.AppendLine("CRITICAL REQUIREMENTS:");
		sb.AppendLine("1. Your response MUST be a SINGLE, VALID JSON object - no markdown, no code blocks, no explanations before or after.");
		sb.AppendLine("2. Start your response with '{' and end with '}'.");
		sb.AppendLine("3. Use ONLY string_ids from the information provided above.");
		sb.AppendLine();
		sb.AppendLine("### Field Descriptions:");
		sb.AppendLine();
		sb.AppendLine("- `aggressor_string_id`: (string) String_id of who initiated violence. Use string_id from Participants section above (e.g., \"main_hero\", \"lord_1_27\").");
		sb.AppendLine("- `defender_string_id`: (string) String_id of who is defending. Use string_id from Participants section above.");
		sb.AppendLine("- `witnesses`: (array of strings) Array of string_ids of IMPORTANT witnesses ONLY (notables/heroes from 'Important witnesses' list). Do NOT include generic civilians/soldiers. Use [] if none.");
		sb.AppendLine("- `needs_defenders`: (boolean) true if defenders should respond, false otherwise. Set to false for agreed duels/private fights or silent situations where no one can summon help.");
		sb.AppendLine("- `civilian_panic`: (boolean) true if civilians should panic/flee and generate phrases, false otherwise. CRITICAL: If `needs_defenders = true`, then `civilian_panic = true` ALWAYS. If `needs_defenders = false`, determine based on whether civilians witnessed the violence.");
		sb.AppendLine("- `lords`: (array of objects or null) Lord intervention data. Each object: {\"string_id\": \"lord_string_id\", \"side\": \"player_side\"|\"npc_side\", \"intervention_reason\": \"internal reason\", \"arrival_phrase\": \"what lord says\"}. Use null if absolutely no lords are expected.");
		sb.AppendLine("- `player_involved`: (boolean) true if NPC knew player's identity, false if treated as stranger. Check dialog history!");
		sb.AppendLine($"- `situation_description`: (string) Description of what happened. Length: {GlobalSettings<ModSettings>.Instance.DynamicEventsMinLength}-{GlobalSettings<ModSettings>.Instance.DynamicEventsMaxLength} characters. In {gameLanguage}. Do NOT use string_ids in description, use names.");
		sb.AppendLine("- `civilian_phrases_male_panic`: (array of 12 strings) Exactly 12 unique phrases in " + gameLanguage + " for panicking men. REQUIRED if `civilian_panic = true`, use [] if `civilian_panic = false`.");
		sb.AppendLine("- `civilian_phrases_male_fight`: (array of 12 strings) Exactly 12 unique phrases in " + gameLanguage + " for fighting men. REQUIRED if `civilian_panic = true`, use [] if `civilian_panic = false`.");
		sb.AppendLine("- `civilian_phrases_female`: (array of 12 strings) Exactly 12 unique phrases in " + gameLanguage + " for women. REQUIRED if `civilian_panic = true`, use [] if `civilian_panic = false`.");
		sb.AppendLine("- `civilian_phrases_child`: (array of 12 strings) Exactly 12 unique phrases in " + gameLanguage + " for children. REQUIRED if `civilian_panic = true`, use [] if `civilian_panic = false`.");
		sb.AppendLine("- `notable_phrases`: (object) Object with notable string_ids as keys, arrays of 2 phrases in " + gameLanguage + " as values. Format: {\"notable_string_id\": [\"phrase1\", \"phrase2\"]}. Only include notables from 'Settlement Notables' and 'Important witnesses' sections. REQUIRED if `civilian_panic = true`, use {} if `civilian_panic = false`.");
		sb.AppendLine("- `companion_stance`: (object) Decisions for companions listed above. Format: {\"companion_string_id\": \"support_player\"|\"oppose_player\"|\"stay_out\", ...}. Use {} if no companions or none present.");
		sb.AppendLine();
		sb.AppendLine("JSON STRUCTURE (example with proper types):");
		sb.AppendLine("{");
		sb.AppendLine("  \"aggressor_string_id\": \"main_hero\",");
		sb.AppendLine("  \"defender_string_id\": \"lord_1_27\",");
		sb.AppendLine("  \"witnesses\": [\"CharacterObject_2349\", \"CharacterObject_1756\"],");
		sb.AppendLine("  \"needs_defenders\": true,");
		sb.AppendLine("  \"civilian_panic\": true,");
		sb.AppendLine("  \"lords\": null,");
		sb.AppendLine("  \"player_involved\": false,");
		sb.AppendLine("  \"situation_description\": \"description situation here\",");
		sb.AppendLine("  \"civilian_phrases_male_panic\": [\"phrase1\", \"phrase2\"],");
		sb.AppendLine("  \"civilian_phrases_male_fight\": [\"phrase1\", \"phrase2\"],");
		sb.AppendLine("  \"civilian_phrases_female\": [\"phrase1\", \"phrase2\"],");
		sb.AppendLine("  \"civilian_phrases_child\": [\"phrase1\", \"phrase2\"],");
		sb.AppendLine("  \"notable_phrases\": {\"CharacterObject_2349\": [\"phrase1\", \"phrase2\"], \"CharacterObject_1756\": [\"phrase1\", \"phrase2\"]},");
		sb.AppendLine("  \"companion_stance\": {\"CharacterObject_1798\": \"support_player\"}");
		sb.AppendLine("}");
		sb.AppendLine();
	}

	private string GetRecentDialogueSummary(NPCContext context, int maxLines)
	{
		if (context?.ConversationHistory == null || context.ConversationHistory.Count == 0)
		{
			return "No recent dialogue recorded.";
		}
		int count = context.ConversationHistory.Count;
		int count2 = Math.Max(0, count - maxLines);
		List<string> list = (from l in context.ConversationHistory.Skip(count2).Select(SanitizeDialogueLine)
			where !string.IsNullOrEmpty(l)
			select l).ToList();
		if (!list.Any())
		{
			return "No recent dialogue recorded.";
		}
		return string.Join(" | ", list);
	}

	private string SanitizeDialogueLine(string line)
	{
		if (string.IsNullOrWhiteSpace(line))
		{
			return string.Empty;
		}
		string text = line.Replace("\r", " ").Replace("\n", " ").Trim();
		if (text.Length > 160)
		{
			text = text.Substring(0, 157) + "...";
		}
		return text;
	}

	private void AppendCombatSummary(StringBuilder sb, ActiveCombat combat, CombatResult result)
	{
		sb.AppendLine("## Actual Defender Response (what really happened)");
		sb.AppendLine();
		if (result.SimpleDefendersArrived)
		{
			sb.AppendLine($"- Simple Defenders: ARRIVED ({result.SimpleDefendersSpawned} units)");
		}
		else
		{
			sb.AppendLine("- Simple Defenders: DID NOT ARRIVE");
		}
		if (result.MilitiaArrived)
		{
			sb.AppendLine($"- Militia: ARRIVED ({result.MilitiaSpawned} units)");
		}
		else
		{
			sb.AppendLine("- Militia: Did not arrive");
		}
		if (result.GuardsArrived)
		{
			sb.AppendLine($"- Guards: ARRIVED ({result.GuardsSpawned} units)");
		}
		else
		{
			sb.AppendLine("- Guards: Did not arrive");
		}
		if (result.LordsArrived.Any())
		{
			sb.AppendLine("- Lords:");
			foreach (LordArrivalInfo item in result.LordsArrived)
			{
				string text = (item.OnPlayerSide ? "DEFENDING PLAYER" : "AGAINST PLAYER");
				string arg = ((item.TroopsLost > 0) ? $"Lost {item.TroopsLost} troops" : "NO LOSSES");
				sb.AppendLine("  - " + item.LordName + " (id:" + item.LordStringId + ") - " + text);
				sb.AppendLine($"    Troops: {item.TroopsSpawned} spawned, {arg}");
			}
		}
		else
		{
			sb.AppendLine("- Lords: Did not arrive");
		}
		if (result.PlayerSummonedTroopsCount > 0)
		{
			sb.AppendLine($"- Player's summoned troops: {result.PlayerSummonedTroopsCount} ({result.PlayerSummonedTroopsInfo})");
		}
		else
		{
			sb.AppendLine("- Player's summoned troops: none");
		}
		sb.AppendLine();
	}

	private void AppendCombatStatistics(StringBuilder sb, CombatResult result)
	{
		sb.AppendLine("## Combat Statistics");
		int num = result.DefenderCasualties.Killed + result.DefenderCasualties.Wounded;
		if (result.SimpleDefendersArrived)
		{
			num += result.SimpleDefendersSpawned;
		}
		if (result.MilitiaArrived)
		{
			num += result.MilitiaSpawned;
		}
		if (result.GuardsArrived)
		{
			num += result.GuardsSpawned;
		}
		foreach (LordArrivalInfo item in result.LordsArrived)
		{
			if (!item.OnPlayerSide)
			{
				num += item.TroopsSpawned;
			}
		}
		int num2 = result.AttackerCasualties.Killed + result.AttackerCasualties.Wounded;
		foreach (LordArrivalInfo item2 in result.LordsArrived)
		{
			if (item2.OnPlayerSide)
			{
				num2 += item2.TroopsSpawned;
			}
		}
		int playerSummonedTroopsCount = result.PlayerSummonedTroopsCount;
		num2 += playerSummonedTroopsCount;
		sb.AppendLine($"- Defender Total Troops: {num}");
		sb.AppendLine($"- Defender Losses: {result.DefenderCasualties.Killed} killed, {result.DefenderCasualties.Wounded} wounded");
		sb.AppendLine($"- Attacker Total Troops: {num2}");
		sb.AppendLine($"- Attacker Losses: {result.AttackerCasualties.Killed} killed, {result.AttackerCasualties.Wounded} wounded");
		if (playerSummonedTroopsCount > 0)
		{
			sb.AppendLine($"  (Player summoned troops: {playerSummonedTroopsCount} included in attacker total)");
		}
		sb.AppendLine();
		CivilianCasualtySummary civilianCasualties = result.CivilianCasualties;
		if (civilianCasualties.MenKilled + civilianCasualties.MenWounded + civilianCasualties.WomenKilled + civilianCasualties.WomenWounded + civilianCasualties.ChildrenKilled + civilianCasualties.ChildrenWounded > 0)
		{
			sb.AppendLine("### Civilian Casualties");
			if (civilianCasualties.MenKilled + civilianCasualties.MenWounded > 0)
			{
				sb.AppendLine($"- Men: {civilianCasualties.MenKilled} killed, {civilianCasualties.MenWounded} wounded");
			}
			if (civilianCasualties.WomenKilled + civilianCasualties.WomenWounded > 0)
			{
				sb.AppendLine($"- Women: {civilianCasualties.WomenKilled} killed, {civilianCasualties.WomenWounded} wounded");
			}
			if (civilianCasualties.ChildrenKilled + civilianCasualties.ChildrenWounded > 0)
			{
				sb.AppendLine($"- Children: {civilianCasualties.ChildrenKilled} killed, {civilianCasualties.ChildrenWounded} wounded");
			}
			sb.AppendLine();
		}
		if (result.ImportantCasualties.Any())
		{
			sb.AppendLine("### Important Lords and Heroes");
			foreach (VipCasualtyRecord vip in result.ImportantCasualties)
			{
				string text = (vip.IsKilled ? "killed" : "wounded");
				string text2 = ((vip.Side == CombatSide.Defenders) ? "defender" : ((vip.Side == CombatSide.Attackers) ? "attacker" : "unknown side"));
				string text3 = ((!string.IsNullOrEmpty(vip.VictimStringId)) ? (vip.VictimName + " (string_id:" + vip.VictimStringId + ")") : vip.VictimName);
				string text4 = string.Empty;
				if (!string.IsNullOrEmpty(vip.KillerName))
				{
					bool flag = false;
					if (!string.IsNullOrEmpty(vip.KillerStringId) && vip.KillerStringId != "unknown" && vip.KillerStringId != "unknown_agent")
					{
						Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == vip.KillerStringId));
						flag = ((val == null) ? (vip.KillerStringId.StartsWith("lord_") || vip.KillerStringId == "main_hero" || vip.KillerStringId.StartsWith("CharacterObject_")) : (val.IsLord || val == Hero.MainHero || val.IsNotable));
					}
					text4 = ((!flag) ? (" by " + vip.KillerName) : (" by " + vip.KillerName + " (string_id:" + vip.KillerStringId + ")"));
				}
				sb.AppendLine("- " + text3 + " (" + text2 + ") " + text + text4);
			}
			sb.AppendLine();
		}
		sb.AppendLine($"- Total Killed: {result.TotalKilled}");
		sb.AppendLine($"- Total Wounded: {result.TotalWounded}");
		sb.AppendLine($"- Civilians Killed: {result.CiviliansKilled}");
		sb.AppendLine($"- Civilians Wounded: {result.CiviliansWounded}");
		sb.AppendLine();
		if (result.PlayerEvacuated)
		{
			sb.AppendLine("### Player Outcome");
			Hero mainHero = Hero.MainHero;
			string text5 = ((mainHero == null) ? null : ((object)mainHero.Name)?.ToString()) ?? "Player";
			sb.AppendLine("- " + text5 + " (string_id:main_hero) was knocked out but evacuated by his own troops and escaped captivity.");
			sb.AppendLine("- involved_player: true");
			sb.AppendLine();
		}
		else if (result.PlayerCaptured)
		{
			sb.AppendLine("### Player Outcome");
			Hero mainHero2 = Hero.MainHero;
			string text6 = ((mainHero2 == null) ? null : ((object)mainHero2.Name)?.ToString()) ?? "Player";
			if (result.PlayerPrisonSettlement != null)
			{
				sb.AppendLine($"- {text6} (string_id:main_hero) was captured and is now imprisoned in {result.PlayerPrisonSettlement.Name} (id:{((MBObjectBase)result.PlayerPrisonSettlement).StringId}).");
			}
			else
			{
				sb.AppendLine("- " + text6 + " (string_id:main_hero) was captured and is now a prisoner.");
			}
			sb.AppendLine("- involved_player: true");
			sb.AppendLine();
			if (result.CapturedHeroes != null && result.CapturedHeroes.Count > 0)
			{
				sb.AppendLine("### Captured Heroes With Player");
				foreach (string heroId in result.CapturedHeroes)
				{
					if (!string.IsNullOrEmpty(heroId))
					{
						Hero val2 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == heroId));
						if (val2 != null)
						{
							sb.AppendLine($"- {val2.Name} (id:{((MBObjectBase)val2).StringId}) was captured together with the player during the failed attack.");
						}
						else
						{
							sb.AppendLine("- Hero with id:" + heroId + " was captured together with the player during the failed attack.");
						}
					}
				}
				sb.AppendLine();
			}
		}
		if (result.Settlement == null)
		{
			return;
		}
		sb.AppendLine("### Settlement Current State");
		CultureObject culture = result.Settlement.Culture;
		string text7 = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown";
		IFaction mapFaction = result.Settlement.MapFaction;
		IFaction obj = ((mapFaction is Kingdom) ? mapFaction : null);
		object obj2 = ((obj == null) ? null : ((object)((Kingdom)obj).Name)?.ToString());
		if (obj2 == null)
		{
			IFaction mapFaction2 = result.Settlement.MapFaction;
			obj2 = ((mapFaction2 == null) ? null : ((object)mapFaction2.Name)?.ToString()) ?? "Unknown";
		}
		string text8 = (string)obj2;
		sb.AppendLine("- Culture: " + text7);
		sb.AppendLine("- Owner Kingdom: " + text8);
		if (result.Settlement.IsVillage && result.Settlement.Village != null)
		{
			sb.AppendLine($"- Village Hearth (population): {result.Settlement.Village.Hearth:F0}");
			int num3 = (int)result.Settlement.Militia;
			sb.AppendLine($"- Militia remaining: {num3}");
			Settlement bound = result.Settlement.Village.Bound;
			sb.AppendLine($"- Bound Town: {((bound != null) ? bound.Name : null)}");
			if (result.Settlement.Village.Bound != null && result.Settlement.Village.Bound.Town != null)
			{
				sb.AppendLine($"- Town Prosperity: {result.Settlement.Village.Bound.Town.Prosperity:F0}");
			}
		}
		else if (result.Settlement.IsTown && result.Settlement.Town != null)
		{
			sb.AppendLine($"- Town Prosperity: {result.Settlement.Town.Prosperity:F0}");
			int num4 = (int)result.Settlement.Militia;
			sb.AppendLine($"- Militia remaining: {num4}");
		}
		else if (result.Settlement.IsCastle && result.Settlement.Town != null)
		{
			sb.AppendLine($"- Castle Prosperity: {result.Settlement.Town.Prosperity:F0}");
			int num5 = (int)result.Settlement.Militia;
			sb.AppendLine($"- Militia remaining: {num5}");
		}
		sb.AppendLine();
	}

	private void AppendEventCreationInstructions(StringBuilder sb, string gameLanguage)
	{
		sb.AppendLine("## Event Creation Instructions");
		sb.AppendLine();
		sb.AppendLine("Create a dynamic event describing the aftermath of this combat.");
		sb.AppendLine();
		sb.AppendLine("IMPORTANT NOTES:");
		sb.AppendLine();
		sb.AppendLine("1. Character Reference Format in Prompt:");
		sb.AppendLine("   - Throughout this prompt, IMPORTANT characters (lords, heroes, notables) are referenced in format: \"Name (string_id:xxx)\"");
		sb.AppendLine("   - This helps AI correctly identify characters and avoid confusion");
		sb.AppendLine("   - Examples: \"Ragnar (string_id:lord_1_27)\", \"Player (string_id:main_hero)\", \"Notable Name (string_id:CharacterObject_2349)\"");
		sb.AppendLine("   - CRITICAL: string_id is shown ONLY for important characters (lords, heroes, notables). Regular soldiers/troops do NOT have string_id shown.");
		sb.AppendLine("   - When describing kills/wounds:");
		sb.AppendLine("     * We ALWAYS know the killer's name - it's provided in the combat statistics");
		sb.AppendLine("     * For important victims: \"Victim Name (string_id:xxx) killed/wounded by Killer Name\"");
		sb.AppendLine("     * If killer is also important: \"Victim Name (string_id:xxx) killed/wounded by Killer Name (string_id:yyy)\"");
		sb.AppendLine("     * If killer is regular soldier: \"Victim Name (string_id:xxx) killed/wounded by Killer Name\" (NO string_id for killer, but name is ALWAYS provided)");
		sb.AppendLine();
		sb.AppendLine("2. Player Involvement Double Check:");
		sb.AppendLine("   - The first analysis determined player_involved based on initial situation");
		sb.AppendLine("   - Now you must CONFIRM based on combat statistics and defender response:");
		sb.AppendLine("   - If player was aggressor AND defenders arrived (militia/guards/lords against them), player was obviously identified");
		sb.AppendLine("   - If player was defender AND lords arrived on their side, player's presence is known");
		sb.AppendLine("   - Use logic to make final determination for player_involved in the event");
		sb.AppendLine();
		sb.AppendLine("   CRITICAL: If player_involved = FALSE:");
		sb.AppendLine("   - DO NOT use player's name in the description");
		sb.AppendLine("   - DO NOT reference player's character (id:main_hero) in characters_involved");
		sb.AppendLine("   - Use only: 'unknown attacker', 'stranger', 'mysterious figure', etc. (for the PLAYER only, not for other killers)");
		sb.AppendLine("   - IMPORTANT: For other killers (non-player), we ALWAYS know their name - use it! Only the player can be 'unknown' if player_involved = false");
		sb.AppendLine("   - The event should describe what happened WITHOUT identifying the player");
		sb.AppendLine();
		sb.AppendLine("3. Kingdoms Involved - IMPORTANT:");
		sb.AppendLine("   - DO NOT determine kingdoms_involved based on troop culture/equipment!");
		sb.AppendLine("   - Troops can be of ANY culture (players recruit from different kingdoms)");
		sb.AppendLine("   - Determine kingdoms_involved ONLY by:");
		sb.AppendLine("     * Settlement's kingdom (where event occurred)");
		sb.AppendLine("     * Player's kingdom (if player_involved = true)");
		sb.AppendLine("     * Kingdoms of lords who participated");
		sb.AppendLine("   - Example: If player has Imperial troops but belongs to Aserai kingdom → kingdoms_involved: [\"aserai\"]");
		sb.AppendLine();
		sb.AppendLine("4. Defender Response Consideration:");
		sb.AppendLine("   - If militia/guards/lords arrived, this SIGNIFICANTLY affects event importance");
		sb.AppendLine("   - If lords arrived and SUFFERED LOSSES, this increases importance and may require diplomatic response");
		sb.AppendLine("   - If a lord arrived on player's side and helped them, this should be reflected in description");
		sb.AppendLine("   - If a lord arrived against player but player killed/wounded them, this is CRITICALLY important");
		sb.AppendLine("   - ALWAYS mention lords who arrived in characters_involved");
		sb.AppendLine();
		sb.AppendLine("## Response Format (JSON)");
		sb.AppendLine();
		sb.AppendLine("CRITICAL REQUIREMENTS:");
		sb.AppendLine("1. Your response MUST be a SINGLE, VALID JSON object - no markdown, no code blocks, no explanations before or after");
		sb.AppendLine("2. Start your response with '{' and end with '}'");
		sb.AppendLine("3. Return a complete DynamicEvent JSON object with ALL fields listed below");
		sb.AppendLine();
		sb.AppendLine("### Field Descriptions:");
		sb.AppendLine();
		sb.AppendLine("- `id`: (string) Unique event ID. Format: \"settlement_combat_[settlement_string_id]_[timestamp]\" or similar unique identifier.");
		sb.AppendLine("- `type`: (string) Event type. Must be one of: \"military\" (major combat, 5+ deaths), \"local\" (local tragedy, civilian casualties), \"news\" (notable incident), \"rumor\" (minor incident), \"political\" (political implications), \"economic\" (economic impact).");
		sb.AppendLine($"- `description`: (string) Detailed narrative of aftermath and consequences. Length: {GlobalSettings<ModSettings>.Instance.DynamicEventsMinLength}-{GlobalSettings<ModSettings>.Instance.DynamicEventsMaxLength} characters. In {gameLanguage}. Reference characters by NAME, NOT string_ids.");
		sb.AppendLine("- `player_involved`: (boolean) TAKE FROM FIRST ANALYSIS ('Player Involved (from first analysis)' field). This was determined from the DIALOGUE between the player and the Trigger NPC. Do NOT re-determine from combat statistics alone. Override to false ONLY if: first analysis said true BUT all witnesses are dead AND no lords arrived. Override to true if lords arrived against the player (they SAW the player).");
		sb.AppendLine("- `kingdoms_involved`: (array of strings, null, or \"all\") Kingdom string_ids based on PARTICIPANTS (settlement kingdom, player kingdom if player_involved=true, lords' kingdoms). NOT based on troop culture!");
		sb.AppendLine("- `characters_involved`: (array of strings) ALL character string_ids mentioned (victims, killers, witnesses, lords who arrived). Use string_ids from information above.");
		sb.AppendLine("- `importance`: (integer) 1-10 scale. 1-3=Minor incident, 4-6=Notable event, 7-8=Major incident, 9-10=Catastrophic event.");
		sb.AppendLine("- `spread_speed`: (string) How fast information spreads. \"fast\" (major events, many witnesses), \"normal\" (standard incidents), \"slow\" (minor, few witnesses).");
		sb.AppendLine("- `allows_diplomatic_response`: (boolean) true if kingdoms might respond diplomatically, false otherwise.");
		sb.AppendLine("- `applicable_npcs`: (array of strings) Who should know about event. Options: [\"all\"], [\"lords\"], [\"faction_leaders\"], [\"companions\"], [\"village_notables\"], [\"merchants\"], or mix like [\"lords\", \"faction_leaders\"], or specific string_ids.");
		sb.AppendLine("- `settlement_penalty`: (object) Economic consequences. Object with three fields:");
		sb.AppendLine("  - `prosperity_penalty_per_day`: (number) 1-20 if villiage, else 10-50 if castle/town Hearth/prosperity decrease per day based on situation severity.");
		sb.AppendLine("  - `penalty_duration_days`: (number) 3-25. Days penalty lasts based on situation.");
		sb.AppendLine("  - `penalty_reason`: (string) Brief reason 1-5 words.");
		sb.AppendLine();
		sb.AppendLine("JSON STRUCTURE (example with proper types and values):");
		sb.AppendLine("{");
		if (GlobalSettings<ModSettings>.Instance.EnableDynamicEventsInternalThoughts)
		{
			sb.AppendLine("  \"internal_thoughts\": \"FACT CHECK: Player attacked village, 500 killed... REASONING: Catastrophic military event...\",");
		}
		sb.AppendLine("  \"id\": \"settlement_combat_town_ES5_1234567890\",");
		sb.AppendLine("  \"type\": \"local\",");
		sb.AppendLine("  \"description\": \"description situation here\",");
		sb.AppendLine("  \"player_involved\": false,");
		sb.AppendLine("  \"kingdoms_involved\": [\"empire_s\"],");
		sb.AppendLine("  \"characters_involved\": [\"lord_1_27\", \"CharacterObject_2349\", \"CharacterObject_1756\"],");
		sb.AppendLine("  \"importance\": 6,");
		sb.AppendLine("  \"spread_speed\": \"normal\",");
		sb.AppendLine("  \"allows_diplomatic_response\": false,");
		sb.AppendLine("  \"applicable_npcs\": [\"lords\", \"faction_leaders\"],");
		sb.AppendLine("  \"settlement_penalty\": {");
		sb.AppendLine("    \"prosperity_penalty_per_day\": 2.5,");
		sb.AppendLine("    \"penalty_duration_days\": 10,");
		sb.AppendLine("    \"penalty_reason\": \"Brief reason 1-5 words.\"");
		sb.AppendLine("  }");
		sb.AppendLine("}");
		sb.AppendLine();
		sb.AppendLine("FINAL CHECKLIST before returning JSON:");
		sb.AppendLine("- All fields present?");
		sb.AppendLine("- All values are proper JSON types (strings, numbers, booleans, arrays, objects)?");
		sb.AppendLine("- player_involved verified based on defenders response?");
		sb.AppendLine("- String_ids match those from information above?");
		sb.AppendLine("- Description length correct?");
		sb.AppendLine("- kingdoms_involved based on PARTICIPANTS, not troop culture?");
		sb.AppendLine();
	}

	private string GetSettlementType(Settlement settlement)
	{
		if (settlement.IsTown)
		{
			return "Town";
		}
		if (settlement.IsCastle)
		{
			return "Castle";
		}
		if (settlement.IsVillage)
		{
			return "Village";
		}
		return "Unknown";
	}

	private string GetTimeOfDay()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			CampaignTime now = CampaignTime.Now;
			float num = (now).GetHourOfDay;
			if (num >= 5f && num < 8f)
			{
				return $"Dawn ({num:F1}h)";
			}
			if (num >= 8f && num < 12f)
			{
				return $"Morning ({num:F1}h)";
			}
			if (num >= 12f && num < 17f)
			{
				return $"Afternoon ({num:F1}h)";
			}
			if (num >= 17f && num < 20f)
			{
				return $"Evening ({num:F1}h)";
			}
			if (num >= 20f && num < 23f)
			{
				return $"Dusk ({num:F1}h)";
			}
			return $"Night ({num:F1}h)";
		}
		catch
		{
			return "Unknown";
		}
	}
}
