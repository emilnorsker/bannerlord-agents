using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(DefaultMarriageModel))]
public class MarriageRomanceProtectionPatch
{
	[HarmonyPatch("NpcCoupleMarriageChance")]
	[HarmonyPrefix]
	public static bool NpcCoupleMarriageChance_Prefix(Hero firstHero, Hero secondHero, ref float __result)
	{
		try
		{
			if (firstHero == null || secondHero == null)
			{
				return true;
			}
			Hero val = null;
			Hero val2 = null;
			if (firstHero.IsHumanPlayerCharacter)
			{
				val = firstHero;
				val2 = secondHero;
			}
			else if (secondHero.IsHumanPlayerCharacter)
			{
				val = secondHero;
				val2 = firstHero;
			}
			if (val != null && val2 != null)
			{
				AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
				if (instance != null)
				{
					NPCContext nPCContextByStringId = instance.GetNPCContextByStringId(((MBObjectBase)val2).StringId);
					if (nPCContextByStringId != null && nPCContextByStringId.RomanceLevel > 15f)
					{
						__result = 0f;
						instance.LogMessage($"[MARRIAGE_PROTECTION] Blocked vanilla marriage between {val.Name} and {val2.Name} - RomanceLevel is {nPCContextByStringId.RomanceLevel:F1} (> 15)");
						return false;
					}
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[MARRIAGE_PROTECTION] Error in prefix patch: " + ex.Message);
			return true;
		}
	}
}
