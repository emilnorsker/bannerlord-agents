using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;

namespace StoryMode.GameComponents;

public class StoryModePrisonerRecruitmentCalculationModel : PrisonerRecruitmentCalculationModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateRecruitableNumber(PartyBase party, CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetConformityChangePerHour(PartyBase party, CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetConformityNeededToRecruitPrisoner(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetPrisonerRecruitmentMoraleEffect(PartyBase party, CharacterObject character, int num)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsPrisonerRecruitable(PartyBase party, CharacterObject character, out int conformityNeeded)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool ShouldPartyRecruitPrisoners(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StoryModePrisonerRecruitmentCalculationModel()
	{
		throw null;
	}
}
