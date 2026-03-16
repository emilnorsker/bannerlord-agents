using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Storyline.MissionControllers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace NavalDLC.Storyline.Quests;

public class FreeTheSeaHoundsCaptivesQuest : NavalStorylineQuestBase
{
	public enum FreeTheSeaHoundsCaptivesQuestState
	{
		None,
		RestartMission,
		GoToSeaHoundPartyPosition,
		EncounteredWithSeaHoundsParty,
		TalkedWithGunnarBeforeFight,
		TalkedWithPurigBeforeBossFight,
		PlayerLostBossFight,
		DefeatedPurig,
		HeadBackToOstican
	}

	private const int PlayerLostDuelAndLetPurigGoHonorBonus = 50;

	private const int PlayerLostDuelAndKilledPurigHonorPenalty = -50;

	private const int PlayerLostDuelAndKilledPurigRenownBonus = 50;

	private const string SeaHoundSetPieceBattlePartyTemplateString = "storyline_act3_quest_5_sea_hounds_set_piece_battle_template";

	private const string SeaHoundPartyTemplateStringId = "storyline_act3_quest_5_sea_hounds_template";

	private const string EncounterMenuId = "act_3_quest_5_encounter_menu";

	private const string MissionMenuId = "act_3_quest_5_mission_menu";

	private const string SetPieceBattleSceneName = "naval_storyline_act_3_quest_5";

	private const int SeaHoundPartySize = 67;

	private const string NordMediumShipStringId = "nord_medium_ship";

	private const string AseraiHeavyShipStringId = "aserai_heavy_ship";

	[SaveableField(1)]
	private MobileParty _seaHoundsParty;

	private bool _shouldMissionContinueFromCheckpoint;

	[SaveableField(0)]
	private FreeTheSeaHoundsCaptivesQuestState _currentState;

	[SaveableField(7)]
	private float _strengthModifier;

	private bool _isPurigKilledViaConversation;

	private bool _isSisterSavedSceneNotificationTriggered;

	[SaveableField(12)]
	private readonly MapMarker _skatriaIslandsMarker;

	[SaveableField(13)]
	private Quest5SetPieceBattleMissionController.Quest5SetPieceBattleMissionState _lastHitCheckpoint;

	[SaveableField(14)]
	public Quest5SetPieceBattleMissionController.BossFightOutComeEnum BossFightOutCome;

	private readonly List<KeyValuePair<string, string>> _seaHoundPartyShipUpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _nordMediumShipyShipUpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _aseraiHeavyShipUpgradePieceList;

	public override TextObject Title
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override NavalStorylineData.NavalStorylineStage Stage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool WillProgressStoryline
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override string MainPartyTemplateStringId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private CampaignVec2 _seaHoundsSpawnPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _allyDefeatedText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _findSeaHoundsQuestLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _arrivedAngranfjordQuestLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FreeTheSeaHoundsCaptivesQuest(string questId, float strengthModifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void PreAfterLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void InitializeQuestOnGameLoadInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RegisterEventsInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetDialogs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnBjolgur()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BossFightAftermathConversationWithPurigConsequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GunnarInitialMeetingDialogCondition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GunnarInitialMeetingDialogConsequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DuelLostPopUpConsequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGameMenus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleMenuInitState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mission_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void game_menu_encounter_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("act_3_quest_5_encounter_menu")]
	private static void quest_game_menus_on_init_background(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool encounter_menu_continue_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void encounter_menu_continue_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool encounter_menu_checkpoint_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void encounter_menu_checkpoint_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool encounter_menu_start_over_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void encounter_menu_start_over_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool encounter_menu_leave_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void encounter_menu_leave_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeSetPieceBattleMission(Quest5SetPieceBattleMissionController.Quest5SetPieceBattleMissionState checkpoint = Quest5SetPieceBattleMissionController.Quest5SetPieceBattleMissionState.InitializePhase1Part1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnStartQuestInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPartyVisibilityChanged(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CanHeroBecomePrisoner(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionEnded(IMission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalizeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCompleteWithSuccessInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateSeaHoundParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroySeaHoundParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void FillParty(MobileParty mobileParty, PartyTemplateObject partyTemplate, int desiredMenCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowNavalSaveSisterSceneNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNavalSaveSisterSceneNotificationClosed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowAllyDefeatedPopUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAllyDefeatedPopUpClosed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanStartFromCheckPoint()
	{
		throw null;
	}
}
