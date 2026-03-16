using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class BannerlordConfig
{
	private interface IConfigPropertyBoundChecker<T>
	{
	}

	private abstract class ConfigProperty : Attribute
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		protected ConfigProperty()
		{
			throw null;
		}
	}

	private sealed class ConfigPropertyInt : ConfigProperty
	{
		private int[] _possibleValues;

		private bool _isRange;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ConfigPropertyInt(int[] possibleValues, bool isRange = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsValidValue(int value)
		{
			throw null;
		}
	}

	private sealed class ConfigPropertyUnbounded : ConfigProperty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public ConfigPropertyUnbounded()
		{
			throw null;
		}
	}

	private static int[] _battleSizes;

	private static int[] _siegeBattleSizes;

	private static int[] _sallyOutBattleSizes;

	private static int[] _reinforcementWaveCounts;

	public const int MaxCorpseCount = 1021;

	public static double SiegeBattleSizeMultiplier;

	public const int DefaultPlayerReceviedDamageDifficulty = 0;

	public const bool DefaultGyroOverrideForAttackDefend = false;

	public const int DefaultAttackDirectionControl = 1;

	public const int DefaultDefendDirectionControl = 0;

	public const int DefaultNumberOfCorpses = 3;

	public const bool DefaultShowBlood = true;

	public const bool DefaultDisplayAttackDirection = true;

	public const bool DefaultDisplayTargetingReticule = true;

	public const bool DefaultForceVSyncInMenus = true;

	public const int DefaultBattleSize = 2;

	public const int DefaultReinforcementWaveCount = 3;

	public const float DefaultBattleSizeMultiplier = 0.5f;

	public const float DefaultFirstPersonFov = 65f;

	public const float DefaultUIScale = 1f;

	public const float DefaultCombatCameraDistance = 1f;

	public const int DefaultCombatAI = 0;

	public const int DefaultTurnCameraWithHorseInFirstPerson = 2;

	public const int DefaultAutoSaveInterval = 30;

	public const float DefaultFriendlyTroopsBannerOpacity = 1f;

	public const int DefaultAlwaysShowFriendlyTroopBannersType = 1;

	public const bool DefaultShowFormationDistances = false;

	public const bool DefaultReportDamage = true;

	public const bool DefaultReportBark = true;

	public const bool DefaultEnableTutorialHints = true;

	public const int DefaultKillFeedVisualType = 1;

	public const int DefaultAutoTrackAttackedSettlements = 0;

	public const bool DefaultReportPersonalDamage = true;

	public const bool DefaultStopGameOnFocusLost = true;

	public const bool DefaultSlowDownOnOrder = true;

	public const bool DefaultReportExperience = true;

	public const bool DefaultEnableDamageTakenVisuals = true;

	public const bool DefaultEnableVoiceChat = true;

	public const bool DefaultEnableDeathIcon = true;

	public const bool DefaultEnableNetworkAlertIcons = true;

	public const bool DefaultEnableVerticalAimCorrection = true;

	public const float DefaultZoomSensitivityModifier = 0.66666f;

	public const bool DefaultSingleplayerEnableChatBox = true;

	public const bool DefaultMultiplayerEnableChatBox = true;

	public const float DefaultChatBoxSizeX = 495f;

	public const float DefaultChatBoxSizeY = 340f;

	public const int DefaultCrosshairType = 0;

	public const bool DefaultEnableGenericAvatars = false;

	public const bool DefaultEnableGenericNames = false;

	public const bool DefaultHideFullServers = false;

	public const bool DefaultHideEmptyServers = false;

	public const bool DefaultHidePasswordProtectedServers = false;

	public const bool DefaultHideUnofficialServers = false;

	public const bool DefaultHideModuleIncompatibleServers = false;

	public const bool DefaultShowOnlyFavoriteServers = false;

	public const int DefaultOrderLayoutType = 0;

	public const bool DefaultHideBattleUI = false;

	public const int DefaultUnitSpawnPrioritization = 0;

	public const int DefaultOrderType = 0;

	public const bool DefaultLockTarget = false;

	private static string _language;

	private static string _voiceLanguage;

	private static int _numberOfCorpses;

	private static int _battleSize;

	private static int _autoSaveInterval;

	private static bool _stopGameOnFocusLost;

	private static int _orderType;

	private static int _orderLayoutType;

	public static int MinBattleSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static int MaxBattleSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static int MinReinforcementWaveCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static int MaxReinforcementWaveCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static string DefaultLanguage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static string Language
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static string VoiceLanguage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1, 2 }, false)]
	public static int PlayerReceivedDamageDifficulty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool GyroOverrideForAttackDefend
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1, 2 }, false)]
	public static int AttackDirectionControl
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1, 2 }, false)]
	public static int DefendDirectionControl
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1, 2, 3, 4, 5 }, false)]
	public static int NumberOfCorpses
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool ShowBlood
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool DisplayAttackDirection
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool DisplayTargetingReticule
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool ForceVSyncInMenus
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1, 2, 3, 4, 5, 6 }, false)]
	public static int BattleSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1, 2, 3 }, false)]
	public static int ReinforcementWaveCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public static float CivilianAgentCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static float FirstPersonFov
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static float UIScale
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static float CombatCameraDistance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1, 2, 3 }, false)]
	public static int TurnCameraWithHorseInFirstPerson
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool ReportDamage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool ReportBark
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool LockTarget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool EnableTutorialHints
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static int AutoSaveInterval
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static float FriendlyTroopsBannerOpacity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1, 2 }, false)]
	public static int AlwaysShowFriendlyTroopBannersType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool ShowFormationDistances
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1, 2 }, false)]
	public static int KillFeedVisualType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1, 2 }, false)]
	public static int AutoTrackAttackedSettlements
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool ReportPersonalDamage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool SlowDownOnOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool StopGameOnFocusLost
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool ReportExperience
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool EnableDamageTakenVisuals
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool EnableVerticalAimCorrection
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static float ZoomSensitivityModifier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1 }, false)]
	public static int CrosshairType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool EnableGenericAvatars
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool EnableGenericNames
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool HideFullServers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool HideEmptyServers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool HidePasswordProtectedServers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool HideUnofficialServers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool HideModuleIncompatibleServers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool ShowOnlyFavoriteServers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1 }, false)]
	public static int OrderType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1 }, false)]
	public static int OrderLayoutType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool EnableVoiceChat
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool EnableDeathIcon
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool EnableNetworkAlertIcons
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool EnableSingleplayerChatBox
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool EnableMultiplayerChatBox
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static float ChatBoxSizeX
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static float ChatBoxSizeY
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static string LatestSaveGameName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool HideBattleUI
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyInt(new int[] { 0, 1, 2, 3 }, false)]
	public static int UnitSpawnPrioritization
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[ConfigPropertyUnbounded]
	public static bool IAPNoticeConfirmed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveResult Save()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDamageToPlayerMultiplier()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetRealBattleSize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetRealBattleSizeForSiege()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetRealBattleSizeForNaval()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetReinforcementWaveCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetRealBattleSizeForSallyOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetDefaultLanguage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static BannerlordConfig()
	{
		throw null;
	}
}
