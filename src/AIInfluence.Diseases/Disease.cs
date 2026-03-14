using System;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diseases;

[JsonSerializable]
public class Disease
{
	[JsonProperty("id")]
	public string Id { get; set; }

	[JsonProperty("settlement_id")]
	public string SettlementId { get; set; }

	[JsonProperty("severity")]
	public int Severity { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; }

	[JsonProperty("type")]
	public string Type { get; set; }

	[JsonProperty("effects")]
	public DiseaseEffects Effects { get; set; }

	[JsonProperty("spread_rate")]
	public float SpreadRate { get; set; }

	[JsonProperty("duration_days")]
	public int DurationDays { get; set; }

	[JsonProperty("created_at")]
	public float CreatedAt { get; set; }

	[JsonProperty("is_quarantined")]
	public bool IsQuarantined { get; set; }

	[JsonProperty("quarantine_end_days")]
	public float? QuarantineEndDays { get; set; }

	[JsonProperty("source_event_id")]
	public string SourceEventId { get; set; }

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
			return Math.Max(0, (int)(num - CreatedAt));
		}
	}

	[JsonIgnore]
	public CampaignTime? QuarantineEndTime
	{
		get
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			if (!QuarantineEndDays.HasValue)
			{
				return null;
			}
			float value = QuarantineEndDays.Value;
			CampaignTime now = CampaignTime.Now;
			float num = value - (float)(now).ToDays;
			return CampaignTime.DaysFromNow(num);
		}
		set
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			float? quarantineEndDays;
			if (!value.HasValue)
			{
				quarantineEndDays = null;
			}
			else
			{
				CampaignTime value2 = value.Value;
				quarantineEndDays = (float)(value2).ToDays;
			}
			QuarantineEndDays = quarantineEndDays;
		}
	}

	public Disease()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		Id = Guid.NewGuid().ToString();
		Effects = new DiseaseEffects();
		_ = CampaignTime.Now;
		CampaignTime now = CampaignTime.Now;
		CreatedAt = (float)(now).ToDays;
	}

	public bool IsExpired()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		_ = CampaignTime.Now;
		if (false)
		{
			return false;
		}
		CampaignTime now = CampaignTime.Now;
		float num = (float)(now).ToDays;
		return num > CreatedAt + (float)DurationDays;
	}

	public bool IsQuarantineExpired()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (!IsQuarantined || !QuarantineEndDays.HasValue)
		{
			return false;
		}
		_ = CampaignTime.Now;
		if (false)
		{
			return false;
		}
		CampaignTime now = CampaignTime.Now;
		float num = (float)(now).ToDays;
		return num >= QuarantineEndDays.Value;
	}

	public void SetQuarantine(int durationDays = 0)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		IsQuarantined = true;
		if (durationDays > 0)
		{
			_ = CampaignTime.Now;
			if (true)
			{
				CampaignTime now = CampaignTime.Now;
				float num = (float)(now).ToDays;
				float num2 = ((QuarantineEndDays.HasValue && QuarantineEndDays.Value > num) ? QuarantineEndDays.Value : num);
				QuarantineEndDays = num2 + (float)durationDays;
				return;
			}
		}
		QuarantineEndDays = null;
	}

	public void RemoveQuarantine()
	{
		IsQuarantined = false;
		QuarantineEndDays = null;
	}

	public float GetDailyProgressIncrease()
	{
		return Severity switch
		{
			1 => 1f, 
			2 => 1.5f, 
			3 => 2.5f, 
			4 => 3.5f, 
			5 => 5f, 
			_ => 1f, 
		} * (GlobalSettings<ModSettings>.Instance?.DiseaseProgressionMultiplier ?? 1f);
	}

	public float GetSeverityModifier()
	{
		return Severity switch
		{
			1 => 1f, 
			2 => 0.8f, 
			3 => 0.6f, 
			4 => 0.4f, 
			5 => 0.2f, 
			_ => 1f, 
		};
	}

	public float GetBaseRecoveryRate()
	{
		return Severity switch
		{
			1 => 2f, 
			2 => 1.5f, 
			3 => 1f, 
			4 => 0.75f, 
			5 => 0.5f, 
			_ => 1f, 
		} * (GlobalSettings<ModSettings>.Instance?.DiseaseRecoveryMultiplier ?? 1f);
	}

	public float GetBaseNaturalRecoveryRate()
	{
		return Severity switch
		{
			1 => 0.5f, 
			2 => 0.3f, 
			_ => 0f, 
		};
	}

	public int GetMinMedicineForNaturalRecovery()
	{
		return Severity switch
		{
			1 => 50, 
			2 => 100, 
			_ => int.MaxValue, 
		};
	}

	public int GetMaxTreatmentDays()
	{
		return Severity switch
		{
			1 => 7, 
			2 => 6, 
			3 => 5, 
			4 => 4, 
			5 => 4, 
			_ => 7, 
		};
	}
}
