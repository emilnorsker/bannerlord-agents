using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class MarriageOfferCampaignBehavior : CampaignBehaviorBase, IMarriageOfferCampaignBehavior, ICampaignBehavior
{
	private const int MarriageOfferCooldownDurationAsDays = 7;

	private const int OfferRelationGainAmountWithTheMarriageClan = 10;

	private const float MapNotificationAutoDeclineDurationInDays = 2f;

	private readonly TextObject MarriageOfferPanelExplanationText;

	private readonly TextObject MarriagePreparationStartedText;

	private readonly TextObject MarriagePreparationCanceledText;

	private Hero _currentOfferedPlayerClanHero;

	private Hero _currentOfferedOtherClanHero;

	private CampaignTime _lastMarriageOfferTime;

	private Dictionary<Hero, Hero> _acceptedMarriageOffersThatWaitingForAvailability;

	internal bool IsThereActiveMarriageOffer
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
	public void CreateMarriageOffer(Hero currentOfferedPlayerClanHero, Hero currentOfferedOtherClanHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBBindingList<TextObject> GetMarriageAcceptedConsequences()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickClan(Clan consideringClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MarryHeroesViaOffer(Hero playerClanHero, Hero otherClanHero, bool showSceneNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMarriageOfferAcceptedOnPopUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMarriageOfferedToPlayer(Hero suitor, Hero maiden)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMarriageOfferDeclinedOnPopUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMarriageOfferCanceled(Hero suitor, Hero maiden)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsHeroEngaged(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroPrisonerTaken(PartyBase capturer, Hero prisoner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroesMarried(Hero hero1, Hero hero2, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnArmyCreated(Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CharacterBecameFugitive(Hero hero, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnWarDeclared(IFaction faction1, IFaction faction2, DeclareWarAction.DeclareWarDetail declareWarDetail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroRelationChanged(Hero effectiveHero, Hero effectiveHeroGainedRelationWith, int relationChange, bool showNotification, ChangeRelationAction.ChangeRelationDetail detail, Hero originalHero, Hero originalGainedRelationWith)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomAction.ChangeKingdomActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanOfferMarriageForClan(Clan consideringClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsiderMarriageForPlayerClanMember(Hero playerClanHero, Clan consideringClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FinalizeMarriageOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MarriageOfferCampaignBehavior()
	{
		throw null;
	}
}
