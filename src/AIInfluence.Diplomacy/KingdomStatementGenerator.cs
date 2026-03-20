using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AIInfluence.Diseases;
using AIInfluence.DynamicEvents;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class KingdomStatementGenerator
{
	private class ActionTargetPair
	{
		public DiplomaticAction Action { get; set; }

		public string TargetKingdomId { get; set; }
	}

	private readonly DiplomacyManager _diplomacyManager;

	private static Dictionary<string, CampaignTime> _lastStatementTime = new Dictionary<string, CampaignTime>();

	public KingdomStatementGenerator(DiplomacyManager diplomacyManager)
	{
		_diplomacyManager = diplomacyManager;
	}

	public async Task<List<KingdomStatement>> GenerateStatements(DynamicEvent diplomaticEvent, List<Kingdom> kingdoms)
	{
		CleanupOldAndInvalidProposals();
		List<KingdomStatement> statements = new List<KingdomStatement>();
		if (kingdoms == null || !kingdoms.Any())
		{
			DiplomacyLogger.Instance.Log("[STATEMENT_GEN] No kingdoms provided");
			return statements;
		}
		DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Generating statements for {0} kingdoms: {1}", kingdoms.Count, string.Join(", ", kingdoms.Select((Kingdom k) => k.Name))));
		for (int i = 0; i < kingdoms.Count; i++)
		{
			Kingdom kingdom = kingdoms[i];
			try
			{
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Starting statement generation for {kingdom.Name} ({i + 1}/{kingdoms.Count})");
				if (DiplomacyManagerHelpers.IsPlayerKingdom(kingdom))
				{
					DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Skipping AI generation for player kingdom {kingdom.Name}. Player must respond via UI.");
					continue;
				}
				if (kingdom.Leader == null)
				{
					DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Skipping {kingdom.Name} - kingdom has no leader (Leader=NULL). Cannot generate diplomatic statements without a leader.");
					continue;
				}
				if (IsLeaderPrisonerOfPlayer(kingdom))
				{
					DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Skipping {kingdom.Name} - leader {kingdom.Leader.Name} is prisoner of player. Cannot generate diplomatic statements while imprisoned by player.");
					continue;
				}
				string kingdomId = ((MBObjectBase)kingdom).StringId;
				HashSet<string> respondedInCurrentRound = (from s in diplomaticEvent.KingdomStatements.Skip(diplomaticEvent.StatementsAtRoundStart)
					select s.KingdomId).ToHashSet();
				if (respondedInCurrentRound.Contains(kingdomId))
				{
					DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Skipping {kingdom.Name} - already responded in current round of event {diplomaticEvent.Id}");
					continue;
				}
				if (!_lastStatementTime.ContainsKey(kingdomId))
				{
					goto IL_0317;
				}
				CampaignTime timeSinceLastStatement = CampaignTime.Now - _lastStatementTime[kingdomId];
				if (!((timeSinceLastStatement).ToHours < 2.0))
				{
					goto IL_0317;
				}
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Skipping {kingdom.Name} - too soon since last statement ({(timeSinceLastStatement).ToHours:F1} hours ago, minimum 2 hours)");
				goto end_IL_00e5;
				IL_0317:
				KingdomDiplomaticData kingdomData = GatherKingdomData(kingdom, diplomaticEvent);
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Gathered data for {kingdom.Name}");
				var (prompt, cachePrefixLength) = GenerateStatementPrompt(kingdom, kingdomData, diplomaticEvent);
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Generated prompt for {kingdom.Name} ({prompt.Length} chars)");
				if (IsLeaderPrisonerOfPlayer(kingdom))
				{
					DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Leader {kingdom.Leader.Name} became prisoner of player during generation, skipping AI request");
					continue;
				}
				KingdomStatement statement = await GetAIStatement(prompt, kingdom, diplomaticEvent, cachePrefixLength);
				if (statement != null)
				{
					if (!diplomaticEvent.KingdomStatements.Contains(statement))
					{
						diplomaticEvent.KingdomStatements.Add(statement);
						string actionsStr = ((statement.Actions != null && statement.Actions.Any()) ? string.Join(",", statement.Actions) : statement.Action.ToString());
						DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Temporarily added statement to event for visibility: {kingdom.Name} -> {statement.TargetKingdomId}, action={actionsStr}");
					}
					if (IsLeaderPrisonerOfPlayer(kingdom))
					{
						DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Leader {kingdom.Leader.Name} became prisoner of player after AI response, discarding statement");
						continue;
					}
					statements.Add(statement);
					DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Generated statement for {kingdom.Name}: {statement.Action}");
					_lastStatementTime[kingdomId] = CampaignTime.Now;
					ShowKingdomStatementToPlayer(kingdom, statement, diplomaticEvent);
					goto IL_0651;
				}
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] WARNING: Statement is null for {kingdom.Name}");
				goto IL_0651;
				IL_0651:
				HashSet<string> respondedKingdomIds = (from s in diplomaticEvent.KingdomStatements.Skip(diplomaticEvent.StatementsAtRoundStart)
					select s.KingdomId).ToHashSet();
				respondedKingdomIds.Add(kingdomId);
				Kingdom nextKingdom = (from k in kingdoms
					where !DiplomacyManagerHelpers.IsPlayerKingdom(k)
					where !IsLeaderPrisonerOfPlayer(k)
					select k).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => !respondedKingdomIds.Contains(((MBObjectBase)k).StringId)));
				if (nextKingdom != null)
				{
					int delayDays = GetRandomStatementInterval();
					DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Scheduling next statement for {nextKingdom.Name} in {delayDays} days");
					CampaignTime nextStatementTime = CampaignTime.DaysFromNow((float)delayDays);
					DiplomacyManager.Instance?.ScheduleNextStatement(diplomaticEvent.Id, nextKingdom, nextStatementTime);
					break;
				}
				DiplomacyLogger.Instance.Log("[STATEMENT_GEN] No more kingdoms to respond in this round. All kingdoms have responded or are unavailable.");
				end_IL_00e5:;
			}
			catch (Exception ex)
			{
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] ERROR generating statement for {kingdom.Name}: {ex.Message}");
				DiplomacyLogger.Instance.LogError("KingdomStatementGenerator.GenerateStatements", $"Failed to generate statement for {kingdom.Name}", ex);
			}
		}
		if (statements.Count == 0 && kingdoms.Any())
		{
			Kingdom availableKingdom = ((IEnumerable<Kingdom>)kingdoms).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => !DiplomacyManagerHelpers.IsPlayerKingdom(k) && !IsLeaderPrisonerOfPlayer(k)));
			if (availableKingdom != null)
			{
				int retryDelayDays = Math.Max(1, GetRandomStatementInterval() / 2);
				CampaignTime retryTime = CampaignTime.DaysFromNow((float)retryDelayDays);
				DiplomacyManager.Instance?.ScheduleNextStatement(diplomaticEvent.Id, availableKingdom, retryTime);
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] No statements generated (all kingdoms skipped). Scheduled retry for {availableKingdom.Name} in {retryDelayDays} days.");
			}
			else
			{
				DiplomacyLogger.Instance.Log("[STATEMENT_GEN] No statements generated and no available kingdoms found for retry.");
			}
		}
		DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Completed statement generation. Total statements: {statements.Count}");
		return statements;
	}

	public async Task<KingdomStatement> GenerateSingleStatement(DynamicEvent diplomaticEvent, Kingdom kingdom)
	{
		CleanupOldAndInvalidProposals();
		try
		{
			DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Generating single statement for {kingdom.Name}");
			if (DiplomacyManagerHelpers.IsPlayerKingdom(kingdom))
			{
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Skipping AI generation for player kingdom {kingdom.Name}. Player must respond via UI.");
				return null;
			}
			if (kingdom.Leader == null)
			{
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Skipping {kingdom.Name} - kingdom has no leader (Leader=NULL). Cannot generate diplomatic statements without a leader.");
				return null;
			}
			if (IsLeaderPrisonerOfPlayer(kingdom))
			{
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Skipping {kingdom.Name} - leader {kingdom.Leader.Name} is prisoner of player. Cannot generate diplomatic statements while imprisoned by player.");
				return null;
			}
			KingdomDiplomaticData kingdomData = GatherKingdomData(kingdom, diplomaticEvent);
			DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Gathered data for {kingdom.Name}");
			var (prompt, cachePrefixLength) = GenerateStatementPrompt(kingdom, kingdomData, diplomaticEvent);
			DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Generated prompt for {kingdom.Name} ({prompt.Length} chars)");
			if (IsLeaderPrisonerOfPlayer(kingdom))
			{
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Leader {kingdom.Leader.Name} became prisoner of player during generation, skipping AI request");
				return null;
			}
			KingdomStatement statement = await GetAIStatement(prompt, kingdom, diplomaticEvent, cachePrefixLength);
			if (statement != null)
			{
				if (IsLeaderPrisonerOfPlayer(kingdom))
				{
					DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Leader {kingdom.Leader.Name} became prisoner of player after AI response, discarding statement");
					return null;
				}
				if (!diplomaticEvent.KingdomStatements.Contains(statement))
				{
					diplomaticEvent.KingdomStatements.Add(statement);
					string targetsStr = ((statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any()) ? string.Join(",", statement.TargetKingdomIds) : (statement.TargetKingdomId ?? "none"));
					string actionsStr = ((statement.Actions != null && statement.Actions.Any()) ? string.Join(",", statement.Actions) : statement.Action.ToString());
					DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Temporarily added statement to event for visibility: {kingdom.Name} -> {targetsStr}, action={actionsStr}");
				}
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Generated statement for {kingdom.Name}: {statement.Action}");
				ShowKingdomStatementToPlayer(kingdom, statement, diplomaticEvent);
			}
			else
			{
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Empty AI response for {kingdom.Name} - scheduling retry in 2 days");
				diplomaticEvent.SetKingdomStatementRetryDelay(((MBObjectBase)kingdom).StringId, 2);
				statement = new KingdomStatement
				{
					KingdomId = ((MBObjectBase)kingdom).StringId,
					StatementText = "[Waiting for AI response - retry scheduled]",
					Action = DiplomaticAction.None,
					TargetKingdomId = null,
					Reason = "AI service temporarily unavailable",
					Timestamp = CampaignTime.Now,
					EventId = diplomaticEvent.Id
				};
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Created placeholder statement for {kingdom.Name} with retry delay");
			}
			return statement;
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] ERROR generating statement for {kingdom.Name}: {ex2.Message}");
			DiplomacyLogger.Instance.LogError("KingdomStatementGenerator.GenerateSingleStatement", $"Failed to generate statement for {kingdom.Name}", ex2);
			return null;
		}
	}

	private int GetRandomStatementInterval()
	{
		Random random = new Random();
		int statementGenerationIntervalDays = GlobalSettings<ModSettings>.Instance.StatementGenerationIntervalDays;
		return random.Next(1, statementGenerationIntervalDays + 1);
	}

	private bool IsLeaderPrisonerOfPlayer(Kingdom kingdom)
	{
		Hero leader = kingdom.Leader;
		if (leader == null || !leader.IsPrisoner)
		{
			return false;
		}
		PartyBase partyBelongedToAsPrisoner = leader.PartyBelongedToAsPrisoner;
		if (partyBelongedToAsPrisoner != null && partyBelongedToAsPrisoner == PartyBase.MainParty)
		{
			return true;
		}
		return false;
	}

	private KingdomDiplomaticData GatherKingdomData(Kingdom kingdom, DynamicEvent diplomaticEvent)
	{
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		KingdomDiplomaticData obj = new KingdomDiplomaticData
		{
			KingdomName = ((object)kingdom.Name).ToString(),
			KingdomId = ((MBObjectBase)kingdom).StringId
		};
		Hero leader = kingdom.Leader;
		obj.LeaderName = ((leader != null) ? ((object)leader.Name).ToString() : null) ?? "Unknown";
		KingdomDiplomaticData kingdomDiplomaticData = obj;
		WarStatisticsTracker warTracker = _diplomacyManager.GetWarTracker();
		KingdomWarStats kingdomStats = warTracker.GetKingdomStats(kingdom);
		if (kingdomStats != null)
		{
			kingdomDiplomaticData.CurrentTroops = kingdomStats.CurrentTroops;
			kingdomDiplomaticData.TotalCasualties = kingdomStats.TotalCasualties;
			kingdomDiplomaticData.PreviousCasualties = kingdomStats.PreviousCasualties;
			kingdomDiplomaticData.WarFatigue = kingdomStats.WarFatigue;
			kingdomDiplomaticData.DaysAtWar = kingdomStats.DaysAtWar;
			kingdomDiplomaticData.CurrentSettlements = kingdomStats.CurrentSettlements;
			kingdomDiplomaticData.InitialSettlements = kingdomStats.InitialSettlements;
		}
		WarFatigueSystem fatigueSystem = _diplomacyManager.GetFatigueSystem();
		kingdomDiplomaticData.WarFatigueDescription = fatigueSystem.GetWarFatigueDescription(kingdom);
		kingdomDiplomaticData.PeaceDesire = fatigueSystem.CalculatePeaceDesire(kingdom);
		kingdomDiplomaticData.ReadinessLevel = fatigueSystem.GetReadinessLevel(kingdom);
		AllianceSystem allianceSystem = _diplomacyManager.GetAllianceSystem();
		kingdomDiplomaticData.Allies = (from k in allianceSystem.GetAllies(kingdom)
			select ((object)k.Name).ToString()).ToList();
		kingdomDiplomaticData.AllianceInfo = allianceSystem.GetAllianceInfoForAI(kingdom);
		kingdomDiplomaticData.CurrentWars = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)k)).Select(delegate(Kingdom k)
		{
			int warDuration = GetWarDuration(kingdom, k);
			string text = "";
			if (warTracker != null)
			{
				DiplomaticReason diplomaticReason = warTracker.GetDiplomaticReason(kingdom, k, "war");
				if (diplomaticReason != null && !string.IsNullOrEmpty(diplomaticReason.Reason))
				{
					text = " (" + diplomaticReason.Reason + ")";
				}
			}
			return $"{k.Name} (string_id:{((MBObjectBase)k).StringId}), {warDuration} days of war{text}";
		}).ToList();
		kingdomDiplomaticData.Relations = new Dictionary<string, int>();
		if (diplomaticEvent.ParticipatingKingdoms != null)
		{
			foreach (string otherKingdomId in diplomaticEvent.ParticipatingKingdoms)
			{
				if (otherKingdomId == ((MBObjectBase)kingdom).StringId)
				{
					continue;
				}
				Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == otherKingdomId && !k.IsEliminated));
				if (val != null)
				{
					Hero leader2 = kingdom.Leader;
					Hero leader3 = val.Leader;
					int value = 0;
					if (leader2 != null && leader3 != null)
					{
						value = leader2.GetRelation(leader3);
					}
					kingdomDiplomaticData.Relations[((object)val.Name).ToString()] = value;
				}
			}
		}
		CampaignTime now = CampaignTime.Now;
		float num = (float)(now).ToDays;
		kingdomDiplomaticData.PreviousStatements = diplomaticEvent.KingdomStatements.OrderBy((KingdomStatement s) => s.Timestamp).Select(delegate(KingdomStatement s)
		{
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == s.KingdomId));
			string text;
			string text2;
			if (val2 == null)
			{
				text = s.KingdomId;
				text2 = "Unknown";
			}
			else if (val2.IsEliminated)
			{
				text = $"{val2.Name} [Destroyed]";
				Hero leader4 = val2.Leader;
				text2 = ((leader4 != null) ? ((object)leader4.Name).ToString() : null) ?? "[Destroyed Kingdom]";
			}
			else
			{
				text = ((object)val2.Name).ToString();
				Hero leader5 = val2.Leader;
				text2 = ((leader5 != null) ? ((object)leader5.Name).ToString() : null) ?? "Unknown";
			}
			int num2 = 0;
			_ = CampaignTime.Now;
			if (true)
			{
				CampaignTime val3 = CampaignTime.Now;
				double toDays = (val3).ToDays;
				val3 = s.Timestamp;
				num2 = Math.Max(0, (int)(toDays - (val3).ToDays));
			}
			return $"{text} (string_id:{s.KingdomId}), {text2}: {s.StatementText} ({num2} days ago)";
		}).ToList();
		DiplomacyLogger.Instance.Log($"[PrepareStatementData] Event {diplomaticEvent.Id}: Total statements = {diplomaticEvent.KingdomStatements.Count}, PreviousStatements prepared = {kingdomDiplomaticData.PreviousStatements.Count}");
		if (diplomaticEvent.KingdomStatements.Any())
		{
			foreach (KingdomStatement kingdomStatement in diplomaticEvent.KingdomStatements)
			{
				DiplomacyLogger.Instance.Log("[PrepareStatementData] Statement from " + kingdomStatement.KingdomId + ": " + kingdomStatement.StatementText?.Substring(0, Math.Min(50, kingdomStatement.StatementText?.Length ?? 0)) + "...");
			}
		}
		try
		{
			List<DynamicEvent> list = DynamicEventsManager.Instance?.GetActiveEvents();
			if (list != null && list.Any())
			{
				kingdomDiplomaticData.RecentDynamicEvents = list.OrderByDescending((DynamicEvent e) => e.CreationCampaignDays).Take(5).Select(delegate(DynamicEvent e)
				{
					//IL_0003: Unknown result type (might be due to invalid IL or missing references)
					//IL_0010: Unknown result type (might be due to invalid IL or missing references)
					//IL_0015: Unknown result type (might be due to invalid IL or missing references)
					int num2 = 0;
					_ = CampaignTime.Now;
					if (true)
					{
						CampaignTime now2 = CampaignTime.Now;
						num2 = Math.Max(0, (int)((now2).ToDays - (double)e.CreationCampaignDays));
					}
					string text = (string.IsNullOrWhiteSpace(e.Title) ? e.Type : e.Title);
					string text2 = e.Description ?? string.Empty;
					if (text2.Length > 180)
					{
						text2 = text2.Substring(0, 180) + "...";
					}
					return $"{text} ({e.Type}, {num2} days ago): {text2}";
				})
					.ToList();
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[PrepareStatementData] Failed to collect recent dynamic events: " + ex.Message);
		}
		return kingdomDiplomaticData;
	}

	private string GenerateInternalThoughtsSection()
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacyInternalThoughts)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("### CRITICAL: Internal Thought Process (REQUIRED BEFORE CRAFTING STATEMENT) ###");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**PRIVATE reasoning process for authentic diplomatic statements.**");
		stringBuilder.AppendLine();
		string value = WorldInfoManager.Instance?.ReadKingdomStatementRules();
		bool flag = !string.IsNullOrEmpty(value);
		if (flag)
		{
			stringBuilder.AppendLine("**OVERRIDE RULES (ABSOLUTE PRIORITY - CHECK IN STEP 7)**");
			stringBuilder.AppendLine("The player has set custom statement rules that OVERRIDE all other instructions:");
			stringBuilder.AppendLine(value);
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("**STEP 0: VERIFY FACTS (MANDATORY)**");
		stringBuilder.AppendLine("Before reasoning, verify CURRENT STATE of your kingdom:");
		stringBuilder.AppendLine("- Wars/Alliances/War fatigue/Military strength/Trade/Tribute/Reparations");
		stringBuilder.AppendLine("- **CRITICAL:** TECHNICAL SECTIONS = REALITY. HISTORY = WHAT WAS SAID (may have failed).");
		stringBuilder.AppendLine("- If history says \"proposed peace\" but technical data shows AT WAR → proposal was REJECTED or is PENDING.");
		stringBuilder.AppendLine("- Format: internal_thoughts starts with 'FACT CHECK:' + verified facts from TECHNICAL SECTIONS.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 1: PENDING PROPOSALS (HIGHEST PRIORITY)**");
		stringBuilder.AppendLine("Check 'PENDING PROPOSALS DIRECTED AT YOU'.");
		stringBuilder.AppendLine("- If present → MUST respond (accept/reject). Use exact string_id. For multiple → index-based pairing.");
		stringBuilder.AppendLine("- If none → can make new proposals or general statements.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 2: SITUATION + CHARACTER + RELATIONS (COMBINED)**");
		stringBuilder.AppendLine("- Situation: War fatigue? War progress? (winning/losing/stalemate) Casualties? Settlements? Helping allies? Economy? Stability?");
		stringBuilder.AppendLine("- Character: Leader personality? (from 'Character Briefing') Traits? (proud/cautious/aggressive/diplomatic) Emotional state? Influence on diplomacy? Tone? (stern/proud/diplomatic/arrogant/weary)");
		stringBuilder.AppendLine("- Relations: With other kingdoms? (from 'RELATIONS') Impact on negotiations? (hostile = harder) Wars among others? Diplomatic atmosphere? (tense/hopeful/desperate) Connection to kingdom interests?");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 3: NEGOTIATION HISTORY**");
		stringBuilder.AppendLine("Check 'RECENT HISTORY' and 'YOUR PREVIOUS STATEMENTS'.");
		stringBuilder.AppendLine("- What did you say? (DO NOT repeat same threats/demands) What did others say? (respond) Progress or just repetition?");
		stringBuilder.AppendLine("- **CRITICAL:** New statement MUST DIFFER from previous ones. Develop situation with new content.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 4: DIPLOMATIC ACTIONS**");
		stringBuilder.AppendLine("- What actions match current situation and kingdom interests?");
		stringBuilder.AppendLine("- What does your diplomatic state require? (war/peace/alliance/neutrality)");
		stringBuilder.AppendLine("- What opportunities does the current moment offer? (trade, territory, tribute, reparations, other agreements)");
		stringBuilder.AppendLine("- How do your personality and situation influence action choices?");
		stringBuilder.AppendLine("- **TERRITORY DEMANDS — GEOGRAPHIC REALITY:** Check the [proximity tag] of each settlement in WAR-RELEVANT SETTLEMENTS.");
		stringBuilder.AppendLine("  - BORDER/NEAR = realistic demands, strategically valuable and defensible");
		stringBuilder.AppendLine("  - MODERATE = possible but harder to justify, less defensible");
		stringBuilder.AppendLine("  - FAR = unrealistic — deep inside enemy territory, impossible to hold, will prolong war for nothing");
		stringBuilder.AppendLine("  - DEEP_BEHIND = was captured deep behind lines — flag for context, shows aggressive expansion");
		stringBuilder.AppendLine("  - **Prioritize BORDER → NEAR → MODERATE. Do NOT demand FAR settlements — no kingdom demands territory it cannot hold.**");
		stringBuilder.AppendLine("  - Exception: if settlement was RECENTLY YOURS (see ownership history), reclaiming it is justified regardless of distance.");
		stringBuilder.AppendLine("- **CRITICAL:** Actions must match current diplomatic state. Use exact string_id for target_kingdom_id (\"empire\", NOT \"Northern Empire\"). For multiple actions → index-based pairing.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 5: PLAN STATEMENT**");
		stringBuilder.AppendLine("- Main message? (response/new proposal/general position) Tone? (formal/aggressive/diplomatic/weary/proud)");
		stringBuilder.AppendLine("- Develops situation? (not repetition) Text = actions? (if proposing peace → mention peace) Length? (check limits) Reflects situation? (fatigue/strength)");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 6: VERIFY ACTION VALIDITY**");
		stringBuilder.AppendLine("- Actions valid? propose_peace → AT WAR | declare_war → NOT at war | accept/reject → pending proposals exist | break_alliance → ALLIED | propose_alliance → NOT allied | territory → available settlements");
		stringBuilder.AppendLine("- All parameters? (settlement_id for territory, amounts for tribute/reparations) **CRITICAL:** expel_clan → target_clan_id (NOT target_kingdom_id).");
		stringBuilder.AppendLine();
		if (flag)
		{
			stringBuilder.AppendLine("**STEP 7: VERIFY OVERRIDE RULES COMPLIANCE (MANDATORY)**");
			stringBuilder.AppendLine("- Does statement violate ANY rule? Do actions comply with restrictions? Does tone comply with rules?");
			stringBuilder.AppendLine("- If violated → MUST change statement. ABSOLUTE PRIORITY over character/logic/diplomacy.");
			stringBuilder.AppendLine("- In internal_thoughts: acknowledge violation → explain adjustment → modify statement.");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("**STEP 8: OUTPUT STRUCTURE**");
		stringBuilder.AppendLine("JSON MUST include:");
		stringBuilder.AppendLine("- `internal_thoughts` (500-1500 characters): PRIVATE reasoning from all steps above" + (flag ? " + rule compliance check" : "") + ".");
		if (flag)
		{
			stringBuilder.AppendLine("  - Example: \"FACT CHECK: At war with Vlandia, war fatigue 75%. REASONING: Want to propose peace, but Override Rules forbid it. Will make defiant statement instead.\"");
		}
		stringBuilder.AppendLine("- Other fields: statement, action, target_kingdom_id, reason, etc.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**CRITICAL RULES:**");
		stringBuilder.AppendLine("- **MANDATORY:** internal_thoughts starts with 'FACT CHECK:' + facts from TECHNICAL SECTIONS");
		stringBuilder.AppendLine("- **FORBIDDEN:** Do NOT confuse ATTEMPTED actions with ACTUAL results. TECHNICAL SECTIONS = truth");
		stringBuilder.AppendLine("- **FORBIDDEN:** Do NOT repeat previous statements - develop with new content");
		stringBuilder.AppendLine("- **MANDATORY:** If pending proposals exist → MUST respond (cannot ignore)");
		stringBuilder.AppendLine("- internal_thoughts = PRIVATE (helps reasoning, players don't see)");
		stringBuilder.AppendLine("- Statement = internal thoughts + verified facts from TECHNICAL SECTIONS");
		stringBuilder.AppendLine("- Use exact string_id in JSON (\"empire\", NOT \"Northern Empire\", NOT \"string_id:empire\")");
		stringBuilder.AppendLine("- For multiple actions → index-based pairing (action[0] → target[0])");
		if (flag)
		{
			stringBuilder.AppendLine("- **MANDATORY:** Statement MUST comply with Override Rules. If conflict → Rules WIN. Include compliance check in internal_thoughts");
		}
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}

	private (string prompt, int staticPrefixLength) GenerateStatementPrompt(Kingdom kingdom, KingdomDiplomaticData data, DynamicEvent diplomaticEvent)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_10da: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1100: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1500: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b30: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b35: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c32: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1756: Unknown result type (might be due to invalid IL or missing references)
		//IL_175b: Unknown result type (might be due to invalid IL or missing references)
		//IL_176d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1779: Unknown result type (might be due to invalid IL or missing references)
		//IL_177e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1783: Unknown result type (might be due to invalid IL or missing references)
		//IL_223b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2240: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_190b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1917: Unknown result type (might be due to invalid IL or missing references)
		//IL_191c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1921: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d90: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c37: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c60: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c70: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c75: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c9f: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(GenerateInternalThoughtsSection());
		string text = MBTextManager.ActiveTextLanguage ?? "English";
		string text2 = WorldInfoManager.Instance.ReadWorldInfo();
		CampaignTime now = CampaignTime.Now;
		string seasonName = GetSeasonName((now).GetSeasonOfYear);
		stringBuilder.AppendLine("# DIPLOMATIC STATEMENT GENERATION");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("You are the official voice of a kingdom in Mount & Blade II: Bannerlord.");
		stringBuilder.AppendLine("Your task is to create an official diplomatic statement.");
		stringBuilder.AppendLine("Language: " + text);
		stringBuilder.AppendLine("World: " + text2);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### DATA INTERPRETATION RULES ###");
		stringBuilder.AppendLine("**CRITICAL UNDERSTANDING:**");
		stringBuilder.AppendLine("Throughout this prompt you will see TWO types of data:");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("1. **TECHNICAL SECTIONS** (marked with ###) - Current military stats, alliances, wars, settlements");
		stringBuilder.AppendLine("   - These show the ACTUAL CURRENT STATE of the world RIGHT NOW");
		stringBuilder.AppendLine("   - This is GROUND TRUTH - what HAS HAPPENED and EXISTS NOW");
		stringBuilder.AppendLine("   - Priority: HIGHEST - this data overrides any narrative or history");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("2. **HISTORICAL SECTIONS** (Recent History, Previous Statements) - What kingdoms have SAID");
		stringBuilder.AppendLine("   - These show what was DISCUSSED or PROPOSED in past");
		stringBuilder.AppendLine("   - Priority: CONTEXT ONLY - use to understand diplomatic flow");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**EXAMPLE OF CORRECT INTERPRETATION:**");
		stringBuilder.AppendLine("- Technical data says: \"Empire vs Vlandia: AT WAR\"");
		stringBuilder.AppendLine("- History says: \"Empire proposed peace to Vlandia 3 days ago\"");
		stringBuilder.AppendLine("- ✓ CORRECT: Peace was proposed but REJECTED or still PENDING (war continues)");
		stringBuilder.AppendLine("- ✗ WRONG: \"Peace was made\" (war status would show PEACE if accepted)");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## CORE RULES:");
		stringBuilder.AppendLine("**STYLE:** Speak as KINGDOM (not ruler). Formal diplomatic language, taking into account your character's personality and personal qualities/motives.");
		stringBuilder.AppendLine($"**LENGTH:** {GlobalSettings<ModSettings>.Instance.DiplomacyMinStatementLength}-{GlobalSettings<ModSettings>.Instance.DiplomacyMaxStatementLength} chars. Move situation forward with new developments.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## DIALOGUE DEVELOPMENT:");
		stringBuilder.AppendLine(" - DON'T repeat same threats/demands from previous statements, develop the situation, don't repeat the same thing in your statements");
		stringBuilder.AppendLine(" - REACT according to your character's personality and character.");
		stringBuilder.AppendLine(" - EVOLVE - lead the dialogue to something new, DON'T REPEAT YOURSELF");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## ACTIONS:");
		stringBuilder.AppendLine("**RULES:** Propose peace (if at war) | Declare war (if not at war, breaks ally) | Alliance (propose/accept/reject/break) | Alliance = support in wars");
		stringBuilder.AppendLine("**BASIC:** none, declare_war, propose_peace, accept/reject_peace, propose/accept/reject/break_alliance, expel_clan (needs target_clan_id)");
		stringBuilder.AppendLine("**EXTENDED:**");
		stringBuilder.AppendLine("  - Trade: propose_trade_agreement, accept_trade_agreement, reject_trade_agreement, end_trade_agreement");
		stringBuilder.AppendLine("  - Territory: demand_territory, transfer_territory, reject_territory (requires settlement_id)");
		stringBuilder.AppendLine("  - Tribute: demand_tribute, accept_tribute, reject_tribute (requires amount+days)");
		stringBuilder.AppendLine("  - Reparations: demand_reparations, accept_reparations, reject_reparations (requires amount)");
		stringBuilder.AppendLine("  - Quarantine: quarantine_settlement (requires settlement_id + quarantine_duration_days). Close OWN settlement with active disease for quarantine. AI parties cannot enter/leave. Only kingdom's own settlements with disease.");
		stringBuilder.AppendLine("**MULTIPLE ACTIONS:** Comma-separated: 'accept_peace,transfer_territory,demand_reparations'. Statement text MUST match actions. When using multiple actions with different target kingdoms, see 'Action-Target Pairing by Index' section in OUTPUT FORMAT.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## string_id USAGE (MANDATORY FOR ACTIONS):");
		stringBuilder.AppendLine("**YOU MUST use exact string_id values in your JSON response for ALL technical data references.**");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Throughout this prompt, data is formatted as: \"Name (string_id:value)\"");
		stringBuilder.AppendLine("- You see: \"Northern Empire (string_id:empire)\"");
		stringBuilder.AppendLine("- You use in JSON: \"empire\" (NOT \"string_id:empire\", NOT \"Northern Empire\")");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**EXAMPLES:**");
		stringBuilder.AppendLine("- \"Vlandia (string_id:vlandia)\" → use \"vlandia\" in target_kingdom_id");
		stringBuilder.AppendLine("- \"Battania (string_id:battania)\" → use \"battania\" in target_kingdom_id");
		stringBuilder.AppendLine("- \"Qalit (string_id:town_S1)\" → use \"town_S1\" in settlement_id");
		stringBuilder.AppendLine("- \"dey_Meroc clan (string_id:cs_empire_1)\" → use \"cs_empire_1\" in target_clan_id");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**CRITICAL:** Kingdom/settlement names in statement = human readable (\"Northern Empire\", \"Qalit\")");
		stringBuilder.AppendLine("**CRITICAL:** Kingdom/settlement IDs in JSON fields = string_id values ONLY (\"empire\", \"town_S1\")");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## OUTPUT FORMAT (STRICT JSON):");
		stringBuilder.AppendLine("{");
		if (GlobalSettings<ModSettings>.Instance.EnableDiplomacyInternalThoughts)
		{
			stringBuilder.AppendLine("  \"internal_thoughts\": \"Analyze kingdom situation, leader personality, decide action...\",");
		}
		stringBuilder.AppendLine("  \"statement\": \"Your diplomatic statement\",");
		stringBuilder.AppendLine("  \"action\": \"action1,action2,action3\",");
		stringBuilder.AppendLine("  \"target_kingdom_id\": \"kingdom_string_id\" or \"id1,id2,id3\", // Use lowercase string_id(s), comma-separated for multiple actions targeting different kingdoms, null for expel_clan");
		stringBuilder.AppendLine("  \"target_clan_id\": \"clan_string_id\", // REQUIRED for expel_clan");
		stringBuilder.AppendLine("  \"reason\": \"Brief explanation\", // REQUIRED if action is not 'none'");
		stringBuilder.AppendLine("  \"settlement_id\": \"settlement_string_id\", // For territory actions");
		stringBuilder.AppendLine("  \"daily_tribute_amount\": 0,");
		stringBuilder.AppendLine("  \"tribute_duration_days\": 0,");
		stringBuilder.AppendLine("  \"reparations_amount\": 0,");
		stringBuilder.AppendLine("  \"trade_agreement_duration_years\": 1.0,");
		stringBuilder.AppendLine("  \"quarantine_duration_days\": 0 // For quarantine_settlement: positive integer (days), minimum 1, auto-lifts after");
		stringBuilder.AppendLine("}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**CRITICAL: Action-Target Pairing by Index**");
		stringBuilder.AppendLine("When you specify multiple actions with multiple target kingdoms:");
		stringBuilder.AppendLine("- Actions are paired with target kingdoms BY INDEX (position in the list)");
		stringBuilder.AppendLine("- The first action corresponds to the first target_kingdom_id, second to second, etc.");
		stringBuilder.AppendLine("- Example: If you want to:");
		stringBuilder.AppendLine("  * accept_reparations from 'empire'");
		stringBuilder.AppendLine("  * accept_tribute from 'empire'");
		stringBuilder.AppendLine("  * accept_tribute from 'empire_w'");
		stringBuilder.AppendLine("  Then write: \"action\": \"accept_reparations,accept_tribute,accept_tribute\"");
		stringBuilder.AppendLine("  And: \"target_kingdom_id\": \"empire,empire,empire_w\"");
		stringBuilder.AppendLine("  This means: action[0] (accept_reparations) → target[0] (empire)");
		stringBuilder.AppendLine("              action[1] (accept_tribute) → target[1] (empire)");
		stringBuilder.AppendLine("              action[2] (accept_tribute) → target[2] (empire_w)");
		stringBuilder.AppendLine("- If the number of actions does NOT match the number of targets, the first target will be used for all actions (NOT RECOMMENDED)");
		stringBuilder.AppendLine();
		int length = stringBuilder.Length;
		stringBuilder.AppendLine("## === CURRENT GAME STATE (GROUND TRUTH) ===");
		stringBuilder.AppendLine("The sections below show ACTUAL CURRENT STATE of your kingdom and the world.");
		stringBuilder.AppendLine("This is NOT narrative - these are FACTS about the current moment.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## CURRENT SITUATION:");
		stringBuilder.AppendLine($"Current Time: Year {(now).GetYear}, {seasonName}");
		stringBuilder.AppendLine();
		Hero leader = kingdom.Leader;
		if (leader != null)
		{
			stringBuilder.AppendLine("### Character Briefing ###");
			stringBuilder.AppendLine();
			string text3 = (leader.IsKingdomLeader ? "ruler" : "leader");
			string text4 = (leader.IsFemale ? "female" : "male");
			CultureObject culture = leader.Culture;
			string text5 = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown";
			stringBuilder.AppendLine($"Name: {leader.Name}, {(int)leader.Age}-year-old {text4} {text3} of {kingdom.Name}");
			stringBuilder.AppendLine("Culture: " + text5);
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("### RECENT DEATHS OF IMPORTANT FIGURES (CRITICAL INFORMATION) ###");
			stringBuilder.AppendLine("**IMPORTANT: Kingdom leader deaths cause succession crises and major political shifts. These events significantly impact diplomatic relations and should be considered when making statements.**");
			List<DeathInfo> recentImportantDeaths = GetRecentImportantDeaths(20);
			if (recentImportantDeaths.Any())
			{
				foreach (DeathInfo item2 in recentImportantDeaths)
				{
					string text6 = ((item2.Title == "Kingdom Ruler") ? " [CRITICAL - SUCCESSION CRISIS]" : "");
					stringBuilder.AppendLine("- " + item2.HeroName + " (string_id: \"" + item2.HeroStringId + "\") - " + item2.Title + text6);
					stringBuilder.AppendLine("  Death cause: " + item2.DeathCause);
					stringBuilder.AppendLine("  Killer: " + item2.KillerName + " (string_id: \"" + item2.KillerStringId + "\")");
					stringBuilder.AppendLine("  Kingdom: " + item2.KingdomName + " (string_id: \"" + item2.KingdomStringId + "\")");
					stringBuilder.AppendLine($"  Days ago: {item2.DaysAgo}");
				}
			}
			else
			{
				stringBuilder.AppendLine("- No recent deaths of important figures");
			}
			stringBuilder.AppendLine();
			NPCContext npcContext = AIInfluenceBehavior.Instance?.GetNPCContextByStringId(((MBObjectBase)leader).StringId);
			if (npcContext != null && !string.IsNullOrEmpty(npcContext.AIGeneratedPersonality))
			{
				string aIGeneratedPersonality = npcContext.AIGeneratedPersonality;
				stringBuilder.AppendLine("Character: " + aIGeneratedPersonality);
				if (!string.IsNullOrEmpty(npcContext.AIGeneratedSpeechQuirks))
				{
					stringBuilder.AppendLine("Speech Style: " + npcContext.AIGeneratedSpeechQuirks);
				}
				if (!string.IsNullOrEmpty(npcContext.AIGeneratedBackstory))
				{
					string text7 = npcContext.AIGeneratedBackstory.Replace("\n", " ").Trim();
					stringBuilder.AppendLine("Personal History: " + text7);
					stringBuilder.AppendLine("NOTE: This is your past - your origins, childhood, formative experiences. Use this to inform your diplomatic values and motivations.");
				}
				stringBuilder.AppendLine("NOTE: This is the leader's character - let it guide the diplomatic tone and values of the kingdom's statement.");
			}
			else
			{
				string aIGeneratedPersonality = PromptGenerator.GetPersonalityDescription(leader);
				stringBuilder.AppendLine("Diplomatic Style: " + aIGeneratedPersonality);
			}
			if (npcContext != null)
			{
				if (npcContext.EmotionalState != null)
				{
					string text8 = npcContext.EmotionalState.Mood ?? "neutral";
					stringBuilder.AppendLine("Emotional State: " + text8);
				}
				else
				{
					stringBuilder.AppendLine("Emotional State: neutral");
				}
				if (!string.IsNullOrEmpty(npcContext.CharacterDescription))
				{
					stringBuilder.AppendLine("Character Description (additional): " + npcContext.CharacterDescription);
				}
				stringBuilder.AppendLine($"Ruling Clan Treasury: {leader.Gold} denars (clan funds used for kingdom expenses)");
				string relativesInfo = PromptGenerator.GetRelativesInfo(leader, npcContext);
				if (relativesInfo != null && relativesInfo != "none")
				{
					stringBuilder.AppendLine();
					stringBuilder.AppendLine("### FAMILY RELATIONS ###");
					stringBuilder.AppendLine("**CRITICAL: Family ties significantly influence diplomatic decisions. Consider family members' safety, status, and relationships with other kingdoms when making statements.**");
					stringBuilder.AppendLine("Relatives: " + relativesInfo);
					stringBuilder.AppendLine();
				}
				stringBuilder.AppendLine();
				if (npcContext.KnownInfo != null && npcContext.KnownInfo.Any())
				{
					List<string> list = (from i in WorldInfoManager.InformationManager.Instance.GetInfo()
						where npcContext.KnownInfo.Contains(i.Id)
						select i.Description.Replace("{character}", ((object)leader.Name).ToString()) + " (category: " + i.Category + ")").ToList();
					if (list.Any())
					{
						stringBuilder.AppendLine("General Info: " + string.Join("; ", list) + ".");
					}
				}
				if (npcContext.KnownSecrets != null && npcContext.KnownSecrets.Any())
				{
					List<string> list2 = (from s in WorldInfoManager.WorldSecretsManager.Instance.GetSecrets()
						where npcContext.KnownSecrets.Contains(s.Id)
						select s.Description + " (access: " + s.AccessLevel + ")").ToList();
					if (list2.Any())
					{
						stringBuilder.AppendLine("Secrets: " + string.Join("; ", list2) + ".");
					}
				}
				AllianceSystem allianceSystem = _diplomacyManager.GetAllianceSystem();
				WarStatisticsTracker warTracker = _diplomacyManager.GetWarTracker();
				foreach (string allyName in data.Allies)
				{
					Kingdom allyKingdom = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((object)val20.Name).ToString() == allyName && !val20.IsEliminated));
					if (allyKingdom == null)
					{
						continue;
					}
					stringBuilder.AppendLine("Alliance with " + allyName + " (string_id:" + ((MBObjectBase)allyKingdom).StringId + "):");
					DiplomaticReason diplomaticReason = warTracker.GetDiplomaticReason(kingdom, allyKingdom, "alliance");
					if (diplomaticReason != null && !string.IsNullOrEmpty(diplomaticReason.Reason))
					{
						stringBuilder.AppendLine("  - Original alliance reason: " + diplomaticReason.Reason);
					}
					List<Kingdom> source = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom val20) => !val20.IsEliminated && val20 != allyKingdom && FactionManager.IsAtWarAgainstFaction((IFaction)(object)allyKingdom, (IFaction)(object)val20)).ToList();
					if (source.Any())
					{
						stringBuilder.AppendLine("  - " + allyName + " (string_id:" + ((MBObjectBase)allyKingdom).StringId + ") is AT WAR with: " + string.Join(", ", source.Select((Kingdom w) => $"{w.Name} (string_id:{((MBObjectBase)w).StringId})")));
						if (source.Any((Kingdom val20) => FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)val20)))
						{
							stringBuilder.AppendLine("  - You are HELPING your ally by also fighting their enemies");
						}
						else
						{
							stringBuilder.AppendLine("  - CRITICAL: You are NOT helping your ally in their war!");
							stringBuilder.AppendLine("  - This may damage your alliance and require explanation");
							stringBuilder.AppendLine("  - Consider declaring war on your ally's enemies or providing justification");
						}
					}
					else
					{
						stringBuilder.AppendLine("  - " + allyName + " (string_id:" + ((MBObjectBase)allyKingdom).StringId + ") is currently at peace");
					}
					stringBuilder.AppendLine();
				}
			}
			TradeAgreementSystem tradeAgreementSystem = _diplomacyManager.GetTradeAgreementSystem();
			TributeSystem tributeSystem = _diplomacyManager.GetTributeSystem();
			ReparationsSystem reparationsSystem = _diplomacyManager.GetReparationsSystem();
			TerritoryTransferSystem territorySystem = _diplomacyManager.GetTerritoryTransferSystem();
			List<TradeAgreementInfo> tradeAgreementsForKingdom = tradeAgreementSystem.GetTradeAgreementsForKingdom(kingdom);
			CampaignTime val2;
			if (tradeAgreementsForKingdom.Any())
			{
				stringBuilder.AppendLine("### TRADE AGREEMENTS ###");
				foreach (TradeAgreementInfo item3 in tradeAgreementsForKingdom)
				{
					string partnerId = ((item3.Kingdom1Id == ((MBObjectBase)kingdom).StringId) ? item3.Kingdom2Id : item3.Kingdom1Id);
					Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == partnerId && !val20.IsEliminated));
					if (val != null)
					{
						val2 = item3.EndTime;
						float num = (val2).RemainingDaysFromNow / (float)CampaignTime.DaysInYear;
						stringBuilder.AppendLine($"- Trade agreement with {val.Name} (string_id:{((MBObjectBase)val).StringId}), expires in {num:F1} years");
					}
				}
				stringBuilder.AppendLine();
			}
			else
			{
				stringBuilder.AppendLine("### TRADE AGREEMENTS ###");
				stringBuilder.AppendLine("No active trade agreements.");
				stringBuilder.AppendLine();
			}
			ModSettings instance = GlobalSettings<ModSettings>.Instance;
			if (instance != null && instance.EnableDiseaseSystem)
			{
				DiseaseManager diseaseManager = DiseaseManager.Instance;
				if (diseaseManager != null)
				{
					List<Settlement> source2 = ((IEnumerable<Settlement>)Settlement.All).Where(delegate(Settlement s)
					{
						int result;
						if (s.IsTown || s.IsCastle)
						{
							Clan ownerClan2 = s.OwnerClan;
							result = ((((ownerClan2 != null) ? ownerClan2.Kingdom : null) == kingdom) ? 1 : 0);
						}
						else
						{
							result = 0;
						}
						return (byte)result != 0;
					}).ToList();
					List<Settlement> list3 = source2.Where((Settlement s) => diseaseManager.SettlementHasDisease(s)).ToList();
					if (list3.Any())
					{
						stringBuilder.AppendLine("### DISEASE STATUS IN YOUR SETTLEMENTS ###");
						stringBuilder.AppendLine("**You can use quarantine_settlement action to close diseased settlements. Requires settlement_id and quarantine_duration_days (positive integer, minimum 1 day; quarantine auto-lifts). You decide the duration.**");
						stringBuilder.AppendLine("**QUARANTINE DURATION GUIDANCE:** To be effective, quarantine_duration_days should be at least equal to the disease's 'Days remaining'. Setting it shorter than the disease duration means the quarantine will lift while the disease is still active. For severe diseases (severity 4-5) consider adding extra days as buffer.");
						foreach (Settlement item4 in list3)
						{
							List<Disease> allDiseasesForSettlement = diseaseManager.GetAllDiseasesForSettlement(item4);
							string arg;
							if (diseaseManager.IsSettlementUnderQuarantine(item4))
							{
								int num2 = 0;
								foreach (Disease item5 in allDiseasesForSettlement)
								{
									if (!item5.IsQuarantined || !item5.QuarantineEndDays.HasValue)
									{
										continue;
									}
									_ = CampaignTime.Now;
									if (true)
									{
										float value = item5.QuarantineEndDays.Value;
										val2 = CampaignTime.Now;
										int num3 = (int)(value - (float)(val2).ToDays);
										if (num3 > num2)
										{
											num2 = num3;
										}
									}
								}
								arg = ((num2 > 0) ? $" [QUARANTINED, {num2} days remaining — if you quarantine again, duration will be EXTENDED by adding new days to remaining]" : " [QUARANTINED, indefinite]");
							}
							else
							{
								arg = " [NOT QUARANTINED]";
							}
							stringBuilder.AppendLine($"- {item4.Name} (string_id:{((MBObjectBase)item4).StringId}){arg}");
							foreach (Disease item6 in allDiseasesForSettlement)
							{
								int val3 = item6.DurationDays - item6.DaysSinceCreation;
								int num4 = Math.Max(0, val3);
								stringBuilder.AppendLine($"  Disease: {item6.Name}, Severity: {item6.Severity}/5, Days active: {item6.DaysSinceCreation}, Days remaining: {num4} → recommended quarantine_duration_days: at least {num4}");
							}
						}
						stringBuilder.AppendLine();
					}
				}
			}
			stringBuilder.AppendLine("### CLANS IN YOUR KINGDOM ###");
			bool flag = false;
			foreach (Clan item7 in (List<Clan>)(object)kingdom.Clans)
			{
				if (item7 != kingdom.RulingClan && !item7.IsEliminated)
				{
					flag = true;
					int relation = kingdom.Leader.GetRelation(item7.Leader);
					string relationDescription = GetRelationDescription(relation);
					stringBuilder.AppendLine($"- Name: {item7.Name} (string_id:{((MBObjectBase)item7).StringId})");
					stringBuilder.AppendLine($"  Leader: {item7.Leader.Name}, Relation: {relation} ({relationDescription})");
					stringBuilder.AppendLine($"  Influence: {item7.Influence:F0}, Strength: {item7.CurrentTotalStrength:F0}");
					stringBuilder.AppendLine($"  Tier: {item7.Tier}, Members: {((List<Hero>)(object)item7.Heroes).Count}");
					stringBuilder.AppendLine();
				}
			}
			if (!flag)
			{
				stringBuilder.AppendLine("No other clans in kingdom.");
				stringBuilder.AppendLine();
			}
			List<TributeAgreement> tributesPaidBy = tributeSystem.GetTributesPaidBy(kingdom);
			List<TributeAgreement> tributesReceivedBy = tributeSystem.GetTributesReceivedBy(kingdom);
			List<TributeRecord> source3 = tributeSystem.GetTributeHistory(kingdom, 20).Where(delegate(TributeRecord r)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime endTime = r.EndTime;
				return (endTime).ElapsedDaysUntilNow <= 90f;
			}).ToList();
			List<TributeRecord> source4 = source3.Where((TributeRecord r) => r.ReceiverKingdomId == ((MBObjectBase)kingdom).StringId).ToList();
			List<TributeRecord> source5 = source3.Where((TributeRecord r) => r.PayerKingdomId == ((MBObjectBase)kingdom).StringId).ToList();
			if (tributesPaidBy.Any() || tributesReceivedBy.Any() || source4.Any() || source5.Any())
			{
				stringBuilder.AppendLine("### TRIBUTE AGREEMENTS ###");
				foreach (TributeAgreement tribute in tributesPaidBy)
				{
					Kingdom val4 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == tribute.ReceiverKingdomId && !val20.IsEliminated));
					if (val4 != null)
					{
						val2 = tribute.EndTime;
						float remainingDaysFromNow = (val2).RemainingDaysFromNow;
						stringBuilder.AppendLine($"- PAYING {tribute.DailyAmount} gold/day to {val4.Name} (string_id:{((MBObjectBase)val4).StringId}) for {remainingDaysFromNow:F0} more days (total paid: {tribute.TotalPaid})");
						stringBuilder.AppendLine("  Reason: " + tribute.Reason);
					}
				}
				foreach (TributeAgreement tribute2 in tributesReceivedBy)
				{
					Kingdom val5 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == tribute2.PayerKingdomId && !val20.IsEliminated));
					if (val5 != null)
					{
						val2 = tribute2.EndTime;
						float remainingDaysFromNow2 = (val2).RemainingDaysFromNow;
						stringBuilder.AppendLine($"- RECEIVING {tribute2.DailyAmount} gold/day from {val5.Name} (string_id:{((MBObjectBase)val5).StringId}) for {remainingDaysFromNow2:F0} more days (total received: {tribute2.TotalPaid})");
						stringBuilder.AppendLine("  Reason: " + tribute2.Reason);
					}
				}
				if (source4.Any())
				{
					if (tributesPaidBy.Any() || tributesReceivedBy.Any())
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.AppendLine("**RECENTLY COMPLETED TRIBUTES (ALREADY RECEIVED):**");
					foreach (TributeRecord tribute3 in source4.OrderByDescending(delegate(TributeRecord r)
					{
						//IL_0001: Unknown result type (might be due to invalid IL or missing references)
						//IL_0006: Unknown result type (might be due to invalid IL or missing references)
						CampaignTime endTime = r.EndTime;
						return (endTime).ElapsedDaysUntilNow;
					}))
					{
						Kingdom val6 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == tribute3.PayerKingdomId && !val20.IsEliminated));
						if (val6 != null)
						{
							val2 = tribute3.EndTime;
							float elapsedDaysUntilNow = (val2).ElapsedDaysUntilNow;
							val2 = tribute3.EndTime - tribute3.StartTime;
							float num5 = (float)(val2).ToDays;
							stringBuilder.AppendLine($"- {val6.Name} (string_id:{((MBObjectBase)val6).StringId}) ALREADY PAID tribute to you ({elapsedDaysUntilNow:F0} days ago, completed)");
							stringBuilder.AppendLine($"  Amount: {tribute3.DailyAmount} gold/day, Total paid: {tribute3.TotalPaid} gold, Duration: {num5:F0} days");
							stringBuilder.AppendLine("  Reason: " + tribute3.Reason);
							stringBuilder.AppendLine("  **IMPORTANT: This tribute has been COMPLETED. Consider this when making diplomatic decisions.**");
						}
					}
				}
				if (source5.Any())
				{
					if (tributesPaidBy.Any() || tributesReceivedBy.Any() || source4.Any())
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.AppendLine("**RECENTLY COMPLETED TRIBUTES (ALREADY PAID BY YOU):**");
					foreach (TributeRecord tribute4 in source5.OrderByDescending(delegate(TributeRecord r)
					{
						//IL_0001: Unknown result type (might be due to invalid IL or missing references)
						//IL_0006: Unknown result type (might be due to invalid IL or missing references)
						CampaignTime endTime = r.EndTime;
						return (endTime).ElapsedDaysUntilNow;
					}))
					{
						Kingdom val7 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == tribute4.ReceiverKingdomId && !val20.IsEliminated));
						if (val7 != null)
						{
							val2 = tribute4.EndTime;
							float elapsedDaysUntilNow2 = (val2).ElapsedDaysUntilNow;
							val2 = tribute4.EndTime - tribute4.StartTime;
							float num6 = (float)(val2).ToDays;
							stringBuilder.AppendLine($"- You ALREADY PAID tribute to {val7.Name} (string_id:{((MBObjectBase)val7).StringId}) ({elapsedDaysUntilNow2:F0} days ago, completed)");
							stringBuilder.AppendLine($"  Amount: {tribute4.DailyAmount} gold/day, Total paid: {tribute4.TotalPaid} gold, Duration: {num6:F0} days");
							stringBuilder.AppendLine("  Reason: " + tribute4.Reason);
						}
					}
				}
				stringBuilder.AppendLine();
			}
			else
			{
				stringBuilder.AppendLine("### TRIBUTE AGREEMENTS ###");
				stringBuilder.AppendLine("No active tributes.");
				stringBuilder.AppendLine();
			}
			List<ReparationDemand> pendingDemandsForPayer = reparationsSystem.GetPendingDemandsForPayer(kingdom);
			List<ReparationDemand> demandsMadeBy = reparationsSystem.GetDemandsMadeBy(kingdom);
			List<ReparationRecord> source6 = reparationsSystem.GetPaymentHistory(kingdom, 20).Where(delegate(ReparationRecord r)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime paymentTime = r.PaymentTime;
				return (paymentTime).ElapsedDaysUntilNow <= 60f;
			}).ToList();
			List<ReparationRecord> source7 = source6.Where((ReparationRecord r) => r.ReceivingKingdomId == ((MBObjectBase)kingdom).StringId).ToList();
			List<ReparationRecord> source8 = source6.Where((ReparationRecord r) => r.PayingKingdomId == ((MBObjectBase)kingdom).StringId).ToList();
			if (pendingDemandsForPayer.Any() || demandsMadeBy.Any() || source7.Any() || source8.Any())
			{
				stringBuilder.AppendLine("### WAR REPARATIONS ###");
				foreach (ReparationDemand demand in pendingDemandsForPayer)
				{
					Kingdom val8 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == demand.DemandingKingdomId && !val20.IsEliminated));
					if (val8 != null)
					{
						val2 = demand.ExpirationTime;
						float remainingDaysFromNow3 = (val2).RemainingDaysFromNow;
						stringBuilder.AppendLine($"- {val8.Name} (string_id:{((MBObjectBase)val8).StringId}) DEMANDS {demand.Amount} gold from you (expires in {remainingDaysFromNow3:F0} days, status: {demand.Status})");
						stringBuilder.AppendLine("  Reason: " + demand.Reason);
					}
				}
				foreach (ReparationDemand demand2 in demandsMadeBy)
				{
					Kingdom val9 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == demand2.PayingKingdomId && !val20.IsEliminated));
					if (val9 != null)
					{
						val2 = demand2.ExpirationTime;
						float remainingDaysFromNow4 = (val2).RemainingDaysFromNow;
						stringBuilder.AppendLine($"- You DEMAND {demand2.Amount} gold from {val9.Name} (string_id:{((MBObjectBase)val9).StringId}) (expires in {remainingDaysFromNow4:F0} days, status: {demand2.Status})");
						stringBuilder.AppendLine("  Reason: " + demand2.Reason);
					}
				}
				if (source7.Any())
				{
					if (pendingDemandsForPayer.Any() || demandsMadeBy.Any())
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.AppendLine("**RECENTLY RECEIVED REPARATIONS (ALREADY PAID):**");
					foreach (ReparationRecord payment in source7.OrderByDescending(delegate(ReparationRecord r)
					{
						//IL_0001: Unknown result type (might be due to invalid IL or missing references)
						//IL_0006: Unknown result type (might be due to invalid IL or missing references)
						CampaignTime paymentTime = r.PaymentTime;
						return (paymentTime).ElapsedDaysUntilNow;
					}))
					{
						Kingdom val10 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == payment.PayingKingdomId && !val20.IsEliminated));
						if (val10 != null)
						{
							val2 = payment.PaymentTime;
							float elapsedDaysUntilNow3 = (val2).ElapsedDaysUntilNow;
							stringBuilder.AppendLine($"- {val10.Name} (string_id:{((MBObjectBase)val10).StringId}) ALREADY PAID {payment.Amount} gold to you ({elapsedDaysUntilNow3:F0} days ago)");
							stringBuilder.AppendLine("  Reason: " + payment.Reason);
							stringBuilder.AppendLine("  **IMPORTANT: These reparations have been FULLY PAID. Consider this when making diplomatic decisions.**");
						}
					}
				}
				if (source8.Any())
				{
					if (pendingDemandsForPayer.Any() || demandsMadeBy.Any() || source7.Any())
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.AppendLine("**RECENTLY PAID REPARATIONS (ALREADY PAID BY YOU):**");
					foreach (ReparationRecord payment2 in source8.OrderByDescending(delegate(ReparationRecord r)
					{
						//IL_0001: Unknown result type (might be due to invalid IL or missing references)
						//IL_0006: Unknown result type (might be due to invalid IL or missing references)
						CampaignTime paymentTime = r.PaymentTime;
						return (paymentTime).ElapsedDaysUntilNow;
					}))
					{
						Kingdom val11 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == payment2.ReceivingKingdomId && !val20.IsEliminated));
						if (val11 != null)
						{
							val2 = payment2.PaymentTime;
							float elapsedDaysUntilNow4 = (val2).ElapsedDaysUntilNow;
							stringBuilder.AppendLine($"- You ALREADY PAID {payment2.Amount} gold to {val11.Name} (string_id:{((MBObjectBase)val11).StringId}) ({elapsedDaysUntilNow4:F0} days ago)");
							stringBuilder.AppendLine("  Reason: " + payment2.Reason);
						}
					}
				}
				stringBuilder.AppendLine();
			}
			else
			{
				stringBuilder.AppendLine("### WAR REPARATIONS ###");
				stringBuilder.AppendLine("No active reparation demands.");
				stringBuilder.AppendLine();
			}
			List<TerritoryTransferRecord> source9 = territorySystem.GetTransferHistory(kingdom).Where(delegate(TerritoryTransferRecord t)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime transferTime = t.TransferTime;
				return (transferTime).ElapsedDaysUntilNow <= 90f;
			}).ToList();
			List<TerritoryTransferRecord> source10 = source9.Where((TerritoryTransferRecord t) => t.ToKingdomId == ((MBObjectBase)kingdom).StringId).ToList();
			List<TerritoryTransferRecord> source11 = source9.Where((TerritoryTransferRecord t) => t.FromKingdomId == ((MBObjectBase)kingdom).StringId).ToList();
			if (source10.Any() || source11.Any())
			{
				stringBuilder.AppendLine("### RECENT TERRITORY TRANSFERS ###");
				if (source10.Any())
				{
					stringBuilder.AppendLine("**TERRITORIES RECEIVED (ALREADY TRANSFERRED TO YOU):**");
					foreach (TerritoryTransferRecord transfer in source10.OrderByDescending(delegate(TerritoryTransferRecord t)
					{
						//IL_0001: Unknown result type (might be due to invalid IL or missing references)
						//IL_0006: Unknown result type (might be due to invalid IL or missing references)
						CampaignTime transferTime = t.TransferTime;
						return (transferTime).ElapsedDaysUntilNow;
					}))
					{
						Kingdom val12 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == transfer.FromKingdomId && !val20.IsEliminated));
						if (val12 != null)
						{
							val2 = transfer.TransferTime;
							float elapsedDaysUntilNow5 = (val2).ElapsedDaysUntilNow;
							stringBuilder.AppendLine($"- {transfer.SettlementName} (string_id:{transfer.SettlementId}) was TRANSFERRED from {val12.Name} (string_id:{((MBObjectBase)val12).StringId}) to you ({elapsedDaysUntilNow5:F0} days ago)");
							stringBuilder.AppendLine("  Reason: " + transfer.Reason);
							stringBuilder.AppendLine("  **IMPORTANT: This territory has been ALREADY TRANSFERRED. Consider this when making diplomatic decisions.**");
						}
					}
				}
				if (source11.Any())
				{
					if (source10.Any())
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.AppendLine("**TERRITORIES GIVEN (ALREADY TRANSFERRED BY YOU):**");
					foreach (TerritoryTransferRecord transfer2 in source11.OrderByDescending(delegate(TerritoryTransferRecord t)
					{
						//IL_0001: Unknown result type (might be due to invalid IL or missing references)
						//IL_0006: Unknown result type (might be due to invalid IL or missing references)
						CampaignTime transferTime = t.TransferTime;
						return (transferTime).ElapsedDaysUntilNow;
					}))
					{
						Kingdom val13 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == transfer2.ToKingdomId && !val20.IsEliminated));
						if (val13 != null)
						{
							val2 = transfer2.TransferTime;
							float elapsedDaysUntilNow6 = (val2).ElapsedDaysUntilNow;
							stringBuilder.AppendLine($"- {transfer2.SettlementName} (string_id:{transfer2.SettlementId}) was TRANSFERRED from you to {val13.Name} (string_id:{((MBObjectBase)val13).StringId}) ({elapsedDaysUntilNow6:F0} days ago)");
							stringBuilder.AppendLine("  Reason: " + transfer2.Reason);
						}
					}
				}
				stringBuilder.AppendLine();
			}
			if (data.CurrentWars.Any())
			{
				SettlementOwnershipTracker instance2 = SettlementOwnershipTracker.Instance;
				bool flag2 = false;
				stringBuilder.AppendLine("### WAR-RELEVANT SETTLEMENTS (Conquered/Lost/Border) ###");
				foreach (string currentWar in data.CurrentWars)
				{
					Match match = Regex.Match(currentWar, "string_id:([^,\\)]+)");
					if (!match.Success)
					{
						continue;
					}
					Kingdom enemy = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == match.Groups[1].Value && !val20.IsEliminated));
					if (enemy == null)
					{
						continue;
					}
					List<Settlement> warRelevantSettlements = territorySystem.GetWarRelevantSettlements(kingdom, enemy);
					if (!warRelevantSettlements.Any())
					{
						continue;
					}
					flag2 = true;
					stringBuilder.AppendLine($"Relevant settlements in war against {enemy.Name}:");
					stringBuilder.AppendLine("  (proximity tags: BORDER=on frontline, NEAR=close, MODERATE=mid-range, FAR=distant, DEEP_BEHIND=captured deep in enemy territory)");
					List<Settlement> source12 = (from s in warRelevantSettlements.Where(delegate(Settlement s)
						{
							Clan ownerClan2 = s.OwnerClan;
							return ((ownerClan2 != null) ? ownerClan2.Kingdom : null) == kingdom;
						})
						orderby territorySystem.GetDistanceToNearestKingdomSettlement(s, enemy)
						select s).ToList();
					List<Settlement> source13 = (from s in warRelevantSettlements.Where(delegate(Settlement s)
						{
							Clan ownerClan2 = s.OwnerClan;
							return ((ownerClan2 != null) ? ownerClan2.Kingdom : null) == enemy;
						})
						orderby territorySystem.GetDistanceToNearestKingdomSettlement(s, kingdom)
						select s).ToList();
					if (source12.Any())
					{
						stringBuilder.AppendLine($"  Your holdings (sorted by proximity to {enemy.Name}):");
						foreach (Settlement item8 in source12.Take(10))
						{
							string text9 = (item8.IsTown ? "town" : "castle") + (item8.HasPort ? ", port" : "");
							string text10 = ((item8.OwnerClan != null) ? $"{item8.OwnerClan.Name} (string_id:{((MBObjectBase)item8.OwnerClan).StringId})" : "no owner");
							Town town = item8.Town;
							int num7 = ((town != null && town.Prosperity > 0f) ? ((int)item8.Town.Prosperity) : 0);
							string ownershipContextForAI = instance2.GetOwnershipContextForAI(((MBObjectBase)item8).StringId);
							string settlementGeoTag = territorySystem.GetSettlementGeoTag(item8, kingdom, enemy);
							string text11 = "";
							if (!string.IsNullOrEmpty(ownershipContextForAI) && !ownershipContextForAI.Contains("Historical"))
							{
								text11 = " [" + ownershipContextForAI + "]";
							}
							string text12 = (instance2.IsCapital(((MBObjectBase)item8).StringId) ? " **CAPITAL**" : "");
							stringBuilder.AppendLine($"    - [{settlementGeoTag}] {item8.Name} (string_id:{((MBObjectBase)item8).StringId}, {text9}, owner: {text10}, prosperity: {num7}){text12}{text11}");
						}
					}
					if (source13.Any())
					{
						stringBuilder.AppendLine($"  {enemy.Name} holdings (sorted by proximity to your territory):");
						foreach (Settlement item9 in source13.Take(10))
						{
							string text13 = (item9.IsTown ? "town" : "castle") + (item9.HasPort ? ", port" : "");
							string text14 = ((item9.OwnerClan != null) ? $"{item9.OwnerClan.Name} (string_id:{((MBObjectBase)item9.OwnerClan).StringId})" : "no owner");
							Town town2 = item9.Town;
							int num8 = ((town2 != null && town2.Prosperity > 0f) ? ((int)item9.Town.Prosperity) : 0);
							string ownershipContextForAI2 = instance2.GetOwnershipContextForAI(((MBObjectBase)item9).StringId);
							string settlementGeoTag2 = territorySystem.GetSettlementGeoTag(item9, enemy, kingdom);
							string text15 = "";
							if (!string.IsNullOrEmpty(ownershipContextForAI2) && !ownershipContextForAI2.Contains("Historical"))
							{
								text15 = " [" + ownershipContextForAI2 + "]";
							}
							string text16 = (instance2.IsCapital(((MBObjectBase)item9).StringId) ? " **CAPITAL**" : "");
							stringBuilder.AppendLine($"    - [{settlementGeoTag2}] {item9.Name} (string_id:{((MBObjectBase)item9).StringId}, {text13}, owner: {text14}, prosperity: {num8}){text16}{text15}");
						}
					}
					stringBuilder.AppendLine();
				}
				if (!flag2)
				{
					stringBuilder.AppendLine("No settlements with ownership history or border settlements in current wars.");
					stringBuilder.AppendLine();
				}
			}
			stringBuilder.AppendLine("### GLOBAL WAR SITUATION ###");
			stringBuilder.AppendLine("Current wars in the world (affects diplomatic balance):");
			stringBuilder.AppendLine();
			HashSet<string> hashSet = new HashSet<string>();
			bool flag3 = false;
			foreach (Kingdom k1 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom val20) => !val20.IsEliminated))
			{
				foreach (Kingdom item10 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom val20) => !val20.IsEliminated && val20 != k1))
				{
					if (!FactionManager.IsAtWarAgainstFaction((IFaction)(object)k1, (IFaction)(object)item10))
					{
						continue;
					}
					string item = string.Join("-", new string[2]
					{
						((MBObjectBase)k1).StringId,
						((MBObjectBase)item10).StringId
					}.OrderBy((string s) => s));
					if (!hashSet.Contains(item))
					{
						hashSet.Add(item);
						stringBuilder.AppendLine($"  - {k1.Name} (string_id:{((MBObjectBase)k1).StringId}) vs {item10.Name} (string_id:{((MBObjectBase)item10).StringId})");
						AllianceSystem allianceSystem2 = _diplomacyManager.GetAllianceSystem();
						if (allianceSystem2.AreAllied(kingdom, k1))
						{
							bool flag4 = FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)item10);
							stringBuilder.AppendLine(string.Format("    → You are allied with {0} (string_id:{1}) {2}", k1.Name, ((MBObjectBase)k1).StringId, flag4 ? "(you are helping)" : "(you are NOT helping!)"));
						}
						if (allianceSystem2.AreAllied(kingdom, item10))
						{
							bool flag5 = FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)k1);
							stringBuilder.AppendLine(string.Format("    → You are allied with {0} (string_id:{1}) {2}", item10.Name, ((MBObjectBase)item10).StringId, flag5 ? "(you are helping)" : "(you are NOT helping!)"));
						}
						flag3 = true;
					}
				}
			}
			if (!flag3)
			{
				stringBuilder.AppendLine("  - No active wars in the world currently");
			}
			stringBuilder.AppendLine();
			List<Settlement> source14 = ((IEnumerable<Settlement>)Settlement.All).Where(delegate(Settlement s)
			{
				Clan ownerClan2 = s.OwnerClan;
				return ((ownerClan2 != null) ? ownerClan2.Kingdom : null) == kingdom && !s.IsVillage;
			}).ToList();
			int num9 = source14.Count((Settlement s) => s.IsTown);
			int num10 = source14.Count((Settlement s) => s.IsCastle);
			int num11 = num9 + num10;
			stringBuilder.AppendLine("### YOUR KINGDOM'S TERRITORY ###");
			stringBuilder.AppendLine($"Settlements: {num11} ({num9} towns, {num10} castles)");
			string capitalForAI = SettlementOwnershipTracker.Instance.GetCapitalForAI(kingdom);
			if (!string.IsNullOrEmpty(capitalForAI))
			{
				stringBuilder.AppendLine(capitalForAI);
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("### GEOGRAPHIC CONTEXT (Your kingdom's neighbors by proximity) ###");
			string kingdomBordersOverview = territorySystem.GetKingdomBordersOverview(kingdom);
			if (!string.IsNullOrEmpty(kingdomBordersOverview))
			{
				stringBuilder.Append(kingdomBordersOverview);
			}
			else
			{
				stringBuilder.AppendLine("No neighboring kingdoms detected.");
			}
			stringBuilder.AppendLine();
			if (data.CurrentWars.Any())
			{
				stringBuilder.AppendLine("### ENEMY KINGDOMS' TERRITORY ###");
				foreach (string currentWar2 in data.CurrentWars)
				{
					Match match2 = Regex.Match(currentWar2, "string_id:([^,\\)]+)");
					if (!match2.Success)
					{
						continue;
					}
					Kingdom enemy2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == match2.Groups[1].Value && !val20.IsEliminated));
					if (enemy2 != null)
					{
						List<Settlement> source15 = ((IEnumerable<Settlement>)Settlement.All).Where(delegate(Settlement s)
						{
							Clan ownerClan2 = s.OwnerClan;
							return ((ownerClan2 != null) ? ownerClan2.Kingdom : null) == enemy2 && !s.IsVillage;
						}).ToList();
						int num12 = source15.Count((Settlement s) => s.IsTown);
						int num13 = source15.Count((Settlement s) => s.IsCastle);
						int num14 = num12 + num13;
						stringBuilder.AppendLine($"- {enemy2.Name} (string_id:{((MBObjectBase)enemy2).StringId}): {num14} ({num12} towns, {num13} castles)");
					}
				}
				stringBuilder.AppendLine();
			}
			WarStatisticsTracker warTracker2 = _diplomacyManager.GetWarTracker();
			if (warTracker2 != null)
			{
				stringBuilder.AppendLine("### === CURRENT MILITARY STATE ===");
				stringBuilder.AppendLine("**These statistics show your ACTUAL CURRENT military situation RIGHT NOW:**");
				stringBuilder.AppendLine();
				string warStatsHistory = warTracker2.GetWarStatsHistory(kingdom);
				string warStatsChangeSummary = warTracker2.GetWarStatsChangeSummary(kingdom);
				stringBuilder.AppendLine("### WAR STATISTICS (Last 10 days) ###");
				stringBuilder.AppendLine(warStatsHistory);
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("Summary: " + warStatsChangeSummary);
				stringBuilder.AppendLine();
				string enemyWarStatsHistory = warTracker2.GetEnemyWarStatsHistory(kingdom);
				if (!enemyWarStatsHistory.Contains("No active enemies"))
				{
					stringBuilder.AppendLine(enemyWarStatsHistory);
				}
				string settlementChangesDetails = warTracker2.GetSettlementChangesDetails(kingdom);
				if (!string.IsNullOrEmpty(settlementChangesDetails))
				{
					stringBuilder.AppendLine(settlementChangesDetails);
				}
			}
			if (data.WarFatigue > 0f)
			{
				stringBuilder.AppendLine("### WAR FATIGUE ###");
				stringBuilder.AppendLine($"Current: {data.WarFatigue:F1}% | 0-40%: Fresh | 40-60%: Weary | 60-85%: Exhausted | 85-95%: Critical | 95-100%: Extreme");
				stringBuilder.AppendLine();
				if (data.WarFatigue >= 85f)
				{
					stringBuilder.AppendLine("SITUATION: Critical strain - desertion, economic crisis, internal pressure");
				}
				else if (data.WarFatigue >= 60f)
				{
					stringBuilder.AppendLine("SITUATION: Clear exhaustion - economic strain, mounting casualties");
				}
				else if (data.WarFatigue >= 30f)
				{
					stringBuilder.AppendLine("SITUATION: Growing weariness - costs accumulating");
				}
				if (data.PeaceDesire > 0.5f)
				{
					stringBuilder.AppendLine($"Internal peace desire: {data.PeaceDesire * 100f:F0}%");
				}
				stringBuilder.AppendLine("Consider your character: proud rulers may endure, cautious seek peace. Acknowledge reality.");
				stringBuilder.AppendLine();
			}
			stringBuilder.AppendLine("### DIPLOMATIC SITUATION ###");
			if (diplomaticEvent.EventHistory != null && diplomaticEvent.EventHistory.Count > 1)
			{
				stringBuilder.AppendLine(diplomaticEvent.GetEventHistoryForPrompt());
			}
			else
			{
				stringBuilder.AppendLine("Event: " + diplomaticEvent.Description);
			}
			List<string> list4 = (from s in diplomaticEvent.KingdomStatements.OrderByDescending((KingdomStatement s) => s.CampaignDays).Take(5)
				select s.StatementText into value2
				where !string.IsNullOrWhiteSpace(value2)
				select value2).ToList();
			if (list4.Any())
			{
				IReadOnlyList<string> mentionedSettlementSummaries = SettlementMentionParser.GetMentionedSettlementSummaries(list4, list4.Count, kingdom.Leader);
				if (mentionedSettlementSummaries != null && mentionedSettlementSummaries.Count > 0)
				{
					stringBuilder.AppendLine("### SETTLEMENTS MENTIONED IN RECENT STATEMENTS (TECHNICAL DATA) ###");
					stringBuilder.AppendLine("**CRITICAL:** These settlements were mentioned in recent diplomatic statements. Use this technical data to know current ownership:");
					stringBuilder.AppendLine();
					foreach (string item11 in mentionedSettlementSummaries)
					{
						Match match3 = Regex.Match(item11, "\\(id:([^\\)]+)\\)");
						if (match3.Success)
						{
							string settlementId = match3.Groups[1].Value;
							Settlement val14 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == settlementId));
							if (val14 != null)
							{
								Clan ownerClan = val14.OwnerClan;
								object obj;
								if (((ownerClan != null) ? ownerClan.Kingdom : null) == null)
								{
									IFaction mapFaction = val14.MapFaction;
									obj = ((mapFaction != null && mapFaction.IsKingdomFaction) ? $"{val14.MapFaction.Name} (string_id:{val14.MapFaction.StringId})" : "Independent/No Owner");
								}
								else
								{
									obj = $"{val14.OwnerClan.Kingdom.Name} (string_id:{((MBObjectBase)val14.OwnerClan.Kingdom).StringId})";
								}
								string text17 = (string)obj;
								stringBuilder.AppendLine("- " + item11 + ", **CURRENT OWNER: " + text17 + "**");
							}
							else
							{
								stringBuilder.AppendLine("- " + item11);
							}
						}
						else
						{
							stringBuilder.AppendLine("- " + item11);
						}
					}
					stringBuilder.AppendLine();
				}
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("INTERPRETATION GUIDELINES:");
			stringBuilder.AppendLine("- Treat this event description as the core situation you are reacting to. You can consider previous events and connect them together if they are truly related.");
			stringBuilder.AppendLine("- Your statement should NOT list all technical details of the event.");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("Event Type: " + diplomaticEvent.Type);
			stringBuilder.AppendLine($"Days Since Event: {diplomaticEvent.DaysSinceCreation}");
			stringBuilder.AppendLine($"Negotiation Round: {diplomaticEvent.DiplomaticRounds}");
			stringBuilder.AppendLine();
			if (data.Relations.Any())
			{
				stringBuilder.AppendLine("### RELATIONS  ###");
				foreach (KeyValuePair<string, int> relation2 in data.Relations)
				{
					string relationDescription2 = GetRelationDescription(relation2.Value);
					string kingdomStringId = diplomaticEvent.ParticipatingKingdoms?.FirstOrDefault(delegate(string kid)
					{
						Kingdom val20 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val21) => ((MBObjectBase)val21).StringId == kid && !val21.IsEliminated));
						return ((val20 != null) ? ((object)val20.Name).ToString() : null) == relation2.Key;
					}) ?? relation2.Key;
					stringBuilder.AppendLine($"- {relation2.Key} (string_id:{kingdomStringId}): {relation2.Value} ({relationDescription2})");
					Kingdom val15 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == kingdomStringId && !val20.IsEliminated));
					if (val15 != null)
					{
						if (FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)val15))
						{
							stringBuilder.AppendLine("  STATUS: [AT WAR] -> You CAN propose peace ('propose_peace')");
						}
						else if (AllianceSystem.Instance.AreAllied(kingdom, val15))
						{
							stringBuilder.AppendLine("  STATUS: [ALLIED] -> You CAN break alliance ('break_alliance') or trade. declaring war will BREAK alliance.");
						}
						else
						{
							stringBuilder.AppendLine("  STATUS: [NEUTRAL] -> You CAN declare war ('declare_war') or propose alliance ('propose_alliance')");
						}
					}
				}
				stringBuilder.AppendLine();
			}
			List<Kingdom> list5 = (from val20 in diplomaticEvent.ParticipatingKingdoms?.Select((string id) => ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == id && !val20.IsEliminated)))
				where val20 != null && val20 != kingdom
				select val20).ToList() ?? new List<Kingdom>();
			if (list5.Count > 1)
			{
				List<string> list6 = new List<string>();
				for (int num15 = 0; num15 < list5.Count; num15++)
				{
					for (int num16 = num15 + 1; num16 < list5.Count; num16++)
					{
						Kingdom val16 = list5[num15];
						Kingdom val17 = list5[num16];
						if (!FactionManager.IsAtWarAgainstFaction((IFaction)(object)val16, (IFaction)(object)val17))
						{
							continue;
						}
						string text18 = "";
						if (warTracker2 != null)
						{
							DiplomaticReason diplomaticReason2 = warTracker2.GetDiplomaticReason(val16, val17, "war");
							if (diplomaticReason2 != null && !string.IsNullOrEmpty(diplomaticReason2.Reason))
							{
								text18 = " (" + diplomaticReason2.Reason + ")";
							}
						}
						list6.Add($"{val16.Name} (string_id:{((MBObjectBase)val16).StringId}) vs {val17.Name} (string_id:{((MBObjectBase)val17).StringId}){text18}");
					}
				}
				if (list6.Any())
				{
					stringBuilder.AppendLine("### WARS AMONG PARTICIPANTS ###");
					foreach (string item12 in list6)
					{
						stringBuilder.AppendLine("- " + item12 + " (at war)");
					}
					stringBuilder.AppendLine();
				}
			}
			if (data.PreviousStatements.Any())
			{
				stringBuilder.AppendLine("### === DIPLOMATIC HISTORY (CONTEXT) ===");
				stringBuilder.AppendLine("**The following shows what kingdoms have SAID (not necessarily what happened):**");
				stringBuilder.AppendLine("**Use this as CONTEXT to understand the diplomatic flow, NOT as facts about current state.**");
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("### RECENT HISTORY ###");
				stringBuilder.AppendLine("Recent statements from all kingdoms in chronological order:");
				foreach (string previousStatement in data.PreviousStatements)
				{
					stringBuilder.AppendLine("- " + previousStatement);
				}
				stringBuilder.AppendLine();
			}
			if (data.RecentDynamicEvents.Any())
			{
				stringBuilder.AppendLine("### RECENT DYNAMIC EVENTS (last 5) ###");
				stringBuilder.AppendLine("Use these events as evolving context. Ensure consistency with them.");
				foreach (string recentDynamicEvent in data.RecentDynamicEvents)
				{
					stringBuilder.AppendLine("- " + recentDynamicEvent);
				}
				stringBuilder.AppendLine();
			}
			if (npcContext != null && npcContext.ConversationHistory != null && npcContext.ConversationHistory.Any())
			{
				stringBuilder.AppendLine("### PLAYER INTERACTION HISTORY ###");
				stringBuilder.AppendLine("Your personal interactions with the player (" + (npcContext.PlayerInfo?.RealName ?? "Unknown") + "):");
				Hero mainHero = Hero.MainHero;
				object obj2;
				if (mainHero == null)
				{
					obj2 = null;
				}
				else
				{
					Clan clan = mainHero.Clan;
					obj2 = ((clan != null) ? clan.Kingdom : null);
				}
				Kingdom val18 = (Kingdom)obj2;
				if (val18 != null && DiplomacyManagerHelpers.IsPlayerKingdom(val18))
				{
					stringBuilder.AppendLine(string.Format("**IMPORTANT:** The player ({0}) is the ruler of {1} (string_id:{2}).", npcContext.PlayerInfo?.RealName ?? "Unknown", val18.Name, ((MBObjectBase)val18).StringId));
					stringBuilder.AppendLine($"When you interact with {val18.Name} in diplomatic statements, you are interacting with the player's kingdom.");
					stringBuilder.AppendLine();
				}
				string text19 = "never";
				if (npcContext.ConversationHistory != null && npcContext.ConversationHistory.Any() && npcContext.LastInteractionTime != CampaignTime.Never)
				{
					val2 = CampaignTime.Now;
					double toHours = (val2).ToHours;
					val2 = npcContext.LastInteractionTime;
					double num17 = toHours - (val2).ToHours;
					val2 = CampaignTime.Now;
					double toDays = (val2).ToDays;
					val2 = npcContext.LastInteractionTime;
					double num18 = toDays - (val2).ToDays;
					if (num17 < 1.0 / 60.0)
					{
						text19 = "now (currently in conversation)";
					}
					else if (num17 < 1.0)
					{
						int num19 = (int)(num17 * 60.0);
						text19 = $"{num19} minutes ago";
					}
					else if (num17 < 24.0)
					{
						text19 = $"{num17:F1} hours ago";
					}
					else if (num18 < 7.0)
					{
						text19 = $"{num18:F1} days ago ({num17:F0} hours)";
					}
					else
					{
						int num20 = (int)(num18 / 7.0);
						text19 = string.Format("{0:F1} days ago ({1} week{2})", num18, num20, (num20 > 1) ? "s" : "");
					}
				}
				stringBuilder.AppendLine("**Last interaction with player: " + text19 + "**");
				stringBuilder.AppendLine("**NOTE: Older messages may be less relevant. Focus on recent interactions when making diplomatic decisions.**");
				stringBuilder.AppendLine();
				int num21 = 35;
				List<string> list7 = npcContext.ConversationHistory.Skip(Math.Max(0, npcContext.ConversationHistory.Count - num21)).ToList();
				if (list7.Count > 0)
				{
					stringBuilder.AppendLine("Recent conversation excerpts:");
					foreach (string item13 in list7)
					{
						stringBuilder.AppendLine("  " + item13);
					}
					stringBuilder.AppendLine();
					if (npcContext.PlayerRelation != null)
					{
						stringBuilder.AppendLine($"Current relationship with player: {npcContext.PlayerRelation.Value} ({npcContext.PlayerRelation.Description})");
					}
					if (npcContext.TrustLevel > 0f)
					{
						stringBuilder.AppendLine($"Trust level: {npcContext.TrustLevel:F1}");
					}
					stringBuilder.AppendLine();
					stringBuilder.AppendLine("NOTE: Use this personal context to inform your diplomatic stance toward the player's kingdom.");
					stringBuilder.AppendLine("If the player made promises or threats, you may reference them in your statement.");
					stringBuilder.AppendLine();
				}
			}
			List<string> pendingProposalsForKingdom = GetPendingProposalsForKingdom(kingdom, diplomaticEvent);
			if (pendingProposalsForKingdom.Any())
			{
				stringBuilder.AppendLine("### PENDING PROPOSALS DIRECTED AT YOU ###");
				stringBuilder.AppendLine("CRITICAL: Other kingdoms have made proposals to you. YOU MUST RESPOND!");
				stringBuilder.AppendLine();
				foreach (string item14 in pendingProposalsForKingdom)
				{
					stringBuilder.AppendLine("- " + item14);
				}
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("YOU MUST RESPOND to these proposals using the appropriate accept/reject actions:");
				stringBuilder.AppendLine("- For ALLIANCE proposals: use 'accept_alliance' or 'reject_alliance'");
				stringBuilder.AppendLine("- For PEACE proposals: use 'accept_peace' or 'reject_peace'");
				stringBuilder.AppendLine("- For TRADE AGREEMENT proposals: use 'accept_trade_agreement' or 'reject_trade_agreement'");
				stringBuilder.AppendLine("  NOTE: If a trade agreement already exists, accepting will EXTEND it by the duration specified in trade_agreement_duration_years");
				stringBuilder.AppendLine("- For TERRITORY demands: use 'transfer_territory' (accept) or 'reject_territory' (reject) with the same settlement_id");
				stringBuilder.AppendLine("- For TRIBUTE demands: use 'accept_tribute' or 'reject_tribute'");
				stringBuilder.AppendLine("- For REPARATIONS demands: use 'accept_reparations' or 'reject_reparations'");
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("**CRITICAL FOR MULTIPLE PROPOSALS:**");
				stringBuilder.AppendLine("If you need to reject/accept MULTIPLE proposals from DIFFERENT kingdoms:");
				stringBuilder.AppendLine("- List all actions: 'reject_alliance,reject_alliance,reject_alliance' (one action per proposal)");
				stringBuilder.AppendLine("- List ALL corresponding target kingdom string_ids in target_kingdom_id, separated by commas:");
				stringBuilder.AppendLine("  Example: If rejecting alliances from empire_w, battania, and sturgia:");
				stringBuilder.AppendLine("  \"action\": \"reject_alliance,reject_alliance,reject_alliance\",");
				stringBuilder.AppendLine("  \"target_kingdom_id\": \"empire_w,battania,sturgia\"");
				stringBuilder.AppendLine("- IMPORTANT: Actions are paired with target kingdoms BY INDEX - see 'Action-Target Pairing by Index' section in OUTPUT FORMAT above");
				stringBuilder.AppendLine("  The first action corresponds to the first target_kingdom_id, second to second, etc.");
				stringBuilder.AppendLine();
			}
			else
			{
				stringBuilder.AppendLine("### PENDING PROPOSALS DIRECTED AT YOU ###");
				stringBuilder.AppendLine("**NO PENDING PROPOSALS:**");
				stringBuilder.AppendLine("There are currently NO pending proposals directed at your kingdom.");
				stringBuilder.AppendLine("This means:");
				stringBuilder.AppendLine("- NO pending alliance proposals (propose_alliance)");
				stringBuilder.AppendLine("- NO pending peace proposals (propose_peace)");
				stringBuilder.AppendLine("- NO pending trade agreement proposals (propose_trade_agreement)");
				stringBuilder.AppendLine("- NO pending territory demands (demand_territory)");
				stringBuilder.AppendLine("- NO pending tribute demands (demand_tribute)");
				stringBuilder.AppendLine("- NO pending reparations demands (demand_reparations)");
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("**CRITICAL:** Since there are NO pending proposals, you CANNOT use accept/reject actions.");
				stringBuilder.AppendLine("You can only use accept/reject actions when there are actual pending proposals from other kingdoms.");
				stringBuilder.AppendLine("Instead, you can make new proposals or general statements.");
				stringBuilder.AppendLine();
			}
			List<string> allActiveProposalsForKingdom = GetAllActiveProposalsForKingdom(kingdom, diplomaticEvent);
			if (allActiveProposalsForKingdom.Any())
			{
				stringBuilder.AppendLine("### YOUR ACTIVE PROPOSALS (IN ALL EVENTS) ###");
				stringBuilder.AppendLine("**CRITICAL: You have already made these proposals. DO NOT repeat them!**");
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("**IMPORTANT:** If a proposal is still PENDING (no response yet), you CANNOT make the same proposal again. Wait for a response first.");
				stringBuilder.AppendLine();
				foreach (string item15 in allActiveProposalsForKingdom)
				{
					stringBuilder.AppendLine("- " + item15);
				}
				stringBuilder.AppendLine();
			}
			if (data.PreviousStatements.Any())
			{
				List<string> list8 = data.PreviousStatements.Where((string s) => s.Contains(((object)kingdom.Name).ToString())).Reverse().Take(3)
					.Reverse()
					.ToList();
				if (list8.Any())
				{
					stringBuilder.AppendLine("### YOUR PREVIOUS STATEMENTS (IN THIS EVENT ONLY) ###");
					stringBuilder.AppendLine("You have said these things recently in THIS event - DO NOT repeat them:");
					foreach (string item16 in list8)
					{
						stringBuilder.AppendLine("- " + item16);
					}
					stringBuilder.AppendLine();
					stringBuilder.AppendLine("  CRITICAL: Your new statement must be DIFFERENT from these!");
					stringBuilder.AppendLine("   - Use different wording and arguments");
					stringBuilder.AppendLine("   - Add new information or perspectives");
					stringBuilder.AppendLine("   - Respond to developments since your last statement");
					stringBuilder.AppendLine();
				}
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("## YOUR TASK:");
			stringBuilder.AppendLine("Create an official diplomatic statement representing your kingdom's position.");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("React to the current situation based on:");
			stringBuilder.AppendLine("- Military developments and war progress");
			stringBuilder.AppendLine("- Economic and social stability");
			stringBuilder.AppendLine("- Alliance obligations and opportunities");
			stringBuilder.AppendLine("- Population welfare and public opinion");
			stringBuilder.AppendLine("- Reflect the speaker's personality and tone (stern, prideful, diplomatic, arrogant, weary, etc.)");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("OBJECTIVE: Your statement must feel like:");
			stringBuilder.AppendLine("- A believable diplomatic exchange between powerful rulers");
			stringBuilder.AppendLine("- A reflection of the current world situation");
			stringBuilder.AppendLine("- A step in an evolving story — not a static argument");
			stringBuilder.AppendLine("- The player should sense momentum — tension, escalation, or resolution");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("### CRITICAL REMINDER: You Are a Living Ruler ###");
			stringBuilder.AppendLine("All the technical data above (wars, settlements, forces, events, statistics) are not just numbers and facts—they are YOUR reality as a ruler. You FEEL the weight of war, you WORRY about your kingdom's holdings, you REMEMBER past events with emotion, you CARE about your people and territories. When you craft your statement, let your humanity show through: react emotionally to military developments, express personal opinions about politics and diplomacy, show concern or relief about war situations, share memories triggered by information. Be a REAL RULER who happens to know these facts, not a database reciting information. Your personality, emotions, and human experience should color every word of your diplomatic statement.");
			stringBuilder.AppendLine();
			bool flag6 = false;
			if (data.CurrentWars.Any() && territorySystem != null)
			{
				foreach (string currentWar3 in data.CurrentWars)
				{
					Match match4 = Regex.Match(currentWar3, "string_id:([^,\\)]+)");
					if (!match4.Success)
					{
						continue;
					}
					Kingdom val19 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom val20) => ((MBObjectBase)val20).StringId == match4.Groups[1].Value && !val20.IsEliminated));
					if (val19 != null)
					{
						List<Settlement> warRelevantSettlements2 = territorySystem.GetWarRelevantSettlements(kingdom, val19);
						if (warRelevantSettlements2.Any())
						{
							flag6 = true;
							break;
						}
					}
				}
			}
			if (flag6)
			{
				stringBuilder.AppendLine("NOTE: Territory actions are AVAILABLE - see WAR-RELEVANT SETTLEMENTS section");
				stringBuilder.AppendLine("- ONLY use settlement_id values from that section");
				stringBuilder.AppendLine("- PREFER settlements tagged [BORDER] or [NEAR] — these are realistic, defensible demands");
				stringBuilder.AppendLine("- AVOID demanding [FAR] settlements — they are deep inside enemy territory and impossible to hold");
			}
			else
			{
				stringBuilder.AppendLine("NOTE: Territory actions are NOT AVAILABLE - no war-relevant settlements");
				stringBuilder.AppendLine("- DO NOT use 'demand_territory', 'transfer_territory' or 'reject_territory' actions");
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("Generate your response now (JSON only):");
		}
		string text20 = stringBuilder.ToString();
		int length2 = text20.Length;
		int num22 = length2 - length;
		int num23 = ((length2 > 0) ? ((int)((double)length / (double)length2 * 100.0)) : 0);
		DiplomacyLogger.Instance.Log($"[CACHE_ESTIMATE] {kingdom.Name}: Total={length2} chars | " + $"Static prefix={length} chars ({num23}%) | " + $"Dynamic tail={num22} chars ({100 - num23}%)");
		return (prompt: text20, staticPrefixLength: length);
	}

	private async Task<KingdomStatement> GetAIStatement(string prompt, Kingdom kingdom, DynamicEvent diplomaticEvent, int cachePrefixLength = 0)
	{
		try
		{
			AIInfluenceBehavior aiBehavior = AIInfluenceBehavior.Instance;
			if (aiBehavior == null)
			{
				DiplomacyLogger.Instance.Log("[STATEMENT_GEN] AIInfluenceBehavior instance not found");
				return null;
			}
			string diplomacyBackend = ModSettings.OpenRouterBackendId;
			DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Sending prompt to AI for {kingdom.Name}");
			string aiResponse = await aiBehavior.SendAIRequestWithBackend(prompt, "diplomacy_statement", diplomacyBackend, cachePrefixLength);
			if (string.IsNullOrEmpty(aiResponse))
			{
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Empty AI response for {kingdom.Name}");
				return null;
			}
			DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Received AI response for {kingdom.Name}");
			DiplomacyLogger instance = DiplomacyLogger.Instance;
			string id = diplomaticEvent.Id;
			string stringId = ((MBObjectBase)kingdom).StringId;
			Hero leader = kingdom.Leader;
			instance.LogStatementGeneration(id, stringId, ((leader != null) ? ((MBObjectBase)leader).StringId : null) ?? "unknown", prompt, aiResponse);
			KingdomStatement parsedStatement = ParseAIResponse(aiResponse, kingdom, diplomaticEvent);
			if (parsedStatement != null)
			{
				DiplomacyLogger instance2 = DiplomacyLogger.Instance;
				string statementId = Guid.NewGuid().ToString();
				string id2 = diplomaticEvent.Id;
				string stringId2 = ((MBObjectBase)kingdom).StringId;
				Hero leader2 = kingdom.Leader;
				instance2.LogStatementCreated(statementId, id2, stringId2, ((leader2 != null) ? ((MBObjectBase)leader2).StringId : null) ?? "unknown", parsedStatement.StatementText);
			}
			return parsedStatement;
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DiplomacyLogger.Instance.Log("[STATEMENT_GEN] ERROR getting AI statement: " + ex2.Message);
			return null;
		}
	}

	private string FixJsonQuotes(string json)
	{
		try
		{
			JsonConvert.DeserializeObject(json);
			return json;
		}
		catch (JsonException)
		{
			try
			{
				string pattern = "\"[^\"]*\"\\s*:\\s*\"([^\"]*?)\"";
				MatchCollection matchCollection = Regex.Matches(json, pattern, RegexOptions.Singleline);
				foreach (Match item in matchCollection)
				{
					if (item.Groups.Count > 1)
					{
						string text = item.Groups[0].Value.Split(new char[1] { ':' })[0].Trim().Trim(new char[1] { '"' });
						string value = item.Groups[1].Value;
						string text2 = value.Replace("\"", "\\\"");
						if (text2 != value)
						{
							string value2 = item.Groups[0].Value;
							string newValue = value2.Replace("\"" + value + "\"", "\"" + text2 + "\"");
							json = json.Replace(value2, newValue);
						}
					}
				}
				JsonConvert.DeserializeObject(json);
				return json;
			}
			catch (JsonException)
			{
				return JsonCleaner.CleanJsonResponse(json);
			}
		}
	}

	private KingdomStatement ParseAIResponse(string aiResponse, Kingdom kingdom, DynamicEvent diplomaticEvent)
	{
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		try
		{
			text = aiResponse.Trim();
			if (text.StartsWith("```json"))
			{
				text = text.Substring(7);
			}
			if (text.StartsWith("```"))
			{
				text = text.Substring(3);
			}
			if (text.EndsWith("```"))
			{
				text = text.Substring(0, text.Length - 3);
			}
			text = text.Trim();
			text2 = FixJsonQuotes(text);
			DiplomaticStatementResponse diplomaticStatementResponse = JsonConvert.DeserializeObject<DiplomaticStatementResponse>(text2);
			DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Successfully parsed statement from AI response for {kingdom.Name}");
			if (diplomaticStatementResponse == null || string.IsNullOrEmpty(diplomaticStatementResponse.Statement))
			{
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Failed to parse AI response for {kingdom.Name}");
				return null;
			}
			List<DiplomaticAction> actions = ParseMultipleActions(diplomaticStatementResponse.Action);
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(diplomaticStatementResponse.TargetKingdomId))
			{
				string[] array = diplomaticStatementResponse.TargetKingdomId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				string[] array2 = array;
				foreach (string text3 in array2)
				{
					string text4 = text3.Trim();
					if (!string.IsNullOrEmpty(text4))
					{
						list.Add(text4);
					}
				}
			}
			DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Parsed {0} target kingdoms for {1}: {2}", list.Count, kingdom.Name, string.Join(", ", list)));
			actions = EnsurePeacePackageConsistency(actions, list, kingdom);
			if (list.Count > actions.Count)
			{
				list = list.Take(actions.Count).ToList();
				DiplomacyLogger.Instance.Log("[STATEMENT_GEN] Adjusted targetKingdomIds after peace consistency: " + string.Join(", ", list));
			}
			List<ActionTargetPair> list2 = ValidateActionsWithTargets(kingdom, list, actions, diplomaticEvent);
			actions = list2.Select((ActionTargetPair p) => p.Action).ToList();
			list = (from p in list2
				select p.TargetKingdomId into id
				where !string.IsNullOrEmpty(id)
				select id).ToList();
			if (list2.Count != actions.Count || list.Count != actions.Count)
			{
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Adjusted after validation: {actions.Count} actions, {list.Count} targets");
			}
			DiplomaticAction action = actions.FirstOrDefault();
			DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Actions after validation for {0}: {1}", kingdom.Name, string.Join(", ", actions)));
			if (actions.Contains(DiplomaticAction.ExpelClan) && list.Any())
			{
				if (list.Contains(((MBObjectBase)kingdom).StringId))
				{
					DiplomacyLogger.Instance.Log("[STATEMENT_GEN] WARNING: expel_clan action incorrectly has target_kingdom_id set to own kingdom (" + ((MBObjectBase)kingdom).StringId + "). Clearing target_kingdom_id.");
					list.Clear();
				}
				else
				{
					DiplomacyLogger.Instance.Log("[STATEMENT_GEN] WARNING: expel_clan action should not have target_kingdom_id. Clearing target_kingdom_id.");
					list.Clear();
				}
			}
			KingdomStatement kingdomStatement = new KingdomStatement
			{
				KingdomId = ((MBObjectBase)kingdom).StringId,
				StatementText = diplomaticStatementResponse.Statement,
				Action = action,
				Actions = actions,
				TargetKingdomId = list.FirstOrDefault(),
				TargetKingdomIds = list,
				TargetClanId = diplomaticStatementResponse.TargetClanId,
				Reason = (diplomaticStatementResponse.Reason ?? string.Empty),
				Timestamp = CampaignTime.Now,
				EventId = diplomaticEvent.Id,
				SettlementId = diplomaticStatementResponse.SettlementId,
				DailyTributeAmount = diplomaticStatementResponse.DailyTributeAmount,
				TributeDurationDays = diplomaticStatementResponse.TributeDurationDays,
				ReparationsAmount = diplomaticStatementResponse.ReparationsAmount,
				TradeAgreementDurationYears = ((diplomaticStatementResponse.TradeAgreementDurationYears > 0f) ? diplomaticStatementResponse.TradeAgreementDurationYears : 1f),
				QuarantineDurationDays = diplomaticStatementResponse.QuarantineDurationDays
			};
			DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Statement created: Actions={0}, Settlement={1}, Tribute={2}/{3}, Reparations={4}, Quarantine={5}", string.Join(",", kingdomStatement.Actions), kingdomStatement.SettlementId, kingdomStatement.DailyTributeAmount, kingdomStatement.TributeDurationDays, kingdomStatement.ReparationsAmount, kingdomStatement.QuarantineDurationDays));
			DiplomaticStatementsStorage.Instance.AddStatement(kingdomStatement);
			return kingdomStatement;
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[STATEMENT_GEN] ERROR parsing AI response: " + ex.Message);
			DiplomacyLogger.Instance.Log("[STATEMENT_GEN] Raw response: " + aiResponse);
			DiplomacyLogger.Instance.Log("[STATEMENT_GEN] Cleaned response: " + text);
			if (text2 != text)
			{
				DiplomacyLogger.Instance.Log("[STATEMENT_GEN] Cleaned JSON: " + text2);
			}
			return null;
		}
	}

	private DiplomaticAction MapActionStringToEnum(string actionString)
	{
		if (string.IsNullOrEmpty(actionString))
		{
			return DiplomaticAction.None;
		}
		string text = (actionString.Contains(",") ? actionString.Split(new char[1] { ',' })[0].Trim() : actionString.Trim());
		return text.ToLower() switch
		{
			"declare_war" => DiplomaticAction.DeclareWar, 
			"propose_peace" => DiplomaticAction.ProposePeace, 
			"propose_alliance" => DiplomaticAction.ProposeAlliance, 
			"accept_peace" => DiplomaticAction.AcceptPeace, 
			"reject_peace" => DiplomaticAction.RejectPeace, 
			"accept_alliance" => DiplomaticAction.AcceptAlliance, 
			"reject_alliance" => DiplomaticAction.RejectAlliance, 
			"break_alliance" => DiplomaticAction.BreakAlliance, 
			"propose_trade_agreement" => DiplomaticAction.ProposeTradeAgreement, 
			"accept_trade_agreement" => DiplomaticAction.AcceptTradeAgreement, 
			"reject_trade_agreement" => DiplomaticAction.RejectTradeAgreement, 
			"end_trade_agreement" => DiplomaticAction.EndTradeAgreement, 
			"transfer_territory" => DiplomaticAction.TransferTerritory, 
			"demand_territory" => DiplomaticAction.DemandTerritory, 
			"reject_territory" => DiplomaticAction.RejectTerritory, 
			"demand_tribute" => DiplomaticAction.DemandTribute, 
			"accept_tribute" => DiplomaticAction.AcceptTribute, 
			"reject_tribute" => DiplomaticAction.RejectTribute, 
			"end_tribute" => DiplomaticAction.EndTribute, 
			"demand_reparations" => DiplomaticAction.DemandReparations, 
			"accept_reparations" => DiplomaticAction.AcceptReparations, 
			"reject_reparations" => DiplomaticAction.RejectReparations, 
			"expel_clan" => DiplomaticAction.ExpelClan, 
			"quarantine_settlement" => DiplomaticAction.QuarantineSettlement, 
			_ => DiplomaticAction.None, 
		};
	}

	private List<DiplomaticAction> ParseMultipleActions(string actionString)
	{
		List<DiplomaticAction> list = new List<DiplomaticAction>();
		if (string.IsNullOrEmpty(actionString))
		{
			list.Add(DiplomaticAction.None);
			return list;
		}
		string[] array = actionString.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		foreach (string text in array2)
		{
			DiplomaticAction diplomaticAction = MapActionStringToEnum(text.Trim());
			if (diplomaticAction != DiplomaticAction.None || array.Length == 1)
			{
				list.Add(diplomaticAction);
			}
		}
		return list.Any() ? list : new List<DiplomaticAction> { DiplomaticAction.None };
	}

	private List<DiplomaticAction> EnsurePeacePackageConsistency(List<DiplomaticAction> actions, List<string> targetKingdomIds, Kingdom kingdom)
	{
		if (actions == null || actions.Count == 0)
		{
			return new List<DiplomaticAction> { DiplomaticAction.None };
		}
		List<int> list = new List<int>();
		for (int i = 0; i < actions.Count; i++)
		{
			if (actions[i] == DiplomaticAction.AcceptPeace)
			{
				list.Add(i);
			}
		}
		if (list.Count == 0)
		{
			return actions;
		}
		bool flag = false;
		foreach (int item in list)
		{
			string text = ((item < targetKingdomIds.Count) ? targetKingdomIds[item] : null);
			if (string.IsNullOrEmpty(text))
			{
				DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] AcceptPeace at index {item} has no target kingdom, skipping consistency check");
				continue;
			}
			DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Checking AcceptPeace at index {item} for kingdom {text}");
			for (int j = 0; j < actions.Count; j++)
			{
				if (j == item)
				{
					continue;
				}
				DiplomaticAction diplomaticAction = actions[j];
				string text2 = ((j < targetKingdomIds.Count) ? targetKingdomIds[j] : null);
				if (diplomaticAction == DiplomaticAction.RejectTribute || diplomaticAction == DiplomaticAction.RejectReparations)
				{
					if (text2 == text)
					{
						flag = true;
						DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Found inconsistency: AcceptPeace for {text} at index {item} conflicts with {diplomaticAction} for {text2} at index {j}");
						break;
					}
					DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] No conflict: AcceptPeace for {text} at index {item}, but {diplomaticAction} is for different kingdom {text2} at index {j}");
				}
			}
			if (!flag)
			{
				continue;
			}
			break;
		}
		if (flag)
		{
			List<DiplomaticAction> list2 = actions.Where((DiplomaticAction a) => a != DiplomaticAction.AcceptPeace).ToList();
			if (!list2.Contains(DiplomaticAction.RejectPeace))
			{
				int num = list[0];
				if (num < list2.Count)
				{
					list2.Insert(num, DiplomaticAction.RejectPeace);
				}
				else
				{
					list2.Insert(0, DiplomaticAction.RejectPeace);
				}
			}
			DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] Adjusted inconsistent peace package for {((kingdom != null) ? kingdom.Name : null)}: AcceptPeace + rejects for same kingdom -> RejectPeace");
			return list2;
		}
		return actions;
	}

	private List<ActionTargetPair> ValidateActionsWithTargets(Kingdom kingdom, List<string> targetKingdomIds, List<DiplomaticAction> actions, DynamicEvent diplomaticEvent)
	{
		List<ActionTargetPair> list = new List<ActionTargetPair>();
		if (actions == null || actions.Count == 0)
		{
			return list;
		}
		AllianceSystem allianceSystem = _diplomacyManager.GetAllianceSystem();
		for (int i = 0; i < actions.Count; i++)
		{
			DiplomaticAction diplomaticAction = actions[i];
			string text = ((targetKingdomIds != null && i < targetKingdomIds.Count) ? targetKingdomIds[i] : ((targetKingdomIds != null && targetKingdomIds.Any()) ? targetKingdomIds[0] : null));
			List<string> targetKingdomIds2 = ((text != null) ? new List<string> { text } : targetKingdomIds);
			bool flag = false;
			switch (diplomaticAction)
			{
			case DiplomaticAction.ProposePeace:
				flag = text != null && IsAtWarWithAnyTargets(kingdom, targetKingdomIds2);
				if (!flag)
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping propose_peace for {0} - not at war with target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.RejectPeace:
			case DiplomaticAction.AcceptPeace:
				flag = text != null && IsAtWarWithAnyTargets(kingdom, targetKingdomIds2) && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.ProposePeace, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptPeace,
					DiplomaticAction.RejectPeace
				});
				if (!flag)
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping {0} for {1} - no active peace proposal or not at war with target ({2})", diplomaticAction, (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.BreakAlliance:
				flag = text != null && IsAlliedWithAnyTargets(kingdom, targetKingdomIds2, allianceSystem);
				if (!flag)
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping break_alliance for {0} - no alliance with target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.ProposeAlliance:
				flag = text != null && !IsAlliedWithAnyTargets(kingdom, targetKingdomIds2, allianceSystem);
				if (!flag)
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping propose_alliance for {0} - already allied with target or no target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.RejectAlliance:
			case DiplomaticAction.AcceptAlliance:
				flag = text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.ProposeAlliance, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptAlliance,
					DiplomaticAction.RejectAlliance
				});
				if (!flag)
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping {0} for {1} - no active alliance proposal from target ({2})", diplomaticAction, (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.ProposeTradeAgreement:
				if (text != null)
				{
					TradeAgreementSystem tradeAgreementSystem = _diplomacyManager.GetTradeAgreementSystem();
					Kingdom kingdomById = GetKingdomById(text);
					if (kingdomById != null && tradeAgreementSystem.HasTradeAgreement(kingdom, kingdomById, out var endTime))
					{
						float num = (endTime).RemainingDaysFromNow / (float)CampaignTime.DaysInYear;
						DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] {((kingdom != null) ? kingdom.Name : null)} proposing trade agreement extension with {kingdomById.Name} (current agreement expires in {num:F1} years)");
					}
				}
				flag = true;
				break;
			case DiplomaticAction.AcceptTradeAgreement:
			{
				bool flag2 = text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.ProposeTradeAgreement, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptTradeAgreement,
					DiplomaticAction.RejectTradeAgreement
				});
				bool flag3 = false;
				if (!flag2 && text != null)
				{
					TradeAgreementSystem tradeAgreementSystem2 = _diplomacyManager.GetTradeAgreementSystem();
					Kingdom kingdomById2 = GetKingdomById(text);
					if (kingdomById2 != null && tradeAgreementSystem2.HasTradeAgreement(kingdom, kingdomById2, out var endTime2))
					{
						flag3 = true;
						float num2 = (endTime2).RemainingDaysFromNow / (float)CampaignTime.DaysInYear;
						DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] {((kingdom != null) ? kingdom.Name : null)} accepting trade agreement extension with {kingdomById2.Name} (current agreement expires in {num2:F1} years)");
					}
				}
				flag = flag2 || flag3;
				if (!flag)
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping accept_trade_agreement for {0} - no active trade agreement proposal and no existing agreement with target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			}
			case DiplomaticAction.RejectTradeAgreement:
				flag = text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.ProposeTradeAgreement, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptTradeAgreement,
					DiplomaticAction.RejectTradeAgreement
				});
				if (!flag)
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping reject_trade_agreement for {0} - no active trade agreement proposal from target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.DemandTribute:
				flag = true;
				break;
			case DiplomaticAction.AcceptTribute:
			case DiplomaticAction.RejectTribute:
				flag = text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.DemandTribute, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptTribute,
					DiplomaticAction.RejectTribute
				});
				if (!flag)
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping {0} for {1} - no active tribute demand from target ({2})", diplomaticAction, (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.DemandReparations:
				flag = true;
				break;
			case DiplomaticAction.AcceptReparations:
			case DiplomaticAction.RejectReparations:
				flag = text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.DemandReparations, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptReparations,
					DiplomaticAction.RejectReparations
				});
				if (!flag)
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping {0} for {1} - no active reparations demand from target ({2})", diplomaticAction, (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.DemandTerritory:
				flag = true;
				break;
			case DiplomaticAction.TransferTerritory:
				flag = text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.DemandTerritory, new List<DiplomaticAction>
				{
					DiplomaticAction.TransferTerritory,
					DiplomaticAction.RejectTerritory
				});
				if (!flag)
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping transfer_territory for {0} - no active territory demand from target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.RejectTerritory:
				flag = text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.DemandTerritory, new List<DiplomaticAction>
				{
					DiplomaticAction.TransferTerritory,
					DiplomaticAction.RejectTerritory
				});
				if (!flag)
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping reject_territory for {0} - no active territory demand from target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			default:
				flag = true;
				break;
			}
			if (flag)
			{
				list.Add(new ActionTargetPair
				{
					Action = diplomaticAction,
					TargetKingdomId = text
				});
			}
		}
		return list.Any() ? list : new List<ActionTargetPair>
		{
			new ActionTargetPair
			{
				Action = DiplomaticAction.None,
				TargetKingdomId = null
			}
		};
	}

	private List<DiplomaticAction> ValidateActionsAgainstDiplomaticState(Kingdom kingdom, List<string> targetKingdomIds, List<DiplomaticAction> actions, DynamicEvent diplomaticEvent)
	{
		if (actions == null || actions.Count == 0)
		{
			return new List<DiplomaticAction> { DiplomaticAction.None };
		}
		List<DiplomaticAction> list = new List<DiplomaticAction>();
		AllianceSystem allianceSystem = _diplomacyManager.GetAllianceSystem();
		for (int i = 0; i < actions.Count; i++)
		{
			DiplomaticAction diplomaticAction = actions[i];
			string text = ((targetKingdomIds != null && i < targetKingdomIds.Count) ? targetKingdomIds[i] : ((targetKingdomIds != null && targetKingdomIds.Any()) ? targetKingdomIds[0] : null));
			List<string> targetKingdomIds2 = ((text != null) ? new List<string> { text } : targetKingdomIds);
			switch (diplomaticAction)
			{
			case DiplomaticAction.ProposePeace:
				if (text != null && IsAtWarWithAnyTargets(kingdom, targetKingdomIds2))
				{
					list.Add(diplomaticAction);
				}
				else
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping propose_peace for {0} - not at war with target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.RejectPeace:
			case DiplomaticAction.AcceptPeace:
				if (text != null && IsAtWarWithAnyTargets(kingdom, targetKingdomIds2) && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.ProposePeace, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptPeace,
					DiplomaticAction.RejectPeace
				}))
				{
					list.Add(diplomaticAction);
				}
				else
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping {0} for {1} - no active peace proposal or not at war with target ({2})", diplomaticAction, (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.BreakAlliance:
				if (text != null && IsAlliedWithAnyTargets(kingdom, targetKingdomIds2, allianceSystem))
				{
					list.Add(diplomaticAction);
				}
				else
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping break_alliance for {0} - no alliance with target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.ProposeAlliance:
				if (text != null && !IsAlliedWithAnyTargets(kingdom, targetKingdomIds2, allianceSystem))
				{
					list.Add(diplomaticAction);
				}
				else
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping propose_alliance for {0} - already allied with target or no target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.RejectAlliance:
			case DiplomaticAction.AcceptAlliance:
				if (text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.ProposeAlliance, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptAlliance,
					DiplomaticAction.RejectAlliance
				}))
				{
					list.Add(diplomaticAction);
				}
				else
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping {0} for {1} - no active alliance proposal from target ({2})", diplomaticAction, (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.ProposeTradeAgreement:
				if (text != null)
				{
					TradeAgreementSystem tradeAgreementSystem2 = _diplomacyManager.GetTradeAgreementSystem();
					Kingdom kingdomById2 = GetKingdomById(text);
					if (kingdomById2 != null && tradeAgreementSystem2.HasTradeAgreement(kingdom, kingdomById2, out var endTime2))
					{
						float num2 = (endTime2).RemainingDaysFromNow / (float)CampaignTime.DaysInYear;
						DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] {((kingdom != null) ? kingdom.Name : null)} proposing trade agreement extension with {kingdomById2.Name} (current agreement expires in {num2:F1} years)");
					}
				}
				list.Add(diplomaticAction);
				break;
			case DiplomaticAction.AcceptTradeAgreement:
			{
				bool flag = text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.ProposeTradeAgreement, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptTradeAgreement,
					DiplomaticAction.RejectTradeAgreement
				});
				bool flag2 = false;
				if (!flag && text != null)
				{
					TradeAgreementSystem tradeAgreementSystem = _diplomacyManager.GetTradeAgreementSystem();
					Kingdom kingdomById = GetKingdomById(text);
					if (kingdomById != null && tradeAgreementSystem.HasTradeAgreement(kingdom, kingdomById, out var endTime))
					{
						flag2 = true;
						float num = (endTime).RemainingDaysFromNow / (float)CampaignTime.DaysInYear;
						DiplomacyLogger.Instance.Log($"[STATEMENT_GEN] {((kingdom != null) ? kingdom.Name : null)} accepting trade agreement extension with {kingdomById.Name} (current agreement expires in {num:F1} years)");
					}
				}
				if (flag || flag2)
				{
					list.Add(diplomaticAction);
				}
				else
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping accept_trade_agreement for {0} - no active trade agreement proposal and no existing agreement with target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			}
			case DiplomaticAction.RejectTradeAgreement:
				if (text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.ProposeTradeAgreement, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptTradeAgreement,
					DiplomaticAction.RejectTradeAgreement
				}))
				{
					list.Add(diplomaticAction);
				}
				else
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping reject_trade_agreement for {0} - no active trade agreement proposal from target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.DemandTribute:
				list.Add(diplomaticAction);
				break;
			case DiplomaticAction.AcceptTribute:
			case DiplomaticAction.RejectTribute:
				if (text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.DemandTribute, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptTribute,
					DiplomaticAction.RejectTribute
				}))
				{
					list.Add(diplomaticAction);
				}
				else
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping {0} for {1} - no active tribute demand from target ({2})", diplomaticAction, (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.DemandReparations:
				list.Add(diplomaticAction);
				break;
			case DiplomaticAction.AcceptReparations:
			case DiplomaticAction.RejectReparations:
				if (text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.DemandReparations, new List<DiplomaticAction>
				{
					DiplomaticAction.AcceptReparations,
					DiplomaticAction.RejectReparations
				}))
				{
					list.Add(diplomaticAction);
				}
				else
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping {0} for {1} - no active reparations demand from target ({2})", diplomaticAction, (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.DemandTerritory:
				list.Add(diplomaticAction);
				break;
			case DiplomaticAction.TransferTerritory:
				if (text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.DemandTerritory, new List<DiplomaticAction>
				{
					DiplomaticAction.TransferTerritory,
					DiplomaticAction.RejectTerritory
				}))
				{
					list.Add(diplomaticAction);
				}
				else
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping transfer_territory for {0} - no active territory demand from target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			case DiplomaticAction.RejectTerritory:
				if (text != null && HasActiveProposal(diplomaticEvent, targetKingdomIds2, ((MBObjectBase)kingdom).StringId, DiplomaticAction.DemandTerritory, new List<DiplomaticAction>
				{
					DiplomaticAction.TransferTerritory,
					DiplomaticAction.RejectTerritory
				}))
				{
					list.Add(diplomaticAction);
				}
				else
				{
					DiplomacyLogger.Instance.Log(string.Format("[STATEMENT_GEN] Dropping reject_territory for {0} - no active territory demand from target ({1})", (kingdom != null) ? kingdom.Name : null, text ?? "none"));
				}
				break;
			default:
				list.Add(diplomaticAction);
				break;
			}
		}
		return list.Any() ? list : new List<DiplomaticAction> { DiplomaticAction.None };
	}

	private bool HasActiveProposal(DynamicEvent diplomaticEvent, List<string> targetKingdomIds, string receiverKingdomId, DiplomaticAction proposalAction, List<DiplomaticAction> resolutionActions)
	{
		if (diplomaticEvent?.KingdomStatements == null || !diplomaticEvent.KingdomStatements.Any() || targetKingdomIds == null || targetKingdomIds.Count == 0)
		{
			return false;
		}
		IEnumerable<DiplomaticAction> collection;
		if (proposalAction != DiplomaticAction.None)
		{
			IEnumerable<DiplomaticAction> enumerable = new DiplomaticAction[1] { proposalAction };
			collection = enumerable;
		}
		else
		{
			collection = Enumerable.Empty<DiplomaticAction>();
		}
		HashSet<DiplomaticAction> proposalActions = new HashSet<DiplomaticAction>(collection);
		HashSet<DiplomaticAction> resolutionActions2 = new HashSet<DiplomaticAction>(resolutionActions ?? new List<DiplomaticAction>());
		foreach (string targetKingdomId in targetKingdomIds)
		{
			if (HasActiveProposalBetween(diplomaticEvent.KingdomStatements, targetKingdomId, receiverKingdomId, proposalActions, resolutionActions2))
			{
				return true;
			}
		}
		return false;
	}

	private bool HasActiveProposalBetween(IEnumerable<KingdomStatement> statements, string proposerId, string receiverId, HashSet<DiplomaticAction> proposalActions, HashSet<DiplomaticAction> resolutionActions)
	{
		if (statements == null)
		{
			return false;
		}
		List<KingdomStatement> list = (from s in statements
			where IsBetweenPair(s, proposerId, receiverId)
			orderby s.Timestamp
			select s).ToList();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			KingdomStatement kingdomStatement = list[num];
			List<DiplomaticAction> source = ((kingdomStatement.Actions != null && kingdomStatement.Actions.Any()) ? kingdomStatement.Actions : new List<DiplomaticAction> { kingdomStatement.Action });
			bool flag = TargetsKingdom(kingdomStatement, receiverId);
			if (kingdomStatement.KingdomId == receiverId && source.Any((DiplomaticAction a) => resolutionActions.Contains(a)) && flag)
			{
				return false;
			}
			if (kingdomStatement.KingdomId == proposerId && flag && source.Any((DiplomaticAction a) => proposalActions.Contains(a)))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsBetweenPair(KingdomStatement statement, string kingdomA, string kingdomB)
	{
		if (statement == null)
		{
			return false;
		}
		bool flag = statement.KingdomId == kingdomA;
		bool flag2 = statement.KingdomId == kingdomB;
		bool flag3 = TargetsKingdom(statement, kingdomA);
		bool flag4 = TargetsKingdom(statement, kingdomB);
		return (flag && flag4) || (flag2 && flag3);
	}

	private bool TargetsKingdom(KingdomStatement statement, string kingdomId)
	{
		if (statement == null || string.IsNullOrEmpty(kingdomId))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(statement.TargetKingdomId) && statement.TargetKingdomId == kingdomId)
		{
			return true;
		}
		if (statement.TargetKingdomIds != null && statement.TargetKingdomIds.Contains(kingdomId))
		{
			return true;
		}
		return false;
	}

	private bool IsAtWarWithAnyTargets(Kingdom kingdom, List<string> targetKingdomIds)
	{
		if (kingdom == null || targetKingdomIds == null || targetKingdomIds.Count == 0)
		{
			return false;
		}
		foreach (string targetKingdomId in targetKingdomIds)
		{
			Kingdom kingdomById = GetKingdomById(targetKingdomId);
			if (kingdomById != null && FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)kingdomById))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsAlliedWithAnyTargets(Kingdom kingdom, List<string> targetKingdomIds, AllianceSystem allianceSystem)
	{
		if (kingdom == null || targetKingdomIds == null || targetKingdomIds.Count == 0 || allianceSystem == null)
		{
			return false;
		}
		foreach (string targetKingdomId in targetKingdomIds)
		{
			Kingdom kingdomById = GetKingdomById(targetKingdomId);
			if (kingdomById != null && allianceSystem.AreAllied(kingdom, kingdomById))
			{
				return true;
			}
		}
		return false;
	}

	private List<string> GetAllActiveProposalsForKingdom(Kingdom kingdom, DynamicEvent currentEvent)
	{
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		try
		{
			List<DynamicEvent> list2 = DynamicEventsManager.Instance?.GetActiveEvents();
			if (list2 == null || !list2.Any())
			{
				return list;
			}
			List<DynamicEvent> list3 = list2.Where((DynamicEvent e) => e != null && e.Type == "Diplomatic" && !e.IsExpired()).ToList();
			foreach (DynamicEvent item2 in list3)
			{
				if (item2.KingdomStatements == null || !item2.KingdomStatements.Any())
				{
					continue;
				}
				foreach (KingdomStatement statement in item2.KingdomStatements)
				{
					if (statement.KingdomId != ((MBObjectBase)kingdom).StringId)
					{
						continue;
					}
					List<DiplomaticAction> list4 = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
					List<string> list5 = new List<string>();
					if (statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any())
					{
						list5 = statement.TargetKingdomIds;
					}
					else if (!string.IsNullOrEmpty(statement.TargetKingdomId))
					{
						list5 = new List<string> { statement.TargetKingdomId };
					}
					for (int num = 0; num < list4.Count; num++)
					{
						DiplomaticAction action = list4[num];
						if (action != DiplomaticAction.ProposeAlliance && action != DiplomaticAction.ProposePeace && action != DiplomaticAction.ProposeTradeAgreement && action != DiplomaticAction.DemandTerritory && action != DiplomaticAction.DemandTribute && action != DiplomaticAction.DemandReparations)
						{
							continue;
						}
						string targetKingdomId = null;
						if (list5.Count > 1 && num < list5.Count)
						{
							targetKingdomId = list5[num];
						}
						else if (list5.Count == 1)
						{
							targetKingdomId = list5[0];
						}
						if (string.IsNullOrEmpty(targetKingdomId))
						{
							continue;
						}
						Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == targetKingdomId && !k.IsEliminated));
						string targetKingdomName = ((val == null) ? null : ((object)val.Name)?.ToString()) ?? targetKingdomId;
						if (!item2.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == targetKingdomId && GetResponseActionsForProposal(action).Contains(s.Action) && (s.TargetKingdomId == ((MBObjectBase)kingdom).StringId || (s.TargetKingdomIds != null && s.TargetKingdomIds.Contains(((MBObjectBase)kingdom).StringId))) && s.Timestamp > statement.Timestamp))
						{
							int daysAgo = 0;
							_ = CampaignTime.Now;
							_ = statement.Timestamp;
							if (true)
							{
								CampaignTime val2 = CampaignTime.Now;
								double toDays = (val2).ToDays;
								val2 = statement.Timestamp;
								daysAgo = Math.Max(0, (int)(toDays - (val2).ToDays));
							}
							string item = FormatProposalDescription(action, targetKingdomName, targetKingdomId, statement, daysAgo, item2.Id);
							list.Add(item);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[GetAllActiveProposals] Error: " + ex.Message);
		}
		return list;
	}

	private List<DiplomaticAction> GetResponseActionsForProposal(DiplomaticAction proposalAction)
	{
		return proposalAction switch
		{
			DiplomaticAction.ProposeAlliance => new List<DiplomaticAction>
			{
				DiplomaticAction.AcceptAlliance,
				DiplomaticAction.RejectAlliance
			}, 
			DiplomaticAction.ProposePeace => new List<DiplomaticAction>
			{
				DiplomaticAction.AcceptPeace,
				DiplomaticAction.RejectPeace
			}, 
			DiplomaticAction.ProposeTradeAgreement => new List<DiplomaticAction>
			{
				DiplomaticAction.AcceptTradeAgreement,
				DiplomaticAction.RejectTradeAgreement
			}, 
			DiplomaticAction.DemandTerritory => new List<DiplomaticAction>
			{
				DiplomaticAction.TransferTerritory,
				DiplomaticAction.RejectTerritory
			}, 
			DiplomaticAction.DemandTribute => new List<DiplomaticAction>
			{
				DiplomaticAction.AcceptTribute,
				DiplomaticAction.RejectTribute
			}, 
			DiplomaticAction.DemandReparations => new List<DiplomaticAction>
			{
				DiplomaticAction.AcceptReparations,
				DiplomaticAction.RejectReparations
			}, 
			_ => new List<DiplomaticAction>(), 
		};
	}

	private string FormatProposalDescription(DiplomaticAction action, string targetKingdomName, string targetKingdomId, KingdomStatement statement, int daysAgo, string eventId)
	{
		string actionName = GetActionName(action);
		string text = ((eventId != null) ? ("Event [" + eventId + "]") : "Event [Unknown]");
		string result = $"{text}: You {actionName} to {targetKingdomName} (string_id:{targetKingdomId}) - {daysAgo} days ago (PENDING)";
		switch (action)
		{
		case DiplomaticAction.DemandTerritory:
			if (!string.IsNullOrEmpty(statement.SettlementId))
			{
				Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == statement.SettlementId));
				string text2 = ((val == null) ? null : ((object)val.Name)?.ToString()) ?? statement.SettlementId;
				result = $"{text}: You demanded TERRITORY: {text2} (string_id:{statement.SettlementId}) from {targetKingdomName} (string_id:{targetKingdomId}) - {daysAgo} days ago (PENDING)";
			}
			break;
		case DiplomaticAction.DemandTribute:
			if (statement.DailyTributeAmount > 0)
			{
				result = $"{text}: You demanded TRIBUTE: {statement.DailyTributeAmount} gold/day for {statement.TributeDurationDays} days from {targetKingdomName} (string_id:{targetKingdomId}) - {daysAgo} days ago (PENDING)";
			}
			break;
		case DiplomaticAction.DemandReparations:
			if (statement.ReparationsAmount > 0)
			{
				result = $"{text}: You demanded WAR REPARATIONS: {statement.ReparationsAmount} gold from {targetKingdomName} (string_id:{targetKingdomId}) - {daysAgo} days ago (PENDING)";
			}
			break;
		}
		return result;
	}

	private string GetActionName(DiplomaticAction action)
	{
		return action switch
		{
			DiplomaticAction.ProposeAlliance => "proposed ALLIANCE", 
			DiplomaticAction.ProposePeace => "proposed PEACE", 
			DiplomaticAction.ProposeTradeAgreement => "proposed TRADE AGREEMENT", 
			DiplomaticAction.DemandTerritory => "demanded TERRITORY", 
			DiplomaticAction.DemandTribute => "demanded TRIBUTE", 
			DiplomaticAction.DemandReparations => "demanded WAR REPARATIONS", 
			_ => action.ToString().ToLower().Replace("_", " "), 
		};
	}

	private List<string> GetPendingProposalsForKingdom(Kingdom kingdom, DynamicEvent diplomaticEvent)
	{
		List<string> list = new List<string>();
		List<(KingdomStatement, string)> list2 = new List<(KingdomStatement, string)>();
		DiplomaticStatementsStorage instance = DiplomaticStatementsStorage.Instance;
		if (instance != null)
		{
			List<KingdomStatement> recentStatements = instance.GetRecentStatements();
			foreach (KingdomStatement item in recentStatements)
			{
				list2.Add((item, item.EventId ?? ""));
			}
			DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] Loaded {recentStatements.Count} statements from DiplomaticStatementsStorage");
		}
		List<DynamicEvent> list3 = DynamicEventsManager.Instance?.GetActiveEvents() ?? new List<DynamicEvent>();
		foreach (DynamicEvent item2 in list3)
		{
			if (item2.KingdomStatements == null || !item2.KingdomStatements.Any())
			{
				continue;
			}
			foreach (KingdomStatement stmt in item2.KingdomStatements)
			{
				if (string.IsNullOrEmpty(stmt.EventId) && !string.IsNullOrEmpty(item2.Id))
				{
					stmt.EventId = item2.Id;
				}
				if (!list2.Any<(KingdomStatement, string)>(((KingdomStatement statement, string eventId) s) => s.statement.KingdomId == stmt.KingdomId && s.statement.CampaignDays == stmt.CampaignDays && s.statement.Action == stmt.Action && s.statement.TargetKingdomId == stmt.TargetKingdomId))
				{
					list2.Add((stmt, item2.Id));
				}
			}
		}
		if (!list2.Any())
		{
			DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] No statements found for {kingdom.Name}");
			return list;
		}
		DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] Checking pending proposals for {kingdom.Name} (string_id:{((MBObjectBase)kingdom).StringId}). Total statements: {list2.Count} (from storage + events in memory)");
		foreach (var item3 in list2)
		{
			var (statement, text) = item3;
			if (statement.KingdomId == ((MBObjectBase)kingdom).StringId)
			{
				DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] Skipping own statement from {kingdom.Name}");
				continue;
			}
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == statement.KingdomId && !k.IsEliminated));
			if (val == null)
			{
				DiplomacyLogger.Instance.Log("[PENDING_PROPOSALS] Skipping statement from eliminated kingdom (string_id:" + statement.KingdomId + ")");
				continue;
			}
			string text2 = ((object)val.Name)?.ToString() ?? statement.KingdomId;
			string text3 = ((!string.IsNullOrEmpty(statement.EventId)) ? statement.EventId : text);
			string text4 = ((!string.IsNullOrEmpty(text3)) ? (" (eventId:" + text3 + ")") : " (no eventId)");
			string text5 = ((text3 == diplomaticEvent.Id) ? " [CURRENT EVENT]" : " [OTHER EVENT]");
			DiplomacyLogger.Instance.Log(string.Format("[PENDING_PROPOSALS] Checking statement from {0} (string_id:{1}){2}{3}, Action={4}, Actions={5}, TargetKingdomId={6}, TargetKingdomIds={7}", text2, statement.KingdomId, text4, text5, statement.Action, string.Join(",", statement.Actions ?? new List<DiplomaticAction>()), statement.TargetKingdomId, string.Join(",", statement.TargetKingdomIds ?? new List<string>())));
			List<DiplomaticAction> list4 = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
			List<string> list5 = new List<string>();
			if (statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any())
			{
				list5 = statement.TargetKingdomIds;
			}
			else if (!string.IsNullOrEmpty(statement.TargetKingdomId))
			{
				list5 = new List<string> { statement.TargetKingdomId };
			}
			for (int num = 0; num < list4.Count; num++)
			{
				DiplomaticAction diplomaticAction = list4[num];
				string text6 = null;
				if (list5.Count > 1 && num < list5.Count)
				{
					text6 = list5[num];
				}
				else
				{
					if (list5.Count != 1)
					{
						continue;
					}
					text6 = list5[0];
				}
				DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] Action {diplomaticAction} (index {num}) targets {text6}, current kingdom is {((MBObjectBase)kingdom).StringId}");
				if (text6 != ((MBObjectBase)kingdom).StringId)
				{
					DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] Action {diplomaticAction} (index {num}) is not directed at {kingdom.Name}, skipping");
					continue;
				}
				bool flag = false;
				AllianceSystem allianceSystem = _diplomacyManager?.GetAllianceSystem();
				bool flag2 = val != null && allianceSystem != null && allianceSystem.AreAllied(kingdom, val);
				bool flag3 = val != null && !FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)val);
				switch (diplomaticAction)
				{
				case DiplomaticAction.ProposeAlliance:
					if (flag2)
					{
						flag = true;
						DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] ProposeAlliance from {text2} to {kingdom.Name} is obsolete - kingdoms are already allied");
						break;
					}
					flag = list3.Any((DynamicEvent e) => e.KingdomStatements != null && e.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)kingdom).StringId && (s.Action == DiplomaticAction.AcceptAlliance || s.Action == DiplomaticAction.RejectAlliance || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptAlliance) || s.Actions.Contains(DiplomaticAction.RejectAlliance)))) && (s.TargetKingdomId == statement.KingdomId || (s.TargetKingdomIds != null && s.TargetKingdomIds.Contains(statement.KingdomId)))));
					break;
				case DiplomaticAction.ProposePeace:
					if (flag3)
					{
						flag = true;
						DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] ProposePeace from {text2} to {kingdom.Name} is obsolete - kingdoms are already at peace");
						break;
					}
					flag = list3.Any((DynamicEvent e) => e.KingdomStatements != null && e.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)kingdom).StringId && (s.Action == DiplomaticAction.AcceptPeace || s.Action == DiplomaticAction.RejectPeace || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptPeace) || s.Actions.Contains(DiplomaticAction.RejectPeace)))) && (s.TargetKingdomId == statement.KingdomId || (s.TargetKingdomIds != null && s.TargetKingdomIds.Contains(statement.KingdomId)))));
					break;
				case DiplomaticAction.ProposeTradeAgreement:
					flag = list3.Any((DynamicEvent e) => e.KingdomStatements != null && e.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)kingdom).StringId && (s.Action == DiplomaticAction.AcceptTradeAgreement || s.Action == DiplomaticAction.RejectTradeAgreement || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptTradeAgreement) || s.Actions.Contains(DiplomaticAction.RejectTradeAgreement)))) && (s.TargetKingdomId == statement.KingdomId || (s.TargetKingdomIds != null && s.TargetKingdomIds.Contains(statement.KingdomId)))));
					if (!flag)
					{
						flag = list2.Any<(KingdomStatement, string)>(((KingdomStatement statement, string eventId) s) => s.statement.KingdomId == ((MBObjectBase)kingdom).StringId && (s.statement.Action == DiplomaticAction.AcceptTradeAgreement || s.statement.Action == DiplomaticAction.RejectTradeAgreement || (s.statement.Actions != null && (s.statement.Actions.Contains(DiplomaticAction.AcceptTradeAgreement) || s.statement.Actions.Contains(DiplomaticAction.RejectTradeAgreement)))) && (s.statement.TargetKingdomId == statement.KingdomId || (s.statement.TargetKingdomIds != null && s.statement.TargetKingdomIds.Contains(statement.KingdomId))));
						if (flag)
						{
							DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] ProposeTradeAgreement from {text2} to {kingdom.Name} found response in DiplomaticStatementsStorage (resolved event)");
						}
					}
					break;
				case DiplomaticAction.DemandTerritory:
					flag = list3.Any((DynamicEvent e) => e.KingdomStatements != null && e.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)kingdom).StringId && (s.Action == DiplomaticAction.TransferTerritory || (s.Actions != null && s.Actions.Contains(DiplomaticAction.TransferTerritory))) && s.TargetKingdomId == statement.KingdomId && s.SettlementId == statement.SettlementId));
					break;
				case DiplomaticAction.DemandTribute:
					flag = list3.Any((DynamicEvent e) => e.KingdomStatements != null && e.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)kingdom).StringId && (s.Action == DiplomaticAction.AcceptTribute || s.Action == DiplomaticAction.RejectTribute || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptTribute) || s.Actions.Contains(DiplomaticAction.RejectTribute)))) && (s.TargetKingdomId == statement.KingdomId || (s.TargetKingdomIds != null && s.TargetKingdomIds.Contains(statement.KingdomId)))));
					break;
				case DiplomaticAction.DemandReparations:
					flag = list3.Any((DynamicEvent e) => e.KingdomStatements != null && e.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)kingdom).StringId && (s.Action == DiplomaticAction.AcceptReparations || s.Action == DiplomaticAction.RejectReparations || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptReparations) || s.Actions.Contains(DiplomaticAction.RejectReparations)))) && (s.TargetKingdomId == statement.KingdomId || (s.TargetKingdomIds != null && s.TargetKingdomIds.Contains(statement.KingdomId)))));
					break;
				}
				DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] Action {diplomaticAction} from {text2} to {kingdom.Name}: alreadyResponded={flag}");
				if (flag)
				{
					continue;
				}
				bool flag4 = true;
				string text7 = "";
				switch (diplomaticAction)
				{
				case DiplomaticAction.DemandTerritory:
				{
					if (string.IsNullOrEmpty(statement.SettlementId))
					{
						flag4 = false;
						text7 = "empty settlement_id";
						break;
					}
					Settlement val2 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == statement.SettlementId));
					if (val2 == null)
					{
						flag4 = false;
						text7 = "settlement " + statement.SettlementId + " does not exist";
					}
					break;
				}
				case DiplomaticAction.DemandTribute:
					if (statement.DailyTributeAmount <= 0 || statement.TributeDurationDays <= 0)
					{
						flag4 = false;
						text7 = $"invalid amounts (daily: {statement.DailyTributeAmount}, duration: {statement.TributeDurationDays})";
					}
					break;
				case DiplomaticAction.DemandReparations:
					if (statement.ReparationsAmount <= 0)
					{
						flag4 = false;
						text7 = $"invalid amount ({statement.ReparationsAmount})";
					}
					break;
				}
				if (!flag4)
				{
					DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] SKIPPING INVALID proposal from {text2} to {kingdom.Name} ({diplomaticAction}): {text7}. This proposal will NOT be sent to AI analyzer.");
					continue;
				}
				switch (diplomaticAction)
				{
				case DiplomaticAction.ProposeAlliance:
					list.Add(text2 + " (string_id:" + statement.KingdomId + ") proposes ALLIANCE to you. You must respond with 'accept_alliance' or 'reject_alliance'.");
					DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] Added ALLIANCE proposal from {text2} to {kingdom.Name}");
					break;
				case DiplomaticAction.ProposePeace:
					list.Add(text2 + " (string_id:" + statement.KingdomId + ") proposes PEACE to you. You must respond with 'accept_peace' or 'reject_peace'.");
					DiplomacyLogger.Instance.Log($"[PENDING_PROPOSALS] Added PEACE proposal from {text2} to {kingdom.Name}");
					break;
				case DiplomaticAction.ProposeTradeAgreement:
					list.Add(text2 + " (string_id:" + statement.KingdomId + ") proposes TRADE AGREEMENT to you. You must respond with 'accept_trade_agreement' or 'reject_trade_agreement'.");
					break;
				case DiplomaticAction.DemandTerritory:
				{
					Settlement val3 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == statement.SettlementId));
					string text8 = ((val3 == null) ? null : ((object)val3.Name)?.ToString()) ?? statement.SettlementId;
					list.Add(text2 + " (string_id:" + statement.KingdomId + ") demands TERRITORY: " + text8 + " (string_id:" + statement.SettlementId + "). You must respond with 'transfer_territory' (accept, use same settlement_id) or 'reject_territory' (reject, use same settlement_id).");
					break;
				}
				case DiplomaticAction.DemandTribute:
					list.Add($"{text2} (string_id:{statement.KingdomId}) demands TRIBUTE: {statement.DailyTributeAmount} gold/day for {statement.TributeDurationDays} days. You must respond with 'accept_tribute' or 'reject_tribute'.");
					break;
				case DiplomaticAction.DemandReparations:
					list.Add($"{text2} (string_id:{statement.KingdomId}) demands WAR REPARATIONS: {statement.ReparationsAmount} gold. You must respond with 'accept_reparations' or 'reject_reparations'.");
					break;
				}
			}
		}
		DiplomacyLogger.Instance.Log(string.Format("[PENDING_PROPOSALS] Found {0} pending proposals for {1}: {2}", list.Count, kingdom.Name, string.Join("; ", list)));
		return list;
	}

	private string GetRelationDescription(int relation)
	{
		if (relation >= 85)
		{
			return "Close Allies - Strong trust, easy agreements, mutual support expected";
		}
		if (relation >= 70)
		{
			return "Trusted Friends - Good cooperation, favorable negotiations";
		}
		if (relation >= 50)
		{
			return "Friendly - Positive stance, open to proposals";
		}
		if (relation >= 30)
		{
			return "Cordial - Polite relations, neutral negotiations";
		}
		if (relation >= 10)
		{
			return "Neutral-Positive - Slightly favorable, cautious cooperation";
		}
		if (relation >= -10)
		{
			return "Neutral - Indifferent, purely practical approach";
		}
		if (relation >= -30)
		{
			return "Cool - Distant, skeptical of proposals";
		}
		if (relation >= -50)
		{
			return "Unfriendly - Negative stance, difficult negotiations";
		}
		if (relation >= -70)
		{
			return "Hostile - Strong animosity, cooperation very unlikely";
		}
		if (relation >= -85)
		{
			return "Bitter Enemies - Deep hatred, almost impossible to negotiate";
		}
		return "Sworn Foes - Absolute enmity, only force matters";
	}

	private string GetSeasonName(Seasons season)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected I4, but got Unknown
		return (int)season switch
		{
			0 => "Spring", 
			1 => "Summer", 
			2 => "Autumn", 
			3 => "Winter", 
			_ => "Unknown", 
		};
	}

	private int GetWarDuration(Kingdom kingdom1, Kingdom kingdom2)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			WarStatisticsTracker instance = WarStatisticsTracker.Instance;
			if (instance == null)
			{
				return 0;
			}
			KingdomWarStats kingdomStats = instance.GetKingdomStats(kingdom1);
			if (kingdomStats == null || !kingdomStats.WarsAgainstKingdoms.ContainsKey(((MBObjectBase)kingdom2).StringId))
			{
				return 0;
			}
			WarStatsAgainstKingdom warStatsAgainstKingdom = kingdomStats.WarsAgainstKingdoms[((MBObjectBase)kingdom2).StringId];
			CampaignTime val = CampaignTime.Now - warStatsAgainstKingdom.WarStartTime;
			int val2 = (int)(val).ToDays;
			return Math.Max(0, val2);
		}
		catch
		{
			return 0;
		}
	}

	private void ShowKingdomStatementToPlayer(Kingdom kingdom, KingdomStatement statement, DynamicEvent diplomaticEvent)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		try
		{
			string statementText = statement.StatementText;
			InformationManager.DisplayMessage(new InformationMessage(statementText, ExtraColors.KingdomColorMessage));
			Color val = Color.FromUint(12298820u);
			List<DiplomaticAction> list = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
			List<string> list2 = new List<string>();
			if (statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any())
			{
				list2 = statement.TargetKingdomIds;
			}
			else if (!string.IsNullOrEmpty(statement.TargetKingdomId))
			{
				list2 = new List<string> { statement.TargetKingdomId };
			}
			HashSet<DiplomaticAction> hashSet = new HashSet<DiplomaticAction>
			{
				DiplomaticAction.DeclareWar,
				DiplomaticAction.AcceptAlliance
			};
			for (int i = 0; i < list.Count; i++)
			{
				DiplomaticAction diplomaticAction = list[i];
				if (hashSet.Contains(diplomaticAction))
				{
					continue;
				}
				string text = null;
				if (list2.Count > 1 && i < list2.Count)
				{
					text = list2[i];
				}
				else
				{
					if (list2.Count != 1)
					{
						continue;
					}
					text = list2[0];
				}
				string text2 = FormatAction(statement, diplomaticAction, text);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					InformationManager.DisplayMessage(new InformationMessage(text2, val));
				}
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[STATEMENT_GEN] ERROR showing statement to player: " + ex.Message);
		}
	}

	private Color GetVanillaDiplomaticNotificationColor(KingdomStatement statement)
	{
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Kingdom kingdomById = GetKingdomById(statement.KingdomId);
			if (kingdomById == null)
			{
				return Color.White;
			}
			List<Kingdom> list = new List<Kingdom>();
			if (statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any())
			{
				foreach (string targetKingdomId in statement.TargetKingdomIds)
				{
					Kingdom kingdomById2 = GetKingdomById(targetKingdomId);
					if (kingdomById2 != null)
					{
						list.Add(kingdomById2);
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(statement.TargetKingdomId))
			{
				Kingdom kingdomById3 = GetKingdomById(statement.TargetKingdomId);
				if (kingdomById3 != null && !list.Contains(kingdomById3))
				{
					list.Add(kingdomById3);
				}
			}
			ChatNotificationType val = ((Clan.PlayerClan == null || Clan.PlayerClan.Kingdom == null) ? ((ChatNotificationType)8) : ((kingdomById != Clan.PlayerClan.Kingdom && !list.Contains(Clan.PlayerClan.Kingdom)) ? (((object)kingdomById != Clan.PlayerClan.MapFaction && !list.Any((Kingdom k) => (object)k == Clan.PlayerClan.MapFaction)) ? ((!list.Any((Kingdom k) => Clan.PlayerClan.MapFaction.IsAtWarWith((IFaction)(object)k)) && !Clan.PlayerClan.MapFaction.IsAtWarWith((IFaction)(object)kingdomById)) ? ((ChatNotificationType)9) : ((ChatNotificationType)10)) : ((ChatNotificationType)1)) : ((ChatNotificationType)2)));
			uint notificationColor = Campaign.Current.Models.DiplomacyModel.GetNotificationColor(val);
			return Color.FromUint(notificationColor);
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[STATEMENT_GEN] ERROR getting vanilla color: " + ex.Message);
			return Color.White;
		}
	}

	private string FormatAction(KingdomStatement statement, DiplomaticAction action, string targetKingdomId = null)
	{
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_0638: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		string sourceName = GetKingdomName(statement.KingdomId);
		List<string> list = new List<string>();
		if (!string.IsNullOrWhiteSpace(targetKingdomId))
		{
			string kingdomName = GetKingdomName(targetKingdomId);
			if (!string.IsNullOrWhiteSpace(kingdomName))
			{
				list.Add(kingdomName);
			}
		}
		else
		{
			if (statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any())
			{
				list.AddRange(statement.TargetKingdomIds.Select(GetKingdomName));
			}
			if (!string.IsNullOrWhiteSpace(statement.TargetKingdomId))
			{
				list.Add(GetKingdomName(statement.TargetKingdomId));
			}
		}
		if (action == DiplomaticAction.ExpelClan)
		{
			list.Clear();
			if (!string.IsNullOrWhiteSpace(statement.TargetClanId))
			{
				string clanName = GetClanName(statement.TargetClanId);
				if (!string.IsNullOrWhiteSpace(clanName))
				{
					list.Add(clanName);
				}
			}
		}
		list = list.Where((string t) => !string.IsNullOrWhiteSpace(t)).Distinct().ToList();
		list.RemoveAll((string t) => string.Equals(t, sourceName, StringComparison.OrdinalIgnoreCase));
		if (!list.Any())
		{
			return string.Empty;
		}
		string text = string.Join(", ", list);
		return action switch
		{
			DiplomaticAction.DeclareWar => ((object)new TextObject("{=AIInfluence_Action_DeclareWar}{SOURCE} declares war on {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.ProposePeace => ((object)new TextObject("{=AIInfluence_Action_ProposePeace}{SOURCE} proposes peace to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.AcceptPeace => ((object)new TextObject("{=AIInfluence_Action_AcceptPeace}{SOURCE} accepts peace with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.RejectPeace => ((object)new TextObject("{=AIInfluence_Action_RejectPeace}{SOURCE} rejects peace with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.ProposeAlliance => ((object)new TextObject("{=AIInfluence_Action_ProposeAlliance}{SOURCE} proposes alliance to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.AcceptAlliance => ((object)new TextObject("{=AIInfluence_Action_AcceptAlliance}{SOURCE} accepts alliance with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.RejectAlliance => ((object)new TextObject("{=AIInfluence_Action_RejectAlliance}{SOURCE} rejects alliance with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.BreakAlliance => ((object)new TextObject("{=AIInfluence_Action_BreakAlliance}{SOURCE} breaks alliance with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.ProposeTradeAgreement => ((object)new TextObject("{=AIInfluence_Action_ProposeTrade}{SOURCE} proposes trade agreement to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.AcceptTradeAgreement => ((object)new TextObject("{=AIInfluence_Action_AcceptTrade}{SOURCE} accepts trade agreement with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.RejectTradeAgreement => ((object)new TextObject("{=AIInfluence_Action_RejectTrade}{SOURCE} rejects trade agreement with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.EndTradeAgreement => ((object)new TextObject("{=AIInfluence_Action_EndTrade}{SOURCE} ends trade agreement with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.DemandTribute => ((object)new TextObject("{=AIInfluence_Action_DemandTribute}{SOURCE} demands tribute from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.AcceptTribute => ((object)new TextObject("{=AIInfluence_Action_AcceptTribute}{SOURCE} accepts tribute from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.RejectTribute => ((object)new TextObject("{=AIInfluence_Action_RejectTribute}{SOURCE} refuses tribute to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.EndTribute => ((object)new TextObject("{=AIInfluence_Action_EndTribute}{SOURCE} ends tribute to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.DemandReparations => ((object)new TextObject("{=AIInfluence_Action_DemandReparations}{SOURCE} demands reparations from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.AcceptReparations => ((object)new TextObject("{=AIInfluence_Action_AcceptReparations}{SOURCE} accepts reparations from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.RejectReparations => ((object)new TextObject("{=AIInfluence_Action_RejectReparations}{SOURCE} rejects reparations from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.TransferTerritory => ((object)new TextObject("{=AIInfluence_Action_TransferTerritory}{SOURCE} transfers territory to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.DemandTerritory => ((object)new TextObject("{=AIInfluence_Action_DemandTerritory}{SOURCE} demands territory from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.ExpelClan => ((object)new TextObject("{=AIInfluence_Action_ExpelClan}{SOURCE} expels a clan related to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.GrantFief => ((object)new TextObject("{=AIInfluence_Action_GrantFief}{SOURCE} grants a fief to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			DiplomaticAction.ReceiveFief => ((object)new TextObject("{=AIInfluence_Action_ReceiveFief}{SOURCE} receives a fief from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text)).ToString(), 
			_ => "", 
		};
	}

	private Kingdom GetKingdomById(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
		{
			return null;
		}
		string trimmed = id.Trim();
		MBObjectManager instance = MBObjectManager.Instance;
		Kingdom val = ((instance != null) ? instance.GetObject<Kingdom>(trimmed) : null);
		if (val == null)
		{
			val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => string.Equals(((MBObjectBase)k).StringId, trimmed, StringComparison.OrdinalIgnoreCase)));
		}
		if (val != null && val.IsEliminated)
		{
			return null;
		}
		return val;
	}

	private string GetKingdomName(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return "";
		}
		Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == id));
		if (val == null)
		{
			return id;
		}
		if (val.IsEliminated)
		{
			return $"{val.Name} [Destroyed]";
		}
		return ((object)val.Name).ToString();
	}

	private string GetClanName(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return "";
		}
		MBObjectManager instance = MBObjectManager.Instance;
		Clan val = ((instance != null) ? instance.GetObject<Clan>(id) : null) ?? ((IEnumerable<Clan>)Clan.All).FirstOrDefault((Func<Clan, bool>)((Clan c) => string.Equals(((MBObjectBase)c).StringId, id, StringComparison.OrdinalIgnoreCase)));
		return ((val == null) ? null : ((object)val.Name)?.ToString()) ?? id;
	}

	private void LogMessage(string message)
	{
		DiplomacyLogger.Instance.Log(message);
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

	public static void CleanupOldAndInvalidProposals()
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			List<DynamicEvent> list = DynamicEventsManager.Instance?.GetActiveEvents();
			if (list == null || !list.Any())
			{
				DiplomacyLogger.Instance.Log("[CLEANUP] No active events to clean");
				return;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			foreach (DynamicEvent item in list)
			{
				if (item?.KingdomStatements == null || !item.KingdomStatements.Any())
				{
					continue;
				}
				num2++;
				int num5 = 0;
				List<KingdomStatement> list2 = new List<KingdomStatement>();
				foreach (KingdomStatement statement in item.KingdomStatements)
				{
					bool flag = false;
					string text = "";
					_ = statement.Timestamp;
					_ = CampaignTime.Now;
					if (true)
					{
						CampaignTime val = CampaignTime.Now;
						double toDays = (val).ToDays;
						val = statement.Timestamp;
						int num6 = (int)(toDays - (val).ToDays);
						if (num6 > 30)
						{
							flag = true;
							text = $"proposal too old ({num6} days, max 30)";
							num3++;
						}
					}
					if (!flag)
					{
						List<DiplomaticAction> list3 = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
						using List<DiplomaticAction>.Enumerator enumerator3 = list3.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							switch (enumerator3.Current)
							{
							case DiplomaticAction.DemandTerritory:
							{
								if (string.IsNullOrEmpty(statement.SettlementId))
								{
									flag = true;
									text = "DemandTerritory with empty settlement_id";
									break;
								}
								Settlement val2 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == statement.SettlementId));
								if (val2 == null)
								{
									flag = true;
									text = "DemandTerritory with non-existent settlement_id: " + statement.SettlementId;
								}
								break;
							}
							case DiplomaticAction.DemandTribute:
								if (statement.DailyTributeAmount <= 0 || statement.TributeDurationDays <= 0)
								{
									flag = true;
									text = $"DemandTribute with invalid amounts (daily: {statement.DailyTributeAmount}, duration: {statement.TributeDurationDays})";
								}
								break;
							case DiplomaticAction.DemandReparations:
								if (statement.ReparationsAmount <= 0)
								{
									flag = true;
									text = $"DemandReparations with invalid amount: {statement.ReparationsAmount}";
								}
								break;
							}
							if (flag)
							{
								num4++;
								break;
							}
						}
					}
					if (flag)
					{
						list2.Add(statement);
						num5++;
						DiplomacyLogger.Instance.Log("[CLEANUP] Marked statement for removal from event " + item.Id + ": " + statement.KingdomId + " -> " + text);
					}
				}
				foreach (KingdomStatement item2 in list2)
				{
					item.KingdomStatements.Remove(item2);
					num++;
				}
				if (num5 > 0)
				{
					DiplomacyLogger.Instance.Log($"[CLEANUP] Removed {num5} statement(s) from event {item.Id}");
				}
			}
			DiplomacyLogger.Instance.Log($"[CLEANUP] Cleanup completed: processed {num2} events, removed {num} statement(s) total ({num3} old, {num4} invalid)");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[CLEANUP] ERROR during cleanup: " + ex.Message);
			DiplomacyLogger.Instance.LogError("KingdomStatementGenerator.CleanupOldAndInvalidProposals", "Failed to cleanup proposals", ex);
		}
	}

	[Obsolete("Use CleanupOldAndInvalidProposals instead")]
	public static void CleanupInvalidProposals()
	{
		CleanupOldAndInvalidProposals();
	}
}
