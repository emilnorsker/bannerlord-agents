using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Buildings;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSettlementPatrolModel : SettlementPatrolModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetPatrolPartySpawnDuration(Settlement settlement, bool naval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanSettlementHavePatrolParties(Settlement settlement, bool naval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HasGuardHouse(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Building GetGuardHouse(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PartyTemplateObject GetPartyTemplateForPatrolParty(Settlement settlement, bool naval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSettlementPatrolModel()
	{
		throw null;
	}
}
