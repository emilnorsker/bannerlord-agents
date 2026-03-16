using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem;

public class PartyThinkParams
{
	public MobileParty MobilePartyOf;

	private readonly MBList<(AIBehaviorData, float)> _aiBehaviorScores;

	private MBList<MobileParty> _possibleArmyMembersUponArmyCreation;

	public float CurrentObjectiveValue;

	public bool WillGatherAnArmy;

	public bool DoNotChangeBehavior;

	public float StrengthOfLordsWithoutArmy;

	public float StrengthOfLordsWithArmy;

	public float StrengthOfLordsAtSameClanWithoutArmy;

	public MBReadOnlyList<(AIBehaviorData, float)> AIBehaviorScores
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MobileParty> PossibleArmyMembersUponArmyCreation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PartyThinkParams(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialization()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPotentialArmyMember(MobileParty armyMember)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetBehaviorScore(in AIBehaviorData aiBehaviorData, out float score)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBehaviorScore(in AIBehaviorData aiBehaviorData, float score)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddBehaviorScore(in (AIBehaviorData, float) value)
	{
		throw null;
	}
}
