using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AIInfluence.SettlementCombat;
using HarmonyLib;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.MountAndBlade.View.MissionViews.Order;

namespace AIInfluence.Patches;

[HarmonyPatch]
public static class SettlementOrderUIPatch
{
	private static readonly SettlementCombatLogger _logger = SettlementCombatLogger.Instance;

	[HarmonyTargetMethods]
	private static IEnumerable<MethodBase> TargetMethods()
	{
		try
		{
			Type type = AccessTools.TypeByName("SandBox.View.Missions.SandBoxMissionViews");
			if (type == null)
			{
				_logger.LogError("TargetMethods", "Cannot find SandBox.View.Missions.SandBoxMissionViews type");
				return Enumerable.Empty<MethodBase>();
			}
			List<MethodBase> list = new List<MethodBase>();
			string[] array = new string[3] { "OpenVillageMission", "OpenTownCenterMission", "OpenLordsHallMission" };
			string[] array2 = array;
			foreach (string text in array2)
			{
				MethodInfo methodInfo = AccessTools.Method(type, text, (Type[])null, (Type[])null);
				if (methodInfo != null)
				{
					list.Add(methodInfo);
					_logger.Log("[ORDER_UI_PATCH] Found method to patch: " + text);
				}
				else
				{
					_logger.Log("[ORDER_UI_PATCH] Method not found: " + text);
				}
			}
			if (list.Count == 0)
			{
				_logger.LogError("TargetMethods", "No methods found to patch!");
			}
			else
			{
				_logger.Log($"[ORDER_UI_PATCH] Total methods to patch: {list.Count}");
			}
			return list;
		}
		catch (Exception ex)
		{
			_logger.LogError("TargetMethods", ex.Message, ex);
			return Enumerable.Empty<MethodBase>();
		}
	}

	private static void Postfix(ref MissionView[] __result, Mission mission)
	{
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		try
		{
			if (__result == null)
			{
				_logger.LogError("Postfix", "__result is null");
				return;
			}
			_logger.Log($"[ORDER_UI_PATCH] Postfix called for mission. Original views count: {__result.Length}");
			bool flag = __result.Any((MissionView view) => ((object)view)?.GetType().Name.Contains("OrderUI") ?? false);
			bool flag2 = __result.Any((MissionView view) => ((object)view)?.GetType().Name.Contains("OrderTroopPlacer") ?? false);
			if (flag && flag2)
			{
				_logger.Log("[ORDER_UI_PATCH] Mission already has Order UI, skipping");
				return;
			}
			List<MissionView> list = new List<MissionView>(__result);
			if (!flag)
			{
				try
				{
					MissionView val = ViewCreator.CreateMissionOrderUIHandler((Mission)null);
					if (val != null)
					{
						list.Insert(0, val);
						_logger.Log("[ORDER_UI_PATCH] Added MissionOrderUIHandler");
					}
				}
				catch (Exception ex)
				{
					_logger.LogError("Postfix.CreateOrderUI", ex.Message, ex);
				}
			}
			if (!flag2)
			{
				try
				{
					OrderTroopPlacer val2 = new OrderTroopPlacer((OrderController)null);
					if (val2 != null)
					{
						list.Insert(1, (MissionView)(object)val2);
						_logger.Log("[ORDER_UI_PATCH] Added OrderTroopPlacer");
					}
				}
				catch (Exception ex2)
				{
					_logger.LogError("Postfix.CreateOrderTroopPlacer", ex2.Message, ex2);
				}
			}
			if (!__result.Any((MissionView view) => ((object)view)?.GetType().Name.Contains("FormationMarker") ?? false))
			{
				try
				{
					MissionView val3 = ViewCreator.CreateMissionFormationMarkerUIHandler(mission);
					if (val3 != null)
					{
						list.Add(val3);
						_logger.Log("[ORDER_UI_PATCH] Added MissionFormationMarkerUIHandler");
					}
				}
				catch (Exception ex3)
				{
					_logger.LogError("Postfix.CreateFormationMarker", ex3.Message, ex3);
				}
			}
			if (!__result.Any((MissionView view) => ((object)view)?.GetType().Name.Contains("TargetSelection") ?? false))
			{
				try
				{
					MissionFormationTargetSelectionHandler val4 = new MissionFormationTargetSelectionHandler();
					if (val4 != null)
					{
						list.Add((MissionView)(object)val4);
						_logger.Log("[ORDER_UI_PATCH] Added MissionFormationTargetSelectionHandler");
					}
				}
				catch (Exception ex4)
				{
					_logger.LogError("Postfix.CreateTargetSelection", ex4.Message, ex4);
				}
			}
			__result = list.ToArray();
			_logger.Log($"[ORDER_UI_PATCH] Patch complete! New views count: {__result.Length}");
		}
		catch (Exception ex5)
		{
			_logger.LogError("Postfix", ex5.Message, ex5);
		}
	}
}
