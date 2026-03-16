using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using AIInfluence.Diseases;
using AIInfluence.ViewModels;
using HarmonyLib;
using SandBox.ViewModelCollection.Nameplate.NameplateNotifications;
using SandBox.ViewModelCollection.Nameplate.NameplateNotifications.SettlementNotificationTypes;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch]
public static class HospitalVisitSettlementNotificationPatch
{
	private static readonly FieldInfo SettlementField;

	private static readonly FieldInfo TickField;

	private static readonly Dictionary<Settlement, SettlementNameplateNotificationsVM> _registry;

	static HospitalVisitSettlementNotificationPatch()
	{
		SettlementField = AccessTools.Field(typeof(SettlementNameplateNotificationsVM), "_settlement");
		TickField = AccessTools.Field(typeof(SettlementNameplateNotificationsVM), "_tickSinceEnabled");
		_registry = new Dictionary<Settlement, SettlementNameplateNotificationsVM>();
		HospitalVisitSettlementNotification.OnHeroVisitedHospital += OnNotify;
		HospitalVisitSettlementNotification.OnSettlementForceTreated += OnSettlementForceTreated;
		ArenaTrainingNotification.OnTrainingStarted += OnArenaTrainingStarted;
	}

	private static void OnNotify(Hero hero, Settlement settlement)
	{
		if (hero != null && settlement != null && _registry.TryGetValue(settlement, out var vm))
		{
			int createdTick = ((TickField != null) ? ((int)(TickField.GetValue(vm) ?? ((object)0))) : 0);
			HeroVisitedHospitalNotificationItemVM item = new HeroVisitedHospitalNotificationItemVM(delegate(SettlementNotificationItemBaseVM item2)
			{
				((Collection<SettlementNotificationItemBaseVM>)(object)vm.Notifications).Remove(item2);
			}, hero, settlement, createdTick);
			((Collection<SettlementNotificationItemBaseVM>)(object)vm.Notifications).Add((SettlementNotificationItemBaseVM)(object)item);
		}
	}

	private static void OnSettlementForceTreated(Settlement settlement, string targetType, Hero lordHero, string ownerDisplayName)
	{
		if (settlement != null && !string.IsNullOrEmpty(targetType) && _registry.TryGetValue(settlement, out var vm))
		{
			int createdTick = ((TickField != null) ? ((int)(TickField.GetValue(vm) ?? ((object)0))) : 0);
			SettlementForceTreatedNotificationItemVM item = new SettlementForceTreatedNotificationItemVM(delegate(SettlementNotificationItemBaseVM item2)
			{
				((Collection<SettlementNotificationItemBaseVM>)(object)vm.Notifications).Remove(item2);
			}, settlement, targetType, createdTick, lordHero, ownerDisplayName);
			((Collection<SettlementNotificationItemBaseVM>)(object)vm.Notifications).Add((SettlementNotificationItemBaseVM)(object)item);
		}
	}

	private static void OnArenaTrainingStarted(Settlement settlement, Hero hero, string customText)
	{
		if (settlement != null && _registry.TryGetValue(settlement, out var vm))
		{
			int createdTick = ((TickField != null) ? ((int)(TickField.GetValue(vm) ?? ((object)0))) : 0);
			ArenaTrainingNotificationItemVM item = new ArenaTrainingNotificationItemVM(delegate(SettlementNotificationItemBaseVM item2)
			{
				((Collection<SettlementNotificationItemBaseVM>)(object)vm.Notifications).Remove(item2);
			}, hero, settlement, createdTick, customText);
			((Collection<SettlementNotificationItemBaseVM>)(object)vm.Notifications).Add((SettlementNotificationItemBaseVM)(object)item);
		}
	}

	[HarmonyPatch(typeof(SettlementNameplateNotificationsVM), "RegisterEvents")]
	[HarmonyPostfix]
	private static void RegisterEvents_Postfix(SettlementNameplateNotificationsVM __instance)
	{
		object? obj = SettlementField?.GetValue(__instance);
		Settlement val = (Settlement)((obj is Settlement) ? obj : null);
		if (val != null)
		{
			_registry[val] = __instance;
		}
	}

	[HarmonyPatch(typeof(SettlementNameplateNotificationsVM), "UnloadEvents")]
	[HarmonyPostfix]
	private static void UnloadEvents_Postfix(SettlementNameplateNotificationsVM __instance)
	{
		object? obj = SettlementField?.GetValue(__instance);
		Settlement val = (Settlement)((obj is Settlement) ? obj : null);
		if (val != null)
		{
			_registry.Remove(val);
		}
	}
}
