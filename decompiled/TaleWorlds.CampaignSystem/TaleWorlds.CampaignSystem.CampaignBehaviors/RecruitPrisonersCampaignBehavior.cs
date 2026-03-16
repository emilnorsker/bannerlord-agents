using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class RecruitPrisonersCampaignBehavior : CampaignBehaviorBase
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HourlyTickMainParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickAIMobileParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GenerateConformityForTroop(MobileParty mobileParty, CharacterObject troop, int hours = 1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyPrisonerRecruitmentEffects(MobileParty mobileParty, CharacterObject troop, int num)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RecruitPrisonersAi(MobileParty mobileParty, CharacterObject troop, int num, int conformityCost)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsPrisonerRecruitable(MobileParty mobileParty, CharacterObject character, out int conformityNeeded)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMainPartyPrisonerRecruited(FlattenedTroopRoster flattenedTroopRosters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RecruitPrisonersCampaignBehavior()
	{
		throw null;
	}
}
