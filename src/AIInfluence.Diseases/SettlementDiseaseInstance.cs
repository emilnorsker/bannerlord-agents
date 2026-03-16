using System;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diseases;

[JsonSerializable]
public class SettlementDiseaseInstance
{
	[JsonProperty("settlement_id")]
	public string SettlementId { get; set; }

	[JsonProperty("disease_id")]
	public string DiseaseId { get; set; }

	[JsonProperty("target_type")]
	public string TargetType { get; set; }

	[JsonProperty("infection_progress")]
	public float InfectionProgress { get; set; }

	[JsonProperty("infected_percentage")]
	public float InfectedPercentage { get; set; }

	[JsonProperty("infected_count")]
	public int InfectedCount { get; set; }

	[JsonProperty("average_progress")]
	public float AverageProgress { get; set; }

	[JsonProperty("start_days")]
	public float StartDays { get; set; }

	[JsonProperty("end_days")]
	public float? EndDays { get; set; }

	[JsonProperty("last_auto_treatment_days")]
	public float LastAutoTreatmentDays { get; set; }

	[JsonProperty("is_treated")]
	public bool IsTreated { get; set; }

	[JsonIgnore]
	public CampaignTime StartTime
	{
		get
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			float startDays = StartDays;
			CampaignTime now = CampaignTime.Now;
			float num = startDays - (float)(now).ToDays;
			return CampaignTime.DaysFromNow(num);
		}
		set
		{
			StartDays = (float)(value).ToDays;
		}
	}

	[JsonIgnore]
	public CampaignTime? EndTime
	{
		get
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			if (!EndDays.HasValue)
			{
				return null;
			}
			float value = EndDays.Value;
			CampaignTime now = CampaignTime.Now;
			float num = value - (float)(now).ToDays;
			return CampaignTime.DaysFromNow(num);
		}
		set
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			float? endDays;
			if (!value.HasValue)
			{
				endDays = null;
			}
			else
			{
				CampaignTime value2 = value.Value;
				endDays = (float)(value2).ToDays;
			}
			EndDays = endDays;
		}
	}

	[JsonIgnore]
	public CampaignTime LastAutoTreatmentTime
	{
		get
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			float lastAutoTreatmentDays = LastAutoTreatmentDays;
			CampaignTime now = CampaignTime.Now;
			float num = lastAutoTreatmentDays - (float)(now).ToDays;
			return CampaignTime.DaysFromNow(num);
		}
		set
		{
			LastAutoTreatmentDays = (float)(value).ToDays;
		}
	}

	[JsonIgnore]
	public int DaysSinceStart
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			_ = CampaignTime.Now;
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			return Math.Max(0, (int)(num - StartDays));
		}
	}

	[JsonIgnore]
	public int DaysSinceLastAutoTreatment
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			_ = CampaignTime.Now;
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			return Math.Max(0, (int)(num - LastAutoTreatmentDays));
		}
	}

	public SettlementDiseaseInstance()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		_ = CampaignTime.Now;
		if (true)
		{
			CampaignTime now = CampaignTime.Now;
			StartDays = (float)(now).ToDays;
			LastAutoTreatmentDays = StartDays;
		}
	}

	public bool NeedsAutoTreatment()
	{
		return DaysSinceLastAutoTreatment >= 4;
	}

	public void MarkAutoTreatmentDone()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_ = CampaignTime.Now;
		if (true)
		{
			CampaignTime now = CampaignTime.Now;
			LastAutoTreatmentDays = (float)(now).ToDays;
		}
	}

	public void MarkRecovered()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_ = CampaignTime.Now;
		if (true)
		{
			CampaignTime now = CampaignTime.Now;
			EndDays = (float)(now).ToDays;
		}
		InfectionProgress = 0f;
		InfectedPercentage = 0f;
		InfectedCount = 0;
	}

	public bool IsRecovered()
	{
		return EndDays.HasValue || InfectionProgress <= 0f;
	}

	public float GetInfectionRate(float totalCount)
	{
		if (totalCount <= 0f)
		{
			return 0f;
		}
		if (TargetType == "militia")
		{
			return InfectedPercentage;
		}
		return (float)InfectedCount / totalCount * 100f;
	}

	public int CalculateInfectedMilitiaCount(float totalMilitia)
	{
		if (TargetType != "militia")
		{
			return 0;
		}
		return (int)(totalMilitia * InfectedPercentage / 100f);
	}

	public void UpdateMilitiaInfectedCount(float totalMilitia)
	{
		if (TargetType == "militia")
		{
			InfectedCount = CalculateInfectedMilitiaCount(totalMilitia);
		}
	}
}
