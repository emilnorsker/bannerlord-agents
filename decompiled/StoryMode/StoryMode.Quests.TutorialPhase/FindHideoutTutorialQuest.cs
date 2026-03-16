using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace StoryMode.Quests.TutorialPhase;

public class FindHideoutTutorialQuest : StoryModeQuestBase
{
	public enum HideoutBattleEndState
	{
		None,
		Retreated,
		Defeated,
		Victory
	}

	private const string RaiderPartyStringId = "radagos_raider_party_";

	private const string TutorialHideoutSceneName = "forest_hideout_003";

	private const int RaiderPartyCount = 2;

	private const int RaiderPartySize = 4;

	private const int MainPartyHealHitPointLimit = 50;

	private const int MaximumHealth = 100;

	private const int PlayerPartySizeMinLimitToAttack = 4;

	[SaveableField(1)]
	private readonly Settlement _hideout;

	[SaveableField(2)]
	private List<MobileParty> _raiderParties;

	private bool _foughtWithRadagos;

	private bool _dueledRadagos;

	[SaveableField(4)]
	private bool _talkedWithRadagos;

	[SaveableField(5)]
	private bool _talkedWithBrother;

	[SaveableField(6)]
	private HideoutBattleEndState _hideoutBattleEndState;

	private List<CharacterObject> _mainPartyTroopBackup;

	private static string _activeHideoutStringId;

	private TextObject _startQuestLog
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FindHideoutTutorialQuest(Hero questGiver, Settlement hideout)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroCanDieInfoIsRequested(Hero hero, KillCharacterActionDetail causeOfDeath, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroCanBeSelectedInInventoryInfoIsRequested(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroCanHaveCampaignIssuesInfoIsRequested(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void InitializeQuestOnGameLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnStartQuest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeHideout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MobileParty CreateRaiderParty(int number, bool isBanditBossParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetDialogs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool bandit_hideout_boss_fight_start_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bandit_hideout_start_duel_fight_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool bandit_hideout_continue_battle_on_clickable_condition(out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bandit_hideout_continue_battle_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool radagos_meeting_conversation_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void radagos_meeting_conversation_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenBrotherConversationMenu()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool brother_farewell_conversation_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SelectClanName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnChangeClanNameDone(string newClanName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool OpenBannerSelectionScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameMenuOpened(MenuCallbackArgs menuCallbackArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyDestroyed(MobileParty mobileParty, PartyBase destroyerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGameMenus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void brother_chest_menu_on_init(MenuCallbackArgs menuCallbackArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool brother_chest_menu_on_condition(MenuCallbackArgs menuCallbackArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void brother_chest_menu_on_consequence(MenuCallbackArgs menuCallbackArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void radagos_hideout_menu_on_init(MenuCallbackArgs menuCallbackArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool enter_radagos_hideout_condition(MenuCallbackArgs menuCallbackArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void enter_radagos_hideout_on_consequence(MenuCallbackArgs menuCallbackArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool leave_radagos_hideout_condition(MenuCallbackArgs menuCallbackArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void leave_radagos_hideout_on_consequence(MenuCallbackArgs menuCallbackArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("radagos_hideout")]
	[GameMenuInitializationHandler("brother_chest_menu")]
	private static void quest_game_menus_on_init_background(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCompleteWithSuccess()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AutoGeneratedStaticCollectObjectsFindHideoutTutorialQuest(object o, List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_hideout(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_raiderParties(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_talkedWithRadagos(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_talkedWithBrother(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_hideoutBattleEndState(object o)
	{
		throw null;
	}
}
