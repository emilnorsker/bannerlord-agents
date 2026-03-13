using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public static class DiplomacyPatches
{
	private static bool _patchesApplied;

	private static int _bypassCounter;

	public static void WithBypass(Action action)
	{
		_bypassCounter++;
		try
		{
			action?.Invoke();
		}
		finally
		{
			_bypassCounter--;
		}
	}

	private static void TryPatchMethod(Harmony harmony, Type type, string methodName, MethodInfo prefix)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		try
		{
			MethodInfo methodInfo = AccessTools.Method(type, methodName, (Type[])null, (Type[])null);
			if (methodInfo != null && prefix != null)
			{
				harmony.Patch((MethodBase)methodInfo, new HarmonyMethod(prefix), (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null);
				LogMessage("[DIPLOMACY_PATCHES] Patched " + type.Name + "." + methodName);
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] WARNING: Failed to patch " + type?.Name + "." + methodName + ": " + ex.Message);
		}
	}

	private static void CalculateClanGoldChange_Postfix(Clan clan, bool includeDescriptions, bool applyWithdrawals, bool includeDetails, ref ExplainedNumber __result)
	{
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy || !includeDescriptions || clan == null || clan != Clan.PlayerClan)
			{
				return;
			}
			Kingdom kingdom = clan.Kingdom;
			if (kingdom == null)
			{
				return;
			}
			TributeSystem instance = TributeSystem.Instance;
			if (instance == null)
			{
				return;
			}
			List<TributeAgreement> tributesPaidBy = instance.GetTributesPaidBy(kingdom);
			List<TributeAgreement> tributesReceivedBy = instance.GetTributesReceivedBy(kingdom);
			bool flag = tributesPaidBy != null && tributesPaidBy.Count > 0;
			bool flag2 = tributesReceivedBy != null && tributesReceivedBy.Count > 0;
			if (!flag && !flag2)
			{
				return;
			}
			if (flag)
			{
				foreach (TributeAgreement tribute in tributesPaidBy)
				{
					Kingdom val = ((List<Kingdom>)(object)Kingdom.All).Find((Predicate<Kingdom>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute.ReceiverKingdomId));
					TextObject val2 = new TextObject("{=AIInfluence_TributePaidTooltip}Tribute payment to {KINGDOM}", (Dictionary<string, object>)null);
					val2.SetTextVariable("KINGDOM", (val != null) ? val.Name : TextObject.GetEmpty());
					if (tribute.DailyAmount > 0)
					{
						((ExplainedNumber)(ref __result)).Add(0f - (float)tribute.DailyAmount, val2, (TextObject)null);
					}
				}
			}
			if (!flag2)
			{
				return;
			}
			foreach (TributeAgreement tribute2 in tributesReceivedBy)
			{
				Kingdom val3 = ((List<Kingdom>)(object)Kingdom.All).Find((Predicate<Kingdom>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute2.PayerKingdomId));
				TextObject val4 = new TextObject("{=AIInfluence_TributeReceivedTooltip}Tribute received from {KINGDOM}", (Dictionary<string, object>)null);
				val4.SetTextVariable("KINGDOM", (val3 != null) ? val3.Name : TextObject.GetEmpty());
				if (tribute2.DailyAmount > 0)
				{
					((ExplainedNumber)(ref __result)).Add((float)tribute2.DailyAmount, val4, (TextObject)null);
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in CalculateClanGoldChange_Postfix: " + ex.Message);
		}
	}

	public static void ApplyPatches(Harmony harmony)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Expected O, but got Unknown
		if (_patchesApplied)
		{
			LogMessage("[DIPLOMACY_PATCHES] Patches already applied, skipping");
			return;
		}
		try
		{
			LogMessage("[DIPLOMACY_PATCHES] Applying Harmony patches for diplomacy system...");
			MethodInfo methodInfo = AccessTools.Method(typeof(KingdomDecisionProposalBehavior), "ConsiderWar", (Type[])null, (Type[])null);
			MethodInfo methodInfo2 = AccessTools.Method(typeof(DiplomacyPatches), "ConsiderWar_Prefix", (Type[])null, (Type[])null);
			if (methodInfo != null && methodInfo2 != null)
			{
				harmony.Patch((MethodBase)methodInfo, new HarmonyMethod(methodInfo2), (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null);
				LogMessage("[DIPLOMACY_PATCHES] Patched KingdomDecisionProposalBehavior.ConsiderWar");
			}
			else
			{
				LogMessage("[DIPLOMACY_PATCHES] WARNING: Could not find ConsiderWar method to patch");
			}
			MethodInfo methodInfo3 = AccessTools.Method(typeof(KingdomDecisionProposalBehavior), "ConsiderPeace", (Type[])null, (Type[])null);
			MethodInfo methodInfo4 = null;
			if (methodInfo3 != null)
			{
				ParameterInfo[] parameters = methodInfo3.GetParameters();
				if (parameters.Length == 4)
				{
					methodInfo4 = AccessTools.Method(typeof(DiplomacyPatches), "ConsiderPeace_132_Prefix", (Type[])null, (Type[])null);
					LogMessage("[DIPLOMACY_PATCHES] Detected v1.3.2 ConsiderPeace signature (4 parameters)");
				}
				else if (parameters.Length == 3)
				{
					methodInfo4 = AccessTools.Method(typeof(DiplomacyPatches), "ConsiderPeace_Prefix", (Type[])null, (Type[])null);
					LogMessage("[DIPLOMACY_PATCHES] Detected v1.3.1 ConsiderPeace signature (3 parameters)");
				}
				else
				{
					LogMessage($"[DIPLOMACY_PATCHES] WARNING: Unknown ConsiderPeace signature with {parameters.Length} parameters");
				}
			}
			if (methodInfo3 != null && methodInfo4 != null)
			{
				harmony.Patch((MethodBase)methodInfo3, new HarmonyMethod(methodInfo4), (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null);
				LogMessage("[DIPLOMACY_PATCHES] Patched KingdomDecisionProposalBehavior.ConsiderPeace");
			}
			else
			{
				LogMessage("[DIPLOMACY_PATCHES] WARNING: Could not find ConsiderPeace method to patch");
			}
			MethodInfo methodInfo5 = AccessTools.Method(typeof(KingdomDecisionProposalBehavior), "ConsiderTradeAgreement", (Type[])null, (Type[])null);
			MethodInfo methodInfo6 = AccessTools.Method(typeof(DiplomacyPatches), "ConsiderTradeAgreement_Prefix", (Type[])null, (Type[])null);
			if (methodInfo5 != null && methodInfo6 != null)
			{
				harmony.Patch((MethodBase)methodInfo5, new HarmonyMethod(methodInfo6), (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null);
				LogMessage("[DIPLOMACY_PATCHES] Patched KingdomDecisionProposalBehavior.ConsiderTradeAgreement");
			}
			else
			{
				LogMessage("[DIPLOMACY_PATCHES] WARNING: Could not find ConsiderTradeAgreement method to patch");
			}
			TryPatchMethod(harmony, typeof(DeclareWarAction), "ApplyByDefault", AccessTools.Method(typeof(DiplomacyPatches), "DeclareWarAction_Prefix", (Type[])null, (Type[])null));
			TryPatchMethod(harmony, typeof(DeclareWarAction), "ApplyByKingdomDecision", AccessTools.Method(typeof(DiplomacyPatches), "DeclareWarAction_Prefix", (Type[])null, (Type[])null));
			TryPatchMethod(harmony, typeof(DeclareWarAction), "ApplyByCallToWarAgreement", AccessTools.Method(typeof(DiplomacyPatches), "DeclareWarAction_Prefix", (Type[])null, (Type[])null));
			TryPatchMethod(harmony, typeof(MakePeaceAction), "Apply", AccessTools.Method(typeof(DiplomacyPatches), "MakePeaceAction_Prefix", (Type[])null, (Type[])null));
			TryPatchMethod(harmony, typeof(MakePeaceAction), "ApplyByKingdomDecision", AccessTools.Method(typeof(DiplomacyPatches), "MakePeaceAction_Prefix", (Type[])null, (Type[])null));
			Type type = Type.GetType("TaleWorlds.CampaignSystem.CampaignBehaviors.AllianceCampaignBehavior, TaleWorlds.CampaignSystem");
			if (type != null)
			{
				TryPatchMethod(harmony, type, "StartAlliance", AccessTools.Method(typeof(DiplomacyPatches), "StartAlliance_Prefix", (Type[])null, (Type[])null));
				TryPatchMethod(harmony, type, "EndAlliance", AccessTools.Method(typeof(DiplomacyPatches), "EndAlliance_Prefix", (Type[])null, (Type[])null));
			}
			else
			{
				LogMessage("[DIPLOMACY_PATCHES] AllianceCampaignBehavior type not found");
			}
			Type type2 = Type.GetType("TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.Diplomacy.KingdomDiplomacyVM, TaleWorlds.CampaignSystem.ViewModelCollection");
			if (type2 != null)
			{
				TryPatchMethod(harmony, type2, "GetAreProposalActionsEnabledWithReason", AccessTools.Method(typeof(DiplomacyPatches), "GetAreProposalActionsEnabledWithReason_Prefix", (Type[])null, (Type[])null));
				LogMessage("[DIPLOMACY_PATCHES] Patched KingdomDiplomacyVM to block player proposals");
			}
			else
			{
				LogMessage("[DIPLOMACY_PATCHES] WARNING: KingdomDiplomacyVM type not found");
			}
			TryPatchMethod(harmony, typeof(DeclareWarDecision), "OnShowDecision", AccessTools.Method(typeof(DiplomacyPatches), "DiplomaticDecision_OnShowDecision_Prefix", (Type[])null, (Type[])null));
			TryPatchMethod(harmony, typeof(MakePeaceKingdomDecision), "OnShowDecision", AccessTools.Method(typeof(DiplomacyPatches), "DiplomaticDecision_OnShowDecision_Prefix", (Type[])null, (Type[])null));
			TryPatchMethod(harmony, typeof(StartAllianceDecision), "OnShowDecision", AccessTools.Method(typeof(DiplomacyPatches), "DiplomaticDecision_OnShowDecision_Prefix", (Type[])null, (Type[])null));
			TryPatchMethod(harmony, typeof(TradeAgreementDecision), "OnShowDecision", AccessTools.Method(typeof(DiplomacyPatches), "TradeAgreementDecision_OnShowDecision_Prefix", (Type[])null, (Type[])null));
			try
			{
				MethodInfo methodInfo7 = AccessTools.Method(typeof(DefaultClanFinanceModel), "CalculateClanGoldChange", (Type[])null, (Type[])null);
				MethodInfo methodInfo8 = AccessTools.Method(typeof(DiplomacyPatches), "CalculateClanGoldChange_Postfix", (Type[])null, (Type[])null);
				if (methodInfo7 != null && methodInfo8 != null)
				{
					harmony.Patch((MethodBase)methodInfo7, (HarmonyMethod)null, new HarmonyMethod(methodInfo8), (HarmonyMethod)null, (HarmonyMethod)null);
					LogMessage("[DIPLOMACY_PATCHES] Patched DefaultClanFinanceModel.CalculateClanGoldChange (tribute tooltip)");
				}
				else
				{
					LogMessage("[DIPLOMACY_PATCHES] WARNING: Could not patch DefaultClanFinanceModel.CalculateClanGoldChange for tribute tooltip");
				}
			}
			catch (Exception ex)
			{
				LogMessage("[DIPLOMACY_PATCHES] ERROR patching CalculateClanGoldChange: " + ex.Message);
			}
			_patchesApplied = true;
			LogMessage("[DIPLOMACY_PATCHES] All diplomacy patches applied successfully");
		}
		catch (Exception ex2)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR applying patches: " + ex2.Message);
			LogMessage("[DIPLOMACY_PATCHES] Stack trace: " + ex2.StackTrace);
		}
	}

	private static bool ConsiderWar_Prefix(Clan clan, Kingdom kingdom, IFaction otherFaction, ref bool __result)
	{
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return true;
			}
			if (kingdom == null || otherFaction == null || !otherFaction.IsKingdomFaction)
			{
				return true;
			}
			LogMessage($"[DIPLOMACY_PATCHES] Blocked vanilla war proposal: {kingdom.Name} vs {otherFaction.Name}");
			__result = false;
			return false;
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in ConsiderWar_Prefix: " + ex.Message);
			return true;
		}
	}

	private static bool ConsiderPeace_Prefix(Clan clan, IFaction otherFaction, out MakePeaceKingdomDecision decision, ref bool __result)
	{
		decision = null;
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return true;
			}
			Kingdom val = ((clan != null) ? clan.Kingdom : null);
			LogMessage($"[DIPLOMACY_PATCHES] Blocked vanilla peace proposal (v1.3.1): {((val != null) ? val.Name : null)} vs {((otherFaction != null) ? otherFaction.Name : null)}");
			__result = false;
			return false;
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in ConsiderPeace_Prefix: " + ex.Message);
			return true;
		}
	}

	private static bool ConsiderPeace_132_Prefix(Clan clan, Clan otherClan, IFaction otherFaction, out MakePeaceKingdomDecision decision, ref bool __result)
	{
		decision = null;
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return true;
			}
			Kingdom val = ((clan != null) ? clan.Kingdom : null);
			LogMessage($"[DIPLOMACY_PATCHES] Blocked vanilla peace proposal (v1.3.2): {((val != null) ? val.Name : null)} vs {((otherFaction != null) ? otherFaction.Name : null)}");
			__result = false;
			return false;
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in ConsiderPeace_132_Prefix: " + ex.Message);
			return true;
		}
	}

	private static bool ConsiderTradeAgreement_Prefix(Clan clan, Kingdom kingdom, Kingdom otherKingdom, ref bool __result)
	{
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return true;
			}
			LogMessage($"[DIPLOMACY_PATCHES] Blocked vanilla trade agreement proposal: {((kingdom != null) ? kingdom.Name : null)} ↔ {((otherKingdom != null) ? otherKingdom.Name : null)}");
			__result = false;
			return false;
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in ConsiderTradeAgreement_Prefix: " + ex.Message);
			return true;
		}
	}

	private static void LogMessage(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}

	private static bool DeclareWarAction_Prefix(IFaction faction1, IFaction faction2)
	{
		try
		{
			if (_bypassCounter > 0)
			{
				return true;
			}
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return true;
			}
			if (faction1 == null || !faction1.IsKingdomFaction || faction2 == null || !faction2.IsKingdomFaction)
			{
				return true;
			}
			if (faction1 != Hero.MainHero.MapFaction && faction2 != Hero.MainHero.MapFaction)
			{
				LogMessage($"[DIPLOMACY_PATCHES] Blocked DeclareWarAction between AI: {((faction1 != null) ? faction1.Name : null)} vs {((faction2 != null) ? faction2.Name : null)}");
				return false;
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in DeclareWarAction_Prefix: " + ex.Message);
		}
		return true;
	}

	private static bool MakePeaceAction_Prefix(IFaction faction1, IFaction faction2)
	{
		try
		{
			if (_bypassCounter > 0)
			{
				return true;
			}
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return true;
			}
			if (faction1 != Hero.MainHero.MapFaction && faction2 != Hero.MainHero.MapFaction)
			{
				LogMessage($"[DIPLOMACY_PATCHES] Blocked MakePeaceAction between AI: {((faction1 != null) ? faction1.Name : null)} ↔ {((faction2 != null) ? faction2.Name : null)}");
				return false;
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in MakePeaceAction_Prefix: " + ex.Message);
		}
		return true;
	}

	private static bool StartAlliance_Prefix(Kingdom proposerKingdom, Kingdom receiverKingdom)
	{
		try
		{
			if (_bypassCounter > 0)
			{
				return true;
			}
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return true;
			}
			if ((object)proposerKingdom != Hero.MainHero.MapFaction && (object)receiverKingdom != Hero.MainHero.MapFaction)
			{
				LogMessage($"[DIPLOMACY_PATCHES] Blocked AI alliance start: {((proposerKingdom != null) ? proposerKingdom.Name : null)} ↔ {((receiverKingdom != null) ? receiverKingdom.Name : null)}");
				return false;
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in StartAlliance_Prefix: " + ex.Message);
		}
		return true;
	}

	private static bool EndAlliance_Prefix(Kingdom kingdom1, Kingdom kingdom2)
	{
		try
		{
			if (_bypassCounter > 0)
			{
				return true;
			}
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return true;
			}
			if ((object)kingdom1 != Hero.MainHero.MapFaction && (object)kingdom2 != Hero.MainHero.MapFaction)
			{
				LogMessage($"[DIPLOMACY_PATCHES] Blocked AI alliance end: {((kingdom1 != null) ? kingdom1.Name : null)} ↔ {((kingdom2 != null) ? kingdom2.Name : null)}");
				return false;
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in EndAlliance_Prefix: " + ex.Message);
		}
		return true;
	}

	private static bool GetAreProposalActionsEnabledWithReason_Prefix(float actionInfluenceCost, ref TextObject disabledReason, ref bool __result)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableModification || !GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return true;
			}
			disabledReason = new TextObject("AIInfluence diplomacy system is handling diplomatic relations. Diplomatic actions (war, peace, alliances, trade agreements) are managed through AI-driven events.", (Dictionary<string, object>)null);
			__result = false;
			LogMessage("[DIPLOMACY_PATCHES] Blocked player diplomatic proposal through Kingdom UI");
			return false;
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in GetAreProposalActionsEnabledWithReason_Prefix: " + ex.Message);
			return true;
		}
	}

	private static bool DiplomaticDecision_OnShowDecision_Prefix(KingdomDecision __instance, ref bool __result)
	{
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableModification || !GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return true;
			}
			string name = ((object)__instance).GetType().Name;
			LogMessage("[DIPLOMACY_PATCHES] Blocked showing " + name + " to player - handled by AIInfluence diplomacy");
			__result = false;
			return false;
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in DiplomaticDecision_OnShowDecision_Prefix: " + ex.Message);
			return true;
		}
	}

	private static bool TradeAgreementDecision_OnShowDecision_Prefix(TradeAgreementDecision __instance, ref bool __result)
	{
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableModification || !GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return true;
			}
			LogMessage("[DIPLOMACY_PATCHES] Blocked showing TradeAgreementDecision to player - handled by AIInfluence diplomacy");
			__result = false;
			return false;
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_PATCHES] ERROR in TradeAgreementDecision_OnShowDecision_Prefix: " + ex.Message);
			return true;
		}
	}
}
