using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Election;

public class KingdomElection
{
	[SaveableField(0)]
	private readonly KingdomDecision _decision;

	private MBList<DecisionOutcome> _possibleOutcomes;

	[SaveableField(2)]
	private List<Supporter> _supporters;

	[SaveableField(3)]
	private Clan _chooser;

	[SaveableField(4)]
	private DecisionOutcome _chosenOutcome;

	[SaveableField(5)]
	private bool _ignorePlayerSupport;

	[SaveableField(6)]
	private bool _hasPlayerVoted;

	public MBReadOnlyList<DecisionOutcome> PossibleOutcomes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[SaveableProperty(7)]
	public bool IsCancelled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public bool IsPlayerSupporter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private Supporter PlayerAsSupporter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsPlayerChooser
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public KingdomElection(KingdomDecision decision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Setup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartElection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float DetermineInitialSupport(DecisionOutcome possibleOutcome)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartElectionWithoutPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetLikelihoodForSponsor(Clan sponsor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineSupport(MBReadOnlyList<DecisionOutcome> possibleOutcomes, bool calculateRelationshipEffect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSupport(MBReadOnlyList<DecisionOutcome> possibleOutcomes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReadyToAiChoose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyChosenOutcome()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRelationChangeWithSponsor(Hero opposerOrSupporter, Supporter.SupportWeights supportWeight, bool isOpposingSides)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleInfluenceCosts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplySecondaryEffects(MBReadOnlyList<DecisionOutcome> possibleOutcomes, DecisionOutcome chosenOutcome)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetInfluenceRequiredToOverrideDecision(DecisionOutcome popularOutcome, DecisionOutcome overridingOutcome)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DecisionOutcome GetAiChoice(MBReadOnlyList<DecisionOutcome> possibleOutcomes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetChosenOutcomeText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private KingdomDecision.SupportStatus GetSupportStatusOfDecisionOutcome(DecisionOutcome chosenOutcome)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DetermineOfficialSupport()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetInfluenceCostOfOutcome(DecisionOutcome outcome, Clan supporter, Supporter.SupportWeights weight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetSecondaryEffects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerSupport(DecisionOutcome decisionOutcome, Supporter.SupportWeights supportWeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplySelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList<DecisionOutcome> GetSortedDecisionOutcomes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetGeneralTitle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetTitle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetDescription()
	{
		throw null;
	}
}
