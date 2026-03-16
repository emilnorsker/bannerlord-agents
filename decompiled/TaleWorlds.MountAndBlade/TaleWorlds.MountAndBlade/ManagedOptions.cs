using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class ManagedOptions
{
	public enum ManagedOptionsType
	{
		Language,
		GyroOverrideForAttackDefend,
		ControlBlockDirection,
		ControlAttackDirection,
		NumberOfCorpses,
		BattleSize,
		ReinforcementWaveCount,
		TurnCameraWithHorseInFirstPerson,
		ShowBlood,
		ShowAttackDirection,
		ShowTargetingReticle,
		AutoSaveInterval,
		FriendlyTroopsBannerOpacity,
		AlwaysShowFriendlyTroopBannersType,
		ShowFormationDistances,
		ReportDamage,
		ReportBark,
		LockTarget,
		EnableTutorialHints,
		ReportCasualtiesType,
		ReportExperience,
		ReportPersonalDamage,
		FirstPersonFov,
		CombatCameraDistance,
		EnableDamageTakenVisuals,
		EnableVoiceChat,
		EnableDeathIcon,
		EnableNetworkAlertIcons,
		ForceVSyncInMenus,
		EnableVerticalAimCorrection,
		ZoomSensitivityModifier,
		UIScale,
		CrosshairType,
		EnableGenericAvatars,
		EnableGenericNames,
		OrderType,
		OrderLayoutType,
		AutoTrackAttackedSettlements,
		StopGameOnFocusLost,
		SlowDownOnOrder,
		HideFullServers,
		HideEmptyServers,
		HidePasswordProtectedServers,
		HideUnofficialServers,
		HideModuleIncompatibleServers,
		HideBattleUI,
		UnitSpawnPrioritization,
		EnableSingleplayerChatBox,
		EnableMultiplayerChatBox,
		VoiceLanguage,
		PlayerReceivedDamageDifficulty,
		ManagedOptionTypeCount
	}

	public delegate void OnManagedOptionChangedDelegate(ManagedOptionsType changedManagedOptionsType);

	public static OnManagedOptionChangedDelegate OnManagedOptionChanged;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetConfig(ManagedOptionsType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDefaultConfig(ManagedOptionsType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, true)]
	internal static int GetConfigCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, true)]
	internal static float GetConfigValue(int type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetConfig(ManagedOptionsType type, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveResult SaveConfig()
	{
		throw null;
	}
}
