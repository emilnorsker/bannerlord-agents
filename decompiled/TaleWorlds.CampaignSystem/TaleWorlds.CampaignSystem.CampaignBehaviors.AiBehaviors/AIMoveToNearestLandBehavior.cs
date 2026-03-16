using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors.AiBehaviors;

internal class AIMoveToNearestLandBehavior : CampaignBehaviorBase
{
	private const int MoveToNearestLandMaximumScore = 2;

	private const float RatioThreshold = 0.75f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AiHourlyTick(MobileParty mobileParty, PartyThinkParams p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AIMoveToNearestLandBehavior()
	{
		throw null;
	}
}
