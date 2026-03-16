using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class RansomOfferCampaignBehavior : CampaignBehaviorBase
{
	private const float RansomOfferInitialChance = 0.2f;

	private const float RansomOfferChanceAfterRefusal = 0.12f;

	private const float RansomOfferChanceForPrisonersKeptByAI = 0.1f;

	private const float MapNotificationAutoDeclineDurationInDays = 2f;

	private const int AmountOfGoldLeftAfterRansom = 1000;

	private static TextObject RansomOfferDescriptionText;

	private static TextObject RansomPanelDescriptionNpcHeldPrisonerText;

	private static TextObject RansomPanelDescriptionPlayerHeldPrisonerText;

	private List<Hero> _heroesWithDeclinedRansomOffers;

	private Hero _currentRansomHero;

	private Hero _currentRansomPayer;

	private CampaignTime _currentRansomOfferDate;

	private static TextObject RansomPanelTitleText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static TextObject RansomPanelAffirmativeText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static TextObject RansomPanelNegativeText
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
	private void OnHeroPrisonerTaken(PartyBase party, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderRansomPrisoner(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Clan GetCaptorClanOfPrisoner(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCurrentRansomHero(Hero hero, Hero ransomPayer = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRansomOffered(Hero captiveHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (bool, string) IsAffirmativeOptionEnabled(Hero ransomPayer, int ransomPrice)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AcceptRansomOffer(int ransomPrice)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeclineRansomOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleDeclineRansomOffer(Hero victim)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPrisonersChangeInSettlement(Settlement settlement, FlattenedTroopRoster roster, Hero prisoner, bool takenFromDungeon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroPrisonerReleased(Hero prisoner, PartyBase party, IFaction capturerFaction, EndCaptivityDetail detail, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RansomOfferCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static RansomOfferCampaignBehavior()
	{
		throw null;
	}
}
