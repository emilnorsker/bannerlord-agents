using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.DynamicEvents;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

[JsonSerializable]
public class SerializedPlayerStatement
{
	[JsonProperty("statement_text")]
	public string StatementText { get; set; }

	[JsonProperty("action")]
	public string Action { get; set; }

	[JsonProperty("actions")]
	public List<string> Actions { get; set; }

	[JsonProperty("target_kingdom_id")]
	public string TargetKingdomId { get; set; }

	[JsonProperty("target_kingdom_ids")]
	public List<string> TargetKingdomIds { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }

	[JsonProperty("tone")]
	public string Tone { get; set; }

	[JsonProperty("player_kingdom_id")]
	public string PlayerKingdomId { get; set; }

	[JsonProperty("publication_time_hours")]
	public float PublicationTimeHours { get; set; }

	[JsonProperty("settlement_id")]
	public string SettlementId { get; set; }

	[JsonProperty("daily_tribute_amount")]
	public int DailyTributeAmount { get; set; }

	[JsonProperty("tribute_duration_days")]
	public int TributeDurationDays { get; set; }

	[JsonProperty("reparations_amount")]
	public int ReparationsAmount { get; set; }

	[JsonProperty("trade_agreement_duration_years")]
	public float TradeAgreementDurationYears { get; set; } = 1f;

	[JsonProperty("quarantine_duration_days")]
	public int QuarantineDurationDays { get; set; }

	[JsonProperty("target_clan_id")]
	public string TargetClanId { get; set; }

	[JsonProperty("new_kingdom_name")]
	public string NewKingdomName { get; set; }

	[JsonProperty("new_kingdom_informal_name")]
	public string NewKingdomInformalName { get; set; }

	public static SerializedPlayerStatement FromDelayed(DelayedPlayerStatement delayed)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		SerializedPlayerStatement obj = new SerializedPlayerStatement
		{
			StatementText = delayed.StatementText,
			Action = delayed.Action.ToString(),
			Actions = (delayed.Actions?.Select((DiplomaticAction a) => a.ToString()).ToList() ?? new List<string> { delayed.Action.ToString() }),
			TargetKingdomId = delayed.TargetKingdomId,
			TargetKingdomIds = (delayed.TargetKingdomIds ?? new List<string>()),
			Reason = delayed.Reason,
			Tone = delayed.Tone
		};
		Kingdom playerKingdom = delayed.PlayerKingdom;
		obj.PlayerKingdomId = ((playerKingdom != null) ? ((MBObjectBase)playerKingdom).StringId : null);
		CampaignTime publicationTime = delayed.PublicationTime;
		obj.PublicationTimeHours = (float)(publicationTime).ToHours;
		obj.SettlementId = delayed.SettlementId;
		obj.DailyTributeAmount = delayed.DailyTributeAmount;
		obj.TributeDurationDays = delayed.TributeDurationDays;
		obj.ReparationsAmount = delayed.ReparationsAmount;
		obj.TradeAgreementDurationYears = delayed.TradeAgreementDurationYears;
		obj.QuarantineDurationDays = delayed.QuarantineDurationDays;
		SerializedPlayerStatement serializedPlayerStatement = obj;
		DiplomacyLogger instance = DiplomacyLogger.Instance;
		object[] array = new object[4];
		Kingdom playerKingdom2 = delayed.PlayerKingdom;
		array[0] = ((playerKingdom2 != null) ? playerKingdom2.Name : null);
		array[1] = string.Join(",", serializedPlayerStatement.Actions);
		array[2] = delayed.PublicationTime;
		array[3] = serializedPlayerStatement.PublicationTimeHours;
		instance.Log(string.Format("[SERIALIZED_STATEMENT] Converting to serialized: Kingdom={0}, Actions={1}, PublicationTime={2} -> {3} hours", array));
		return serializedPlayerStatement;
	}

	public DelayedPlayerStatement ToDelayed()
	{
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == PlayerKingdomId));
		if (val == null)
		{
			DiplomacyLogger.Instance.LogWarning("SerializedPlayerStatement.ToDelayed", "Failed to find kingdom with ID: " + PlayerKingdomId);
			return null;
		}
		List<DiplomaticAction> list = new List<DiplomaticAction>();
		if (Actions != null && Actions.Any())
		{
			foreach (string action in Actions)
			{
				if (Enum.TryParse<DiplomaticAction>(action, out var result))
				{
					list.Add(result);
				}
			}
		}
		if (!list.Any())
		{
			if (!Enum.TryParse<DiplomaticAction>(Action, out var result2))
			{
				DiplomacyLogger.Instance.LogWarning("SerializedPlayerStatement.ToDelayed", "Failed to parse action: " + Action);
				result2 = DiplomaticAction.None;
			}
			list.Add(result2);
		}
		List<string> targetKingdomIds = ((TargetKingdomIds != null && TargetKingdomIds.Any()) ? TargetKingdomIds : ((!string.IsNullOrEmpty(TargetKingdomId)) ? new List<string> { TargetKingdomId } : new List<string>()));
		CampaignTime val2 = CampaignTime.Hours(PublicationTimeHours);
		DiplomacyLogger.Instance.Log($"[SERIALIZED_STATEMENT] Converting {PublicationTimeHours} hours to CampaignTime: {val2}");
		return new DelayedPlayerStatement
		{
			StatementText = StatementText,
			Action = list.FirstOrDefault(),
			Actions = list,
			TargetKingdomIds = targetKingdomIds,
			Reason = Reason,
			Tone = Tone,
			PlayerKingdom = val,
			PublicationTime = val2,
			SettlementId = SettlementId,
			DailyTributeAmount = DailyTributeAmount,
			TributeDurationDays = TributeDurationDays,
			ReparationsAmount = ReparationsAmount,
			TradeAgreementDurationYears = TradeAgreementDurationYears,
			QuarantineDurationDays = QuarantineDurationDays
		};
	}
}
