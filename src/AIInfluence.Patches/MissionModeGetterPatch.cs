using System;
using System.Reflection;
using AIInfluence.SettlementCombat;
using HarmonyLib;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace AIInfluence.Patches;

[HarmonyPatch(/*Could not decode attribute arguments.*/)]
public static class MissionModeGetterPatch
{
	private static readonly SettlementCombatLogger _logger = SettlementCombatLogger.Instance;

	private static FieldInfo _cachedModeField;

	private static bool _fieldResolved;

	private static bool _isActive;

	private static Mission _lastCheckedMission;

	private static float _lastCheckTime;

	private const float CHECK_INTERVAL = 0.5f;

	private static bool Prefix(Mission __instance, ref MissionMode __result)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected I4, but got Unknown
		try
		{
			if (__instance != _lastCheckedMission || __instance.CurrentTime - _lastCheckTime > 0.5f)
			{
				_lastCheckedMission = __instance;
				_lastCheckTime = __instance.CurrentTime;
				_isActive = ShouldBeActive(__instance);
			}
			if (!_isActive)
			{
				return true;
			}
			if (!_fieldResolved)
			{
				_cachedModeField = AccessTools.Field(typeof(Mission), "_mode");
				_fieldResolved = true;
			}
			if (_cachedModeField == null)
			{
				return true;
			}
			MissionMode val = (MissionMode)_cachedModeField.GetValue(__instance);
			if (__instance.PlayerTeam != null && __instance.PlayerTeam.IsPlayerGeneral)
			{
				PlayerReinforcementMissionLogic missionBehavior = __instance.GetMissionBehavior<PlayerReinforcementMissionLogic>();
				if (missionBehavior != null && missionBehavior.HasActiveSummonedTroops())
				{
					__result = (MissionMode)2;
					return false;
				}
			}
			__result = (MissionMode)(int)val;
			return true;
		}
		catch (Exception ex)
		{
			_isActive = false;
			_logger.LogError("MissionModeGetterPatch.Prefix", ex.Message, ex);
			return true;
		}
	}

	private static bool ShouldBeActive(Mission mission)
	{
		try
		{
			if (Settlement.CurrentSettlement == null)
			{
				return false;
			}
			if (PlayerEncounter.EncounteredBattle != null)
			{
				return false;
			}
			if (mission.GetMissionBehavior<PlayerReinforcementMissionLogic>() == null)
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}
}
