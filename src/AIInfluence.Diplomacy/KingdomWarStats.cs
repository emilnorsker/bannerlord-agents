using System.Collections.Generic;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

[JsonSerializable]
public class KingdomWarStats
{
	[JsonProperty("kingdom_id")]
	public string KingdomId { get; set; }

	[JsonProperty("initial_troops")]
	public int InitialTroops { get; set; }

	[JsonProperty("current_troops")]
	public int CurrentTroops { get; set; }

	[JsonProperty("previous_troops")]
	public int PreviousTroops { get; set; }

	[JsonProperty("total_casualties")]
	public int TotalCasualties { get; set; }

	[JsonProperty("previous_casualties")]
	public int PreviousCasualties { get; set; }

	[JsonProperty("total_lords_captured")]
	public int TotalLordsCaptured { get; set; }

	[JsonProperty("total_lords_killed")]
	public int TotalLordsKilled { get; set; }

	[JsonProperty("total_settlements_lost")]
	public int TotalSettlementsLost { get; set; }

	[JsonProperty("total_caravans_destroyed")]
	public int TotalCaravansDestroyed { get; set; }

	[JsonProperty("days_at_war")]
	public int DaysAtWar { get; set; }

	[JsonProperty("initial_settlements")]
	public int InitialSettlements { get; set; }

	[JsonProperty("current_settlements")]
	public int CurrentSettlements { get; set; }

	[JsonProperty("war_fatigue")]
	public float WarFatigue { get; set; }

	[JsonProperty("base_fatigue")]
	public float BaseFatigue { get; set; }

	[JsonProperty("stats_history")]
	public List<WarStatsSnapshot> StatsHistory { get; set; } = new List<WarStatsSnapshot>();

	[JsonProperty("wars_against_kingdoms")]
	public Dictionary<string, WarStatsAgainstKingdom> WarsAgainstKingdoms { get; set; } = new Dictionary<string, WarStatsAgainstKingdom>();

	[JsonProperty("last_update_time_days")]
	public float LastUpdateTimeDays { get; set; }

	[JsonIgnore]
	public CampaignTime LastUpdateTime
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
			if (LastUpdateTimeDays > 0f)
			{
				_ = CampaignTime.Now;
				if (true)
				{
					CampaignTime now = CampaignTime.Now;
					float num = (float)((CampaignTime)(ref now)).ToDays;
					float num2 = num - LastUpdateTimeDays;
					return CampaignTime.DaysFromNow(0f - num2);
				}
			}
			return CampaignTime.Now;
		}
		set
		{
			bool flag = true;
			LastUpdateTimeDays = (float)((CampaignTime)(ref value)).ToDays;
		}
	}

	[JsonProperty("diplomatic_reasons")]
	public Dictionary<string, DiplomaticReason> DiplomaticReasons { get; set; } = new Dictionary<string, DiplomaticReason>();
}
