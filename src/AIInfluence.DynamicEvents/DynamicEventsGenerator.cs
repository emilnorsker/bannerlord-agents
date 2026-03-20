using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AIInfluence;
using AIInfluence.Diplomacy;
using AIInfluence.Diseases;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.DynamicEvents;

public class DynamicEventsGenerator
{
	private class EventTypeConfig
	{
		public string[] Focuses { get; set; }

		public string[] Tones { get; set; }

		public string[] CreativityHints { get; set; }
	}

	private readonly Random _random;

	private readonly Dictionary<string, KingdomDestructionInfo> _kingdomDestructionTracker = new Dictionary<string, KingdomDestructionInfo>();

	public static readonly int PROSPERITY_HIGH_THRESHOLD = 4000;

	public static readonly int PROSPERITY_MEDIUM_THRESHOLD = 2000;

	public static readonly int FOOD_STOCKS_LOW_THRESHOLD = 100;

	public static readonly int TOWN_SECURITY_LOW_THRESHOLD = 30;

	public static readonly int TOWN_LOYALTY_LOW_THRESHOLD = 30;

	public static readonly int VILLAGE_HEARTH_LOW_THRESHOLD = 100;

	public static readonly int VILLAGE_HEARTH_MEDIUM_THRESHOLD = 200;

	public static readonly int CLAN_TIER_HIGH_THRESHOLD = 5;

	public static readonly int CLAN_TIER_MEDIUM_THRESHOLD = 4;

	public static readonly int RULER_AGE_OLD_THRESHOLD = 55;

	public static readonly int HEIR_ADULT_AGE_THRESHOLD = 18;

	public static readonly int LARGE_BATTLE_TROOPS_THRESHOLD = 1500;

	public static readonly int LARGE_ARMY_TROOPS_THRESHOLD = 850;

	public static readonly int PARTY_MORALE_LOW_THRESHOLD = 30;

	public static readonly float SETTLEMENT_DISTANCE_NEAR_THRESHOLD = 50f;

	public static readonly float SETTLEMENT_DISTANCE_MEDIUM_THRESHOLD = 60f;

	private const string PROSPERITY_STATUS_PROSPEROUS = "prosperous";

	private const string PROSPERITY_STATUS_MODERATE = "moderate";

	private const string PROSPERITY_STATUS_STRUGGLING = "struggling";

	private const string CLAN_TIER_STATUS_HIGH_LORD = "High Lord";

	private const string CLAN_TIER_STATUS_LORD = "Lord";

	private static string GetProsperityStatus(float prosperity)
	{
		return (prosperity > (float)PROSPERITY_HIGH_THRESHOLD) ? "prosperous" : ((prosperity > (float)PROSPERITY_MEDIUM_THRESHOLD) ? "moderate" : "struggling");
	}

	private static string GetFoodStocksStatus(float foodStocks)
	{
		if (foodStocks < (float)FOOD_STOCKS_LOW_THRESHOLD)
		{
			return "critical shortage";
		}
		if (foodStocks < 300f)
		{
			return "low reserves";
		}
		if (foodStocks < 500f)
		{
			return "adequate";
		}
		return "abundant";
	}

	private static string GetHearthStatus(float hearth)
	{
		if (hearth < (float)VILLAGE_HEARTH_LOW_THRESHOLD)
		{
			return "critically low";
		}
		if (hearth < (float)VILLAGE_HEARTH_MEDIUM_THRESHOLD)
		{
			return "below average";
		}
		if (hearth < 400f)
		{
			return "normal";
		}
		return "thriving";
	}

	private static string GetClanTierStatus(int tier)
	{
		return (tier >= CLAN_TIER_HIGH_THRESHOLD) ? "High Lord" : "Lord";
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

	public DynamicEventsGenerator()
	{
		_random = new Random();
		BattleHistoryManager instance = BattleHistoryManager.Instance;
		SettlementCaptureManager instance2 = SettlementCaptureManager.Instance;
		CampaignEvents.KingdomDestroyedEvent.AddNonSerializedListener((object)this, (Action<Kingdom>)OnKingdomDestroyed);
	}

	public async Task GenerateEvents()
	{
		DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Starting event generation...");
		try
		{
			CollectMilitaryWorldData();
			string existingEvents = GetExistingEventsData();
			bool hasNewDialogues;
			string dialogueData = CollectDialogueData(out hasNewDialogues);
			string diplomaticStatements = CollectDiplomaticStatementsData();
			if (GlobalSettings<ModSettings>.Instance.DynamicEventsDialogueOnly)
			{
				if (!hasNewDialogues)
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Dialogue-only mode enabled but no new dialogues, skipping generation");
				}
				else
				{
					await ProcessDialogueOnlyMode(dialogueData);
				}
				return;
			}
			if (!GlobalSettings<ModSettings>.Instance.HasEnabledEventTypes())
			{
				if (!hasNewDialogues)
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] No event types enabled and no new dialogues, skipping generation");
					return;
				}
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] No event types enabled, generating only from dialogues");
				string dialogueWorldData = CollectMinimalWorldData();
				string dialoguePrompt = BuildEventGenerationPrompt(dialogueWorldData, existingEvents, diplomaticStatements, dialogueData, hasDialogues: true);
				DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] Sending dialogue-only prompt to AI ({dialoguePrompt.Length} characters)");
				AIInfluenceBehavior dialogueBehavior = AIInfluenceBehavior.Instance;
				if (dialogueBehavior == null)
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] AIInfluenceBehavior instance not found");
					return;
				}
				string dialogueAiResponse = await dialogueBehavior.SendAIRequestWithBackend(dialoguePrompt, "dynamic_event_generation", GlobalSettings<ModSettings>.Instance.DynamicEventsAIBackend.SelectedValue);
				if (string.IsNullOrEmpty(dialogueAiResponse))
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] AI returned empty response for dialogue-only generation - API may be unavailable");
					if (dialogueAiResponse != null && (dialogueAiResponse.Contains("API key is missing") || dialogueAiResponse.Contains("Error:")))
					{
						DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] API Error detected in dialogue generation: " + dialogueAiResponse);
						DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Scheduling retry in 1 day due to API issues");
						DynamicEventsManager.Instance.ScheduleGenerationForNextDay();
					}
					else
					{
						DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Empty response for dialogue-only generation - no events generated this time");
					}
					return;
				}
				DynamicEventsResponse dialogueEventsResponse = ParseAIResponse(dialogueAiResponse);
				MarkDialoguesAsAnalyzed();
				if (dialogueEventsResponse == null || !dialogueEventsResponse.Events.Any())
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] No events generated by AI from dialogues (dialogue-only mode)");
					DynamicEventsLogger.Instance.LogEventGeneration(dialoguePrompt, dialogueAiResponse, 0);
					return;
				}
				DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] AI generated {dialogueEventsResponse.Events.Count} events from dialogues");
				DynamicEventsLogger.Instance.LogEventGeneration(dialoguePrompt, dialogueAiResponse, dialogueEventsResponse.Events.Count);
				foreach (DynamicEvent dynamicEvent in dialogueEventsResponse.Events)
				{
					ProcessGeneratedEvent(dynamicEvent);
				}
				return;
			}
			Dictionary<string, int> enabledTypes = GlobalSettings<ModSettings>.Instance.GetEnabledEventTypes();
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Enabled event types (configured): " + string.Join(", ", enabledTypes.Select((KeyValuePair<string, int> kvp) => $"{kvp.Key}({kvp.Value}%)")));
			string selectedEventType = "";
			string worldDataForPrompt;
			if (hasNewDialogues)
			{
				worldDataForPrompt = CollectMinimalWorldData();
			}
			else
			{
				if (CheckForHighFatigueWars())
				{
					selectedEventType = "military";
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] High fatigue war detected - forcing military event type");
				}
				else
				{
					selectedEventType = GetRandomEventType();
				}
				worldDataForPrompt = CollectFocusedWorldData(selectedEventType);
			}
			string prompt = BuildEventGenerationPrompt(worldDataForPrompt, existingEvents, diplomaticStatements, dialogueData, hasNewDialogues, selectedEventType);
			DynamicEventsLogger.Instance.Log(string.Format("[DYNAMIC_EVENTS_GEN] Sending prompt to AI ({0} characters, {1} new dialogues)", prompt.Length, hasNewDialogues ? "with" : "without"));
			AIInfluenceBehavior behavior = AIInfluenceBehavior.Instance;
			if (behavior == null)
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] AIInfluenceBehavior instance not found");
				return;
			}
			string aiResponse = await behavior.SendAIRequestWithBackend(prompt, "dynamic_event_generation", GlobalSettings<ModSettings>.Instance.DynamicEventsAIBackend.SelectedValue);
			if (string.IsNullOrEmpty(aiResponse))
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] AI returned empty response - API may be unavailable");
				if (aiResponse != null && (aiResponse.Contains("API key is missing") || aiResponse.Contains("Error:")))
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] API Error detected: " + aiResponse);
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Scheduling retry in 1 day due to API issues");
					DynamicEventsManager.Instance.ScheduleGenerationForNextDay();
				}
				else
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Empty response - no events generated this time");
				}
				return;
			}
			DynamicEventsResponse eventsResponse = ParseAIResponse(aiResponse);
			if (hasNewDialogues)
			{
				MarkDialoguesAsAnalyzed();
			}
			if (eventsResponse == null || !eventsResponse.Events.Any())
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] No events generated by AI");
				DynamicEventsLogger.Instance.LogEventGeneration(prompt, aiResponse, 0);
				if (hasNewDialogues)
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Dialogues produced no events - scheduling generation for next day");
					DynamicEventsManager.Instance.ScheduleGenerationForNextDay();
				}
				return;
			}
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] AI generated {eventsResponse.Events.Count} events");
			DynamicEventsLogger.Instance.LogEventGeneration(prompt, aiResponse, eventsResponse.Events.Count);
			foreach (DynamicEvent dynamicEvent2 in eventsResponse.Events)
			{
				ProcessGeneratedEvent(dynamicEvent2);
			}
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Events successfully created - resetting generation timer");
			DynamicEventsManager.Instance.ResetGenerationTimer();
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Error generating events: " + ex2.Message + "\n" + ex2.StackTrace);
			DynamicEventsManager.Instance.ResetGenerationTimer();
		}
	}

	private string GetRandomEventType()
	{
		Dictionary<string, int> enabledEventTypes = GlobalSettings<ModSettings>.Instance.GetEnabledEventTypes();
		if (!enabledEventTypes.Any())
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] No event types enabled, using fallback");
			return "military";
		}
		int num = enabledEventTypes.Values.Sum();
		if (num <= 0)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] All event types have 0% chance, using fallback");
			return enabledEventTypes.Keys.First();
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (KeyValuePair<string, int> item in enabledEventTypes)
		{
			int value = (int)Math.Round((double)item.Value * 100.0 / (double)num);
			dictionary[item.Key] = value;
		}
		string arg = string.Join(", ", dictionary.Select((KeyValuePair<string, int> kvp) => $"{kvp.Key}({kvp.Value}%)"));
		DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] Normalized probabilities: {arg} (total configured: {num}%)");
		int num2 = _random.Next(100);
		DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] Random roll: {num2}/100");
		int num3 = 0;
		foreach (KeyValuePair<string, int> item2 in enabledEventTypes)
		{
			int num4 = dictionary[item2.Key];
			num3 += num4;
			if (num2 < num3)
			{
				DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] Selected event type: {item2.Key} (configured: {item2.Value}%, actual probability: {num4}%)");
				return item2.Key;
			}
		}
		DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Weighted selection failed due to rounding, using last enabled type");
		return enabledEventTypes.Keys.Last();
	}

	private bool CheckForHighFatigueWars()
	{
		WarStatisticsTracker instance = WarStatisticsTracker.Instance;
		if (instance == null)
		{
			return false;
		}
		foreach (Kingdom item in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			IEnumerable<Kingdom> enemyKingdoms = GameVersionCompatibility.GetEnemyKingdoms(item);
			foreach (Kingdom item2 in enemyKingdoms)
			{
				KingdomWarStats kingdomStats = instance.GetKingdomStats(item);
				KingdomWarStats kingdomStats2 = instance.GetKingdomStats(item2);
				float num = kingdomStats?.WarFatigue ?? 0f;
				float num2 = kingdomStats2?.WarFatigue ?? 0f;
				if (num > 75f || num2 > 75f)
				{
					DynamicEventsLogger.Instance.Log($"[HIGH_FATIGUE_CHECK] War between {item.Name} and {item2.Name} has high fatigue ({num:F1}% / {num2:F1}%) - forcing military event");
					return true;
				}
			}
		}
		return false;
	}

	private string CollectFocusedWorldData(string eventType)
	{
		return eventType switch
		{
			"military" => CollectMilitaryWorldData(), 
			"political" => CollectPoliticalWorldData(), 
			"economic" => CollectEconomicWorldData(), 
			"social" => CollectSocialWorldData(), 
			"mysterious" => CollectMysteriousWorldData(), 
			"disease_outbreak" => CollectDiseaseOutbreakWorldData(), 
			_ => CollectMinimalWorldData(), 
		};
	}

	private string CollectMinimalWorldData()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected I4, but got Unknown
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== CURRENT WORLD STATE ===");
		CampaignTime now = CampaignTime.Now;
		Seasons getSeasonOfYear = (now).GetSeasonOfYear;
		Seasons val = getSeasonOfYear;
		stringBuilder.AppendLine(string.Format("CURRENT TIME: Year {0}, {1}", (now).GetYear, (int)val switch
		{
			0 => "spring", 
			1 => "summer", 
			2 => "autumn", 
			3 => "winter", 
			_ => "unknown", 
		}));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("EXISTING KINGDOMS (for kingdoms_involved field):");
		stringBuilder.AppendLine("**IMPORTANT: When using string_id in JSON, use ONLY the value (e.g. \"empire\"), NOT \"string_id:empire\"**");
		stringBuilder.AppendLine("**NOTE: Destroyed kingdoms are excluded from this list and should not be referenced**");
		foreach (Kingdom item in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			Hero leader = item.Leader;
			stringBuilder.AppendLine("- " + (((object)item.Name)?.ToString() ?? "Unknown"));
			stringBuilder.AppendLine("  string_id: \"" + ((MBObjectBase)item).StringId + "\"");
			stringBuilder.AppendLine("  Leader: " + (((leader == null) ? null : ((object)leader.Name)?.ToString()) ?? "None"));
			if (leader != null)
			{
				stringBuilder.AppendLine("  Leader string_id: \"" + ((MBObjectBase)leader).StringId + "\"");
			}
			IEnumerable<Kingdom> enemyKingdoms = GameVersionCompatibility.GetEnemyKingdoms(item);
			if (enemyKingdoms.Any())
			{
				stringBuilder.AppendLine("  At war with: " + string.Join(", ", enemyKingdoms.Select((Kingdom e) => ((object)e.Name)?.ToString() ?? "Unknown")));
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	private string CollectMilitaryWorldData()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== MILITARY SITUATION ===");
		stringBuilder.AppendLine();
		CampaignTime val = CampaignTime.Now;
		object arg = (val).GetYear;
		val = CampaignTime.Now;
		stringBuilder.AppendLine($"Time: Year {arg}, {(val).GetSeasonOfYear}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Wars:");
		HashSet<string> hashSet = new HashSet<string>();
		bool flag = false;
		foreach (Kingdom item3 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			List<Kingdom> list = GameVersionCompatibility.GetEnemyKingdoms(item3).ToList();
			foreach (Kingdom item4 in list)
			{
				string item = ((string.Compare(((MBObjectBase)item3).StringId, ((MBObjectBase)item4).StringId, StringComparison.Ordinal) < 0) ? (((MBObjectBase)item3).StringId + "_" + ((MBObjectBase)item4).StringId) : (((MBObjectBase)item4).StringId + "_" + ((MBObjectBase)item3).StringId));
				if (hashSet.Contains(item))
				{
					continue;
				}
				hashSet.Add(item);
				int warDuration = GetWarDuration(item3, item4);
				string text = "";
				WarStatisticsTracker warStatisticsTracker = DiplomacyManager.Instance?.GetWarTracker();
				if (warStatisticsTracker != null)
				{
					DiplomaticReason diplomaticReason = warStatisticsTracker.GetDiplomaticReason(item3, item4, "war");
					if (diplomaticReason != null && !string.IsNullOrEmpty(diplomaticReason.Reason))
					{
						text = " (Reason: " + diplomaticReason.Reason + ")";
					}
				}
				stringBuilder.AppendLine($"- {item3.Name} (string_id: \"{((MBObjectBase)item3).StringId}\") vs {item4.Name} (string_id: \"{((MBObjectBase)item4).StringId}\"), ongoing for {warDuration} days.{text}");
				flag = true;
			}
		}
		if (!flag)
		{
			stringBuilder.AppendLine("- No active wars in the world");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Alliances:");
		AllianceSystem instance = AllianceSystem.Instance;
		bool flag2 = false;
		if (instance != null)
		{
			List<Kingdom> list2 = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated).ToList();
			HashSet<string> hashSet2 = new HashSet<string>();
			foreach (Kingdom item5 in list2)
			{
				List<Kingdom> allies = instance.GetAllies(item5);
				foreach (Kingdom item6 in allies)
				{
					string item2 = ((string.Compare(((MBObjectBase)item5).StringId, ((MBObjectBase)item6).StringId, StringComparison.Ordinal) < 0) ? (((MBObjectBase)item5).StringId + "_" + ((MBObjectBase)item6).StringId) : (((MBObjectBase)item6).StringId + "_" + ((MBObjectBase)item5).StringId));
					if (hashSet2.Contains(item2))
					{
						continue;
					}
					hashSet2.Add(item2);
					string text2 = "";
					WarStatisticsTracker warStatisticsTracker2 = DiplomacyManager.Instance?.GetWarTracker();
					if (warStatisticsTracker2 != null)
					{
						DiplomaticReason diplomaticReason2 = warStatisticsTracker2.GetDiplomaticReason(item5, item6, "alliance");
						if (diplomaticReason2 != null && !string.IsNullOrEmpty(diplomaticReason2.Reason))
						{
							text2 = " (Reason: " + diplomaticReason2.Reason + ")";
						}
					}
					stringBuilder.AppendLine($"- {item5.Name} (\"{((MBObjectBase)item5).StringId}\") allied with {item6.Name} (\"{((MBObjectBase)item6).StringId}\"){text2}");
					flag2 = true;
				}
			}
		}
		if (!flag2)
		{
			stringBuilder.AppendLine("- No active alliances");
		}
		stringBuilder.AppendLine();
		DiplomacyManager instance2 = DiplomacyManager.Instance;
		if (instance2 != null && instance2.IsInitialized)
		{
			TradeAgreementSystem tradeAgreementSystem = instance2.GetTradeAgreementSystem();
			TributeSystem tributeSystem = instance2.GetTributeSystem();
			ReparationsSystem reparationsSystem = instance2.GetReparationsSystem();
			List<TradeAgreementInfo> list3 = tradeAgreementSystem.TradeAgreements.Values.Where(delegate(TradeAgreementInfo t)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime endTime = t.EndTime;
				return (endTime).IsFuture;
			}).ToList();
			stringBuilder.AppendLine("Trade Agreements:");
			if (list3.Any())
			{
				foreach (TradeAgreementInfo agreement in list3)
				{
					Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == agreement.Kingdom1Id && !k.IsEliminated));
					Kingdom val3 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == agreement.Kingdom2Id && !k.IsEliminated));
					if (val2 != null && val3 != null)
					{
						val = agreement.EndTime;
						float num = (val).RemainingDaysFromNow / (float)CampaignTime.DaysInYear;
						stringBuilder.AppendLine($"- {val2.Name} (\"{((MBObjectBase)val2).StringId}\") ↔ {val3.Name} (\"{((MBObjectBase)val3).StringId}\") (expires in {num:F1} years)");
					}
				}
			}
			else
			{
				stringBuilder.AppendLine("- No active trade agreements");
			}
			stringBuilder.AppendLine();
			List<TributeAgreement> list4 = tributeSystem.Tributes.Values.Where(delegate(TributeAgreement t)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime endTime = t.EndTime;
				return (endTime).IsFuture;
			}).ToList();
			stringBuilder.AppendLine("Active Tributes:");
			if (list4.Any())
			{
				foreach (TributeAgreement tribute in list4)
				{
					Kingdom val4 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute.PayerKingdomId && !k.IsEliminated));
					Kingdom val5 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute.ReceiverKingdomId && !k.IsEliminated));
					if (val4 != null && val5 != null)
					{
						val = tribute.EndTime;
						float remainingDaysFromNow = (val).RemainingDaysFromNow;
						stringBuilder.AppendLine($"- {val4.Name} (\"{((MBObjectBase)val4).StringId}\") → {val5.Name} (\"{((MBObjectBase)val5).StringId}\"): {tribute.DailyAmount} gold/day for {remainingDaysFromNow:F0} more days");
					}
				}
			}
			else
			{
				stringBuilder.AppendLine("- No active tributes");
			}
			stringBuilder.AppendLine();
			List<ReparationDemand> list5 = reparationsSystem.PendingDemands.Values.Where(delegate(ReparationDemand d)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime expirationTime = d.ExpirationTime;
				return (expirationTime).IsFuture;
			}).ToList();
			stringBuilder.AppendLine("Pending Reparation Demands:");
			if (list5.Any())
			{
				foreach (ReparationDemand demand in list5)
				{
					Kingdom val6 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == demand.DemandingKingdomId && !k.IsEliminated));
					Kingdom val7 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == demand.PayingKingdomId && !k.IsEliminated));
					if (val6 != null && val7 != null)
					{
						val = demand.ExpirationTime;
						float remainingDaysFromNow2 = (val).RemainingDaysFromNow;
						stringBuilder.AppendLine($"- {val6.Name} (\"{((MBObjectBase)val6).StringId}\") demands {demand.Amount} gold from {val7.Name} (\"{((MBObjectBase)val7).StringId}\") (expires in {remainingDaysFromNow2:F0} days)");
					}
				}
			}
			else
			{
				stringBuilder.AppendLine("- No pending reparation demands");
			}
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine($"Recent Large Battles (>{LARGE_BATTLE_TROOPS_THRESHOLD} troops, last 30 days):");
		List<BattleInfo> recentLargeBattles = GetRecentLargeBattles();
		if (recentLargeBattles.Any())
		{
			foreach (BattleInfo item7 in recentLargeBattles)
			{
				stringBuilder.AppendLine($"- {item7.AttackerKingdom} vs {item7.DefenderKingdom}, winner: {item7.Winner}, near {item7.Location}, leaders: {item7.AttackerLeader} & {item7.DefenderLeader}, {item7.DaysAgo} days ago.");
			}
		}
		else
		{
			stringBuilder.AppendLine("- No recent large battles");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Active Sieges:");
		List<Settlement> list6 = ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsUnderSiege).ToList();
		if (list6.Any())
		{
			foreach (Settlement settlement in list6)
			{
				MobileParty val8 = ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty p) => p.SiegeEvent != null && p.SiegeEvent.BesiegedSettlement == settlement));
				string text3 = "Unknown";
				string text4 = "unknown";
				if (val8 != null)
				{
					IFaction mapFaction = val8.MapFaction;
					Clan val9 = (Clan)(object)((mapFaction is Clan) ? mapFaction : null);
					if (val9 != null && val9.Kingdom != null)
					{
						text3 = ((object)val9.Kingdom.Name)?.ToString() ?? "Unknown";
						text4 = ((MBObjectBase)val9.Kingdom).StringId;
					}
					else if (val8.MapFaction != null)
					{
						text3 = (((object)val8.MapFaction.Name)?.ToString() ?? "Unknown") + " (independent clan)";
						text4 = val8.MapFaction.StringId;
					}
				}
				Clan ownerClan = settlement.OwnerClan;
				object obj;
				if (ownerClan == null)
				{
					obj = null;
				}
				else
				{
					Kingdom kingdom = ownerClan.Kingdom;
					obj = ((kingdom == null) ? null : ((object)kingdom.Name)?.ToString());
				}
				if (obj == null)
				{
					obj = "Independent";
				}
				string text5 = (string)obj;
				Clan ownerClan2 = settlement.OwnerClan;
				object obj2;
				if (ownerClan2 == null)
				{
					obj2 = null;
				}
				else
				{
					Kingdom kingdom2 = ownerClan2.Kingdom;
					obj2 = ((kingdom2 != null) ? ((MBObjectBase)kingdom2).StringId : null);
				}
				if (obj2 == null)
				{
					obj2 = "independent";
				}
				string text6 = (string)obj2;
				object obj3;
				if (val8 == null)
				{
					obj3 = null;
				}
				else
				{
					Hero leaderHero = val8.LeaderHero;
					obj3 = ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString());
				}
				if (obj3 == null)
				{
					obj3 = "Unknown";
				}
				string text7 = (string)obj3;
				object obj4;
				if (val8 == null)
				{
					obj4 = null;
				}
				else
				{
					Hero leaderHero2 = val8.LeaderHero;
					obj4 = ((leaderHero2 != null) ? ((MBObjectBase)leaderHero2).StringId : null);
				}
				if (obj4 == null)
				{
					obj4 = "unknown";
				}
				string text8 = (string)obj4;
				IFaction obj5 = ((val8 != null) ? val8.MapFaction : null);
				IFaction obj6 = ((obj5 is Clan) ? obj5 : null);
				string text9 = ((obj6 == null) ? null : ((object)((Clan)obj6).Name)?.ToString()) ?? "Unknown";
				stringBuilder.AppendLine($"- {settlement.Name} (string_id: \"{((MBObjectBase)settlement).StringId}\") is UNDER SIEGE (not captured yet) by {text3} (string_id: \"{text4}\"), defending: {text5} (string_id: \"{text6}\"), leader: {text7} (string_id: \"{text8}\") from clan {text9}.");
			}
		}
		else
		{
			stringBuilder.AppendLine("- No active sieges");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine($"LARGE ARMIES (>{LARGE_ARMY_TROOPS_THRESHOLD} troops):");
		List<ArmyInfo> largeArmies = GetLargeArmies();
		if (largeArmies.Any())
		{
			foreach (ArmyInfo item8 in largeArmies)
			{
				stringBuilder.AppendLine($"- {item8.ArmyName} ({item8.TotalTroops} troops)");
				stringBuilder.AppendLine("  Leader: " + item8.LeaderName + " (string_id: \"" + item8.LeaderStringId + "\")");
				stringBuilder.AppendLine("  Kingdom: " + item8.KingdomName + " (string_id: \"" + item8.KingdomStringId + "\")");
				stringBuilder.AppendLine("  Location: Near " + item8.Location);
				stringBuilder.AppendLine("  Target: " + item8.Target);
				stringBuilder.AppendLine($"  Parties: {item8.PartyCount} parties in army");
				stringBuilder.AppendLine(string.Format("  Status: {0}, Morale: {1:F0}%", item8.IsDisorganized ? "Disorganized" : "Organized", item8.Morale));
				stringBuilder.AppendLine("  Objective: " + item8.Objective);
			}
		}
		else
		{
			stringBuilder.AppendLine("- No large armies currently active");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("MILITARY INTELLIGENCE:");
		string militaryIntelligence = GetMilitaryIntelligence();
		stringBuilder.AppendLine(militaryIntelligence);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("EXISTING KINGDOMS (use string_id for kingdoms_involved field):");
		stringBuilder.AppendLine("**NOTE: Destroyed kingdoms are not included and should not be referenced in events**");
		foreach (Kingdom item9 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			Hero leader = item9.Leader;
			stringBuilder.AppendLine("- " + (((object)item9.Name)?.ToString() ?? "Unknown"));
			stringBuilder.AppendLine("  string_id: \"" + ((MBObjectBase)item9).StringId + "\"");
			stringBuilder.AppendLine("  Leader: " + (((leader == null) ? null : ((object)leader.Name)?.ToString()) ?? "None"));
			if (leader != null)
			{
				stringBuilder.AppendLine("  Leader string_id: \"" + ((MBObjectBase)leader).StringId + "\"");
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	private string CollectPoliticalWorldData()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		//IL_0619: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		//IL_0775: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08de: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== POLITICAL SITUATION ===");
		stringBuilder.AppendLine();
		CampaignTime now = CampaignTime.Now;
		stringBuilder.AppendLine($"Time: Year {(now).GetYear}, {GetSeasonName((now).GetSeasonOfYear)}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("KINGDOMS AND LEADERS:");
		foreach (Kingdom kingdom in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			Hero leader = kingdom.Leader;
			stringBuilder.AppendLine("- " + (((object)kingdom.Name)?.ToString() ?? "Unknown") + " (string_id: \"" + ((MBObjectBase)kingdom).StringId + "\")");
			stringBuilder.AppendLine(string.Format("  Leader: {0} (string_id: \"{1}\", Age: {2})", ((leader == null) ? null : ((object)leader.Name)?.ToString()) ?? "None", ((leader != null) ? ((MBObjectBase)leader).StringId : null) ?? "none", (leader != null) ? leader.Age : 0f));
			object obj;
			if (leader == null)
			{
				obj = null;
			}
			else
			{
				Clan clan = leader.Clan;
				obj = ((clan == null) ? null : ((object)clan.Name)?.ToString());
			}
			if (obj == null)
			{
				obj = "Unknown";
			}
			stringBuilder.AppendLine("  Clan: " + (string?)obj);
			string text = AnalyzeSuccession(leader);
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendLine("  Succession: " + text);
			}
			IEnumerable<Kingdom> enemyKingdoms = GameVersionCompatibility.GetEnemyKingdoms(kingdom);
			if (enemyKingdoms.Any())
			{
				stringBuilder.AppendLine("  At war with: " + string.Join(", ", enemyKingdoms.Select((Kingdom e) => ((object)e.Name)?.ToString() ?? "Unknown")));
			}
			AllianceSystem allianceSystem = AllianceSystem.Instance;
			if (allianceSystem != null)
			{
				List<Kingdom> source = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => k != kingdom && !k.IsEliminated && allianceSystem.AreAllied(kingdom, k)).ToList();
				if (source.Any())
				{
					stringBuilder.AppendLine("  Allied with: " + string.Join(", ", source.Select((Kingdom a) => ((object)a.Name)?.ToString() ?? "Unknown")));
				}
			}
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("INFLUENTIAL CLANS:");
		List<Clan> list = (from c in (IEnumerable<Clan>)Clan.All
			where c.Tier >= CLAN_TIER_MEDIUM_THRESHOLD && !c.IsMinorFaction && !c.IsBanditFaction
			orderby c.Tier descending
			select c).Take(6).ToList();
		foreach (Clan item in list)
		{
			Hero leader2 = item.Leader;
			string text2 = string.Format("- {0} (Tier {1})", ((object)item.Name)?.ToString() ?? "Unknown", item.Tier);
			if (leader2 != null)
			{
				text2 = text2 + " - Leader: " + (((object)leader2.Name)?.ToString() ?? "Unknown") + " (string_id: \"" + ((MBObjectBase)leader2).StringId + "\")";
			}
			if (item.Kingdom != null)
			{
				text2 = text2 + " - Kingdom: " + (((object)item.Kingdom.Name)?.ToString() ?? "Unknown");
				if (leader2 != null && item.Kingdom.Leader != null && leader2 != item.Kingdom.Leader)
				{
					int relation = leader2.GetRelation(item.Kingdom.Leader);
					text2 += $" - Relations with ruler: {GetRelationDescription(relation)} ({relation})";
				}
			}
			else
			{
				text2 += " - Independent clan";
			}
			stringBuilder.AppendLine(text2);
		}
		stringBuilder.AppendLine();
		DiplomacyManager instance = DiplomacyManager.Instance;
		if (instance != null && instance.IsInitialized)
		{
			TradeAgreementSystem tradeAgreementSystem = instance.GetTradeAgreementSystem();
			TributeSystem tributeSystem = instance.GetTributeSystem();
			ReparationsSystem reparationsSystem = instance.GetReparationsSystem();
			List<TradeAgreementInfo> list2 = tradeAgreementSystem.TradeAgreements.Values.Where(delegate(TradeAgreementInfo t)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime endTime = t.EndTime;
				return (endTime).IsFuture;
			}).ToList();
			stringBuilder.AppendLine("TRADE AGREEMENTS:");
			CampaignTime val3;
			if (list2.Any())
			{
				foreach (TradeAgreementInfo agreement in list2)
				{
					Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == agreement.Kingdom1Id && !k.IsEliminated));
					Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == agreement.Kingdom2Id && !k.IsEliminated));
					if (val != null && val2 != null)
					{
						val3 = agreement.EndTime;
						float num = (val3).RemainingDaysFromNow / (float)CampaignTime.DaysInYear;
						stringBuilder.AppendLine($"- {val.Name} (\"{((MBObjectBase)val).StringId}\") ↔ {val2.Name} (\"{((MBObjectBase)val2).StringId}\") (expires in {num:F1} years)");
					}
				}
			}
			else
			{
				stringBuilder.AppendLine("- No active trade agreements");
			}
			stringBuilder.AppendLine();
			List<TributeAgreement> list3 = tributeSystem.Tributes.Values.Where(delegate(TributeAgreement t)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime endTime = t.EndTime;
				return (endTime).IsFuture;
			}).ToList();
			stringBuilder.AppendLine("ACTIVE TRIBUTES:");
			if (list3.Any())
			{
				foreach (TributeAgreement tribute in list3)
				{
					Kingdom val4 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute.PayerKingdomId && !k.IsEliminated));
					Kingdom val5 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute.ReceiverKingdomId && !k.IsEliminated));
					if (val4 != null && val5 != null)
					{
						val3 = tribute.EndTime;
						float remainingDaysFromNow = (val3).RemainingDaysFromNow;
						stringBuilder.AppendLine($"- {val4.Name} (\"{((MBObjectBase)val4).StringId}\") → {val5.Name} (\"{((MBObjectBase)val5).StringId}\"): {tribute.DailyAmount} gold/day for {remainingDaysFromNow:F0} more days");
					}
				}
			}
			else
			{
				stringBuilder.AppendLine("- No active tributes");
			}
			stringBuilder.AppendLine();
			List<ReparationDemand> list4 = reparationsSystem.PendingDemands.Values.Where(delegate(ReparationDemand d)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime expirationTime = d.ExpirationTime;
				return (expirationTime).IsFuture;
			}).ToList();
			stringBuilder.AppendLine("PENDING REPARATION DEMANDS:");
			if (list4.Any())
			{
				foreach (ReparationDemand demand in list4)
				{
					Kingdom val6 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == demand.DemandingKingdomId && !k.IsEliminated));
					Kingdom val7 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == demand.PayingKingdomId && !k.IsEliminated));
					if (val6 != null && val7 != null)
					{
						val3 = demand.ExpirationTime;
						float remainingDaysFromNow2 = (val3).RemainingDaysFromNow;
						stringBuilder.AppendLine($"- {val6.Name} (\"{((MBObjectBase)val6).StringId}\") demands {demand.Amount} gold from {val7.Name} (\"{((MBObjectBase)val7).StringId}\") (expires in {remainingDaysFromNow2:F0} days)");
					}
				}
			}
			else
			{
				stringBuilder.AppendLine("- No pending reparation demands");
			}
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("POLITICAL TENSIONS:");
		List<string> list5 = AnalyzePoliticalTensions();
		if (list5.Any())
		{
			foreach (string item2 in list5)
			{
				stringBuilder.AppendLine("- " + item2);
			}
		}
		else
		{
			stringBuilder.AppendLine("- No significant political tensions detected");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("INTERNAL CONFLICTS:");
		List<(string, int)> list6 = AnalyzeInternalConflicts();
		if (list6.Any())
		{
			foreach (var item3 in list6)
			{
				stringBuilder.AppendLine("- " + item3.Item1);
			}
		}
		else
		{
			stringBuilder.AppendLine("- No significant internal conflicts detected");
		}
		return stringBuilder.ToString();
	}

	private string CollectEconomicWorldData()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Unknown result type (might be due to invalid IL or missing references)
		//IL_0817: Expected I4, but got Unknown
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== ECONOMIC SITUATION ===");
		stringBuilder.AppendLine();
		CampaignTime now = CampaignTime.Now;
		stringBuilder.AppendLine($"Time: Year {(now).GetYear}, {GetSeasonName((now).GetSeasonOfYear)}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("TRADING CENTERS BY KINGDOM:");
		List<Kingdom> list = (from k in (IEnumerable<Kingdom>)Kingdom.All
			where !k.IsEliminated
			orderby _random.Next()
			select k).Take(4).ToList();
		foreach (Kingdom item in list)
		{
			List<Settlement> source = ((IEnumerable<Settlement>)item.Settlements).Where((Settlement s) => s.IsTown).ToList();
			if (!source.Any())
			{
				continue;
			}
			stringBuilder.AppendLine((((object)item.Name)?.ToString() ?? "Unknown") + " (string_id: \"" + ((MBObjectBase)item).StringId + "\"):");
			Settlement val = source.OrderByDescending((Settlement t) => t.Town.Prosperity).FirstOrDefault();
			if (val != null)
			{
				stringBuilder.AppendLine("  BEST TRADING CENTER:");
				stringBuilder.AppendLine($"    - {val.Name} (string_id: \"{((MBObjectBase)val).StringId}\")");
				CultureObject culture = val.Culture;
				stringBuilder.AppendLine("      Culture: " + (((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown"));
				string[] obj = new string[5] { "      Ruler: ", null, null, null, null };
				Clan ownerClan = val.OwnerClan;
				object obj2;
				if (ownerClan == null)
				{
					obj2 = null;
				}
				else
				{
					Hero leader = ownerClan.Leader;
					obj2 = ((leader == null) ? null : ((object)leader.Name)?.ToString());
				}
				if (obj2 == null)
				{
					obj2 = "Unknown";
				}
				obj[1] = (string)obj2;
				obj[2] = " (string_id: \"";
				Clan ownerClan2 = val.OwnerClan;
				object obj3;
				if (ownerClan2 == null)
				{
					obj3 = null;
				}
				else
				{
					Hero leader2 = ownerClan2.Leader;
					obj3 = ((leader2 != null) ? ((MBObjectBase)leader2).StringId : null);
				}
				if (obj3 == null)
				{
					obj3 = "unknown";
				}
				obj[3] = (string)obj3;
				obj[4] = "\")";
				stringBuilder.AppendLine(string.Concat(obj));
				stringBuilder.AppendLine("      Economic status: " + GetProsperityStatus(val.Town.Prosperity));
				stringBuilder.AppendLine("      Food situation: " + GetFoodStocksStatus(((Fief)val.Town).FoodStocks));
			}
			Settlement val2 = source.OrderBy((Settlement t) => t.Town.Prosperity).FirstOrDefault();
			if (val2 != null)
			{
				stringBuilder.AppendLine("  STRUGGLING TRADING CENTER:");
				stringBuilder.AppendLine($"    - {val2.Name} (string_id: \"{((MBObjectBase)val2).StringId}\")");
				CultureObject culture2 = val2.Culture;
				stringBuilder.AppendLine("      Culture: " + (((culture2 == null) ? null : ((object)((BasicCultureObject)culture2).Name)?.ToString()) ?? "Unknown"));
				string[] obj4 = new string[5] { "      Ruler: ", null, null, null, null };
				Clan ownerClan3 = val2.OwnerClan;
				object obj5;
				if (ownerClan3 == null)
				{
					obj5 = null;
				}
				else
				{
					Hero leader3 = ownerClan3.Leader;
					obj5 = ((leader3 == null) ? null : ((object)leader3.Name)?.ToString());
				}
				if (obj5 == null)
				{
					obj5 = "Unknown";
				}
				obj4[1] = (string)obj5;
				obj4[2] = " (string_id: \"";
				Clan ownerClan4 = val2.OwnerClan;
				object obj6;
				if (ownerClan4 == null)
				{
					obj6 = null;
				}
				else
				{
					Hero leader4 = ownerClan4.Leader;
					obj6 = ((leader4 != null) ? ((MBObjectBase)leader4).StringId : null);
				}
				if (obj6 == null)
				{
					obj6 = "unknown";
				}
				obj4[3] = (string)obj6;
				obj4[4] = "\")";
				stringBuilder.AppendLine(string.Concat(obj4));
				stringBuilder.AppendLine("      Economic status: " + GetProsperityStatus(val2.Town.Prosperity));
				stringBuilder.AppendLine("      Food situation: " + GetFoodStocksStatus(((Fief)val2.Town).FoodStocks));
			}
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("RESOURCES AND PRODUCTION:");
		foreach (Kingdom item2 in list)
		{
			List<Settlement> source2 = ((IEnumerable<Settlement>)item2.Settlements).Where((Settlement s) => s.IsTown).ToList();
			if (!source2.Any())
			{
				continue;
			}
			stringBuilder.AppendLine((((object)item2.Name)?.ToString() ?? "Unknown") + " (string_id: \"" + ((MBObjectBase)item2).StringId + "\"):");
			Settlement val3 = source2.OrderBy((Settlement t) => _random.Next()).FirstOrDefault();
			if (val3 != null)
			{
				List<Village> source3 = ((IEnumerable<Village>)val3.Town.Villages).ToList();
				if (source3.Any())
				{
					stringBuilder.AppendLine($"  {val3.Name} (string_id: \"{((MBObjectBase)val3).StringId}\") production villages:");
					foreach (Village item3 in source3.OrderBy((Village v) => _random.Next()).Take(2))
					{
						Hero val4 = ((IEnumerable<Hero>)((SettlementComponent)item3).Settlement.Notables).FirstOrDefault((Func<Hero, bool>)((Hero n) => n.IsHeadman));
						string text = ((object)item3.VillageType)?.ToString() ?? "Unknown";
						stringBuilder.AppendLine($"    - {((SettlementComponent)item3).Name} (string_id: \"{((MBObjectBase)item3).StringId}\")");
						stringBuilder.AppendLine("      Resource: " + text);
						stringBuilder.AppendLine("      Headman: " + (((val4 == null) ? null : ((object)val4.Name)?.ToString()) ?? "Unknown") + " (string_id: \"" + (((val4 != null) ? ((MBObjectBase)val4).StringId : null) ?? "unknown") + "\")");
						stringBuilder.AppendLine("      Production level: " + GetHearthStatus(item3.Hearth));
					}
				}
			}
			stringBuilder.AppendLine();
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && instance.EnableDiseaseSystem)
		{
			DiseaseManager diseaseManager = DiseaseManager.Instance;
			if (diseaseManager != null)
			{
				List<Settlement> list2 = ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => (s.IsTown || s.IsCastle) && diseaseManager.IsSettlementUnderQuarantine(s)).ToList();
				if (list2.Any())
				{
					stringBuilder.AppendLine("QUARANTINED SETTLEMENTS (officially closed by kingdom rulers):");
					foreach (Settlement item4 in list2)
					{
						TextObject name = item4.Name;
						string stringId = ((MBObjectBase)item4).StringId;
						Clan ownerClan5 = item4.OwnerClan;
						object obj7;
						if (ownerClan5 == null)
						{
							obj7 = null;
						}
						else
						{
							Kingdom kingdom = ownerClan5.Kingdom;
							obj7 = ((kingdom == null) ? null : ((object)kingdom.Name)?.ToString());
						}
						if (obj7 == null)
						{
							obj7 = "Unknown";
						}
						stringBuilder.AppendLine($"- {name} (string_id: \"{stringId}\"), Kingdom: {obj7}");
					}
					stringBuilder.AppendLine("**IMPORTANT:** Do NOT use the word 'quarantine' for settlements NOT in this list. Only these have official quarantine.");
					stringBuilder.AppendLine();
				}
			}
		}
		stringBuilder.AppendLine("SEASONAL ECONOMIC FACTORS:");
		Seasons getSeasonOfYear = (now).GetSeasonOfYear;
		Seasons val5 = getSeasonOfYear;
		Seasons val6 = val5;
		switch ((int)val6)
		{
		case 0:
			stringBuilder.AppendLine("- Spring: Agricultural planting season, trade routes reopening after winter");
			stringBuilder.AppendLine("- Food stocks may be low after winter, prices higher");
			stringBuilder.AppendLine("- Agricultural villages preparing for planting");
			break;
		case 1:
			stringBuilder.AppendLine("- Summer: Peak trading season, agricultural growth period");
			stringBuilder.AppendLine("- Food production at maximum, trade routes most active");
			stringBuilder.AppendLine("- Best time for economic prosperity");
			break;
		case 2:
			stringBuilder.AppendLine("- Autumn: Harvest season, preparation for winter");
			stringBuilder.AppendLine("- Food stocks being replenished, trade activity high");
			stringBuilder.AppendLine("- Critical period for food security");
			break;
		case 3:
			stringBuilder.AppendLine("- Winter: Reduced trade, resource scarcity, higher prices");
			stringBuilder.AppendLine("- Food stocks being consumed, agricultural production minimal");
			stringBuilder.AppendLine("- Economic hardship period, especially for struggling settlements");
			break;
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("EXISTING KINGDOMS (use string_id for kingdoms_involved field):");
		stringBuilder.AppendLine("**NOTE: Destroyed kingdoms are not included and should not be referenced in events**");
		foreach (Kingdom item5 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			Hero leader5 = item5.Leader;
			stringBuilder.AppendLine("- " + (((object)item5.Name)?.ToString() ?? "Unknown"));
			stringBuilder.AppendLine("  string_id: \"" + ((MBObjectBase)item5).StringId + "\"");
			stringBuilder.AppendLine("  Leader: " + (((leader5 == null) ? null : ((object)leader5.Name)?.ToString()) ?? "None"));
			if (leader5 != null)
			{
				stringBuilder.AppendLine("  Leader string_id: \"" + ((MBObjectBase)leader5).StringId + "\"");
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	private string CollectSocialWorldData()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== SOCIAL SITUATION ===");
		stringBuilder.AppendLine();
		CampaignTime now = CampaignTime.Now;
		stringBuilder.AppendLine($"Time: Year {(now).GetYear}, {GetSeasonName((now).GetSeasonOfYear)}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("RECENT NOBLE MARRIAGES:");
		List<MarriageInfo> recentMarriages = GetRecentMarriages();
		if (recentMarriages.Any())
		{
			foreach (MarriageInfo item in recentMarriages)
			{
				stringBuilder.AppendLine("- " + item.HusbandName + " (string_id: \"" + item.HusbandStringId + "\", " + item.HusbandKingdomName + " (string_id: \"" + item.HusbandKingdomStringId + "\")) married " + item.WifeName + " (string_id: \"" + item.WifeStringId + "\", " + item.WifeKingdomName + " (string_id: \"" + item.WifeKingdomStringId + "\"))");
				stringBuilder.AppendLine("  Political significance: " + item.PoliticalSignificance);
				stringBuilder.AppendLine($"  Days ago: {item.DaysAgo}");
			}
		}
		else
		{
			stringBuilder.AppendLine("- No recent noble marriages");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("RECENT DEATHS OF IMPORTANT FIGURES (CRITICAL INFORMATION):");
		stringBuilder.AppendLine("**IMPORTANT: Kingdom leader deaths cause succession crises and major political shifts. Pay special attention to these.**");
		List<DeathInfo> recentImportantDeaths = GetRecentImportantDeaths(20);
		if (recentImportantDeaths.Any())
		{
			foreach (DeathInfo item2 in recentImportantDeaths)
			{
				stringBuilder.AppendLine("- " + item2.HeroName + " (string_id: \"" + item2.HeroStringId + "\") - " + item2.Title);
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
		stringBuilder.AppendLine("CULTURAL INFORMATION:");
		Dictionary<string, string> culturalTraditions = GetCulturalTraditions();
		List<Kingdom> list = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated).Take(4).ToList();
		foreach (Kingdom item3 in list)
		{
			CultureObject culture = item3.Culture;
			string text = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown";
			CultureObject culture2 = item3.Culture;
			string key = ((culture2 != null) ? ((MBObjectBase)culture2).StringId : null) ?? "unknown";
			string text2 = "No description available";
			if (culturalTraditions.TryGetValue(key, out var value) || culturalTraditions.TryGetValue(text, out value))
			{
				text2 = value;
			}
			stringBuilder.AppendLine($"- {item3.Name} (string_id: \"{((MBObjectBase)item3).StringId}\"):");
			stringBuilder.AppendLine("  Culture: " + text);
			stringBuilder.AppendLine("  Description: " + text2);
			string[] obj = new string[5] { "  Leader: ", null, null, null, null };
			Hero leader = item3.Leader;
			obj[1] = ((leader == null) ? null : ((object)leader.Name)?.ToString()) ?? "None";
			obj[2] = " (string_id: \"";
			Hero leader2 = item3.Leader;
			obj[3] = ((leader2 != null) ? ((MBObjectBase)leader2).StringId : null) ?? "none";
			obj[4] = "\")";
			stringBuilder.AppendLine(string.Concat(obj));
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("AVAILABLE CHARACTERS FOR SOCIAL EVENTS:");
		List<Hero> list2 = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h.IsLord && h.Clan != null && h.Clan.Tier >= 4).Take(8).ToList();
		foreach (Hero item4 in list2)
		{
			string arg = (item4.IsKingdomLeader ? "Ruler" : GetClanTierStatus(item4.Clan.Tier));
			stringBuilder.AppendLine($"- {item4.Name} (string_id: \"{((MBObjectBase)item4).StringId}\") - {arg}");
			string[] obj2 = new string[5] { "  Kingdom: ", null, null, null, null };
			IFaction mapFaction = item4.MapFaction;
			obj2[1] = ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString()) ?? "Independent";
			obj2[2] = " (string_id: \"";
			IFaction mapFaction2 = item4.MapFaction;
			obj2[3] = ((mapFaction2 != null) ? mapFaction2.StringId : null) ?? "independent";
			obj2[4] = "\")";
			stringBuilder.AppendLine(string.Concat(obj2));
			CultureObject culture3 = item4.Culture;
			stringBuilder.AppendLine("  Culture: " + (((culture3 == null) ? null : ((object)((BasicCultureObject)culture3).Name)?.ToString()) ?? "Unknown"));
			stringBuilder.AppendLine($"  Age: {item4.Age}");
			Hero spouse = item4.Spouse;
			stringBuilder.AppendLine("  Spouse: " + (((spouse == null) ? null : ((object)spouse.Name)?.ToString()) ?? "None"));
		}
		return stringBuilder.ToString();
	}

	private string CollectMysteriousWorldData()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== MYSTERIOUS SITUATION ===");
		stringBuilder.AppendLine();
		CampaignTime now = CampaignTime.Now;
		stringBuilder.AppendLine($"Time: Year {(now).GetYear}, {GetSeasonName((now).GetSeasonOfYear)}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("POTENTIAL DISCOVERY LOCATIONS:");
		List<DiscoveryLocation> potentialDiscoveryLocations = GetPotentialDiscoveryLocations();
		foreach (DiscoveryLocation item in potentialDiscoveryLocations)
		{
			stringBuilder.AppendLine("- " + item.SettlementName + " (string_id: \"" + item.SettlementStringId + "\") - " + item.SettlementType);
			stringBuilder.AppendLine("  Kingdom: " + item.KingdomName + " (string_id: \"" + item.KingdomStringId + "\")");
			stringBuilder.AppendLine("  Culture: " + item.Culture);
			stringBuilder.AppendLine("  Discovery potential: " + item.DiscoveryPotential);
			stringBuilder.AppendLine("  Ruler: " + item.RulerName + " (string_id: \"" + item.RulerStringId + "\")");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("DISEASE-VULNERABLE SETTLEMENTS:");
		List<DiseaseVulnerableSettlement> diseaseVulnerableSettlements = GetDiseaseVulnerableSettlements();
		foreach (DiseaseVulnerableSettlement item2 in diseaseVulnerableSettlements)
		{
			stringBuilder.AppendLine("- " + item2.SettlementName + " (string_id: \"" + item2.SettlementStringId + "\") - " + item2.SettlementType);
			stringBuilder.AppendLine("  Kingdom: " + item2.KingdomName + " (string_id: \"" + item2.KingdomStringId + "\")");
			stringBuilder.AppendLine("  Culture: " + item2.Culture);
			stringBuilder.AppendLine("  Vulnerability: " + item2.VulnerabilityLevel);
			stringBuilder.AppendLine("  Risk factors: " + item2.RiskFactors);
			stringBuilder.AppendLine("  Ruler: " + item2.RulerName + " (string_id: \"" + item2.RulerStringId + "\")");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("SETTLEMENTS WITH STRANGE OCCURRENCES POTENTIAL:");
		List<StrangeOccurrenceSettlement> strangeOccurrenceSettlements = GetStrangeOccurrenceSettlements();
		foreach (StrangeOccurrenceSettlement item3 in strangeOccurrenceSettlements)
		{
			stringBuilder.AppendLine("- " + item3.SettlementName + " (string_id: \"" + item3.SettlementStringId + "\") - " + item3.SettlementType);
			stringBuilder.AppendLine("  Kingdom: " + item3.KingdomName + " (string_id: \"" + item3.KingdomStringId + "\")");
			stringBuilder.AppendLine("  Culture: " + item3.Culture);
			stringBuilder.AppendLine("  Strange potential: " + item3.StrangePotential);
			stringBuilder.AppendLine("  Contributing factors: " + item3.ContributingFactors);
			stringBuilder.AppendLine("  Ruler: " + item3.RulerName + " (string_id: \"" + item3.RulerStringId + "\")");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("EXISTING KINGDOMS (use string_id for kingdoms_involved field):");
		stringBuilder.AppendLine("**NOTE: Destroyed kingdoms are not included and should not be referenced in events**");
		foreach (Kingdom item4 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			Hero leader = item4.Leader;
			stringBuilder.AppendLine("- " + (((object)item4.Name)?.ToString() ?? "Unknown"));
			stringBuilder.AppendLine("  string_id: \"" + ((MBObjectBase)item4).StringId + "\"");
			stringBuilder.AppendLine("  Leader: " + (((leader == null) ? null : ((object)leader.Name)?.ToString()) ?? "None"));
			if (leader != null)
			{
				stringBuilder.AppendLine("  Leader string_id: \"" + ((MBObjectBase)leader).StringId + "\"");
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	private string CollectDiseaseOutbreakWorldData()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected I4, but got Unknown
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== DISEASE OUTBREAK SITUATION ===");
		stringBuilder.AppendLine();
		CampaignTime now = CampaignTime.Now;
		stringBuilder.AppendLine($"Time: Year {(now).GetYear}, {GetSeasonName((now).GetSeasonOfYear)}");
		Seasons getSeasonOfYear = (now).GetSeasonOfYear;
		stringBuilder.AppendLine("Season disease risk: " + (int)getSeasonOfYear switch
		{
			3 => "High risk - cold weather increases respiratory illness spread", 
			2 => "Moderate-high risk - harvests bring travelers and disease vectors", 
			0 => "Moderate risk - thawing conditions can spread waterborne diseases", 
			1 => "Low-moderate risk - heat can increase food spoilage and dysentery", 
			_ => "Unknown", 
		});
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("SETTLEMENTS AT HIGH RISK FOR DISEASE OUTBREAKS:");
		List<DiseaseVulnerableSettlement> diseaseVulnerableSettlements = GetDiseaseVulnerableSettlements();
		foreach (DiseaseVulnerableSettlement item in diseaseVulnerableSettlements)
		{
			stringBuilder.AppendLine("- " + item.SettlementName + " (string_id: \"" + item.SettlementStringId + "\") - " + item.SettlementType);
			stringBuilder.AppendLine("  Kingdom: " + item.KingdomName + " (string_id: \"" + item.KingdomStringId + "\")");
			stringBuilder.AppendLine("  Culture: " + item.Culture);
			stringBuilder.AppendLine("  Vulnerability level: " + item.VulnerabilityLevel);
			stringBuilder.AppendLine("  Risk factors: " + item.RiskFactors);
			stringBuilder.AppendLine("  Ruler: " + item.RulerName + " (string_id: \"" + item.RulerStringId + "\")");
		}
		stringBuilder.AppendLine();
		DiseaseManager instance = DiseaseManager.Instance;
		if (instance != null)
		{
			List<Disease> allDiseases = instance.GetAllDiseases();
			if (allDiseases != null && allDiseases.Count > 0)
			{
				stringBuilder.AppendLine("CURRENTLY ACTIVE DISEASES:");
				foreach (Disease item2 in allDiseases.Take(5))
				{
					stringBuilder.AppendLine($"- {item2.Name} (severity: {item2.Severity}/5)");
					stringBuilder.AppendLine("  Location: " + item2.SettlementId);
					stringBuilder.AppendLine($"  Quarantined: {item2.IsQuarantined}");
				}
				stringBuilder.AppendLine();
			}
		}
		stringBuilder.AppendLine("EXISTING KINGDOMS (use string_id for kingdoms_involved field):");
		foreach (Kingdom item3 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			Hero leader = item3.Leader;
			stringBuilder.AppendLine("- " + (((object)item3.Name)?.ToString() ?? "Unknown"));
			stringBuilder.AppendLine("  string_id: \"" + ((MBObjectBase)item3).StringId + "\"");
			stringBuilder.AppendLine("  Leader: " + (((leader == null) ? null : ((object)leader.Name)?.ToString()) ?? "None"));
			if (leader != null)
			{
				stringBuilder.AppendLine("  Leader string_id: \"" + ((MBObjectBase)leader).StringId + "\"");
			}
		}
		return stringBuilder.ToString();
	}

	private string AnalyzeSuccession(Hero ruler)
	{
		if (ruler == null)
		{
			return "";
		}
		List<string> list = new List<string>();
		if (ruler.Age > (float)RULER_AGE_OLD_THRESHOLD)
		{
			list.Add("Aging ruler");
		}
		if (ruler.IsWounded)
		{
			list.Add("Ruler is wounded");
		}
		if (!((IEnumerable<Hero>)ruler.Children).Any())
		{
			list.Add("No clear heir");
		}
		else
		{
			List<Hero> source = ((IEnumerable<Hero>)ruler.Children).Where((Hero c) => c.Age >= (float)HEIR_ADULT_AGE_THRESHOLD).ToList();
			if (!source.Any())
			{
				list.Add("Heirs too young");
			}
		}
		if (ruler.Siblings.Any())
		{
			list.Add("Has siblings who could claim succession");
		}
		return list.Any() ? string.Join(", ", list) : "";
	}

	private List<string> AnalyzePoliticalTensions()
	{
		List<string> list = new List<string>();
		foreach (Kingdom item in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			Hero ruler = item.Leader;
			if (ruler == null)
			{
				continue;
			}
			List<Clan> list2 = (from c in (IEnumerable<Clan>)item.Clans
				where c.Tier >= CLAN_TIER_MEDIUM_THRESHOLD && c.Leader != null && c.Leader != ruler
				where c.Leader.GetRelation(ruler) < -10
				select c).ToList();
			foreach (Clan item2 in list2)
			{
				list.Add($"{item2.Name} ({item2.Leader.Name}, string_id: \"{((MBObjectBase)item2.Leader).StringId}\") shows discontent with {ruler.Name} (string_id: \"{((MBObjectBase)ruler).StringId}\", relations: {GetRelationDescription(item2.Leader.GetRelation(ruler))} ({item2.Leader.GetRelation(ruler)}))");
			}
			List<Clan> source = ((IEnumerable<Clan>)Clan.All).Where((Clan c) => c.Tier >= CLAN_TIER_MEDIUM_THRESHOLD && c.Kingdom == null && !c.IsMinorFaction && !c.IsBanditFaction).ToList();
			foreach (Clan item3 in source.Take(3))
			{
				TextObject name = item3.Name;
				Hero leader = item3.Leader;
				TextObject arg = ((leader != null) ? leader.Name : null);
				Hero leader2 = item3.Leader;
				list.Add($"{name} ({arg}, string_id: \"{((leader2 != null) ? ((MBObjectBase)leader2).StringId : null)}\") is independent and may seek to join a kingdom");
			}
		}
		return list;
	}

	private List<(string conflictText, int severity)> AnalyzeInternalConflicts()
	{
		List<(string, int)> list = new List<(string, int)>();
		foreach (Kingdom kingdom in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			List<Clan> list2 = ((IEnumerable<Clan>)kingdom.Clans).Where((Clan c) => c.Leader != null).ToList();
			for (int num = 0; num < list2.Count; num++)
			{
				for (int num2 = num + 1; num2 < list2.Count; num2++)
				{
					Clan val = list2[num];
					Clan val2 = list2[num2];
					if (val.Tier >= 4 && val2.Tier >= 4)
					{
						int relation = val.Leader.GetRelation(val2.Leader);
						if (relation < -20)
						{
							string item = $"Rivalry between {val.Name} ({val.Leader.Name}, string_id: \"{((MBObjectBase)val.Leader).StringId}\") and {val2.Name} ({val2.Leader.Name}, string_id: \"{((MBObjectBase)val2.Leader).StringId}\") in {kingdom.Name} (relations: {GetRelationDescription(relation)} ({relation}))";
							list.Add((item, relation));
						}
					}
				}
			}
			List<Clan> source = ((IEnumerable<Clan>)kingdom.Clans).Where((Clan c) => c.Culture != kingdom.Culture && c.Leader != null).ToList();
			foreach (Clan item3 in source.Take(2))
			{
				object[] obj = new object[5]
				{
					item3.Name,
					item3.Leader.Name,
					((MBObjectBase)item3.Leader).StringId,
					null,
					null
				};
				CultureObject culture = item3.Culture;
				obj[3] = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown";
				obj[4] = kingdom.Name;
				string item2 = string.Format("{0} ({1}, string_id: \"{2}\") is of different culture ({3}) in {4}", obj);
				list.Add((item2, -10));
			}
		}
		return list.OrderBy<(string, int), int>(((string conflictText, int severity) c) => c.severity).Take(3).ToList();
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

	private string GetExistingEventsData()
	{
		List<DynamicEvent> activeEvents = DynamicEventsManager.Instance.GetActiveEvents();
		if (!activeEvents.Any())
		{
			return "No existing dynamic events.";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== EXISTING DYNAMIC EVENTS (DO NOT DUPLICATE) ===");
		foreach (DynamicEvent item in activeEvents.OrderByDescending((DynamicEvent e) => e.CreationTime).Take(8))
		{
			stringBuilder.AppendLine($"- [{item.Type}] {item.Description} (created {item.DaysSinceCreation} days ago)");
		}
		return stringBuilder.ToString();
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
				return "=== ACTIVE ECONOMIC EFFECTS ===\nNo economic effects manager available.\n";
			}
			List<ActiveEconomicEffect> activeEffects = instance.GetActiveEffects();
			if (activeEffects == null || !activeEffects.Any())
			{
				return "=== ACTIVE ECONOMIC EFFECTS ===\nNo active economic effects.\n";
			}
			CampaignTime now = CampaignTime.Now;
			float currentDay = (float)(now).ToDays;
			List<ActiveEconomicEffect> list = activeEffects.Where((ActiveEconomicEffect e) => currentDay < e.StartDay + (float)e.DurationDays).ToList();
			if (!list.Any())
			{
				return "=== ACTIVE ECONOMIC EFFECTS ===\nNo active economic effects.\n";
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
			stringBuilder.AppendLine("Grouped by reason/effect to avoid per-settlement spam:");
			stringBuilder.AppendLine();
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
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Error getting active economic effects: " + ex.Message);
			return "=== ACTIVE ECONOMIC EFFECTS ===\nError retrieving economic effects data.\n";
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

	private string CollectDialogueData(out bool hasNewDialogues)
	{
		hasNewDialogues = false;
		AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
		if (instance == null)
		{
			return null;
		}
		Dictionary<string, NPCContext> nPCContexts = instance.GetNPCContexts();
		if (nPCContexts == null || !nPCContexts.Any())
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== NEW NPC DIALOGUES (since last analysis) ===");
		int num = 0;
		List<KeyValuePair<string, NPCContext>> list = nPCContexts.ToList();
		foreach (KeyValuePair<string, NPCContext> item in list)
		{
			NPCContext context = item.Value;
			List<string> newMessagesForEventAnalysis = context.GetNewMessagesForEventAnalysis();
			if (newMessagesForEventAnalysis == null || !newMessagesForEventAnalysis.Any())
			{
				continue;
			}
			string arg = "unknown";
			Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((object)h.Name)?.ToString() == context.Name));
			if (val != null)
			{
				arg = ((MBObjectBase)val).StringId ?? "unknown";
			}
			stringBuilder.AppendLine($"\nNew dialogue with {context.Name} (string_id: \"{arg}\", {newMessagesForEventAnalysis.Count} messages):");
			foreach (string item2 in newMessagesForEventAnalysis)
			{
				stringBuilder.AppendLine("  " + item2);
			}
			IReadOnlyList<string> mentionedSettlementSummaries = SettlementMentionParser.GetMentionedSettlementSummaries(newMessagesForEventAnalysis, newMessagesForEventAnalysis.Count, val);
			if (mentionedSettlementSummaries != null && mentionedSettlementSummaries.Count > 0)
			{
				stringBuilder.AppendLine("  **Settlements mentioned in this dialogue (use these exact IDs for economic_effects target_id):**");
				foreach (string item3 in mentionedSettlementSummaries)
				{
					stringBuilder.AppendLine("    - " + item3);
				}
			}
			num += newMessagesForEventAnalysis.Count;
		}
		if (num == 0)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] No new dialogues to analyze");
			return null;
		}
		hasNewDialogues = true;
		DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] Found {num} new dialogue messages from {nPCContexts.Count((KeyValuePair<string, NPCContext> kvp) => kvp.Value.GetNewMessagesForEventAnalysis().Any())} NPCs");
		return stringBuilder.ToString();
	}

	private async Task ProcessDialogueOnlyMode(string dialogueData)
	{
		try
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Processing dialogues in dialogue-only mode");
			string worldData = CollectMinimalWorldData();
			string existingEvents = GetExistingEventsData();
			string diplomaticStatements = "=== DIPLOMACY SYSTEM TEMPORARILY DISABLED ===";
			string prompt = BuildEventGenerationPrompt(worldData, existingEvents, diplomaticStatements, dialogueData, hasDialogues: true);
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] Sending dialogue analysis prompt to AI ({prompt.Length} characters)");
			AIInfluenceBehavior behavior = AIInfluenceBehavior.Instance;
			if (behavior == null)
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] AIInfluenceBehavior instance not found");
				return;
			}
			string aiResponse = await behavior.SendAIRequestWithBackend(prompt, "dynamic_events", GlobalSettings<ModSettings>.Instance.DynamicEventsAIBackend.SelectedValue);
			if (string.IsNullOrEmpty(aiResponse))
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Empty AI response for dialogue analysis - API may be unavailable");
				if (aiResponse != null && (aiResponse.Contains("API key is missing") || aiResponse.Contains("Error:")))
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] API Error detected in dialogue analysis: " + aiResponse);
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Scheduling retry in 1 day due to API issues");
					DynamicEventsManager.Instance.ScheduleGenerationForNextDay();
				}
				else
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Empty response for dialogue analysis - no events generated this time");
				}
				return;
			}
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] AI response received ({aiResponse.Length} characters)");
			DynamicEventsResponse eventsResponse = ParseAIResponse(aiResponse);
			if (eventsResponse == null || !eventsResponse.Events.Any())
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] No events generated by AI from dialogues in dialogue-only mode");
				DynamicEventsLogger.Instance.Log("=== DIALOGUE ANALYSIS (DIALOGUE-ONLY MODE) ===");
				DynamicEventsLogger.Instance.Log("PROMPT SENT TO AI:");
				DynamicEventsLogger.Instance.Log("-------------------");
				DynamicEventsLogger.Instance.Log(prompt);
				DynamicEventsLogger.Instance.Log("");
				DynamicEventsLogger.Instance.Log("AI RESPONSE:");
				DynamicEventsLogger.Instance.Log("-------------------");
				DynamicEventsLogger.Instance.Log(aiResponse);
				DynamicEventsLogger.Instance.Log("");
				DynamicEventsLogger.Instance.Log("RESULT: No events generated");
				DynamicEventsLogger.Instance.Log("=== DIALOGUE ANALYSIS END ===");
				DynamicEventsLogger.Instance.Log("");
			}
			else
			{
				DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] AI generated {eventsResponse.Events.Count} events from dialogues (dialogue-only mode - adding to NPC contexts only)");
				foreach (DynamicEvent dynamicEvent in eventsResponse.Events)
				{
					dynamicEvent.CreationTime = DateTime.Now;
					CampaignTime now = CampaignTime.Now;
					dynamicEvent.CreationCampaignDays = (float)(now).ToDays;
					dynamicEvent.ExpirationCampaignDays = dynamicEvent.CreationCampaignDays + (float)GlobalSettings<ModSettings>.Instance.DynamicEventsLifespan;
					dynamicEvent.ExpirationTime = DateTime.Now.AddDays(GlobalSettings<ModSettings>.Instance.DynamicEventsLifespan);
					AddEventToNPCContexts(dynamicEvent);
				}
				DynamicEventsLogger.Instance.Log("=== DIALOGUE ANALYSIS (DIALOGUE-ONLY MODE) ===");
				DynamicEventsLogger.Instance.Log("PROMPT SENT TO AI:");
				DynamicEventsLogger.Instance.Log("-------------------");
				DynamicEventsLogger.Instance.Log(prompt);
				DynamicEventsLogger.Instance.Log("");
				DynamicEventsLogger.Instance.Log("AI RESPONSE:");
				DynamicEventsLogger.Instance.Log("-------------------");
				DynamicEventsLogger.Instance.Log(aiResponse);
				DynamicEventsLogger.Instance.Log("");
				DynamicEventsLogger.Instance.Log($"RESULT: {eventsResponse.Events.Count} events generated and added to NPC contexts only (dialogue-only mode)");
				DynamicEventsLogger.Instance.Log("=== DIALOGUE ANALYSIS END ===");
				DynamicEventsLogger.Instance.Log("");
			}
			MarkDialoguesAsAnalyzed();
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Dialogue analysis completed in dialogue-only mode");
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Error in dialogue-only mode: " + ex2.Message);
		}
	}

	private void AddEventToNPCContexts(DynamicEvent dynamicEvent)
	{
		if (dynamicEvent == null)
		{
			return;
		}
		AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
		if (instance == null)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] AIInfluenceBehavior instance not found");
			return;
		}
		Dictionary<string, NPCContext> nPCContexts = instance.GetNPCContexts();
		if (nPCContexts == null || !nPCContexts.Any())
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] No NPC contexts found");
			return;
		}
		List<KeyValuePair<string, NPCContext>> list = nPCContexts.ToList();
		int num = 0;
		foreach (KeyValuePair<string, NPCContext> item in list)
		{
			string key = item.Key;
			NPCContext context = item.Value;
			Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == context.StringId));
			if (val != null && ShouldNPCKnowEvent(val, context, dynamicEvent))
			{
				context.AddDynamicEvent(dynamicEvent.Id);
				num++;
				instance.SaveNPCContext(key, val, context);
			}
		}
		DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] Added event '{dynamicEvent.Id}' to {num} NPC contexts (dialogue-only mode)");
	}

	private bool ShouldNPCKnowEvent(Hero npc, NPCContext context, DynamicEvent dynamicEvent)
	{
		if (npc == null || context == null || dynamicEvent == null)
		{
			return false;
		}
		if (dynamicEvent.ApplicableNPCs != null && dynamicEvent.ApplicableNPCs.Any())
		{
			return IsApplicableNPC(npc, dynamicEvent.ApplicableNPCs);
		}
		List<string> kingdomStringIds = dynamicEvent.GetKingdomStringIds();
		if (kingdomStringIds != null && kingdomStringIds.Any())
		{
			if (kingdomStringIds.Contains("all"))
			{
				return true;
			}
			Clan clan = npc.Clan;
			Kingdom val = ((clan != null) ? clan.Kingdom : null);
			if (val != null && kingdomStringIds.Contains(((MBObjectBase)val).StringId))
			{
				return true;
			}
		}
		if (dynamicEvent.CharactersInvolved != null && dynamicEvent.CharactersInvolved.Any() && dynamicEvent.CharactersInvolved.Contains(((MBObjectBase)npc).StringId))
		{
			return true;
		}
		return dynamicEvent.Importance >= 8;
	}

	private bool IsApplicableNPC(Hero npc, List<string> applicableNPCs)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		if (applicableNPCs.Contains("all"))
		{
			return true;
		}
		if (applicableNPCs.Contains("lords") && (int)npc.Occupation == 3)
		{
			return true;
		}
		if (applicableNPCs.Contains("companions") && npc.IsWanderer)
		{
			return true;
		}
		if (applicableNPCs.Contains("faction_leaders"))
		{
			Clan clan = npc.Clan;
			object obj;
			if (clan == null)
			{
				obj = null;
			}
			else
			{
				IFaction mapFaction = clan.MapFaction;
				obj = ((mapFaction != null) ? mapFaction.Leader : null);
			}
			if (npc == obj)
			{
				return true;
			}
		}
		if (applicableNPCs.Contains("village_notables") && npc.IsNotable)
		{
			Settlement currentSettlement = npc.CurrentSettlement;
			if (currentSettlement != null && currentSettlement.IsVillage)
			{
				return true;
			}
		}
		if (applicableNPCs.Contains("merchants") && npc.IsMerchant)
		{
			return true;
		}
		return false;
	}

	private void MarkDialoguesAsAnalyzed()
	{
		AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
		if (instance == null)
		{
			return;
		}
		Dictionary<string, NPCContext> nPCContexts = instance.GetNPCContexts();
		if (nPCContexts == null)
		{
			return;
		}
		List<KeyValuePair<string, NPCContext>> list = nPCContexts.ToList();
		int num = 0;
		foreach (KeyValuePair<string, NPCContext> item in list)
		{
			NPCContext context = item.Value;
			List<string> newMessagesForEventAnalysis = context.GetNewMessagesForEventAnalysis();
			if (newMessagesForEventAnalysis != null && newMessagesForEventAnalysis.Any())
			{
				int lastEventAnalysisMessageIndex = context.LastEventAnalysisMessageIndex;
				context.MarkMessagesAsSentToEventAnalysis();
				int lastEventAnalysisMessageIndex2 = context.LastEventAnalysisMessageIndex;
				nPCContexts[item.Key] = context;
				Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == context.StringId));
				if (val != null)
				{
					instance.SaveNPCContext(item.Key, val, context);
					num++;
					DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] Marked {newMessagesForEventAnalysis.Count} messages as analyzed for {context.Name} (index: {lastEventAnalysisMessageIndex} -> {lastEventAnalysisMessageIndex2})");
				}
				else
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] WARNING: Could not find Hero for " + context.StringId + " to save context after marking dialogues");
				}
			}
		}
		DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] Marked all dialogues as analyzed for {num} NPCs");
	}

	private string GenerateInternalThoughtsSection(bool hasDialogues, string selectedEventType)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableDynamicEventsInternalThoughts)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("### CRITICAL: Internal Thought Process (REQUIRED BEFORE GENERATING EVENTS) ###");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**PRIVATE reasoning process for logical, consistent, and engaging events that fit the world state.**");
		stringBuilder.AppendLine();
		string value = WorldInfoManager.Instance?.ReadEventsGeneratorRules();
		bool flag = !string.IsNullOrEmpty(value);
		if (flag)
		{
			stringBuilder.AppendLine("**OVERRIDE RULES (ABSOLUTE PRIORITY - CHECK IN STEP 7)**");
			stringBuilder.AppendLine("The player has set custom event generation rules that OVERRIDE all other instructions:");
			stringBuilder.AppendLine(value);
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("**STEP 0: VERIFY FACTS (MANDATORY)**");
		stringBuilder.AppendLine("Before reasoning, verify CURRENT WORLD DATA:");
		stringBuilder.AppendLine("- Kingdoms exist? (Check 'EXISTING KINGDOMS' - destroyed excluded) Wars? Sieges? (UNDER SIEGE ≠ CAPTURED) Large armies? Recent battles? Diplomatic agreements?");
		stringBuilder.AppendLine("- **CRITICAL:** Do NOT confuse 'UNDER SIEGE' with 'CAPTURED'. Facts from CURRENT WORLD DATA only. Do NOT hallucinate. If conflict with existing events → CURRENT DATA IS CORRECT.");
		stringBuilder.AppendLine("- Format: internal_thoughts starts with 'FACT CHECK:' + verified facts from current data.");
		stringBuilder.AppendLine();
		if (hasDialogues)
		{
			stringBuilder.AppendLine("**STEP 1: DIALOGUE ANALYSIS (DIALOGUE MODE)**");
			stringBuilder.AppendLine("- What information discussed? PUBLIC/WORLD-IMPACTING or SECRET/PRIVATE?");
			stringBuilder.AppendLine("- **CRITICAL:** Only PUBLIC info NPCs share openly. **FORBIDDEN:** SECRET/CONFIDENTIAL/PRIVATE.");
			stringBuilder.AppendLine("- Event type? (military/political/economic/social) Kingdoms/characters involved? Relation to world state?");
			stringBuilder.AppendLine("- **IMPORTANT:** If only personal/secret or lacks public world-impact → return empty events array.");
			stringBuilder.AppendLine();
		}
		else
		{
			stringBuilder.AppendLine("**STEP 1: WORLD STATE ANALYSIS (WORLD STATE MODE)**");
			stringBuilder.AppendLine("- Selected type: " + (string.IsNullOrEmpty(selectedEventType) ? "not specified (general)" : selectedEventType));
			stringBuilder.AppendLine("- Most significant developments? Conflicts/tensions/opportunities? Most INTERESTING/LOGICAL event? How does selected type guide focus?");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("**STEP 2: EXISTING EVENTS + DIPLOMATIC CONTEXT (COMBINED)**");
		stringBuilder.AppendLine("- Existing: Review 'EXISTING EVENTS'. Already created? Duplicate/conflict? **CRITICAL:** Avoid similar events. If world state changed → CURRENT DATA = truth. How to create UNIQUE event?");
		stringBuilder.AppendLine("- Diplomatic: Recent statements? Relation to world state? Trigger diplomatic responses? (allows_diplomatic_response: true/false) If true → which kingdoms MUST be in kingdoms_involved? Fit into narrative?");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 3: LOGICAL CONSISTENCY**");
		stringBuilder.AppendLine("- Makes logical sense? Kingdoms/characters ACTUALLY exist? (Check current data)");
		stringBuilder.AppendLine("- **CRITICAL:** Never reference destroyed kingdoms or non-existent characters. string_ids correct? (Check 'EXISTING KINGDOMS')");
		stringBuilder.AppendLine("- Event type matches content? (military = military, etc.) Importance appropriate? (10=world-changing, 7-9=major, 4-6=notable, 1-3=minor) CAUSE → ACTION → CONSEQUENCE structure?");
		stringBuilder.AppendLine();
		if (selectedEventType == "economic" || hasDialogues)
		{
			stringBuilder.AppendLine("**STEP 4: ECONOMIC EFFECTS (if applicable)**");
			stringBuilder.AppendLine("- Review 'ACTIVE ECONOMIC EFFECTS'. Too many on target? **CRITICAL:** Avoid unrealistic overlaps.");
			stringBuilder.AppendLine("- Values within range? Reason logical/specific? For target_type=\"kingdom\" or \"clan\": target_id with correct string_id? target_scope appropriate?");
			stringBuilder.AppendLine("- **IMPORTANT:** prosperity_delta_per_day MORE VISIBLE. **FOR VILLAGES:** Only prosperity_delta/prosperity_delta_per_day (Hearth). Do NOT use Food/Security/Loyalty!");
			ModSettings instance = GlobalSettings<ModSettings>.Instance;
			if (instance != null && instance.EnableDiseaseSystem)
			{
				stringBuilder.AppendLine("- **QUARANTINE WORD:** Do NOT use 'quarantine' in description or economic_effects reason for settlements NOT in 'QUARANTINED SETTLEMENTS' list. Only kingdom rulers impose quarantine.");
			}
			stringBuilder.AppendLine();
		}
		ModSettings instance2 = GlobalSettings<ModSettings>.Instance;
		if (instance2 != null && instance2.EnableDiseaseSystem)
		{
			stringBuilder.AppendLine("**STEP 4b: DISEASE SYSTEM (if disease_outbreak)**");
			stringBuilder.AppendLine("- Review 'ACTIVE DISEASES'. Settlement already infected? Spread logical? (proximity, trade routes)");
			stringBuilder.AppendLine("- disease_data: settlement_id exists in world? severity 1-5? spread_rate 0.1-1.0? disease_effects modifiers 0.5-1.0 (1=no change)?");
			stringBuilder.AppendLine("- Consider economic_effects for affected settlement (negative prosperity, security).");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("**STEP 5: EVENT STRUCTURE**");
		stringBuilder.AppendLine("- CAUSE? (from current data) ACTION? (what happened) CONSEQUENCES? (future impact)");
		stringBuilder.AppendLine("- Kingdoms/characters involved? (exact string_ids) player_involved? (only if directly participated)");
		stringBuilder.AppendLine("- Importance? (1-10) spread_speed? (slow/normal/fast) Which NPCs know? (applicable_npcs)");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 6: DESCRIPTION QUALITY**");
		stringBuilder.AppendLine("- Specific/grounded in data? (not generic/cliché) Uses human-readable names? (NOT string_ids) Length? (check limits)");
		stringBuilder.AppendLine("- Avoids duplication? Engaging/interesting? Fits world setting/atmosphere?");
		stringBuilder.AppendLine();
		if (flag)
		{
			stringBuilder.AppendLine("**STEP 7: VERIFY OVERRIDE RULES COMPLIANCE (MANDATORY)**");
			stringBuilder.AppendLine("- Does event violate ANY rule? Comply with restrictions?");
			stringBuilder.AppendLine("- If violated → MUST change event. ABSOLUTE PRIORITY over logic/world state.");
			stringBuilder.AppendLine("- In internal_thoughts: acknowledge violation → explain adjustment → modify event. If impossible → return empty events array.");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("**STEP 8: OUTPUT STRUCTURE**");
		stringBuilder.AppendLine("JSON MUST include:");
		stringBuilder.AppendLine("- `internal_thoughts` (500-2000 characters): PRIVATE reasoning from all steps above" + (flag ? " + rule compliance check" : "") + ".");
		if (flag)
		{
			stringBuilder.AppendLine("  - Example: \"FACT CHECK: Empire vs Vlandia at war, Qalit under siege. REASONING: Planned military event, but Override Rules forbid military. Will create political event instead.\"");
		}
		stringBuilder.AppendLine("- `events` (array): Generated event(s) based on analysis above.");
		if (GlobalSettings<ModSettings>.Instance?.GameMasterDynamicEventsBlgmEnabled == true)
		{
			stringBuilder.AppendLine("- `blgm_plan` (object, REQUIRED): gm_command (starts with gm.), args (string array), intent (query|mutate|probe_help), probe_help_first (bool), story_intent (string). Prefer intent=query and gm.query.*. Same top-level JSON object as internal_thoughts/events.");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**CRITICAL RULES:**");
		stringBuilder.AppendLine("- **MANDATORY:** internal_thoughts starts with 'FACT CHECK:' + facts from CURRENT WORLD DATA");
		stringBuilder.AppendLine("- **FORBIDDEN:** Do NOT hallucinate. Do NOT reference destroyed kingdoms or non-existent characters");
		stringBuilder.AppendLine("- **FORBIDDEN:** Do NOT confuse 'UNDER SIEGE' with 'CAPTURED'");
		stringBuilder.AppendLine("- internal_thoughts = PRIVATE (helps reasoning, players don't see)");
		stringBuilder.AppendLine("- Event = internal thoughts + verified facts. If insufficient data → return empty events array: {\"events\": []}");
		if (flag)
		{
			stringBuilder.AppendLine("- **MANDATORY:** Event MUST comply with Override Rules. If conflict → Rules WIN. Include compliance check in internal_thoughts");
		}
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}

	private string BuildEventGenerationPrompt(string worldData, string existingEvents, string diplomaticStatements, string dialogueData, bool hasDialogues, string selectedEventType = "")
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(GenerateInternalThoughtsSection(hasDialogues, selectedEventType));
		string text = MBTextManager.ActiveTextLanguage ?? "English";
		string text2 = WorldInfoManager.Instance.ReadWorldInfo();
		stringBuilder.AppendLine("# MISSION: Generate Dynamic World Events");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("You are an intelligent world event generator for Mount & Blade II: Bannerlord.");
		stringBuilder.AppendLine("You are operating in the world of " + text2 + ".");
		stringBuilder.AppendLine("Create events that fit the setting and atmosphere of this world.");
		stringBuilder.AppendLine("Language: " + text);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### DATA TYPES IN THIS PROMPT ###");
		stringBuilder.AppendLine("**You will see two types of data below:**");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("1. **CURRENT WORLD DATA** - Technical sections with kingdoms, wars, settlements, statistics");
		stringBuilder.AppendLine("   - Shows ACTUAL CURRENT STATE of the world RIGHT NOW");
		stringBuilder.AppendLine("   - These are FACTS - ground truth of what exists and is happening");
		stringBuilder.AppendLine("   - Example: \"Empire vs Vlandia: AT WAR\" = they ARE at war NOW");
		stringBuilder.AppendLine("   - Example: \"Settlement under siege\" = it IS being sieged NOW");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("2. **EXISTING EVENTS** - Narrative descriptions of past events");
		stringBuilder.AppendLine("   - Shows what HAS BEEN REPORTED (history/past)");
		stringBuilder.AppendLine("   - Use to AVOID DUPLICATION, not as source of current facts");
		stringBuilder.AppendLine("   - Current world data may have CHANGED since these events were created");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**CRITICAL RULE:** When current world data conflicts with existing events, the CURRENT DATA IS CORRECT.");
		stringBuilder.AppendLine("Example: Event says \"peace made\" but current data shows \"AT WAR\" → war is correct (peace failed)");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## CORE RULES:");
		stringBuilder.AppendLine("Aggregate technical data into narrative. Don't copy raw lists. Be specific, avoid clichés, no duplication.");
		stringBuilder.AppendLine($"**TITLE:** 10-50 chars headline (no markdown/ids) | **DESCRIPTION:** {GlobalSettings<ModSettings>.Instance.DynamicEventsMinLength}-{GlobalSettings<ModSettings>.Instance.DynamicEventsMaxLength} chars");
		stringBuilder.AppendLine("'UNDER SIEGE' ≠ captured (need ownership change). Independent clans ≠ kingdoms.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## EVENT STRUCTURE:");
		stringBuilder.AppendLine("MUST include: 1) CAUSE (from data) 2) ACTION (decision taken) 3) CONSEQUENCE (future impact)");
		stringBuilder.AppendLine("Prefer DEVELOPING existing conflicts over new minor incidents. Return [] if insufficient data.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## string_id RULES:");
		stringBuilder.AppendLine("**IN DESCRIPTION TEXT (for players to read):**");
		stringBuilder.AppendLine("- Use human-readable names: \"Northern Empire\", \"Vlandia\", \"Qalit\"");
		stringBuilder.AppendLine("- NEVER use string_id values like \"empire\" or \"town_S1\" in description");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**IN JSON FIELDS (for game code to process):**");
		stringBuilder.AppendLine("- kingdoms_involved: use string_id values only: [\"empire\", \"vlandia\"] or \"all\" (null is FORBIDDEN)");
		stringBuilder.AppendLine("- characters_involved: use string_id values only: [\"lord_1_1\", \"lord_2_1\"]");
		stringBuilder.AppendLine("- settlement references in economic_effects: use string_id only: \"town_B1\"");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**HOW TO EXTRACT string_id:**");
		stringBuilder.AppendLine("- Data format: \"Northern Empire (string_id:empire)\" → Use \"empire\" in JSON");
		stringBuilder.AppendLine("- Data format: \"Qalit (string_id:town_S1)\" → Use \"town_S1\" in JSON");
		stringBuilder.AppendLine("- NEVER include \"string_id:\" prefix in JSON - just the value");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## FIELDS:");
		stringBuilder.AppendLine("kingdoms_involved: string_id [] or \"all\" (null is FORBIDDEN - use \"all\" for global events) | characters_involved: string_id [] (never invent) | player_involved: true only if commands/fights");
		stringBuilder.AppendLine("type: news/political/military/economic/local/rumor | importance: 10=world/7-9=major/4-6=notable/1-3=minor | applicable_npcs: all/lords/faction_leaders/companions/village_notables/merchants");
		stringBuilder.AppendLine("allows_diplomatic_response: true for wars/alliances/peace/scandals/territory, false for local/rumors/nature/trade");
		stringBuilder.AppendLine("If allows_diplomatic_response = true, kingdoms_involved MUST list the relevant kingdoms (cannot be empty).");
		stringBuilder.AppendLine("**CRITICAL:** kingdoms_involved CANNOT be null. Use \"all\" for events affecting all kingdoms, or use array of string_ids for specific kingdoms.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**ECONOMIC EFFECTS:** Check 'ACTIVE ECONOMIC EFFECTS' - avoid conflicts/overlaps. Too many on one target = unrealistic.");
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && instance.EnableDiseaseSystem)
		{
			stringBuilder.AppendLine("**QUARANTINE:** Do NOT use 'quarantine' in description/reason for settlements NOT in 'QUARANTINED SETTLEMENTS'. Only kingdom rulers impose quarantine.");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## OUTPUT FORMAT (STRICT JSON):");
		stringBuilder.AppendLine("```json");
		stringBuilder.AppendLine("{");
		if (GlobalSettings<ModSettings>.Instance.EnableDynamicEventsInternalThoughts)
		{
			stringBuilder.AppendLine("  \"internal_thoughts\": \"Analyze world state, check thresholds, determine the most logical event...\",");
		}
		stringBuilder.AppendLine("  \"events\": [");
		stringBuilder.AppendLine("    {");
		stringBuilder.AppendLine("      \"type\": \"political\", // or \"military\", \"news\", \"social\", \"economic\", etc.");
		stringBuilder.AppendLine("      \"title\": \"Short headline 10-50 chars\",");
		stringBuilder.AppendLine("      \"description\": \"Detailed, specific event description with names and context (do not use string_id here)\",");
		stringBuilder.AppendLine("      \"player_involved\": false,");
		stringBuilder.AppendLine("      \"kingdoms_involved\": [\"empire\", \"vlandia\"],");
		stringBuilder.AppendLine("      \"characters_involved\": [\"exact_string_id_from_data\"],");
		stringBuilder.AppendLine("      \"importance\": 6,");
		stringBuilder.AppendLine("      \"spread_speed\": \"normal\",");
		stringBuilder.AppendLine("      \"allows_diplomatic_response\": true,");
		stringBuilder.AppendLine("      \"applicable_npcs\": [\"all\", \"lords\", \"faction_leaders\", \"companions\", \"village_notables\", \"merchants\"]");
		ModSettings instance2 = GlobalSettings<ModSettings>.Instance;
		stringBuilder.AppendLine("      // OPTIONAL: For economic events, add economic_effects:");
		stringBuilder.AppendLine("      // \"economic_effects\": [{");
		stringBuilder.AppendLine("      //   \"target_type\": \"settlement\",  // or \"kingdom\" or \"clan\"");
		stringBuilder.AppendLine("      //   \"target_id\": \"town_B1\",  // REQUIRED: settlement/kingdom/clan string_id");
		stringBuilder.AppendLine("      //   \"target_ids\": [\"town_B1\", \"town_S1\"],  // Optional: for multiple settlements");
		stringBuilder.AppendLine("      //   \"target_scope\": \"all_settlements\",  // For kingdom/clan: \"all_settlements\", \"towns\", \"castles\", \"villages\"");
		stringBuilder.AppendLine($"      //   \"prosperity_delta\": {instance2.ProsperityDeltaMin},  // IMMEDIATE one-time change (applied once when event is created). Range: {instance2.ProsperityDeltaMin} to {instance2.ProsperityDeltaMax}");
		stringBuilder.AppendLine($"      //   \"prosperity_delta_per_day\": {instance2.ProsperityDeltaPerDayMin},  // DAILY change (applied every day for duration_days). Range: {instance2.ProsperityDeltaPerDayMin} to {instance2.ProsperityDeltaPerDayMax}");
		stringBuilder.AppendLine($"      //   \"food_delta\": {instance2.FoodDeltaMin},  // IMMEDIATE one-time change. Range: {instance2.FoodDeltaMin} to {instance2.FoodDeltaMax}");
		stringBuilder.AppendLine($"      //   \"food_delta_per_day\": {instance2.FoodDeltaPerDayMin},  // DAILY change. Range: {instance2.FoodDeltaPerDayMin} to {instance2.FoodDeltaPerDayMax}");
		stringBuilder.AppendLine($"      //   \"security_delta\": {instance2.SecurityDeltaMin},  // IMMEDIATE one-time change. Range: {instance2.SecurityDeltaMin} to {instance2.SecurityDeltaMax}");
		stringBuilder.AppendLine($"      //   \"security_delta_per_day\": {instance2.SecurityDeltaPerDayMin},  // DAILY change (applied every day for duration_days). Range: {instance2.SecurityDeltaPerDayMin} to {instance2.SecurityDeltaPerDayMax}. IMPORTANT: Security is 0-100, use small values like 0.2 or 0.5");
		stringBuilder.AppendLine($"      //   \"loyalty_delta\": {instance2.LoyaltyDeltaMin},  // IMMEDIATE one-time change. Range: {instance2.LoyaltyDeltaMin} to {instance2.LoyaltyDeltaMax}");
		stringBuilder.AppendLine($"      //   \"loyalty_delta_per_day\": {instance2.LoyaltyDeltaPerDayMin},  // DAILY change (applied every day for duration_days). Range: {instance2.LoyaltyDeltaPerDayMin} to {instance2.LoyaltyDeltaPerDayMax}. IMPORTANT: Loyalty is 0-100, use small values like 0.2 or 0.5");
		stringBuilder.AppendLine($"      //   \"income_multiplier\": {instance2.IncomeMultiplierMin:F2},  // 1.0 = no change, 0.8 = -20%, 1.2 = +20%. Range: {instance2.IncomeMultiplierMin:F2} to {instance2.IncomeMultiplierMax:F2}");
		stringBuilder.AppendLine($"      //   \"duration_days\": {instance2.DurationDaysMin},  // How long the effect lasts (for _per_day effects). Range: {instance2.DurationDaysMin} to {instance2.DurationDaysMax} days");
		stringBuilder.AppendLine("      //   \"reason\": \"Example: Merchants avoid the town after the raid\"");
		stringBuilder.AppendLine("      // }]");
		stringBuilder.AppendLine("      // CRITICAL RULES:");
		stringBuilder.AppendLine("      // - For target_type=\"kingdom\" or \"clan\": target_id is REQUIRED (use kingdom/clan string_id)");
		stringBuilder.AppendLine("      // - target_scope only works when target_id is provided");
		stringBuilder.AppendLine("      // - To affect multiple kingdoms: create MULTIPLE objects in economic_effects array");
		stringBuilder.AppendLine("      // - target_scope values: \"all_settlements\", \"towns\", \"castles\", \"villages\" (NOT \"all\")");
		stringBuilder.AppendLine("      // - IMPORTANT: prosperity_delta_per_day is MORE VISIBLE than prosperity_delta (use _per_day for noticeable effects)");
		stringBuilder.AppendLine("      //   Example: prosperity_delta_per_day: -1 for 21 days = -21 total (more noticeable than prosperity_delta: -15 once)");
		stringBuilder.AppendLine("      // - FOR VILLAGES: Only prosperity_delta and prosperity_delta_per_day are available (applied to Hearth).");
		stringBuilder.AppendLine("      //   Food/Security/Loyalty effects DO NOT EXIST for villages - do NOT use them for village target_id!");
		stringBuilder.AppendLine("    }");
		stringBuilder.AppendLine("  ]");
		stringBuilder.AppendLine("}");
		stringBuilder.AppendLine("```");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("If there is not enough concrete information to create a realistic event without inventing fictional characters, locations, or details, return: {\"events\": []}");
		stringBuilder.AppendLine();
		string value = WorldInfoManager.Instance.ReadEventsGeneratorRules();
		if (!string.IsNullOrEmpty(value))
		{
			stringBuilder.AppendLine("### OVERRIDE RULES ###");
			stringBuilder.AppendLine("**IMPORTANT: The information below overrides any rules stated above. These rules take priority.**");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(value);
			stringBuilder.AppendLine();
		}
		if (hasDialogues)
		{
			stringBuilder.AppendLine("## MODE: DIALOGUE ANALYSIS");
			stringBuilder.AppendLine("Analyze the player dialogues and create events ONLY based on what was discussed in those dialogues.");
			stringBuilder.AppendLine("Create 1-3 events that directly relate to the dialogue content, but avoid personal matters or secret/confidential information that should remain private even if it relates to global affairs.");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("### CRITICAL: DIALOGUE EVENT FILTERING");
			stringBuilder.AppendLine("Only create events from dialogues that represent SIGNIFICANT WORLD EVENTS, but are NOT secret/confidential:");
			stringBuilder.AppendLine("- Major political events (wars, alliances, betrayals, succession)");
			stringBuilder.AppendLine("- Important military information (large battles, sieges, army movements)");
			stringBuilder.AppendLine("- Significant diplomatic events (peace negotiations, trade agreements)");
			stringBuilder.AppendLine("- Major economic events (trade disruptions, resource shortages)");
			stringBuilder.AppendLine("- Important social events (marriages, deaths, scandals involving rulers)");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("DO NOT create events IF:");
			stringBuilder.AppendLine("- Casual mentions of locations, people, or clans without significant context, or if the discussion was secret and could not be passed to third parties");
			stringBuilder.AppendLine("- It is a personal conversation about daily life or minor matters");
			stringBuilder.AppendLine("- It is a simple discussion of observations about weather, food, or travel");
			stringBuilder.AppendLine("- It is a discussion of minor local incidents or gossip");
			stringBuilder.AppendLine("- Routine military patrols or small skirmishes (e.g., bandit/deserter skirmishes)");
			stringBuilder.AppendLine("- Individual character's personal problems");
			stringBuilder.AppendLine("- **SECRET/PRIVATE conversations that should remain confidential**");
			stringBuilder.AppendLine("- **HIDDEN information that NPCs would not share publicly**");
			stringBuilder.AppendLine("- **CONFIDENTIAL discussions that would not become public knowledge**");
			stringBuilder.AppendLine("If dialogues are only personal/secret or lack public world-impact, return {\"events\": []} (no events).");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("### SECRECY RULE:");
			stringBuilder.AppendLine("If the dialogue contains SECRET, PRIVATE, or CONFIDENTIAL information that NPCs would not share publicly, DO NOT create an event from it.");
			stringBuilder.AppendLine("Only create events from information that would realistically become public knowledge or be discussed openly.");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("### DIPLOMATIC RESPONSE RULE:");
			stringBuilder.AppendLine("CRITICAL: If you create multiple events from the same dialogue, ONLY ONE event should have 'allows_diplomatic_response': true.");
			stringBuilder.AppendLine("The other events should have 'allows_diplomatic_response': false.");
			stringBuilder.AppendLine("This prevents multiple diplomatic responses to the same information.");
			stringBuilder.AppendLine("Choose the most important/significant event for diplomatic response.");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("### SPECIAL RULE FOR DIALOGUE-BASED EVENTS:");
			stringBuilder.AppendLine("If the event is created from a dialogue with a specific NPC, ALWAYS include that NPC's string_id in characters_involved.");
			stringBuilder.AppendLine("The string_id is provided in the dialogue header: \"New dialogue with [Name] (string_id: \"[string_id]\")\"");
			stringBuilder.AppendLine("This ensures the NPC will know the event involves them personally.");
			stringBuilder.AppendLine();
		}
		else
		{
			stringBuilder.AppendLine("## MODE: WORLD STATE ANALYSIS");
			stringBuilder.AppendLine("Analyze the current world state and create EXACTLY 1 event based on kingdom dynamics, wars, or political situation.");
			stringBuilder.AppendLine("- Produce exactly 1 event tied to world dynamics.");
			stringBuilder.AppendLine("- player_involved: false");
			stringBuilder.AppendLine();
			Dictionary<string, EventTypeConfig> dictionary = new Dictionary<string, EventTypeConfig>();
			dictionary["military"] = new EventTypeConfig
			{
				Focuses = new string[1] { "Focus on creating an event that relates to or references military matters. This can be anything that may affect the game world, kingdoms, peace between kingdoms, or war between them." },
				Tones = new string[4] { "Write in a neutral, journalistic tone as if reporting military facts.", "Write in a dramatic, storytelling style.", "Write in a concise, matter-of-fact style.", "Write in a serious, authoritative tone befitting military matters." },
				CreativityHints = new string[4] { "Consider the strategic implications of current military movements.", "Think about how small skirmishes can escalate into major conflicts.", "Imagine the human cost and suffering behind military statistics.", "Consider both immediate tactical and long-term strategic consequences." }
			};
			dictionary["political"] = new EventTypeConfig
			{
				Focuses = new string[1] { "Focus on creating an event that relates to politics (external or internal) of any kingdoms." },
				Tones = new string[4] { "Write in a formal, diplomatic tone appropriate for political matters.", "Write in an intriguing style.", "Write in a serious, authoritative tone befitting political authority.", "Write in a mysterious tone." },
				CreativityHints = new string[4] { "Consider the hidden motivations behind political actions.", "Think about how personal ambitions drive political decisions.", "Imagine the ripple effects of political changes across kingdoms.", "Consider both immediate political consequences and long-term stability." }
			};
			dictionary["economic"] = new EventTypeConfig
			{
				Focuses = new string[1] { "Focus on creating an event that relates to the economy of kingdoms or a kingdom." },
				Tones = new string[4] { "Write in a practical, business-like tone focusing on economic realities.", "Write in a concerned tone that highlights economic impacts on common people.", "Write in a analytical style that explains economic cause and effect.", "Write in a matter-of-fact tone appropriate for financial matters." },
				CreativityHints = new string[4] { "Consider how economic changes affect different social classes.", "Think about the interconnected nature of trade and commerce.", "Imagine the human stories behind economic statistics.", "Consider both immediate economic impacts and long-term prosperity." }
			};
			dictionary["social"] = new EventTypeConfig
			{
				Focuses = new string[1] { "Focus on creating an event that relates to social matters, cultures, personal stories, or global changes in the world." },
				Tones = new string[4] { "Write in a warm, human tone.", "Write in a dramatic style that emphasizes emotional impact.", "Write in a respectful tone appropriate for cultural matters.", "Write in a storytelling style that brings characters to life." },
				CreativityHints = new string[4] { "Consider the personal stories behind public events.", "Think about how individual actions reflect broader social trends.", "Imagine the emotional impact of social events on communities.", "Consider both immediate social effects and cultural significance." }
			};
			dictionary["mysterious"] = new EventTypeConfig
			{
				Focuses = new string[1] { "Focus on creating mysterious/mystical events that could occur in the world, but pay attention to world information about whether mysticism/magic exists in this world." },
				Tones = new string[4] { "Write in a mysterious, intriguing tone that leaves room for speculation.", "Write in a ominous style that suggests hidden dangers or secrets.", "Write in a wondrous tone that captures the sense of discovery.", "Write in a cryptic style that hints at deeper meanings." },
				CreativityHints = new string[4] { "Consider the unexplained and mysterious aspects of the world.", "Think about how mysterious events affect people's beliefs and fears.", "Imagine the possibilities behind unexplained phenomena.", "Consider both immediate mystery and potential long-term implications." }
			};
			dictionary["disease_outbreak"] = new EventTypeConfig
			{
				Focuses = new string[3] { "Focus on creating a disease outbreak event affecting a settlement. The disease should spread from a specific location and affect the population.", "Create a plague or epidemic that threatens a town or city. Consider the social and economic impacts of the disease.", "Generate an event about a mysterious illness affecting a settlement. Think about how people react to disease and what measures they take." },
				Tones = new string[4] { "Write in a concerned, urgent tone that conveys the seriousness of the outbreak.", "Write in a dramatic style that emphasizes the human suffering caused by disease.", "Write in a matter-of-fact medical tone appropriate for describing symptoms and spread.", "Write in a somber tone that reflects the fear and uncertainty of an epidemic." },
				CreativityHints = new string[4] { "Consider how disease affects different social classes and professions.", "Think about the economic disruption caused by quarantines and sick workers.", "Imagine the fear and superstition that arise during epidemics.", "Consider both the immediate health crisis and long-term demographic impacts." }
			};
			Dictionary<string, EventTypeConfig> dictionary2 = dictionary;
			if (!string.IsNullOrEmpty(selectedEventType) && dictionary2.ContainsKey(selectedEventType))
			{
				EventTypeConfig eventTypeConfig = dictionary2[selectedEventType];
				string text3 = eventTypeConfig.Focuses[_random.Next(eventTypeConfig.Focuses.Length)];
				string text4 = eventTypeConfig.Tones[_random.Next(eventTypeConfig.Tones.Length)];
				string text5 = eventTypeConfig.CreativityHints[_random.Next(eventTypeConfig.CreativityHints.Length)];
				stringBuilder.AppendLine("### CREATIVE DIRECTION (" + selectedEventType + " event):");
				stringBuilder.AppendLine("- " + text3);
				stringBuilder.AppendLine("- " + text4);
				stringBuilder.AppendLine("- " + text5);
				stringBuilder.AppendLine();
			}
			if (string.Equals(selectedEventType, "economic", StringComparison.OrdinalIgnoreCase))
			{
				stringBuilder.AppendLine("### ECONOMIC EVENT SPECIFICS:");
				stringBuilder.AppendLine("- Use \"type\": \"economic\" and include non-empty economic_effects array");
				stringBuilder.AppendLine("- CRITICAL: For target_type=\"kingdom\" or \"clan\", target_id is REQUIRED (use exact string_id: \"empire\", \"vlandia\", \"aserai\", etc.)");
				stringBuilder.AppendLine("- Multiple kingdoms: create MULTIPLE objects in economic_effects array (one per kingdom with its string_id)");
				stringBuilder.AppendLine("- target_scope: \"all_settlements\", \"towns\", \"castles\", \"villages\" (works only with target_id)");
				stringBuilder.AppendLine("- prosperity_delta_per_day is MORE VISIBLE than prosperity_delta (use _per_day for noticeable effects: -1/day for 21 days = -21 total)");
				stringBuilder.AppendLine();
			}
			if (string.Equals(selectedEventType, "disease_outbreak", StringComparison.OrdinalIgnoreCase))
			{
				ModSettings instance3 = GlobalSettings<ModSettings>.Instance;
				int num = instance3?.DiseaseMaxSeverity ?? 5;
				float num2 = instance3?.DiseaseMaxSpreadRate ?? 1f;
				float num3 = instance3?.DiseaseMinCombatModifier ?? 0.5f;
				float num4 = instance3?.DiseaseMinMapSpeedModifier ?? 0.5f;
				float num5 = instance3?.DiseaseMaxMoralePenalty ?? (-30f);
				float num6 = instance3?.DiseaseMaxPhysicalSkillPenalty ?? (-30f);
				float num7 = instance3?.DiseaseMaxDeathChance ?? 0.3f;
				stringBuilder.AppendLine("### DISEASE OUTBREAK — YOU (AI) MUST SET disease_data:");
				stringBuilder.AppendLine("YOU must generate: disease_name, disease_description, severity, settlement_id (use real settlement from world data), spread_rate, disease_effects.");
				stringBuilder.AppendLine("Do NOT copy placeholders; choose values from context (settlement, narrative, existing diseases).");
				stringBuilder.AppendLine("Format:");
				stringBuilder.AppendLine("```json");
				stringBuilder.AppendLine("{\"type\": \"disease_outbreak\", \"disease_data\": {");
				stringBuilder.AppendLine($"  \"disease_name\": \"<your generated name>\", \"disease_description\": \"<your description>\", \"severity\": <1-{num}>, \"settlement_id\": \"<valid settlement string_id from world>\", \"spread_rate\": <0.1-{num2:F1}>,");
				stringBuilder.AppendLine("  \"duration_days\": <7-120>,  // OPTIONAL: how many days the disease stays active. If omitted, auto-calculated from severity (sev1=30d, sev2=45d, sev3=60d, sev4=75d, sev5=90d)");
				stringBuilder.AppendLine($"  \"disease_effects\": {{\"physical_skill_penalty\": <{num6:F0} to 0>, \"combat_damage_modifier\": <{num3:F1}-1.0>, \"combat_defense_modifier\": <{num3:F1}-1.0>, \"combat_speed_modifier\": <{num3:F1}-1.0>, \"map_speed_modifier\": <{num4:F1}-1.0>, \"morale_modifier\": <{num5:F0} to 0>, \"death_chance\": <0-{num7:F1}>}}");
				stringBuilder.AppendLine("}}");
				stringBuilder.AppendLine("```");
				stringBuilder.AppendLine($"severity 1-{num}; spread_rate 0.1-{num2:F1} (how fast disease spreads); duration_days 7-120 (optional, auto-calculated from severity if omitted); disease_effects: modifiers {num3:F1}-1.0 (1=no change); economic_effects recommended.");
				stringBuilder.AppendLine();
			}
		}
		stringBuilder.AppendLine("## === CURRENT WORLD DATA (GROUND TRUTH) ===");
		stringBuilder.AppendLine("The following data shows the ACTUAL CURRENT STATE of the game world RIGHT NOW.");
		stringBuilder.AppendLine("Use this as FACTUAL BASIS for creating events.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(worldData);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## === EXISTING EVENTS (HISTORICAL NARRATIVE) ===");
		stringBuilder.AppendLine("These are events that have ALREADY BEEN CREATED AND REPORTED.");
		stringBuilder.AppendLine("**Purpose: To AVOID DUPLICATION - do not create similar events**");
		stringBuilder.AppendLine("**Note: World state may have CHANGED since these were created - use current data above as truth**");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(existingEvents);
		stringBuilder.AppendLine();
		string activeEconomicEffectsData = GetActiveEconomicEffectsData();
		stringBuilder.AppendLine(activeEconomicEffectsData);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(diplomaticStatements);
		stringBuilder.AppendLine();
		if (hasDialogues && !string.IsNullOrEmpty(dialogueData))
		{
			stringBuilder.AppendLine(dialogueData);
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("TASK: Create events ONLY from dialogue content above!");
			stringBuilder.AppendLine("Analyze what was discussed and extract 1-3 events that NPCs would talk about.");
			stringBuilder.AppendLine("IMPORTANT: Create only significant and world-class events. IGNORE PLAYERS' PERSONAL LIVES unless they are directly related to the events. If a conversation was confidential or secretive, DO NOT create an event based on it.");
		}
		else
		{
			stringBuilder.AppendLine("=== NO NEW DIALOGUES ===");
			stringBuilder.AppendLine("TASK: Create EXACTLY 1 event based on current kingdom relations, wars, or political tensions.");
			stringBuilder.AppendLine("Choose the most interesting aspect of the current world state.");
		}
		stringBuilder.AppendLine();
		if (hasDialogues)
		{
			stringBuilder.AppendLine("Generate 1-3 events based on dialogues NOW (JSON only):");
		}
		else
		{
			stringBuilder.AppendLine("Generate EXACTLY 1 event based on world state NOW (JSON only):");
		}
		return stringBuilder.ToString();
	}

	private DynamicEventsResponse ParseAIResponse(string aiResponse)
	{
		try
		{
			string text = aiResponse.Trim();
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
			DynamicEventsResponse dynamicEventsResponse = JsonConvert.DeserializeObject<DynamicEventsResponse>(text);
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_GEN] Successfully parsed {(dynamicEventsResponse?.Events?.Count).GetValueOrDefault()} events from AI response");
			if (dynamicEventsResponse?.BlgmPlan != null)
			{
				string dynBackend = GlobalSettings<ModSettings>.Instance?.DynamicEventsAIBackend?.SelectedValue ?? "";
				GameMasterPlanExecutor.TryEnqueueFromDynamicEvents(dynamicEventsResponse.BlgmPlan, "dyn_" + DateTime.UtcNow.Ticks, dynBackend);
			}
			return dynamicEventsResponse;
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Failed to parse AI response: " + ex.Message);
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] Raw response: " + aiResponse);
			return null;
		}
	}

	private void ProcessGeneratedEvent(DynamicEvent dynamicEvent)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (dynamicEvent == null)
		{
			return;
		}
		dynamicEvent.CreationTime = DateTime.Now;
		CampaignTime now = CampaignTime.Now;
		dynamicEvent.CreationCampaignDays = (float)(now).ToDays;
		dynamicEvent.ExpirationCampaignDays = dynamicEvent.CreationCampaignDays + (float)GlobalSettings<ModSettings>.Instance.DynamicEventsLifespan;
		dynamicEvent.ExpirationTime = DateTime.Now.AddDays(GlobalSettings<ModSettings>.Instance.DynamicEventsLifespan);
		dynamicEvent.Title = GetEventTitleOrFallback(dynamicEvent);
		if (dynamicEvent.EventHistory == null)
		{
			dynamicEvent.EventHistory = new List<EventUpdate>();
		}
		List<EconomicEffect> economicEffects = null;
		try
		{
			if (dynamicEvent.EconomicEffects != null && dynamicEvent.EconomicEffects.Any())
			{
				EconomicEffectsManager.Instance?.AddEconomicEffects(dynamicEvent.EconomicEffects);
				economicEffects = dynamicEvent.EconomicEffects;
			}
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS_GEN] ERROR applying economic effects for event " + dynamicEvent.Id + ": " + ex.Message);
		}
		if (!dynamicEvent.EventHistory.Any())
		{
			DiseaseEventData diseaseData = (dynamicEvent.IsDiseaseEvent ? dynamicEvent.DiseaseData : null);
			dynamicEvent.AddEventUpdate(dynamicEvent.Description, "Initial Event", economicEffects, diseaseData);
		}
		if (dynamicEvent.IsDiseaseEvent && dynamicEvent.DiseaseData != null)
		{
			ProcessDiseaseOutbreakEvent(dynamicEvent);
		}
		DynamicEventsManager.Instance.AddEvent(dynamicEvent);
		DiplomacyLogger.Instance?.Log("Checking diplomatic response for event " + dynamicEvent.Id);
		DiplomacyLogger.Instance?.Log($"AllowsDiplomaticResponse = {dynamicEvent.AllowsDiplomaticResponse}");
		DiplomacyLogger.Instance?.Log($"EnableDiplomacy = {GlobalSettings<ModSettings>.Instance.EnableDiplomacy}");
		if (!dynamicEvent.AllowsDiplomaticResponse || !GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
		{
			return;
		}
		List<string> kingdomStringIds = dynamicEvent.GetKingdomStringIds();
		if (kingdomStringIds.Any() && kingdomStringIds[0] != "all")
		{
			List<string> list = kingdomStringIds.Where((string k) => k != "all").ToList();
			if (list.Count >= 1)
			{
				dynamicEvent.ParticipatingKingdoms = list;
				dynamicEvent.RequiresDiplomaticAnalysis = true;
				DiplomacyLogger.Instance?.Log("Event " + dynamicEvent.Id + " created diplomatic situation involving " + string.Join(", ", list));
				ProcessDiplomaticEventAsync(dynamicEvent);
			}
		}
	}

	private void ProcessDiseaseOutbreakEvent(DynamicEvent dynamicEvent)
	{
		if (dynamicEvent?.DiseaseData == null)
		{
			return;
		}
		try
		{
			DiseaseEventData diseaseData = dynamicEvent.DiseaseData;
			string text = ExtractSettlementIdForDisease(dynamicEvent);
			if (string.IsNullOrEmpty(text))
			{
				DynamicEventsLogger.Instance.Log("[DISEASE] Could not determine settlement for disease event");
				return;
			}
			DiseaseEffects effects = ConvertDiseaseEffectsData(diseaseData.DiseaseEffects);
			int val = GlobalSettings<ModSettings>.Instance?.DiseaseMaxSeverity ?? 5;
			Disease disease = DiseaseManager.Instance?.CreateDiseaseFromEvent(dynamicEvent, diseaseData.DiseaseName ?? "Неизвестная болезнь", diseaseData.DiseaseDescription ?? "Странная болезнь неизвестного происхождения.", Math.Max(1, Math.Min(val, diseaseData.Severity)), effects, text);
			if (disease != null)
			{
				diseaseData.DiseaseId = disease.Id;
				DynamicEventsLogger.Instance.Log($"[DISEASE] Created disease '{disease.Name}' (severity {disease.Severity}) in settlement {text}");
			}
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[DISEASE] Error processing disease outbreak event: " + ex.Message);
		}
	}

	private string ExtractSettlementIdForDisease(DynamicEvent dynamicEvent)
	{
		if (!string.IsNullOrEmpty(dynamicEvent.DiseaseData?.SettlementId))
		{
			return dynamicEvent.DiseaseData.SettlementId;
		}
		List<EconomicEffect> economicEffects = dynamicEvent.EconomicEffects;
		if (economicEffects != null && economicEffects.Count > 0)
		{
			EconomicEffect economicEffect = dynamicEvent.EconomicEffects.FirstOrDefault((EconomicEffect e) => e.TargetType == "settlement");
			if (economicEffect != null && !string.IsNullOrEmpty(economicEffect.TargetId))
			{
				return economicEffect.TargetId;
			}
		}
		if (!string.IsNullOrEmpty(dynamicEvent.Description))
		{
			foreach (Settlement item in ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsTown || s.IsCastle))
			{
				if (dynamicEvent.Description.Contains(((object)item.Name).ToString()))
				{
					return ((MBObjectBase)item).StringId;
				}
			}
		}
		if (!string.IsNullOrEmpty(dynamicEvent.Title))
		{
			foreach (Settlement item2 in ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsTown || s.IsCastle))
			{
				if (dynamicEvent.Title.Contains(((object)item2.Name).ToString()))
				{
					return ((MBObjectBase)item2).StringId;
				}
			}
		}
		Settlement val = (from _ in (IEnumerable<Settlement>)Settlement.All
			where _.IsTown && IsDiseaseVulnerable(_)
			orderby _random.Next()
			select _).FirstOrDefault();
		return (val != null) ? ((MBObjectBase)val).StringId : null;
	}

	private DiseaseEffects ConvertDiseaseEffectsData(DiseaseEffectsData data)
	{
		DiseaseEffects diseaseEffects = new DiseaseEffects();
		if (data == null)
		{
			return diseaseEffects;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		float val = instance?.DiseaseMinCombatModifier ?? 0.5f;
		float val2 = instance?.DiseaseMinMapSpeedModifier ?? 0.5f;
		float val3 = instance?.DiseaseMaxMoralePenalty ?? (-30f);
		float val4 = instance?.DiseaseMaxPhysicalSkillPenalty ?? (-30f);
		float val5 = instance?.DiseaseMaxDeathChance ?? 0.3f;
		if (data.PhysicalSkillPenalty != 0f)
		{
			float val6 = 0f - Math.Abs(data.PhysicalSkillPenalty);
			float value = Math.Max(val4, Math.Min(0f, val6));
			string[] physicalSkills = DiseaseEffects.PhysicalSkills;
			foreach (string key in physicalSkills)
			{
				diseaseEffects.SkillModifiers[key] = value;
			}
		}
		diseaseEffects.CombatModifiers.DamageMultiplier = Math.Max(val, Math.Min(1f, Math.Abs(data.CombatDamageModifier)));
		diseaseEffects.CombatModifiers.DefenseMultiplier = Math.Max(val, Math.Min(1f, Math.Abs(data.CombatDefenseModifier)));
		diseaseEffects.CombatModifiers.SpeedMultiplier = Math.Max(val, Math.Min(1f, Math.Abs(data.CombatSpeedModifier)));
		diseaseEffects.MapModifiers.MovementSpeedMultiplier = Math.Max(val2, Math.Min(1f, Math.Abs(data.MapSpeedModifier)));
		float val7 = 0f - Math.Abs(data.MoraleModifier);
		diseaseEffects.MapModifiers.MoraleModifier = Math.Max(val3, Math.Min(0f, val7));
		diseaseEffects.DeathChance = Math.Max(0f, Math.Min(val5, Math.Abs(data.DeathChance)));
		return diseaseEffects;
	}

	private string GetEventTitleOrFallback(DynamicEvent dynamicEvent)
	{
		if (!string.IsNullOrWhiteSpace(dynamicEvent?.Title))
		{
			return dynamicEvent.Title.Trim();
		}
		if (!string.IsNullOrWhiteSpace(dynamicEvent?.Description))
		{
			string text = dynamicEvent.Description.Trim();
			return (text.Length > 80) ? (text.Substring(0, 80) + "...") : text;
		}
		return string.IsNullOrWhiteSpace(dynamicEvent?.Type) ? "World Event" : dynamicEvent.Type;
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

	private string GetStrategicLocationInfo(Settlement settlement, Kingdom kingdom)
	{
		List<string> list = new List<string>();
		if (settlement.IsCastle)
		{
			list.Add("(military stronghold)");
		}
		else if (settlement.IsTown)
		{
			Town town = settlement.Town;
			if (((town != null) ? new float?(town.Prosperity) : ((float?)null)) > (float)PROSPERITY_HIGH_THRESHOLD)
			{
				list.Add("(prosperous trade center)");
			}
		}
		if (SettlementCaptureManager.Instance.IsRecentlyCaptured(((MBObjectBase)settlement).StringId))
		{
			int daysSinceCapture = SettlementCaptureManager.Instance.GetDaysSinceCapture(((MBObjectBase)settlement).StringId);
			list.Add($"(captured {daysSinceCapture} days ago)");
		}
		IEnumerable<Kingdom> enemyKingdoms = GameVersionCompatibility.GetEnemyKingdoms(kingdom);
		List<Settlement> source = ((IEnumerable<Settlement>)Settlement.All).Where(delegate(Settlement s)
		{
			IEnumerable<Kingdom> source2 = enemyKingdoms;
			IFaction mapFaction = s.MapFaction;
			return source2.Contains((Kingdom)(object)((mapFaction is Kingdom) ? mapFaction : null));
		}).Where(delegate(Settlement s)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			Vec2 position2D = settlement.GetPosition2D();
			return (position2D).Distance(s.GetPosition2D()) <= SETTLEMENT_DISTANCE_NEAR_THRESHOLD;
		}).ToList();
		if (source.Any())
		{
			list.Add("(border location with enemy territories nearby)");
		}
		return list.Any() ? string.Join(", ", list) : "";
	}

	private List<string> GetNearbySettlementsInfo(Settlement settlement, Kingdom kingdom)
	{
		List<string> list = new List<string>();
		List<Settlement> list2 = ((IEnumerable<Settlement>)Settlement.All).Where(delegate(Settlement s)
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (s != settlement)
			{
				Vec2 position2D = settlement.GetPosition2D();
				result = (((position2D).Distance(s.GetPosition2D()) <= SETTLEMENT_DISTANCE_MEDIUM_THRESHOLD) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).OrderBy(delegate(Settlement s)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			Vec2 position2D = settlement.GetPosition2D();
			return (position2D).Distance(s.GetPosition2D());
		}).Take(5)
			.ToList();
		foreach (Settlement item in list2)
		{
			string text = (item.IsTown ? "Town" : (item.IsCastle ? "Castle" : "Village")) + (item.HasPort ? " (port)" : "");
			IFaction mapFaction = item.MapFaction;
			string text2 = ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString()) ?? "Neutral";
			CultureObject culture = item.Culture;
			string text3 = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown";
			IFaction mapFaction2 = item.MapFaction;
			Kingdom val = (Kingdom)(object)((mapFaction2 is Kingdom) ? mapFaction2 : null);
			string text4 = ((val != null) ? ((object)val.Name)?.ToString() : "Independent");
			string text5 = ((MBObjectBase)item).StringId ?? "unknown";
			list.Add($"{item.Name} ({text}, {text3}, {text4}, string_id: \"{text5}\")");
		}
		return list;
	}

	private List<BattleInfo> GetRecentLargeBattles()
	{
		return BattleHistoryManager.Instance.GetRecentLargeBattles();
	}

	private List<ArmyInfo> GetLargeArmies()
	{
		List<ArmyInfo> list = new List<ArmyInfo>();
		List<MobileParty> list2 = ((IEnumerable<MobileParty>)MobileParty.All).Where((MobileParty p) => p.Army != null && p.Army.LeaderParty == p && p.MapFaction is Kingdom).ToList();
		foreach (MobileParty item2 in list2)
		{
			Army army = item2.Army;
			int num = 0;
			int num2 = 0;
			foreach (MobileParty item3 in (List<MobileParty>)(object)army.Parties)
			{
				num += item3.MemberRoster.TotalManCount;
				num2++;
			}
			if (num > LARGE_ARMY_TROOPS_THRESHOLD)
			{
				ArmyInfo obj = new ArmyInfo
				{
					ArmyName = (((object)army.Name)?.ToString() ?? ((object)item2.Name)?.ToString() ?? "Unknown Army"),
					TotalTroops = num
				};
				Hero leaderHero = item2.LeaderHero;
				obj.LeaderName = ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString()) ?? "Unknown";
				Hero leaderHero2 = item2.LeaderHero;
				obj.LeaderStringId = ((leaderHero2 != null) ? ((MBObjectBase)leaderHero2).StringId : null) ?? "unknown";
				IFaction mapFaction = item2.MapFaction;
				obj.KingdomName = ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString()) ?? "Unknown";
				IFaction mapFaction2 = item2.MapFaction;
				obj.KingdomStringId = ((mapFaction2 != null) ? mapFaction2.StringId : null) ?? "unknown";
				Settlement nearestSettlement = GetNearestSettlement(item2);
				obj.Location = ((nearestSettlement == null) ? null : ((object)nearestSettlement.Name)?.ToString()) ?? "Unknown location";
				obj.Target = GetArmyTarget(item2);
				obj.PartyCount = num2;
				obj.IsDisorganized = item2.IsDisorganized;
				obj.Morale = item2.Morale;
				obj.Objective = GetArmyObjective(item2);
				ArmyInfo item = obj;
				list.Add(item);
			}
		}
		return list.OrderByDescending((ArmyInfo a) => a.TotalTroops).Take(10).ToList();
	}

	private string GetArmyObjective(MobileParty armyLeader)
	{
		if (armyLeader.SiegeEvent != null)
		{
			Settlement besiegedSettlement = armyLeader.SiegeEvent.BesiegedSettlement;
			object obj;
			if (besiegedSettlement == null)
			{
				obj = null;
			}
			else
			{
				IFaction mapFaction = besiegedSettlement.MapFaction;
				obj = ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString());
			}
			if (obj == null)
			{
				obj = "Unknown";
			}
			string text = (string)obj;
			return "Besieging " + (((besiegedSettlement == null) ? null : ((object)besiegedSettlement.Name)?.ToString()) ?? "Unknown settlement") + " (" + text + ")";
		}
		if (armyLeader.TargetSettlement != null)
		{
			IFaction mapFaction2 = armyLeader.TargetSettlement.MapFaction;
			string arg = ((mapFaction2 == null) ? null : ((object)mapFaction2.Name)?.ToString()) ?? "Unknown";
			return $"Moving to {armyLeader.TargetSettlement.Name} ({arg})";
		}
		if (armyLeader.TargetParty != null)
		{
			IFaction mapFaction3 = armyLeader.TargetParty.MapFaction;
			string arg2 = ((mapFaction3 == null) ? null : ((object)mapFaction3.Name)?.ToString()) ?? "Unknown";
			return $"Engaging {armyLeader.TargetParty.Name} ({arg2})";
		}
		if (armyLeader.IsDisorganized)
		{
			return "Disorganized and regrouping";
		}
		return "Patrolling";
	}

	private string GetMilitaryIntelligence()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("IMPORTANT: Army status is CURRENT state, NOT a result of battle:");
		stringBuilder.AppendLine("- DISORGANIZED = army is temporarily regrouping/patrolling (NOT defeated in battle)");
		stringBuilder.AppendLine("- LOW MORALE = army morale is low (NOT necessarily from a recent battle)");
		stringBuilder.AppendLine("- Do NOT assume these armies were defeated unless you see actual battle data above");
		stringBuilder.AppendLine();
		List<MobileParty> source = ((IEnumerable<MobileParty>)MobileParty.All).Where((MobileParty p) => p.Army != null && p.Army.LeaderParty == p && p.IsDisorganized && p.MapFaction is Kingdom).ToList();
		if (source.Any())
		{
			stringBuilder.AppendLine("DISORGANIZED ARMIES (temporarily regrouping):");
			foreach (MobileParty item in source.Take(3))
			{
				Hero leaderHero = item.LeaderHero;
				string text = ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString()) ?? "Unknown";
				Hero leaderHero2 = item.LeaderHero;
				string text2 = ((leaderHero2 != null) ? ((MBObjectBase)leaderHero2).StringId : null) ?? "unknown";
				IFaction mapFaction = item.MapFaction;
				string text3 = ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString()) ?? "Unknown";
				IFaction mapFaction2 = item.MapFaction;
				string text4 = ((mapFaction2 != null) ? mapFaction2.StringId : null) ?? "unknown";
				stringBuilder.AppendLine($"- {item.Army.Name} ({text3}, string_id: \"{text4}\") - Leader: {text} (string_id: \"{text2}\")");
			}
			stringBuilder.AppendLine();
		}
		List<MobileParty> source2 = ((IEnumerable<MobileParty>)MobileParty.All).Where((MobileParty p) => p.Army != null && p.Army.LeaderParty == p && p.Morale < (float)PARTY_MORALE_LOW_THRESHOLD && p.MapFaction is Kingdom).ToList();
		if (source2.Any())
		{
			stringBuilder.AppendLine("LOW MORALE ARMIES (demoralized):");
			foreach (MobileParty item2 in source2.Take(3))
			{
				Hero leaderHero3 = item2.LeaderHero;
				string text5 = ((leaderHero3 == null) ? null : ((object)leaderHero3.Name)?.ToString()) ?? "Unknown";
				Hero leaderHero4 = item2.LeaderHero;
				string text6 = ((leaderHero4 != null) ? ((MBObjectBase)leaderHero4).StringId : null) ?? "unknown";
				IFaction mapFaction3 = item2.MapFaction;
				string text7 = ((mapFaction3 == null) ? null : ((object)mapFaction3.Name)?.ToString()) ?? "Unknown";
				IFaction mapFaction4 = item2.MapFaction;
				string text8 = ((mapFaction4 != null) ? mapFaction4.StringId : null) ?? "unknown";
				stringBuilder.AppendLine($"- {item2.Army.Name} ({text7}, string_id: \"{text8}\") - Leader: {text5} (string_id: \"{text6}\"), Morale: {item2.Morale:F0}%");
			}
			stringBuilder.AppendLine();
		}
		List<MobileParty> source3 = ((IEnumerable<MobileParty>)MobileParty.All).Where((MobileParty p) => p.Army != null && p.Army.LeaderParty == p && p.HasUnpaidWages > 0f && p.MapFaction is Kingdom).ToList();
		if (source3.Any())
		{
			stringBuilder.AppendLine("ARMIES WITH UNPAID WAGES (potential mutiny):");
			foreach (MobileParty item3 in source3.Take(3))
			{
				Hero leaderHero5 = item3.LeaderHero;
				string text9 = ((leaderHero5 == null) ? null : ((object)leaderHero5.Name)?.ToString()) ?? "Unknown";
				Hero leaderHero6 = item3.LeaderHero;
				string text10 = ((leaderHero6 != null) ? ((MBObjectBase)leaderHero6).StringId : null) ?? "unknown";
				IFaction mapFaction5 = item3.MapFaction;
				string text11 = ((mapFaction5 == null) ? null : ((object)mapFaction5.Name)?.ToString()) ?? "Unknown";
				IFaction mapFaction6 = item3.MapFaction;
				string text12 = ((mapFaction6 != null) ? mapFaction6.StringId : null) ?? "unknown";
				stringBuilder.AppendLine($"- {item3.Army.Name} ({text11}, string_id: \"{text12}\") - Leader: {text9} (string_id: \"{text10}\"), Unpaid wages: {item3.HasUnpaidWages:F0}");
			}
			stringBuilder.AppendLine();
		}
		List<MobileParty> source4 = ((IEnumerable<MobileParty>)MobileParty.All).Where((MobileParty p) => p.Army != null && p.Army.LeaderParty == p && p.IsEngaging && p.MapFaction is Kingdom).ToList();
		if (source4.Any())
		{
			stringBuilder.AppendLine("ARMIES CURRENTLY ENGAGING ENEMIES:");
			foreach (MobileParty item4 in source4.Take(3))
			{
				string engagingEnemyInfo = GetEngagingEnemyInfo(item4);
				Hero leaderHero7 = item4.LeaderHero;
				string text13 = ((leaderHero7 == null) ? null : ((object)leaderHero7.Name)?.ToString()) ?? "Unknown";
				Hero leaderHero8 = item4.LeaderHero;
				string text14 = ((leaderHero8 != null) ? ((MBObjectBase)leaderHero8).StringId : null) ?? "unknown";
				IFaction mapFaction7 = item4.MapFaction;
				string text15 = ((mapFaction7 == null) ? null : ((object)mapFaction7.Name)?.ToString()) ?? "Unknown";
				IFaction mapFaction8 = item4.MapFaction;
				string text16 = ((mapFaction8 != null) ? mapFaction8.StringId : null) ?? "unknown";
				stringBuilder.AppendLine($"- {item4.Army.Name} ({text15}, string_id: \"{text16}\") - Leader: {text13} (string_id: \"{text14}\"), {engagingEnemyInfo}");
			}
			stringBuilder.AppendLine();
		}
		if (!source.Any() && !source2.Any() && !source3.Any() && !source4.Any())
		{
			stringBuilder.AppendLine("No significant military intelligence available.");
		}
		return stringBuilder.ToString().TrimEnd(Array.Empty<char>());
	}

	private string GetEngagingEnemyInfo(MobileParty armyLeader)
	{
		if (armyLeader.SiegeEvent != null)
		{
			Settlement besiegedSettlement = armyLeader.SiegeEvent.BesiegedSettlement;
			object obj;
			if (besiegedSettlement == null)
			{
				obj = null;
			}
			else
			{
				IFaction mapFaction = besiegedSettlement.MapFaction;
				obj = ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString());
			}
			if (obj == null)
			{
				obj = "Unknown";
			}
			string arg = (string)obj;
			return $"Besieging {((besiegedSettlement != null) ? besiegedSettlement.Name : null)} ({arg})";
		}
		if (armyLeader.TargetSettlement != null)
		{
			IFaction mapFaction2 = armyLeader.TargetSettlement.MapFaction;
			string arg2 = ((mapFaction2 == null) ? null : ((object)mapFaction2.Name)?.ToString()) ?? "Unknown";
			return $"Attacking {armyLeader.TargetSettlement.Name} ({arg2})";
		}
		if (armyLeader.TargetParty != null)
		{
			IFaction mapFaction3 = armyLeader.TargetParty.MapFaction;
			string arg3 = ((mapFaction3 == null) ? null : ((object)mapFaction3.Name)?.ToString()) ?? "Unknown";
			return $"Engaging {armyLeader.TargetParty.Name} ({arg3})";
		}
		if (armyLeader.ShortTermTargetParty != null)
		{
			IFaction mapFaction4 = armyLeader.ShortTermTargetParty.MapFaction;
			string arg4 = ((mapFaction4 == null) ? null : ((object)mapFaction4.Name)?.ToString()) ?? "Unknown";
			return $"Pursuing {armyLeader.ShortTermTargetParty.Name} ({arg4})";
		}
		return "In active combat (target unknown)";
	}

	private Settlement GetNearestSettlement(MobileParty party)
	{
		if (party == null)
		{
			return null;
		}
		return (from s in (IEnumerable<Settlement>)Settlement.All
			where s.IsActive
			orderby GameVersionCompatibility.GetDistance(party, s)
			select s).FirstOrDefault();
	}

	private string GetArmyTarget(MobileParty army)
	{
		if (army == null)
		{
			return "Unknown";
		}
		if (army.TargetSettlement != null)
		{
			TextObject name = army.TargetSettlement.Name;
			Clan ownerClan = army.TargetSettlement.OwnerClan;
			object obj;
			if (ownerClan == null)
			{
				obj = null;
			}
			else
			{
				Kingdom kingdom = ownerClan.Kingdom;
				obj = ((kingdom == null) ? null : ((object)kingdom.Name)?.ToString());
			}
			if (obj == null)
			{
				obj = "Independent";
			}
			return $"{name} ({obj})";
		}
		MobilePartyAi ai = army.Ai;
		if (ai != null && ai.DoNotMakeNewDecisions)
		{
			return "Following orders";
		}
		return "Patrolling";
	}

	private List<MarriageInfo> GetRecentMarriages(int daysThreshold = 30)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		List<MarriageInfo> list = new List<MarriageInfo>();
		List<WorldInfoManager.MarriageRecord> recentMarriages = WorldInfoManager.Instance.GetRecentMarriages(daysThreshold);
		foreach (WorldInfoManager.MarriageRecord item2 in recentMarriages)
		{
			CampaignTime val = CampaignTime.Now - item2.MarriageTime;
			int daysAgo = (int)(val).ToDays;
			MarriageInfo marriageInfo = new MarriageInfo();
			Hero husband = item2.Husband;
			marriageInfo.HusbandName = ((husband == null) ? null : ((object)husband.Name)?.ToString()) ?? "Unknown";
			Hero husband2 = item2.Husband;
			marriageInfo.HusbandStringId = ((husband2 != null) ? ((MBObjectBase)husband2).StringId : null) ?? "unknown";
			Hero husband3 = item2.Husband;
			object obj;
			if (husband3 == null)
			{
				obj = null;
			}
			else
			{
				CultureObject culture = husband3.Culture;
				obj = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString());
			}
			if (obj == null)
			{
				obj = "Unknown";
			}
			marriageInfo.HusbandCulture = (string)obj;
			Hero husband4 = item2.Husband;
			object obj2;
			if (husband4 == null)
			{
				obj2 = null;
			}
			else
			{
				Clan clan = husband4.Clan;
				if (clan == null)
				{
					obj2 = null;
				}
				else
				{
					Kingdom kingdom = clan.Kingdom;
					obj2 = ((kingdom == null) ? null : ((object)kingdom.Name)?.ToString());
				}
			}
			if (obj2 == null)
			{
				obj2 = "Independent";
			}
			marriageInfo.HusbandKingdomName = (string)obj2;
			Hero husband5 = item2.Husband;
			object obj3;
			if (husband5 == null)
			{
				obj3 = null;
			}
			else
			{
				Clan clan2 = husband5.Clan;
				if (clan2 == null)
				{
					obj3 = null;
				}
				else
				{
					Kingdom kingdom2 = clan2.Kingdom;
					obj3 = ((kingdom2 != null) ? ((MBObjectBase)kingdom2).StringId : null);
				}
			}
			if (obj3 == null)
			{
				obj3 = "independent";
			}
			marriageInfo.HusbandKingdomStringId = (string)obj3;
			Hero wife = item2.Wife;
			marriageInfo.WifeName = ((wife == null) ? null : ((object)wife.Name)?.ToString()) ?? "Unknown";
			Hero wife2 = item2.Wife;
			marriageInfo.WifeStringId = ((wife2 != null) ? ((MBObjectBase)wife2).StringId : null) ?? "unknown";
			Hero wife3 = item2.Wife;
			object obj4;
			if (wife3 == null)
			{
				obj4 = null;
			}
			else
			{
				CultureObject culture2 = wife3.Culture;
				obj4 = ((culture2 == null) ? null : ((object)((BasicCultureObject)culture2).Name)?.ToString());
			}
			if (obj4 == null)
			{
				obj4 = "Unknown";
			}
			marriageInfo.WifeCulture = (string)obj4;
			Hero wife4 = item2.Wife;
			object obj5;
			if (wife4 == null)
			{
				obj5 = null;
			}
			else
			{
				Clan clan3 = wife4.Clan;
				if (clan3 == null)
				{
					obj5 = null;
				}
				else
				{
					Kingdom kingdom3 = clan3.Kingdom;
					obj5 = ((kingdom3 == null) ? null : ((object)kingdom3.Name)?.ToString());
				}
			}
			if (obj5 == null)
			{
				obj5 = "Independent";
			}
			marriageInfo.WifeKingdomName = (string)obj5;
			Hero wife5 = item2.Wife;
			object obj6;
			if (wife5 == null)
			{
				obj6 = null;
			}
			else
			{
				Clan clan4 = wife5.Clan;
				if (clan4 == null)
				{
					obj6 = null;
				}
				else
				{
					Kingdom kingdom4 = clan4.Kingdom;
					obj6 = ((kingdom4 != null) ? ((MBObjectBase)kingdom4).StringId : null);
				}
			}
			if (obj6 == null)
			{
				obj6 = "independent";
			}
			marriageInfo.WifeKingdomStringId = (string)obj6;
			marriageInfo.PoliticalSignificance = item2.PoliticalSignificance;
			marriageInfo.DaysAgo = daysAgo;
			MarriageInfo item = marriageInfo;
			list.Add(item);
		}
		return list;
	}

	private List<DeathInfo> GetRecentImportantDeaths(int daysThreshold)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		List<DeathInfo> list = new List<DeathInfo>();
		List<WorldInfoManager.DeathRecord> recentDeaths = WorldInfoManager.Instance.GetRecentDeaths();
		foreach (WorldInfoManager.DeathRecord item2 in recentDeaths)
		{
			CampaignTime val = CampaignTime.Now - item2.DeathTime;
			if (!((val).ToDays > (double)daysThreshold))
			{
				DeathInfo obj = new DeathInfo
				{
					HeroName = (((object)item2.Victim.Name)?.ToString() ?? "Unknown"),
					HeroStringId = (((MBObjectBase)item2.Victim).StringId ?? "unknown")
				};
				object title;
				if (!item2.Victim.IsKingdomLeader)
				{
					Clan clan = item2.Victim.Clan;
					title = GetClanTierStatus((clan != null) ? clan.Tier : 0);
				}
				else
				{
					title = "Kingdom Ruler";
				}
				obj.Title = (string)title;
				obj.DeathCause = item2.DeathCause;
				obj.KillerName = item2.KillerName;
				obj.KillerStringId = item2.KillerStringId;
				Clan clan2 = item2.Victim.Clan;
				object obj2;
				if (clan2 == null)
				{
					obj2 = null;
				}
				else
				{
					Kingdom kingdom = clan2.Kingdom;
					obj2 = ((kingdom == null) ? null : ((object)kingdom.Name)?.ToString());
				}
				if (obj2 == null)
				{
					obj2 = "Independent";
				}
				obj.KingdomName = (string)obj2;
				Clan clan3 = item2.Victim.Clan;
				object obj3;
				if (clan3 == null)
				{
					obj3 = null;
				}
				else
				{
					Kingdom kingdom2 = clan3.Kingdom;
					obj3 = ((kingdom2 != null) ? ((MBObjectBase)kingdom2).StringId : null);
				}
				if (obj3 == null)
				{
					obj3 = "independent";
				}
				obj.KingdomStringId = (string)obj3;
				val = CampaignTime.Now - item2.DeathTime;
				obj.DaysAgo = (int)(val).ToDays;
				DeathInfo item = obj;
				list.Add(item);
			}
		}
		return list.OrderByDescending((DeathInfo d) => (d.DaysAgo == 0) ? int.MaxValue : d.DaysAgo).Take(4).ToList();
	}

	private Dictionary<string, string> GetCulturalTraditions()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		try
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
			string path = Path.Combine(fullName, "cultural_traditions.json");
			if (File.Exists(path))
			{
				string text = File.ReadAllText(path);
				Dictionary<string, string> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
				if (dictionary2 != null)
				{
					foreach (KeyValuePair<string, string> item in dictionary2)
					{
						dictionary[item.Key] = item.Value;
					}
				}
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to load cultural_traditions.json: " + ex.Message);
		}
		return dictionary;
	}

	private List<DiscoveryLocation> GetPotentialDiscoveryLocations()
	{
		List<DiscoveryLocation> list = new List<DiscoveryLocation>();
		List<Settlement> list2 = (from s in (IEnumerable<Settlement>)Settlement.All
			where s.IsTown || s.IsCastle
			orderby _random.Next()
			select s).Take(2).ToList();
		foreach (Settlement item2 in list2)
		{
			string discoveryPotential = GetDiscoveryPotential(item2);
			DiscoveryLocation obj = new DiscoveryLocation
			{
				SettlementName = (((object)item2.Name)?.ToString() ?? "Unknown"),
				SettlementStringId = (((MBObjectBase)item2).StringId ?? "unknown"),
				SettlementType = (item2.IsTown ? "Town" : "Castle") + (item2.HasPort ? " (port)" : "")
			};
			IFaction mapFaction = item2.MapFaction;
			obj.KingdomName = ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString()) ?? "Independent";
			IFaction mapFaction2 = item2.MapFaction;
			obj.KingdomStringId = ((mapFaction2 != null) ? mapFaction2.StringId : null) ?? "independent";
			CultureObject culture = item2.Culture;
			obj.Culture = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown";
			obj.DiscoveryPotential = discoveryPotential;
			Clan ownerClan = item2.OwnerClan;
			object obj2;
			if (ownerClan == null)
			{
				obj2 = null;
			}
			else
			{
				Hero leader = ownerClan.Leader;
				obj2 = ((leader == null) ? null : ((object)leader.Name)?.ToString());
			}
			if (obj2 == null)
			{
				obj2 = "Unknown";
			}
			obj.RulerName = (string)obj2;
			Clan ownerClan2 = item2.OwnerClan;
			object obj3;
			if (ownerClan2 == null)
			{
				obj3 = null;
			}
			else
			{
				Hero leader2 = ownerClan2.Leader;
				obj3 = ((leader2 != null) ? ((MBObjectBase)leader2).StringId : null);
			}
			if (obj3 == null)
			{
				obj3 = "unknown";
			}
			obj.RulerStringId = (string)obj3;
			DiscoveryLocation item = obj;
			list.Add(item);
		}
		return list;
	}

	private List<DiseaseVulnerableSettlement> GetDiseaseVulnerableSettlements()
	{
		List<DiseaseVulnerableSettlement> list = new List<DiseaseVulnerableSettlement>();
		List<Settlement> list2 = (from s in (IEnumerable<Settlement>)Settlement.All
			where s.IsTown || s.IsCastle
			where IsDiseaseVulnerable(s)
			orderby _random.Next()
			select s).Take(2).ToList();
		foreach (Settlement item2 in list2)
		{
			string vulnerabilityLevel = GetVulnerabilityLevel(item2);
			string riskFactors = GetRiskFactors(item2);
			DiseaseVulnerableSettlement obj = new DiseaseVulnerableSettlement
			{
				SettlementName = (((object)item2.Name)?.ToString() ?? "Unknown"),
				SettlementStringId = (((MBObjectBase)item2).StringId ?? "unknown"),
				SettlementType = (item2.IsTown ? "Town" : "Castle") + (item2.HasPort ? " (port)" : "")
			};
			IFaction mapFaction = item2.MapFaction;
			obj.KingdomName = ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString()) ?? "Independent";
			IFaction mapFaction2 = item2.MapFaction;
			obj.KingdomStringId = ((mapFaction2 != null) ? mapFaction2.StringId : null) ?? "independent";
			CultureObject culture = item2.Culture;
			obj.Culture = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown";
			obj.VulnerabilityLevel = vulnerabilityLevel;
			obj.RiskFactors = riskFactors;
			Clan ownerClan = item2.OwnerClan;
			object obj2;
			if (ownerClan == null)
			{
				obj2 = null;
			}
			else
			{
				Hero leader = ownerClan.Leader;
				obj2 = ((leader == null) ? null : ((object)leader.Name)?.ToString());
			}
			if (obj2 == null)
			{
				obj2 = "Unknown";
			}
			obj.RulerName = (string)obj2;
			Clan ownerClan2 = item2.OwnerClan;
			object obj3;
			if (ownerClan2 == null)
			{
				obj3 = null;
			}
			else
			{
				Hero leader2 = ownerClan2.Leader;
				obj3 = ((leader2 != null) ? ((MBObjectBase)leader2).StringId : null);
			}
			if (obj3 == null)
			{
				obj3 = "unknown";
			}
			obj.RulerStringId = (string)obj3;
			DiseaseVulnerableSettlement item = obj;
			list.Add(item);
		}
		return list;
	}

	private List<StrangeOccurrenceSettlement> GetStrangeOccurrenceSettlements()
	{
		List<StrangeOccurrenceSettlement> list = new List<StrangeOccurrenceSettlement>();
		List<Settlement> list2 = (from s in (IEnumerable<Settlement>)Settlement.All
			where s.IsTown || s.IsCastle
			where HasStrangeOccurrencePotential(s)
			orderby _random.Next()
			select s).Take(2).ToList();
		foreach (Settlement item2 in list2)
		{
			string strangePotential = GetStrangePotential(item2);
			string contributingFactors = GetContributingFactors(item2);
			StrangeOccurrenceSettlement obj = new StrangeOccurrenceSettlement
			{
				SettlementName = (((object)item2.Name)?.ToString() ?? "Unknown"),
				SettlementStringId = (((MBObjectBase)item2).StringId ?? "unknown"),
				SettlementType = (item2.IsTown ? "Town" : "Castle") + (item2.HasPort ? " (port)" : "")
			};
			IFaction mapFaction = item2.MapFaction;
			obj.KingdomName = ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString()) ?? "Independent";
			IFaction mapFaction2 = item2.MapFaction;
			obj.KingdomStringId = ((mapFaction2 != null) ? mapFaction2.StringId : null) ?? "independent";
			CultureObject culture = item2.Culture;
			obj.Culture = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown";
			obj.StrangePotential = strangePotential;
			obj.ContributingFactors = contributingFactors;
			Clan ownerClan = item2.OwnerClan;
			object obj2;
			if (ownerClan == null)
			{
				obj2 = null;
			}
			else
			{
				Hero leader = ownerClan.Leader;
				obj2 = ((leader == null) ? null : ((object)leader.Name)?.ToString());
			}
			if (obj2 == null)
			{
				obj2 = "Unknown";
			}
			obj.RulerName = (string)obj2;
			Clan ownerClan2 = item2.OwnerClan;
			object obj3;
			if (ownerClan2 == null)
			{
				obj3 = null;
			}
			else
			{
				Hero leader2 = ownerClan2.Leader;
				obj3 = ((leader2 != null) ? ((MBObjectBase)leader2).StringId : null);
			}
			if (obj3 == null)
			{
				obj3 = "unknown";
			}
			obj.RulerStringId = (string)obj3;
			StrangeOccurrenceSettlement item = obj;
			list.Add(item);
		}
		return list;
	}

	private string GetDiscoveryPotential(Settlement settlement)
	{
		List<string> list = new List<string>();
		if (settlement.IsCastle)
		{
			list.Add("ancient fortress");
		}
		CultureObject culture = settlement.Culture;
		string text = ((culture != null) ? ((MBObjectBase)culture).StringId : null) ?? "";
		if (text.Contains("empire"))
		{
			list.Add("imperial ruins");
		}
		else if (text.Contains("vlandia"))
		{
			list.Add("old kingdom artifacts");
		}
		else if (text.Contains("sturgia"))
		{
			list.Add("northern mysteries");
		}
		if (SettlementCaptureManager.Instance.IsRecentlyCaptured(((MBObjectBase)settlement).StringId, 60))
		{
			list.Add("recently disturbed");
		}
		return list.Any() ? string.Join(", ", list) : "moderate archaeological potential";
	}

	private bool IsDiseaseVulnerable(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return false;
		}
		bool flag = settlement.Town.Prosperity < (float)PROSPERITY_MEDIUM_THRESHOLD;
		bool flag2 = ((Fief)settlement.Town).FoodStocks < (float)FOOD_STOCKS_LOW_THRESHOLD;
		bool flag3 = settlement.Town.Security < (float)TOWN_SECURITY_LOW_THRESHOLD;
		bool isUnderSiege = settlement.IsUnderSiege;
		return flag || flag2 || flag3 || isUnderSiege;
	}

	private string GetVulnerabilityLevel(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return "unknown";
		}
		int num = 0;
		if (settlement.Town.Prosperity < 2000f)
		{
			num++;
		}
		if (((Fief)settlement.Town).FoodStocks < 100f)
		{
			num++;
		}
		if (settlement.Town.Security < 30f)
		{
			num++;
		}
		if (settlement.IsUnderSiege)
		{
			num++;
		}
		return num switch
		{
			1 => "low vulnerability", 
			2 => "moderate vulnerability", 
			3 => "high vulnerability", 
			4 => "extreme vulnerability", 
			_ => "unknown vulnerability", 
		};
	}

	private string GetRiskFactors(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return "none";
		}
		List<string> list = new List<string>();
		if (settlement.Town.Prosperity < 2000f)
		{
			list.Add("poverty");
		}
		if (((Fief)settlement.Town).FoodStocks < 100f)
		{
			list.Add("food shortage");
		}
		if (settlement.Town.Security < 30f)
		{
			list.Add("poor sanitation");
		}
		if (settlement.IsUnderSiege)
		{
			list.Add("siege conditions");
		}
		return list.Any() ? string.Join(", ", list) : "none";
	}

	private bool HasStrangeOccurrencePotential(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return false;
		}
		bool flag = settlement.Town.Loyalty < (float)TOWN_LOYALTY_LOW_THRESHOLD;
		bool flag2 = settlement.Town.Security < (float)TOWN_SECURITY_LOW_THRESHOLD;
		bool isUnderSiege = settlement.IsUnderSiege;
		bool flag3 = SettlementCaptureManager.Instance.IsRecentlyCaptured(((MBObjectBase)settlement).StringId);
		return flag || flag2 || isUnderSiege || flag3;
	}

	private string GetStrangePotential(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return "unknown";
		}
		int num = 0;
		if (settlement.Town.Loyalty < 30f)
		{
			num++;
		}
		if (settlement.Town.Security < 30f)
		{
			num++;
		}
		if (settlement.IsUnderSiege)
		{
			num++;
		}
		if (SettlementCaptureManager.Instance.IsRecentlyCaptured(((MBObjectBase)settlement).StringId))
		{
			num++;
		}
		return num switch
		{
			1 => "low strange potential", 
			2 => "moderate strange potential", 
			3 => "high strange potential", 
			4 => "extreme strange potential", 
			_ => "unknown strange potential", 
		};
	}

	private string GetContributingFactors(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return "none";
		}
		List<string> list = new List<string>();
		if (settlement.Town.Loyalty < 30f)
		{
			list.Add("discontent population");
		}
		if (settlement.Town.Security < 30f)
		{
			list.Add("lawlessness");
		}
		if (settlement.IsUnderSiege)
		{
			list.Add("siege stress");
		}
		if (SettlementCaptureManager.Instance.IsRecentlyCaptured(((MBObjectBase)settlement).StringId))
		{
			list.Add("recent instability");
		}
		return list.Any() ? string.Join(", ", list) : "none";
	}

	private string CollectDiplomaticStatementsData()
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
		{
			return "=== DIPLOMACY SYSTEM DISABLED ===";
		}
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("=== RECENT DIPLOMATIC STATEMENTS (Last 15 statements from last 50 days) ===");
			DiplomaticStatementsStorage instance = DiplomaticStatementsStorage.Instance;
			List<KingdomStatement> recentStatements = instance.GetRecentStatements(50);
			if (!recentStatements.Any())
			{
				stringBuilder.AppendLine("No recent diplomatic statements.");
				return stringBuilder.ToString();
			}
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			List<IGrouping<string, KingdomStatement>> list = (from s in recentStatements
				group s by s.EventId into g
				orderby g.Max((KingdomStatement s) => s.Timestamp) descending
				select g).ToList();
			foreach (IGrouping<string, KingdomStatement> item in list)
			{
				DynamicEvent eventById = DynamicEventsManager.Instance.GetEventById(item.Key);
				if (eventById != null)
				{
					stringBuilder.AppendLine("\nEvent: " + eventById.Description);
					stringBuilder.AppendLine("Participating Kingdoms: " + string.Join(", ", eventById.ParticipatingKingdoms));
				}
				else
				{
					stringBuilder.AppendLine("\nEvent: [Expired event]");
				}
				stringBuilder.AppendLine("Statements:");
				foreach (KingdomStatement statement in item.OrderBy((KingdomStatement s) => s.Timestamp))
				{
					Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == statement.KingdomId));
					string text;
					string text2;
					string text3;
					if (val == null)
					{
						text = statement.KingdomId;
						text2 = "Unknown";
						text3 = "unknown";
					}
					else if (val.IsEliminated)
					{
						text = $"{val.Name} [Destroyed]";
						Hero leader = val.Leader;
						text2 = ((leader != null) ? ((object)leader.Name).ToString() : null) ?? "[Destroyed Kingdom]";
						Hero leader2 = val.Leader;
						text3 = ((leader2 != null) ? ((MBObjectBase)leader2).StringId : null) ?? "unknown";
					}
					else
					{
						text = ((object)val.Name).ToString();
						Hero leader3 = val.Leader;
						text2 = ((leader3 != null) ? ((object)leader3.Name).ToString() : null) ?? "Unknown";
						Hero leader4 = val.Leader;
						text3 = ((leader4 != null) ? ((MBObjectBase)leader4).StringId : null) ?? "unknown";
					}
					int num2 = 0;
					if (statement.CampaignDays > 0f)
					{
						float campaignDays = statement.CampaignDays;
						num2 = Math.Max(0, (int)(num - campaignDays));
					}
					stringBuilder.AppendLine($"  - {text} (string_id: \"{statement.KingdomId}\") (Ruler: {text2}, string_id: \"{text3}\"): {statement.StatementText} ({num2} days ago)");
					if (statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any())
					{
						List<string> values = statement.TargetKingdomIds.Select(delegate(string id)
						{
							Kingdom val3 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom kingdom) => ((MBObjectBase)kingdom).StringId == id));
							if (val3 == null)
							{
								return id;
							}
							return val3.IsEliminated ? $"{val3.Name} [Destroyed]" : ((object)val3.Name).ToString();
						}).ToList();
						stringBuilder.AppendLine("    Targets: " + string.Join(", ", values));
					}
					else if (!string.IsNullOrEmpty(statement.TargetKingdomId))
					{
						Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == statement.TargetKingdomId));
						string text4 = ((val2 == null) ? statement.TargetKingdomId : ((!val2.IsEliminated) ? ((object)val2.Name).ToString() : $"{val2.Name} [Destroyed]"));
						stringBuilder.AppendLine("    Target: " + text4);
					}
					if (statement.Action != DiplomaticAction.None)
					{
						stringBuilder.AppendLine($"    Action: {statement.Action}");
					}
				}
			}
			return stringBuilder.ToString();
		}
		catch (Exception exception)
		{
			DiplomacyLogger.Instance?.LogError("CollectDiplomaticStatementsData", "Error collecting diplomatic statements", exception);
			return "=== ERROR COLLECTING DIPLOMATIC STATEMENTS ===";
		}
	}

	private async Task ProcessDiplomaticEventAsync(DynamicEvent diplomaticEvent)
	{
		try
		{
			DiplomacyLogger.Instance?.Log("Processing diplomatic event " + diplomaticEvent.Id);
			DiplomacyLogger.Instance?.Log("Event type: " + diplomaticEvent.Type);
			DiplomacyLogger.Instance?.Log("Kingdoms involved: " + string.Join(", ", diplomaticEvent.GetKingdomStringIds()));
			DiplomacyLogger.Instance?.Log($"Requires diplomatic analysis: {diplomaticEvent.RequiresDiplomaticAnalysis}");
			DiplomacyLogger.Instance?.Log($"Allows diplomatic response: {diplomaticEvent.AllowsDiplomaticResponse}");
			DiplomacyLogger.Instance?.Log("Participating kingdoms: " + string.Join(", ", diplomaticEvent.ParticipatingKingdoms ?? new List<string>()));
			DiplomacyManager diplomacyManager = DiplomacyManager.Instance;
			if (diplomacyManager == null)
			{
				DiplomacyLogger.Instance?.Log("DiplomacyManager not initialized");
				return;
			}
			await diplomacyManager.ProcessDiplomaticEvent(diplomaticEvent);
			DiplomacyLogger.Instance?.Log("Diplomatic event " + diplomaticEvent.Id + " processed successfully");
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DiplomacyLogger.Instance?.LogError("DynamicEventsGenerator.ProcessDiplomaticEventAsync", "Failed to process diplomatic event " + diplomaticEvent.Id, ex2);
		}
	}

	private void OnKingdomDestroyed(Kingdom destroyedKingdom)
	{
		if (destroyedKingdom != null && destroyedKingdom.IsEliminated)
		{
			DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] Kingdom '{destroyedKingdom.Name}' (string_id: {((MBObjectBase)destroyedKingdom).StringId}) has been destroyed");
			KingdomDestructionInfo kingdomDestructionInfo = DetermineKingdomDestroyer(destroyedKingdom);
			_kingdomDestructionTracker[((MBObjectBase)destroyedKingdom).StringId] = kingdomDestructionInfo;
			CreateKingdomDestructionEvent(destroyedKingdom, kingdomDestructionInfo);
		}
	}

	private KingdomDestructionInfo DetermineKingdomDestroyer(Kingdom destroyedKingdom)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		KingdomDestructionInfo destructionInfo = new KingdomDestructionInfo
		{
			DestroyedKingdomId = ((MBObjectBase)destroyedKingdom).StringId,
			DestroyedKingdomName = (((object)destroyedKingdom.Name)?.ToString() ?? "Unknown"),
			DestructionTime = CampaignTime.Now
		};
		SettlementOwnershipTracker instance = SettlementOwnershipTracker.Instance;
		WarStatisticsTracker instance2 = WarStatisticsTracker.Instance;
		List<SettlementCaptureInfo> list = new List<SettlementCaptureInfo>();
		CampaignTime now = CampaignTime.Now;
		float num = (float)(now).ToDays;
		float cutoffDays = num - 30f;
		foreach (Settlement item in ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsTown || s.IsCastle))
		{
			SettlementOwnershipHistory settlementOwnershipHistory = instance?.GetOwnershipHistory(((MBObjectBase)item).StringId);
			if (settlementOwnershipHistory == null || (!(settlementOwnershipHistory.OriginalOwnerKingdomId == ((MBObjectBase)destroyedKingdom).StringId) && !settlementOwnershipHistory.OwnershipChanges.Any((OwnershipChange c) => c.FromKingdomId == ((MBObjectBase)destroyedKingdom).StringId)))
			{
				continue;
			}
			List<OwnershipChange> source = (from c in settlementOwnershipHistory.OwnershipChanges.Where(delegate(OwnershipChange c)
				{
					//IL_0019: Unknown result type (might be due to invalid IL or missing references)
					//IL_001e: Unknown result type (might be due to invalid IL or missing references)
					int result;
					if (c.FromKingdomId == ((MBObjectBase)destroyedKingdom).StringId)
					{
						CampaignTime changeDate = c.ChangeDate;
						result = (((float)(changeDate).ToDays >= cutoffDays) ? 1 : 0);
					}
					else
					{
						result = 0;
					}
					return (byte)result != 0;
				})
				orderby c.ChangeDate descending
				select c).ToList();
			if (source.Any())
			{
				OwnershipChange lastCapture = source.First();
				Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == lastCapture.ToKingdomId && !k.IsEliminated));
				list.Add(new SettlementCaptureInfo
				{
					SettlementId = ((MBObjectBase)item).StringId,
					SettlementName = (((object)item.Name)?.ToString() ?? "Unknown"),
					CapturerKingdomId = lastCapture.ToKingdomId,
					CapturerKingdomName = (((val == null) ? null : ((object)val.Name)?.ToString()) ?? lastCapture.ToKingdomName ?? "Unknown"),
					CaptureTime = lastCapture.ChangeDate
				});
			}
		}
		List<string> recentlyCapturedSettlementsFromKingdom = SettlementCaptureManager.Instance.GetRecentlyCapturedSettlementsFromKingdom(destroyedKingdom);
		foreach (string settlementId in recentlyCapturedSettlementsFromKingdom)
		{
			if (!list.Any((SettlementCaptureInfo c) => c.SettlementId == settlementId) && SettlementCaptureManager.Instance.IsRecentlyCaptured(settlementId))
			{
				CampaignTime captureTime = SettlementCaptureManager.Instance.GetCaptureTime(settlementId);
				Kingdom capturerKingdom = SettlementCaptureManager.Instance.GetCapturerKingdom(settlementId);
				Settlement val2 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == settlementId));
				list.Add(new SettlementCaptureInfo
				{
					SettlementId = settlementId,
					SettlementName = (((val2 == null) ? null : ((object)val2.Name)?.ToString()) ?? "Unknown"),
					CapturerKingdomId = (((capturerKingdom != null) ? ((MBObjectBase)capturerKingdom).StringId : null) ?? "unknown"),
					CapturerKingdomName = (((capturerKingdom == null) ? null : ((object)capturerKingdom.Name)?.ToString()) ?? "Unknown"),
					CaptureTime = captureTime
				});
			}
		}
		if (list.Any())
		{
			var source2 = (from c in list
				group c by c.CapturerKingdomId into g
				select new
				{
					KingdomId = g.Key,
					KingdomName = g.First().CapturerKingdomName,
					CaptureCount = g.Count(),
					LastCapture = g.OrderByDescending((SettlementCaptureInfo c) => c.CaptureTime).First()
				} into x
				orderby x.CaptureCount descending, x.LastCapture.CaptureTime descending
				select x).ToList();
			var anon = source2.First();
			SettlementCaptureInfo lastCapture2 = anon.LastCapture;
			destructionInfo.DestroyerKingdomId = anon.KingdomId;
			destructionInfo.DestroyerKingdomName = anon.KingdomName;
			destructionInfo.LastCapturedSettlementId = lastCapture2.SettlementId;
			destructionInfo.LastCapturedSettlementName = lastCapture2.SettlementName;
			destructionInfo.Method = "conquest";
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
			Kingdom val3 = (Kingdom)obj;
			if (val3 != null && ((MBObjectBase)val3).StringId == anon.KingdomId)
			{
				destructionInfo.PlayerInvolved = true;
			}
			DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] Determined destroyer from memory: {destructionInfo.DestroyerKingdomName} (captured {anon.CaptureCount} settlements, last: {lastCapture2.SettlementName} at {lastCapture2.CaptureTime})");
		}
		else
		{
			KingdomWarStats kingdomWarStats = instance2?.GetKingdomStats(destroyedKingdom);
			if (kingdomWarStats != null && kingdomWarStats.WarsAgainstKingdoms != null && kingdomWarStats.WarsAgainstKingdoms.Any())
			{
				destructionInfo.Method = "internal_collapse";
				DynamicEventsLogger.Instance.Log("[KINGDOM_DESTRUCTION] Had wars but no recent captures - likely internal collapse (all clans left)");
			}
			else
			{
				destructionInfo.Method = "internal_collapse";
				DynamicEventsLogger.Instance.Log("[KINGDOM_DESTRUCTION] No recent captures or wars found in memory - likely internal collapse");
			}
		}
		if (!string.IsNullOrEmpty(destructionInfo.DestroyerKingdomId) && destructionInfo.DestroyerKingdomId != "unknown")
		{
			Kingdom val4 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == destructionInfo.DestroyerKingdomId && !k.IsEliminated));
			if (val4 != null)
			{
				destructionInfo.CurrentWar = GetCurrentWarInfo(destroyedKingdom, val4);
				destructionInfo.DestroyedKingdomAllies = GetKingdomAllies(destroyedKingdom);
				destructionInfo.DestroyerKingdomAllies = GetKingdomAllies(val4);
				destructionInfo.WarLosses = GetWarLossesInfo(destroyedKingdom, val4);
			}
		}
		destructionInfo.WarsInvolved = GetKingdomWarsAtDestruction(destroyedKingdom);
		return destructionInfo;
	}

	private List<WarInfo> GetKingdomWarsAtDestruction(Kingdom kingdom)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		List<WarInfo> list = new List<WarInfo>();
		try
		{
			WarStatisticsTracker instance = WarStatisticsTracker.Instance;
			if (instance == null)
			{
				DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] WarStatisticsTracker not available for {kingdom.Name}");
				return list;
			}
			KingdomWarStats kingdomStats = instance.GetKingdomStats(kingdom);
			if (kingdomStats == null || kingdomStats.WarsAgainstKingdoms == null)
			{
				DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] No war stats found in memory for {kingdom.Name}");
				return list;
			}
			foreach (KeyValuePair<string, WarStatsAgainstKingdom> warsAgainstKingdom in kingdomStats.WarsAgainstKingdoms)
			{
				string enemyKingdomId = warsAgainstKingdom.Key;
				WarStatsAgainstKingdom value = warsAgainstKingdom.Value;
				Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == enemyKingdomId && !k.IsEliminated));
				string enemyKingdomName = ((val != null && !val.IsEliminated) ? (((object)val.Name)?.ToString() ?? "Unknown") : enemyKingdomId);
				CampaignTime val2 = CampaignTime.Now - value.WarStartTime;
				int durationDays = (int)(val2).ToDays;
				list.Add(new WarInfo
				{
					EnemyKingdomId = enemyKingdomId,
					EnemyKingdomName = enemyKingdomName,
					DurationDays = durationDays
				});
			}
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] Error getting wars from memory for {kingdom.Name}: {ex.Message}");
		}
		return list;
	}

	private CurrentWarInfo GetCurrentWarInfo(Kingdom destroyedKingdom, Kingdom destroyerKingdom)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		CurrentWarInfo currentWarInfo = new CurrentWarInfo();
		try
		{
			WarStatisticsTracker instance = WarStatisticsTracker.Instance;
			if (instance == null)
			{
				return currentWarInfo;
			}
			KingdomWarStats kingdomStats = instance.GetKingdomStats(destroyedKingdom);
			KingdomWarStats kingdomStats2 = instance.GetKingdomStats(destroyerKingdom);
			if (kingdomStats != null && kingdomStats.WarsAgainstKingdoms.ContainsKey(((MBObjectBase)destroyerKingdom).StringId))
			{
				WarStatsAgainstKingdom warStatsAgainstKingdom = kingdomStats.WarsAgainstKingdoms[((MBObjectBase)destroyerKingdom).StringId];
				CampaignTime val = CampaignTime.Now - warStatsAgainstKingdom.WarStartTime;
				currentWarInfo.DurationDays = (int)(val).ToDays;
				currentWarInfo.DestroyedKingdomCasualties = warStatsAgainstKingdom.CasualtiesAgainstThisKingdom;
			}
			if (kingdomStats2 != null && kingdomStats2.WarsAgainstKingdoms.ContainsKey(((MBObjectBase)destroyedKingdom).StringId))
			{
				WarStatsAgainstKingdom warStatsAgainstKingdom2 = kingdomStats2.WarsAgainstKingdoms[((MBObjectBase)destroyedKingdom).StringId];
				currentWarInfo.DestroyerKingdomCasualties = warStatsAgainstKingdom2.CasualtiesAgainstThisKingdom;
			}
			DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] Current war info: {currentWarInfo.DurationDays} days, casualties: {destroyedKingdom.Name}={currentWarInfo.DestroyedKingdomCasualties}, {destroyerKingdom.Name}={currentWarInfo.DestroyerKingdomCasualties}");
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[KINGDOM_DESTRUCTION] Error getting current war info: " + ex.Message);
		}
		return currentWarInfo;
	}

	private List<string> GetKingdomAllies(Kingdom kingdom)
	{
		List<string> list = new List<string>();
		try
		{
			AllianceSystem allianceSystem = AllianceSystem.Instance;
			if (allianceSystem == null)
			{
				return list;
			}
			List<Kingdom> list2 = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => k != kingdom && !k.IsEliminated && allianceSystem.AreAllied(kingdom, k)).ToList();
			foreach (Kingdom item in list2)
			{
				list.Add(((MBObjectBase)item).StringId);
			}
			DynamicEventsLogger.Instance.Log(string.Format("[KINGDOM_DESTRUCTION] {0} allies: {1}", kingdom.Name, string.Join(", ", list)));
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] Error getting allies for {kingdom.Name}: {ex.Message}");
		}
		return list;
	}

	private WarLossesInfo GetWarLossesInfo(Kingdom destroyedKingdom, Kingdom destroyerKingdom)
	{
		WarLossesInfo warLossesInfo = new WarLossesInfo();
		try
		{
			WarStatisticsTracker instance = WarStatisticsTracker.Instance;
			if (instance == null)
			{
				return warLossesInfo;
			}
			KingdomWarStats kingdomStats = instance.GetKingdomStats(destroyedKingdom);
			KingdomWarStats kingdomStats2 = instance.GetKingdomStats(destroyerKingdom);
			if (kingdomStats != null)
			{
				warLossesInfo.DestroyedKingdomTroopsLost = kingdomStats.TotalCasualties;
				warLossesInfo.DestroyedKingdomLordsCaptured = kingdomStats.TotalLordsCaptured;
				warLossesInfo.DestroyedKingdomLordsKilled = kingdomStats.TotalLordsKilled;
				warLossesInfo.DestroyedKingdomSettlementsLost = kingdomStats.TotalSettlementsLost;
				warLossesInfo.DestroyedKingdomCaravansDestroyed = kingdomStats.TotalCaravansDestroyed;
				warLossesInfo.DestroyedKingdomWarFatigue = kingdomStats.WarFatigue;
			}
			if (kingdomStats2 != null)
			{
				warLossesInfo.DestroyerKingdomTroopsLost = kingdomStats2.TotalCasualties;
				warLossesInfo.DestroyerKingdomLordsCaptured = kingdomStats2.TotalLordsCaptured;
				warLossesInfo.DestroyerKingdomLordsKilled = kingdomStats2.TotalLordsKilled;
				warLossesInfo.DestroyerKingdomSettlementsLost = kingdomStats2.TotalSettlementsLost;
				warLossesInfo.DestroyerKingdomCaravansDestroyed = kingdomStats2.TotalCaravansDestroyed;
				warLossesInfo.DestroyerKingdomWarFatigue = kingdomStats2.WarFatigue;
			}
			if (kingdomStats != null && kingdomStats.WarsAgainstKingdoms.ContainsKey(((MBObjectBase)destroyerKingdom).StringId))
			{
				WarStatsAgainstKingdom warStatsAgainstKingdom = kingdomStats.WarsAgainstKingdoms[((MBObjectBase)destroyerKingdom).StringId];
				warLossesInfo.DestroyedKingdomCasualtiesInThisWar = warStatsAgainstKingdom.CasualtiesAgainstThisKingdom;
			}
			if (kingdomStats2 != null && kingdomStats2.WarsAgainstKingdoms.ContainsKey(((MBObjectBase)destroyedKingdom).StringId))
			{
				WarStatsAgainstKingdom warStatsAgainstKingdom2 = kingdomStats2.WarsAgainstKingdoms[((MBObjectBase)destroyedKingdom).StringId];
				warLossesInfo.DestroyerKingdomCasualtiesInThisWar = warStatsAgainstKingdom2.CasualtiesAgainstThisKingdom;
			}
			DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] War losses: {destroyedKingdom.Name} lost {warLossesInfo.DestroyedKingdomCasualtiesInThisWar} troops, {destroyerKingdom.Name} lost {warLossesInfo.DestroyerKingdomCasualtiesInThisWar} troops in this war");
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[KINGDOM_DESTRUCTION] Error getting war losses info: " + ex.Message);
		}
		return warLossesInfo;
	}

	private async Task CreateKingdomDestructionEvent(Kingdom destroyedKingdom, KingdomDestructionInfo destructionInfo)
	{
		try
		{
			DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] Creating event for destruction of {destroyedKingdom.Name}");
			string worldData = CollectWorldDataExcludingKingdom(((MBObjectBase)destroyedKingdom).StringId);
			string existingEvents = GetExistingEventsData();
			string diplomaticStatements = CollectDiplomaticStatementsData();
			string prompt = BuildKingdomDestructionPrompt(worldData, existingEvents, diplomaticStatements, destructionInfo);
			DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] Sending prompt to AI ({prompt.Length} characters)");
			AIInfluenceBehavior behavior = AIInfluenceBehavior.Instance;
			if (behavior == null)
			{
				DynamicEventsLogger.Instance.Log("[KINGDOM_DESTRUCTION] AIInfluenceBehavior instance not found");
				return;
			}
			string aiResponse = await behavior.SendAIRequestWithBackend(prompt, "kingdom_destruction_event", GlobalSettings<ModSettings>.Instance.DynamicEventsAIBackend.SelectedValue);
			if (string.IsNullOrEmpty(aiResponse))
			{
				DynamicEventsLogger.Instance.Log("[KINGDOM_DESTRUCTION] AI returned empty response for kingdom destruction event");
				return;
			}
			DynamicEventsResponse eventsResponse = ParseAIResponse(aiResponse);
			if (eventsResponse == null || !eventsResponse.Events.Any())
			{
				DynamicEventsLogger.Instance.Log("[KINGDOM_DESTRUCTION] No events generated by AI for kingdom destruction");
				DynamicEventsLogger.Instance.LogEventGeneration(prompt, aiResponse, 0);
				return;
			}
			DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] AI generated {eventsResponse.Events.Count} events for kingdom destruction");
			DynamicEventsLogger.Instance.LogEventGeneration(prompt, aiResponse, eventsResponse.Events.Count);
			foreach (DynamicEvent dynamicEvent in eventsResponse.Events)
			{
				ProcessGeneratedEvent(dynamicEvent);
			}
			DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] Successfully created event for destruction of {destroyedKingdom.Name}");
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DynamicEventsLogger.Instance.Log($"[KINGDOM_DESTRUCTION] Error creating event for {destroyedKingdom.Name}: {ex2.Message}\n{ex2.StackTrace}");
		}
	}

	private string CollectWorldDataExcludingKingdom(string excludedKingdomId)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected I4, but got Unknown
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("=== CURRENT WORLD STATE (EXCLUDING DESTROYED KINGDOM) ===");
		stringBuilder.AppendLine();
		CampaignTime now = CampaignTime.Now;
		Seasons getSeasonOfYear = (now).GetSeasonOfYear;
		Seasons val = getSeasonOfYear;
		stringBuilder.AppendLine(string.Format("CURRENT TIME: Year {0}, {1}", (now).GetYear, (int)val switch
		{
			0 => "spring", 
			1 => "summer", 
			2 => "autumn", 
			3 => "winter", 
			_ => "unknown", 
		}));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("EXISTING KINGDOMS (excluding the destroyed one):");
		stringBuilder.AppendLine("**IMPORTANT: When using string_id in JSON, use ONLY the value (e.g. \"empire\"), NOT \"string_id:empire\"**");
		foreach (Kingdom item in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && ((MBObjectBase)k).StringId != excludedKingdomId))
		{
			Hero leader = item.Leader;
			stringBuilder.AppendLine("- " + (((object)item.Name)?.ToString() ?? "Unknown"));
			stringBuilder.AppendLine("  string_id: \"" + ((MBObjectBase)item).StringId + "\"");
			stringBuilder.AppendLine("  Leader: " + (((leader == null) ? null : ((object)leader.Name)?.ToString()) ?? "None"));
			if (leader != null)
			{
				stringBuilder.AppendLine("  Leader string_id: \"" + ((MBObjectBase)leader).StringId + "\"");
			}
			IEnumerable<Kingdom> enemyKingdoms = GameVersionCompatibility.GetEnemyKingdoms(item);
			if (enemyKingdoms.Any())
			{
				stringBuilder.AppendLine("  At war with: " + string.Join(", ", enemyKingdoms.Select((Kingdom e) => ((object)e.Name)?.ToString() ?? "Unknown")));
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	private string BuildKingdomDestructionPrompt(string worldData, string existingEvents, string diplomaticStatements, KingdomDestructionInfo destructionInfo)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = MBTextManager.ActiveTextLanguage ?? "English";
		string text2 = WorldInfoManager.Instance.ReadWorldInfo();
		if (GlobalSettings<ModSettings>.Instance.EnableDynamicEventsInternalThoughts)
		{
			stringBuilder.AppendLine("### CRITICAL: Internal Thought Process (REQUIRED BEFORE GENERATING EVENT) ###");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("**IMPORTANT: You MUST think through the kingdom destruction event generation process before crafting the JSON.**");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("**STEP 0: VERIFY DESTRUCTION FACTS**");
			stringBuilder.AppendLine("- Which kingdom was destroyed? (Check DESTROYED KINGDOM section)");
			stringBuilder.AppendLine("- Who destroyed it? (Check DESTROYED BY section - may be unknown)");
			stringBuilder.AppendLine("- How was it destroyed? (conquest vs internal_collapse)");
			stringBuilder.AppendLine("- What wars was it involved in? (Check WARS AT TIME OF DESTRUCTION)");
			stringBuilder.AppendLine("- Was the player involved? (Check PLAYER INVOLVEMENT section)");
			stringBuilder.AppendLine("- **Write in internal_thoughts:** Start with 'FACT CHECK:' listing verified destruction facts.");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("**STEP 1: ANALYZE POLITICAL CONSEQUENCES**");
			stringBuilder.AppendLine("- What power vacuum was created?");
			stringBuilder.AppendLine("- Which surviving kingdoms are most affected?");
			stringBuilder.AppendLine("- What territorial disputes might arise?");
			stringBuilder.AppendLine("- How will alliances shift?");
			stringBuilder.AppendLine("- What diplomatic realignments are likely?");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("**STEP 2: PLAN EVENT STRUCTURE**");
			stringBuilder.AppendLine("- CAUSE: Why/how was the kingdom destroyed?");
			stringBuilder.AppendLine("- IMMEDIATE CONSEQUENCES: What happens right after destruction?");
			stringBuilder.AppendLine("- LONG-TERM IMPACT: How does the world change?");
			stringBuilder.AppendLine("- Which kingdoms should be in kingdoms_involved? (surviving kingdoms affected)");
			stringBuilder.AppendLine("- What importance level? (8-10 for kingdom destruction)");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("**OUTPUT:** Include `internal_thoughts` field in JSON with your reasoning (500-2000 characters).");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("# MISSION: Generate Kingdom Destruction Event");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("You are an intelligent world event generator for Mount & Blade II: Bannerlord.");
		stringBuilder.AppendLine("You are operating in the world of " + text2 + ".");
		stringBuilder.AppendLine("Language: " + text);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## CORE RULES:");
		stringBuilder.AppendLine("Create ONE significant POLITICAL event about the destruction of a kingdom.");
		stringBuilder.AppendLine("Focus on the POLITICAL CONSEQUENCES and IMPACT of this kingdom's destruction.");
		stringBuilder.AppendLine("Consider power vacuums, territorial disputes, diplomatic realignments, succession crises.");
		stringBuilder.AppendLine("The event should be noteworthy and have lasting POLITICAL effects on the world.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## KINGDOM DESTRUCTION DETAILS:");
		stringBuilder.AppendLine("DESTROYED KINGDOM: " + destructionInfo.DestroyedKingdomName + " (string_id: \"" + destructionInfo.DestroyedKingdomId + "\")");
		if (!string.IsNullOrEmpty(destructionInfo.DestroyerKingdomId) && destructionInfo.DestroyerKingdomId != "unknown")
		{
			stringBuilder.AppendLine("DESTROYED BY: " + destructionInfo.DestroyerKingdomName + " (string_id: \"" + destructionInfo.DestroyerKingdomId + "\")");
			stringBuilder.AppendLine("METHOD: " + destructionInfo.Method);
			if (!string.IsNullOrEmpty(destructionInfo.LastCapturedSettlementName))
			{
				stringBuilder.AppendLine("LAST SETTLEMENT CAPTURED: " + destructionInfo.LastCapturedSettlementName);
			}
		}
		else
		{
			stringBuilder.AppendLine("DESTRUCTION METHOD: " + destructionInfo.Method + " (no clear conqueror)");
		}
		if (destructionInfo.CurrentWar != null && !string.IsNullOrEmpty(destructionInfo.DestroyerKingdomId) && destructionInfo.DestroyerKingdomId != "unknown")
		{
			stringBuilder.AppendLine("## CURRENT WAR (THE WAR IN WHICH KINGDOM WAS DESTROYED):");
			stringBuilder.AppendLine("War against: " + destructionInfo.DestroyerKingdomName + " (string_id: \"" + destructionInfo.DestroyerKingdomId + "\")");
			stringBuilder.AppendLine($"War duration: {destructionInfo.CurrentWar.DurationDays} days");
			stringBuilder.AppendLine($"Casualties in this war: {destructionInfo.DestroyedKingdomName} lost {destructionInfo.CurrentWar.DestroyedKingdomCasualties} troops, {destructionInfo.DestroyerKingdomName} lost {destructionInfo.CurrentWar.DestroyerKingdomCasualties} troops");
			stringBuilder.AppendLine();
		}
		if (destructionInfo.DestroyedKingdomAllies.Any() || destructionInfo.DestroyerKingdomAllies.Any())
		{
			stringBuilder.AppendLine("## ALLIES IN THE WAR:");
			if (destructionInfo.DestroyedKingdomAllies.Any())
			{
				List<string> values = destructionInfo.DestroyedKingdomAllies.Select(delegate(string id)
				{
					Kingdom? obj = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == id && !k.IsEliminated));
					return ((obj == null) ? null : ((object)obj.Name)?.ToString()) ?? id;
				}).ToList();
				stringBuilder.AppendLine(destructionInfo.DestroyedKingdomName + " allies: " + string.Join(", ", values) + " (string_ids: [" + string.Join(", ", destructionInfo.DestroyedKingdomAllies.Select((string id) => "\"" + id + "\"")) + "])");
			}
			else
			{
				stringBuilder.AppendLine(destructionInfo.DestroyedKingdomName + " had no allies");
			}
			if (destructionInfo.DestroyerKingdomAllies.Any())
			{
				List<string> values2 = destructionInfo.DestroyerKingdomAllies.Select(delegate(string id)
				{
					Kingdom? obj = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == id && !k.IsEliminated));
					return ((obj == null) ? null : ((object)obj.Name)?.ToString()) ?? id;
				}).ToList();
				stringBuilder.AppendLine(destructionInfo.DestroyerKingdomName + " allies: " + string.Join(", ", values2) + " (string_ids: [" + string.Join(", ", destructionInfo.DestroyerKingdomAllies.Select((string id) => "\"" + id + "\"")) + "])");
			}
			else
			{
				stringBuilder.AppendLine(destructionInfo.DestroyerKingdomName + " had no allies");
			}
			stringBuilder.AppendLine();
		}
		if (destructionInfo.WarLosses != null)
		{
			stringBuilder.AppendLine("## WAR LOSSES:");
			stringBuilder.AppendLine(destructionInfo.DestroyedKingdomName + " losses:");
			stringBuilder.AppendLine($"  - Total casualties: {destructionInfo.WarLosses.DestroyedKingdomTroopsLost}");
			stringBuilder.AppendLine($"  - Casualties in this war: {destructionInfo.WarLosses.DestroyedKingdomCasualtiesInThisWar}");
			stringBuilder.AppendLine($"  - Lords captured: {destructionInfo.WarLosses.DestroyedKingdomLordsCaptured}");
			stringBuilder.AppendLine($"  - Lords killed: {destructionInfo.WarLosses.DestroyedKingdomLordsKilled}");
			stringBuilder.AppendLine($"  - Settlements lost: {destructionInfo.WarLosses.DestroyedKingdomSettlementsLost}");
			stringBuilder.AppendLine($"  - Caravans destroyed: {destructionInfo.WarLosses.DestroyedKingdomCaravansDestroyed}");
			stringBuilder.AppendLine($"  - War fatigue: {destructionInfo.WarLosses.DestroyedKingdomWarFatigue:F1}%");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(destructionInfo.DestroyerKingdomName + " losses:");
			stringBuilder.AppendLine($"  - Total casualties: {destructionInfo.WarLosses.DestroyerKingdomTroopsLost}");
			stringBuilder.AppendLine($"  - Casualties in this war: {destructionInfo.WarLosses.DestroyerKingdomCasualtiesInThisWar}");
			stringBuilder.AppendLine($"  - Lords captured: {destructionInfo.WarLosses.DestroyerKingdomLordsCaptured}");
			stringBuilder.AppendLine($"  - Lords killed: {destructionInfo.WarLosses.DestroyerKingdomLordsKilled}");
			stringBuilder.AppendLine($"  - Settlements lost: {destructionInfo.WarLosses.DestroyerKingdomSettlementsLost}");
			stringBuilder.AppendLine($"  - Caravans destroyed: {destructionInfo.WarLosses.DestroyerKingdomCaravansDestroyed}");
			stringBuilder.AppendLine($"  - War fatigue: {destructionInfo.WarLosses.DestroyerKingdomWarFatigue:F1}%");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("## ALL WARS AT TIME OF DESTRUCTION (for context):");
		if (destructionInfo.WarsInvolved.Any())
		{
			foreach (WarInfo item in destructionInfo.WarsInvolved)
			{
				string text3 = ((item.DurationDays == 0) ? "just started" : $"{item.DurationDays} days");
				stringBuilder.AppendLine("- At war with " + item.EnemyKingdomName + " (string_id: \"" + item.EnemyKingdomId + "\") for " + text3);
			}
		}
		else
		{
			stringBuilder.AppendLine("- No active wars at time of destruction");
		}
		stringBuilder.AppendLine();
		if (destructionInfo.PlayerInvolved)
		{
			stringBuilder.AppendLine("PLAYER INVOLVEMENT: The player (main_hero) was involved in this kingdom's destruction.");
			stringBuilder.AppendLine("This could mean the player was leading the conquering kingdom, was besieging settlements, or participated in battles.");
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("## EVENT STRUCTURE:");
		stringBuilder.AppendLine("MUST include: 1) CAUSE (why/how kingdom was destroyed) 2) IMMEDIATE CONSEQUENCES 3) LONG-TERM IMPACT");
		stringBuilder.AppendLine("Prefer realistic consequences: refugee crises, power vacuums, territorial disputes.");
		stringBuilder.AppendLine("Avoid clichés, be specific and grounded in the provided data.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## FIELDS:");
		stringBuilder.AppendLine("type: political (kingdom destruction is always a political event)");
		stringBuilder.AppendLine("importance: 8-10 (kingdom destruction is major event)");
		stringBuilder.AppendLine("kingdoms_involved: string_id [] or \"all\" (null is FORBIDDEN - use array of surviving kingdoms affected by this destruction, or \"all\" if all kingdoms are affected)");
		stringBuilder.AppendLine("allows_diplomatic_response: true (kingdom destruction requires diplomatic handling)");
		stringBuilder.AppendLine("**CRITICAL:** kingdoms_involved CANNOT be null. Use array of string_ids for specific kingdoms, or \"all\" for global impact.");
		if (destructionInfo.PlayerInvolved)
		{
			stringBuilder.AppendLine("player_involved: MUST be true (player was involved in the destruction)");
		}
		else
		{
			stringBuilder.AppendLine("player_involved: false (player was not involved)");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## OUTPUT FORMAT (STRICT JSON):");
		stringBuilder.AppendLine("```json");
		stringBuilder.AppendLine("{");
		if (GlobalSettings<ModSettings>.Instance.EnableDynamicEventsInternalThoughts)
		{
			stringBuilder.AppendLine("  \"internal_thoughts\": \"FACT CHECK: [Kingdom] destroyed by [Destroyer]. REASONING: Political consequences include...\",");
		}
		stringBuilder.AppendLine("  \"events\": [");
		stringBuilder.AppendLine("    {");
		stringBuilder.AppendLine("      \"type\": \"political\",");
		stringBuilder.AppendLine("      \"title\": \"Fall of [Kingdom Name]\",");
		stringBuilder.AppendLine("      \"description\": \"Detailed description of the kingdom's destruction and its consequences\",");
		stringBuilder.AppendLine("      \"player_involved\": " + (destructionInfo.PlayerInvolved ? "true" : "false") + ",");
		stringBuilder.AppendLine("      \"kingdoms_involved\": [\"empire\", \"vlandia\"],");
		stringBuilder.AppendLine("      \"characters_involved\": [],");
		stringBuilder.AppendLine("      \"importance\": 9,");
		stringBuilder.AppendLine("      \"spread_speed\": \"fast\",");
		stringBuilder.AppendLine("      \"allows_diplomatic_response\": true");
		stringBuilder.AppendLine("    }");
		stringBuilder.AppendLine("  ]");
		stringBuilder.AppendLine("}");
		stringBuilder.AppendLine("```");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## CURRENT WORLD STATE:");
		stringBuilder.AppendLine(worldData);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("## EXISTING EVENTS:");
		stringBuilder.AppendLine(existingEvents);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(diplomaticStatements);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("TASK: Create ONE POLITICAL event about the destruction of this kingdom and its POLITICAL consequences.");
		stringBuilder.AppendLine("Focus on how the POLITICAL landscape changes now that " + destructionInfo.DestroyedKingdomName + " is gone.");
		stringBuilder.AppendLine("Consider power vacuums, alliances, territorial claims, and diplomatic realignments.");
		stringBuilder.AppendLine("Generate the kingdom destruction event NOW (JSON only):");
		return stringBuilder.ToString();
	}
}
