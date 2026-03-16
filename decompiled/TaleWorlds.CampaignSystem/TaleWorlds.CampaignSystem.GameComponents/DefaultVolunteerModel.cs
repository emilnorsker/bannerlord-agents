using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultVolunteerModel : VolunteerModel
{
	public override int MaxVolunteerTier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int MaximumIndexHeroCanRecruitFromHero(Hero buyerHero, Hero sellerHero, int useValueAsRelation = -101)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int MaximumIndexGarrisonCanRecruitFromHero(Settlement settlement, Hero sellerHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int MaximumIndexCanPartyRecruitFromHeroInternal(Hero buyerHero, Hero sellerHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDailyVolunteerProductionProbability(Hero hero, int index, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CharacterObject GetBasicVolunteer(Hero sellerHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanHaveRecruits(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultVolunteerModel()
	{
		throw null;
	}
}
