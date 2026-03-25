using System.Collections.Generic;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class EventUpdate
{
	[JsonProperty("campaign_days")]
	public float CampaignDays { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; }

	[JsonProperty("update_reason")]
	public string UpdateReason { get; set; }

	[JsonProperty("days_since_creation")]
	public int DaysSinceCreation { get; set; }

	[JsonProperty("economic_effects")]
	public List<EconomicEffect> EconomicEffects { get; set; } = new List<EconomicEffect>();

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

	public EventUpdate()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime now = CampaignTime.Now;
		CampaignDays = (float)(now).ToDays;
		UpdateReason = "Event Update";
		EconomicEffects = new List<EconomicEffect>();
	}

	public EventUpdate(string description, string updateReason = "Event Update")
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime now = CampaignTime.Now;
		CampaignDays = (float)(now).ToDays;
		Description = description;
		UpdateReason = updateReason;
		EconomicEffects = new List<EconomicEffect>();
	}
}
