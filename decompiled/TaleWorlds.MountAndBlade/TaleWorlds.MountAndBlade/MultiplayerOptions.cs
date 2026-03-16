using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerOptions
{
	public enum MultiplayerOptionsAccessMode
	{
		DefaultMapOptions,
		CurrentMapOptions,
		NextMapOptions,
		NumAccessModes
	}

	public enum OptionValueType
	{
		Bool,
		Integer,
		Enum,
		String
	}

	public enum OptionType
	{
		[MultiplayerOptionsProperty(OptionValueType.String, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Changes the name of the server in the server list", 0, 0, null, false, null)]
		ServerName,
		[MultiplayerOptionsProperty(OptionValueType.String, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Welcome messages which is shown to all players when they enter the server.", 0, 0, null, false, null)]
		WelcomeMessage,
		[MultiplayerOptionsProperty(OptionValueType.String, MultiplayerOptionsProperty.ReplicationOccurrence.Never, "Sets a password that clients have to enter before connecting to the server.", 0, 0, null, false, null)]
		GamePassword,
		[MultiplayerOptionsProperty(OptionValueType.String, MultiplayerOptionsProperty.ReplicationOccurrence.Never, "Sets a password that allows players access to admin tools during the game.", 0, 0, null, false, null)]
		AdminPassword,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Never, "Sets ID of the private game definition.", int.MinValue, int.MaxValue, null, false, null)]
		GameDefinitionId,
		[MultiplayerOptionsProperty(OptionValueType.Bool, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Allow players to start polls to kick other players.", 0, 0, null, false, null)]
		AllowPollsToKickPlayers,
		[MultiplayerOptionsProperty(OptionValueType.Bool, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Allow players to start polls to ban other players.", 0, 0, null, false, null)]
		AllowPollsToBanPlayers,
		[MultiplayerOptionsProperty(OptionValueType.Bool, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Allow players to start polls to change the current map.", 0, 0, null, false, null)]
		AllowPollsToChangeMaps,
		[MultiplayerOptionsProperty(OptionValueType.Bool, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Allow players to use their custom banner.", 0, 0, null, false, null)]
		AllowIndividualBanners,
		[MultiplayerOptionsProperty(OptionValueType.Bool, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Use animation progress dependent blocking.", 0, 0, null, false, null)]
		UseRealisticBlocking,
		[MultiplayerOptionsProperty(OptionValueType.String, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Changes the game type.", 0, 0, null, true, null)]
		PremadeMatchGameMode,
		[MultiplayerOptionsProperty(OptionValueType.String, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Changes the game type.", 0, 0, null, true, null)]
		GameType,
		[MultiplayerOptionsProperty(OptionValueType.Enum, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Type of the premade game.", 0, 1, null, true, typeof(PremadeGameType))]
		PremadeGameType,
		[MultiplayerOptionsProperty(OptionValueType.String, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Map of the game.", 0, 0, null, true, null)]
		Map,
		[MultiplayerOptionsProperty(OptionValueType.String, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Sets culture for team 1", 0, 0, null, true, null)]
		CultureTeam1,
		[MultiplayerOptionsProperty(OptionValueType.String, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Sets culture for team 2", 0, 0, null, true, null)]
		CultureTeam2,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Set the maximum amount of player allowed on the server.", 1, 1023, null, false, null)]
		MaxNumberOfPlayers,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Set the amount of players that are needed to start the first round. If not met, players will just wait.", 0, 20, null, false, null)]
		MinNumberOfPlayersForMatchStart,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Amount of bots on team 1", 0, 510, null, false, null)]
		NumberOfBotsTeam1,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Amount of bots on team 2", 0, 510, new string[] { "Battle", "NewBattle", "ClassicBattle", "Captain", "Skirmish", "Siege", "TeamDeathmatch" }, false, null)]
		NumberOfBotsTeam2,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Amount of bots per formation", 0, 100, new string[] { "Captain" }, false, null)]
		NumberOfBotsPerFormation,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "A percentage of how much melee damage inflicted upon a friend is dealt back to the inflictor.", 0, 2000, new string[] { "Battle", "NewBattle", "ClassicBattle", "Captain", "Skirmish", "Siege", "TeamDeathmatch" }, false, null)]
		FriendlyFireDamageMeleeSelfPercent,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "A percentage of how much melee damage inflicted upon a friend is actually dealt.", 0, 2000, new string[] { "Battle", "NewBattle", "ClassicBattle", "Captain", "Skirmish", "Siege", "TeamDeathmatch" }, false, null)]
		FriendlyFireDamageMeleeFriendPercent,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "A percentage of how much ranged damage inflicted upon a friend is dealt back to the inflictor.", 0, 2000, new string[] { "Battle", "NewBattle", "ClassicBattle", "Captain", "Skirmish", "Siege", "TeamDeathmatch" }, false, null)]
		FriendlyFireDamageRangedSelfPercent,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "A percentage of how much ranged damage inflicted upon a friend is actually dealt.", 0, 2000, new string[] { "Battle", "NewBattle", "ClassicBattle", "Captain", "Skirmish", "Siege", "TeamDeathmatch" }, false, null)]
		FriendlyFireDamageRangedFriendPercent,
		[MultiplayerOptionsProperty(OptionValueType.Enum, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Who can spectators look at, and how.", 0, 7, null, true, typeof(SpectatorCameraTypes))]
		SpectatorCamera,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Maximum duration for the warmup. In seconds.", 60, 3600, null, false, null)]
		WarmupTimeLimitInSeconds,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Maximum duration for the map. In minutes.", 1, 60, null, false, null)]
		MapTimeLimit,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Maximum duration for each round. In seconds.", 60, 3600, new string[] { "Battle", "NewBattle", "ClassicBattle", "Captain", "Skirmish", "Siege" }, false, null)]
		RoundTimeLimit,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Time available to select class/equipment. In seconds.", 2, 60, new string[] { "Battle", "NewBattle", "ClassicBattle", "Captain", "Skirmish", "Siege" }, false, null)]
		RoundPreparationTimeLimit,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Maximum amount of rounds before the game ends.", 1, 99, new string[] { "Battle", "NewBattle", "ClassicBattle", "Captain", "Skirmish", "Siege" }, false, null)]
		RoundTotal,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Wait time after death, before respawning again. In seconds.", 1, 60, new string[] { "Siege" }, false, null)]
		RespawnPeriodTeam1,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Wait time after death, before respawning again. In seconds.", 1, 60, new string[] { "Siege" }, false, null)]
		RespawnPeriodTeam2,
		[MultiplayerOptionsProperty(OptionValueType.Bool, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Unlimited gold option.", 0, 0, new string[] { "Battle", "Skirmish", "Siege", "TeamDeathmatch" }, false, null)]
		UnlimitedGold,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Gold gain multiplier from agent deaths.", -100, 100, new string[] { "Siege", "TeamDeathmatch" }, false, null)]
		GoldGainChangePercentageTeam1,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Gold gain multiplier from agent deaths.", -100, 100, new string[] { "Siege", "TeamDeathmatch" }, false, null)]
		GoldGainChangePercentageTeam2,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Min score to win match.", 0, 1023000, new string[] { "TeamDeathmatch" }, false, null)]
		MinScoreToWinMatch,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Min score to win duel.", 0, 7, new string[] { "Duel" }, false, null)]
		MinScoreToWinDuel,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Minimum needed difference in poll results before it is accepted.", 0, 10, null, false, null)]
		PollAcceptThreshold,
		[MultiplayerOptionsProperty(OptionValueType.Integer, MultiplayerOptionsProperty.ReplicationOccurrence.Immediately, "Maximum player imbalance between team 1 and team 2. Selecting 0 will disable auto team balancing.", 0, 30, null, false, null)]
		AutoTeamBalanceThreshold,
		[MultiplayerOptionsProperty(OptionValueType.Bool, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Enables mission recording.", 0, 0, null, false, null)]
		EnableMissionRecording,
		[MultiplayerOptionsProperty(OptionValueType.Bool, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Sets if the game mode uses single spawning.", 0, 0, null, false, null)]
		SingleSpawn,
		[MultiplayerOptionsProperty(OptionValueType.Bool, MultiplayerOptionsProperty.ReplicationOccurrence.AtMapLoad, "Disables the inactivity kick timer.", 0, 0, null, false, null)]
		DisableInactivityKick,
		NumOfSlots
	}

	public enum OptionsCategory
	{
		Default,
		PremadeMatch
	}

	public class MultiplayerOption
	{
		private struct IntegerValue
		{
			public static IntegerValue Invalid
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				get
				{
					throw null;
				}
			}

			public bool IsValid
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				[CompilerGenerated]
				get
				{
					throw null;
				}
				[MethodImpl(MethodImplOptions.NoInlining)]
				[CompilerGenerated]
				private set
				{
					throw null;
				}
			}

			public int Value
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				[CompilerGenerated]
				get
				{
					throw null;
				}
				[MethodImpl(MethodImplOptions.NoInlining)]
				[CompilerGenerated]
				private set
				{
					throw null;
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static IntegerValue Create()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void UpdateValue(int value)
			{
				throw null;
			}
		}

		private struct StringValue
		{
			public static StringValue Invalid
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				get
				{
					throw null;
				}
			}

			public bool IsValid
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				[CompilerGenerated]
				get
				{
					throw null;
				}
				[MethodImpl(MethodImplOptions.NoInlining)]
				[CompilerGenerated]
				private set
				{
					throw null;
				}
			}

			public string Value
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				[CompilerGenerated]
				get
				{
					throw null;
				}
				[MethodImpl(MethodImplOptions.NoInlining)]
				[CompilerGenerated]
				private set
				{
					throw null;
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static StringValue Create()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void UpdateValue(string value)
			{
				throw null;
			}
		}

		public readonly OptionType OptionType;

		private IntegerValue _intValue;

		private StringValue _stringValue;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MultiplayerOption CreateMultiplayerOption(OptionType optionType)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MultiplayerOption CopyMultiplayerOption(MultiplayerOption option)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private MultiplayerOption(OptionType optionType)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MultiplayerOption UpdateValue(bool value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MultiplayerOption UpdateValue(int value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MultiplayerOption UpdateValue(string value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void GetValue(out bool value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void GetValue(out int value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void GetValue(out string value)
		{
			throw null;
		}
	}

	private class MultiplayerOptionsContainer
	{
		private readonly MultiplayerOption[] _multiplayerOptions;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MultiplayerOptionsContainer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MultiplayerOption GetOptionFromOptionType(OptionType optionType)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CopyOptionFromOther(OptionType optionType, MultiplayerOption option)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CreateOption(OptionType optionType)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UpdateOptionValue(OptionType optionType, int value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UpdateOptionValue(OptionType optionType, string value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UpdateOptionValue(OptionType optionType, bool value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CopyAllValuesTo(MultiplayerOptionsContainer other)
		{
			throw null;
		}
	}

	private const int PlayerCountLimitMin = 1;

	private const int PlayerCountLimitMax = 1023;

	private const int PlayerCountLimitForMatchStartMin = 0;

	private const int PlayerCountLimitForMatchStartMax = 20;

	private const int MapTimeLimitMin = 1;

	private const int MapTimeLimitMax = 60;

	private const int WarmupTimeLimitMin = 60;

	private const int WarmupTimeLimitMax = 3600;

	private const int RoundLimitMin = 1;

	private const int RoundLimitMax = 99;

	private const int RoundTimeLimitMin = 60;

	private const int RoundTimeLimitMax = 3600;

	private const int RoundPreparationTimeLimitMin = 2;

	private const int RoundPreparationTimeLimitMax = 60;

	private const int RespawnPeriodMin = 1;

	private const int RespawnPeriodMax = 60;

	private const int GoldGainChangePercentageMin = -100;

	private const int GoldGainChangePercentageMax = 100;

	private const int PollAcceptThresholdMin = 0;

	private const int PollAcceptThresholdMax = 10;

	private const int BotsPerTeamLimitMin = 0;

	private const int BotsPerTeamLimitMax = 510;

	private const int BotsPerFormationLimitMin = 0;

	private const int BotsPerFormationLimitMax = 100;

	private const int FriendlyFireDamagePercentMin = 0;

	private const int FriendlyFireDamagePercentMax = 2000;

	private const int GameDefinitionIdMin = int.MinValue;

	private const int GameDefinitionIdMax = int.MaxValue;

	private const int MaxScoreToEndDuel = 7;

	private static MultiplayerOptions _instance;

	private readonly MultiplayerOptionsContainer _default;

	private readonly MultiplayerOptionsContainer _current;

	private readonly MultiplayerOptionsContainer _next;

	public OptionsCategory CurrentOptionsCategory;

	public static MultiplayerOptions Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Release()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerOption GetOptionFromOptionType(OptionType optionType, MultiplayerOptionsAccessMode mode = MultiplayerOptionsAccessMode.CurrentMapOptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnGameTypeChanged(MultiplayerOptionsAccessMode mode = MultiplayerOptionsAccessMode.CurrentMapOptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeNextAndDefaultOptionContainers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeForTeamDeathmatch(MultiplayerOptionsAccessMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeForDuel(MultiplayerOptionsAccessMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeForSiege(MultiplayerOptionsAccessMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeForCaptain(MultiplayerOptionsAccessMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeForSkirmish(MultiplayerOptionsAccessMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeForBattle(MultiplayerOptionsAccessMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfPlayersForGameMode(string gameModeID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRoundCountForGameMode(string gameModeID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRoundTimeLimitInMinutesForGameMode(string gameModeID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeFromCommandList(List<string> arguments)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetDefaultsToCurrent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<string> GetMultiplayerOptionsTextList(OptionType optionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<string> GetMultiplayerOptionsList(OptionType optionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<string> GetAvailableClanMatchScenes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MultiplayerOptionsContainer GetContainer(MultiplayerOptionsAccessMode mode = MultiplayerOptionsAccessMode.CurrentMapOptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeAllOptionsFromNext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMbMultiplayerData(MultiplayerOptionsContainer container)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList<string> GetMapList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetValueTextForOptionWithMultipleSelection(OptionType optionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetValueForOptionWithMultipleSelectionFromText(OptionType optionType, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetLocalizedCultureNameFromStringID(string cultureID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryGetOptionTypeFromString(string optionTypeString, out OptionType optionType, out MultiplayerOptionsProperty optionAttribute)
	{
		throw null;
	}
}
