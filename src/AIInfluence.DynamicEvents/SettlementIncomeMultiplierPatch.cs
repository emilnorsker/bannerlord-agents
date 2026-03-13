using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AIInfluence.Diseases;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.DynamicEvents;

public class SettlementIncomeMultiplierPatch
{
	private static MethodInfo _addSettlementIncomeMethod;

	private static bool _initializationAttempted;

	private static string _initializationError;

	private static bool _patchApplied;

	private static void EnsureInitialized()
	{
		if (_initializationAttempted)
		{
			return;
		}
		_initializationAttempted = true;
		try
		{
			_addSettlementIncomeMethod = AccessTools.Method(typeof(DefaultClanFinanceModel), "AddSettlementIncome", (Type[])null, (Type[])null);
			if (_addSettlementIncomeMethod == null)
			{
				_addSettlementIncomeMethod = AccessTools.Method(typeof(DefaultClanFinanceModel), "AddSettlementIncome", new Type[4]
				{
					typeof(Clan),
					typeof(ExplainedNumber).MakeByRefType(),
					typeof(bool),
					typeof(bool)
				}, (Type[])null);
			}
			if (_addSettlementIncomeMethod == null)
			{
				_addSettlementIncomeMethod = AccessTools.DeclaredMethod(typeof(DefaultClanFinanceModel), "AddSettlementIncome", (Type[])null, (Type[])null);
			}
			if (_addSettlementIncomeMethod == null)
			{
				_initializationError = "Could not find AddSettlementIncome method";
				try
				{
					DynamicEventsLogger.Instance?.Log("[SETTLEMENT_INCOME_PATCH] WARNING: Could not find AddSettlementIncome method for income multiplier patch");
					DynamicEventsLogger.Instance?.Log("[SETTLEMENT_INCOME_PATCH] Tried: AccessTools.Method(name), AccessTools.Method(name, types), AccessTools.DeclaredMethod(name)");
					return;
				}
				catch
				{
					return;
				}
			}
			try
			{
				DynamicEventsLogger.Instance?.Log("[SETTLEMENT_INCOME_PATCH] Successfully found AddSettlementIncome method: " + _addSettlementIncomeMethod.Name);
			}
			catch
			{
			}
		}
		catch (Exception ex)
		{
			_initializationError = ex.Message;
			try
			{
				DynamicEventsLogger.Instance?.Log("[SETTLEMENT_INCOME_PATCH] ERROR finding AddSettlementIncome: " + ex.Message);
			}
			catch
			{
			}
		}
	}

	public static void ApplyPatch(Harmony harmony)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		if (_patchApplied)
		{
			return;
		}
		EnsureInitialized();
		try
		{
			if (_addSettlementIncomeMethod == null)
			{
				try
				{
					DynamicEventsLogger.Instance?.Log("[SETTLEMENT_INCOME_PATCH] WARNING: Cannot apply income multiplier patch - " + (_initializationError ?? "method not found"));
					return;
				}
				catch
				{
					return;
				}
			}
			MethodInfo methodInfo = AccessTools.Method(typeof(SettlementIncomeMultiplierPatch), "AddSettlementIncome_Postfix", (Type[])null, (Type[])null);
			if (methodInfo == null)
			{
				try
				{
					DynamicEventsLogger.Instance?.Log("[SETTLEMENT_INCOME_PATCH] ERROR: Could not find AddSettlementIncome_Postfix method");
					return;
				}
				catch
				{
					return;
				}
			}
			harmony.Patch((MethodBase)_addSettlementIncomeMethod, (HarmonyMethod)null, new HarmonyMethod(methodInfo), (HarmonyMethod)null, (HarmonyMethod)null);
			_patchApplied = true;
			try
			{
				DynamicEventsLogger.Instance?.Log("[SETTLEMENT_INCOME_PATCH] Income multiplier patch applied successfully");
			}
			catch
			{
			}
		}
		catch (Exception ex)
		{
			try
			{
				DynamicEventsLogger.Instance?.Log("[SETTLEMENT_INCOME_PATCH] ERROR applying income multiplier patch: " + ex.Message);
			}
			catch
			{
			}
		}
	}

	private static void AddSettlementIncome_Postfix(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals, bool includeDetails)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		try
		{
			if (Campaign.Current == null || Campaign.Current.Models == null)
			{
				return;
			}
			_ = CampaignTime.Now;
			if (false || clan == null || clan.Fiefs == null || ((List<Town>)(object)clan.Fiefs).Count == 0)
			{
				return;
			}
			List<ActiveEconomicEffect> list = EconomicEffectsManager.Instance?.GetActiveEffects();
			CampaignTime now = CampaignTime.Now;
			float currentDay = (float)((CampaignTime)(ref now)).ToDays;
			foreach (Town item in (List<Town>)(object)clan.Fiefs)
			{
				if (((item != null) ? ((SettlementComponent)item).Settlement : null) == null)
				{
					continue;
				}
				string settlementId = ((MBObjectBase)((SettlementComponent)item).Settlement).StringId;
				if (string.IsNullOrEmpty(settlementId))
				{
					continue;
				}
				float num = CalculateSettlementBaseIncome(clan, item, applyWithdrawals);
				if (Math.Abs(num) < 0.001f)
				{
					continue;
				}
				if (list != null && list.Count > 0)
				{
					List<ActiveEconomicEffect> list2 = list.Where((ActiveEconomicEffect e) => e != null && e.TargetType == "settlement" && e.TargetId == settlementId && currentDay < e.StartDay + (float)e.DurationDays && Math.Abs(e.IncomeMultiplier - 1f) > 0.001f).ToList();
					if (list2.Any())
					{
						float num2 = 0f;
						foreach (ActiveEconomicEffect item2 in list2)
						{
							float num3 = item2.IncomeMultiplier - 1f;
							num2 += num * num3;
						}
						if (Math.Abs(num2) > 0.001f)
						{
							float num4 = 1f + num2 / num;
							string text = $"Economic effects: x{num4:F2} income";
							if (list2.Count > 1)
							{
								text += $" ({list2.Count} effects)";
							}
							TextObject val = new TextObject(text, (Dictionary<string, object>)null);
							((ExplainedNumber)(ref goldChange)).Add(num2, val, ((SettlementComponent)item).Name);
						}
					}
				}
				if (DiseaseManager.Instance != null)
				{
					float quarantineIncomeMultiplier = DiseaseManager.Instance.GetQuarantineIncomeMultiplier(((SettlementComponent)item).Settlement);
					if (Math.Abs(quarantineIncomeMultiplier - 1f) > 0.001f)
					{
						float num5 = num * (quarantineIncomeMultiplier - 1f);
						TextObject val2 = new TextObject("{=AIInfluence_QuarantinePenaltyReason}Quarantine", (Dictionary<string, object>)null);
						((ExplainedNumber)(ref goldChange)).Add(num5, val2, ((SettlementComponent)item).Name);
					}
				}
			}
		}
		catch (Exception ex)
		{
			try
			{
				DynamicEventsLogger.Instance?.Log("[SETTLEMENT_INCOME_PATCH] ERROR in Postfix: " + ex.Message);
				DynamicEventsLogger.Instance?.Log("[SETTLEMENT_INCOME_PATCH] StackTrace: " + ex.StackTrace);
			}
			catch
			{
			}
		}
	}

	private static float CalculateSettlementBaseIncome(Clan clan, Town town, bool applyWithdrawals)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((town != null) ? ((SettlementComponent)town).Settlement : null) == null)
			{
				return 0f;
			}
			Campaign current = Campaign.Current;
			if (((current != null) ? current.Models : null) == null)
			{
				return 0f;
			}
			if (Campaign.Current.Models.SettlementTaxModel == null || Campaign.Current.Models.ClanFinanceModel == null)
			{
				return 0f;
			}
			float num = 0f;
			ExplainedNumber val = Campaign.Current.Models.SettlementTaxModel.CalculateTownTax(town, false);
			num += ((ExplainedNumber)(ref val)).ResultNumber;
			ExplainedNumber val2 = Campaign.Current.Models.ClanFinanceModel.CalculateTownIncomeFromTariffs(clan, town, false);
			num += ((ExplainedNumber)(ref val2)).ResultNumber;
			int num2 = Campaign.Current.Models.ClanFinanceModel.CalculateTownIncomeFromProjects(town);
			num += (float)num2;
			if (town.Villages != null)
			{
				foreach (Village item in (List<Village>)(object)town.Villages)
				{
					if (item != null)
					{
						int num3 = Campaign.Current.Models.ClanFinanceModel.CalculateVillageIncome(clan, item, false);
						num += (float)num3;
					}
				}
			}
			return num;
		}
		catch
		{
			return 0f;
		}
	}
}
