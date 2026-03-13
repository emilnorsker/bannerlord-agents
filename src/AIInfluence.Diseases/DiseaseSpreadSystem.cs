using System;
using System.Collections.Generic;
using System.Linq;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace AIInfluence.Diseases;

public static class DiseaseSpreadSystem
{
	private static readonly Random _random = new Random();

	public static float SettlementInfectionSeverityMod = 0.1f;

	public static float SettlementInfectionProsperityMaxReduction = 0.5f;

	public static float SettlementInfectionProsperityDivisor = 10000f;

	public static float MissionInfectionSeverityMod = 0.2f;

	public static float LordHallInfectionSeverityMod = 0.1f;

	public static float LordHallInfectionMaxChance = 0.35f;

	public static float LeaderToTroopsBaseRate = 0.075f;

	public static float PlayerFromTroopsMedicineDivisor = 600f;

	public static float PartyTroopInfectionBaseRate = 0.075f;

	public static float WithinPartyBaseChance = 0.025f;

	public static float WithinPartyTroopCountDivisor = 100f;

	public static float CaravanInfectionBaseChance = 0.1f;

	public static float CaravanTroopInfectionRate = 0.1f;

	public static float VillagerPartyTroopInfectionBaseRate = 0.075f;

	public static float LordInfectionBaseChance = 0.075f;

	public static float LordTroopInfectionRate = 0.075f;

	public static float NotableInfectionBaseChance = 0.09f;

	public static float CarrierToSettlementBaseChance = 0.05f;

	public static float MilitiaInfectionBaseChance = 0.125f;

	public static float MilitiaInitialInfectedPercent = 5f;

	public static float GarrisonInfectionBaseChance = 0.1f;

	public static float GarrisonInitialInfectedPercent = 5f;

	public static float HeroMedicineResistanceDivisor = 600f;

	public static float HeroMedicineResistanceMax = 0.5f;

	public static int EpidemicMinInfectedHeroes = 4;

	public static float QuarantineTreatmentBonus = 1.3f;

	public static float SettlementInfectionBaseChance => GlobalSettings<ModSettings>.Instance?.SettlementInfectionBaseChance ?? 0.05f;

	public static float MissionInfectionBaseChance => GlobalSettings<ModSettings>.Instance?.MissionInfectionBaseChance ?? 0.08f;

	public static float LordHallInfectionChancePerLord => GlobalSettings<ModSettings>.Instance?.LordHallInfectionChancePerLord ?? 0.025f;

	public static float PlayerFromTroopsBaseChance => GlobalSettings<ModSettings>.Instance?.PlayerFromTroopsBaseChance ?? 0.175f;

	public static float QuarantineInfectionReduction => GlobalSettings<ModSettings>.Instance?.QuarantineInfectionReduction ?? 0.5f;

	public static float PrisonerSpreadModifier => GlobalSettings<ModSettings>.Instance?.PrisonerSpreadModifier ?? 0.5f;

	private static float GetSeverityMultiplier(Disease disease)
	{
		return 1f + (float)disease.Severity * 0.1f;
	}

	private static float GetHeroMedicineResistance(Hero hero)
	{
		if (hero == null)
		{
			return 0f;
		}
		int skillValue = hero.GetSkillValue(DefaultSkills.Medicine);
		return Math.Min(HeroMedicineResistanceMax, (float)skillValue / HeroMedicineResistanceDivisor);
	}

	private static float GetProsperityModifier(Settlement settlement)
	{
		if (settlement == null)
		{
			return 1f;
		}
		float num = (settlement.IsTown ? settlement.Town.Prosperity : (settlement.IsCastle ? settlement.Town.Prosperity : 1000f));
		return 1f - Math.Min(SettlementInfectionProsperityMaxReduction, num / SettlementInfectionProsperityDivisor);
	}

	public static float GetQuarantineModifier(Settlement settlement)
	{
		if (settlement == null)
		{
			return 1f;
		}
		DiseaseManager instance = DiseaseManager.Instance;
		if (instance != null && instance.IsSettlementUnderQuarantine(settlement))
		{
			return QuarantineInfectionReduction;
		}
		return 1f;
	}

	public static bool CheckSettlementInfection(Hero hero, Settlement settlement, Disease disease)
	{
		if (hero == null || settlement == null || disease == null)
		{
			return false;
		}
		float settlementInfectionBaseChance = SettlementInfectionBaseChance;
		float num = 1f + (float)disease.Severity * SettlementInfectionSeverityMod;
		float prosperityModifier = GetProsperityModifier(settlement);
		float num2 = 1f - GetHeroMedicineResistance(hero);
		float quarantineModifier = GetQuarantineModifier(settlement);
		float num3 = settlementInfectionBaseChance * num * prosperityModifier * disease.SpreadRate * num2 * quarantineModifier;
		return _random.NextDouble() < (double)num3;
	}

	public static bool CheckMissionInfection(Hero hero, Settlement settlement, Disease disease)
	{
		if (hero == null || settlement == null || disease == null)
		{
			return false;
		}
		float missionInfectionBaseChance = MissionInfectionBaseChance;
		float num = 1f + (float)disease.Severity * MissionInfectionSeverityMod;
		float prosperityModifier = GetProsperityModifier(settlement);
		float num2 = 1f - GetHeroMedicineResistance(hero);
		float quarantineModifier = GetQuarantineModifier(settlement);
		float num3 = missionInfectionBaseChance * num * prosperityModifier * disease.SpreadRate * num2 * quarantineModifier;
		return _random.NextDouble() < (double)num3;
	}

	public static bool CheckLordHallInfection(Hero hero, Settlement settlement, Disease disease)
	{
		if (hero == null || settlement == null || disease == null)
		{
			return false;
		}
		List<Hero> list = GetInfectedHeroesInSettlement(settlement).Where(delegate(Hero h)
		{
			int result;
			if (h.IsLord && h != hero)
			{
				DiseaseManager instance = DiseaseManager.Instance;
				result = ((instance != null && instance.GetHeroDiseases(h)?.Any((DiseaseInstance d) => d.DiseaseId == disease.Id) == true) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
		if (list.Count == 0)
		{
			return false;
		}
		float num = LordHallInfectionChancePerLord * (float)list.Count;
		float num2 = 1f + (float)disease.Severity * LordHallInfectionSeverityMod;
		float prosperityModifier = GetProsperityModifier(settlement);
		float num3 = 1f - GetHeroMedicineResistance(hero);
		float quarantineModifier = GetQuarantineModifier(settlement);
		float num4 = Math.Min(LordHallInfectionMaxChance, num * num2 * prosperityModifier * disease.SpreadRate * num3 * quarantineModifier);
		return _random.NextDouble() < (double)num4;
	}

	public static void SpreadDiseaseFromLeaderToTroops(MobileParty party)
	{
		if (((party != null) ? party.LeaderHero : null) == null || ((party != null) ? party.MemberRoster : null) == null)
		{
			return;
		}
		int totalRegulars = party.MemberRoster.TotalRegulars;
		if (totalRegulars <= 0)
		{
			return;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(party.LeaderHero);
		if (list == null || list.Count == 0)
		{
			return;
		}
		LogMessage($"[DISEASE_SPREAD] Checking leader-to-troop spread: {party.Name} (leader has {list.Count} disease(s), {totalRegulars} troops)");
		List<DiseaseInstance> source = DiseaseManager.Instance?.GetPartyDiseases(party) ?? new List<DiseaseInstance>();
		foreach (DiseaseInstance item in list)
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
			if (disease == null)
			{
				continue;
			}
			int num = source.Where((DiseaseInstance i) => i.DiseaseId == disease.Id).Sum((DiseaseInstance i) => i.InfectedTroopCount);
			int num2 = totalRegulars - num;
			if (num2 > 0)
			{
				float leaderToTroopsBaseRate = LeaderToTroopsBaseRate;
				float num3 = DiseaseEffectSystem.CalculateTroopMedicineEffectiveness(party, disease);
				float num4 = (1f - num3) * disease.SpreadRate * GetSeverityMultiplier(disease);
				num4 *= 1f - DiseasePerkBonuses.GetPartySpreadReduction(party);
				num4 *= 1f - ImmunitySystem.CalculateTroopImmunityChance(party, disease);
				float num5 = (float)num2 * leaderToTroopsBaseRate * num4;
				int num6 = ((num5 >= 1f) ? ((int)num5) : ((num5 > 0f) ? ((_random.NextDouble() < (double)num5) ? 1 : 0) : 0));
				if (num6 >= 1)
				{
					DiseaseManager.Instance?.InfectPartyTroops(party, disease, num6);
					LogMessage($"[DISEASE_SPREAD] Leader spread {disease.Name} to {num6} troops in {party.Name}");
				}
				else
				{
					LogMessage($"[DISEASE_SPREAD] Leader-to-troop spread ({disease.Name}): 0 troops to infect (medicine effectiveness: {num3:P0}, healthy: {num2})");
				}
			}
		}
	}

	public static bool CheckPlayerInfectionFromTroops(Hero player, MobileParty party)
	{
		if (player == null || party == null)
		{
			return false;
		}
		int skillValue = player.GetSkillValue(DefaultSkills.Medicine);
		float num = Math.Min(0.9f, (float)skillValue / PlayerFromTroopsMedicineDivisor);
		bool result = false;
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetPartyDiseases(party);
		TroopRoster memberRoster = party.MemberRoster;
		int num2 = ((memberRoster != null) ? memberRoster.TotalRegulars : 0);
		if (list != null && list.Count > 0 && num2 > 0)
		{
			foreach (DiseaseInstance item in list)
			{
				Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
				if (disease == null)
				{
					continue;
				}
				float num3 = (float)item.InfectedTroopCount / (float)num2;
				if (num3 <= 0f)
				{
					continue;
				}
				float num4 = PlayerFromTroopsBaseChance * num3;
				float num5 = num4 * disease.SpreadRate * GetSeverityMultiplier(disease) * (1f - num);
				if (_random.NextDouble() < (double)num5)
				{
					DiseaseManager instance = DiseaseManager.Instance;
					if (instance != null && instance.InfectHero(player, disease))
					{
						LogMessage($"[DISEASE_SPREAD] {player.Name} infected by troops with {disease.Name} (chance: {num5:P1})");
						result = true;
					}
				}
			}
		}
		List<DiseaseInstance> list2 = DiseaseManager.Instance?.GetPartyPrisonerDiseases(party);
		TroopRoster prisonRoster = party.PrisonRoster;
		int num6 = ((prisonRoster != null) ? prisonRoster.TotalRegulars : 0);
		if (list2 != null && list2.Count > 0 && num6 > 0)
		{
			foreach (DiseaseInstance item2 in list2)
			{
				Disease disease2 = DiseaseManager.Instance?.GetDiseaseById(item2.DiseaseId);
				if (disease2 == null)
				{
					continue;
				}
				float num7 = (float)item2.InfectedTroopCount / (float)num6;
				if (num7 <= 0f)
				{
					continue;
				}
				float num8 = PlayerFromTroopsBaseChance * DiseaseManager.PrisonerSpreadModifier * num7;
				float num9 = num8 * disease2.SpreadRate * GetSeverityMultiplier(disease2) * (1f - num);
				if (_random.NextDouble() < (double)num9)
				{
					DiseaseManager instance2 = DiseaseManager.Instance;
					if (instance2 != null && instance2.InfectHero(player, disease2))
					{
						LogMessage($"[DISEASE_SPREAD] {player.Name} infected by prisoner troops with {disease2.Name} (chance: {num9:P1})");
						result = true;
					}
				}
			}
		}
		return result;
	}

	public static void CheckPartyTroopInfection(MobileParty party, Disease disease, Settlement settlement = null)
	{
		if (((party != null) ? party.MemberRoster : null) == null || disease == null)
		{
			return;
		}
		int totalRegulars = party.MemberRoster.TotalRegulars;
		if (totalRegulars > 0)
		{
			int num = Math.Max(1, (int)((float)totalRegulars * PartyTroopInfectionBaseRate));
			Settlement val = settlement ?? party.CurrentSettlement;
			float num2 = ((val != null) ? GetProsperityModifier(val) : 1f);
			float quarantineModifier = GetQuarantineModifier(val);
			float num3 = 1f - ImmunitySystem.CalculateTroopImmunityChance(party, disease);
			int num4 = (int)((float)num * disease.SpreadRate * GetSeverityMultiplier(disease) * num2 * quarantineModifier * num3);
			if (num4 > 0)
			{
				DiseaseManager.Instance?.InfectPartyTroops(party, disease, num4);
			}
		}
	}

	public static void SpreadDiseaseWithinParty(MobileParty party)
	{
		if (((party != null) ? party.MemberRoster : null) == null)
		{
			return;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetPartyDiseases(party);
		if (list == null || list.Count == 0)
		{
			return;
		}
		int totalRegulars = party.MemberRoster.TotalRegulars;
		if (totalRegulars <= 0)
		{
			return;
		}
		foreach (DiseaseInstance item in list)
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
			if (disease == null)
			{
				continue;
			}
			int num = totalRegulars - item.InfectedTroopCount;
			if (num > 0)
			{
				float withinPartyBaseChance = WithinPartyBaseChance;
				float num2 = 1f + (float)totalRegulars / WithinPartyTroopCountDivisor;
				float num3 = withinPartyBaseChance * num2 * disease.SpreadRate * GetSeverityMultiplier(disease);
				num3 *= 1f - DiseasePerkBonuses.GetPartySpreadReduction(party);
				num3 *= 1f - ImmunitySystem.CalculateTroopImmunityChance(party, disease);
				int num4 = (int)((float)num * num3);
				if (num4 > 0)
				{
					DiseaseManager.Instance?.InfectPartyTroops(party, disease, num4);
					LogMessage($"[DISEASE_SPREAD] {num4} more troops infected in {party.Name}");
				}
			}
		}
	}

	public static void CheckPrisonerToTroopSpread(MobileParty party)
	{
		if (((party != null) ? party.MemberRoster : null) == null || ((party != null) ? party.PrisonRoster : null) == null)
		{
			return;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetPartyPrisonerDiseases(party);
		if (list == null || list.Count == 0)
		{
			return;
		}
		int totalRegulars = party.MemberRoster.TotalRegulars;
		if (totalRegulars <= 0)
		{
			return;
		}
		foreach (DiseaseInstance item in list)
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
			if (disease == null)
			{
				continue;
			}
			int num = totalRegulars - ((DiseaseManager.Instance?.GetPartyDiseases(party)?.FirstOrDefault((DiseaseInstance i) => i.DiseaseId == disease.Id))?.InfectedTroopCount ?? 0);
			if (num <= 0)
			{
				continue;
			}
			float num2 = ((item.TotalTroopCount > 0) ? ((float)item.InfectedTroopCount / (float)item.TotalTroopCount) : 0f);
			if (!(num2 <= 0f))
			{
				float num3 = WithinPartyBaseChance * DiseaseManager.PrisonerSpreadModifier;
				float num4 = disease.SpreadRate * GetSeverityMultiplier(disease);
				float num5 = num3 * num2 * num4;
				num5 *= 1f - DiseasePerkBonuses.GetPartySpreadReduction(party);
				num5 *= 1f - ImmunitySystem.CalculateTroopImmunityChance(party, disease);
				int num6 = (int)((float)num * num5);
				if (num6 > 0)
				{
					DiseaseManager.Instance?.InfectPartyTroops(party, disease, num6);
					LogMessage($"[DISEASE_SPREAD] {num6} troops infected by prisoners in {party.Name} ({disease.Name})");
				}
			}
		}
	}

	public static void CheckPrisonerHeroSpread(MobileParty party)
	{
		if (party == null)
		{
			return;
		}
		List<Hero> list = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h.IsPrisoner && h.PartyBelongedToAsPrisoner == party.Party && (DiseaseManager.Instance?.IsHeroInfected(h) ?? false)).ToList();
		if (list.Count == 0)
		{
			return;
		}
		List<Disease> diseasesFromInfectedHeroes = GetDiseasesFromInfectedHeroes(list);
		foreach (Disease disease in diseasesFromInfectedHeroes)
		{
			int num = list.Count(delegate(Hero h)
			{
				DiseaseManager instance3 = DiseaseManager.Instance;
				return instance3 != null && instance3.GetHeroDiseases(h)?.Any((DiseaseInstance d) => d.DiseaseId == disease.Id) == true;
			});
			TroopRoster memberRoster = party.MemberRoster;
			int num2 = ((memberRoster != null) ? memberRoster.TotalRegulars : 0);
			if (num2 > 0)
			{
				int num3 = num2 - ((DiseaseManager.Instance?.GetPartyDiseases(party)?.FirstOrDefault((DiseaseInstance i) => i.DiseaseId == disease.Id))?.InfectedTroopCount ?? 0);
				if (num3 > 0)
				{
					float num4 = WithinPartyBaseChance * DiseaseManager.PrisonerSpreadModifier * (float)num;
					float num5 = disease.SpreadRate * GetSeverityMultiplier(disease);
					float num6 = num4 * num5;
					num6 *= 1f - DiseasePerkBonuses.GetPartySpreadReduction(party);
					num6 *= 1f - ImmunitySystem.CalculateTroopImmunityChance(party, disease);
					int num7 = (int)((float)num3 * num6);
					if (num7 > 0)
					{
						DiseaseManager.Instance?.InfectPartyTroops(party, disease, num7);
						LogMessage($"[DISEASE_SPREAD] {num7} troops infected by prisoner hero(es) in {party.Name} ({disease.Name})");
					}
				}
			}
			List<Hero> list2 = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h.PartyBelongedTo == party && !h.IsPrisoner && h.IsAlive).ToList();
			foreach (Hero item in list2)
			{
				DiseaseManager instance = DiseaseManager.Instance;
				if (instance != null && instance.IsHeroInfectedWith(item, disease))
				{
					continue;
				}
				float num8 = WithinPartyBaseChance * (float)num * DiseaseManager.PrisonerSpreadModifier;
				float severityMultiplier = GetSeverityMultiplier(disease);
				float num9 = 1f - GetHeroMedicineResistance(item);
				float num10 = num8 * severityMultiplier * disease.SpreadRate * num9;
				if (_random.NextDouble() < (double)num10)
				{
					DiseaseManager instance2 = DiseaseManager.Instance;
					if (instance2 != null && instance2.InfectHero(item, disease))
					{
						LogMessage($"[DISEASE_SPREAD] {item.Name} infected by prisoner hero with {disease.Name} in {party.Name}");
					}
				}
			}
		}
	}

	public static void CheckAllCaravanInfection()
	{
		IEnumerable<MobileParty> allCaravanParties = (IEnumerable<MobileParty>)MobileParty.AllCaravanParties;
		IEnumerable<MobileParty> enumerable = allCaravanParties ?? ((IEnumerable<MobileParty>)MobileParty.All).Where((MobileParty p) => IsCaravan(p));
		foreach (MobileParty item in enumerable)
		{
			object obj = item.CurrentSettlement;
			if (obj == null)
			{
				Hero leaderHero = item.LeaderHero;
				obj = ((leaderHero != null) ? leaderHero.CurrentSettlement : null);
			}
			Settlement val = (Settlement)obj;
			if (val == null)
			{
				continue;
			}
			List<Disease> list = DiseaseManager.Instance?.GetAllDiseasesForSettlement(val);
			if (list != null && list.Count > 0)
			{
				foreach (Disease item2 in list)
				{
					CheckCaravanInfection(item, val, item2);
				}
			}
			if (item.LeaderHero == null)
			{
				continue;
			}
			DiseaseManager instance = DiseaseManager.Instance;
			if (instance == null || !instance.IsHeroInfected(item.LeaderHero))
			{
				continue;
			}
			DiseaseManager instance2 = DiseaseManager.Instance;
			if (instance2 != null && instance2.IsSettlementUnderQuarantine(val))
			{
				continue;
			}
			List<DiseaseInstance> list2 = DiseaseManager.Instance?.GetHeroDiseases(item.LeaderHero);
			foreach (DiseaseInstance item3 in list2 ?? new List<DiseaseInstance>())
			{
				Disease disease = DiseaseManager.Instance?.GetDiseaseById(item3.DiseaseId);
				if (disease != null)
				{
					LogMessage($"[DISEASE_SPREAD] Infected caravan {item.Name} in {val.Name}, checking spread of {disease.Name} to settlement");
					SpreadDiseaseToSettlement(item, val, disease);
				}
			}
		}
	}

	public static void CheckAllLordInfection()
	{
		foreach (Hero item in ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h.IsLord && h != Hero.MainHero))
		{
			Settlement currentSettlement = item.CurrentSettlement;
			if (currentSettlement == null)
			{
				continue;
			}
			List<Disease> list = DiseaseManager.Instance?.GetAllDiseasesForSettlement(currentSettlement);
			if (list != null && !DiseaseManager.Instance.IsHeroInfected(item))
			{
				foreach (Disease item2 in list)
				{
					CheckLordInfectionInSettlement(item, currentSettlement, item2);
				}
			}
			DiseaseManager instance = DiseaseManager.Instance;
			if (instance == null || !instance.IsHeroInfected(item))
			{
				continue;
			}
			DiseaseManager instance2 = DiseaseManager.Instance;
			if (instance2 != null && instance2.IsSettlementUnderQuarantine(currentSettlement))
			{
				continue;
			}
			List<DiseaseInstance> list2 = DiseaseManager.Instance?.GetHeroDiseases(item);
			foreach (DiseaseInstance item3 in list2 ?? new List<DiseaseInstance>())
			{
				Disease disease = DiseaseManager.Instance?.GetDiseaseById(item3.DiseaseId);
				if (disease != null && !DiseaseManager.Instance.SettlementHasDisease(currentSettlement))
				{
					MobileParty partyBelongedTo = item.PartyBelongedTo;
					LogMessage($"[DISEASE_SPREAD] Infected lord {item.Name} (party {((partyBelongedTo != null) ? partyBelongedTo.Name : null)}) in {currentSettlement.Name}, checking spread of {disease.Name} to settlement");
					SpreadDiseaseToSettlement(partyBelongedTo, currentSettlement, disease);
				}
			}
		}
	}

	public static void CheckAllVillagerPartyInfection()
	{
		IEnumerable<MobileParty> allVillagerParties = (IEnumerable<MobileParty>)MobileParty.AllVillagerParties;
		IEnumerable<MobileParty> enumerable = allVillagerParties ?? ((IEnumerable<MobileParty>)MobileParty.All).Where((MobileParty p) => p != null && p.IsVillager);
		foreach (MobileParty item in enumerable)
		{
			if (((item != null) ? item.MemberRoster : null) == null || item.MemberRoster.TotalRegulars <= 0)
			{
				continue;
			}
			Settlement currentSettlement = item.CurrentSettlement;
			if (currentSettlement == null)
			{
				continue;
			}
			List<Disease> list = DiseaseManager.Instance?.GetAllDiseasesForSettlement(currentSettlement);
			if (list == null || list.Count == 0)
			{
				if (currentSettlement.IsVillage)
				{
					CheckInfectedVillagerPartySpreadToVillage(item, currentSettlement);
				}
				continue;
			}
			foreach (Disease item2 in list)
			{
				CheckVillagerPartyTroopInfection(item, currentSettlement, item2);
			}
		}
	}

	private static void CheckVillagerPartyTroopInfection(MobileParty party, Settlement settlement, Disease disease)
	{
		if (((party != null) ? party.MemberRoster : null) == null || disease == null)
		{
			return;
		}
		int totalRegulars = party.MemberRoster.TotalRegulars;
		if (totalRegulars > 0)
		{
			int num = Math.Max(1, (int)((float)totalRegulars * VillagerPartyTroopInfectionBaseRate));
			float prosperityModifier = GetProsperityModifier(settlement);
			float quarantineModifier = GetQuarantineModifier(settlement);
			int num2 = (int)((float)num * disease.SpreadRate * GetSeverityMultiplier(disease) * prosperityModifier * quarantineModifier);
			if (num2 > 0)
			{
				DiseaseManager.Instance?.InfectPartyTroops(party, disease, num2);
				LogMessage($"[DISEASE_SPREAD] Villager party {party.Name} infected with {disease.Name} in {settlement.Name} ({num2} troops)");
			}
		}
	}

	private static void CheckInfectedVillagerPartySpreadToVillage(MobileParty party, Settlement village)
	{
		if (((party != null) ? party.MemberRoster : null) == null || village == null || !village.IsVillage)
		{
			return;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetPartyDiseases(party);
		if (list == null || list.Count == 0)
		{
			return;
		}
		int totalRegulars = party.MemberRoster.TotalRegulars;
		if (totalRegulars <= 0)
		{
			return;
		}
		foreach (DiseaseInstance item in list)
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
			if (disease == null)
			{
				continue;
			}
			float num = (float)item.InfectedTroopCount / (float)totalRegulars;
			double num2 = CarrierToSettlementBaseChance * num;
			double num3 = num2 * (double)disease.SpreadRate * (double)GetSeverityMultiplier(disease) * (double)GetProsperityModifier(village);
			if (_random.NextDouble() < num3)
			{
				Disease disease2 = DiseaseManager.Instance?.SpreadDiseaseToNewSettlement(disease, village);
				if (disease2 != null)
				{
					LogMessage($"[DISEASE_SPREAD] Infected villager party {party.Name} spread {disease.Name} to village {village.Name} " + $"({item.InfectedTroopCount}/{totalRegulars} infected troops, chance: {num3:P1})");
					InfectVillageFromDisease(village, disease2);
				}
			}
		}
	}

	private static void InfectVillageFromDisease(Settlement village, Disease disease)
	{
		if (village == null || disease == null || !village.IsVillage || village.Notables == null)
		{
			return;
		}
		foreach (Hero item in (List<Hero>)(object)village.Notables)
		{
			if (item != null && item.IsAlive && !item.IsLord)
			{
				DiseaseManager instance = DiseaseManager.Instance;
				if (instance == null || !instance.IsHeroInfected(item))
				{
					CheckNotableInfectionInSettlement(item, village, disease);
				}
			}
		}
	}

	private static void CheckCaravanInfection(MobileParty caravan, Settlement settlement, Disease disease)
	{
		if (caravan == null || settlement == null || disease == null)
		{
			return;
		}
		if (caravan.LeaderHero != null)
		{
			DiseaseManager instance = DiseaseManager.Instance;
			if (instance != null && instance.IsHeroInfectedWith(caravan.LeaderHero, disease))
			{
				return;
			}
			double num = CaravanInfectionBaseChance * disease.SpreadRate * GetSeverityMultiplier(disease) * GetProsperityModifier(settlement) * (1f - GetHeroMedicineResistance(caravan.LeaderHero)) * GetQuarantineModifier(settlement);
			double num2 = _random.NextDouble();
			if (num2 < num)
			{
				DiseaseManager.Instance?.InfectHero(caravan.LeaderHero, disease);
				TroopRoster memberRoster = caravan.MemberRoster;
				if (memberRoster != null && memberRoster.TotalRegulars > 0)
				{
					int num3 = Math.Max(1, (int)((float)caravan.MemberRoster.TotalRegulars * CaravanTroopInfectionRate));
					int infectedCount = Math.Max(1, (int)((float)num3 * disease.SpreadRate * GetSeverityMultiplier(disease)));
					DiseaseManager.Instance?.InfectPartyTroops(caravan, disease, infectedCount);
				}
				LogMessage($"[DISEASE_SPREAD] Caravan {caravan.Name} infected with {disease.Name} in {settlement.Name}");
			}
			return;
		}
		TroopRoster memberRoster2 = caravan.MemberRoster;
		if (memberRoster2 != null && memberRoster2.TotalRegulars > 0 && DiseaseManager.Instance?.GetPartyDiseaseInstance(caravan, disease) == null)
		{
			double num4 = CaravanInfectionBaseChance * disease.SpreadRate * GetSeverityMultiplier(disease) * GetProsperityModifier(settlement) * GetQuarantineModifier(settlement);
			if (_random.NextDouble() < num4)
			{
				int num5 = Math.Max(1, (int)((float)caravan.MemberRoster.TotalRegulars * CaravanTroopInfectionRate));
				int infectedCount2 = Math.Max(1, (int)((float)num5 * disease.SpreadRate * GetSeverityMultiplier(disease)));
				DiseaseManager.Instance?.InfectPartyTroops(caravan, disease, infectedCount2);
				LogMessage($"[DISEASE_SPREAD] Caravan {caravan.Name} (no leader) troops infected with {disease.Name} in {settlement.Name}");
			}
		}
	}

	public static void CheckAllNotableInfection()
	{
		foreach (Settlement item in ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsTown || s.IsCastle || s.IsVillage))
		{
			List<Disease> list = DiseaseManager.Instance?.GetAllDiseasesForSettlement(item);
			if (list == null || list.Count == 0 || item.Notables == null)
			{
				continue;
			}
			foreach (Hero item2 in (List<Hero>)(object)item.Notables)
			{
				if (item2 == null || !item2.IsAlive || item2.IsLord)
				{
					continue;
				}
				DiseaseManager instance = DiseaseManager.Instance;
				if (instance != null && instance.IsHeroInfected(item2))
				{
					continue;
				}
				foreach (Disease item3 in list)
				{
					CheckNotableInfectionInSettlement(item2, item, item3);
				}
			}
		}
	}

	private static void CheckNotableInfectionInSettlement(Hero notable, Settlement settlement, Disease disease)
	{
		if (notable != null && settlement != null && disease != null)
		{
			double num = NotableInfectionBaseChance * disease.SpreadRate * GetSeverityMultiplier(disease) * GetProsperityModifier(settlement) * (1f - GetHeroMedicineResistance(notable)) * GetQuarantineModifier(settlement);
			double num2 = _random.NextDouble();
			if (num2 < num)
			{
				DiseaseManager.Instance?.InfectHero(notable, disease);
				LogMessage($"[DISEASE_SPREAD] {notable.Name} ({SeasonalDiseaseSystem.GetHeroTypeTag(notable)}) infected with {disease.Name} in {settlement.Name}");
			}
		}
	}

	private static void CheckLordInfectionInSettlement(Hero lord, Settlement settlement, Disease disease)
	{
		double num = LordInfectionBaseChance * disease.SpreadRate * GetSeverityMultiplier(disease) * GetProsperityModifier(settlement) * (1f - GetHeroMedicineResistance(lord)) * GetQuarantineModifier(settlement);
		double num2 = _random.NextDouble();
		if (!(num2 < num))
		{
			return;
		}
		DiseaseManager.Instance?.InfectHero(lord, disease);
		MobileParty partyBelongedTo = lord.PartyBelongedTo;
		if (partyBelongedTo != null)
		{
			TroopRoster memberRoster = partyBelongedTo.MemberRoster;
			if (((memberRoster != null) ? new int?(memberRoster.TotalRegulars) : ((int?)null)) > 0)
			{
				int num3 = Math.Max(1, (int)((float)lord.PartyBelongedTo.MemberRoster.TotalRegulars * LordTroopInfectionRate));
				int infectedCount = Math.Max(1, (int)((float)num3 * disease.SpreadRate * GetSeverityMultiplier(disease)));
				DiseaseManager.Instance?.InfectPartyTroops(lord.PartyBelongedTo, disease, infectedCount);
			}
		}
		LogMessage($"[DISEASE_SPREAD] {lord.Name} ({SeasonalDiseaseSystem.GetHeroTypeTag(lord)}) infected with {disease.Name} in {settlement.Name}");
	}

	private static void SpreadDiseaseToSettlement(MobileParty carrier, Settlement settlement, Disease disease)
	{
		if (carrier == null || settlement == null || disease == null)
		{
			return;
		}
		DiseaseManager instance = DiseaseManager.Instance;
		if (instance != null && instance.SettlementHasDisease(settlement))
		{
			return;
		}
		DiseaseManager instance2 = DiseaseManager.Instance;
		if (instance2 != null && instance2.IsSettlementUnderQuarantine(settlement))
		{
			return;
		}
		double num = CarrierToSettlementBaseChance * disease.SpreadRate * GetSeverityMultiplier(disease) * GetProsperityModifier(settlement);
		double num2 = _random.NextDouble();
		if (num2 < num)
		{
			Disease disease2 = DiseaseManager.Instance?.SpreadDiseaseToNewSettlement(disease, settlement);
			if (disease2 != null)
			{
				LogMessage($"[DISEASE_SPREAD] {((carrier != null) ? carrier.Name : null)} spread {disease.Name} to {settlement.Name} (new disease ID: {disease2.Id})");
			}
		}
	}

	public static void CheckSettlementMilitiaAndGarrisonInfection(Settlement settlement, Disease disease)
	{
		if (settlement == null || disease == null)
		{
			return;
		}
		int num = (int)settlement.Militia;
		Town town = settlement.Town;
		int? obj;
		if (town == null)
		{
			obj = null;
		}
		else
		{
			MobileParty garrisonParty = ((Fief)town).GarrisonParty;
			if (garrisonParty == null)
			{
				obj = null;
			}
			else
			{
				TroopRoster memberRoster = garrisonParty.MemberRoster;
				obj = ((memberRoster != null) ? new int?(memberRoster.TotalManCount) : ((int?)null));
			}
		}
		int? num2 = obj;
		int valueOrDefault = num2.GetValueOrDefault();
		if (ImmunitySystem.CheckSettlementImmunity(settlement, disease))
		{
			LogMessage($"[DISEASE_SPREAD] Settlement {settlement.Name} has immunity to {disease.Name}, skipping garrison/militia infection");
			return;
		}
		if (settlement.Militia > 0f)
		{
			SettlementDiseaseInstance settlementDiseaseInstance = DiseaseManager.Instance?.GetSettlementDiseaseInstance(settlement, "militia");
			if (settlementDiseaseInstance == null)
			{
				double num3 = MilitiaInfectionBaseChance * disease.SpreadRate * GetSeverityMultiplier(disease) * GetProsperityModifier(settlement) * GetQuarantineModifier(settlement) * (1f - DiseasePerkBonuses.GetSettlementSpreadReduction(settlement));
				double num4 = _random.NextDouble();
				if (num4 < num3)
				{
					SettlementDiseaseInstance settlementDiseaseInstance2 = DiseaseManager.Instance?.CreateSettlementDiseaseInstance(settlement, disease, "militia");
					if (settlementDiseaseInstance2 != null)
					{
						settlementDiseaseInstance2.InfectedPercentage = MilitiaInitialInfectedPercent;
						settlementDiseaseInstance2.UpdateMilitiaInfectedCount(settlement.Militia);
						LogMessage($"[DISEASE_SPREAD] Militia infected in {settlement.Name}");
					}
				}
			}
		}
		Town town2 = settlement.Town;
		if (town2 == null)
		{
			return;
		}
		MobileParty garrisonParty2 = ((Fief)town2).GarrisonParty;
		int? obj2;
		if (garrisonParty2 == null)
		{
			obj2 = null;
		}
		else
		{
			TroopRoster memberRoster2 = garrisonParty2.MemberRoster;
			obj2 = ((memberRoster2 != null) ? new int?(memberRoster2.TotalManCount) : ((int?)null));
		}
		if (!(obj2 > 0))
		{
			return;
		}
		SettlementDiseaseInstance settlementDiseaseInstance3 = DiseaseManager.Instance?.GetSettlementDiseaseInstance(settlement, "garrison");
		if (settlementDiseaseInstance3 != null)
		{
			return;
		}
		double num5 = GarrisonInfectionBaseChance * disease.SpreadRate * GetSeverityMultiplier(disease) * GetProsperityModifier(settlement) * GetQuarantineModifier(settlement) * (1f - DiseasePerkBonuses.GetSettlementSpreadReduction(settlement));
		double num6 = _random.NextDouble();
		if (num6 < num5)
		{
			SettlementDiseaseInstance settlementDiseaseInstance4 = DiseaseManager.Instance?.CreateSettlementDiseaseInstance(settlement, disease, "garrison");
			if (settlementDiseaseInstance4 != null)
			{
				int totalManCount = ((Fief)settlement.Town).GarrisonParty.MemberRoster.TotalManCount;
				settlementDiseaseInstance4.InfectedCount = Math.Max(1, (int)((float)totalManCount * GarrisonInitialInfectedPercent / 100f));
				LogMessage($"[DISEASE_SPREAD] Garrison infected in {settlement.Name}");
			}
		}
	}

	public static void CheckAllSettlementEpidemics()
	{
		foreach (Settlement item in ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsTown || s.IsCastle))
		{
			CheckSettlementEpidemic(item);
		}
	}

	public static void CheckSettlementEpidemic(Settlement settlement)
	{
		if (settlement == null)
		{
			return;
		}
		Disease disease = DiseaseManager.Instance?.GetDiseaseForSettlement(settlement);
		if (disease != null && disease.IsQuarantined)
		{
			return;
		}
		List<Hero> infectedHeroesInSettlement = GetInfectedHeroesInSettlement(settlement);
		if (infectedHeroesInSettlement.Count < EpidemicMinInfectedHeroes)
		{
			return;
		}
		List<Disease> diseasesFromInfectedHeroes = GetDiseasesFromInfectedHeroes(infectedHeroesInSettlement);
		if (diseasesFromInfectedHeroes.Count > 0)
		{
			Disease sourceDisease = SelectRandomDiseaseForEpidemic(diseasesFromInfectedHeroes);
			if (!DiseaseManager.Instance.SettlementHasDisease(settlement))
			{
				CreateEpidemicInSettlement(settlement, sourceDisease);
			}
		}
	}

	public static List<Hero> GetInfectedHeroesInSettlement(Settlement settlement)
	{
		List<Hero> list = new List<Hero>();
		if (settlement == null)
		{
			return list;
		}
		foreach (Hero item in (List<Hero>)(object)Hero.AllAliveHeroes)
		{
			if (item.CurrentSettlement == settlement)
			{
				DiseaseManager instance = DiseaseManager.Instance;
				if (instance != null && instance.IsHeroInfected(item))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	public static List<Disease> GetDiseasesFromInfectedHeroes(List<Hero> infectedHeroes)
	{
		List<Disease> list = new List<Disease>();
		HashSet<string> hashSet = new HashSet<string>();
		foreach (Hero infectedHero in infectedHeroes)
		{
			List<DiseaseInstance> list2 = DiseaseManager.Instance?.GetHeroDiseases(infectedHero);
			if (list2 == null)
			{
				continue;
			}
			foreach (DiseaseInstance item in list2)
			{
				if (!hashSet.Contains(item.DiseaseId))
				{
					Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
					if (disease != null)
					{
						list.Add(disease);
						hashSet.Add(item.DiseaseId);
					}
				}
			}
		}
		return list;
	}

	public static Disease SelectRandomDiseaseForEpidemic(List<Disease> diseases)
	{
		if (diseases == null || diseases.Count == 0)
		{
			return null;
		}
		return diseases[_random.Next(diseases.Count)];
	}

	public static void CreateEpidemicInSettlement(Settlement settlement, Disease sourceDisease)
	{
		if (settlement != null && sourceDisease != null)
		{
			Disease disease = DiseaseManager.Instance?.SpreadDiseaseToNewSettlement(sourceDisease, settlement);
			if (disease != null)
			{
				LogMessage($"[DISEASE_SPREAD] EPIDEMIC started in {settlement.Name} - disease: {sourceDisease.Name} " + $"(triggered by {EpidemicMinInfectedHeroes}+ infected heroes, new disease ID: {disease.Id})");
			}
		}
	}

	public static bool IsCaravan(MobileParty party)
	{
		return party != null && party.IsCaravan;
	}

	public static bool IsLordParty(MobileParty party)
	{
		int result;
		if (party == null)
		{
			result = 0;
		}
		else
		{
			Hero leaderHero = party.LeaderHero;
			result = ((((leaderHero != null) ? new bool?(leaderHero.IsLord) : ((bool?)null)) == true) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	internal static void CheckSingleCaravanInfection(MobileParty party)
	{
		if (party == null)
		{
			return;
		}
		object obj = party.CurrentSettlement;
		if (obj == null)
		{
			Hero leaderHero = party.LeaderHero;
			obj = ((leaderHero != null) ? leaderHero.CurrentSettlement : null);
		}
		Settlement val = (Settlement)obj;
		if (val == null)
		{
			return;
		}
		List<Disease> list = DiseaseManager.Instance?.GetAllDiseasesForSettlement(val);
		if (list != null && list.Count > 0)
		{
			foreach (Disease item in list)
			{
				CheckCaravanInfection(party, val, item);
			}
		}
		if (party.LeaderHero == null)
		{
			return;
		}
		DiseaseManager instance = DiseaseManager.Instance;
		if (instance == null || !instance.IsHeroInfected(party.LeaderHero))
		{
			return;
		}
		DiseaseManager instance2 = DiseaseManager.Instance;
		if (instance2 != null && instance2.IsSettlementUnderQuarantine(val))
		{
			return;
		}
		List<DiseaseInstance> list2 = DiseaseManager.Instance?.GetHeroDiseases(party.LeaderHero);
		foreach (DiseaseInstance item2 in list2 ?? new List<DiseaseInstance>())
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item2.DiseaseId);
			if (disease != null)
			{
				SpreadDiseaseToSettlement(party, val, disease);
			}
		}
	}

	internal static void CheckSingleVillagerPartyInfection(MobileParty party)
	{
		if (((party != null) ? party.MemberRoster : null) == null || party.MemberRoster.TotalManCount <= 0)
		{
			return;
		}
		Settlement currentSettlement = party.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		List<Disease> list = DiseaseManager.Instance?.GetAllDiseasesForSettlement(currentSettlement);
		if (list == null || list.Count == 0)
		{
			if (currentSettlement.IsVillage)
			{
				CheckInfectedVillagerPartySpreadToVillage(party, currentSettlement);
			}
			return;
		}
		foreach (Disease item in list)
		{
			CheckVillagerPartyTroopInfection(party, currentSettlement, item);
		}
	}

	internal static void CheckSingleLordInfection(Hero lord)
	{
		if (lord == null || !lord.IsAlive)
		{
			return;
		}
		Settlement currentSettlement = lord.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		List<Disease> list = DiseaseManager.Instance?.GetAllDiseasesForSettlement(currentSettlement);
		if (list != null && !DiseaseManager.Instance.IsHeroInfected(lord))
		{
			foreach (Disease item in list)
			{
				CheckLordInfectionInSettlement(lord, currentSettlement, item);
			}
		}
		DiseaseManager instance = DiseaseManager.Instance;
		if (instance == null || !instance.IsHeroInfected(lord))
		{
			return;
		}
		DiseaseManager instance2 = DiseaseManager.Instance;
		if (instance2 != null && instance2.IsSettlementUnderQuarantine(currentSettlement))
		{
			return;
		}
		List<DiseaseInstance> list2 = DiseaseManager.Instance?.GetHeroDiseases(lord);
		foreach (DiseaseInstance item2 in list2 ?? new List<DiseaseInstance>())
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item2.DiseaseId);
			if (disease != null && !DiseaseManager.Instance.SettlementHasDisease(currentSettlement))
			{
				SpreadDiseaseToSettlement(lord.PartyBelongedTo, currentSettlement, disease);
			}
		}
	}

	internal static void CheckSettlementNotableInfection(Settlement settlement)
	{
		if (settlement == null || settlement.Notables == null)
		{
			return;
		}
		List<Disease> list = DiseaseManager.Instance?.GetAllDiseasesForSettlement(settlement);
		if (list == null || list.Count == 0)
		{
			return;
		}
		foreach (Hero item in (List<Hero>)(object)settlement.Notables)
		{
			if (item == null || !item.IsAlive || item.IsLord)
			{
				continue;
			}
			DiseaseManager instance = DiseaseManager.Instance;
			if (instance != null && instance.IsHeroInfected(item))
			{
				continue;
			}
			foreach (Disease item2 in list)
			{
				CheckNotableInfectionInSettlement(item, settlement, item2);
			}
		}
	}

	internal static void CheckSingleWandererInfection(Hero wanderer)
	{
		if (wanderer == null || !wanderer.IsAlive)
		{
			return;
		}
		Settlement currentSettlement = wanderer.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		List<Disease> list = DiseaseManager.Instance?.GetAllDiseasesForSettlement(currentSettlement);
		if (list == null || list.Count == 0)
		{
			return;
		}
		DiseaseManager instance = DiseaseManager.Instance;
		if (instance != null && instance.IsHeroInfected(wanderer))
		{
			return;
		}
		foreach (Disease item in list)
		{
			CheckNotableInfectionInSettlement(wanderer, currentSettlement, item);
		}
	}

	private static void LogMessage(string message)
	{
		DiseaseLogger.Instance?.Log(message);
	}
}
