using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace Helpers;

public static class ShipHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Banner GetShipBanner(IShipOrigin shipOrigin, IAgent captain = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static (uint sailColor1, uint sailColor2) GetSailColors(IShipOrigin shipOrigin, IAgent captain = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Banner GetShipBanner(PartyBase party = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static (uint sailColor1, uint sailColor2) GetSailColors(PartyBase party = null)
	{
		throw null;
	}
}
