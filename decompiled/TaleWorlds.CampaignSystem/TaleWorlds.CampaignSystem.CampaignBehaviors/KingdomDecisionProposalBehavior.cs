using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class KingdomDecisionProposalBehavior : CampaignBehaviorBase
{
	private delegate KingdomDecision KingdomDecisionCreatorDelegate(Clan sponsorClan);

	private const float DaysBetweenSameProposal = 5f;

	private List<KingdomDecision> _kingdomDecisionsList;

	private ITradeAgreementsCampaignBehavior _tradeAgreementsBehavior;

	public ITradeAgreementsCampaignBehavior TradeAgreementsCampaignBehavior
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
	private void OnKingdomDestroyed(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateKingdomDecisions(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPeaceMade(IFaction side1Faction, IFaction side2Faction, MakePeaceAction.MakePeaceDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnWarDeclared(IFaction side1Faction, IFaction side2Faction, DeclareWarAction.DeclareWarDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleDiplomaticChangeBetweenFactions(IFaction side1Faction, IFaction side2Faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private KingdomDecision GetRandomStartingAllianceDecision(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private KingdomDecision GetRandomWarDecision(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static KingdomDecision GetRandomPeaceDecision(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsiderWar(Clan clan, Kingdom kingdom, IFaction otherFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetKingdomSupportForWar(Clan clan, Kingdom kingdom, IFaction otherFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool ConsiderPeace(Clan clan, Clan otherClan, IFaction otherFaction, out MakePeaceKingdomDecision decision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private KingdomDecision GetRandomPolicyDecision(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsiderPolicy(Clan clan, Kingdom kingdom, PolicyObject policy, bool invert)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetKingdomSupportForPolicy(Clan clan, Kingdom kingdom, PolicyObject policy, bool invert)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private KingdomDecision GetRandomAnnexationDecision(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsiderAnnex(Clan clan, Town targetSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private KingdomDecision GetRandomTradeAgreementDecision(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsiderTradeAgreement(Clan clan, Kingdom kingdom, Kingdom otherKingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomAction.ChangeKingdomActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnKingdomDecisionAdded(KingdomDecision decision, bool isPlayerInvolved)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public KingdomDecisionProposalBehavior()
	{
		throw null;
	}
}
