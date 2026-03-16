using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace StoryMode.Quests.SecondPhase.ConspiracyQuests;

public class DestroyRaidersConspiracyQuest : ConspiracyQuestBase
{
	private const int QuestSuccededRelationBonus = 5;

	private const int QuestSucceededSecurityBonus = 5;

	private const int QuestSuceededProsperityBonus = 5;

	private const int QuestSuceededRenownBonus = 5;

	private const int QuestFailedRelationPenalty = -5;

	private const int NumberOfRegularRaidersToSpawn = 3;

	[SaveableField(1)]
	private readonly Settlement _targetSettlement;

	[SaveableField(2)]
	private readonly List<MobileParty> _regularRaiderParties;

	[SaveableField(3)]
	private MobileParty _specialRaiderParty;

	[SaveableField(4)]
	private JournalLog _regularPartiesProgressTracker;

	[SaveableField(5)]
	private JournalLog _specialPartyProgressTracker;

	[SaveableField(6)]
	private Clan _banditFaction;

	[SaveableField(7)]
	private CharacterObject _conspiracyCaptainCharacter;

	[SaveableField(8)]
	private Settlement _closestHideout;

	[SaveableField(9)]
	private List<MobileParty> _directedRaidersToEngagePlayer;

	private float RaiderPartyPlayerEncounterRadius
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

	public override float ConspiracyStrengthDecreaseAmount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int RegularRaiderPartyTroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int SpecialRaiderPartyTroopCount
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

	public override TextObject StartMessageLogFromMentor
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

	private TextObject _destroyRaidersQuestSucceededLogText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _destroyRaidersQuestFailedOnTimedOutLogText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _destroyRaidersQuestFailedOnPlayerDefeatedByRaidersLogText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _destroyRaidersRegularPartiesProgress
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _destroyRaidersSpecialPartyProgress
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _destroyRaidersRegularProgressNotification
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _destroyRaidersRegularProgressCompletedNotification
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _destroyRaidersSpecialPartyInformationQuestLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _destroyRaidersSpecialPartySpawnNotification
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DestroyRaidersConspiracyQuest(string questId, Hero questGiver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetDialogs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameMenuOpened(MenuCallbackArgs menuCallbackArgs)
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
	private Settlement DetermineTargetSettlement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeRaiders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<Settlement> DetermineClosestHideouts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnRaiderPartyAtHideout(Settlement hideout, bool isSpecialParty = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetDefaultRaiderAi(MobileParty raiderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Clan GetBanditTypeForSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MobilePartyDestroyed(MobileParty mobileParty, PartyBase destroyerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSpecialBanditPartyClearedByPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBanditPartyClearedByPlayer(MobileParty defeatedParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroTakenPrisoner(PartyBase capturer, Hero prisoner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckRaiderPartyPlayerEncounter(MobileParty raiderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DialogFlow GetConspiracyCaptainDialogue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnConspiracyCaptainDialogueEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestSucceeded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestFailedByDefeat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestFailed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTimedOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AutoGeneratedStaticCollectObjectsDestroyRaidersConspiracyQuest(object o, List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_targetSettlement(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_regularRaiderParties(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_specialRaiderParty(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_regularPartiesProgressTracker(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_specialPartyProgressTracker(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_banditFaction(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_conspiracyCaptainCharacter(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_closestHideout(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_directedRaidersToEngagePlayer(object o)
	{
		throw null;
	}
}
