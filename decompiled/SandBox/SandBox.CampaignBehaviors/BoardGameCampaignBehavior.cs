using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;

namespace SandBox.CampaignBehaviors;

public class BoardGameCampaignBehavior : CampaignBehaviorBase
{
	[CompilerGenerated]
	private sealed class _003Cget_WonBoardGamesInOneWeekInSettlement_003Ed__12 : IEnumerable<Settlement>, IEnumerable, IEnumerator<Settlement>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Settlement _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public BoardGameCampaignBehavior _003C_003E4__this;

		private Dictionary<Settlement, CampaignTime>.KeyCollection.Enumerator _003C_003E7__wrap1;

		Settlement IEnumerator<Settlement>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003Cget_WonBoardGamesInOneWeekInSettlement_003Ed__12(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<Settlement> IEnumerable<Settlement>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	private const int NumberOfBoardGamesCanPlayerPlayAgainstHeroPerDay = 3;

	private Dictionary<Hero, List<CampaignTime>> _heroAndBoardGameTimeDictionary;

	private Dictionary<Settlement, CampaignTime> _wonBoardGamesInOneWeekInSettlement;

	private AIDifficulty _difficulty;

	private int _betAmount;

	private bool _influenceGained;

	private bool _renownGained;

	private bool _opposingHeroExtraXPGained;

	private bool _relationGained;

	private bool _gainedNothing;

	private CultureObject _initializedBoardGameCultureInMission;

	public IEnumerable<Settlement> WonBoardGamesInOneWeekInSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_WonBoardGamesInOneWeekInSettlement_003Ed__12))]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionEnd(IMission obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WeeklyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerBoardGameOver(Hero opposingHero, BoardGameState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeConversationVars()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMissionStarted(IMission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CultureObject GetBoardGameCulture()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeBoardGamePrefabInMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LocationCharactersAreReadyToSpawn(Dictionary<string, int> unusedUsablePointCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateGameHost(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddDialogs(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_lord_reject_game_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_talk_common_to_taverngamehost_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_taverngamehost_bet_0_denars_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_taverngamehost_can_bet_100_denars_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_taverngamehost_bet_100_denars_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_taverngamehost_can_bet_200_denars_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_taverngamehost_bet_200_denars_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_taverngamehost_can_bet_300_denars_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_taverngamehost_bet_300_denars_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_taverngamehost_can_bet_400_denars_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_taverngamehost_bet_400_denars_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_taverngamehost_can_bet_500_denars_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool taverngame_host_play_game_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_taverngamehost_bet_500_denars_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_taverngamehost_difficulty_easy_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_taverngamehost_difficulty_normal_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_taverngamehost_difficulty_hard_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void conversation_lord_play_game_again_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void conversation_lord_dont_play_game_again_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_lord_detect_difficulty_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void conversation_taverngamehost_set_player_one_starts_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void conversation_taverngamehost_set_player_two_starts_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void conversation_taverngamehost_play_game_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_taverngamehost_talk_place_bet_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_taverngamehost_talk_not_place_bet_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_taverngamehost_talk_is_seega_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_taverngamehost_talk_is_puluc_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_taverngamehost_talk_is_mutorere_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_taverngamehost_talk_is_konane_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_taverngamehost_talk_is_baghchal_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_taverngamehost_talk_is_tablut_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool taverngamehost_player_sitting_now_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_lord_talk_game_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_lord_talk_game_again_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool conversation_lord_talk_cancel_game_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void conversation_lord_talk_cancel_game_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool lord_after_lord_win_boardgame_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool lord_after_player_win_boardgame_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_lord_play_game_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void conversation_lord_play_game_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PlayerWonAgainstTavernChampion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GameEndWithHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanPlayerPlayBoardGameAgainstHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeleteOldBoardGamesOfChampion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeleteOldBoardGamesOfHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBetAmount(int bet)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetDifficulty(AIDifficulty difficulty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoardGameCampaignBehavior()
	{
		throw null;
	}
}
