using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors.BarterBehaviors;

public class DiplomaticBartersBehavior : CampaignBehaviorBase
{
	private const int MinimumDaysOfTributeNeededForPeace = 5;

	private const float IndependentClanLikelihoodThresholdToMakePeace = 0.5f;

	private const float IndependentClanPeaceConsiderChance = 0.5f;

	private const float IndependentClanConsiderPeaceWithAnotherClanChance = 0.5f;

	private const float ClanLeaveKingdomChance = 0.4f;

	private const float ClanConsideringWarDeclarationChance = 0.7f;

	private const int IndependentClanLeaderMinimumRelationForDeclaringPeaceWithKingdom = -65;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderClanLeaveKingdom(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderClanLeaveAsMercenary(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderClanJoin(Clan clan, Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderClanJoinAsMercenary(Clan clan, Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderDefection(Clan clan1, Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderPeace(Clan clan1, Clan clan2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderWar(Clan clan, IFaction otherMapFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DiplomaticBartersBehavior()
	{
		throw null;
	}
}
