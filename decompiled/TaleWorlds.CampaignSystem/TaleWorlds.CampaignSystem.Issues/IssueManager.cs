using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Issues;

public class IssueManager : CampaignEventReceiver
{
	[CompilerGenerated]
	private sealed class _003Cget_IssueSolvingCompanionList_003Ed__13 : IEnumerable<Hero>, IEnumerable, IEnumerator<Hero>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Hero _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public IssueManager _003C_003E4__this;

		private Dictionary<Hero, IssueBase>.Enumerator _003C_003E7__wrap1;

		Hero IEnumerator<Hero>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003Cget_IssueSolvingCompanionList_003Ed__13(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<Hero> IEnumerable<Hero>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetHeroesThatHaveIssueForSettlement_003Ed__42 : IEnumerable<Hero>, IEnumerable, IEnumerator<Hero>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Hero _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Settlement settlement;

		public Settlement _003C_003E3__settlement;

		private List<Hero>.Enumerator _003C_003E7__wrap1;

		private List<MobileParty>.Enumerator _003C_003E7__wrap2;

		private IEnumerator<TroopRosterElement> _003C_003E7__wrap3;

		Hero IEnumerator<Hero>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetHeroesThatHaveIssueForSettlement_003Ed__42(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally2()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally3()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<Hero> IEnumerable<Hero>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetIssuesInSettlement_003Ed__65 : IEnumerable<IssueBase>, IEnumerable, IEnumerator<IssueBase>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IssueBase _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Settlement settlement;

		public Settlement _003C_003E3__settlement;

		private bool onlyNotables;

		public bool _003C_003E3__onlyNotables;

		private List<Hero>.Enumerator _003C_003E7__wrap1;

		private List<MobileParty>.Enumerator _003C_003E7__wrap2;

		private MobileParty _003CsettlementParty_003E5__4;

		private int _003Ci_003E5__5;

		IssueBase IEnumerator<IssueBase>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetIssuesInSettlement_003Ed__65(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally2()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally3()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<IssueBase> IEnumerable<IssueBase>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	[SaveableField(0)]
	private int _nextIssueUniqueIndex;

	public MBReadOnlyDictionary<Hero, IssueBase> Issues;

	[SaveableField(1)]
	private readonly Dictionary<Hero, IssueBase> _issues;

	[SaveableField(2)]
	private Dictionary<string, List<IssueCoolDownData>> _issuesCoolDownData;

	[CachedData]
	private Dictionary<Hero, List<PotentialIssueData>> _issueArgs;

	[SaveableField(4)]
	private TroopRoster _awaitingAlternativeSolutionTroops;

	public const string IssueOfferToken = "issue_offer";

	public const string HeroMainOptionsToken = "hero_main_options";

	public const string IssueClassicQuestStartToken = "issue_classic_quest_start";

	public const string IssueDiscussAlternativeSolution = "issue_discuss_alternative_solution";

	private const float IssueCancelChance = 0.2f;

	public IEnumerable<Hero> IssueSolvingCompanionList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_IssueSolvingCompanionList_003Ed__13))]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AutoGeneratedStaticCollectObjectsIssueManager(object o, List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_nextIssueUniqueIndex(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_issues(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_issuesCoolDownData(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_awaitingAlternativeSolutionTroops(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IssueManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LoadInitializationCallback]
	private void OnLoad(MetaData metaData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AssignIssuesToHeroes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void PreAfterLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeForSavedGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CreateNewIssue(in PotentialIssueData pid, Hero issueOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool StartIssueQuest(Hero issueOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeactivateIssue(IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeIssueOwner(IssueBase issue, Hero newOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PrepareIssueArguments(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPotentialIssueData(Hero hero, PotentialIssueData issueData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PotentialIssueData> GetPotentialIssues(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<PotentialIssueData> CheckForIssues(Hero issueOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfTroopsCanReturnToMainParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeAlternativeTroopsReturn(TroopRoster roster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TryToMakeTroopsReturn(IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExpireInvalidData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsThereActiveIssueWithTypeInSettlement(Type type, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumOfAvailableIssuesInSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumOfActiveIssuesInSettlement(Settlement settlement, bool includeQuests)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetHeroesThatHaveIssueForSettlement_003Ed__42))]
	private IEnumerable<Hero> GetHeroesThatHaveIssueForSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameMenuOption.IssueQuestFlags CheckIssueForMenuLocations(List<Location> currentLocations, bool getIssuesWithoutAQuest = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnQuestCompleted(QuestBase quest, QuestBase.QuestCompleteDetails detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroUnregistered(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSettlementLeft(MobileParty party, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCharacterPortraitPopUpOpened(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IssueDeactivationCommonCondition(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHeroKilled(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail detail, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ToggleAllIssueTracks(bool enableTrack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddIssueCoolDownData(Type type, IssueCoolDownData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasIssueCoolDown(Type type, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHaveCampaignIssues(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHeroDie(Hero hero, KillCharacterAction.KillCharacterActionDetail causeOfDeath, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHeroBecomePrisoner(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHeroMarry(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHeroEquipmentBeChanged(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanHeroLeadParty(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanMoveToSettlement(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanBeGovernorOrHavePartyRole(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void IsSettlementBusy(Settlement settlement, object asker, ref int priority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FillIssueCountsPerSettlement(Dictionary<Settlement, int> issueCountPerSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetIssuesInSettlement_003Ed__65))]
	public static IEnumerable<IssueBase> GetIssuesInSettlement(Settlement settlement, bool onlyNotables = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IssueBase GetIssueOfQuest(QuestBase quest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FillIssueCountsPerClan(Dictionary<Clan, int> issueCountPerClan, IEnumerable<Clan> clans)
	{
		throw null;
	}
}
