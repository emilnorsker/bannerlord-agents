using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace StoryMode.Quests.SecondPhase.ConspiracyQuests;

public class ConspiracyBaseOfOperationsDiscoveredConspiracyQuest : ConspiracyQuestBase
{
	private const string AntiImperialHideoutBossStringId = "anti_imperial_conspiracy_boss";

	private const string ImperialHideoutBossStringId = "imperial_conspiracy_boss";

	private const int RaiderPartySize = 6;

	private const int RaiderPartyCount = 2;

	[SaveableField(1)]
	private readonly Settlement _hideout;

	private Settlement _baseLocation;

	private bool _dueledWithHideoutBoss;

	private bool _isSuccess;

	private bool _isDone;

	private float _conspiracyStrengthDecreaseAmount;

	[SaveableField(2)]
	private readonly List<MobileParty> _raiderParties;

	public override TextObject Title
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject SideNotificationText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject StartMessageLogFromMentor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject StartLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override float ConspiracyStrengthDecreaseAmount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject HideoutBossName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject HideoutSpottedLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject HideoutRemovedLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject NotDueledWithHideoutBossAndDefeatLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject NotDueledWithHideoutBossAndDefeatedLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject DueledWithHideoutBossAndDefeatLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject DueledWithHideoutBossAndDefeatedLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConspiracyBaseOfOperationsDiscoveredConspiracyQuest(string questId, Hero questGiver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Settlement SelectHideout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MobileParty CreateRaiderParty(Settlement hideout, bool isBanditBossParty, int partyIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void InitializeQuestOnGameLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeHideout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChangeHideoutParties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHideoutBattleCompleted(BattleSideEnum winnerSide, HideoutEventComponent hideoutEventComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameMenuOpened(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionStarted(IMission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionEnded(IMission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHideoutSpotted(PartyBase party, PartyBase hideoutParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHideoutCleared(Settlement hideout)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NotDueledWithHideoutBossAndDefeatedCaravan()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NotDueledWithHideoutBossAndDefeatedByCaravan()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DueledWithHideoutBossAndDefeatedCaravan()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DueledWithHideoutBossAndDefeatedByCaravan()
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
	protected override void OnStartQuest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCompleteWithSuccess()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTimedOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AutoGeneratedStaticCollectObjectsConspiracyBaseOfOperationsDiscoveredConspiracyQuest(object o, List<object> collectedObjects)
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
}
