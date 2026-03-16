using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.View.Map.Visuals;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.Engine;

namespace SandBox.View.Map.Managers;

public class MapWeatherVisualManager : EntityVisualManagerBase<WeatherNode>
{
	public const int DefaultCloudHeight = 26;

	public const int OpenSeaStormCloudHeight = 20;

	private MapWeatherVisual[] _allWeatherNodeVisuals;

	private const string RainPrefabName = "campaign_rain_prefab";

	private const string BlizzardPrefabName = "campaign_snow_prefab";

	private const string RainSoundPath = "event:/map/ambient/bed/rain";

	private const string SnowSoundPath = "event:/map/ambient/bed/snow";

	private const string WeatherEventParameterName = "Rainfall";

	private const string CameraRainPrefabName = "map_camera_rain_prefab";

	private const string CameraStormPrefabName = "map_camera_storm_prefab";

	private const int DefaultRainObjectPoolCount = 5;

	private const int DefaultBlizzardObjectPoolCount = 5;

	private const int WeatherCheckOriginZDelta = 25;

	private readonly List<GameEntity> _unusedRainPrefabEntityPool;

	private readonly List<GameEntity> _unusedBlizzardPrefabEntityPool;

	private readonly Scene _mapScene;

	private readonly byte[] _rainData;

	private readonly byte[] _rainDataTemporal;

	private SoundEvent _currentRainSound;

	private SoundEvent _currentBlizzardSound;

	private GameEntity _cameraRainEffect;

	private GameEntity _cameraStormEffect;

	public static MapWeatherVisualManager Current
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int Priority
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int DimensionSquared
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapWeatherVisualManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnVisualTick(MapScreen screen, float realDt, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRainData(int dataIndex, byte value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCloudData(int dataIndex, byte value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WeatherAudioAndVisualTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroyRainSound()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroyBlizzardSound()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartRainSoundIfNeeded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartBlizzardSoundIfNeeded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetRainPrefabFromPool()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetBlizzardPrefabFromPool()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseRainPrefab(GameEntity prefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseBlizzardPrefab(GameEntity prefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeObjectPoolWithDefaultCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<GameEntity> CreateNewWeatherPrefabPoolElements(string prefabName, int delta)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MapEntityVisual<WeatherNode> GetVisualOfEntity(WeatherNode entity)
	{
		throw null;
	}
}
