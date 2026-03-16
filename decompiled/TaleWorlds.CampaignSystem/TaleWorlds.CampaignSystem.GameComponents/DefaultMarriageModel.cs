using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultMarriageModel : MarriageModel
{
	private const float BaseMarriageChanceForNpcs = 0.002f;

	public override int MinimumMarriageAgeMale
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MinimumMarriageAgeFemale
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsCoupleSuitableForMarriage(Hero firstHero, Hero secondHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsClanSuitableForMarriage(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float NpcCoupleMarriageChance(Hero firstHero, Hero secondHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool ShouldNpcMarriageBetweenClansBeAllowed(Clan consideringClan, Clan targetClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<Hero> GetAdultChildrenSuitableForMarriage(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreHeroesRelatedAux1(Hero firstHero, Hero secondHero, int ancestorDepth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreHeroesRelatedAux2(Hero firstHero, Hero secondHero, int ancestorDepth, int secondAncestorDepth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreHeroesRelated(Hero firstHero, Hero secondHero, int ancestorDepth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetEffectiveRelationIncrease(Hero firstHero, Hero secondHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsSuitableForMarriage(Hero maidenOrSuitor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Clan GetClanAfterMarriage(Hero firstHero, Hero secondHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultMarriageModel()
	{
		throw null;
	}
}
