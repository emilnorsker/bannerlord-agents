using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace NavalDLC.GameComponents;

public class NavalDLCMapWeatherModel : MapWeatherModel
{
	private const float MaximumWindSpeed = 30f;

	private const float MinWindWithStormOnCampaignMap = 0.1f;

	private const float MaxWindWithStormOnCampaignMap = 1f;

	private const float MinWindWithoutStormOnCampaignMap = 1f / 15f;

	private const float MaxWindWithoutStormOnCampaignMap = 0.46f;

	private const float MinWindSpeedRatioWithStormOnMission = 2f / 3f;

	private const float MaxWindSpeedRatioWithStormOnMission = 1f;

	private const float MinWindSpeedRatioWithoutStormOnMission = 0.4f;

	private const float MaxWindSpeedRatioWithoutStormOnMission = 8f / 15f;

	public override CampaignTime WeatherUpdateFrequency
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override CampaignTime WeatherUpdatePeriod
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override AtmosphereInfo GetAtmosphereModel(CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override AtmosphereState GetInterpolatedAtmosphereState(CampaignTime timeOfYear, Vec3 pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetSeasonTimeFactorOfCampaignTime(CampaignTime ct, out float timeFactorForSnow, out float timeFactorForRain, bool snapCampaignTimeToWeatherPeriod = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetSnowAndRainDataForPosition(Vec2 position, CampaignTime ct, out float snowValue, out float rainValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override WeatherEventEffectOnTerrain GetWeatherEffectOnTerrainForPosition(Vec2 pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void InitializeCaches()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override WeatherEvent GetWeatherEventInPosition(Vec2 pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Vec2 GetWindForPosition(CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override WeatherEvent UpdateWeatherForPosition(CampaignVec2 position, CampaignTime ct)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsPositionInsideStormForMission(CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCMapWeatherModel()
	{
		throw null;
	}
}
