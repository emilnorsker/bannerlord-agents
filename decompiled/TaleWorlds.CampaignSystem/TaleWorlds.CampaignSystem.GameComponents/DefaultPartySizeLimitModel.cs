using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultPartySizeLimitModel : PartySizeLimitModel
{
	private enum LimitType
	{
		MobilePartySizeLimit,
		GarrisonPartySizeLimit,
		PrisonerSizeLimit
	}

	private const int BaseMobilePartySize = 20;

	private const int BaseMobilePartyPrisonerSize = 10;

	private const int BaseSettlementPrisonerSize = 60;

	private const int SettlementPrisonerSizeBonusPerWallLevel = 40;

	private const int BaseGarrisonPartySize = 200;

	private const int BasePatrolPartySize = 10;

	private const int TownGarrisonSizeBonus = 200;

	private const int AdditionalPartySizeForCheat = 5000;

	private const int OneVillagerPerHearth = 40;

	private const int AdditionalPartySizeLimitPerTier = 15;

	private const int AdditionalPartySizeLimitForLeaderPerTier = 25;

	private readonly TextObject _leadershipSkillLevelBonusText;

	private readonly TextObject _leadershipPerkUltimateLeaderBonusText;

	private readonly TextObject _wallLevelBonusText;

	private readonly TextObject _baseSizeText;

	private readonly TextObject _clanTierText;

	private readonly TextObject _renownText;

	private readonly TextObject _clanLeaderText;

	private readonly TextObject _factionLeaderText;

	private readonly TextObject _leaderLevelText;

	private readonly TextObject _townBonusText;

	private readonly TextObject _minorFactionText;

	private readonly TextObject _currentPartySizeBonusText;

	private readonly TextObject _randomSizeBonusTemporary;

	private static bool _addAdditionalPartySizeAsCheat;

	private static bool _addAdditionalPrisonerSizeAsCheat;

	public override int MinimumNumberOfVillagersAtVillagerParty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultPartySizeLimitModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetPartyMemberSizeLimit(PartyBase party, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ExplainedNumber CalculatePatrolPartySizeLimit(MobileParty mobileParty, bool includeDescriptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetPatrolPartySizeLimitFromGuardHouseLevel(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetPartyPrisonerSizeLimit(PartyBase party, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ExplainedNumber CalculateMobilePartyMemberSizeLimit(MobileParty party, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateGarrisonPartySizeLimit(Settlement settlement, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ExplainedNumber CalculateSettlementPartyPrisonerSizeLimitInternal(Settlement settlement, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ExplainedNumber CalculateMobilePartyPrisonerSizeLimitInternal(PartyBase party, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddMobilePartyLeaderPrisonerSizePerkEffects(PartyBase party, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGarrisonOwnerPerkEffects(Settlement currentSettlement, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetNextClanTierPartySizeEffectChangeForHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetTierEffectInternal(int tier, bool isHeroClanLeader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetAssumedPartySizeForLordParty(Hero leaderHero, IFaction partyMapFaction, Clan actualClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetClanTierPartySizeEffectForHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSettlementProjectBonuses(Settlement settlement, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSettlementProjectPrisonerBonuses(Settlement settlement, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetCurrentPartySizeEffect(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateBaseMemberSize(Hero partyLeader, IFaction partyMapFaction, Clan actualClan, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetPartySizeRatioForSize(PartyTemplateObject partyTemplate, int desiredSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetInitialPartySizeRatioForMobileParty(MobileParty party, PartyTemplateObject partyTemplate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetIdealVillagerPartySize(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TroopRoster FindAppropriateInitialRosterForMobileParty(MobileParty party, PartyTemplateObject partyTemplate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<Ship> FindAppropriateInitialShipsForMobileParty(MobileParty party, PartyTemplateObject partyTemplate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultPartySizeLimitModel()
	{
		throw null;
	}
}
