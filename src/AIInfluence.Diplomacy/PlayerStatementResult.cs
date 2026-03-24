using System.Collections.Generic;
using System.Linq;
using AIInfluence.DynamicEvents;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class PlayerStatementResult
{
	public DiplomaticAction Action { get; set; }

	public List<DiplomaticAction> Actions { get; set; } = new List<DiplomaticAction>();

	public List<string> TargetKingdomIds { get; set; } = new List<string>();

	public string TargetKingdomId => TargetKingdomIds.FirstOrDefault();

	public Kingdom TargetKingdom => TargetKingdoms.FirstOrDefault();

	public List<Kingdom> TargetKingdoms { get; set; } = new List<Kingdom>();

	public string Tone { get; set; }

	public string Reason { get; set; }

	public string SettlementId { get; set; }

	public int DailyTributeAmount { get; set; }

	public int TributeDurationDays { get; set; }

	public int ReparationsAmount { get; set; }

	public float TradeAgreementDurationYears { get; set; } = 1f;
}
