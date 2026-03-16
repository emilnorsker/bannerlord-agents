using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class VassalAndMercenaryOfferCampaignBehavior : CampaignBehaviorBase, IVassalAndMercenaryOfferCampaignBehavior
{
	private const float MercenaryOfferCreationChance = 0.02f;

	private const float VassalOfferCreationChance = 0.01f;

	private const int MercenaryOfferCancelTimeInDays = 2;

	private static readonly TextObject MercenaryOfferDecisionPopUpExplanationText;

	private static readonly TextObject MercenaryOfferPanelNotificationText;

	private static readonly TextObject VassalOfferPanelNotificationText;

	private Tuple<Kingdom, CampaignTime> _currentMercenaryOffer;

	private Dictionary<Kingdom, CampaignTime> _vassalOffers;

	private bool _stopOffers;

	private static TextObject DecisionPopUpTitleText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static TextObject DecisionPopUpAffirmativeText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static TextObject DecisionPopUpNegativeText
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
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool VassalKingdomSelectionConditionsHold(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool MercenaryKingdomSelectionConditionsHold(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroPrisonerTaken(PartyBase captor, Hero prisoner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomAction.ChangeKingdomActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnVassalOrMercenaryServiceOfferedToPlayer(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CancelVassalOrMercenaryServiceOffer(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnWarDeclared(IFaction faction1, IFaction faction2, DeclareWarAction.DeclareWarDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroRelationChanged(Hero effectiveHero, Hero effectiveHeroGainedRelationWith, int relationChange, bool showNotification, ChangeRelationAction.ChangeRelationDetail detail, Hero originalHero, Hero originalGainedRelationWith)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnKingdomDestroyed(Kingdom destroyedKingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerCharacterChanged(Hero oldPlayer, Hero newPlayer, MobileParty newMainParty, bool isMainPartyChanged)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearKingdomOffer(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanPlayerClanReceiveMercenaryOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateMercenaryOffer(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateMercenaryOfferDecisionPopUp(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MercenaryOfferAccepted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MercenaryOfferDeclined()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanPlayerClanReceiveVassalOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateVassalOffer(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddVassalDialogues(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool valid_vassal_offer_start_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_set_oath_phrases_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool invalid_vassal_offer_start_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vassal_conversation_end_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VassalAndMercenaryOfferCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static VassalAndMercenaryOfferCampaignBehavior()
	{
		throw null;
	}
}
