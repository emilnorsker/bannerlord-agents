using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace StoryMode.GameComponents.CampaignBehaviors;

public class TutorialPhaseCampaignBehavior : CampaignBehaviorBase
{
	private bool _controlledByBrother;

	private bool _notifyPlayerAboutPosition;

	private Equipment[] _mainHeroEquipmentBackup;

	private Equipment[] _brotherEquipmentBackup;

	private float _distanceThresholdForQuestFocusTarget;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDialogAndGameMenus(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeTutorial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CanHaveCampaignIssuesInfoIsRequested(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CanHeroMarry(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCharacterCreationIsOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreatedPartialFollowUp(CampaignGameStarter campaignGameStarter, int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizeTutorialPhase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowStealthTutorialInquiry()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartStealthTutorial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateHeadman(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool recruit_troops_village_menu_option_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool buy_products_village_menu_option_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool raid_village_menu_option_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool wait_village_menu_option_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool PlaceholderOptionsClickableCondition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void storymode_recruit_volunteers_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void storymode_ui_village_buy_good_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("storymode_tutorial_village_game_menu")]
	private static void storymode_tutorial_village_game_menu_on_init_background(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("storymode_game_menu_blocker")]
	private static void storymode_tutorial_blocker_game_menu_on_init_background(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void storymode_game_menu_blocker_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void storymode_tutorial_village_game_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool storymode_conversation_blocker_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool storymode_tutorial_village_enter_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void storymode_tutorial_village_enter_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool game_menu_leave_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool game_menu_leave_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void game_menu_leave_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnYourBrotherInLocation(Hero hero, string locationId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestCompleted(QuestBase quest, QuestCompleteDetails detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementLeft(MobileParty party, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfMainPartyStarving()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAllNotablesForVillage(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TutorialPhaseCampaignBehavior()
	{
		throw null;
	}
}
