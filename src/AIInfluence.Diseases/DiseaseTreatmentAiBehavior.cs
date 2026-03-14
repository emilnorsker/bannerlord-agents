using System;
using System.Collections.Generic;
using Helpers;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence.Diseases;

public class DiseaseTreatmentAiBehavior : CampaignBehaviorBase
{
	private const float BaseTreatmentScore = 3f;

	private const float MaxTreatmentScore = 10f;

	private const float MaxDistanceDays = 3f;

	public override void RegisterEvents()
	{
		CampaignEvents.AiHourlyTickEvent.AddNonSerializedListener((object)this, (Action<MobileParty, PartyThinkParams>)OnAiHourlyTick);
	}

	public override void SyncData(IDataStore dataStore)
	{
	}

	private void OnAiHourlyTick(MobileParty mobileParty, PartyThinkParams p)
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Invalid comparison between Unknown and I4
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem || !ShouldConsiderParty(mobileParty))
		{
			return;
		}
		DiseaseManager instance2 = DiseaseManager.Instance;
		if (instance2 == null)
		{
			return;
		}
		bool flag = instance2.IsHeroInfected(mobileParty.LeaderHero);
		bool flag2 = instance2.PartyHasInfectedTroops(mobileParty);
		if (!flag && !flag2)
		{
			return;
		}
		float num = CalculateTreatmentUrgency(mobileParty, instance2);
		if (num <= 0f)
		{
			return;
		}
		Village val = SettlementHelper.FindNearestVillageToMobileParty(mobileParty, mobileParty.NavigationCapability, (Func<Settlement, bool>)((Settlement s) => IsVillageSuitableForTreatment(mobileParty, s)));
		if (((val != null) ? ((SettlementComponent)val).Settlement : null) == null)
		{
			return;
		}
		Settlement settlement = ((SettlementComponent)val).Settlement;
		NavigationType val2 = default(NavigationType);
		bool flag3 = default(bool);
		float num2 = default(float);
		AiHelper.GetBestNavigationTypeAndAdjustedDistanceOfSettlementForMobileParty(mobileParty, settlement, false, out val2, out num2, out flag3);
		if ((int)val2 == 0)
		{
			return;
		}
		float num3 = num2 / (Campaign.Current.EstimatedAverageLordPartySpeed * (float)CampaignTime.HoursInDay);
		if (num3 > 3f)
		{
			return;
		}
		bool flag4 = false;
		if (settlement.HasPort && mobileParty.HasNavalNavigationCapability)
		{
			NavigationType val3 = default(NavigationType);
			float num4 = default(float);
			bool flag5 = default(bool);
			AiHelper.GetBestNavigationTypeAndAdjustedDistanceOfSettlementForMobileParty(mobileParty, settlement, true, out val3, out num4, out flag5);
			if ((int)val3 != 0 && num4 < num2)
			{
				val2 = val3;
				num2 = num4;
				flag3 = flag5;
				flag4 = true;
			}
		}
		float val4 = num * (1f - num3 / 6f);
		val4 = Math.Max(0.5f, Math.Min(10f, val4));
		AIBehaviorData item = default(AIBehaviorData);
		item = new AIBehaviorData((IMapPoint)(object)settlement, (AiBehavior)2, val2, false, flag3, flag4);
		float num5 = default(float);
		if (p.TryGetBehaviorScore(ref item, ref num5))
		{
			p.SetBehaviorScore(ref item, num5 + val4);
		}
		else
		{
			(AIBehaviorData, float) tuple = (item, val4);
			p.AddBehaviorScore(ref tuple);
		}
		instance2.MarkPartyGoingForTreatment(mobileParty, settlement);
	}

	private static bool ShouldConsiderParty(MobileParty mobileParty)
	{
		if (mobileParty == null || mobileParty.LeaderHero == null)
		{
			return false;
		}
		if (mobileParty.IsBandit || mobileParty.IsMilitia || mobileParty.IsCaravan || mobileParty.IsPatrolParty || mobileParty.IsVillager)
		{
			return false;
		}
		IFaction mapFaction = mobileParty.MapFaction;
		if (mapFaction == null)
		{
			return false;
		}
		if (!mapFaction.IsMinorFaction && !mapFaction.IsKingdomFaction)
		{
			return false;
		}
		if (!mobileParty.LeaderHero.IsLord)
		{
			return false;
		}
		if (mobileParty.Army != null && mobileParty.Army.LeaderParty != mobileParty)
		{
			return false;
		}
		if (mobileParty.CurrentSettlement != null)
		{
			return false;
		}
		return true;
	}

	private static bool IsVillageSuitableForTreatment(MobileParty mobileParty, Settlement settlement)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		if (settlement == null || !settlement.IsVillage)
		{
			return false;
		}
		if (settlement.Party.MapEvent != null)
		{
			return false;
		}
		if (settlement.Party.SiegeEvent != null && settlement.Party.SiegeEvent.IsBlockadeActive && !mobileParty.HasNavalNavigationCapability)
		{
			return false;
		}
		Village village = settlement.Village;
		if (village == null || (int)village.VillageState > 0)
		{
			return false;
		}
		PartyBase party = mobileParty.Party;
		object obj;
		if (party == null)
		{
			obj = null;
		}
		else
		{
			Hero owner = party.Owner;
			obj = ((owner != null) ? owner.MapFaction : null);
		}
		IFaction val = (IFaction)obj;
		if (val == null)
		{
			return true;
		}
		if (!val.IsAtWarWith(settlement.MapFaction))
		{
			return true;
		}
		Hero leaderHero = mobileParty.LeaderHero;
		int? obj2;
		if (leaderHero == null)
		{
			obj2 = null;
		}
		else
		{
			Clan clan = leaderHero.Clan;
			obj2 = ((clan == null) ? ((int?)null) : ((List<Settlement>)(object)clan.Settlements)?.Count);
		}
		int? num = obj2;
		bool flag = num.GetValueOrDefault() == 0;
		return val.IsMinorFaction || flag;
	}

	private static float CalculateTreatmentUrgency(MobileParty mobileParty, DiseaseManager dm)
	{
		float num = 0f;
		int num2 = 1;
		if (mobileParty.LeaderHero != null)
		{
			foreach (DiseaseInstance heroDisease in dm.GetHeroDiseases(mobileParty.LeaderHero))
			{
				if (!heroDisease.IsTreated && !heroDisease.HasPostTreatmentEffect)
				{
					num = Math.Max(num, heroDisease.DiseaseProgress);
					Disease diseaseById = dm.GetDiseaseById(heroDisease.DiseaseId);
					if (diseaseById != null)
					{
						num2 = Math.Max(num2, diseaseById.Severity);
					}
				}
			}
		}
		List<DiseaseInstance> partyDiseases = dm.GetPartyDiseases(mobileParty);
		foreach (DiseaseInstance item in partyDiseases)
		{
			if (!item.IsTreated && !item.IsRecovered && !item.HasPostTreatmentEffect)
			{
				num = Math.Max(num, item.DiseaseProgress);
				Disease diseaseById2 = dm.GetDiseaseById(item.DiseaseId);
				if (diseaseById2 != null)
				{
					num2 = Math.Max(num2, diseaseById2.Severity);
				}
			}
		}
		if (num <= 0f)
		{
			return 0f;
		}
		float num3 = Math.Min(1f, num / 50f);
		float num4 = 0.5f + (float)num2 / 5f * 0.5f;
		return 3f + 7f * num3 * num4;
	}
}
