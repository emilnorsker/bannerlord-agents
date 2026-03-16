using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace NavalDLC.GameComponents;

public class NavalSettlementPatrolModel : SettlementPatrolModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanSettlementHavePatrolParties(Settlement settlement, bool naval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PartyTemplateObject GetPartyTemplateForPatrolParty(Settlement settlement, bool naval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetPatrolPartySpawnDuration(Settlement settlement, bool naval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HasCoastalEdict(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalSettlementPatrolModel()
	{
		throw null;
	}
}
