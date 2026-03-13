using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(DefaultHeroCreationModel))]
public class HeroCreationNullEquipmentRosterPatch
{
	[HarmonyPatch("GetCivilianEquipment")]
	[HarmonyPrefix]
	public static bool GetCivilianEquipment_Prefix(Hero hero, DefaultHeroCreationModel __instance, ref Equipment __result)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		try
		{
			if (hero == null)
			{
				__result = new Equipment();
				return false;
			}
			Campaign current = Campaign.Current;
			object obj;
			if (current == null)
			{
				obj = null;
			}
			else
			{
				GameModels models = current.Models;
				obj = ((models != null) ? models.EquipmentSelectionModel : null);
			}
			EquipmentSelectionModel val = (EquipmentSelectionModel)obj;
			if (val == null)
			{
				if (hero.CivilianEquipment != null)
				{
					__result = hero.CivilianEquipment;
					return false;
				}
				__result = new Equipment();
				return false;
			}
			MBList<MBEquipmentRoster> equipmentRostersForDeliveredOffspring = val.GetEquipmentRostersForDeliveredOffspring(hero);
			if (equipmentRostersForDeliveredOffspring == null || ((List<MBEquipmentRoster>)(object)equipmentRostersForDeliveredOffspring).Count == 0)
			{
				if (hero.CivilianEquipment != null)
				{
					__result = hero.CivilianEquipment;
					return false;
				}
				__result = new Equipment();
				return false;
			}
			List<MBEquipmentRoster> list = ((IEnumerable<MBEquipmentRoster>)equipmentRostersForDeliveredOffspring).Where((MBEquipmentRoster r) => r != null).ToList();
			if (list.Count == 0)
			{
				if (hero.CivilianEquipment != null)
				{
					__result = hero.CivilianEquipment;
					return false;
				}
				__result = new Equipment();
				return false;
			}
			MBEquipmentRoster val2 = list[MBRandom.RandomInt(list.Count)];
			if (val2 == null)
			{
				if (hero.CivilianEquipment != null)
				{
					__result = hero.CivilianEquipment;
					return false;
				}
				__result = new Equipment();
				return false;
			}
			IEnumerable<Equipment> civilianEquipments = MBEquipmentRosterExtensions.GetCivilianEquipments(val2);
			if (civilianEquipments == null)
			{
				if (hero.CivilianEquipment != null)
				{
					__result = hero.CivilianEquipment;
					return false;
				}
				__result = new Equipment();
				return false;
			}
			List<Equipment> list2 = civilianEquipments.ToList();
			if (list2.Count == 0)
			{
				if (hero.CivilianEquipment != null)
				{
					__result = hero.CivilianEquipment;
					return false;
				}
				__result = new Equipment();
				return false;
			}
			Equipment val3 = list2[MBRandom.RandomInt(list2.Count)];
			if (val3 != null)
			{
				__result = val3;
				return false;
			}
			if (hero.CivilianEquipment != null)
			{
				__result = hero.CivilianEquipment;
				return false;
			}
			__result = new Equipment();
			return false;
		}
		catch (Exception ex)
		{
			Campaign current2 = Campaign.Current;
			((current2 != null) ? current2.GetCampaignBehavior<AIInfluenceBehavior>() : null)?.LogMessage("[HeroCreationNullEquipmentRosterPatch] Exception in GetCivilianEquipment_Prefix: " + ex.Message);
			if (((hero != null) ? hero.CivilianEquipment : null) != null)
			{
				__result = hero.CivilianEquipment;
			}
			else
			{
				__result = new Equipment();
			}
			return false;
		}
	}
}
