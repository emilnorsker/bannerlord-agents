using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;

namespace NavalDLC.GameComponents;

public class NavalDLCShipLimitModel : PartyShipLimitModel
{
	private const int LordPartyShipBaseLimit = 3;

	private const int ConvoyPartyShipBaseLimit = 3;

	private const int BanditPartyShipBaseLimit = 3;

	private const float MustSellPriorityValue = float.MaxValue;

	private const float MustDiscardPriorityValue = float.MinValue;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetIdealShipNumber(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetIdealShipNumber(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetShipPriority(MobileParty mobileParty, Ship ship, bool isSelling)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCShipLimitModel()
	{
		throw null;
	}
}
