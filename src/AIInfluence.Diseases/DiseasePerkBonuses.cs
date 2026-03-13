using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diseases;

public static class DiseasePerkBonuses
{
	public const float SelfMedicationRecoveryBonus = 0.15f;

	public const float PreventiveMedicineImmunityBonus = 0.1f;

	public const float TriageTentStationaryBonus = 0.2f;

	public const float WalkItOffThreshold = 10f;

	public const float SledgesSpeedPenaltyReduction = 0.3f;

	public const float BestMedicineMoraleThreshold = 50f;

	public const float BestMedicineHealingBonus = 0.15f;

	public const float SiegeMedicProgressionReduction = 0.3f;

	public const float VeterinarianSpreadReduction = 0.25f;

	public const float PristineStreetsSpreadReduction = 0.2f;

	public const float BushDoctorHerbCostReduction = 0.25f;

	public const float PerfectHealthImmunityPerFood = 0.03f;

	public const float PhysicianOfPeopleNaturalRecoveryChance = 0.3f;

	public const float CheatDeathResetProgress = 50f;

	public const float FortitudeTonicCompanionImmunity = 0.1f;

	public const float HelpingHandsPerTenTroops = 0.01f;

	public const float BattleHardenedPostImmunity = 0.05f;

	public const float MinisterOfHealthImmunityPerPoint = 0.005f;

	public const float MinisterOfHealthHealingPerPoint = 0.003f;

	public const int MinisterOfHealthSkillThreshold = 250;

	public static float GetHeroRecoveryMultiplier(Hero hero, MobileParty party)
	{
		if (hero == null)
		{
			return 1f;
		}
		float num = 1f;
		if (hero.GetPerkValue(Medicine.SelfMedication))
		{
			num += 0.15f;
		}
		Hero val = ((party != null) ? party.EffectiveSurgeon : null);
		if (val != null)
		{
			if (!party.IsMoving && val.GetPerkValue(Medicine.TriageTent))
			{
				num += 0.2f;
			}
			if (party.Morale > 50f && val.GetPerkValue(Medicine.BestMedicine))
			{
				num += 0.15f;
			}
			if (val.GetPerkValue(Medicine.HelpingHands))
			{
				TroopRoster memberRoster = party.MemberRoster;
				int num2 = ((memberRoster != null) ? memberRoster.TotalManCount : 0);
				num += (float)(num2 / 10) * 0.01f;
			}
			if (val.GetPerkValue(Medicine.MinisterOfHealth))
			{
				int skillValue = val.GetSkillValue(DefaultSkills.Medicine);
				if (skillValue > 250)
				{
					num += (float)(skillValue - 250) * 0.003f;
				}
			}
		}
		return num;
	}

	public static float GetTroopRecoveryMultiplier(MobileParty party)
	{
		if (party == null)
		{
			return 1f;
		}
		Hero effectiveSurgeon = party.EffectiveSurgeon;
		if (effectiveSurgeon == null)
		{
			return 1f;
		}
		float num = 1f;
		if (!party.IsMoving && effectiveSurgeon.GetPerkValue(Medicine.TriageTent))
		{
			num += 0.2f;
		}
		if (party.Morale > 50f && effectiveSurgeon.GetPerkValue(Medicine.BestMedicine))
		{
			num += 0.15f;
		}
		if (effectiveSurgeon.GetPerkValue(Medicine.HelpingHands))
		{
			TroopRoster memberRoster = party.MemberRoster;
			int num2 = ((memberRoster != null) ? memberRoster.TotalManCount : 0);
			num += (float)(num2 / 10) * 0.01f;
		}
		if (effectiveSurgeon.GetPerkValue(Medicine.MinisterOfHealth))
		{
			int skillValue = effectiveSurgeon.GetSkillValue(DefaultSkills.Medicine);
			if (skillValue > 250)
			{
				num += (float)(skillValue - 250) * 0.003f;
			}
		}
		return num;
	}

	public static float GetHeroImmunityBonus(Hero hero, MobileParty party)
	{
		if (hero == null)
		{
			return 0f;
		}
		float num = 0f;
		if (hero.GetPerkValue(Medicine.PreventiveMedicine))
		{
			num += 0.1f;
		}
		Hero val = ((party != null) ? party.EffectiveSurgeon : null);
		if (val != null)
		{
			if (val.GetPerkValue(Medicine.FortitudeTonic))
			{
				num += 0.1f;
			}
			if (val.GetPerkValue(Medicine.PerfectHealth))
			{
				ItemRoster itemRoster = party.ItemRoster;
				int num2 = ((itemRoster != null) ? itemRoster.FoodVariety : 0);
				num += (float)num2 * 0.03f;
			}
		}
		if (hero.GetPerkValue(Medicine.MinisterOfHealth))
		{
			int skillValue = hero.GetSkillValue(DefaultSkills.Medicine);
			if (skillValue > 250)
			{
				num += (float)(skillValue - 250) * 0.005f;
			}
		}
		return num;
	}

	public static float GetTroopImmunityBonus(MobileParty party)
	{
		if (party == null)
		{
			return 0f;
		}
		Hero effectiveSurgeon = party.EffectiveSurgeon;
		if (effectiveSurgeon == null)
		{
			return 0f;
		}
		float num = 0f;
		if (effectiveSurgeon.GetPerkValue(Medicine.PerfectHealth))
		{
			ItemRoster itemRoster = party.ItemRoster;
			int num2 = ((itemRoster != null) ? itemRoster.FoodVariety : 0);
			num += (float)num2 * 0.03f;
		}
		if (effectiveSurgeon.GetPerkValue(Medicine.MinisterOfHealth))
		{
			int skillValue = effectiveSurgeon.GetSkillValue(DefaultSkills.Medicine);
			if (skillValue > 250)
			{
				num += (float)(skillValue - 250) * 0.005f;
			}
		}
		return num;
	}

	public static float GetPartySpreadReduction(MobileParty party)
	{
		Hero val = ((party != null) ? party.EffectiveSurgeon : null);
		if (val != null && val.GetPerkValue(Medicine.Veterinarian))
		{
			return 0.25f;
		}
		return 0f;
	}

	public static float GetSettlementSpreadReduction(Settlement settlement)
	{
		object obj;
		if (settlement == null)
		{
			obj = null;
		}
		else
		{
			Town town = settlement.Town;
			obj = ((town != null) ? town.Governor : null);
		}
		if (obj != null && settlement.Town.Governor.GetPerkValue(Medicine.PristineStreets))
		{
			return 0.2f;
		}
		return 0f;
	}

	public static float GetSiegeProgressionReduction(MobileParty party)
	{
		Hero val = ((party != null) ? party.EffectiveSurgeon : null);
		if (((party != null) ? party.SiegeEvent : null) != null && val != null && val.GetPerkValue(Medicine.SiegeMedic))
		{
			return 0.3f;
		}
		return 0f;
	}

	public static float GetSpeedPenaltyReduction(MobileParty party)
	{
		Hero val = ((party != null) ? party.EffectiveSurgeon : null);
		if (val != null && val.GetPerkValue(Medicine.Sledges))
		{
			return 0.3f;
		}
		return 0f;
	}

	public static int GetMedicalTierBonus(Settlement settlement, Hero hero)
	{
		int num = 0;
		if (hero != null && hero.GetPerkValue(Medicine.GoodLogdings))
		{
			num++;
		}
		object obj;
		if (settlement == null)
		{
			obj = null;
		}
		else
		{
			Town town = settlement.Town;
			obj = ((town != null) ? town.Governor : null);
		}
		if (obj != null && settlement.Town.Governor.GetPerkValue(Medicine.CleanInfrastructure))
		{
			num++;
		}
		return num;
	}

	public static float GetHerbCostReduction(Settlement settlement)
	{
		object obj;
		if (settlement == null)
		{
			obj = null;
		}
		else
		{
			Village village = settlement.Village;
			if (village == null)
			{
				obj = null;
			}
			else
			{
				Settlement bound = village.Bound;
				if (bound == null)
				{
					obj = null;
				}
				else
				{
					Town town = bound.Town;
					obj = ((town != null) ? town.Governor : null);
				}
			}
		}
		if (obj != null && settlement.Village.Bound.Town.Governor.GetPerkValue(Medicine.BushDoctor))
		{
			return 0.25f;
		}
		object obj2;
		if (settlement == null)
		{
			obj2 = null;
		}
		else
		{
			Town town2 = settlement.Town;
			obj2 = ((town2 != null) ? town2.Governor : null);
		}
		if (obj2 != null && settlement.Town.Governor.GetPerkValue(Medicine.BushDoctor))
		{
			return 0.25f;
		}
		return 0f;
	}

	public static float GetLowProgressThreshold(MobileParty party)
	{
		float result = 5f;
		Hero val = ((party != null) ? party.EffectiveSurgeon : null);
		if (val != null && val.GetPerkValue(Medicine.WalkItOff))
		{
			result = 10f;
		}
		return result;
	}

	public static bool ShouldPreventTroopDeath(MobileParty party, Disease disease, int tier)
	{
		if (party == null || disease == null)
		{
			return false;
		}
		if (disease.Severity >= 5)
		{
			return false;
		}
		if (tier > 2)
		{
			return false;
		}
		Hero effectiveSurgeon = party.EffectiveSurgeon;
		return effectiveSurgeon != null && effectiveSurgeon.GetPerkValue(Medicine.HealthAdvise);
	}

	public static bool CanRecoverFromPerkPhysician(MobileParty party, Disease disease)
	{
		if (party == null || disease == null)
		{
			return false;
		}
		if (disease.Severity < 3 || disease.Severity >= 5)
		{
			return false;
		}
		Hero effectiveSurgeon = party.EffectiveSurgeon;
		if (effectiveSurgeon == null || !effectiveSurgeon.GetPerkValue(Medicine.PhysicianOfPeople))
		{
			return false;
		}
		return MBRandom.RandomFloat < 0.3f;
	}

	public static bool TryCheatDeath(Hero hero, DiseaseInstance instance)
	{
		if (hero == null || instance == null)
		{
			return false;
		}
		if (!hero.GetPerkValue(Medicine.CheatDeath))
		{
			return false;
		}
		if (instance.HasUsedCheatDeath)
		{
			return false;
		}
		instance.HasUsedCheatDeath = true;
		instance.DiseaseProgress = 50f;
		DiseaseLogger.Instance?.Log($"[PERK] {hero.Name} cheated death from disease (progress reset to {50f}%)");
		return true;
	}

	public static float GetBattleHardenedImmunityBonus(MobileParty party, Disease disease)
	{
		if (party == null || disease == null)
		{
			return 0f;
		}
		if (disease.Severity < 3)
		{
			return 0f;
		}
		Hero effectiveSurgeon = party.EffectiveSurgeon;
		if (effectiveSurgeon == null || !effectiveSurgeon.GetPerkValue(Medicine.BattleHardened))
		{
			return 0f;
		}
		return 0.05f;
	}

	public static string GetDiseaseBonusText(PerkObject perk)
	{
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Expected O, but got Unknown
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Expected O, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected O, but got Unknown
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected O, but got Unknown
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Expected O, but got Unknown
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Expected O, but got Unknown
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Expected O, but got Unknown
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected O, but got Unknown
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Expected O, but got Unknown
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected O, but got Unknown
		if (perk == null)
		{
			return null;
		}
		return ((MBObjectBase)perk).StringId switch
		{
			"MedicineSelfMedication" => ((object)new TextObject("{=AIInfluence_PerkBonus_SelfMedication}+15% disease recovery speed (personal)", (Dictionary<string, object>)null)).ToString(), 
			"MedicinePreventiveMedicine" => ((object)new TextObject("{=AIInfluence_PerkBonus_PreventiveMedicine}+10% disease immunity (personal)", (Dictionary<string, object>)null)).ToString(), 
			"MedicineTriageTent" => ((object)new TextObject("{=AIInfluence_PerkBonus_TriageTent}+20% disease treatment effectiveness when party is stationary", (Dictionary<string, object>)null)).ToString(), 
			"MedicineWalkItOff" => ((object)new TextObject("{=AIInfluence_PerkBonus_WalkItOff}Low-progress recovery threshold increased to 10%", (Dictionary<string, object>)null)).ToString(), 
			"MedicineSledges" => ((object)new TextObject("{=AIInfluence_PerkBonus_Sledges}-30% map speed penalty from diseases", (Dictionary<string, object>)null)).ToString(), 
			"MedicineDoctorsOath" => ((object)new TextObject("{=AIInfluence_PerkBonus_DoctorsOath}Captured prisoners from sick parties may be cured", (Dictionary<string, object>)null)).ToString(), 
			"MedicineBestMedicine" => ((object)new TextObject("{=AIInfluence_PerkBonus_BestMedicine}+15% disease healing speed when morale > 50", (Dictionary<string, object>)null)).ToString(), 
			"MedicineGoodLodging" => ((object)new TextObject("{=AIInfluence_PerkBonus_GoodLodging}+1 medical tier when treated in settlements", (Dictionary<string, object>)null)).ToString(), 
			"MedicineSiegeMedic" => ((object)new TextObject("{=AIInfluence_PerkBonus_SiegeMedic}Diseases progress 30% slower during sieges", (Dictionary<string, object>)null)).ToString(), 
			"MedicineVeterinarian" => ((object)new TextObject("{=AIInfluence_PerkBonus_Veterinarian}-25% disease spread rate within party", (Dictionary<string, object>)null)).ToString(), 
			"MedicinePristineStreets" => ((object)new TextObject("{=AIInfluence_PerkBonus_PristineStreets}-20% disease spread in governed settlement", (Dictionary<string, object>)null)).ToString(), 
			"MedicineBushDoctor" => ((object)new TextObject("{=AIInfluence_PerkBonus_BushDoctor}-25% herb cost near governed settlement", (Dictionary<string, object>)null)).ToString(), 
			"MedicinePerfectHealth" => ((object)new TextObject("{=AIInfluence_PerkBonus_PerfectHealth}+3% troop immunity per food variety", (Dictionary<string, object>)null)).ToString(), 
			"MedicineHealthAdvise" => ((object)new TextObject("{=AIInfluence_PerkBonus_HealthAdvise}Tier 1-2 troops cannot die from diseases (except severity 5)", (Dictionary<string, object>)null)).ToString(), 
			"MedicinePhysicianOfPeople" => ((object)new TextObject("{=AIInfluence_PerkBonus_PhysicianOfPeople}30% daily chance for tier 1-2 troops to naturally recover from severe diseases", (Dictionary<string, object>)null)).ToString(), 
			"MedicineCleanInfrastructure" => ((object)new TextObject("{=AIInfluence_PerkBonus_CleanInfrastructure}+1 medical tier in governed settlements", (Dictionary<string, object>)null)).ToString(), 
			"MedicineCheatDeath" => ((object)new TextObject("{=AIInfluence_PerkBonus_CheatDeath}Survive 100% disease progress once (reset to 50%)", (Dictionary<string, object>)null)).ToString(), 
			"MedicineFortitudeTonic" => ((object)new TextObject("{=AIInfluence_PerkBonus_FortitudeTonic}+10% disease immunity for all companions", (Dictionary<string, object>)null)).ToString(), 
			"MedicineHelpingHands" => ((object)new TextObject("{=AIInfluence_PerkBonus_HelpingHands}+1% disease healing rate per 10 troops", (Dictionary<string, object>)null)).ToString(), 
			"MedicineBattleHardened" => ((object)new TextObject("{=AIInfluence_PerkBonus_BattleHardened}Troops surviving severe diseases gain +5% permanent immunity", (Dictionary<string, object>)null)).ToString(), 
			"MedicineMinisterOfHealth" => ((object)new TextObject("{=AIInfluence_PerkBonus_MinisterOfHealth}+0.5% party immunity and +0.3% healing per Medicine point above 250", (Dictionary<string, object>)null)).ToString(), 
			_ => null, 
		};
	}
}
