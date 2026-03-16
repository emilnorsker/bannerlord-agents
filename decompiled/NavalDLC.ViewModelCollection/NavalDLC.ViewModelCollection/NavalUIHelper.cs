using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Localization;

namespace NavalDLC.ViewModelCollection;

public static class NavalUIHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetHealthPercent(this Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Tuple<bool, TextObject> GetIsStringApplicableForShipName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Tuple<bool, string> IsStringApplicableForShipName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ship GetFlagship(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TooltipProperty> GetShipyardTooltip(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTownCoastalPatrolTooltip(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPrefabIdOfShipHull(ShipHull shipHull)
	{
		throw null;
	}
}
