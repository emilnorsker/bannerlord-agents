using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;

namespace TaleWorlds.Engine.InputSystem;

public class CheatsHotKeyCategory : GameKeyContext
{
	public const string CategoryId = "Cheats";

	public const string MissionScreenHotkeyIncreaseCameraSpeed = "MissionScreenHotkeyIncreaseCameraSpeed";

	public const string MissionScreenHotkeyDecreaseCameraSpeed = "MissionScreenHotkeyDecreaseCameraSpeed";

	public const string ResetCameraSpeed = "ResetCameraSpeed";

	public const string MissionScreenHotkeyIncreaseSlowMotionFactor = "MissionScreenHotkeyIncreaseSlowMotionFactor";

	public const string MissionScreenHotkeyDecreaseSlowMotionFactor = "MissionScreenHotkeyDecreaseSlowMotionFactor";

	public const string EnterSlowMotion = "EnterSlowMotion";

	public const string Pause = "Pause";

	public const string MissionScreenHotkeyHealYourSelf = "MissionScreenHotkeyHealYourSelf";

	public const string MissionScreenHotkeyHealYourHorse = "MissionScreenHotkeyHealYourHorse";

	public const string MissionScreenHotkeyKillEnemyAgent = "MissionScreenHotkeyKillEnemyAgent";

	public const string MissionScreenHotkeyKillAllEnemyAgents = "MissionScreenHotkeyKillAllEnemyAgents";

	public const string MissionScreenHotkeyKillEnemyHorse = "MissionScreenHotkeyKillEnemyHorse";

	public const string MissionScreenHotkeyKillAllEnemyHorses = "MissionScreenHotkeyKillAllEnemyHorses";

	public const string MissionScreenHotkeyKillFriendlyAgent = "MissionScreenHotkeyKillFriendlyAgent";

	public const string MissionScreenHotkeyKillAllFriendlyAgents = "MissionScreenHotkeyKillAllFriendlyAgents";

	public const string MissionScreenHotkeyKillFriendlyHorse = "MissionScreenHotkeyKillFriendlyHorse";

	public const string MissionScreenHotkeyKillAllFriendlyHorses = "MissionScreenHotkeyKillAllFriendlyHorses";

	public const string MissionScreenHotkeyKillYourSelf = "MissionScreenHotkeyKillYourSelf";

	public const string MissionScreenHotkeyKillYourHorse = "MissionScreenHotkeyKillYourHorse";

	public const string MissionScreenHotkeyGhostCam = "MissionScreenHotkeyGhostCam";

	public const string MissionScreenHotkeySwitchAgentToAi = "MissionScreenHotkeySwitchAgentToAi";

	public const string MissionScreenHotkeyControlFollowedAgent = "MissionScreenHotkeyControlFollowedAgent";

	public const string MissionScreenHotkeyTeleportMainAgent = "MissionScreenHotkeyTeleportMainAgent";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CheatsHotKeyCategory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterCheatHotkey(string id, InputKey hotkeyKey, HotKey.Modifiers modifiers, HotKey.Modifiers negativeModifiers = HotKey.Modifiers.None)
	{
		throw null;
	}
}
