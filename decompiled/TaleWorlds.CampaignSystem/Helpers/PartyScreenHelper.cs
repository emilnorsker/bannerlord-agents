using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Localization;

namespace Helpers;

public static class PartyScreenHelper
{
	public enum PartyScreenMode
	{
		Normal,
		Shared,
		Loot,
		Ransom,
		PrisonerManage,
		TroopsManage,
		QuestTroopManage
	}

	private static readonly int _countToAddForEachTroopCheatMode;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PartyState GetActivePartyState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OpenPartyScreen(bool isDonating = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CloseScreen(bool isForced, bool fromCancel = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ClosePartyPresentation(bool isForced, bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsCheat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TroopRoster GetRosterWithAllGameTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsNormal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsRansom()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsLoot(TroopRoster leftMemberRoster, TroopRoster leftPrisonerRoster, TextObject leftPartyName, int leftPartySizeLimit, PartyScreenClosedDelegate partyScreenClosedDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsManageTroopsAndPrisoners(MobileParty leftParty, PartyScreenClosedDelegate onPartyScreenClosed = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsReceiveTroops(TroopRoster leftMemberParty, TextObject leftPartyName, PartyScreenClosedDelegate partyScreenClosedDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsManageTroops(MobileParty leftParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsDonateTroops(MobileParty leftParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsDonateGarrisonWithCurrentSettlement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsDonatePrisoners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Tuple<bool, TextObject> DonateDonePossibleDelegate(TroopRoster leftMemberRoster, TroopRoster leftPrisonRoster, TroopRoster rightMemberRoster, TroopRoster rightPrisonRoster, int leftLimitNum, int rightLimitNum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DonatePrisonerTransferableDelegate(CharacterObject character, PartyScreenLogic.TroopType type, PartyScreenLogic.PartyRosterSide side, PartyBase LeftOwnerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsManagePrisoners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TroopTransferableDelegate(CharacterObject character, PartyScreenLogic.TroopType type, PartyScreenLogic.PartyRosterSide side, PartyBase leftOwnerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ClanManageTroopAndPrisonerTransferableDelegate(CharacterObject character, PartyScreenLogic.TroopType type, PartyScreenLogic.PartyRosterSide side, PartyBase LeftOwnerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ClanManageTroopTransferableDelegate(CharacterObject character, PartyScreenLogic.TroopType type, PartyScreenLogic.PartyRosterSide side, PartyBase LeftOwnerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DonateModeTroopTransferableDelegate(CharacterObject character, PartyScreenLogic.TroopType type, PartyScreenLogic.PartyRosterSide side, PartyBase LeftOwnerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenWithCondition(IsTroopTransferableDelegate isTroopTransferable, PartyPresentationDoneButtonConditionDelegate doneButtonCondition, PartyPresentationDoneButtonDelegate onDoneClicked, PartyPresentationCancelButtonDelegate onCancelClicked, PartyScreenLogic.TransferState memberTransferState, PartyScreenLogic.TransferState prisonerTransferState, TextObject leftPartyName, int limit, bool showProgressBar, bool isDonating, PartyScreenMode screenMode = PartyScreenMode.Normal, TroopRoster memberRosterLeft = null, TroopRoster prisonerRosterLeft = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenForManagingAlley(bool isNewAlley, TroopRoster memberRosterLeft, IsTroopTransferableDelegate isTroopTransferable, PartyPresentationDoneButtonConditionDelegate doneButtonCondition, PartyPresentationDoneButtonDelegate onDoneClicked, TextObject leftPartyName, PartyPresentationCancelButtonDelegate onCancelButtonClicked)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsQuest(TroopRoster leftMemberRoster, TextObject leftPartyName, int leftPartySizeLimit, int questDaysMultiplier, PartyPresentationDoneButtonConditionDelegate doneButtonCondition, PartyScreenClosedDelegate onPartyScreenClosed, IsTroopTransferableDelegate isTroopTransferable, PartyPresentationCancelButtonActivateDelegate partyPresentationCancelButtonActivateDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenWithDummyRoster(TroopRoster leftMemberRoster, TroopRoster leftPrisonerRoster, TroopRoster rightMemberRoster, TroopRoster rightPrisonerRoster, TextObject leftPartyName, TextObject rightPartyName, int leftPartySizeLimit, int rightPartySizeLimit, PartyPresentationDoneButtonConditionDelegate doneButtonCondition, PartyScreenClosedDelegate onPartyScreenClosed, IsTroopTransferableDelegate isTroopTransferable, CanTalkToHeroDelegate canTalkToTroopDelegate = null, PartyPresentationCancelButtonActivateDelegate partyPresentationCancelButtonActivateDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenWithDummyRosterWithMainParty(TroopRoster leftMemberRoster, TroopRoster leftPrisonerRoster, TextObject leftPartyName, int leftPartySizeLimit, PartyPresentationDoneButtonConditionDelegate doneButtonCondition, PartyScreenClosedDelegate onPartyScreenClosed, IsTroopTransferableDelegate isTroopTransferable, PartyPresentationCancelButtonActivateDelegate partyPresentationCancelButtonActivateDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsCreateClanPartyForHero(Hero hero, PartyScreenClosedDelegate onScreenClosed = null, IsTroopTransferableDelegate isTroopTransferable = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OpenScreenAsCreateClanPartyForHeroPartyScreenClosed(PartyBase leftOwnerParty, TroopRoster leftMemberRoster, TroopRoster leftPrisonRoster, PartyBase rightOwnerParty, TroopRoster rightMemberRoster, TroopRoster rightPrisonRoster, bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool OpenScreenAsCreateClanPartyForHeroTroopTransferableDelegate(CharacterObject character, PartyScreenLogic.TroopType type, PartyScreenLogic.PartyRosterSide side, PartyBase LeftOwnerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool SellPrisonersDoneHandler(TroopRoster leftMemberRoster, TroopRoster leftPrisonRoster, TroopRoster rightMemberRoster, TroopRoster rightPrisonRoster, FlattenedTroopRoster takenPrisonerRoster, FlattenedTroopRoster releasedPrisonerRoster, bool isForced, PartyBase leftParty = null, PartyBase rightParty = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool DonateGarrisonDoneHandler(TroopRoster leftMemberRoster, TroopRoster leftPrisonRoster, TroopRoster rightMemberRoster, TroopRoster rightPrisonRoster, FlattenedTroopRoster takenPrisonerRoster, FlattenedTroopRoster releasedPrisonerRoster, bool isForced, PartyBase leftParty = null, PartyBase rightParty = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool DonatePrisonersDoneHandler(TroopRoster leftMemberRoster, TroopRoster leftPrisonRoster, TroopRoster rightMemberRoster, TroopRoster rightPrisonRoster, FlattenedTroopRoster leftSideTransferredPrisonerRoster, FlattenedTroopRoster rightSideTransferredPrisonerRoster, bool isForced, PartyBase leftParty = null, PartyBase rightParty = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool ManageGarrisonDoneHandler(TroopRoster leftMemberRoster, TroopRoster leftPrisonRoster, TroopRoster rightMemberRoster, TroopRoster rightPrisonRoster, FlattenedTroopRoster takenPrisonerRoster, FlattenedTroopRoster releasedPrisonerRoster, bool isForced, PartyBase leftParty = null, PartyBase rightParty = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CanTalkToHero(Hero hero, PartyScreenLogic.TroopType type, PartyScreenLogic.PartyRosterSide side, PartyBase LeftOwnerParty, out TextObject cantTalkReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool ManageTroopsAndPrisonersDoneHandler(TroopRoster leftMemberRoster, TroopRoster leftPrisonRoster, TroopRoster rightMemberRoster, TroopRoster rightPrisonRoster, FlattenedTroopRoster takenPrisonerRoster, FlattenedTroopRoster releasedPrisonerRoster, bool isForced, PartyBase leftParty = null, PartyBase rightParty = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool DefaultDoneHandler(TroopRoster leftMemberRoster, TroopRoster leftPrisonRoster, TroopRoster rightMemberRoster, TroopRoster rightPrisonRoster, FlattenedTroopRoster takenPrisonerRoster, FlattenedTroopRoster releasedPrisonerRoster, bool isForced, PartyBase leftParty = null, PartyBase rightParty = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void HandleReleasedAndTakenPrisoners(FlattenedTroopRoster takenPrisonerRoster, FlattenedTroopRoster releasedPrisonerRoster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PartyScreenHelper()
	{
		throw null;
	}
}
