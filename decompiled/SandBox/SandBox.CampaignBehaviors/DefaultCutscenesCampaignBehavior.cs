using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.MapEvents;

namespace SandBox.CampaignBehaviors;

public class DefaultCutscenesCampaignBehavior : CampaignBehaviorBase
{
	private bool _heroWonLastMapEVent;

	private CultureObject _lastEnemyCulture;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBeforeMainCharacterDied(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnKingdomDecisionConcluded(KingdomDecision decision, DecisionOutcome chosenOutcome, bool isPlayerInvolved)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMercenaryServiceEnded(Clan clan, EndMercenaryServiceActionDetails detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnKingdomDestroyed(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnKingdomCreated(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroComesOfAge(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventEnd(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnHeroesMarried(Hero firstHero, Hero secondHero, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void FillAllyCharacters(bool noCompanions, ref List<CharacterObject> allyCharacters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Hero GetMentorHeroForComeOfAge(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultCutscenesCampaignBehavior()
	{
		throw null;
	}
}
