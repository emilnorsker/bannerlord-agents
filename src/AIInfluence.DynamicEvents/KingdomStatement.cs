using System.Collections.Generic;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class KingdomStatement
{
	[JsonProperty("kingdom_id")]
	public string KingdomId { get; set; }

	[JsonProperty("statement_text")]
	public string StatementText { get; set; }

	[JsonProperty("action")]
	public DiplomaticAction Action { get; set; } = DiplomaticAction.None;

	[JsonProperty("actions")]
	public List<DiplomaticAction> Actions { get; set; } = new List<DiplomaticAction>();

	[JsonProperty("target_kingdom_id")]
	public string TargetKingdomId { get; set; }

	[JsonProperty("target_kingdom_ids")]
	public List<string> TargetKingdomIds { get; set; } = new List<string>();

	[JsonProperty("target_clan_id")]
	public string TargetClanId { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }

	[JsonProperty("campaign_days")]
	public float CampaignDays { get; set; }

	[JsonIgnore]
	public CampaignTime Timestamp
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			float campaignDays = CampaignDays;
			CampaignTime now = CampaignTime.Now;
			return CampaignTime.DaysFromNow(campaignDays - (float)(now).ToDays);
		}
		set
		{
			CampaignDays = (float)(value).ToDays;
		}
	}

	[JsonProperty("event_id")]
	public string EventId { get; set; }

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

	[JsonProperty("new_kingdom_name")]
	public string NewKingdomName { get; set; }

	[JsonProperty("new_kingdom_informal_name")]
	public string NewKingdomInformalName { get; set; }
}
