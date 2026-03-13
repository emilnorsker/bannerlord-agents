using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIInfluence.Diplomacy;
using AIInfluence.DynamicEvents;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence.SettlementCombat;

public class PostCombatEventCreator
{
	private readonly AIInfluenceBehavior _behavior;

	private readonly SettlementCombatLogger _logger;

	public PostCombatEventCreator(AIInfluenceBehavior behavior)
	{
		_behavior = behavior;
		_logger = SettlementCombatLogger.Instance;
	}

	public void CreatePostCombatEvent(string aiResponse, Settlement settlement, CombatResult combatResult = null)
	{
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			_behavior.LogMessage("[POST_COMBAT_EVENT] Parsing AI response to create dynamic event");
			DynamicEvent dynamicEvent = ParseAIResponse(aiResponse);
			if (dynamicEvent == null)
			{
				_logger.LogError("CreatePostCombatEvent", "Failed to parse AI response");
				_behavior.LogMessage("[POST_COMBAT_EVENT] ERROR: Could not parse AI response");
				return;
			}
			if (combatResult != null && combatResult.PlayerCaptured)
			{
				dynamicEvent.PlayerInvolved = true;
			}
			if (combatResult != null && combatResult.CapturedHeroes != null && combatResult.CapturedHeroes.Count > 0)
			{
				if (dynamicEvent.CharactersInvolved == null)
				{
					dynamicEvent.CharactersInvolved = new List<string>();
				}
				foreach (string capturedHero in combatResult.CapturedHeroes)
				{
					if (!string.IsNullOrEmpty(capturedHero) && !dynamicEvent.CharactersInvolved.Contains(capturedHero))
					{
						dynamicEvent.CharactersInvolved.Add(capturedHero);
					}
				}
			}
			dynamicEvent.CreationTime = DateTime.Now;
			CampaignTime now = CampaignTime.Now;
			dynamicEvent.CreationCampaignDays = (float)((CampaignTime)(ref now)).ToDays;
			dynamicEvent.ExpirationCampaignDays = dynamicEvent.CreationCampaignDays + (float)GlobalSettings<ModSettings>.Instance.DynamicEventsLifespan;
			dynamicEvent.ExpirationTime = DateTime.Now.AddDays(GlobalSettings<ModSettings>.Instance.DynamicEventsLifespan);
			if (dynamicEvent.EventHistory == null)
			{
				dynamicEvent.EventHistory = new List<EventUpdate>();
			}
			if (!dynamicEvent.EventHistory.Any())
			{
				dynamicEvent.AddEventUpdate(dynamicEvent.Description, "Combat Aftermath");
			}
			DynamicEventsManager.Instance.AddEvent(dynamicEvent);
			_logger.LogDynamicEventCreated(dynamicEvent.Id, dynamicEvent.Description, "combat");
			_behavior.LogMessage("[POST_COMBAT_EVENT] Dynamic event created: " + dynamicEvent.Id);
			CheckAndProcessDiplomaticResponse(dynamicEvent);
			ApplySettlementPenalty(dynamicEvent, settlement);
			SpreadEventToNPCs(dynamicEvent);
		}
		catch (Exception ex)
		{
			_logger.LogError("PostCombatEventCreator.CreatePostCombatEvent", ex.Message, ex);
			_behavior.LogMessage("[POST_COMBAT_EVENT] ERROR creating event: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private DynamicEvent ParseAIResponse(string aiResponse)
	{
		try
		{
			string text = aiResponse?.Trim() ?? "";
			if (text.StartsWith("```json"))
			{
				text = text.Substring(7);
			}
			else if (text.StartsWith("```"))
			{
				text = text.Substring(3);
			}
			if (text.EndsWith("```"))
			{
				text = text.Substring(0, text.Length - 3);
			}
			text = text.Trim();
			return JsonConvert.DeserializeObject<DynamicEvent>(text);
		}
		catch (Exception ex)
		{
			_logger.LogError("ParseAIResponse", "Failed to parse: " + ex.Message, ex);
			_behavior.LogMessage("[POST_COMBAT_EVENT] Parse error: " + ex.Message);
			_behavior.LogMessage("[POST_COMBAT_EVENT] Raw response: " + aiResponse);
			return null;
		}
	}

	private void SpreadEventToNPCs(DynamicEvent dynamicEvent)
	{
		try
		{
			_behavior.LogMessage("[POST_COMBAT_EVENT] Event will be spread to NPCs matching: " + string.Join(", ", dynamicEvent.ApplicableNPCs));
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[POST_COMBAT_EVENT] ERROR in SpreadEventToNPCs: " + ex.Message);
		}
	}

	private void ApplySettlementPenalty(DynamicEvent dynamicEvent, Settlement settlement)
	{
		try
		{
			if (dynamicEvent.SettlementPenalty == null)
			{
				_behavior.LogMessage("[POST_COMBAT_EVENT] No settlement penalty specified by AI");
				return;
			}
			SettlementPenaltyData settlementPenalty = dynamicEvent.SettlementPenalty;
			if (settlementPenalty.ProsperityPenaltyPerDay <= 0f)
			{
				_logger.LogError("ApplySettlementPenalty", $"Invalid penalty per day: {settlementPenalty.ProsperityPenaltyPerDay} (must be > 0)");
			}
			else if (settlementPenalty.PenaltyDurationDays < 1)
			{
				_logger.LogError("ApplySettlementPenalty", $"Invalid penalty duration: {settlementPenalty.PenaltyDurationDays} (must be >= 1)");
			}
			else if (settlement != null && SettlementPenaltyManager.Instance != null)
			{
				SettlementPenaltyManager.Instance.AddPenalty(settlement, settlementPenalty.ProsperityPenaltyPerDay, settlementPenalty.PenaltyDurationDays, settlementPenalty.PenaltyReason ?? "Unknown");
				_behavior.LogMessage($"[POST_COMBAT_EVENT] Penalty applied to {settlement.Name}: -{settlementPenalty.ProsperityPenaltyPerDay}/day for {settlementPenalty.PenaltyDurationDays} days. Reason: {settlementPenalty.PenaltyReason}");
			}
			else
			{
				_logger.LogError("ApplySettlementPenalty", $"Settlement ({((settlement != null) ? settlement.Name : null)}) or PenaltyManager ({SettlementPenaltyManager.Instance}) is null");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("ApplySettlementPenalty", ex.Message, ex);
			_behavior.LogMessage("[POST_COMBAT_EVENT] ERROR applying penalty: " + ex.Message);
		}
	}

	private void CheckAndProcessDiplomaticResponse(DynamicEvent dynamicEvent)
	{
		try
		{
			DiplomacyLogger.Instance?.Log("Checking diplomatic response for event " + dynamicEvent.Id);
			DiplomacyLogger.Instance?.Log($"AllowsDiplomaticResponse = {dynamicEvent.AllowsDiplomaticResponse}");
			DiplomacyLogger.Instance?.Log($"EnableDiplomacy = {GlobalSettings<ModSettings>.Instance.EnableDiplomacy}");
			if (!dynamicEvent.AllowsDiplomaticResponse || !GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return;
			}
			List<string> kingdomStringIds = dynamicEvent.GetKingdomStringIds();
			if (!kingdomStringIds.Any() || !(kingdomStringIds[0] != "all"))
			{
				return;
			}
			List<string> list = kingdomStringIds.Where((string k) => k != "all").ToList();
			if (list.Count >= 1)
			{
				dynamicEvent.ParticipatingKingdoms = list;
				dynamicEvent.RequiresDiplomaticAnalysis = true;
				bool flag = DiplomacyManager.Instance?.HasActiveDiplomaticEvents() ?? false;
				bool flag2 = DynamicEventsManager.Instance.GetActiveEvents().Any((DynamicEvent e) => e.AllowsDiplomaticResponse && e.RequiresDiplomaticAnalysis && e.Id != dynamicEvent.Id);
				if (flag || flag2)
				{
					DiplomacyLogger.Instance?.Log("Queuing diplomatic response for event " + dynamicEvent.Id + ": Active diplomatic event already exists");
					_behavior.LogMessage("[POST_COMBAT_EVENT] Diplomatic response queued - active diplomatic event already exists");
					DiplomacyManager.Instance?.QueueDiplomaticEvent(dynamicEvent);
				}
				else
				{
					DiplomacyLogger.Instance?.Log("Event " + dynamicEvent.Id + " created diplomatic situation involving " + string.Join(", ", list));
					ProcessDiplomaticEventAsync(dynamicEvent);
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("CheckAndProcessDiplomaticResponse", ex.Message, ex);
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
			DiplomacyLogger.Instance?.LogError("PostCombatEventCreator.ProcessDiplomaticEventAsync", "Failed to process diplomatic event " + diplomaticEvent.Id, ex2);
		}
	}
}
