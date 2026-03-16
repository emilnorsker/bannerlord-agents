using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors.AiBehaviors;

public class AiEngagePartyBehavior : CampaignBehaviorBase
{
	private IDisbandPartyCampaignBehavior _disbandPartyCampaignBehavior;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AiHourlyTick(MobileParty mobileParty, PartyThinkParams p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AiEngagePartyBehavior()
	{
		throw null;
	}
}
