using System.Collections.Generic;
using System.Linq;
using AIInfluence.DynamicEvents;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class DelayedPlayerStatement
{
	public string StatementText { get; set; }

	public DiplomaticAction Action { get; set; } = DiplomaticAction.None;

	public List<DiplomaticAction> Actions { get; set; } = new List<DiplomaticAction>();

	public List<string> TargetKingdomIds { get; set; } = new List<string>();

	public string TargetClanId { get; set; }

	public string TargetKingdomId => TargetKingdomIds.FirstOrDefault();

	public string Reason { get; set; }

	public string Tone { get; set; }

	public Kingdom PlayerKingdom { get; set; }

	public CampaignTime PublicationTime { get; set; }

	public string SettlementId { get; set; }

	public int DailyTributeAmount { get; set; }

	public int TributeDurationDays { get; set; }

	public int ReparationsAmount { get; set; }

	public float TradeAgreementDurationYears { get; set; } = 1f;

	public int QuarantineDurationDays { get; set; }

	public string NewKingdomName { get; set; }

	public string NewKingdomInformalName { get; set; }
}
