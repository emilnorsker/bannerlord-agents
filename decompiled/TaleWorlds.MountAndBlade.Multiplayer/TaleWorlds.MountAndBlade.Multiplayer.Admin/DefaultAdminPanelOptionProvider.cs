using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Multiplayer.Admin.Internal;

namespace TaleWorlds.MountAndBlade.Multiplayer.Admin;

public class DefaultAdminPanelOptionProvider : IAdminPanelOptionProvider
{
	public static class DefaultOptionIds
	{
		public const string NextGameType = "next_game_type";

		public const string NextMap = "next_map";

		public const string NextCultureTeam1 = "next_culture_team_1";

		public const string NextCultureTeam2 = "next_culture_team_2";

		public const string NextNumberOfRounds = "next_number_of_rounds";

		public const string NextMinScoreToWinDuel = "next_min_score_to_win_duel";

		public const string NextMapTimeLimit = "next_map_time_limit";

		public const string NextRoundTimeLimit = "next_round_time_limit";

		public const string NextWarmupTimeLimit = "next_warmup_time_limit";

		public const string NextMaxNumberOfPlayers = "next_max_num_players";

		public const string ApplyAndStartMission = "apply_and_start";

		public const string WelcomeMessage = "welcome_message";

		public const string AutoTeamBalanceTreshold = "auto_balance_treshold";

		public const string FriendlyFireMeleePercent = "friendly_fire_melee_percent";

		public const string FriendlyFireMeleeReflectionPercent = "friendly_fire_melee_self_percent";

		public const string FriendlyFireRangedPercent = "friendly_fire_ranged_percent";

		public const string FriendlyFireRangedReflectionPercent = "friendly_fire_ranged_self_percent";

		public const string AllowInfantry = "allow_infantry";

		public const string AllowRanged = "allow_ranged";

		public const string AllowCavalry = "allow_cavalry";

		public const string AllowHorseArchers = "allow_horse_archers";

		public const string EndWarmup = "end_warmup";

		public const string MutePlayer = "mute_player";

		public const string KickPlayer = "kick_player";

		public const string BanPlayer = "ban_player";
	}

	private class AdminPanelVotableMultiSelectionOption : AdminPanelMultiSelectionOption
	{
		protected readonly IAdminPanelMultiSelectionItem _undecidedOption;

		public bool IsUndecided
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
		public AdminPanelVotableMultiSelectionOption(string uniqueId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnValueChanged(IAdminPanelMultiSelectionItem previousValue, IAdminPanelMultiSelectionItem newValue)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override AdminPanelMultiSelectionOption BuildAvailableOptions(MBReadOnlyList<IAdminPanelMultiSelectionItem> options)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override AdminPanelMultiSelectionOption BuildAvailableOptions(OptionType optionType, bool buildDefaultValue = true)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void AddUndecidedOption()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void RemoveUndecidedOption()
		{
			throw null;
		}
	}

	private class AdminPanelCultureOption : AdminPanelVotableMultiSelectionOption
	{
		private bool _shouldKeepUndecidedOption;

		private AdminPanelCultureOption _otherOption;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelCultureOption(string uniqueId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelCultureOption BuildOtherCultureOption(AdminPanelCultureOption otherOption)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnFinalize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnValueChanged(IAdminPanelMultiSelectionItem previousValue, IAdminPanelMultiSelectionItem newValue)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnOtherOptionValueChanged()
		{
			throw null;
		}
	}

	private class AdminPanelUsableMapsOption : AdminPanelVotableMultiSelectionOption
	{
		private const string _disabledOptionTag = "map_option_disabled";

		private const string _undecidedOptionTag = "map_option_undecided";

		private readonly Dictionary<string, MBList<IAdminPanelMultiSelectionItem>> _optionsByGameType;

		private readonly IAdminPanelMultiSelectionItem _disabledOption;

		private bool _isUpdatingOptions;

		private AdminPanelVotableMultiSelectionOption _gameTypeOption;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelUsableMapsOption(string uniqueId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelUsableMapsOption BuildGameTypeOption(AdminPanelVotableMultiSelectionOption gameTypeOption)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnFinalize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool GetIsDisabled(out string reason)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateOptions()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void FilterAvailableOptions(List<string> availableOptions)
		{
			throw null;
		}
	}

	private class AdminPanelStartMissionAction : AdminPanelAction
	{
		private MBReadOnlyList<IAdminPanelOptionGroup> _optionGroups;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelStartMissionAction(string uniqueId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelStartMissionAction BuildOptionGroups(MBReadOnlyList<IAdminPanelOptionGroup> optionGroups)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool GetIsDisabled(out string reason)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnFinalize()
		{
			throw null;
		}
	}

	private class AdminPanelGameTypeDependentNumericOption : AdminPanelNumericOption
	{
		private AdminPanelVotableMultiSelectionOption _gameTypeOption;

		private List<string> _invalidGameTypes;

		private List<string> _requiredGameTypes;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelGameTypeDependentNumericOption(string uniqueId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool GetIsAvailable()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelGameTypeDependentNumericOption BuildGameTypeOption(AdminPanelVotableMultiSelectionOption gameTypeOption)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelGameTypeDependentNumericOption BuildInvalidGameTypes(string[] gameTypes)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelGameTypeDependentNumericOption BuildRequiredGameTypes(string[] gameTypes)
		{
			throw null;
		}
	}

	private class AdminPanelGameTypeDependentAction : AdminPanelAction
	{
		private AdminPanelVotableMultiSelectionOption _gameTypeOption;

		private List<string> _invalidGameTypes;

		private List<string> _requiredGameTypes;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelGameTypeDependentAction(string uniqueId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool GetIsAvailable()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelGameTypeDependentAction BuildGameTypeOption(AdminPanelVotableMultiSelectionOption gameTypeOption)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelGameTypeDependentAction BuildInvalidGameTypes(string[] gameTypes)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelGameTypeDependentAction BuildRequiredGameTypes(string[] gameTypes)
		{
			throw null;
		}
	}

	private readonly MultiplayerAdminComponent _multiplayerAdminComponent;

	private readonly MissionLobbyComponent _missionLobbyComponent;

	private MBList<IAdminPanelOptionGroup> _optionGroups;

	private AdminPanelVotableMultiSelectionOption _gameTypeOption;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultAdminPanelOptionProvider(MultiplayerAdminComponent adminComponent, MissionLobbyComponent missionLobbyComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IAdminPanelOption GetOptionWithId(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IAdminPanelAction GetActionWithId(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<IAdminPanelOptionGroup> GetOptionGroups()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T GetValueFromOption<T>(string optionId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private AdminPanelOptionGroup GetMissionOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private AdminPanelOptionGroup GetImmediateEffectOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private AdminPanelOptionGroup GetActions()
	{
		throw null;
	}
}
