using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AIInfluence.API;
using AIInfluence.Diseases;
using AIInfluence.DynamicEvents;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class PlayerStatementAnalyzer
{
	private readonly DiplomacyManager _diplomacyManager;

	public PlayerStatementAnalyzer(DiplomacyManager diplomacyManager)
	{
		_diplomacyManager = diplomacyManager;
	}

	public async Task<PlayerStatementResult> AnalyzePlayerStatement(string playerText, Kingdom playerKingdom, List<DynamicEvent> activeDiplomaticEvents = null)
	{
		if (string.IsNullOrEmpty(playerText) || playerKingdom == null)
		{
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] Invalid input: playerText or playerKingdom is null");
			return null;
		}
		DiplomacyLogger.Instance.Log($"[PLAYER_ANALYZER] Analyzing statement from {playerKingdom.Name}");
		try
		{
			string prompt = GenerateAnalysisPrompt(playerText, playerKingdom, activeDiplomaticEvents);
			DiplomacyLogger.Instance.Log($"[PLAYER_ANALYZER] Sending analysis request to AI (prompt length: {prompt.Length})");
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] PROMPT SENT TO AI:");
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] -------------------");
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] " + prompt);
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] -------------------");
			OpenRouterCallResult rawResult = await AIInfluenceBehavior.Instance.SendAIRequestForFeature(prompt, "player_statement_analysis");
			string aiResponse = rawResult.Payload;
			if (!rawResult.Success || string.IsNullOrEmpty(aiResponse))
			{
				DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] Empty or failed AI response");
				return null;
			}
			DiplomacyLogger.Instance.Log($"[PLAYER_ANALYZER] Received AI response (length: {aiResponse.Length})");
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] AI RESPONSE:");
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] -------------------");
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] " + aiResponse);
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] -------------------");
			PlayerStatementResult result = ParseAIResponse(aiResponse, playerKingdom);
			if (result != null)
			{
				DiplomacyLogger.Instance.Log($"[PLAYER_ANALYZER] Analysis successful: Action={result.Action}, Target={result.TargetKingdomId}, Tone={result.Tone}");
			}
			else
			{
				DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] Failed to parse AI response");
			}
			return result;
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] ERROR: " + ex.Message);
			DiplomacyLogger.Instance.LogError("PlayerStatementAnalyzer.AnalyzePlayerStatement", "Failed to analyze player statement", ex);
			return null;
		}
	}

	private string GenerateAnalysisPrompt(string playerText, Kingdom playerKingdom, List<DynamicEvent> activeDiplomaticEvents = null)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("### PLAYER DIPLOMATIC STATEMENT ANALYSIS ###");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("You are analyzing a diplomatic statement made by a player's kingdom in Mount & Blade II: Bannerlord.");
		stringBuilder.AppendLine("Your task is to determine the diplomatic action and target kingdom based on the player's text.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### PLAYER'S KINGDOM ###");
		stringBuilder.AppendLine($"Kingdom: {playerKingdom.Name} ({((MBObjectBase)playerKingdom).StringId})");
		Hero leader = playerKingdom.Leader;
		stringBuilder.AppendLine("Leader: " + (((leader != null) ? ((object)leader.Name).ToString() : null) ?? "Unknown"));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### CURRENT DIPLOMATIC STATUS ###");
		List<Kingdom> list = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => FactionManager.IsAtWarAgainstFaction((IFaction)(object)playerKingdom, (IFaction)(object)k)).ToList();
		if (list.Any())
		{
			stringBuilder.AppendLine("Currently at war with:");
			foreach (Kingdom item in list)
			{
				stringBuilder.AppendLine($"  - {item.Name} ({((MBObjectBase)item).StringId})");
			}
		}
		else
		{
			stringBuilder.AppendLine("Currently at war with: None");
		}
		stringBuilder.AppendLine();
		AllianceSystem allianceSystem = _diplomacyManager.GetAllianceSystem();
		List<Kingdom> allies = allianceSystem.GetAllies(playerKingdom);
		if (allies.Any())
		{
			stringBuilder.AppendLine("Current allies:");
			foreach (Kingdom item2 in allies)
			{
				stringBuilder.AppendLine($"  - {item2.Name} ({((MBObjectBase)item2).StringId})");
			}
		}
		else
		{
			stringBuilder.AppendLine("Current allies: None");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### ALL KINGDOMS ###");
		stringBuilder.AppendLine("Available kingdoms for diplomatic actions:");
		foreach (Kingdom item3 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && k != playerKingdom))
		{
			stringBuilder.AppendLine($"  - {item3.Name} (string_id: {((MBObjectBase)item3).StringId})");
		}
		stringBuilder.AppendLine();
		List<string> pendingProposalsForPlayer = GetPendingProposalsForPlayer(playerKingdom, activeDiplomaticEvents);
		stringBuilder.AppendLine("### PENDING PROPOSALS (IMPORTANT!) ###");
		if (pendingProposalsForPlayer.Any())
		{
			stringBuilder.AppendLine("CRITICAL: You can suggest Accept/Reject actions ONLY for these REAL pending proposals:");
			foreach (string item4 in pendingProposalsForPlayer)
			{
				stringBuilder.AppendLine("- " + item4);
			}
		}
		else
		{
			stringBuilder.AppendLine("No pending proposals from other kingdoms.");
			stringBuilder.AppendLine("You can ONLY use actions like declare_war, propose_peace, propose_alliance, break_alliance, or none.");
			stringBuilder.AppendLine("Accept/Reject actions are NOT available because no kingdoms have made proposals to you!");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### PLAYER'S STATEMENT ###");
		stringBuilder.AppendLine(playerText);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### YOUR TASK ###");
		stringBuilder.AppendLine("Analyze the player's statement and determine:");
		stringBuilder.AppendLine("1. **Diplomatic Action** - what the player wants to do");
		stringBuilder.AppendLine("2. **Target Kingdom** - which kingdom is the target (use string_id)");
		stringBuilder.AppendLine("3. **Tone** - the tone of the statement (aggressive, diplomatic, defensive, neutral)");
		stringBuilder.AppendLine("4. **Reason** - extract or summarize the reason for this action (1-2 sentences)");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### AVAILABLE ACTIONS ###");
		stringBuilder.AppendLine("Basic Diplomatic Actions:");
		stringBuilder.AppendLine("- 'declare_war' - Player wants to declare war");
		stringBuilder.AppendLine("  WARNING: If player declares war on an ally, the alliance will be AUTOMATICALLY BROKEN");
		stringBuilder.AppendLine("- 'propose_peace' - Player proposes peace (must be at war with target)");
		stringBuilder.AppendLine("- 'propose_alliance' - Player proposes alliance");
		stringBuilder.AppendLine("- 'break_alliance' - Player breaks an existing alliance (unilateral action, no proposal needed)");
		stringBuilder.AppendLine();
		bool flag = pendingProposalsForPlayer.Any((string p) => p.Contains("PEACE"));
		bool flag2 = pendingProposalsForPlayer.Any((string p) => p.Contains("ALLIANCE"));
		bool flag3 = pendingProposalsForPlayer.Any((string p) => p.Contains("TRADE AGREEMENT"));
		bool flag4 = pendingProposalsForPlayer.Any((string p) => p.Contains("TERRITORY"));
		bool flag5 = pendingProposalsForPlayer.Any((string p) => p.Contains("TRIBUTE"));
		bool flag6 = pendingProposalsForPlayer.Any((string p) => p.Contains("REPARATIONS"));
		stringBuilder.AppendLine("Response Actions (ONLY if there are corresponding proposals in PENDING PROPOSALS):");
		if (flag)
		{
			stringBuilder.AppendLine("- 'accept_peace' - Accept a peace proposal ✓ AVAILABLE");
			stringBuilder.AppendLine("- 'reject_peace' - Reject a peace proposal ✓ AVAILABLE");
		}
		else
		{
			stringBuilder.AppendLine("- 'accept_peace' - NOT AVAILABLE (no active peace proposals)");
			stringBuilder.AppendLine("- 'reject_peace' - NOT AVAILABLE (no active peace proposals)");
		}
		if (flag2)
		{
			stringBuilder.AppendLine("- 'accept_alliance' - Accept an alliance proposal ✓ AVAILABLE");
			stringBuilder.AppendLine("- 'reject_alliance' - Reject an alliance proposal ✓ AVAILABLE");
		}
		else
		{
			stringBuilder.AppendLine("- 'accept_alliance' - NOT AVAILABLE (no active alliance proposals)");
			stringBuilder.AppendLine("- 'reject_alliance' - NOT AVAILABLE (no active alliance proposals)");
		}
		if (flag3)
		{
			stringBuilder.AppendLine("- 'accept_trade_agreement' - Accept trade agreement proposal ✓ AVAILABLE");
			stringBuilder.AppendLine("- 'reject_trade_agreement' - Reject trade agreement proposal ✓ AVAILABLE");
		}
		else
		{
			stringBuilder.AppendLine("- 'accept_trade_agreement' - NOT AVAILABLE (no trade agreement proposals)");
			stringBuilder.AppendLine("- 'reject_trade_agreement' - NOT AVAILABLE (no trade agreement proposals)");
		}
		if (flag5)
		{
			stringBuilder.AppendLine("- 'accept_tribute' - Accept to pay tribute ✓ AVAILABLE");
			stringBuilder.AppendLine("- 'reject_tribute' - Reject tribute demand ✓ AVAILABLE");
		}
		else
		{
			stringBuilder.AppendLine("- 'accept_tribute' - NOT AVAILABLE (no tribute demands)");
			stringBuilder.AppendLine("- 'reject_tribute' - NOT AVAILABLE (no tribute demands)");
		}
		if (flag6)
		{
			stringBuilder.AppendLine("- 'accept_reparations' - Accept to pay reparations ✓ AVAILABLE");
			stringBuilder.AppendLine("- 'reject_reparations' - Reject reparations demand ✓ AVAILABLE");
		}
		else
		{
			stringBuilder.AppendLine("- 'accept_reparations' - NOT AVAILABLE (no reparations demands)");
			stringBuilder.AppendLine("- 'reject_reparations' - NOT AVAILABLE (no reparations demands)");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Extended Diplomatic Actions (NEW):");
		stringBuilder.AppendLine("- 'propose_trade_agreement' - Player proposes trade agreement");
		stringBuilder.AppendLine("- 'end_trade_agreement' - Player ends existing trade agreement");
		DiplomacyManager instance = DiplomacyManager.Instance;
		bool flag7 = false;
		if (instance != null && instance.IsInitialized)
		{
			TerritoryTransferSystem territoryTransferSystem = instance.GetTerritoryTransferSystem();
			foreach (Kingdom item5 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && k != playerKingdom))
			{
				List<Settlement> warRelevantSettlements = territoryTransferSystem.GetWarRelevantSettlements(playerKingdom, item5);
				if (warRelevantSettlements.Any())
				{
					flag7 = true;
					break;
				}
			}
		}
		if (flag7)
		{
			stringBuilder.AppendLine("- 'demand_territory' - Player demands territory transfer (requires settlement_id, ONLY use settlements from current wars)");
			if (flag4)
			{
				stringBuilder.AppendLine("- 'transfer_territory' - Player agrees to transfer demanded territory (requires settlement_id) ✓ AVAILABLE");
				stringBuilder.AppendLine("- 'reject_territory' - Player rejects territory demand (requires settlement_id) ✓ AVAILABLE");
			}
			else
			{
				stringBuilder.AppendLine("- 'transfer_territory' - Player offers to transfer territory (requires settlement_id)");
				stringBuilder.AppendLine("- 'reject_territory' - Player rejects territory demand (requires settlement_id, only if territory was demanded)");
			}
		}
		else
		{
			stringBuilder.AppendLine("- 'demand_territory' - NOT AVAILABLE (no war-relevant settlements, no territory to demand)");
			stringBuilder.AppendLine("- 'transfer_territory' - NOT AVAILABLE (no war-relevant settlements)");
			stringBuilder.AppendLine("- 'reject_territory' - NOT AVAILABLE (no war-relevant settlements)");
		}
		stringBuilder.AppendLine("- 'demand_tribute' - Player demands daily tribute (requires daily_amount and duration_days)");
		stringBuilder.AppendLine("- 'demand_reparations' - Player demands one-time war reparations (requires reparations_amount)");
		bool flag8 = false;
		ModSettings instance2 = GlobalSettings<ModSettings>.Instance;
		if (instance2 != null && instance2.EnableDiseaseSystem)
		{
			DiseaseManager diseaseManager = DiseaseManager.Instance;
			if (diseaseManager != null)
			{
				List<Settlement> source = ((IEnumerable<Settlement>)Settlement.All).Where(delegate(Settlement s)
				{
					int result;
					if (s.IsTown || s.IsCastle)
					{
						if (s.OwnerClan != Clan.PlayerClan)
						{
							Clan ownerClan = s.OwnerClan;
							result = ((((ownerClan != null) ? ownerClan.Kingdom : null) == playerKingdom) ? 1 : 0);
						}
						else
						{
							result = 1;
						}
					}
					else
					{
						result = 0;
					}
					return (byte)result != 0;
				}).ToList();
				List<Settlement> list2 = source.Where((Settlement s) => diseaseManager.SettlementHasDisease(s)).ToList();
				if (list2.Any())
				{
					flag8 = true;
					stringBuilder.AppendLine("- 'quarantine_settlement' - Close a settlement for quarantine due to disease (requires settlement_id + quarantine_duration_days)");
					stringBuilder.AppendLine("  Available settlements with disease:");
					foreach (Settlement item6 in list2)
					{
						string arg = (diseaseManager.IsSettlementUnderQuarantine(item6) ? " [QUARANTINED]" : "");
						stringBuilder.AppendLine($"    - {item6.Name} (string_id: {((MBObjectBase)item6).StringId}){arg}");
					}
				}
				else
				{
					stringBuilder.AppendLine("- 'quarantine_settlement' - NOT AVAILABLE (no diseased settlements)");
				}
			}
		}
		stringBuilder.AppendLine("- 'none' - Just a statement without specific action");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**MULTIPLE ACTIONS:** Player can propose multiple actions at once (e.g., 'accept_peace,transfer_territory,demand_reparations'). In this case, return ALL actions as comma-separated string.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### ANALYSIS GUIDELINES ###");
		stringBuilder.AppendLine("CRITICAL - UNDERSTAND THE DIFFERENCE:");
		stringBuilder.AppendLine("- 'propose_peace' = Player DIRECTLY offers peace TO A KINGDOM THEY ARE AT WAR WITH");
		stringBuilder.AppendLine("- If player calls for/asks for peace BETWEEN OTHER KINGDOMS → use 'none' (just a statement)");
		stringBuilder.AppendLine("- If player threatens OR warns → use 'none' (just a statement, not a direct action)");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("ACTION DETECTION:");
		stringBuilder.AppendLine("- Player DIRECTLY declares/starts war → 'declare_war'");
		stringBuilder.AppendLine("- Player DIRECTLY offers peace to THEIR OWN enemy → 'propose_peace'");
		stringBuilder.AppendLine("- Player DIRECTLY proposes alliance → 'propose_alliance'");
		stringBuilder.AppendLine("- Player DIRECTLY accepts a proposal → 'accept_peace' or 'accept_alliance'");
		stringBuilder.AppendLine("- Player DIRECTLY refuses a proposal → 'reject_peace' or 'reject_alliance'");
		stringBuilder.AppendLine("- Player DIRECTLY ends their alliance → 'break_alliance'");
		stringBuilder.AppendLine("- Player makes general statement, threat, or calls for action BETWEEN OTHERS → 'none'");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("TARGET IDENTIFICATION:");
		stringBuilder.AppendLine("- Target = kingdom that RECEIVES player's DIRECT action");
		stringBuilder.AppendLine("- If player talks ABOUT kingdom but doesn't ACT ON them → target is null, action is 'none'");
		stringBuilder.AppendLine("- Look for: 'we offer to X', 'we declare war on X', 'we propose to X'");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("EXAMPLES:");
		stringBuilder.AppendLine("- 'We declare war on Vlandia' → action='declare_war', target_kingdom_ids=['vlandia']");
		stringBuilder.AppendLine("- 'We declare war on all kingdoms' → action='declare_war', target_kingdom_ids=['vlandia', 'empire', 'sturgia', 'aserai', 'khuzait', 'battania']");
		stringBuilder.AppendLine("- 'We propose peace to Empire' → action='propose_peace', target_kingdom_ids=['empire'] (only if at war!)");
		if (pendingProposalsForPlayer.Any())
		{
			stringBuilder.AppendLine("- 'We accept the peace proposal from Sturgia' → action='accept_peace', target_kingdom_ids=['sturgia'] (ONLY if Sturgia has made a peace proposal in PENDING PROPOSALS!)");
			stringBuilder.AppendLine("- 'We accept the alliance proposal from Vlandia' → action='accept_alliance', target_kingdom_ids=['vlandia'] (ONLY if Vlandia has made an alliance proposal in PENDING PROPOSALS!)");
			stringBuilder.AppendLine("- 'We reject the alliance proposal' → action='reject_alliance', target_kingdom_ids=['source_kingdom'] (ONLY if some kingdom has made an alliance proposal in PENDING PROPOSALS!)");
		}
		else
		{
			stringBuilder.AppendLine("- 'We accept the peace proposal' → action='accept_peace', target_kingdom_ids=[] (INVALID - no pending proposals!)");
			stringBuilder.AppendLine("- 'We reject the alliance proposal' → action='reject_alliance', target_kingdom_ids=[] (INVALID - no pending proposals!)");
		}
		stringBuilder.AppendLine("- 'We call on Empire to stop the war' → action='none', target_kingdom_ids=[] (calling for action, not acting)");
		stringBuilder.AppendLine("- 'We warn Empire, or we will help our allies' → action='none', target_kingdom_ids=[] (warning/threat)");
		stringBuilder.AppendLine("- 'We stand with our allies against Empire' → action='none', target_kingdom_ids=[] (statement of support)");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### TONE ANALYSIS ###");
		stringBuilder.AppendLine("- **aggressive**: Threatening, hostile, demanding");
		stringBuilder.AppendLine("- **diplomatic**: Formal, measured, seeking compromise");
		stringBuilder.AppendLine("- **defensive**: Justifying, explaining, responding to threats");
		stringBuilder.AppendLine("- **neutral**: Stating facts, observing, no strong emotion");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### OUTPUT FORMAT ###");
		stringBuilder.AppendLine("Respond ONLY with a valid JSON object (no markdown, no code blocks):");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("{");
		stringBuilder.AppendLine("  \"action\": \"action1,action2,action3\", // Can be single or multiple actions separated by comma");
		stringBuilder.AppendLine("  \"target_kingdom_ids\": [\"kingdom_string_id1\", \"kingdom_string_id2\"], // Array of string_ids from ALL KINGDOMS section");
		stringBuilder.AppendLine("  \"tone\": \"aggressive|diplomatic|defensive|neutral\",");
		stringBuilder.AppendLine("  \"reason\": \"Brief summary of the reason for this action (1-2 sentences)\",");
		stringBuilder.AppendLine("  \"settlement_id\": \"settlement_string_id\", // REQUIRED for territory actions, null otherwise");
		stringBuilder.AppendLine("  \"daily_tribute_amount\": 0, // REQUIRED for tribute demand (gold per day), 0 otherwise");
		stringBuilder.AppendLine("  \"tribute_duration_days\": 0, // REQUIRED for tribute demand (duration), 0 otherwise");
		stringBuilder.AppendLine("  \"reparations_amount\": 0, // REQUIRED for reparations demand (one-time payment), 0 otherwise");
		stringBuilder.AppendLine("  \"trade_agreement_duration_years\": 1.0, // For trade agreements, default 1.0");
		stringBuilder.AppendLine("  \"quarantine_duration_days\": 0 // For quarantine_settlement: positive integer (days), minimum 1, auto-lifts after");
		stringBuilder.AppendLine("}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("IMPORTANT:");
		stringBuilder.AppendLine("- Use lowercase string_id (e.g., \"khuzait\", \"sturgia\", \"empire\")");
		stringBuilder.AppendLine("- For multiple targets (like 'declare war on all kingdoms'), include ALL relevant kingdom string_ids in the array");
		stringBuilder.AppendLine("- For single targets, use an array with one element: [\"kingdom_name\"]");
		stringBuilder.AppendLine("- If no clear target is mentioned, use an empty array: []");
		stringBuilder.AppendLine("- Extract the reason from the player's text or create a brief summary");
		stringBuilder.AppendLine("- For multiple actions, separate them with commas: 'accept_peace,transfer_territory,demand_reparations'");
		stringBuilder.AppendLine("- Include all required parameters for each action type");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("CRITICAL REMINDER:");
		if (flag7)
		{
			stringBuilder.AppendLine("- You CAN use territory actions - settlements are available in current wars");
			stringBuilder.AppendLine("- ONLY use settlement_id values that exist in the game state (check war-relevant settlements if shown)");
		}
		else
		{
			stringBuilder.AppendLine("- You CANNOT use territory actions - NO war-relevant settlements available");
			stringBuilder.AppendLine("- If player demands territory when none available, set action to 'none' and reason: 'No settlements available for transfer'");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("EXAMPLES:");
		stringBuilder.AppendLine("1. Simple peace: {\"action\": \"accept_peace\", \"target_kingdom_ids\": [\"vlandia\"], \"tone\": \"diplomatic\", \"reason\": \"End the war\", \"settlement_id\": null, \"daily_tribute_amount\": 0, \"tribute_duration_days\": 0, \"reparations_amount\": 0, \"trade_agreement_duration_years\": 1.0}");
		if (flag7)
		{
			stringBuilder.AppendLine("2. Peace with territory: {\"action\": \"accept_peace,transfer_territory\", \"target_kingdom_ids\": [\"vlandia\"], \"tone\": \"diplomatic\", \"reason\": \"Peace in exchange for territory\", \"settlement_id\": \"town_V1\", \"daily_tribute_amount\": 0, \"tribute_duration_days\": 0, \"reparations_amount\": 0, \"trade_agreement_duration_years\": 1.0}");
		}
		stringBuilder.AppendLine("3. Peace with tribute and reparations: {\"action\": \"accept_peace,demand_tribute,demand_reparations\", \"target_kingdom_ids\": [\"battania\"], \"tone\": \"aggressive\", \"reason\": \"You will pay for your aggression\", \"settlement_id\": null, \"daily_tribute_amount\": 300, \"tribute_duration_days\": 180, \"reparations_amount\": 25000, \"trade_agreement_duration_years\": 1.0}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Generate your analysis now:");
		return stringBuilder.ToString();
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

	private PlayerStatementResult ParseAIResponse(string aiResponse, Kingdom playerKingdom)
	{
		if (string.IsNullOrEmpty(aiResponse))
		{
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] AI response missing: " + (aiResponse ?? "(null)"));
			return null;
		}
		string text = "";
		string text2 = "";
		try
		{
			DiplomacyLogger.Instance.Log($"[PLAYER_ANALYZER] Parsing AI response (length: {aiResponse?.Length ?? 0})");
			text = aiResponse.Trim();
			if (text.StartsWith("```json"))
			{
				text = text.Substring(7);
				DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] Removed ```json prefix");
			}
			if (text.StartsWith("```"))
			{
				text = text.Substring(3);
				DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] Removed ``` prefix");
			}
			if (text.EndsWith("```"))
			{
				text = text.Substring(0, text.Length - 3);
				DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] Removed ``` suffix");
			}
			text = text.Trim();
			DiplomacyLogger.Instance.Log($"[PLAYER_ANALYZER] Cleaned response length: {text.Length}");
			text2 = FixJsonQuotes(text);
			PlayerStatementAnalysisResponse response = JsonConvert.DeserializeObject<PlayerStatementAnalysisResponse>(text2);
			if (response == null)
			{
				DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] JSON deserialization returned null");
				return null;
			}
			DiplomacyLogger.Instance.Log($"[PLAYER_ANALYZER] JSON parsed: action={response.Action}, target={response.TargetKingdomId}, targets={response.TargetKingdomIds?.Count ?? 0}, tone={response.Tone}");
			List<DiplomaticAction> list = ParseMultipleActions(response.Action);
			DiplomaticAction action = list.FirstOrDefault();
			DiplomacyLogger.Instance.Log(string.Format("[PLAYER_ANALYZER] Parsed {0} actions: {1}", list.Count, string.Join(", ", list)));
			List<string> list2 = new List<string>();
			List<Kingdom> list3 = new List<Kingdom>();
			if (response.TargetKingdomIds != null && response.TargetKingdomIds.Any())
			{
				list2.AddRange(response.TargetKingdomIds);
				foreach (string kingdomId in response.TargetKingdomIds)
				{
					Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == kingdomId));
					if (val != null)
					{
						list3.Add(val);
					}
					else
					{
						DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] WARNING: Target kingdom not found: " + kingdomId);
					}
				}
			}
			else if (!string.IsNullOrEmpty(response.TargetKingdomId))
			{
				list2.Add(response.TargetKingdomId);
				Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == response.TargetKingdomId));
				if (val2 != null)
				{
					list3.Add(val2);
				}
				else
				{
					DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] WARNING: Target kingdom not found: " + response.TargetKingdomId);
				}
			}
			PlayerStatementResult playerStatementResult = new PlayerStatementResult
			{
				Action = action,
				Actions = list,
				TargetKingdomIds = list2,
				TargetKingdoms = list3,
				Tone = (response.Tone ?? "neutral"),
				Reason = (response.Reason ?? string.Empty),
				SettlementId = response.SettlementId,
				DailyTributeAmount = response.DailyTributeAmount,
				TributeDurationDays = response.TributeDurationDays,
				ReparationsAmount = response.ReparationsAmount,
				TradeAgreementDurationYears = ((response.TradeAgreementDurationYears > 0f) ? response.TradeAgreementDurationYears : 1f),
				QuarantineDurationDays = response.QuarantineDurationDays
			};
			DiplomacyLogger.Instance.Log(string.Format("[PLAYER_ANALYZER] Result created: Actions={0}, Settlement={1}, Tribute={2}/{3}, Reparations={4}, Quarantine={5}", string.Join(",", playerStatementResult.Actions), playerStatementResult.SettlementId, playerStatementResult.DailyTributeAmount, playerStatementResult.TributeDurationDays, playerStatementResult.ReparationsAmount, playerStatementResult.QuarantineDurationDays));
			return playerStatementResult;
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] ERROR parsing response: " + ex.Message);
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] Raw response: " + aiResponse);
			DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] Cleaned response: " + text);
			if (text2 != text)
			{
				DiplomacyLogger.Instance.Log("[PLAYER_ANALYZER] Cleaned JSON: " + text2);
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

	private List<string> GetPendingProposalsForPlayer(Kingdom playerKingdom, List<DynamicEvent> activeDiplomaticEvents = null)
	{
		List<string> list = new List<string>();
		if (activeDiplomaticEvents == null || !activeDiplomaticEvents.Any())
		{
			return list;
		}
		foreach (DynamicEvent activeDiplomaticEvent in activeDiplomaticEvents)
		{
			if (activeDiplomaticEvent.KingdomStatements == null || !activeDiplomaticEvent.KingdomStatements.Any())
			{
				continue;
			}
			foreach (KingdomStatement statement in activeDiplomaticEvent.KingdomStatements)
			{
				if (statement.KingdomId == ((MBObjectBase)playerKingdom).StringId)
				{
					continue;
				}
				Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == statement.KingdomId));
				string text = ((val == null) ? null : ((object)val.Name)?.ToString()) ?? statement.KingdomId;
				if (!(statement.TargetKingdomId == ((MBObjectBase)playerKingdom).StringId))
				{
					continue;
				}
				List<DiplomaticAction> list2 = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
				foreach (DiplomaticAction item in list2)
				{
					bool flag = false;
					switch (item)
					{
					case DiplomaticAction.ProposeAlliance:
						flag = activeDiplomaticEvent.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)playerKingdom).StringId && (s.Action == DiplomaticAction.AcceptAlliance || s.Action == DiplomaticAction.RejectAlliance || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptAlliance) || s.Actions.Contains(DiplomaticAction.RejectAlliance)))) && s.TargetKingdomId == statement.KingdomId);
						break;
					case DiplomaticAction.ProposePeace:
						flag = activeDiplomaticEvent.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)playerKingdom).StringId && (s.Action == DiplomaticAction.AcceptPeace || s.Action == DiplomaticAction.RejectPeace || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptPeace) || s.Actions.Contains(DiplomaticAction.RejectPeace)))) && s.TargetKingdomId == statement.KingdomId);
						break;
					case DiplomaticAction.ProposeTradeAgreement:
						flag = activeDiplomaticEvent.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)playerKingdom).StringId && (s.Action == DiplomaticAction.AcceptTradeAgreement || s.Action == DiplomaticAction.RejectTradeAgreement || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptTradeAgreement) || s.Actions.Contains(DiplomaticAction.RejectTradeAgreement)))) && s.TargetKingdomId == statement.KingdomId);
						break;
					case DiplomaticAction.DemandTerritory:
						flag = activeDiplomaticEvent.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)playerKingdom).StringId && (s.Action == DiplomaticAction.TransferTerritory || s.Action == DiplomaticAction.RejectTerritory || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.TransferTerritory) || s.Actions.Contains(DiplomaticAction.RejectTerritory)))) && s.TargetKingdomId == statement.KingdomId && s.SettlementId == statement.SettlementId);
						break;
					case DiplomaticAction.DemandTribute:
						flag = activeDiplomaticEvent.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)playerKingdom).StringId && (s.Action == DiplomaticAction.AcceptTribute || s.Action == DiplomaticAction.RejectTribute || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptTribute) || s.Actions.Contains(DiplomaticAction.RejectTribute)))) && s.TargetKingdomId == statement.KingdomId);
						break;
					case DiplomaticAction.DemandReparations:
						flag = activeDiplomaticEvent.KingdomStatements.Any((KingdomStatement s) => s.KingdomId == ((MBObjectBase)playerKingdom).StringId && (s.Action == DiplomaticAction.AcceptReparations || s.Action == DiplomaticAction.RejectReparations || (s.Actions != null && (s.Actions.Contains(DiplomaticAction.AcceptReparations) || s.Actions.Contains(DiplomaticAction.RejectReparations)))) && s.TargetKingdomId == statement.KingdomId);
						break;
					}
					if (flag)
					{
						continue;
					}
					switch (item)
					{
					case DiplomaticAction.ProposeAlliance:
						list.Add(text + " (" + statement.KingdomId + ") proposes ALLIANCE to you. You can respond with 'accept_alliance' or 'reject_alliance'.");
						break;
					case DiplomaticAction.ProposePeace:
						list.Add(text + " (" + statement.KingdomId + ") proposes PEACE to you. You can respond with 'accept_peace' or 'reject_peace'.");
						break;
					case DiplomaticAction.ProposeTradeAgreement:
						list.Add(text + " (" + statement.KingdomId + ") proposes TRADE AGREEMENT to you. You can respond with 'accept_trade_agreement' or 'reject_trade_agreement'.");
						break;
					case DiplomaticAction.DemandTerritory:
					{
						Settlement val2 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == statement.SettlementId));
						string text2 = ((val2 == null) ? null : ((object)val2.Name)?.ToString()) ?? statement.SettlementId;
						list.Add(text + " (" + statement.KingdomId + ") demands TERRITORY: " + text2 + " (id:" + statement.SettlementId + "). You can respond with 'transfer_territory' (agreement) or reject in peace negotiations.");
						break;
					}
					case DiplomaticAction.DemandTribute:
						list.Add($"{text} ({statement.KingdomId}) demands TRIBUTE: {statement.DailyTributeAmount} gold/day for {statement.TributeDurationDays} days. You can respond with 'accept_tribute' or 'reject_tribute'.");
						break;
					case DiplomaticAction.DemandReparations:
						list.Add($"{text} ({statement.KingdomId}) demands WAR REPARATIONS: {statement.ReparationsAmount} gold. You can respond with 'accept_reparations' or 'reject_reparations'.");
						break;
					}
				}
			}
		}
		return list;
	}

	private void LogMessage(string message)
	{
		DiplomacyLogger.Instance.Log(message);
	}
}
