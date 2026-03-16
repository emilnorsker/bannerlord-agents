using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.SaveSystem;

namespace NavalDLC.Storyline.Quests;

public class CaptureTheImperialMerchantPrusas : NavalStorylineQuestBase
{
	private const int NumberOfCorsairParties = 2;

	private const int CalculatingBonusAmount = 50;

	private const int HonorBonusAmount = 50;

	private const int CorsairShipAiDisableTimeAsHours = 3;

	[SaveableField(1)]
	private List<MobileParty> _corsairParties;

	[SaveableField(2)]
	private JournalLog _playerStartsQuestLog;

	[SaveableField(3)]
	private CampaignVec2 _corsairSpawnPosition;

	[SaveableField(4)]
	private int _numberOfDefeatedCorsairParties;

	[SaveableField(5)]
	private MobileParty _bossCorsairParty;

	[SaveableField(6)]
	private bool _battleWon;

	[SaveableField(7)]
	private bool _willProgressStoryline;

	[SaveableField(8)]
	private int _selectedOption;

	[SaveableField(9)]
	private bool _checkpointReached;

	[SaveableField(10)]
	private bool _hasRanMissionBefore;

	private bool _shouldRunMission;

	private const string Act3Quest4CorsairPartyTemplateStringId = "storyline_act3_quest_4_corsair_generic_template";

	private const string Act3Quest4BossCorsairPartyTemplateStringId = "storyline_act3_quest_4_boss_corsair_template";

	public int SelectedOption
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

	public override TextObject Title
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject DescriptionLogText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject MainCorsairShipSpawnedLogText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject PlayerStartsQuestLogText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject QuestSucceededWithHonorableOptionLogText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject QuestSucceededWithCalculatingOptionLogText
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

	protected override string MainPartyTemplateStringId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CaptureTheImperialMerchantPrusas(string questId, Hero questGiver, CampaignVec2 corsairSpawnPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalizeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void InitializeQuestOnGameLoadInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetDialogs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnStartQuestInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void IsNavalQuestPartyInternal(PartyBase party, NavalStorylinePartyData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCompleteWithSuccessInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFailedInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCheckPointReached()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RegisterEventsInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventStarted(MapEvent mapEvent, PartyBase partyBase1, PartyBase partyBase2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipOwnerChanged(Ship ship, PartyBase partyBase, ShipOwnerChangeDetail shipOwnerChangeDetail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnConversationEnded(IEnumerable<CharacterObject> conversationCharacters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBeforeGameMenuOpened(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameMenuOpened(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionEnded(IMission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyDestroyed(MobileParty party, PartyBase partyBase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDialogsForFinalFight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerSelectsOption1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerSelectsOption2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMainHero(IAgent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsCrusas(IAgent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsBjolgur(IAgent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsGangradir(IAgent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool MultiAgentConversationCondition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnBjolgur()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnGangradir()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartBattle(bool startFromCheckpoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnMainCorsairParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupCorsairParty(MobileParty corsairParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroyCorsairParties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGameMenus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool game_menu_encounter_retry_attack_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void game_menu_encounter_retry_attack_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool game_menu_encounter_retry_continue_from_checkpoint_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void game_menu_encounter_retry_continue_from_checkpoint_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool game_menu_encounter_retry_leave_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void game_menu_encounter_retry_leave_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void naval_storyline_act_3_quest_4_encounter_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool naval_storyline_act_3_quest_4_encounter_menu_continue_option_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void naval_storyline_act_3_quest_4_encounter_menu_continue_option_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("naval_storyline_act_3_quest_4_encounter_menu")]
	[GameMenuInitializationHandler("naval_storyline_act_3_quest_4_encounter_retry")]
	private static void quest_game_menus_on_init_background(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsCrusasVisible()
	{
		throw null;
	}
}
