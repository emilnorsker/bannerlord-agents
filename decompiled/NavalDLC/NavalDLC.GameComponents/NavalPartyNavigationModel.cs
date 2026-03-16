using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace NavalDLC.GameComponents;

public class NavalPartyNavigationModel : PartyNavigationModel
{
	private readonly Dictionary<NavigationType, int[]> _invalidTypesIntegerCache;

	private readonly PartyNavigationModel _baseModel;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetEmbarkDisembarkThresholdDistance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsTerrainTypeValidForNaval(TerrainType t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalPartyNavigationModel(PartyNavigationModel partyNavigationModel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeInvalidTypesCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsTerrainTypeValidForNavigationType(TerrainType terrainType, NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int[] GetInvalidTerrainTypesForNavigationType(NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool HasNavalNavigationCapability(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanPlayerNavigateToPosition(CampaignVec2 vec2, out NavigationType navigationType)
	{
		throw null;
	}
}
