using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIInfluence.API;
using AIInfluence.Diplomacy;
using AIInfluence.Diseases;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.DynamicEvents;

public class DynamicEventsAnalyzer
{
	private const int RECENT_CAPTURES_DAYS = 20;

	private const int LARGE_ARMY_THRESHOLD = 850;

	private readonly DiplomacyManager _diplomacyManager;

	private readonly AIInfluenceBehavior _aiBehavior;

	public DynamicEventsAnalyzer(DiplomacyManager diplomacyManager, AIInfluenceBehavior aiBehavior)
	{
		_diplomacyManager = diplomacyManager;
		_aiBehavior = aiBehavior;
	}

	public async Task<DiplomaticAnalysisResult> AnalyzeDiplomaticEvent(DynamicEvent diplomaticEvent, List<KingdomStatement> statements)
	{
		if (diplomaticEvent == null)
		{
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Diplomatic event is null");
			return null;
		}
		if (statements == null || !statements.Any())
		{
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] No statements to analyze");
			return new DiplomaticAnalysisResult
			{
				ShouldEndEvent = true,
				EventUpdate = "No kingdoms responded to this diplomatic situation."
			};
		}
		DynamicEventsLogger.Instance.Log($"[EVENTS_ANALYZER] Analyzing diplomatic event {diplomaticEvent.Id} with {statements.Count} statements");
		try
		{
			string analysisData = GatherAnalysisData(diplomaticEvent, statements);
			DiplomacyLogger.Instance.Log("=== DIPLOMATIC EVENT ANALYSIS START ===");
			DiplomacyLogger.Instance.Log("Event ID: " + diplomaticEvent.Id);
			DiplomacyLogger.Instance.Log("Event Type: " + diplomaticEvent.Type);
			DiplomacyLogger.Instance.Log($"Diplomatic Round: {diplomaticEvent.DiplomaticRounds}");
			DiplomacyLogger.Instance.Log("");
			DiplomacyLogger.Instance.Log("ANALYSIS PROMPT SENT TO AI:");
			DiplomacyLogger.Instance.Log("----------------------------");
			DiplomacyLogger.Instance.Log(analysisData);
			string aiResponse = await SendAnalysisToAI(analysisData);
			if (string.IsNullOrEmpty(aiResponse))
			{
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Empty AI response - scheduling retry in 2 days");
				DiplomacyLogger.Instance.Log("ERROR: Empty AI response received - will retry in 2 game days");
				return new DiplomaticAnalysisResult
				{
					ShouldContinueEvent = true,
					ShouldEndEvent = false,
					EventUpdate = "Waiting for diplomatic analysis... (AI service temporarily unavailable)",
					RetryDelayDays = 2
				};
			}
			DiplomacyLogger.Instance.Log("");
			DiplomacyLogger.Instance.Log("AI ANALYSIS RESPONSE:");
			DiplomacyLogger.Instance.Log("---------------------");
			DiplomacyLogger.Instance.Log(aiResponse);
			DiplomacyLogger.Instance.Log("");
			DiplomaticAnalysisResult result = ProcessAIResponse(aiResponse, diplomaticEvent);
			if (result != null)
			{
				DynamicEventsLogger.Instance.Log($"[EVENTS_ANALYZER] Analysis complete: Continue={result.ShouldContinueEvent}, End={result.ShouldEndEvent}");
				int actionsCount = result.ActionsToExecute?.Count ?? 0;
				int relationChangesCount = result.RelationChanges?.Count ?? 0;
				DiplomacyLogger.Instance.Log($"Actions to Execute: {actionsCount}");
				DiplomacyLogger.Instance.Log($"Relation Changes: {relationChangesCount}");
				DiplomacyLogger.Instance.Log("=== DIPLOMATIC EVENT ANALYSIS END ===");
				DiplomacyLogger.Instance.Log("");
			}
			else
			{
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] ProcessAIResponse returned null");
				DiplomacyLogger.Instance.Log("ERROR: Failed to process AI response");
				DiplomacyLogger.Instance.Log("=== DIPLOMATIC EVENT ANALYSIS FAILED ===");
				DiplomacyLogger.Instance.Log("");
			}
			return result;
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] ERROR analyzing event: " + ex.Message);
			DiplomacyLogger.Instance.LogError("DynamicEventsAnalyzer.AnalyzeDiplomaticEvent", "Failed to analyze event " + diplomaticEvent.Id, ex);
			return null;
		}
	}

	private string GenerateInternalThoughtsSection()
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableDynamicEventsInternalThoughts)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("### CRITICAL: Internal Thought Process (REQUIRED BEFORE ANALYZING) ###");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**PRIVATE reasoning process for logical and realistic diplomatic outcomes.**");
		stringBuilder.AppendLine();
		string value = WorldInfoManager.Instance?.ReadEventsAnalyzerRules();
		bool flag = !string.IsNullOrEmpty(value);
		if (flag)
		{
			stringBuilder.AppendLine("**OVERRIDE RULES (ABSOLUTE PRIORITY - CHECK IN STEP 8)**");
			stringBuilder.AppendLine("The player has set custom analyzer rules that OVERRIDE all other instructions:");
			stringBuilder.AppendLine(value);
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("**STEP 0: VERIFY FACTS (MANDATORY)**");
		stringBuilder.AppendLine("Before reasoning, verify CURRENT DIPLOMATIC STATE (GROUND TRUTH):");
		stringBuilder.AppendLine("- Wars/Alliances/Trade agreements/Tributes/Reparations/Pending proposals");
		stringBuilder.AppendLine("- **CRITICAL:** TECHNICAL DATA = REALITY. HISTORY = WHAT WAS SAID (may have failed).");
		stringBuilder.AppendLine("- If history says \"proposal sent\" but technical data shows no alliance → REJECTED or PENDING.");
		stringBuilder.AppendLine("- If history says \"war declared\" but technical data shows PEACE → PEACE is correct.");
		stringBuilder.AppendLine("- Format: internal_thoughts starts with 'FACT CHECK:' + verified facts from TECHNICAL DATA.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 1: ROUND STATUS**");
		stringBuilder.AppendLine("- Which kingdoms already responded? (Check 'CURRENT ROUND STATUS') **CRITICAL:** Cannot respond again this round.");
		stringBuilder.AppendLine("- Rounds/Days active? (Check 'Diplomatic Rounds'/'Days Since Creation') Too long? (3+ rounds/7+ days = warning)");
		stringBuilder.AppendLine("- Progress level? (Check 'PROGRESS CHECK')");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 2: HISTORY + PENDING PROPOSALS (COMBINED)**");
		stringBuilder.AppendLine("- History: Review statements chronologically. What was ATTEMPTED? (proposals/demands/declarations)");
		stringBuilder.AppendLine("- **CRITICAL:** Distinguish ATTEMPTED vs ACTUAL. Repetitive? (stalemate) Progress or repetition? Tone? (hostile/diplomatic/neutral/desperate) New developments?");
		stringBuilder.AppendLine("- Pending: What proposals PENDING? (awaiting response, NOT rejected) **CRITICAL:** NEVER end if pending exist.");
		stringBuilder.AppendLine("- Which kingdoms waiting? How long pending? Wait or end despite pending?");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 3: CONTINUE VS END**");
		stringBuilder.AppendLine("- Should CONTINUE? (all statements have interest/development)");
		stringBuilder.AppendLine("- Should END? (repetition 2+ rounds/4+ days | logical conclusion | all responded + no pending | stalemate)");
		stringBuilder.AppendLine("- **CRITICAL:** Do NOT end if pending exist (unless explicitly rejected).");
		stringBuilder.AppendLine("- Logical next step: continue, end, or escalate?");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 4: KINGDOMS TO ADD/REMOVE**");
		stringBuilder.AppendLine("- Check 'RELEVANT OUTSIDERS' - kingdoms at war with participants (add to resolve conflict).");
		stringBuilder.AppendLine("- Kingdoms not participating for long time? Relevant but not participating? Should remove any? (only if no longer relevant)");
		stringBuilder.AppendLine("- **CRITICAL:** Max limit (excluding player) - Check 'AVAILABLE KINGDOMS'. Use exact string_id (\"empire\", NOT \"Northern Empire\").");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 5: RELATION CHANGES**");
		stringBuilder.AppendLine("- What statements affect relations? (insults/threats/agreements) Which pairs had significant interactions?");
		stringBuilder.AppendLine("- Appropriate change? (Check allowed range) Reason? (specific/logical) Consistent with statements/actions?");
		stringBuilder.AppendLine("- **CRITICAL:** Use exact string_id for both kingdoms in relation_changes.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 6: EVENT UPDATE NARRATIVE**");
		stringBuilder.AppendLine("- REACTION? (shock/relief/anger/frustration/hope) OUTCOME? (based on TECHNICAL DATA, not attempts)");
		stringBuilder.AppendLine("- ATMOSPHERE? (tension/change/stalemate/escalation/compromise)");
		stringBuilder.AppendLine("- **CRITICAL:** Base on DIPLOMATIC STATUS (ground truth), not ATTEMPTED. If repeating → stalemate/frustration. If pending → world waits.");
		stringBuilder.AppendLine("- Specific/detailed? (avoid clichés/repetition) Length? (check limits)");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 7: ECONOMIC EFFECTS (if applicable)**");
		stringBuilder.AppendLine("- Warrant economic effects? (embargo/sanctions/trade disruption) Review 'ACTIVE ECONOMIC EFFECTS' - avoid conflicts/stacking.");
		stringBuilder.AppendLine("- **CRITICAL:** For target_type=\"kingdom\" or \"clan\", target_id REQUIRED (exact string_id). Multiple kingdoms → MULTIPLE objects.");
		stringBuilder.AppendLine("- Values within range? (Check OUTPUT FORMAT) Reason logical/specific? **IMPORTANT:** prosperity_delta_per_day MORE VISIBLE.");
		stringBuilder.AppendLine();
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && instance.EnableDiseaseSystem)
		{
			ModSettings instance2 = GlobalSettings<ModSettings>.Instance;
			stringBuilder.AppendLine("**STEP 7b: DISEASE_DATA (if applicable)**");
			stringBuilder.AppendLine("- Review 'ACTIVE DISEASES'. Spread logical? (event narrative, proximity, trade) settlement_id exists in world?");
			stringBuilder.AppendLine($"- disease_data works for ANY event type (like economic_effects). severity 1-{instance2.DiseaseMaxSeverity}, spread_rate 0.1-{instance2.DiseaseMaxSpreadRate:F1}, disease_effects modifiers {instance2.DiseaseMinCombatModifier:F1}-1.0.");
			stringBuilder.AppendLine("- Only include disease_data if creating NEW disease (e.g. spread to another settlement).");
			stringBuilder.AppendLine($"- **LIMIT:** Max {instance2.DiseaseMaxSimultaneous} simultaneous diseases. Check ACTIVE DISEASES count before creating new ones.");
			stringBuilder.AppendLine();
		}
		if (flag)
		{
			stringBuilder.AppendLine("**STEP 8: VERIFY OVERRIDE RULES COMPLIANCE (MANDATORY)**");
			stringBuilder.AppendLine("- Does analysis violate ANY rule? Do should_continue_event/should_end_event comply? Do relation_changes comply?");
			stringBuilder.AppendLine("- If violated → MUST change analysis. ABSOLUTE PRIORITY over logic/diplomacy.");
			stringBuilder.AppendLine("- In internal_thoughts: acknowledge violation → explain adjustment → modify analysis.");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("**STEP 9: OUTPUT STRUCTURE**");
		stringBuilder.AppendLine("JSON MUST include:");
		stringBuilder.AppendLine("- `internal_thoughts` (500-2000 characters): PRIVATE reasoning from all steps above" + (flag ? " + rule compliance check" : "") + ".");
		if (flag)
		{
			stringBuilder.AppendLine("  - Example: \"FACT CHECK: Empire vs Vlandia at war, peace proposal pending. REASONING: Want to end, but Override Rules forbid ending with pending. Will continue and wait.\"");
		}
		stringBuilder.AppendLine("- Other fields: should_continue_event, should_end_event, kingdoms_to_add/remove, event_update, relation_changes, etc.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**CRITICAL RULES:**");
		stringBuilder.AppendLine("- **MANDATORY:** internal_thoughts starts with 'FACT CHECK:' + facts from TECHNICAL DATA");
		stringBuilder.AppendLine("- **FORBIDDEN:** Do NOT confuse ATTEMPTED with ACTUAL. TECHNICAL DATA = truth");
		stringBuilder.AppendLine("- **FORBIDDEN:** Do NOT write pending proposals failed/rejected (awaiting response)");
		stringBuilder.AppendLine("- **FORBIDDEN:** Do NOT end if pending exist (unless explicitly rejected)");
		stringBuilder.AppendLine("- internal_thoughts = PRIVATE (helps reasoning, players don't see)");
		stringBuilder.AppendLine("- Analysis = internal thoughts + verified facts from TECHNICAL DATA");
		stringBuilder.AppendLine("- Use exact string_id in JSON (\"empire\", NOT \"Northern Empire\", NOT \"string_id:empire\")");
		if (flag)
		{
			stringBuilder.AppendLine("- **MANDATORY:** Analysis MUST comply with Override Rules. If conflict → Rules WIN. Include compliance check in internal_thoughts");
		}
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}

	private string GatherAnalysisData(DynamicEvent diplomaticEvent, List<KingdomStatement> statements)
	{
		//IL_14dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_162a: Unknown result type (might be due to invalid IL or missing references)
		//IL_162f: Unknown result type (might be due to invalid IL or missing references)
		//IL_170f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1714: Unknown result type (might be due to invalid IL or missing references)
		//IL_1886: Unknown result type (might be due to invalid IL or missing references)
		//IL_188b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1982: Unknown result type (might be due to invalid IL or missing references)
		//IL_1987: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c41: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d42: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(GenerateInternalThoughtsSection());
		AllianceSystem allianceSystem = AllianceSystem.Instance;
		WarStatisticsTracker warTracker = _diplomacyManager.GetWarTracker();
		Hero mainHero = Hero.MainHero;
		object obj;
		if (mainHero == null)
		{
			obj = null;
		}
		else
		{
			Clan clan = mainHero.Clan;
			obj = ((clan != null) ? clan.Kingdom : null);
		}
		Kingdom val = (Kingdom)obj;
		string playerKingdomId = null;
		if (val != null && val.Leader == Hero.MainHero)
		{
			playerKingdomId = ((MBObjectBase)val).StringId;
		}
		string text = MBTextManager.ActiveTextLanguage ?? "English";
		stringBuilder.AppendLine("# MISSION: Analyze Diplomatic Situation");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("You are an intelligent diplomatic analyzer for Mount & Blade II: Bannerlord.");
		stringBuilder.AppendLine("Your task is to process the round of diplomatic statements and update the global event narrative.");
		stringBuilder.AppendLine("Language: " + text);
		stringBuilder.AppendLine();
		try
		{
			string value = WorldInfoManager.Instance.ReadWorldInfo();
			if (!string.IsNullOrEmpty(value))
			{
				stringBuilder.AppendLine("### WORLD CONTEXT ###");
				stringBuilder.AppendLine(value);
				stringBuilder.AppendLine();
			}
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Error reading world info: " + ex.Message);
		}
		stringBuilder.AppendLine("### DATA INTERPRETATION PRIORITY ###");
		stringBuilder.AppendLine("**CRITICAL UNDERSTANDING:**");
		stringBuilder.AppendLine("1. TECHNICAL DATA sections (wars, alliances, statistics, proposals) = CURRENT REALITY = GROUND TRUTH");
		stringBuilder.AppendLine("2. NEGOTIATION HISTORY section = WHAT WAS SAID (attempts, proposals, statements)");
		stringBuilder.AppendLine("3. ALWAYS prioritize technical data over narrative when they conflict");
		stringBuilder.AppendLine("4. Example: If history says \"kingdom declared war\" but technical data shows PEACE, then PEACE is correct");
		stringBuilder.AppendLine("5. Example: If history says \"proposal sent\" but technical data shows no alliance, the proposal was REJECTED or is PENDING");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**YOUR JOB:** Aggregate technical data into coherent narrative. Don't copy raw lists.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## CORE RULES:");
		stringBuilder.AppendLine($"- event_update length: {GlobalSettings<ModSettings>.Instance.DynamicEventsMinLength}-{GlobalSettings<ModSettings>.Instance.DynamicEventsMaxLength} chars");
		stringBuilder.AppendLine("- Be specific, detailed, avoid clichés and repetition");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## EVENT UPDATE STRUCTURE:");
		stringBuilder.AppendLine("event_update MUST include: 1) REACTION (shock/relief/anger) 2) OUTCOME (what happened) 3) ATMOSPHERE (tension/change)");
		stringBuilder.AppendLine("If repeating: show stalemate/frustration. If pending: world waits.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## LOGIC GUIDELINES:");
		stringBuilder.AppendLine("- PENDING = awaiting response, NOT rejected (don't write \"failed\")");
		stringBuilder.AppendLine("- ADD KINGDOMS: Check 'RELEVANT OUTSIDERS' - add enemies/allies if at war. Also, add other kingdoms that have not participated in events for a long time (can be checked by event history).");
		stringBuilder.AppendLine("- END EVENT: Repetition of ruler statements without progress (monotonous, constantly repeating the same thing) for 2+ rounds/4+ days. OR, the event has reached a logical conclusion, CONSIDERING ALL EVENT PARTICIPANTS. NEVER end if pending proposals exist (peace, reparations, tribute and everything that requires logical confirmation).");
		stringBuilder.AppendLine("- CONTINUE: Continue the event if all statements in the current event contain interest and development, OTHERWISE end the event.");
		stringBuilder.AppendLine("- ECONOMIC EFFECTS: Only for concrete consequences (embargo, sanctions). Check 'ACTIVE ECONOMIC EFFECTS' to avoid conflicts");
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && instance.EnableDiseaseSystem)
		{
			stringBuilder.AppendLine("- QUARANTINE WORD: Do NOT use 'quarantine' in event_update or economic_effects reason for settlements NOT marked [QUARANTINED] in ACTIVE DISEASES. Only kingdom rulers impose quarantine.");
		}
		stringBuilder.AppendLine("  **CRITICAL: For target_type=\"kingdom\" or \"clan\", target_id is REQUIRED (use kingdom/clan string_id). To affect multiple kingdoms, create MULTIPLE objects.**");
		stringBuilder.AppendLine("  **target_scope values: \"all_settlements\", \"towns\", \"castles\", \"villages\" (NOT \"all\"). target_scope only works when target_id is provided.**");
		stringBuilder.AppendLine();
		if (diplomaticEvent.IsDiseaseEvent)
		{
			stringBuilder.AppendLine("## DISEASE EVENT LOGIC:");
			stringBuilder.AppendLine("- ADD KINGDOMS: If disease is spreading to other kingdoms' settlements, ADD those kingdoms to the event");
			stringBuilder.AppendLine("- QUARANTINE: Kingdoms can quarantine their OWN diseased settlements (quarantine_settlement action from kingdom statements)");
			stringBuilder.AppendLine("- BLAME & COOPERATION: Kingdoms may blame each other for disease origin/spread, or cooperate to fight it");
			stringBuilder.AppendLine("- ECONOMIC EFFECTS: Disease impacts prosperity (negative), food supply, security, and income of affected settlements");
			stringBuilder.AppendLine("- END EVENT: When disease expires/is cured AND all diplomatic tensions are resolved. Also end if disease is no longer relevant");
			stringBuilder.AppendLine("- NARRATIVE: Focus on disease progression, public health measures, humanitarian aspects, and political consequences");
			stringBuilder.AppendLine("- RELATION CHANGES: Disease cooperation improves relations; blame, closed borders, or refusal to help worsens them");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("## string_id USAGE (MANDATORY FOR ACTIONS):");
		stringBuilder.AppendLine("**CRITICAL: You MUST use exact string_id values for all kingdom references in JSON.**");
		stringBuilder.AppendLine("Throughout this prompt, data is formatted as: \"Kingdom Name (string_id:value)\"");
		stringBuilder.AppendLine("- You see: \"Northern Empire (string_id:empire)\"");
		stringBuilder.AppendLine("- You use in JSON: \"empire\" (NOT \"string_id:empire\", NOT \"Northern Empire\")");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**EXAMPLES:** \"Vlandia (string_id:vlandia)\" → use \"vlandia\" | \"Qalit (string_id:town_S1)\" → use \"town_S1\"");
		stringBuilder.AppendLine("**SPLIT USAGE:** Names in event_update = readable | IDs in JSON = string_id only");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## OUTPUT FIELDS:");
		stringBuilder.AppendLine($"1. kingdoms_to_add/remove: string_id only. Max {GlobalSettings<ModSettings>.Instance?.MaxParticipatingKingdoms ?? 4} non-player kingdoms");
		stringBuilder.AppendLine($"2. relation_changes: string_id for both. Range: {GlobalSettings<ModSettings>.Instance.MinKingdomRelationChange} to {GlobalSettings<ModSettings>.Instance.MaxKingdomRelationChange}");
		stringBuilder.AppendLine("3. applicable_npcs: all, lords, faction_leaders, companions, village_notables, merchants");
		stringBuilder.AppendLine("4. economic_effects: Optional, for economic consequences");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## OUTPUT FORMAT (STRICT JSON):");
		stringBuilder.AppendLine("```json");
		stringBuilder.AppendLine("{");
		if (GlobalSettings<ModSettings>.Instance.EnableDynamicEventsInternalThoughts)
		{
			stringBuilder.AppendLine("  \"internal_thoughts\": \"Analyze diplomatic situation, check statements, determine outcome...\",");
		}
		stringBuilder.AppendLine("  \"should_continue_event\": true,");
		stringBuilder.AppendLine("  \"should_end_event\": false,");
		stringBuilder.AppendLine("  \"kingdoms_to_add\": [\"empire\", \"vlandia\"],");
		stringBuilder.AppendLine("  \"kingdoms_to_remove\": [],");
		stringBuilder.AppendLine("  \"event_update\": \"Detailed narrative update...\",");
		stringBuilder.AppendLine("  \"relation_changes\": [{");
		stringBuilder.AppendLine("    \"kingdom1_id\": \"empire\",");
		stringBuilder.AppendLine("    \"kingdom2_id\": \"vlandia\",");
		stringBuilder.AppendLine("    \"change\": -10,");
		stringBuilder.AppendLine("    \"reason\": \"Insulting statement\"");
		stringBuilder.AppendLine("  }],");
		ModSettings instance2 = GlobalSettings<ModSettings>.Instance;
		stringBuilder.AppendLine("  \"applicable_npcs\": [\"all\", \"lords\", \"faction_leaders\", \"companions\", \"village_notables\", \"merchants\"],");
		stringBuilder.AppendLine("  \"economic_effects\": [{ // OPTIONAL");
		stringBuilder.AppendLine("    \"target_type\": \"settlement\",  // or \"kingdom\" or \"clan\"");
		stringBuilder.AppendLine("    \"target_id\": \"town_B1\",  // REQUIRED: settlement/kingdom/clan string_id");
		stringBuilder.AppendLine("    \"target_scope\": \"all_settlements\",  // For kingdom/clan: \"all_settlements\", \"towns\", \"castles\", \"villages\"");
		stringBuilder.AppendLine($"    \"prosperity_delta\": {instance2.ProsperityDeltaMin},  // IMMEDIATE one-time change (applied once). Range: {instance2.ProsperityDeltaMin} to {instance2.ProsperityDeltaMax}");
		stringBuilder.AppendLine($"    \"prosperity_delta_per_day\": {instance2.ProsperityDeltaPerDayMin},  // DAILY change (applied every day for duration_days, MORE VISIBLE). Range: {instance2.ProsperityDeltaPerDayMin} to {instance2.ProsperityDeltaPerDayMax}");
		stringBuilder.AppendLine($"    \"food_delta\": {instance2.FoodDeltaMin},  // IMMEDIATE one-time change. Range: {instance2.FoodDeltaMin} to {instance2.FoodDeltaMax}");
		stringBuilder.AppendLine($"    \"food_delta_per_day\": {instance2.FoodDeltaPerDayMin},  // DAILY change. Range: {instance2.FoodDeltaPerDayMin} to {instance2.FoodDeltaPerDayMax}");
		stringBuilder.AppendLine($"    \"security_delta\": {instance2.SecurityDeltaMin},  // IMMEDIATE one-time change. Range: {instance2.SecurityDeltaMin} to {instance2.SecurityDeltaMax}");
		stringBuilder.AppendLine($"    \"security_delta_per_day\": {instance2.SecurityDeltaPerDayMin},  // DAILY change (applied every day for duration_days). Range: {instance2.SecurityDeltaPerDayMin} to {instance2.SecurityDeltaPerDayMax}. IMPORTANT: Security is 0-100, use small values like 0.2 or 0.5");
		stringBuilder.AppendLine($"    \"loyalty_delta\": {instance2.LoyaltyDeltaMin},  // IMMEDIATE one-time change. Range: {instance2.LoyaltyDeltaMin} to {instance2.LoyaltyDeltaMax}");
		stringBuilder.AppendLine($"    \"loyalty_delta_per_day\": {instance2.LoyaltyDeltaPerDayMin},  // DAILY change (applied every day for duration_days). Range: {instance2.LoyaltyDeltaPerDayMin} to {instance2.LoyaltyDeltaPerDayMax}. IMPORTANT: Loyalty is 0-100, use small values like 0.2 or 0.5");
		stringBuilder.AppendLine($"    \"income_multiplier\": {instance2.IncomeMultiplierMin:F2},  // 1.0 = no change, 0.8 = -20%, 1.2 = +20%. Range: {instance2.IncomeMultiplierMin:F2} to {instance2.IncomeMultiplierMax:F2}");
		stringBuilder.AppendLine($"    \"duration_days\": {instance2.DurationDaysMin},  // How long the effect lasts (for _per_day effects). Range: {instance2.DurationDaysMin} to {instance2.DurationDaysMax} days");
		stringBuilder.AppendLine("    \"reason\": \"Example: Trade embargo after failed negotiations\"");
		ModSettings instance3 = GlobalSettings<ModSettings>.Instance;
		stringBuilder.AppendLine((instance3 != null && instance3.EnableDiseaseSystem) ? "  }]," : "  }]");
		stringBuilder.AppendLine("  // CRITICAL RULES FOR economic_effects:");
		stringBuilder.AppendLine("  // - For target_type=\"kingdom\" or \"clan\": target_id is REQUIRED (use kingdom/clan string_id)");
		stringBuilder.AppendLine("  // - target_scope only works when target_id is provided");
		stringBuilder.AppendLine("  // - To affect multiple kingdoms: create MULTIPLE objects in economic_effects array");
		stringBuilder.AppendLine("  // - target_scope values: \"all_settlements\", \"towns\", \"castles\", \"villages\" (NOT \"all\")");
		stringBuilder.AppendLine("  // - IMPORTANT: prosperity_delta_per_day is MORE VISIBLE than prosperity_delta");
		stringBuilder.AppendLine("  //   Use prosperity_delta_per_day for noticeable lasting effects (e.g., -1 per day for 21 days = -21 total)");
		stringBuilder.AppendLine("  // - FOR VILLAGES: Only prosperity_delta and prosperity_delta_per_day are available (applied to Hearth).");
		stringBuilder.AppendLine("  //   Food/Security/Loyalty effects DO NOT EXIST for villages - do NOT use them for village target_id!");
		ModSettings instance4 = GlobalSettings<ModSettings>.Instance;
		if (instance4 != null && instance4.EnableDiseaseSystem)
		{
			ModSettings instance5 = GlobalSettings<ModSettings>.Instance;
			stringBuilder.AppendLine("  // disease_data: YOU (AI) MUST SET these — generate from context, do NOT copy placeholders");
			stringBuilder.AppendLine("  \"disease_data\": {");
			stringBuilder.AppendLine($"    \"disease_name\": \"<your generated name>\", \"disease_description\": \"<your description>\", \"severity\": <1-{instance5.DiseaseMaxSeverity}>, \"settlement_id\": \"<valid settlement string_id from world>\", \"spread_rate\": <0.1-{instance5.DiseaseMaxSpreadRate:F1}>,");
			stringBuilder.AppendLine("    \"duration_days\": <7-120>,  // OPTIONAL: how many days the disease stays active. If omitted, auto-calculated from severity (sev1=30d, sev2=45d, sev3=60d, sev4=75d, sev5=90d)");
			stringBuilder.AppendLine($"    \"disease_effects\": {{ \"physical_skill_penalty\": <{instance5.DiseaseMaxPhysicalSkillPenalty:F0} to 0>, \"combat_damage_modifier\": <{instance5.DiseaseMinCombatModifier:F1}-1.0>, \"combat_defense_modifier\": <{instance5.DiseaseMinCombatModifier:F1}-1.0>, \"combat_speed_modifier\": <{instance5.DiseaseMinCombatModifier:F1}-1.0>, \"map_speed_modifier\": <{instance5.DiseaseMinMapSpeedModifier:F1}-1.0>, \"morale_modifier\": <{instance5.DiseaseMaxMoralePenalty:F0} to 0>, \"death_chance\": <0-{instance5.DiseaseMaxDeathChance:F1}> }}");
			stringBuilder.AppendLine("  }");
		}
		stringBuilder.AppendLine("}");
		stringBuilder.AppendLine("```");
		stringBuilder.AppendLine();
		string value2 = WorldInfoManager.Instance.ReadEventsAnalyzerRules();
		if (!string.IsNullOrEmpty(value2))
		{
			stringBuilder.AppendLine("### OVERRIDE RULES ###");
			stringBuilder.AppendLine("**IMPORTANT: The information below overrides any rules stated above. These rules take priority.**");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(value2);
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("## === CURRENT DIPLOMATIC STATE (GROUND TRUTH) ===");
		stringBuilder.AppendLine("The following sections show the ACTUAL, CURRENT state of the world RIGHT NOW.");
		stringBuilder.AppendLine("This is what HAS HAPPENED (not what was attempted or proposed).");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## CURRENT DIPLOMATIC SITUATION:");
		stringBuilder.AppendLine("### CURRENT DIPLOMATIC EVENT ###");
		stringBuilder.AppendLine("Event ID: " + diplomaticEvent.Id);
		if (diplomaticEvent.EventHistory != null && diplomaticEvent.EventHistory.Count > 1)
		{
			stringBuilder.AppendLine(diplomaticEvent.GetEventHistoryForPrompt());
		}
		else
		{
			stringBuilder.AppendLine("Description: " + diplomaticEvent.Description);
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Type: " + diplomaticEvent.Type);
		stringBuilder.AppendLine($"Importance: {diplomaticEvent.Importance}/10");
		stringBuilder.AppendLine($"Days Since Creation: {diplomaticEvent.DaysSinceCreation}");
		stringBuilder.AppendLine($"Diplomatic Rounds: {diplomaticEvent.DiplomaticRounds}");
		stringBuilder.AppendLine();
		if (diplomaticEvent.DiplomaticRounds >= 3 || diplomaticEvent.DaysSinceCreation >= 7)
		{
			stringBuilder.AppendLine($"**WARNING: Event duration - {diplomaticEvent.DiplomaticRounds} rounds, {diplomaticEvent.DaysSinceCreation} days**");
			stringBuilder.AppendLine("- Long events need clear progress or should END");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("### PARTICIPATING KINGDOMS ###");
		stringBuilder.AppendLine("Kingdoms currently participating in this event (CANNOT be added, can only be removed):");
		List<string> list = new List<string>();
		foreach (string kingdomId in diplomaticEvent.ParticipatingKingdoms)
		{
			if (!(kingdomId == playerKingdomId))
			{
				Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == kingdomId && !val21.IsEliminated));
				if (val2 != null)
				{
					list.Add($"{val2.Name} (string_id:{kingdomId})");
				}
			}
		}
		if (list.Any())
		{
			stringBuilder.AppendLine(string.Join(", ", list));
		}
		else
		{
			stringBuilder.AppendLine("None");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Details:");
		foreach (string kingdomId2 in diplomaticEvent.ParticipatingKingdoms)
		{
			if (!(kingdomId2 == playerKingdomId))
			{
				Kingdom val3 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == kingdomId2 && !val21.IsEliminated));
				if (val3 != null)
				{
					stringBuilder.AppendLine($"- {val3.Name} (string_id:{kingdomId2})");
					AppendKingdomDetails(stringBuilder, val3);
					AppendKingdomDynamicData(stringBuilder, val3, diplomaticEvent);
				}
			}
		}
		stringBuilder.AppendLine();
		List<KingdomStatement> list2 = diplomaticEvent.KingdomStatements.OrderBy((KingdomStatement s) => s.CampaignDays).ToList();
		List<Kingdom> list3 = (from val21 in diplomaticEvent.ParticipatingKingdoms?.Select((string id) => ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == id && !val21.IsEliminated)))
			where val21 != null
			select val21).ToList() ?? new List<Kingdom>();
		stringBuilder.AppendLine("### DIPLOMATIC STATUS & ALLIANCES ###");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Relations between participating kingdom leaders:");
		for (int num = 0; num < list3.Count; num++)
		{
			for (int num2 = num + 1; num2 < list3.Count; num2++)
			{
				Kingdom val4 = list3[num];
				Kingdom val5 = list3[num2];
				if (val4.Leader != null && val5.Leader != null)
				{
					int relation = val4.Leader.GetRelation(val5.Leader);
					string relationDescription = GetRelationDescription(relation);
					string text2 = "Peace/Neutral";
					if (FactionManager.IsAtWarAgainstFaction((IFaction)(object)val4, (IFaction)(object)val5))
					{
						text2 = "AT WAR";
					}
					else if (allianceSystem.AreAllied(val4, val5))
					{
						text2 = "ALLIED";
					}
					stringBuilder.AppendLine($"  {val4.Leader.Name} (string_id:{((MBObjectBase)val4).StringId}) ↔ {val5.Leader.Name} (string_id:{((MBObjectBase)val5).StringId}): {relation} ({relationDescription}) [{text2}]");
				}
			}
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Current wars (with alliance obligations):");
		HashSet<string> hashSet = new HashSet<string>();
		bool flag = false;
		foreach (Kingdom k1 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom val21) => !val21.IsEliminated))
		{
			foreach (Kingdom item2 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom val21) => !val21.IsEliminated && val21 != k1))
			{
				if (!FactionManager.IsAtWarAgainstFaction((IFaction)(object)k1, (IFaction)(object)item2))
				{
					continue;
				}
				string item = string.Join("-", new string[2]
				{
					((MBObjectBase)k1).StringId,
					((MBObjectBase)item2).StringId
				}.OrderBy((string s) => s));
				if (hashSet.Contains(item))
				{
					continue;
				}
				hashSet.Add(item);
				flag = true;
				KingdomWarStats kingdomStats = warTracker.GetKingdomStats(k1);
				KingdomWarStats kingdomStats2 = warTracker.GetKingdomStats(item2);
				string text3 = "";
				DiplomaticReason diplomaticReason = warTracker.GetDiplomaticReason(k1, item2, "war");
				if (diplomaticReason != null && !string.IsNullOrEmpty(diplomaticReason.Reason))
				{
					text3 = " (Reason: " + diplomaticReason.Reason + ")";
				}
				stringBuilder.AppendLine($"  {k1.Name} (string_id:{((MBObjectBase)k1).StringId}) vs {item2.Name} (string_id:{((MBObjectBase)item2).StringId}){text3}");
				if (kingdomStats != null)
				{
					stringBuilder.AppendLine($"    {k1.Name}: {kingdomStats.TotalCasualties} casualties, {kingdomStats.WarFatigue:F1}% fatigue");
				}
				if (kingdomStats2 != null)
				{
					stringBuilder.AppendLine($"    {item2.Name}: {kingdomStats2.TotalCasualties} casualties, {kingdomStats2.WarFatigue:F1}% fatigue");
				}
				foreach (Kingdom item3 in list3)
				{
					if (allianceSystem.AreAllied(item3, k1))
					{
						bool flag2 = FactionManager.IsAtWarAgainstFaction((IFaction)(object)item3, (IFaction)(object)item2);
						stringBuilder.AppendLine(string.Format("    → {0} (string_id:{1}) allied with {2} (string_id:{3}) {4}", item3.Name, ((MBObjectBase)item3).StringId, k1.Name, ((MBObjectBase)k1).StringId, flag2 ? "(helping)" : "(NOT helping - issue!)"));
					}
					else if (allianceSystem.AreAllied(item3, item2))
					{
						bool flag3 = FactionManager.IsAtWarAgainstFaction((IFaction)(object)item3, (IFaction)(object)k1);
						stringBuilder.AppendLine(string.Format("    → {0} (string_id:{1}) allied with {2} (string_id:{3}) {4}", item3.Name, ((MBObjectBase)item3).StringId, item2.Name, ((MBObjectBase)item2).StringId, flag3 ? "(helping)" : "(NOT helping - issue!)"));
					}
				}
			}
		}
		if (!flag)
		{
			stringBuilder.AppendLine("  - No active wars");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Alliances of participating kingdoms:");
		bool flag4 = false;
		foreach (Kingdom kingdom in list3)
		{
			List<Kingdom> list4 = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom val21) => !val21.IsEliminated && val21 != kingdom && allianceSystem.AreAllied(kingdom, val21)).ToList();
			if (list4.Any())
			{
				stringBuilder.AppendLine($"  {kingdom.Name} (string_id:{((MBObjectBase)kingdom).StringId}):");
				foreach (Kingdom item4 in list4)
				{
					string arg = "";
					DiplomaticReason diplomaticReason2 = warTracker.GetDiplomaticReason(kingdom, item4, "alliance");
					if (diplomaticReason2 != null && !string.IsNullOrEmpty(diplomaticReason2.Reason))
					{
						arg = " (Reason: " + diplomaticReason2.Reason + ")";
					}
					stringBuilder.AppendLine($"    - {item4.Name} (string_id:{((MBObjectBase)item4).StringId}){arg}");
				}
				flag4 = true;
			}
			else
			{
				stringBuilder.AppendLine($"  {kingdom.Name} (string_id:{((MBObjectBase)kingdom).StringId}): None");
			}
		}
		stringBuilder.AppendLine();
		TradeAgreementSystem tradeAgreementSystem = _diplomacyManager.GetTradeAgreementSystem();
		TributeSystem tributeSystem = _diplomacyManager.GetTributeSystem();
		ReparationsSystem reparationsSystem = _diplomacyManager.GetReparationsSystem();
		TerritoryTransferSystem territoryTransferSystem = _diplomacyManager.GetTerritoryTransferSystem();
		stringBuilder.AppendLine("Trade Agreements:");
		CampaignTime val7;
		foreach (Kingdom item5 in list3)
		{
			List<TradeAgreementInfo> tradeAgreementsForKingdom = tradeAgreementSystem.GetTradeAgreementsForKingdom(item5);
			if (tradeAgreementsForKingdom.Any())
			{
				foreach (TradeAgreementInfo item6 in tradeAgreementsForKingdom)
				{
					string partnerId = ((item6.Kingdom1Id == ((MBObjectBase)item5).StringId) ? item6.Kingdom2Id : item6.Kingdom1Id);
					Kingdom val6 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == partnerId && !val21.IsEliminated));
					if (val6 != null)
					{
						val7 = item6.EndTime;
						float num3 = (val7).RemainingDaysFromNow / (float)CampaignTime.DaysInYear;
						stringBuilder.AppendLine($"  - {item5.Name} ↔ {val6.Name} (string_id:{partnerId}): expires in {num3:F1} years");
					}
				}
			}
			else
			{
				stringBuilder.AppendLine($"  - {item5.Name} (string_id:{((MBObjectBase)item5).StringId}): No active trade agreements");
			}
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Active Tributes:");
		foreach (Kingdom item7 in list3)
		{
			List<TributeAgreement> tributesPaidBy = tributeSystem.GetTributesPaidBy(item7);
			List<TributeAgreement> tributesReceivedBy = tributeSystem.GetTributesReceivedBy(item7);
			bool flag5 = false;
			foreach (TributeAgreement tribute in tributesPaidBy)
			{
				Kingdom val8 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == tribute.ReceiverKingdomId && !val21.IsEliminated));
				if (val8 != null)
				{
					val7 = tribute.EndTime;
					float remainingDaysFromNow = (val7).RemainingDaysFromNow;
					stringBuilder.AppendLine($"  - {item7.Name} → {val8.Name} (string_id:{((MBObjectBase)val8).StringId}): {tribute.DailyAmount} gold/day for {remainingDaysFromNow:F0} more days (reason: {tribute.Reason})");
					flag5 = true;
				}
			}
			foreach (TributeAgreement tribute2 in tributesReceivedBy)
			{
				Kingdom val9 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == tribute2.PayerKingdomId && !val21.IsEliminated));
				if (val9 != null)
				{
					val7 = tribute2.EndTime;
					float remainingDaysFromNow2 = (val7).RemainingDaysFromNow;
					stringBuilder.AppendLine($"  - {val9.Name} (string_id:{((MBObjectBase)val9).StringId}) → {item7.Name}: {tribute2.DailyAmount} gold/day for {remainingDaysFromNow2:F0} more days (reason: {tribute2.Reason})");
					flag5 = true;
				}
			}
			if (!flag5)
			{
				stringBuilder.AppendLine($"  - {item7.Name} (string_id:{((MBObjectBase)item7).StringId}): No active tributes");
			}
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Reparations & Demands:");
		foreach (Kingdom item8 in list3)
		{
			List<ReparationDemand> demandsMadeBy = reparationsSystem.GetDemandsMadeBy(item8);
			List<ReparationDemand> pendingDemandsForPayer = reparationsSystem.GetPendingDemandsForPayer(item8);
			bool flag6 = false;
			foreach (ReparationDemand demand in demandsMadeBy)
			{
				Kingdom val10 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == demand.PayingKingdomId && !val21.IsEliminated));
				if (val10 != null)
				{
					val7 = demand.ExpirationTime;
					float remainingDaysFromNow3 = (val7).RemainingDaysFromNow;
					stringBuilder.AppendLine($"  - {item8.Name} demands {demand.Amount} gold from {val10.Name} (string_id:{((MBObjectBase)val10).StringId}) (expires in {remainingDaysFromNow3:F0} days, status: {demand.Status}, reason: {demand.Reason})");
					flag6 = true;
				}
			}
			foreach (ReparationDemand demand2 in pendingDemandsForPayer)
			{
				Kingdom val11 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == demand2.DemandingKingdomId && !val21.IsEliminated));
				if (val11 != null)
				{
					val7 = demand2.ExpirationTime;
					float remainingDaysFromNow4 = (val7).RemainingDaysFromNow;
					stringBuilder.AppendLine($"  - {val11.Name} (string_id:{((MBObjectBase)val11).StringId}) demands {demand2.Amount} gold from {item8.Name} (expires in {remainingDaysFromNow4:F0} days, status: {demand2.Status}, reason: {demand2.Reason})");
					flag6 = true;
				}
			}
			if (!flag6)
			{
				stringBuilder.AppendLine($"  - {item8.Name} (string_id:{((MBObjectBase)item8).StringId}): No reparations or demands");
			}
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### RECENT DEATHS OF IMPORTANT FIGURES (CRITICAL INFORMATION) ###");
		stringBuilder.AppendLine("**IMPORTANT: Kingdom leader deaths cause succession crises and major political shifts. These events significantly impact diplomatic relations and should be considered when analyzing the situation.**");
		List<DeathInfo> recentImportantDeaths = GetRecentImportantDeaths(20);
		if (recentImportantDeaths.Any())
		{
			foreach (DeathInfo item9 in recentImportantDeaths)
			{
				string text4 = ((item9.Title == "Kingdom Ruler") ? " [CRITICAL - SUCCESSION CRISIS]" : "");
				stringBuilder.AppendLine("- " + item9.HeroName + " (string_id: \"" + item9.HeroStringId + "\") - " + item9.Title + text4);
				stringBuilder.AppendLine("  Death cause: " + item9.DeathCause);
				stringBuilder.AppendLine("  Killer: " + item9.KillerName + " (string_id: \"" + item9.KillerStringId + "\")");
				stringBuilder.AppendLine("  Kingdom: " + item9.KingdomName + " (string_id: \"" + item9.KingdomStringId + "\")");
				stringBuilder.AppendLine($"  Days ago: {item9.DaysAgo}");
			}
		}
		else
		{
			stringBuilder.AppendLine("- No recent deaths of important figures");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Pending Proposals:");
		bool flag7 = false;
		if (list2.Any())
		{
			foreach (KingdomStatement statement in list2)
			{
				Kingdom val12 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == statement.KingdomId && !val21.IsEliminated));
				if (val12 == null)
				{
					continue;
				}
				List<string> list5 = ((statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any()) ? statement.TargetKingdomIds : ((!string.IsNullOrEmpty(statement.TargetKingdomId)) ? new List<string> { statement.TargetKingdomId } : new List<string>()));
				if (!list5.Any())
				{
					continue;
				}
				List<DiplomaticAction> list6 = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
				for (int num4 = 0; num4 < list6.Count; num4++)
				{
					DiplomaticAction diplomaticAction = list6[num4];
					string targetKingdomId;
					if (list6.Count == list5.Count)
					{
						targetKingdomId = list5[num4];
					}
					else
					{
						targetKingdomId = list5.FirstOrDefault();
					}
					if (string.IsNullOrEmpty(targetKingdomId))
					{
						continue;
					}
					Kingdom val13 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == targetKingdomId && !val21.IsEliminated));
					if (val13 == null)
					{
						continue;
					}
					bool flag8 = false;
					Func<KingdomStatement, bool> hasRespondedToSource = (KingdomStatement s) => s.KingdomId == targetKingdomId && (s.TargetKingdomId == statement.KingdomId || (s.TargetKingdomIds != null && s.TargetKingdomIds.Contains(statement.KingdomId)));
					switch (diplomaticAction)
					{
					case DiplomaticAction.ProposeAlliance:
						flag8 = list2.Any((KingdomStatement s) => hasRespondedToSource(s) && (s.Action == DiplomaticAction.AcceptAlliance || s.Action == DiplomaticAction.RejectAlliance || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptAlliance) || s.Actions.Contains(DiplomaticAction.RejectAlliance)))));
						break;
					case DiplomaticAction.ProposePeace:
						flag8 = list2.Any((KingdomStatement s) => hasRespondedToSource(s) && (s.Action == DiplomaticAction.AcceptPeace || s.Action == DiplomaticAction.RejectPeace || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptPeace) || s.Actions.Contains(DiplomaticAction.RejectPeace)))));
						break;
					case DiplomaticAction.ProposeTradeAgreement:
						flag8 = list2.Any((KingdomStatement s) => hasRespondedToSource(s) && (s.Action == DiplomaticAction.AcceptTradeAgreement || s.Action == DiplomaticAction.RejectTradeAgreement || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptTradeAgreement) || s.Actions.Contains(DiplomaticAction.RejectTradeAgreement)))));
						break;
					case DiplomaticAction.DemandTerritory:
						flag8 = list2.Any((KingdomStatement s) => hasRespondedToSource(s) && (s.Action == DiplomaticAction.TransferTerritory || (s.Actions != null && s.Actions.Contains(DiplomaticAction.TransferTerritory))) && s.SettlementId == statement.SettlementId);
						break;
					case DiplomaticAction.DemandTribute:
						flag8 = list2.Any((KingdomStatement s) => hasRespondedToSource(s) && (s.Action == DiplomaticAction.AcceptTribute || s.Action == DiplomaticAction.RejectTribute || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptTribute) || s.Actions.Contains(DiplomaticAction.RejectTribute)))));
						break;
					case DiplomaticAction.DemandReparations:
						flag8 = list2.Any((KingdomStatement s) => hasRespondedToSource(s) && (s.Action == DiplomaticAction.AcceptReparations || s.Action == DiplomaticAction.RejectReparations || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptReparations) || s.Actions.Contains(DiplomaticAction.RejectReparations)))));
						break;
					}
					if (flag8)
					{
						continue;
					}
					string text5 = null;
					switch (diplomaticAction)
					{
					case DiplomaticAction.ProposePeace:
						text5 = $"{val12.Name} → {val13.Name}: PEACE (awaiting response)";
						break;
					case DiplomaticAction.ProposeAlliance:
						text5 = $"{val12.Name} → {val13.Name}: ALLIANCE (awaiting response)";
						break;
					case DiplomaticAction.ProposeTradeAgreement:
						text5 = $"{val12.Name} → {val13.Name}: TRADE AGREEMENT (awaiting response)";
						break;
					case DiplomaticAction.DemandTerritory:
					{
						Settlement val14 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == statement.SettlementId));
						string text6 = ((val14 == null) ? null : ((object)val14.Name)?.ToString()) ?? statement.SettlementId;
						text5 = $"{val12.Name} → {val13.Name}: TERRITORY DEMAND ({text6}, string_id:{statement.SettlementId}) (awaiting response)";
						break;
					}
					case DiplomaticAction.DemandTribute:
						text5 = $"{val12.Name} → {val13.Name}: TRIBUTE DEMAND ({statement.DailyTributeAmount} gold/day for {statement.TributeDurationDays} days) (awaiting response)";
						break;
					case DiplomaticAction.DemandReparations:
						text5 = $"{val12.Name} → {val13.Name}: REPARATIONS DEMAND ({statement.ReparationsAmount} gold) (awaiting response)";
						break;
					}
					if (text5 != null)
					{
						stringBuilder.AppendLine("  " + text5);
						flag7 = true;
					}
				}
			}
		}
		if (!flag7)
		{
			stringBuilder.AppendLine("  - No pending proposals");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### AVAILABLE KINGDOMS ###");
		stringBuilder.AppendLine("All kingdoms that exist in the game and can be added to this diplomatic event:");
		int num5 = diplomaticEvent.ParticipatingKingdoms.Count((string text13) => text13 != playerKingdomId);
		stringBuilder.AppendLine($"**IMPORTANT: Maximum participating kingdoms limit: {GlobalSettings<ModSettings>.Instance?.MaxParticipatingKingdoms ?? 4} (excluding player kingdom)**");
		stringBuilder.AppendLine($"Current participants: {diplomaticEvent.ParticipatingKingdoms.Count} total ({num5} non-player)");
		stringBuilder.AppendLine();
		List<Kingdom> list7 = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom val21) => !val21.IsEliminated && val21.Leader != null && ((MBObjectBase)val21).StringId != playerKingdomId).ToList();
		List<string> list8 = new List<string>();
		foreach (Kingdom k2 in list7)
		{
			List<string> list9 = (from enemy in (IEnumerable<Kingdom>)Kingdom.All
				where !enemy.IsEliminated && enemy != k2 && FactionManager.IsAtWarAgainstFaction((IFaction)(object)k2, (IFaction)(object)enemy)
				select $"{enemy.Name} (string_id:{((MBObjectBase)enemy).StringId})").ToList();
			string arg2 = (list9.Any() ? (" [At War With: " + string.Join(", ", list9) + "]") : " [Peace]");
			list8.Add($"- {k2.Name} (string_id:{((MBObjectBase)k2).StringId}){arg2}");
		}
		stringBuilder.AppendLine(string.Join(Environment.NewLine, list8));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### RELEVANT OUTSIDERS (AT WAR WITH PARTICIPANTS) ###");
		stringBuilder.AppendLine("These kingdoms are NOT in the event yet, but are AT WAR with current participants.");
		stringBuilder.AppendLine("Consider adding them to the event ('kingdoms_to_add') to resolve the conflict:");
		List<string> list10 = new List<string>();
		foreach (string participantId in diplomaticEvent.ParticipatingKingdoms)
		{
			Kingdom val15 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == participantId && !val21.IsEliminated));
			if (val15 == null)
			{
				continue;
			}
			foreach (Kingdom item10 in (List<Kingdom>)(object)Kingdom.All)
			{
				if (!diplomaticEvent.ParticipatingKingdoms.Contains(((MBObjectBase)item10).StringId) && !item10.IsEliminated && item10.Leader != null && FactionManager.IsAtWarAgainstFaction((IFaction)(object)val15, (IFaction)(object)item10))
				{
					string text7 = "";
					DiplomaticReason diplomaticReason3 = warTracker.GetDiplomaticReason(val15, item10, "war");
					if (diplomaticReason3 != null && !string.IsNullOrEmpty(diplomaticReason3.Reason))
					{
						text7 = " (Reason: " + diplomaticReason3.Reason + ")";
					}
					list10.Add($"- {item10.Name} (string_id:{((MBObjectBase)item10).StringId}): At war with {val15.Name} (string_id:{((MBObjectBase)val15).StringId}){text7}");
				}
			}
		}
		if (list10.Any())
		{
			foreach (string item11 in list10.Distinct())
			{
				stringBuilder.AppendLine(item11);
			}
		}
		else
		{
			stringBuilder.AppendLine("None. No relevant outsiders found at war with participants.");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**IMPORTANT!!! ADD OTHER KINGDOMS TO THE EVENT IF IT MAY BE RELATED TO THEM, OR IF A KINGDOM HAS NOT PARTICIPATED IN EVENTS FOR A LONG TIME (can be checked by history of all events and ruler statements).**");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### DIPLOMATIC REASONS ###");
		stringBuilder.AppendLine("Specific reasons for diplomatic actions by participating kingdoms:");
		stringBuilder.AppendLine();
		foreach (string kingdomId3 in diplomaticEvent.ParticipatingKingdoms)
		{
			Kingdom val16 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == kingdomId3 && !val21.IsEliminated));
			if (val16 == null)
			{
				continue;
			}
			List<DiplomaticReason> diplomaticReasons = warTracker.GetDiplomaticReasons(val16);
			if (diplomaticReasons == null || !diplomaticReasons.Any())
			{
				continue;
			}
			stringBuilder.AppendLine($"{val16.Name} (string_id:{kingdomId3}):");
			foreach (DiplomaticReason reason in diplomaticReasons)
			{
				Kingdom val17 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == reason.TargetKingdomId && !val21.IsEliminated));
				if (val17 != null)
				{
					string text8 = reason.ActionType switch
					{
						"war" => "War against", 
						"peace" => "Peace with", 
						"alliance" => "Alliance with", 
						"alliance_break" => "Alliance broken with", 
						_ => reason.ActionType, 
					};
					stringBuilder.AppendLine($"  - {text8} {val17.Name} (string_id:{((MBObjectBase)val17).StringId}): {reason.Reason}");
				}
			}
			stringBuilder.AppendLine();
		}
		if (!diplomaticEvent.ParticipatingKingdoms.Any(delegate(string kid)
		{
			Kingdom val21 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val22) => ((MBObjectBase)val22).StringId == kid && !val22.IsEliminated));
			return val21 != null && warTracker.GetDiplomaticReasons(val21).Any();
		}))
		{
			stringBuilder.AppendLine("No specific diplomatic reasons recorded for participating kingdoms.");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("### CURRENT ROUND STATUS ###");
		stringBuilder.AppendLine($"Round: {diplomaticEvent.DiplomaticRounds}");
		List<string> list11 = (from s in list2.Skip(diplomaticEvent.StatementsAtRoundStart)
			select s.KingdomId).Distinct().ToList();
		if (list11.Any())
		{
			stringBuilder.AppendLine("Kingdoms that ALREADY responded in this round:");
			foreach (string kingdomId4 in list11)
			{
				Kingdom val18 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == kingdomId4));
				string text9 = ((val18 != null) ? ((!val18.IsEliminated) ? ((object)val18.Name).ToString() : $"{val18.Name} [Destroyed]") : kingdomId4);
				stringBuilder.AppendLine("  - " + text9 + " (string_id:" + kingdomId4 + ")");
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("IMPORTANT: Kingdoms that already responded in THIS round CANNOT respond again until the NEXT round.");
			stringBuilder.AppendLine("Do NOT expect or demand responses from kingdoms that already made statements in this round.");
		}
		stringBuilder.AppendLine();
		List<KingdomStatement> list12 = list2.Skip(Math.Max(0, list2.Count - 5)).ToList();
		List<DiplomaticAction> list13 = (from s in list12
			where s.Action != DiplomaticAction.None
			select s.Action).Distinct().ToList();
		stringBuilder.AppendLine("### PROGRESS CHECK ###");
		stringBuilder.AppendLine($"Recent actions: {list13.Count} unique types in last {list12.Count} statements");
		if (diplomaticEvent.DiplomaticRounds >= 2)
		{
			int num6 = (from s in (from s in list2
					where s.CampaignDays > 0f
					orderby s.CampaignDays descending
					select s).Take(diplomaticEvent.ParticipatingKingdoms.Count * 2)
				where s.Action != DiplomaticAction.None
				select s.Action).Distinct().Count();
			if (num6 == 0)
			{
				stringBuilder.AppendLine("WARNING: No actions in last 2 rounds - negotiations stalled → consider ENDING");
			}
			else
			{
				stringBuilder.AppendLine($"Activity level: {num6} action types in last 2 rounds");
			}
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### ACTIVE ECONOMIC EFFECTS ###");
		stringBuilder.AppendLine("Current economic effects that are affecting settlements/kingdoms:");
		stringBuilder.AppendLine("**IMPORTANT: Consider these effects when creating new economic_effects - avoid conflicts or stacking too many effects on same targets**");
		stringBuilder.AppendLine();
		string activeEconomicEffectsData = GetActiveEconomicEffectsData();
		stringBuilder.AppendLine(activeEconomicEffectsData);
		stringBuilder.AppendLine();
		ModSettings instance6 = GlobalSettings<ModSettings>.Instance;
		if (instance6 != null && instance6.EnableDiseaseSystem)
		{
			ModSettings instance7 = GlobalSettings<ModSettings>.Instance;
			stringBuilder.AppendLine("### ACTIVE DISEASES ###");
			stringBuilder.AppendLine("Current diseases in the world. Use disease_data to CREATE a new disease in any settlement (works for ANY event type):");
			stringBuilder.AppendLine("**QUARANTINE:** Only settlements marked [QUARANTINED] are officially quarantined by kingdom rulers. Do NOT use 'quarantine' in event_update or economic_effects reason for settlements without [QUARANTINED] status.");
			int valueOrDefault = (DiseaseManager.Instance?.GetAllDiseases()?.Count).GetValueOrDefault();
			bool flag9 = valueOrDefault < instance7.DiseaseMaxSimultaneous;
			stringBuilder.AppendLine(string.Format("**DISEASE LIMIT:** {0}/{1} active diseases.{2}", valueOrDefault, instance7.DiseaseMaxSimultaneous, flag9 ? "" : " LIMIT REACHED — do NOT create new diseases."));
			stringBuilder.AppendLine();
			string activeDiseasesData = GetActiveDiseasesData();
			stringBuilder.AppendLine(activeDiseasesData);
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("### === NEGOTIATION HISTORY (WHAT WAS SAID) ===");
		stringBuilder.AppendLine("This section shows statements and proposals made during negotiations.");
		stringBuilder.AppendLine("**IMPORTANT DISTINCTIONS:**");
		stringBuilder.AppendLine("- 'Action ATTEMPTED' = what kingdom TRIED to do (may have failed or be pending)");
		stringBuilder.AppendLine("- Actual results are in 'DIPLOMATIC STATUS' sections above (the ground truth)");
		stringBuilder.AppendLine("- 'awaiting response' in Pending Proposals = proposal is PENDING (not rejected, not accepted yet)");
		stringBuilder.AppendLine("- If proposal shows 'awaiting response', DO NOT write that it was rejected or ignored");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### COMPLETE NEGOTIATION HISTORY ###");
		stringBuilder.AppendLine("All statements in chronological order:");
		stringBuilder.AppendLine();
		if (list2.Any())
		{
			val7 = CampaignTime.Now;
			float num7 = (float)(val7).ToDays;
			int num8 = 0;
			foreach (KingdomStatement statement2 in list2)
			{
				Kingdom val19 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == statement2.KingdomId));
				string text10;
				string text11;
				if (val19 == null)
				{
					text10 = statement2.KingdomId;
					text11 = "Unknown";
				}
				else if (val19.IsEliminated)
				{
					text10 = $"{val19.Name} [Destroyed]";
					Hero leader = val19.Leader;
					text11 = ((leader != null) ? ((object)leader.Name).ToString() : null) ?? "[Destroyed Kingdom]";
				}
				else
				{
					text10 = ((object)val19.Name).ToString();
					Hero leader2 = val19.Leader;
					text11 = ((leader2 != null) ? ((object)leader2.Name).ToString() : null) ?? "Unknown";
				}
				int num9 = 0;
				if (statement2.CampaignDays > 0f)
				{
					_ = CampaignTime.Now;
					if (true)
					{
						num9 = Math.Max(0, (int)(num7 - statement2.CampaignDays));
					}
				}
				stringBuilder.AppendLine("[" + text10 + " (string_id:" + statement2.KingdomId + "), " + text11 + "]");
				stringBuilder.AppendLine($"Statement: {statement2.StatementText} ({num9} days ago)");
				stringBuilder.AppendLine($"Action ATTEMPTED: {statement2.Action}");
				if (!string.IsNullOrEmpty(statement2.TargetKingdomId))
				{
					Kingdom val20 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == statement2.TargetKingdomId));
					string text12 = ((val20 == null) ? statement2.TargetKingdomId : ((!val20.IsEliminated) ? ((object)val20.Name).ToString() : $"{val20.Name} [Destroyed]"));
					stringBuilder.AppendLine("Target: " + text12);
				}
				stringBuilder.AppendLine();
			}
		}
		else
		{
			stringBuilder.AppendLine("No previous statements.");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## YOUR TASK:");
		stringBuilder.AppendLine("Classify this round: escalation/compromise/stalemate/breakdown. Base narrative on DIPLOMATIC STATUS (ground truth), not ATTEMPTED actions.");
		stringBuilder.AppendLine("Each kingdom: ONE statement/round. Check CURRENT ROUND STATUS. Reflect NEW developments with consequences.");
		stringBuilder.AppendLine();
		List<string> list14 = diplomaticEvent.ParticipatingKingdoms.Where((string kid) => kid != playerKingdomId).Where(delegate(string kid)
		{
			Kingdom? obj2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == kid && !val21.IsEliminated));
			return ((obj2 != null) ? obj2.Leader : null) != null;
		}).ToList();
		if (list11.Count >= list14.Count && list14.Any())
		{
			stringBuilder.AppendLine("**ALL RESPONDED** → Consider ending if no pending proposals");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("Generate the analysis NOW (JSON only):");
		return stringBuilder.ToString();
	}

	private void AppendKingdomDetails(StringBuilder sb, Kingdom kingdom)
	{
		WarStatisticsTracker warTracker = _diplomacyManager.GetWarTracker();
		KingdomWarStats kingdomStats = warTracker.GetKingdomStats(kingdom);
		if (kingdomStats != null)
		{
			sb.AppendLine($"    Troops: {kingdomStats.CurrentTroops}, Casualties: {kingdomStats.TotalCasualties}, Captured: {kingdomStats.TotalLordsCaptured}, Killed: {kingdomStats.TotalLordsKilled}, Settlements Lost: {kingdomStats.TotalSettlementsLost}, Fatigue: {kingdomStats.WarFatigue:F1}%");
			string warStatsChangeSummary = warTracker.GetWarStatsChangeSummary(kingdom);
			if (!string.IsNullOrEmpty(warStatsChangeSummary))
			{
				sb.AppendLine("    48h Changes: " + warStatsChangeSummary);
			}
		}
	}

	private async Task<string> SendAnalysisToAI(string analysisData)
	{
		try
		{
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Sending analysis request to AI");
			OpenRouterCallResult raw = await _aiBehavior.SendAIRequestRaw(analysisData);
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Received AI analysis response");
			return raw.Success ? raw.Payload : null;
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] ERROR sending to AI: " + ex2.Message);
			return null;
		}
	}

	private DiplomaticAnalysisResult ProcessAIResponse(string aiResponse, DynamicEvent diplomaticEvent)
	{
		//IL_00ec: Expected O, but got Unknown
		try
		{
			if (string.IsNullOrEmpty(aiResponse))
			{
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] AI response missing or empty: " + (aiResponse ?? "(null)"));
				return null;
			}
			DynamicEventsLogger.Instance.Log($"[EVENTS_ANALYZER] Processing AI response (length: {aiResponse?.Length ?? 0})");
			string text = aiResponse.Trim();
			if (text.StartsWith("```json"))
			{
				text = text.Substring(7);
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Removed ```json prefix");
			}
			if (text.StartsWith("```"))
			{
				text = text.Substring(3);
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Removed ``` prefix");
			}
			if (text.EndsWith("```"))
			{
				text = text.Substring(0, text.Length - 3);
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Removed ``` suffix");
			}
			text = text.Trim();
			DynamicEventsLogger.Instance.Log($"[EVENTS_ANALYZER] Cleaned response length: {text.Length}");
			dynamic val = null;
			try
			{
				val = JsonConvert.DeserializeObject<object>(text);
			}
			catch (JsonException ex)
			{
				JsonException ex2 = ex;
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] JSON parsing failed: " + ((Exception)(object)ex2).Message);
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Raw response: " + aiResponse);
				return null;
			}
			if (val == null)
			{
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Failed to parse AI response - result is null");
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Response was: " + aiResponse);
				return null;
			}
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] JSON parsed successfully");
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Creating DiplomaticAnalysisResult object");
			DiplomaticAnalysisResult diplomaticAnalysisResult = new DiplomaticAnalysisResult();
			diplomaticAnalysisResult.ShouldContinueEvent = val.should_continue_event ?? ((object)false);
			diplomaticAnalysisResult.ShouldEndEvent = val.should_end_event ?? ((object)false);
			diplomaticAnalysisResult.KingdomsToAdd = val.kingdoms_to_add?.ToObject<List<string>>() ?? new List<string>();
			diplomaticAnalysisResult.KingdomsToRemove = val.kingdoms_to_remove?.ToObject<List<string>>() ?? new List<string>();
			diplomaticAnalysisResult.EventUpdate = val.event_update?.ToString() ?? "";
			diplomaticAnalysisResult.ActionsToExecute = new List<DiplomaticActionInfo>();
			diplomaticAnalysisResult.RelationChanges = new List<RelationChangeInfo>();
			diplomaticAnalysisResult.EconomicEffects = new List<EconomicEffect>();
			DiplomaticAnalysisResult diplomaticAnalysisResult2 = diplomaticAnalysisResult;
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Base result object created");
			if (val.actions_to_execute != null)
			{
				foreach (dynamic item in val.actions_to_execute)
				{
					string actionStr = item.action?.ToString() ?? "none";
					DiplomaticAction action = ParseActionString(actionStr);
					diplomaticAnalysisResult2.ActionsToExecute.Add(new DiplomaticActionInfo
					{
						Action = action,
						SourceKingdomId = (item.source_kingdom_id?.ToString() ?? ""),
						TargetKingdomId = (item.target_kingdom_id?.ToString() ?? ""),
						Reason = (item.reason?.ToString() ?? "")
					});
				}
			}
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Parsing relation changes");
			if (val.relation_changes != null)
			{
				DynamicEventsLogger.Instance.Log($"[EVENTS_ANALYZER] Found relation_changes field with {(object?)val.relation_changes.Count} entries");
				int num = default(int);
				foreach (dynamic item2 in val.relation_changes)
				{
					int change = 0;
					if (item2.change != null)
					{
						if (item2.change is int)
						{
							change = (int)item2.change;
						}
						else if (int.TryParse(item2.change.ToString(), out num))
						{
							change = num;
						}
					}
					RelationChangeInfo relationChangeInfo = new RelationChangeInfo();
					relationChangeInfo.Kingdom1Id = item2.kingdom1_id?.ToString() ?? "";
					relationChangeInfo.Kingdom2Id = item2.kingdom2_id?.ToString() ?? "";
					relationChangeInfo.Change = change;
					relationChangeInfo.Reason = item2.reason?.ToString() ?? "";
					RelationChangeInfo relationChangeInfo2 = relationChangeInfo;
					diplomaticAnalysisResult2.RelationChanges.Add(relationChangeInfo2);
					DynamicEventsLogger.Instance.Log($"[EVENTS_ANALYZER] Relation change: {relationChangeInfo2.Kingdom1Id} ↔ {relationChangeInfo2.Kingdom2Id}: {relationChangeInfo2.Change}");
				}
			}
			else
			{
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] No relation_changes field in AI response");
			}
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Parsing economic effects");
			if (val.economic_effects != null)
			{
				DynamicEventsLogger.Instance.Log($"[EVENTS_ANALYZER] Found economic_effects field with {(object?)val.economic_effects.Count} entries");
				try
				{
					diplomaticAnalysisResult2.EconomicEffects = val.economic_effects?.ToObject<List<EconomicEffect>>() ?? new List<EconomicEffect>();
					DynamicEventsLogger.Instance.Log($"[EVENTS_ANALYZER] Parsed {diplomaticAnalysisResult2.EconomicEffects.Count} economic effects");
					foreach (EconomicEffect economicEffect in diplomaticAnalysisResult2.EconomicEffects)
					{
						DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Economic effect: " + economicEffect.TargetType + " -> " + (economicEffect.TargetId ?? "multiple") + ", reason: " + economicEffect.Reason);
					}
				}
				catch (Exception ex3)
				{
					DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] ERROR parsing economic effects: " + ex3.Message);
					diplomaticAnalysisResult2.EconomicEffects = new List<EconomicEffect>();
				}
			}
			else
			{
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] No economic_effects field in AI response");
			}
			if (val.disease_data != null)
			{
				try
				{
					diplomaticAnalysisResult2.DiseaseData = val.disease_data?.ToObject<DiseaseEventData>();
					if (diplomaticAnalysisResult2.DiseaseData != null && !string.IsNullOrEmpty(diplomaticAnalysisResult2.DiseaseData.SettlementId))
					{
						DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Parsed disease_data: " + diplomaticAnalysisResult2.DiseaseData.DiseaseName + " in " + diplomaticAnalysisResult2.DiseaseData.SettlementId);
					}
				}
				catch (Exception ex4)
				{
					DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] ERROR parsing disease_data: " + ex4.Message);
					diplomaticAnalysisResult2.DiseaseData = null;
				}
			}
			DynamicEventsLogger.Instance.Log(string.Format("[EVENTS_ANALYZER] Parsed result: {0} actions to execute, {1} relation changes, {2} economic effects{3}", diplomaticAnalysisResult2.ActionsToExecute.Count, diplomaticAnalysisResult2.RelationChanges.Count, diplomaticAnalysisResult2.EconomicEffects.Count, (diplomaticAnalysisResult2.DiseaseData != null) ? ", 1 disease" : ""));
			DynamicEventsLogger.Instance.Log($"[EVENTS_ANALYZER] Kingdoms to add: {diplomaticAnalysisResult2.KingdomsToAdd.Count}, Kingdoms to remove: {diplomaticAnalysisResult2.KingdomsToRemove.Count}");
			if (diplomaticAnalysisResult2.KingdomsToAdd.Any())
			{
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Kingdoms to add: " + string.Join(", ", diplomaticAnalysisResult2.KingdomsToAdd));
			}
			if (diplomaticAnalysisResult2.KingdomsToRemove.Any())
			{
				DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Kingdoms to remove: " + string.Join(", ", diplomaticAnalysisResult2.KingdomsToRemove));
			}
			return diplomaticAnalysisResult2;
		}
		catch (Exception ex5)
		{
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] ERROR processing AI response: " + ex5.Message);
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Raw response: " + aiResponse);
			return null;
		}
	}

	private DiplomaticAction ParseActionString(string actionStr)
	{
		return actionStr?.ToLower() switch
		{
			"declare_war" => DiplomaticAction.DeclareWar, 
			"propose_peace" => DiplomaticAction.ProposePeace, 
			"accept_peace" => DiplomaticAction.AcceptPeace, 
			"reject_peace" => DiplomaticAction.RejectPeace, 
			"propose_alliance" => DiplomaticAction.ProposeAlliance, 
			"accept_alliance" => DiplomaticAction.AcceptAlliance, 
			"reject_alliance" => DiplomaticAction.RejectAlliance, 
			"break_alliance" => DiplomaticAction.BreakAlliance, 
			_ => DiplomaticAction.None, 
		};
	}

	public bool ShouldAnalyzeEvent(DynamicEvent diplomaticEvent)
	{
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		if (diplomaticEvent == null || !diplomaticEvent.RequiresDiplomaticAnalysis)
		{
			return false;
		}
		if (diplomaticEvent.IsExpired())
		{
			return false;
		}
		if (!diplomaticEvent.IsReadyForAnalysis())
		{
			return false;
		}
		Hero mainHero = Hero.MainHero;
		object obj;
		if (mainHero == null)
		{
			obj = null;
		}
		else
		{
			Clan clan = mainHero.Clan;
			obj = ((clan != null) ? clan.Kingdom : null);
		}
		Kingdom val = (Kingdom)obj;
		string playerKingdomId = ((val != null) ? ((MBObjectBase)val).StringId : null);
		int num = diplomaticEvent.ParticipatingKingdoms.Count((string k) => k != playerKingdomId);
		int num2 = Math.Min(diplomaticEvent.ParticipatingKingdoms.Count, (num > 0) ? num : (GlobalSettings<ModSettings>.Instance?.MaxParticipatingKingdoms ?? 4));
		bool flag = diplomaticEvent.KingdomStatements.Count >= num2;
		bool flag2 = false;
		if (diplomaticEvent.KingdomStatements.Any())
		{
			KingdomStatement kingdomStatement = diplomaticEvent.KingdomStatements.OrderByDescending((KingdomStatement s) => s.CampaignDays).First();
			CampaignTime val2 = CampaignTime.Now - kingdomStatement.Timestamp;
			flag2 = (val2).ToHours >= 6.0;
		}
		return flag || flag2;
	}

	private string GetRelationDescription(int relation)
	{
		if (relation >= 85)
		{
			return "Close Allies - Strong trust, easy agreements";
		}
		if (relation >= 70)
		{
			return "Trusted Friends - Good cooperation";
		}
		if (relation >= 55)
		{
			return "Friendly - Positive stance";
		}
		if (relation >= 40)
		{
			return "Good Terms - Favorable relations";
		}
		if (relation >= 25)
		{
			return "Cordial - Polite relations";
		}
		if (relation >= 10)
		{
			return "Neutral-Positive - Slightly favorable";
		}
		if (relation >= -10)
		{
			return "Neutral - Indifferent";
		}
		if (relation >= -25)
		{
			return "Cool - Distant";
		}
		if (relation >= -40)
		{
			return "Suspicious - Wary";
		}
		if (relation >= -55)
		{
			return "Unfriendly - Negative stance";
		}
		if (relation >= -70)
		{
			return "Strained - Strong dislike";
		}
		if (relation >= -85)
		{
			return "Hostile - Deep animosity";
		}
		if (relation >= -95)
		{
			return "Bitter Enemies - Hatred";
		}
		return "Sworn Foes - Absolute enmity";
	}

	private List<DeathInfo> GetRecentImportantDeaths(int daysThreshold)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		List<DeathInfo> list = new List<DeathInfo>();
		List<WorldInfoManager.DeathRecord> recentDeaths = WorldInfoManager.Instance.GetRecentDeaths();
		foreach (WorldInfoManager.DeathRecord item2 in recentDeaths)
		{
			CampaignTime val = CampaignTime.Now - item2.DeathTime;
			if ((val).ToDays > (double)daysThreshold)
			{
				continue;
			}
			object obj;
			if (!item2.Victim.IsKingdomLeader)
			{
				Clan clan = item2.Victim.Clan;
				if (clan == null || clan.Tier < 5)
				{
					Clan clan2 = item2.Victim.Clan;
					obj = ((clan2 != null && clan2.Tier >= 4) ? "Lord" : "Noble");
				}
				else
				{
					obj = "High Lord";
				}
			}
			else
			{
				obj = "Kingdom Ruler";
			}
			string title = (string)obj;
			DeathInfo obj2 = new DeathInfo
			{
				HeroName = (((object)item2.Victim.Name)?.ToString() ?? "Unknown"),
				HeroStringId = (((MBObjectBase)item2.Victim).StringId ?? "unknown"),
				Title = title,
				DeathCause = item2.DeathCause,
				KillerName = item2.KillerName,
				KillerStringId = item2.KillerStringId
			};
			Clan clan3 = item2.Victim.Clan;
			object obj3;
			if (clan3 == null)
			{
				obj3 = null;
			}
			else
			{
				Kingdom kingdom = clan3.Kingdom;
				obj3 = ((kingdom == null) ? null : ((object)kingdom.Name)?.ToString());
			}
			if (obj3 == null)
			{
				obj3 = "Independent";
			}
			obj2.KingdomName = (string)obj3;
			Clan clan4 = item2.Victim.Clan;
			object obj4;
			if (clan4 == null)
			{
				obj4 = null;
			}
			else
			{
				Kingdom kingdom2 = clan4.Kingdom;
				obj4 = ((kingdom2 != null) ? ((MBObjectBase)kingdom2).StringId : null);
			}
			if (obj4 == null)
			{
				obj4 = "independent";
			}
			obj2.KingdomStringId = (string)obj4;
			val = CampaignTime.Now - item2.DeathTime;
			obj2.DaysAgo = (int)(val).ToDays;
			DeathInfo item = obj2;
			list.Add(item);
		}
		return list.OrderByDescending((DeathInfo d) => (d.DaysAgo == 0) ? int.MaxValue : d.DaysAgo).Take(4).ToList();
	}

	private string GetActiveEconomicEffectsData()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			EconomicEffectsManager instance = EconomicEffectsManager.Instance;
			if (instance == null)
			{
				return "No economic effects manager available.";
			}
			List<ActiveEconomicEffect> activeEffects = instance.GetActiveEffects();
			if (activeEffects == null || !activeEffects.Any())
			{
				return "No active economic effects.";
			}
			CampaignTime now = CampaignTime.Now;
			float currentDay = (float)(now).ToDays;
			List<ActiveEconomicEffect> list = activeEffects.Where((ActiveEconomicEffect e) => currentDay < e.StartDay + (float)e.DurationDays).ToList();
			if (!list.Any())
			{
				return "No active economic effects.";
			}
			var list2 = (from e in list
				group e by new
				{
					Reason = GetReason(e),
					TargetType = e.TargetType,
					Prosperity = (float)Math.Round(e.ProsperityDeltaPerDay, 2),
					Food = (float)Math.Round(e.FoodDeltaPerDay, 2),
					Income = (float)Math.Round(e.IncomeMultiplier, 3),
					DurationDays = e.DurationDays
				} into g
				orderby g.Count() descending, g.Key.TargetType, g.Key.Reason
				select g).Take(12).ToList();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("=== ACTIVE ECONOMIC EFFECTS (GROUPED) ===");
			stringBuilder.AppendLine("Grouped by reason and effect signature to avoid per-settlement spam:");
			foreach (var item in list2)
			{
				var key = item.Key;
				stringBuilder.AppendLine("- Reason: " + key.Reason);
				stringBuilder.AppendLine("  Target type: " + key.TargetType);
				if (Math.Abs(key.Prosperity) > 0.001f)
				{
					stringBuilder.AppendLine($"  Prosperity per day: {key.Prosperity:+#.#;-#.#;0}");
				}
				if (Math.Abs(key.Food) > 0.001f)
				{
					stringBuilder.AppendLine($"  Food per day: {key.Food:+#.#;-#.#;0}");
				}
				if (Math.Abs(key.Income - 1f) > 0.001f)
				{
					stringBuilder.AppendLine(string.Format("  Income multiplier: {0:F2}x ({1}{2:F0}%)", key.Income, (key.Income > 1f) ? "+" : "", (key.Income - 1f) * 100f));
				}
				stringBuilder.AppendLine($"  Remaining duration: {item.First().GetRemainingDays()} days");
				if (key.TargetType == "settlement")
				{
					stringBuilder.AppendLine($"  Settlements affected: {item.Count()}");
					foreach (IGrouping<string, ActiveEconomicEffect> item2 in from e in item
						group e by GetKingdomLabel(e.TargetId) into g
						orderby g.Key
						select g)
					{
						List<string> list3 = item2.Select((ActiveEconomicEffect e) => GetSettlementLabel(e.TargetId)).Distinct().Take(3)
							.ToList();
						stringBuilder.Append($"    {item2.Key}: {item2.Count()}");
						if (list3.Any())
						{
							stringBuilder.Append(" (e.g., " + string.Join(", ", list3) + ")");
						}
						stringBuilder.AppendLine();
					}
				}
				else
				{
					IEnumerable<string> values = item.Select(delegate(ActiveEconomicEffect e)
					{
						if (e.TargetType == "kingdom")
						{
							Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == e.TargetId && !k.IsEliminated));
							return (val != null) ? $"{val.Name} ({((MBObjectBase)val).StringId})" : e.TargetId;
						}
						if (e.TargetType == "clan")
						{
							Clan val2 = ((IEnumerable<Clan>)Clan.All).FirstOrDefault((Func<Clan, bool>)((Clan c) => ((MBObjectBase)c).StringId == e.TargetId));
							return (val2 != null) ? $"{val2.Name} ({((MBObjectBase)val2).StringId})" : e.TargetId;
						}
						return e.TargetId;
					}).Distinct().Take(5);
					stringBuilder.AppendLine("  Targets: " + string.Join(", ", values));
				}
				stringBuilder.AppendLine();
			}
			int num = list.Count - list2.Sum(g => g.Count());
			if (num > 0)
			{
				stringBuilder.AppendLine($"... +{num} more active effects grouped under similar reasons.");
			}
			return stringBuilder.ToString();
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Error getting active economic effects: " + ex.Message);
			return "Error retrieving economic effects data.";
		}
		static string GetKingdomLabel(string targetId)
		{
			Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == targetId));
			object obj;
			if (val == null)
			{
				obj = null;
			}
			else
			{
				Clan ownerClan = val.OwnerClan;
				obj = ((ownerClan != null) ? ownerClan.Kingdom : null);
			}
			Kingdom val2 = (Kingdom)obj;
			return (val2 != null) ? ((object)val2.Name).ToString() : "No kingdom";
		}
		static string GetReason(ActiveEconomicEffect e)
		{
			return string.IsNullOrWhiteSpace(e.Reason) ? "No reason specified" : e.Reason.Trim();
		}
		static string GetSettlementLabel(string targetId)
		{
			Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == targetId));
			return (val == null) ? targetId : $"{val.Name} ({((MBObjectBase)val).StringId})";
		}
	}

	private string GetActiveDiseasesData()
	{
		try
		{
			DiseaseManager instance = DiseaseManager.Instance;
			if (instance == null)
			{
				return "Disease system not available.";
			}
			List<Disease> allDiseases = instance.GetAllDiseases();
			if (allDiseases == null || !allDiseases.Any())
			{
				return "No active diseases. Use disease_data to create a new disease outbreak in a settlement.";
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Disease d in allDiseases)
			{
				Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == d.SettlementId));
				string text = ((val == null) ? null : ((object)val.Name)?.ToString()) ?? d.SettlementId;
				object obj;
				if (val == null)
				{
					obj = null;
				}
				else
				{
					Clan ownerClan = val.OwnerClan;
					obj = ((ownerClan != null) ? ownerClan.Kingdom : null);
				}
				string text2 = ((obj == null) ? null : ((object)((Kingdom)obj).Name)?.ToString()) ?? "Unknown";
				string text3 = (d.IsQuarantined ? " [QUARANTINED]" : "");
				stringBuilder.AppendLine($"- {d.Name} in {text} (string_id:{d.SettlementId}), {text2}{text3}, severity {d.Severity}/5");
			}
			return stringBuilder.ToString();
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Error getting active diseases: " + ex.Message);
			return "Error retrieving diseases data.";
		}
	}

	private void AppendKingdomDynamicData(StringBuilder sb, Kingdom kingdom, DynamicEvent diplomaticEvent)
	{
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			List<Settlement> list = ((IEnumerable<Settlement>)kingdom.Settlements).Where((Settlement s) => s.IsTown && !s.IsVillage).ToList();
			List<Settlement> list2 = ((IEnumerable<Settlement>)kingdom.Settlements).Where((Settlement s) => s.IsCastle).ToList();
			sb.AppendLine();
			sb.AppendLine("    **Current Settlements:**");
			if (list.Any())
			{
				List<string> values = list.Select((Settlement t) => ((object)t.Name).ToString() + (GameVersionCompatibility.SettlementHasPort(t) ? " (port)" : "")).ToList();
				sb.AppendLine(string.Format("    Towns ({0}): {1}", list.Count, string.Join(", ", values)));
			}
			else
			{
				sb.AppendLine("    Towns (0): None");
			}
			if (list2.Any())
			{
				sb.AppendLine($"    Castles: {list2.Count} castles");
			}
			else
			{
				sb.AppendLine("    Castles: 0 castles");
			}
			KingdomWarStats kingdomWarStats = _diplomacyManager.GetWarTracker()?.GetKingdomStats(kingdom);
			if (kingdomWarStats != null)
			{
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				CampaignTime val = CampaignTime.Now;
				float num = (float)(val).ToDays;
				foreach (Settlement item in ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsTown || s.IsCastle))
				{
					SettlementOwnershipHistory settlementOwnershipHistory = SettlementOwnershipTracker.Instance?.GetOwnershipHistory(((MBObjectBase)item).StringId);
					if (settlementOwnershipHistory == null || !settlementOwnershipHistory.OwnershipChanges.Any())
					{
						continue;
					}
					OwnershipChange lastChange = settlementOwnershipHistory.OwnershipChanges.LastOrDefault();
					if (lastChange == null)
					{
						continue;
					}
					val = lastChange.ChangeDate;
					float num2 = num - (float)(val).ToDays;
					if (!(num2 <= 20f))
					{
						continue;
					}
					if (lastChange.FromKingdomId == ((MBObjectBase)kingdom).StringId)
					{
						Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == lastChange.ToKingdomId && !k.IsEliminated));
						string arg = ((val2 == null) ? null : ((object)val2.Name)?.ToString()) ?? "Unknown";
						list3.Add($"{item.Name} (lost to {arg} {(int)num2} days ago)");
					}
					else if (lastChange.ToKingdomId == ((MBObjectBase)kingdom).StringId)
					{
						Kingdom val3 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == lastChange.FromKingdomId && !k.IsEliminated));
						string arg2 = ((val3 == null) ? null : ((object)val3.Name)?.ToString()) ?? "Unknown";
						list4.Add($"{item.Name} (captured from {arg2} {(int)num2} days ago)");
					}
				}
				if (list4.Any())
				{
					sb.AppendLine("    Recent captures: " + string.Join(", ", list4));
				}
				if (list3.Any())
				{
					sb.AppendLine("    Recent losses: " + string.Join(", ", list3));
				}
			}
			sb.AppendLine();
			sb.AppendLine("    **Active Sieges:**");
			List<string> list5 = new List<string>();
			List<MobileParty> list6 = ((IEnumerable<MobileParty>)MobileParty.All).Where((MobileParty p) => p.SiegeEvent != null && p.SiegeEvent.BesiegedSettlement != null && p.MapFaction is Kingdom && ((MBObjectBase)(Kingdom)p.MapFaction).StringId == ((MBObjectBase)kingdom).StringId).ToList();
			foreach (MobileParty item2 in list6)
			{
				Settlement besiegedSettlement = item2.SiegeEvent.BesiegedSettlement;
				Clan ownerClan = besiegedSettlement.OwnerClan;
				Kingdom val4 = ((ownerClan != null) ? ownerClan.Kingdom : null);
				string text = ((val4 == null) ? null : ((object)val4.Name)?.ToString()) ?? "Independent";
				Hero leaderHero = item2.LeaderHero;
				string text2 = ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString()) ?? "Unknown";
				list5.Add($"Besieging {besiegedSettlement.Name} (string_id:{((MBObjectBase)besiegedSettlement).StringId}) - Defender: {text}, Leader: {text2}");
			}
			List<Settlement> list7 = ((IEnumerable<Settlement>)Settlement.All).Where(delegate(Settlement s)
			{
				int result;
				if (s.IsUnderSiege)
				{
					Clan ownerClan2 = s.OwnerClan;
					if (((ownerClan2 != null) ? ownerClan2.Kingdom : null) != null)
					{
						result = ((((MBObjectBase)s.OwnerClan.Kingdom).StringId == ((MBObjectBase)kingdom).StringId) ? 1 : 0);
						goto IL_003f;
					}
				}
				result = 0;
				goto IL_003f;
				IL_003f:
				return (byte)result != 0;
			}).ToList();
			foreach (Settlement settlement in list7)
			{
				MobileParty val5 = ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty p) => p.SiegeEvent != null && p.SiegeEvent.BesiegedSettlement == settlement));
				if (val5 != null)
				{
					IFaction mapFaction = val5.MapFaction;
					Kingdom val6 = (Kingdom)(object)((mapFaction is Kingdom) ? mapFaction : null);
					string text3 = ((val6 == null) ? null : ((object)val6.Name)?.ToString()) ?? "Unknown";
					Hero leaderHero2 = val5.LeaderHero;
					string text4 = ((leaderHero2 == null) ? null : ((object)leaderHero2.Name)?.ToString()) ?? "Unknown";
					list5.Add($"Defending {settlement.Name} (string_id:{((MBObjectBase)settlement).StringId}) - Attacker: {text3}, Leader: {text4}");
				}
			}
			if (list5.Any())
			{
				foreach (string item3 in list5)
				{
					sb.AppendLine("    - " + item3);
				}
			}
			else
			{
				sb.AppendLine("    - None");
			}
			sb.AppendLine();
			sb.AppendLine("    **Large Armies:**");
			var list8 = (from p in (IEnumerable<MobileParty>)MobileParty.All
				where p.Army != null && p.Army.LeaderParty == p && p.MapFaction is Kingdom && ((MBObjectBase)(Kingdom)p.MapFaction).StringId == ((MBObjectBase)kingdom).StringId
				select new
				{
					Party = p,
					TotalTroops = ((IEnumerable<MobileParty>)p.Army.Parties).Sum((MobileParty val8) => val8.MemberRoster.TotalManCount)
				} into a
				where a.TotalTroops > 850
				orderby a.TotalTroops descending
				select a).Take(3).ToList();
			if (list8.Any())
			{
				foreach (var item4 in list8)
				{
					MobileParty party = item4.Party;
					Hero leaderHero3 = party.LeaderHero;
					string text5 = ((leaderHero3 == null) ? null : ((object)leaderHero3.Name)?.ToString()) ?? "Unknown";
					Hero leaderHero4 = party.LeaderHero;
					string text6 = ((leaderHero4 != null) ? ((MBObjectBase)leaderHero4).StringId : null) ?? "unknown";
					string text7 = ((object)party.Army.Name)?.ToString() ?? ((object)party.Name)?.ToString() ?? "Unknown Army";
					string text8 = "Patrolling";
					if (party.SiegeEvent != null)
					{
						Settlement besiegedSettlement2 = party.SiegeEvent.BesiegedSettlement;
						object obj;
						if (besiegedSettlement2 == null)
						{
							obj = null;
						}
						else
						{
							IFaction mapFaction2 = besiegedSettlement2.MapFaction;
							obj = ((mapFaction2 == null) ? null : ((object)mapFaction2.Name)?.ToString());
						}
						if (obj == null)
						{
							obj = "Unknown";
						}
						string text9 = (string)obj;
						text8 = "Besieging " + (((besiegedSettlement2 == null) ? null : ((object)besiegedSettlement2.Name)?.ToString()) ?? "Unknown") + " (" + text9 + ")";
					}
					else if (party.TargetSettlement != null)
					{
						IFaction mapFaction3 = party.TargetSettlement.MapFaction;
						string arg3 = ((mapFaction3 == null) ? null : ((object)mapFaction3.Name)?.ToString()) ?? "Unknown";
						text8 = $"Moving to {party.TargetSettlement.Name} ({arg3})";
					}
					else if (party.TargetParty != null)
					{
						IFaction mapFaction4 = party.TargetParty.MapFaction;
						string arg4 = ((mapFaction4 == null) ? null : ((object)mapFaction4.Name)?.ToString()) ?? "Unknown";
						text8 = $"Engaging {party.TargetParty.Name} ({arg4})";
					}
					else if (party.IsDisorganized)
					{
						text8 = "Disorganized, regrouping";
					}
					Settlement val7 = ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsTown || s.IsCastle).OrderBy(delegate(Settlement s)
					{
						//IL_0001: Unknown result type (might be due to invalid IL or missing references)
						//IL_0006: Unknown result type (might be due to invalid IL or missing references)
						//IL_000f: Unknown result type (might be due to invalid IL or missing references)
						Vec2 position2D = s.GetPosition2D();
						return (position2D).DistanceSquared(party.GetPosition2D());
					}).FirstOrDefault();
					string text10 = ((val7 == null) ? null : ((object)val7.Name)?.ToString()) ?? "Unknown location";
					sb.AppendLine($"    - {text7} ({item4.TotalTroops} troops) - Leader: {text5} (string_id:{text6})");
					sb.AppendLine("      Location: Near " + text10);
					sb.AppendLine("      Objective: " + text8);
					sb.AppendLine(string.Format("      Status: {0}, Morale: {1:F0}%", party.IsDisorganized ? "Disorganized" : "Organized", party.Morale));
				}
				return;
			}
			sb.AppendLine($"    - No large armies (>{850} troops)");
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[EVENTS_ANALYZER] Error appending kingdom dynamic data: " + ex.Message);
			sb.AppendLine($"    (Error gathering dynamic data for {kingdom.Name})");
		}
	}
}
