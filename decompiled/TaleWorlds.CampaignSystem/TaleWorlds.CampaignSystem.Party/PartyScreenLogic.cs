using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Helpers;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Party;

public class PartyScreenLogic
{
	public enum TroopSortType
	{
		Invalid = -1,
		Custom,
		Type,
		Name,
		Count,
		Tier
	}

	public enum PartyRosterSide : byte
	{
		None = 99,
		Right = 1,
		Left = 0
	}

	[Flags]
	public enum TroopType
	{
		Member = 1,
		Prisoner = 2,
		None = 3
	}

	public enum PartyCommandCode
	{
		TransferTroop,
		UpgradeTroop,
		TransferPartyLeaderTroop,
		TransferTroopToLeaderSlot,
		ShiftTroop,
		RecruitTroop,
		ExecuteTroop,
		TransferAllTroops,
		SortTroops
	}

	public enum TransferState
	{
		NotTransferable,
		Transferable,
		TransferableWithTrade
	}

	public delegate void PresentationUpdate(PartyCommand command);

	public delegate void PartyGoldDelegate();

	public delegate void PartyMoraleDelegate();

	public delegate void PartyInfluenceDelegate();

	public delegate void PartyHorseDelegate();

	public delegate void AfterResetDelegate(PartyScreenLogic partyScreenLogic, bool fromCancel);

	public class PartyCommand : ISerializableObject
	{
		public PartyCommandCode Code
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

		public PartyRosterSide RosterSide
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

		public CharacterObject Character
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

		public int TotalNumber
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

		public int WoundedNumber
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

		public int Index
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

		public int UpgradeTarget
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

		public TroopType Type
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

		public TroopSortType SortType
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

		public bool IsSortAscending
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PartyCommand()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void FillForTransferTroop(PartyRosterSide fromSide, TroopType type, CharacterObject character, int totalNumber, int woundedNumber, int targetIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void FillForShiftTroop(PartyRosterSide side, TroopType type, CharacterObject character, int targetIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void FillForTransferTroopToLeaderSlot(PartyRosterSide side, TroopType type, CharacterObject character, int totalNumber, int woundedNumber, int targetIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void FillForTransferPartyLeaderTroop(PartyRosterSide side, TroopType type, CharacterObject character, int totalNumber)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void FillForUpgradeTroop(PartyRosterSide side, TroopType type, CharacterObject character, int number, int upgradeTargetType, int index)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void FillForRecruitTroop(PartyRosterSide side, TroopType type, CharacterObject character, int number, int index)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void FillForExecuteTroop(PartyRosterSide side, TroopType type, CharacterObject character)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void FillForTransferAllTroops(PartyRosterSide side, TroopType type)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void FillForSortTroops(PartyRosterSide side, TroopSortType sortType, bool isAscending)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ISerializableObject.SerializeTo(IWriter writer)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ISerializableObject.DeserializeFrom(IReader reader)
		{
			throw null;
		}
	}

	public abstract class TroopComparer : IComparer<TroopRosterElement>
	{
		private bool _isAscending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetIsAscending(bool isAscending)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int GetHeroComparisonResult(TroopRosterElement x, TroopRosterElement y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(TroopRosterElement x, TroopRosterElement y)
		{
			throw null;
		}

		protected abstract int CompareTroops(TroopRosterElement x, TroopRosterElement y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected TroopComparer()
		{
			throw null;
		}
	}

	private class TroopDefaultComparer : TroopComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override int CompareTroops(TroopRosterElement x, TroopRosterElement y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TroopDefaultComparer()
		{
			throw null;
		}
	}

	private class TroopTypeComparer : TroopComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override int CompareTroops(TroopRosterElement x, TroopRosterElement y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TroopTypeComparer()
		{
			throw null;
		}
	}

	private class TroopNameComparer : TroopComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override int CompareTroops(TroopRosterElement x, TroopRosterElement y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TroopNameComparer()
		{
			throw null;
		}
	}

	private class TroopCountComparer : TroopComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override int CompareTroops(TroopRosterElement x, TroopRosterElement y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TroopCountComparer()
		{
			throw null;
		}
	}

	private class TroopTierComparer : TroopComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override int CompareTroops(TroopRosterElement x, TroopRosterElement y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TroopTierComparer()
		{
			throw null;
		}
	}

	public PartyPresentationDoneButtonDelegate PartyPresentationDoneButtonDelegate;

	public PartyPresentationDoneButtonConditionDelegate PartyPresentationDoneButtonConditionDelegate;

	public PartyPresentationCancelButtonActivateDelegate PartyPresentationCancelButtonActivateDelegate;

	public PartyPresentationCancelButtonDelegate PartyPresentationCancelButtonDelegate;

	public PresentationUpdate UpdateDelegate;

	public IsTroopTransferableDelegate IsTroopTransferableDelegate;

	public CanTalkToHeroDelegate CanTalkToHeroDelegate;

	private TroopSortType _activeOtherPartySortType;

	private TroopSortType _activeMainPartySortType;

	private bool _isOtherPartySortAscending;

	private bool _isMainPartySortAscending;

	public TroopRoster[] MemberRosters;

	public TroopRoster[] PrisonerRosters;

	public bool IsConsumablesChanges;

	private PartyScreenHelper.PartyScreenMode _partyScreenMode;

	private readonly Dictionary<TroopSortType, TroopComparer> _defaultComparers;

	private readonly PartyScreenData _initialData;

	private PartyScreenData _savedData;

	private Game _game;

	public TroopSortType ActiveOtherPartySortType
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

	public TroopSortType ActiveMainPartySortType
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

	public bool IsOtherPartySortAscending
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

	public bool IsMainPartySortAscending
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

	public TransferState MemberTransferState
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

	public TransferState PrisonerTransferState
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

	public TransferState AccompanyingTransferState
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

	public TextObject LeftPartyName
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

	public TextObject RightPartyName
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

	public TextObject Header
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

	public int LeftPartyMembersSizeLimit
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

	public int LeftPartyPrisonersSizeLimit
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

	public int RightPartyMembersSizeLimit
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

	public int RightPartyPrisonersSizeLimit
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

	public bool DoNotApplyGoldTransactions
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

	public bool ShowProgressBar
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

	public string DoneReasonString
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

	public bool IsTroopUpgradesDisabled
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

	public CharacterObject RightPartyLeader
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

	public CharacterObject LeftPartyLeader
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

	public PartyBase LeftOwnerParty
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

	public PartyBase RightOwnerParty
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

	public PartyScreenData CurrentData
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

	public bool TransferHealthiesGetWoundedsFirst
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

	public int QuestModeWageDaysMultiplier
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

	public Game Game
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

	public event PartyGoldDelegate PartyGoldChange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event PartyMoraleDelegate PartyMoraleChange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event PartyInfluenceDelegate PartyInfluenceChange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event PartyHorseDelegate PartyHorseChange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event PresentationUpdate Update
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event PartyScreenClosedDelegate PartyScreenClosedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event AfterResetDelegate AfterReset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PartyScreenLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(PartyScreenLogicInitializationData initializationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetPartyGoldChangeAmount(int newTotalAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMoraleChangeAmount(int newAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetHorseChangeAmount(int newAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetInfluenceChangeAmount(int heroInfluence, int troopInfluence, int prisonerInfluence)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessCommand(PartyCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddCommand(PartyCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ValidateCommand(PartyCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnReset(bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void TransferTroopToLeaderSlot(PartyCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void TransferTroop(PartyCommand command, bool invokeUpdate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ShiftTroop(PartyCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void TransferPartyLeaderTroop(PartyCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void UpgradeTroop(PartyCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void RecruitPrisoner(PartyCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ExecuteTroop(PartyCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void TransferAllTroops(PartyCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SortTroops(PartyCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetIndexToInsertTroop(PartyRosterSide side, TroopType type, TroopRosterElement troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TroopSortType GetActiveSortTypeForSide(PartyRosterSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetActiveSortTypeForSide(PartyRosterSide side, TroopSortType sortType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsAscendingSortForSide(PartyRosterSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetIsAscendingForSide(PartyRosterSide side, bool isAscending)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<TroopRosterElement> GetListFromRoster(TroopRoster roster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SyncRosterWithList(TroopRoster roster, List<TroopRosterElement> list)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void EnsureRosterIsSyncedWithList(TroopRoster roster, List<TroopRosterElement> list)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SortRoster(TroopRoster originalRoster, TroopSortType sortType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsRosterOrdered(TroopRoster roster, TroopComparer comparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDoneActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsCancelActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoneLogic(bool isForced)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPartyScreenClosed(bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateComparersAscendingOrder(bool isAscending)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FireCampaignRelatedEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsTroopTransferable(TroopType troopType, CharacterObject character, int side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsTroopRosterTransferable(TroopType troopType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPrisonerRecruitable(TroopType troopType, CharacterObject character, PartyRosterSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetRecruitableReasonString(CharacterObject character, bool isRecruitable, int troopCount, out bool showStackModifierText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsExecutable(TroopType troopType, CharacterObject character, PartyRosterSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetExecutableReasonString(CharacterObject character, bool isExecutable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCurrentQuestCurrentCount(bool includePrisoners, bool includeMembers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCurrentQuestRequiredCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool DefaultDoneHandler(TroopRoster leftMemberRoster, TroopRoster leftPrisonRoster, TroopRoster rightMemberRoster, TroopRoster rightPrisonRoster, FlattenedTroopRoster takenPrisonerRoster, FlattenedTroopRoster releasedPrisonerRoster, bool isForced, PartyBase leftParty = null, PartyBase rightParty = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddUpgradeToHistory(CharacterObject fromTroop, CharacterObject toTroop, int num)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddUsedHorsesToHistory(List<(EquipmentElement, int)> usedHorses)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePrisonerTransferHistory(CharacterObject troop, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddRecruitToHistory(CharacterObject troop, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetItemLockStringID(EquipmentElement equipmentElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<(EquipmentElement, int)> RemoveItemFromItemRoster(ItemCategory itemCategory, int numOfItemsLeftToRemove = 1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset(bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetLogic(bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SavePartyScreenData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetToLastSavedPartyScreenData(bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveZeroCounts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTroopRecruitableAmount(CharacterObject troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TroopRoster GetRoster(PartyRosterSide side, TroopType troopType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnDoneEvent(List<TroopTradeDifference> freshlySellList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsThereAnyChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HaveRightSideGainedTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TroopComparer GetComparer(TroopSortType sortType)
	{
		throw null;
	}
}
