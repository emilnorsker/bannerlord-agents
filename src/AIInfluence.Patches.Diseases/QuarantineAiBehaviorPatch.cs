using System.Collections.Generic;
using System.Linq;
using AIInfluence.Diseases;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CampaignBehaviors.AiBehaviors;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch]
public static class QuarantineAiBehaviorPatch
{
	[HarmonyPatch(typeof(AiVisitSettlementBehavior), "AiHourlyTick")]
	public class AiVisitSettlement_AiHourlyTick_Patch
	{
		[HarmonyPostfix]
		public static void Postfix(MobileParty mobileParty, PartyThinkParams p)
		{
			if (mobileParty == null || p == null)
			{
				return;
			}
			ModSettings instance = GlobalSettings<ModSettings>.Instance;
			if (instance == null || !instance.EnableDiseaseSystem || DiseaseManager.Instance == null)
			{
				return;
			}
			if (mobileParty.CurrentSettlement != null && ShouldBlockPartyFromLeaving(mobileParty))
			{
				Settlement currentSettlement = mobileParty.CurrentSettlement;
				List<(AIBehaviorData, float)> list = ((IEnumerable<(AIBehaviorData, float)>)p.AIBehaviorScores).Where(((AIBehaviorData, float) s) => (int)s.Item1.AiBehavior != 2 || true).ToList();
				{
					foreach (var item in list)
					{
						((List<(AIBehaviorData, float)>)(object)p.AIBehaviorScores).Remove(item);
					}
					return;
				}
			}
			List<(AIBehaviorData, float)> list2 = ((IEnumerable<(AIBehaviorData, float)>)p.AIBehaviorScores).Where(delegate((AIBehaviorData, float) s)
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Invalid comparison between Unknown and I4
				//IL_001b: Unknown result type (might be due to invalid IL or missing references)
				if ((int)s.Item1.AiBehavior != 2)
				{
					return false;
				}
				IMapPoint party = s.Item1.Party;
				Settlement val = (Settlement)(object)((party is Settlement) ? party : null);
				return val != null && ShouldBlockPartyFromSettlement(mobileParty, val);
			}).ToList();
			foreach (var item2 in list2)
			{
				((List<(AIBehaviorData, float)>)(object)p.AIBehaviorScores).Remove(item2);
			}
		}
	}

	[HarmonyPatch(typeof(SetPartyAiAction), "GetActionForVisitingSettlement")]
	public class SetPartyAiAction_VisitSettlement_Patch
	{
		[HarmonyPrefix]
		public static bool Prefix(MobileParty owner, Settlement settlement)
		{
			if (owner == null || settlement == null)
			{
				return true;
			}
			if (owner == MobileParty.MainParty)
			{
				return true;
			}
			if (ShouldBlockPartyFromSettlement(owner, settlement))
			{
				return false;
			}
			return true;
		}
	}

	[HarmonyPatch(typeof(MobileParty), "SetMoveGoToSettlement")]
	public class MobileParty_SetMoveGoToSettlement_Patch
	{
		[HarmonyPrefix]
		public static bool Prefix(MobileParty __instance, Settlement settlement)
		{
			if (__instance == null)
			{
				return true;
			}
			if (__instance == MobileParty.MainParty)
			{
				return true;
			}
			if (__instance.CurrentSettlement != null && __instance.CurrentSettlement != settlement && ShouldBlockPartyFromLeaving(__instance))
			{
				return false;
			}
			if (ShouldBlockPartyFromSettlement(__instance, settlement))
			{
				return false;
			}
			return true;
		}
	}

	[HarmonyPatch(typeof(SetPartyAiAction), "GetActionForPatrollingAroundSettlement")]
	public class SetPartyAiAction_PatrolSettlement_Patch
	{
		[HarmonyPrefix]
		public static bool Prefix(MobileParty owner, Settlement settlement)
		{
			if (owner == null || settlement == null)
			{
				return true;
			}
			if (owner == MobileParty.MainParty)
			{
				return true;
			}
			if (owner.CurrentSettlement != null && owner.CurrentSettlement != settlement && ShouldBlockPartyFromLeaving(owner))
			{
				return false;
			}
			return true;
		}
	}

	private static bool ShouldBlockPartyFromSettlement(MobileParty party, Settlement settlement)
	{
		if (party == null || settlement == null)
		{
			return false;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return false;
		}
		DiseaseManager instance2 = DiseaseManager.Instance;
		if (instance2 == null)
		{
			return false;
		}
		if (!instance2.IsSettlementUnderQuarantine(settlement))
		{
			return false;
		}
		if (instance2.IsPartyExemptFromQuarantine(party, settlement))
		{
			return false;
		}
		if (instance2.IsPartyHostileToSettlement(party, settlement))
		{
			return false;
		}
		return true;
	}

	private static bool ShouldBlockPartyFromLeaving(MobileParty party)
	{
		if (party == null)
		{
			return false;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return false;
		}
		DiseaseManager instance2 = DiseaseManager.Instance;
		if (instance2 == null)
		{
			return false;
		}
		Settlement currentSettlement = party.CurrentSettlement;
		if (currentSettlement == null)
		{
			return false;
		}
		if (!instance2.IsSettlementUnderQuarantine(currentSettlement))
		{
			return false;
		}
		if (instance2.IsPartyExemptFromQuarantine(party, currentSettlement))
		{
			return false;
		}
		if (party.LeaderHero != null && !instance2.IsHeroInfected(party.LeaderHero))
		{
			return false;
		}
		if (party.LeaderHero == null && !instance2.PartyHasInfectedTroops(party))
		{
			return false;
		}
		return true;
	}
}
