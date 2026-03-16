using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace NavalDLC.View;

public class NavalMapSceneWrapper : INavalMapSceneWrapper
{
	private const string VillageDropOffPointTag = "main_map_village_dropoff";

	private MapScene _mapScene;

	private Dictionary<string, List<(CampaignVec2, float)>> _pirateSpawnPoints;

	private Dictionary<Village, CampaignVec2> _villageDropOffPositions;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMapSceneWrapper()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePirateSpawnPoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<(CampaignVec2, float)> GetSpawnPoints(string stringId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<(CampaignVec2, float)> GetSpawnPoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeDropOffLocations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignVec2 GetDropOffLocation(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Dictionary<Village, CampaignVec2> GetAllDropOffLocations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetWindAtPosition(Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeMapWaterWake()
	{
		throw null;
	}
}
