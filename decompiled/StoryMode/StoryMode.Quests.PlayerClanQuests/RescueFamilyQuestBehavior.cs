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

namespace StoryMode.Quests.PlayerClanQuests;

public class RescueFamilyQuestBehavior : CampaignBehaviorBase
{
	public class RescueFamilyQuest : StoryModeQuestBase
	{
		public class RebuildPlayerClanQuestBehaviorTypeDefiner : SaveableTypeDefiner
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			public RebuildPlayerClanQuestBehaviorTypeDefiner()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			protected override void DefineClassTypes()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			protected override void DefineEnumTypes()
			{
				throw null;
			}
		}

		private enum HideoutBattleEndState
		{
			None,
			Retreated,
			Defeated,
			Victory
		}

		private const int RaiderPartySize = 10;

		private const int RaiderPartyCount = 2;

		private const string RescueFamilyRaiderPartyStringId = "rescue_family_quest_raider_party_";

		private Hero _radagos;

		private Hero _hideoutBoss;

		private Settlement _targetSettlementForSiblings;

		[SaveableField(1)]
		private readonly Settlement _hideout;

		[SaveableField(2)]
		private bool _reunionTalkDone;

		[SaveableField(3)]
		private bool _hideoutTalkDone;

		[SaveableField(4)]
		private bool _brotherConversationDone;

		[SaveableField(5)]
		private bool _radagosGoodByeConversationDone;

		[SaveableField(6)]
		private HideoutBattleEndState _hideoutBattleEndState;

		[SaveableField(7)]
		private readonly List<MobileParty> _raiderParties;

		private TextObject _startQuestLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject _defeatedQuestLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject _letGoRadagosEndQuestLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject _executeRadagosEndQuestLogText
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
		public RescueFamilyQuest()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void InitializeQuestOnGameLoad()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanHaveCampaignIssuesInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnCompleteWithSuccess()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnFinalize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnTimedOut()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void InitializeHideout()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CheckIfHideoutIsReady()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddRadagosHenchmanToHideout()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void RemoveRadagosHenchmanFromHideout()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private MobileParty CreateRaiderParty(int number, bool isBanditBossParty)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SelectTargetSettlementForSiblings()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void RegisterEvents()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void IsSettlementBusy(Settlement settlement, object asker, ref int priority)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnHideoutCleared(Settlement hideout)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification = true)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnSettlementLeft(MobileParty party, Settlement settlement)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnMapEventEnded(MapEvent mapEvent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnGameMenuOpened(MenuCallbackArgs args)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnSettlementEntered(MobileParty mobileParty, Settlement settlement, Hero hero)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void HourlyTick()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void SetDialogs()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool radagos_reunion_conversation_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void radagos_reunion_conversation_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool radagos_hideout_conversation_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void radagos_hideout_conversation_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool brother_hideout_conversation_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void brother_hideout_conversation_consequence()
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
		private bool hideout_boss_prisoner_talk_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void hideout_boss_prisoner_talk_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool goodbye_conversation_with_radagos_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void execute_radagos_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void let_go_radagos_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddGameMenus()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void radagos_goodbye_menu_on_init(MenuCallbackArgs args)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool radagos_goodbye_menu_continue_on_condition(MenuCallbackArgs args)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void radagos_goodbye_menu_continue_on_consequence(MenuCallbackArgs args)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[GameMenuInitializationHandler("radagos_goodbye_menu")]
		private static void quest_game_menus_on_init_background(MenuCallbackArgs args)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void AutoGeneratedStaticCollectObjectsRescueFamilyQuest(object o, List<object> collectedObjects)
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
		internal static object AutoGeneratedGetMemberValue_reunionTalkDone(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_hideoutTalkDone(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_brotherConversationDone(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_radagosGoodByeConversationDone(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_hideoutBattleEndState(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_raiderParties(object o)
		{
			throw null;
		}
	}

	private bool _rescueFamilyQuestReadyToStart;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal RescueFamilyQuestBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnGameLoadedEvent(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestCompleted(QuestBase quest, QuestCompleteDetails detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CanHaveCampaignIssuesInfoIsRequested(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CanHeroDie(Hero hero, KillCharacterActionDetail causeOfDeath, ref bool result)
	{
		throw null;
	}
}
