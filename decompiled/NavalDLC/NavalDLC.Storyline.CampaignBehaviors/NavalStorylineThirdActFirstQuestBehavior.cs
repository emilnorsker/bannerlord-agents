using System.Runtime.CompilerServices;
using NavalDLC.Storyline.Quests;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;

namespace NavalDLC.Storyline.CampaignBehaviors;

public class NavalStorylineThirdActFirstQuestBehavior : CampaignBehaviorBase
{
	private const string _questConversationMenuId = "naval_storyline_act_3_quest_1_conversation_menu";

	private bool _isIntroGiven;

	private bool _isQuestAcceptedThroughMission;

	private SetSailAndEscortTheFortuneSeekersQuest _cachedQuest;

	private IFaction _merchantsFaction;

	private static SetSailAndEscortTheFortuneSeekersQuest Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
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
	private void OnQuestStarted(QuestBase quest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNavalStorylineCanceled(NavalStorylineData.StorylineCancelDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAfterSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGameMenus(CampaignGameStarter gameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void naval_storyline_act_3_quest_1_conversation_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGangradirInitialDialogFlow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddMerchantsDialogueFlow(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool merchant_meeting_dialogue_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMerchantConversationEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsQuest1ReadyToStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerAcceptsQuestThroughMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerAgreedToHelp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalStorylineThirdActFirstQuestBehavior()
	{
		throw null;
	}
}
