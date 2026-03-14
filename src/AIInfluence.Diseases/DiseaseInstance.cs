using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diseases;

[JsonSerializable]
public class DiseaseInstance
{
	[JsonProperty("disease_id")]
	public string DiseaseId { get; set; }

	[JsonProperty("disease_name")]
	public string DiseaseName { get; set; }

	[JsonProperty("target_id")]
	public string TargetId { get; set; }

	[JsonProperty("target_type")]
	public DiseaseTargetType TargetType { get; set; }

	[JsonProperty("party_id")]
	public string PartyId { get; set; }

	[JsonProperty("infected_at")]
	public float InfectedAt { get; set; }

	[JsonProperty("disease_progress")]
	public float DiseaseProgress { get; set; }

	[JsonProperty("initial_progress")]
	public float InitialProgress { get; set; }

	[JsonProperty("is_recovered")]
	public bool IsRecovered { get; set; }

	[JsonProperty("is_dead")]
	public bool IsDead { get; set; }

	[JsonProperty("is_treated")]
	public bool IsTreated { get; set; }

	[JsonProperty("treatment_start_days")]
	public float? TreatmentStartDays { get; set; }

	[JsonProperty("treatment_effectiveness")]
	public float TreatmentEffectiveness { get; set; } = 1f;

	[JsonProperty("treatment_quality_bonus")]
	public float TreatmentQualityBonus { get; set; } = 1f;

	[JsonProperty("infected_troop_count")]
	public int InfectedTroopCount { get; set; }

	[JsonProperty("total_troop_count")]
	public int TotalTroopCount { get; set; }

	[JsonProperty("troop_tier_distribution")]
	public Dictionary<int, int> TroopTierDistribution { get; set; }

	[JsonProperty("permanent_modifiers")]
	public DiseaseEffects PermanentModifiers { get; set; }

	[JsonProperty("post_treatment_recovery_rate")]
	public float PostTreatmentRecoveryRate { get; set; }

	[JsonProperty("post_treatment_days_remaining")]
	public int PostTreatmentDaysRemaining { get; set; }

	[JsonProperty("has_prevention_effect")]
	public bool HasPreventionEffect { get; set; }

	[JsonProperty("prevention_end_days")]
	public float? PreventionEndDays { get; set; }

	[JsonProperty("prevention_strength")]
	public int PreventionStrength { get; set; }

	[JsonProperty("seasonal_immunity_end_days")]
	public float? SeasonalImmunityEndDays { get; set; }

	[JsonProperty("has_used_cheat_death")]
	public bool HasUsedCheatDeath { get; set; }

	[JsonIgnore]
	public CampaignTime? TreatmentStartTime
	{
		get
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			if (!TreatmentStartDays.HasValue)
			{
				return null;
			}
			float value = TreatmentStartDays.Value;
			CampaignTime now = CampaignTime.Now;
			float num = value - (float)(now).ToDays;
			return CampaignTime.DaysFromNow(num);
		}
		set
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			float? treatmentStartDays;
			if (!value.HasValue)
			{
				treatmentStartDays = null;
			}
			else
			{
				CampaignTime value2 = value.Value;
				treatmentStartDays = (float)(value2).ToDays;
			}
			TreatmentStartDays = treatmentStartDays;
		}
	}

	[JsonIgnore]
	public CampaignTime? PreventionEndTime
	{
		get
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			if (!PreventionEndDays.HasValue)
			{
				return null;
			}
			float value = PreventionEndDays.Value;
			CampaignTime now = CampaignTime.Now;
			float num = value - (float)(now).ToDays;
			return CampaignTime.DaysFromNow(num);
		}
		set
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			float? preventionEndDays;
			if (!value.HasValue)
			{
				preventionEndDays = null;
			}
			else
			{
				CampaignTime value2 = value.Value;
				preventionEndDays = (float)(value2).ToDays;
			}
			PreventionEndDays = preventionEndDays;
		}
	}

	[JsonIgnore]
	public int DaysSinceInfection
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
			return Math.Max(0, (int)(num - InfectedAt));
		}
	}

	[JsonIgnore]
	public int DaysSinceTreatmentStart
	{
		get
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			if (TreatmentStartDays.HasValue)
			{
				_ = CampaignTime.Now;
				if (0 == 0)
				{
					CampaignTime now = CampaignTime.Now;
					float num = (float)(now).ToDays;
					return Math.Max(0, (int)(num - TreatmentStartDays.Value));
				}
			}
			return 0;
		}
	}

	[JsonIgnore]
	public float InfectionRate
	{
		get
		{
			if (TotalTroopCount <= 0)
			{
				return 0f;
			}
			return Math.Min(100f, (float)InfectedTroopCount / (float)TotalTroopCount * 100f);
		}
	}

	[JsonIgnore]
	public bool HasPostTreatmentEffect => PostTreatmentDaysRemaining > 0 && PostTreatmentRecoveryRate > 0f;

	public DiseaseInstance()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		TroopTierDistribution = new Dictionary<int, int>();
		_ = CampaignTime.Now;
		if (true)
		{
			CampaignTime now = CampaignTime.Now;
			InfectedAt = (float)(now).ToDays;
		}
	}

	public bool IsPreventionExpired()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (!HasPreventionEffect || !PreventionEndDays.HasValue)
		{
			return true;
		}
		_ = CampaignTime.Now;
		if (false)
		{
			return false;
		}
		CampaignTime now = CampaignTime.Now;
		float num = (float)(now).ToDays;
		return num >= PreventionEndDays.Value;
	}

	public bool HasActiveSeasonalImmunity()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (!SeasonalImmunityEndDays.HasValue)
		{
			return false;
		}
		_ = CampaignTime.Now;
		if (false)
		{
			return true;
		}
		CampaignTime now = CampaignTime.Now;
		return (float)(now).ToDays < SeasonalImmunityEndDays.Value;
	}

	public void StartTreatment(float qualityBonus = 1f)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		IsTreated = true;
		TreatmentEffectiveness = 1f;
		TreatmentQualityBonus = qualityBonus;
		_ = CampaignTime.Now;
		if (true)
		{
			CampaignTime now = CampaignTime.Now;
			TreatmentStartDays = (float)(now).ToDays;
		}
		PostTreatmentRecoveryRate = 0f;
		PostTreatmentDaysRemaining = 0;
	}

	public void StopTreatment()
	{
		IsTreated = false;
		TreatmentStartDays = null;
		TreatmentEffectiveness = 0f;
	}

	public void StartPostTreatmentRecovery(float recoveryRate, int durationDays)
	{
		IsTreated = false;
		TreatmentEffectiveness = 0f;
		TreatmentStartDays = null;
		PostTreatmentRecoveryRate = recoveryRate;
		PostTreatmentDaysRemaining = durationDays;
	}

	public void ApplyPrevention(int strength, int durationDays)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		HasPreventionEffect = true;
		PreventionStrength = strength;
		_ = CampaignTime.Now;
		if (true)
		{
			CampaignTime now = CampaignTime.Now;
			PreventionEndDays = (float)(now).ToDays + (float)durationDays;
		}
	}

	public void RemovePrevention()
	{
		HasPreventionEffect = false;
		PreventionStrength = 0;
		PreventionEndDays = null;
	}

	public void AddTroopsToTier(int tier, int count)
	{
		if (TroopTierDistribution.ContainsKey(tier))
		{
			TroopTierDistribution[tier] += count;
		}
		else
		{
			TroopTierDistribution[tier] = count;
		}
		InfectedTroopCount += count;
	}

	public void RemoveTroopsFromTier(int tier, int count)
	{
		if (TroopTierDistribution.ContainsKey(tier))
		{
			TroopTierDistribution[tier] = Math.Max(0, TroopTierDistribution[tier] - count);
			InfectedTroopCount = Math.Max(0, InfectedTroopCount - count);
		}
	}

	public int GetTroopCountInTier(int tier)
	{
		return TroopTierDistribution.ContainsKey(tier) ? TroopTierDistribution[tier] : 0;
	}

	public bool ShouldRetreat()
	{
		if (IsTreated && TreatmentEffectiveness < 0.5f)
		{
			return true;
		}
		if (!IsTreated && !HasPostTreatmentEffect && DiseaseProgress > 0f && !IsRecovered)
		{
			return true;
		}
		return false;
	}
}
