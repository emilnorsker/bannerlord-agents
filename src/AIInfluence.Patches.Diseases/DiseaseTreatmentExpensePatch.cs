using System;
using System.Collections.Generic;
using AIInfluence.Diseases;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculateClanGoldChange")]
public static class DiseaseTreatmentExpensePatch
{
	private static readonly Dictionary<string, int> _pendingDebts = new Dictionary<string, int>();

	public static void AddDebt(Clan clan, int amount)
	{
		if (clan != null && amount > 0)
		{
			string stringId = ((MBObjectBase)clan).StringId;
			_pendingDebts.TryGetValue(stringId, out var value);
			_pendingDebts[stringId] = value + amount;
			DiseaseLogger.Instance?.Log($"[TREATMENT_EXPENSE] Pending debt added for clan {clan.Name}: {amount} gold (total: {value + amount})");
		}
	}

	public static int GetPendingDebt(Clan clan)
	{
		if (clan == null)
		{
			return 0;
		}
		_pendingDebts.TryGetValue(((MBObjectBase)clan).StringId, out var value);
		return value;
	}

	public static void Reset()
	{
		_pendingDebts.Clear();
	}

	[HarmonyPostfix]
	public static void Postfix(Clan clan, bool includeDescriptions, bool applyWithdrawals, ref ExplainedNumber __result)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		try
		{
			if (Campaign.Current != null && clan != null && _pendingDebts.TryGetValue(((MBObjectBase)clan).StringId, out var value) && value > 0)
			{
				if (includeDescriptions)
				{
					((ExplainedNumber)(ref __result)).Add((float)(-value), new TextObject("{=AIInfluence_DiseaseTreatmentExpense}Disease treatment", (Dictionary<string, object>)null), (TextObject)null);
				}
				else
				{
					((ExplainedNumber)(ref __result)).Add((float)(-value), (TextObject)null, (TextObject)null);
				}
				if (applyWithdrawals)
				{
					_pendingDebts.Remove(((MBObjectBase)clan).StringId);
					DiseaseLogger.Instance?.Log($"[TREATMENT_EXPENSE] Applied {value} gold treatment debt for clan {clan.Name}");
				}
			}
		}
		catch (Exception ex)
		{
			try
			{
				DiseaseLogger.Instance?.Log("[TREATMENT_EXPENSE] ERROR in Postfix: " + ex.Message);
			}
			catch
			{
			}
		}
	}
}
