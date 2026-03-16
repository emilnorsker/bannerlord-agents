using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultAlleyModel : AlleyModel
{
	public enum AlleyMemberAvailabilityDetail
	{
		Available,
		AvailableWithDelay,
		NotEnoughRoguerySkill,
		NotEnoughMercyTrait,
		CanNotLeadParty,
		AlreadyAlleyLeader,
		Prisoner,
		SolvingIssue,
		Traveling,
		Busy,
		Fugutive,
		Governor,
		AlleyUnderAttack
	}

	private const int BaseResponseTimeInDays = 8;

	private const int MaxResponseTimeInDays = 12;

	public const int MinimumRoguerySkillNeededForLeadingAnAlley = 30;

	public const int MaximumMercyTraitNeededForLeadingAnAlley = 0;

	private CharacterObject _thug
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private CharacterObject _expertThug
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private CharacterObject _masterThug
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override CampaignTime DestroyAlleyAfterDaysWhenLeaderIsDeath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MinimumTroopCountInPlayerOwnedAlley
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MaximumTroopCountInPlayerOwnedAlley
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override float GetDailyCrimeRatingOfAlley
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDailyXpGainForAssignedClanMember(Hero assignedHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDailyXpGainForMainHero()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetInitialXpGainForMainHero()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetXpGainAfterSuccessfulAlleyDefenseForMainHero()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TroopRoster GetTroopsOfAIOwnedAlley(Alley alley)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TroopRoster GetTroopsOfAlleyForBattleMission(Alley alley)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TroopRoster GetTroopsOfAlleyInternal(Alley alley)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<(Hero, AlleyMemberAvailabilityDetail)> GetClanMembersAndAvailabilityDetailsForLeadingAnAlley(Alley alley)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TroopRoster GetTroopsToRecruitFromAlleyDependingOnAlleyRandom(Alley alley, float random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDisabledReasonTextForHero(Hero hero, Alley alley, AlleyMemberAvailabilityDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetAlleyAttackResponseTimeInDays(TroopRoster troopRoster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Clan GetRelatedBanditClanDependingOnAlleySettlementFaction(Alley alley)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private AlleyMemberAvailabilityDetail GetAvailability(Alley alley, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetDailyIncomeOfAlley(Alley alley)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultAlleyModel()
	{
		throw null;
	}
}
