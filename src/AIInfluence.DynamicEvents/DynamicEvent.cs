using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class DynamicEvent
{
	[JsonProperty("id")]
	public string Id { get; set; }

	[JsonProperty("type")]
	public string Type { get; set; }

	[JsonProperty("title")]
	public string Title { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; }

	[JsonProperty("event_history")]
	public List<EventUpdate> EventHistory { get; set; } = new List<EventUpdate>();

	[JsonProperty("player_involved")]
	public bool PlayerInvolved { get; set; }

	[JsonProperty("kingdoms_involved")]
	public object KingdomsInvolved { get; set; }

	[JsonProperty("characters_involved")]
	public List<string> CharactersInvolved { get; set; } = new List<string>();

	[JsonProperty("importance")]
	public int Importance { get; set; }

	[JsonProperty("plot_id")]
	public string PlotId { get; set; }

	[JsonProperty("storage_tags")]
	public List<string> StorageTags { get; set; }

	[JsonProperty("spread_speed")]
	public string SpreadSpeed { get; set; }

	[JsonProperty("allows_diplomatic_response")]
	public bool AllowsDiplomaticResponse { get; set; }

	[JsonProperty("applicable_npcs")]
	public List<string> ApplicableNPCs { get; set; } = new List<string>();

	[JsonProperty("settlement_penalty")]
	public SettlementPenaltyData SettlementPenalty { get; set; }

	[JsonProperty("economic_effects")]
	public List<EconomicEffect> EconomicEffects { get; set; } = new List<EconomicEffect>();

	[JsonProperty("creation_time")]
	public DateTime CreationTime { get; set; }

	[JsonProperty("creation_campaign_days")]
	public float CreationCampaignDays { get; set; }

	[JsonProperty("expiration_time")]
	public DateTime ExpirationTime { get; set; }

	[JsonProperty("expiration_campaign_days")]
	public float ExpirationCampaignDays { get; set; }

	[JsonIgnore]
	public int DaysSinceCreation
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			_ = CampaignTime.Now;
			if (false)
			{
				return 0;
			}
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			float num2 = num - CreationCampaignDays;
			DynamicEventsLogger.Instance?.Log($"[DEBUG] DaysSinceCreation: CurrentDays={num:F1}, CreationDays={CreationCampaignDays:F1}, Age={num2:F1} days");
			return Math.Max(0, (int)num2);
		}
	}

	[JsonProperty("participating_kingdoms")]
	public List<string> ParticipatingKingdoms { get; set; } = new List<string>();

	[JsonProperty("kingdom_statements")]
	public List<KingdomStatement> KingdomStatements { get; set; } = new List<KingdomStatement>();

	[JsonProperty("requires_diplomatic_analysis")]
	public bool RequiresDiplomaticAnalysis { get; set; }

	[JsonProperty("diplomatic_rounds")]
	public int DiplomaticRounds { get; set; } = 0;

	[JsonProperty("statements_at_round_start")]
	public int StatementsAtRoundStart { get; set; } = 0;

	[JsonIgnore]
	public DiplomaticAnalysisResult LastAnalysisResult { get; set; }

	[JsonProperty("next_analysis_attempt_days")]
	public float NextAnalysisAttemptDays { get; set; } = 0f;

	[JsonProperty("next_statement_attempt_days")]
	public Dictionary<string, float> NextStatementAttemptDays { get; set; } = new Dictionary<string, float>();

	[JsonProperty("failed_statement_attempts")]
	public Dictionary<string, int> FailedStatementAttempts { get; set; } = new Dictionary<string, int>();

	[JsonProperty("disease_data")]
	public DiseaseEventData DiseaseData { get; set; }

	[JsonIgnore]
	public bool IsDiseaseEvent => Type == "disease_outbreak" && DiseaseData != null;

	public DynamicEvent()
	{
		Id = Guid.NewGuid().ToString();
		CreationTime = DateTime.Now;
		Type = "news";
		Title = string.Empty;
		Importance = 5;
		SpreadSpeed = "normal";
		PlayerInvolved = false;
		AllowsDiplomaticResponse = true;
		EventHistory = new List<EventUpdate>();
	}

	public bool IsExpired()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		_ = CampaignTime.Now;
		if (false)
		{
			return false;
		}
		CampaignTime now = CampaignTime.Now;
		float num = (float)(now).ToDays;
		int num2 = GlobalSettings<ModSettings>.Instance?.DynamicEventsLifespan ?? 100;
		float num3 = CreationCampaignDays + (float)num2;
		return num > ExpirationCampaignDays || num > num3;
	}

	public void AddEventUpdate(string newDescription, string updateReason = "Event Update", List<EconomicEffect> economicEffects = null, DiseaseEventData diseaseData = null)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (EventHistory == null)
		{
			EventHistory = new List<EventUpdate>();
		}
		CampaignTime now = CampaignTime.Now;
		float num = (float)(now).ToDays;
		int daysSinceCreation = Math.Max(0, (int)(num - CreationCampaignDays));
		EventUpdate item = new EventUpdate(newDescription, updateReason)
		{
			DaysSinceCreation = daysSinceCreation,
			EconomicEffects = (economicEffects ?? new List<EconomicEffect>()),
			DiseaseData = diseaseData
		};
		EventHistory.Add(item);
		Description = newDescription;
	}

	public string GetEventHistoryForPrompt()
	{
		if (EventHistory == null || EventHistory.Count <= 1)
		{
			return Description;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("**EVENT EVOLUTION:**");
		stringBuilder.AppendLine();
		List<EventUpdate> list = EventHistory.OrderBy((EventUpdate u) => u.CampaignDays).ToList();
		for (int num = 0; num < list.Count; num++)
		{
			EventUpdate eventUpdate = list[num];
			stringBuilder.AppendLine($"**Day {eventUpdate.DaysSinceCreation}** ({eventUpdate.UpdateReason}):");
			stringBuilder.AppendLine(eventUpdate.Description);
			if (num < list.Count - 1)
			{
				stringBuilder.AppendLine();
			}
		}
		return stringBuilder.ToString();
	}

	public List<string> GetKingdomStringIds()
	{
		if (KingdomsInvolved == null)
		{
			return new List<string>();
		}
		if (KingdomsInvolved is string text && text == "all")
		{
			return new List<string> { "all" };
		}
		if (KingdomsInvolved is List<string> result)
		{
			return result;
		}
		object kingdomsInvolved = KingdomsInvolved;
		JArray val = (JArray)((kingdomsInvolved is JArray) ? kingdomsInvolved : null);
		if (val != null)
		{
			return ((JToken)val).ToObject<List<string>>();
		}
		return new List<string>();
	}

	public bool IsKingdomInvolved(string kingdomStringId)
	{
		if (KingdomsInvolved == null)
		{
			return false;
		}
		if (KingdomsInvolved is string text && text == "all")
		{
			return true;
		}
		List<string> kingdomStringIds = GetKingdomStringIds();
		return kingdomStringIds.Contains(kingdomStringId);
	}

	public string GetDescriptionWithAge()
	{
		return $"{Description} ({DaysSinceCreation} days ago)";
	}

	public bool IsReadyForAnalysis()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		_ = CampaignTime.Now;
		if (false)
		{
			return true;
		}
		CampaignTime now = CampaignTime.Now;
		float num = (float)(now).ToDays;
		return num >= NextAnalysisAttemptDays;
	}

	public void SetAnalysisRetryDelay(int delayDays)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		_ = CampaignTime.Now;
		if (true)
		{
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			NextAnalysisAttemptDays = num + (float)delayDays;
		}
	}

	public bool IsKingdomReadyForStatement(string kingdomId)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		_ = CampaignTime.Now;
		if (false)
		{
			return true;
		}
		if (NextStatementAttemptDays.TryGetValue(kingdomId, out var value))
		{
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			return num >= value;
		}
		return true;
	}

	public void SetKingdomStatementRetryDelay(string kingdomId, int delayDays)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		_ = CampaignTime.Now;
		if (true)
		{
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			NextStatementAttemptDays[kingdomId] = num + (float)delayDays;
		}
	}

	public bool IncrementFailedStatementAttempt(string kingdomId)
	{
		if (!FailedStatementAttempts.ContainsKey(kingdomId))
		{
			FailedStatementAttempts[kingdomId] = 0;
		}
		FailedStatementAttempts[kingdomId]++;
		return FailedStatementAttempts[kingdomId] < 3;
	}

	public void ResetFailedStatementAttempt(string kingdomId)
	{
		FailedStatementAttempts.Remove(kingdomId);
	}
}
