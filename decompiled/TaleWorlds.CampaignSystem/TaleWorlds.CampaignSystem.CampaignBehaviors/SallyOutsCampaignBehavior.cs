using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class SallyOutsCampaignBehavior : CampaignBehaviorBase
{
	private const int SallyOutCheckPeriodInHours = 4;

	private const float SallyOutPowerRatioForHelpingReliefForce = 1.5f;

	private const float SallyOutPowerRatio = 2f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SallyOutsCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HourlyTickSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForSettlementSallyOut(Settlement settlement, bool forceForCheck = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckSallyOut(Settlement settlement, bool checkForNavalSallyOut, out bool salliedOut)
	{
		throw null;
	}
}
