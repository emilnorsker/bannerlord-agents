using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

[JsonSerializable]
public class DiplomaticReason
{
	[JsonProperty("action_type")]
	public string ActionType { get; set; }

	[JsonProperty("target_kingdom_id")]
	public string TargetKingdomId { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }

	[JsonProperty("timestamp_days")]
	public float TimestampDays { get; set; }

	[JsonIgnore]
	public CampaignTime Timestamp
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			if (TimestampDays > 0f)
			{
				_ = CampaignTime.Now;
				if (true)
				{
					CampaignTime now = CampaignTime.Now;
					float num = (float)(now).ToDays;
					float num2 = num - TimestampDays;
					return CampaignTime.DaysFromNow(0f - num2);
				}
			}
			return CampaignTime.Now;
		}
		set
		{
			bool flag = true;
			TimestampDays = (float)(value).ToDays;
		}
	}

	[JsonProperty("statement_text")]
	public string StatementText { get; set; }

	public DiplomaticReason()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		Timestamp = CampaignTime.Now;
	}

	public DiplomaticReason(string actionType, string targetKingdomId, string reason, string statementText)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		ActionType = actionType;
		TargetKingdomId = targetKingdomId;
		Reason = reason;
		StatementText = statementText;
		Timestamp = CampaignTime.Now;
	}
}
