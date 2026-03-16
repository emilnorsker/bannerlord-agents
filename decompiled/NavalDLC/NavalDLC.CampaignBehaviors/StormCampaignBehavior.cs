using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NavalDLC.Map;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;

namespace NavalDLC.CampaignBehaviors;

public class StormCampaignBehavior : CampaignBehaviorBase
{
	private List<Vec2> _allOpenSeaWeatherNodePositions;

	private float _spawnDistanceSquaredThreshold;

	private int[] _weatherNodePositionsShuffledIndices;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DamageNearbyParties(Storm spawnedStorm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryDamagingParty(MobileParty mobileParty, Storm affectingStorm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TrySpawningNewStorm()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateAndShuffleWeatherNodeDataIndicesDeterministic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunchedEvent(CampaignGameStarter obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeStormNodes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void MainPartyStormDamageDebugVisualTick(Storm storm, MobileParty nearbyParty, Ship ship, float damage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StormCampaignBehavior()
	{
		throw null;
	}
}
