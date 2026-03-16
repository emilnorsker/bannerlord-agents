using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Encounters;

public class PlayerEncounter
{
	[SaveableField(1)]
	public bool FirstInit;

	[SaveableField(7)]
	public float PlayerPartyInitialStrength;

	[SaveableField(8)]
	private CampaignBattleResult _campaignBattleResult;

	[SaveableField(9)]
	public float PartiesStrengthRatioBeforePlayerJoin;

	[SaveableField(10)]
	public bool ForceRaid;

	[SaveableField(11)]
	public bool ForceSallyOut;

	[SaveableField(40)]
	public bool ForceHideoutSendTroops;

	[SaveableField(32)]
	public bool ForceVolunteers;

	[SaveableField(33)]
	public bool ForceSupplies;

	[SaveableField(34)]
	private bool _isSiegeInterruptedByEnemyDefection;

	public BattleSimulation BattleSimulation;

	[SaveableField(13)]
	private MapEvent _mapEvent;

	[SaveableField(14)]
	private PlayerEncounterState _mapEventState;

	[SaveableField(15)]
	private PartyBase _encounteredParty;

	[SaveableField(16)]
	private PartyBase _attackerParty;

	[SaveableField(17)]
	private PartyBase _defenderParty;

	[SaveableField(18)]
	private List<Hero> _helpedHeroes;

	[SaveableField(19)]
	private List<TroopRosterElement> _capturedHeroes;

	[SaveableField(20)]
	private List<TroopRosterElement> _capturedAlreadyPrisonerHeroes;

	[SaveableField(22)]
	private bool _leaveEncounter;

	[SaveableField(23)]
	private bool _playerSurrender;

	[SaveableField(24)]
	private bool _enemySurrender;

	[SaveableField(25)]
	private bool _battleChallenge;

	[SaveableField(26)]
	private bool _meetingDone;

	[SaveableField(27)]
	private bool _stateHandled;

	[SaveableField(36)]
	private ItemRoster _alternativeRosterToReceiveLootItems;

	public Figurehead PlayerLootedFigurehead;

	[SaveableField(37)]
	private TroopRoster _alternativeRosterToReceiveLootPrisoners;

	[SaveableField(38)]
	private TroopRoster _alternativeRosterToReceiveLootMembers;

	[SaveableField(53)]
	private List<Ship> _alternativeReceivedLootShips;

	[SaveableField(51)]
	private bool _doesBattleContinue;

	[SaveableField(52)]
	private bool _isSallyOutAmbush;

	[SaveableField(54)]
	public bool ForceBlockadeAttack;

	[SaveableField(55)]
	public bool ForceBlockadeSallyOutAttack;

	public static PlayerEncounter Current
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static LocationEncounter LocationEncounter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public static MapEvent Battle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static PartyBase EncounteredParty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static MobileParty EncounteredMobileParty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static MapEvent EncounteredBattle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static BattleState BattleState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static BattleSideEnum WinningSide
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool BattleChallenge
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public static bool PlayerIsDefender
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool PlayerIsAttacker
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool LeaveEncounter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public static bool MeetingDone
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool PlayerSurrender
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public static bool EnemySurrender
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public static bool IsActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[SaveableProperty(2)]
	public BattleSideEnum OpponentSide
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[SaveableProperty(3)]
	public BattleSideEnum PlayerSide
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[SaveableProperty(6)]
	public bool IsJoinedBattle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public static bool InsideSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static CampaignBattleResult CampaignBattleResult
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public static BattleSimulation CurrentBattleSimulation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public PlayerEncounterState EncounterState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public ItemRoster RosterToReceiveLootItems
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TroopRoster RosterToReceiveLootPrisoners
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TroopRoster RosterToReceiveLootMembers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public List<Ship> ReceivedLootShips
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Settlement EncounterSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[SaveableProperty(28)]
	public Settlement EncounterSettlementAux
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[SaveableProperty(50)]
	public bool IsPlayerWaiting
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AutoGeneratedStaticCollectObjectsPlayerEncounter(object o, List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueOpponentSide(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValuePlayerSide(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueIsJoinedBattle(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueEncounterSettlementAux(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueIsPlayerWaiting(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueFirstInit(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValuePlayerPartyInitialStrength(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValuePartiesStrengthRatioBeforePlayerJoin(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueForceRaid(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueForceSallyOut(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueForceHideoutSendTroops(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueForceVolunteers(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueForceSupplies(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueForceBlockadeAttack(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueForceBlockadeSallyOutAttack(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_campaignBattleResult(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_isSiegeInterruptedByEnemyDefection(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_mapEvent(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_mapEventState(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_encounteredParty(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_attackerParty(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_defenderParty(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_helpedHeroes(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_capturedHeroes(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_capturedAlreadyPrisonerHeroes(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_leaveEncounter(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_playerSurrender(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_enemySurrender(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_battleChallenge(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_meetingDone(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_stateHandled(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_alternativeRosterToReceiveLootItems(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_alternativeRosterToReceiveLootPrisoners(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_alternativeRosterToReceiveLootMembers(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_alternativeReceivedLootShips(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_doesBattleContinue(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_isSallyOutAmbush(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LoadInitializationCallback]
	private void OnLoadInitialization(MetaData meta)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PlayerEncounter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RestartPlayerEncounter(PartyBase defenderParty, PartyBase attackerParty, bool forcePlayerOutFromSettlement = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Init(PartyBase attackerParty, PartyBase defenderParty, Settlement settlement = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Init()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetupFields(PartyBase attackerParty, PartyBase defenderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnPartyJoinEncounter(MobileParty newParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckNearbyPartiesToJoinPlayerMapEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsNavalEncounter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MapEvent StartBattleInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MapEvent StartBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JoinBattleInternal(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateStrengthOfParties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void JoinBattle(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayerSurrenderInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnemySurrenderInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Start()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ProtectPlayerSide(float hoursToProtect = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Finish(bool forcePlayerOutFromSettlement = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FinishEncounterInternal(bool playerIsWinner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EndBattleByCheatInternal(bool playerWon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndBattleByCheat(bool playerWon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoBegin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DoMeeting()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetMeetingDone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMeetingFalseForCompanion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoMeetingInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ContinueBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoWait()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckIfLeadingAvaliable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Hero GetLeadingHero()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoPrepareResults()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetPlayerVictorious()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsSallyOutAmbush(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsBlockadeAttack(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsBlockadeSallyOutAttack(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPlayerSiegeInterruptedByEnemyDefection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetPlayerVictoriousInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetPlayerSiegeContinueWithDefenderPullBack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoApplyMapEventResults()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartAttackMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoPlayerVictory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoPlayerDefeat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoCaptureHeroes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoFreeOrCapturePrisonerHeroes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoLootInventory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoLootShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoLootParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfBattleShouldContinueAfterBattleMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizeBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FindNonAttachedNpcPartiesWhoWillJoinEvent(List<MobileParty> partiesToJoinPlayerSide, List<MobileParty> partiesToJoinEnemySide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FindAllNpcPartiesWhoWillJoinEvent(List<MobileParty> partiesToJoinPlayerSide, List<MobileParty> partiesToJoinEnemySide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EnterSettlement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CreateLocationEncounter(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LeaveBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LeaveSettlement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitSimulation(FlattenedTroopRoster selectedTroopsForPlayerSide, FlattenedTroopRoster selectedTroopsForOtherSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InterruptEncounter(string encounterInterrupedType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartSiegeAmbushMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartVillageBattleMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartCombatMissionWithDialogueInTownCenter(CharacterObject characterToTalkTo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartHostileAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartHostileActionInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetBattleRewards(out float renownChange, out float influenceChange, out float moraleChange, out float goldChange, out float playerEarnedLootPercentage, out Figurehead playerEarnedFigurehead, ref ExplainedNumber renownExplainedNumber, ref ExplainedNumber influenceExplainedNumber, ref ExplainedNumber moraleExplainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBattleRewardsInternal(out float renownChange, out float influenceChange, out float moraleChange, out float goldChange, out float playerEarnedLootPercentage, ref ExplainedNumber renownExplainedNumber, ref ExplainedNumber influenceExplainedNumber, ref ExplainedNumber moraleExplainedNumber)
	{
		throw null;
	}
}
