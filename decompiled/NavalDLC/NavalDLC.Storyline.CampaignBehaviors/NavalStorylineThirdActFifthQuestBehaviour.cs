using System.Runtime.CompilerServices;
using NavalDLC.Storyline.MissionControllers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;

namespace NavalDLC.Storyline.CampaignBehaviors;

public class NavalStorylineThirdActFifthQuestBehaviour : CampaignBehaviorBase
{
	public enum NavalStorylineFinalQuestState
	{
		TalkWithGunnarAtPort,
		GunnarWaitsForAnAnswer,
		Quest5IsInProgress,
		TalkWithGunnarAfterFight,
		SpeakToGunnarAndSister,
		End
	}

	private const string QuestConversationMenuId = "naval_storyline_act_3_quest_5_conversation_menu";

	private const string GunnarsLongshipStringId = "northern_medium_ship";

	private const string Tier3NordInfantryStringId = "nord_spear_warrior";

	private const string Tier4NordInfantryStringId = "nord_vargr";

	private const int Tier3NordInfantryCount = 10;

	private const int Tier4NordInfantryCount = 10;

	private NavalStorylineFinalQuestState _navalStorylineFinalQuestState;

	private Quest5SetPieceBattleMissionController.BossFightOutComeEnum _bossFightOutCome;

	private bool _isQuestAcceptedThroughMission;

	private readonly float _strengthModifier;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameMenuOpened(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestCompleted(QuestBase quest, QuestCompleteDetails detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAfterSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDialogs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GunnarConversationOnConsequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeGunnarNotable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerAcceptsQuestThroughMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenQuestMenu()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGameMenus(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void naval_storyline_act_3_quest_5_conversation_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void naval_storyline_finalize_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool naval_storyline_finalize_menu_continue_option_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void naval_storyline_finalize_menu_continue_option_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ActivateQuest5()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool Quest5ConversationStartCondition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GunnarNotableConditions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quest5SetPieceBattleMissionController.BossFightOutComeEnum GetBossFightOutcome()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerWelcomedGunnarsCrew()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DecideGunnarDialogue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalStorylineThirdActFifthQuestBehaviour()
	{
		throw null;
	}
}
