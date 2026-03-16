using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultMapWeatherModel : MapWeatherModel
{
	private struct SunPosition
	{
		public float Angle
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			private set
			{
				throw null;
			}
		}

		public float Altitude
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			private set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SunPosition(float angle, float altitude)
		{
			throw null;
		}
	}

	private const float MinSunAngle = 0f;

	private const float MaxSunAngle = 50f;

	private const float MinEnvironmentMultiplier = 0.001f;

	private const float DayEnvironmentMultiplier = 1f;

	private const float NightEnvironmentMultiplier = 0.001f;

	private const float SnowStartThreshold = 0.55f;

	private const float DenseSnowStartThreshold = 0.85f;

	private const float NoSnowDelta = 0.1f;

	private const float WetThreshold = 0.6f;

	private const float WetThresholdForTexture = 0.3f;

	private const float LightRainStartThreshold = 0.7f;

	private const float DenseRainStartThreshold = 0.85f;

	private const float SnowFrequencyModifier = 0.1f;

	private const float RainFrequencyModifier = 0.45f;

	private const float MaxSnowCoverage = 0.75f;

	private const float WaveMultiplierForSettlements = 0.3f;

	private WeatherEvent[] _weatherDataCache;

	private AtmosphereGrid _atmosphereGrid;

	private bool _sunIsMoon;

	private float SunRiseNorm
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float SunSetNorm
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float DayTime
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

	public override CampaignTime WeatherUpdateFrequency
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private CampaignTime PreviousRainDataCheckForWetness
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private uint GetSeed(CampaignTime campaignTime, Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultMapWeatherModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override AtmosphereState GetInterpolatedAtmosphereState(CampaignTime timeOfYear, Vec3 pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2 GetNodePositionForWeather(Vec2 pos, out int xIndex, out int yIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override AtmosphereInfo GetAtmosphereModel(CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void InitializeCaches()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override WeatherEvent UpdateWeatherForPosition(CampaignVec2 position, CampaignTime ct)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WeatherEvent SetIsBlizzardOrSnowFromFunction(float snowValue, CampaignTime campaignTime, in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WeatherEvent SetIsRainingOrWetFromFunction(float rainValue, CampaignTime campaignTime, in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetCurrentWeatherInAdjustedPosition(uint seed, float frequency, float chanceModifier, in Vec2 adjustedPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetSelectedAtmosphereId(CampaignTime.Seasons selectedSeason, bool isRaining, float snowValue, float rainValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSeasonRainAndSnowDataForOpeningMission(Vec2 position, out CampaignTime.Seasons selectedSeason, out bool isRaining, out float rainValue, out float snowFallDensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SunPosition GetSunPosition(float hourNorm, float seasonFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetSunColor(float environmentMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSunBrightness(float environmentMultiplier, bool forceDay = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSunSize(float envMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSunRayStrength(float envMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetEnvironmentMultiplier(SunPosition sunPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetModifiedEnvironmentMultiplier(float envMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSkyBrightness(float hourNorm, float envMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetFogDensity(float environmentMultiplier, Vec3 pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetFogColor(float environmentMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetAmbientFogColor(float moddedEnvMul)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMieScatterStrength(float envMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetRayleighConstant(float envMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetHourOfDay()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetHourOfDayNormalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetNightTimeFactor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetExposureCoefficientBetweenDayNight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetSnowAndRainDataForPosition(Vec2 position, CampaignTime ct, out float snowValue, out float rainValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override WeatherEvent GetWeatherEventInPosition(Vec2 pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override WeatherEventEffectOnTerrain GetWeatherEffectOnTerrainForPosition(Vec2 pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetWinterTimeFactor(CampaignTime timeOfYear)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetDrynessFactor(CampaignTime timeOfYear)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetSeasonTimeFactorOfCampaignTime(CampaignTime ct, out float timeFactorForSnow, out float timeFactorForRain, bool snapCampaignTimeToWeatherPeriod = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateTimeFactorForSnow(float yearProgress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateTimeFactorForRain(float yearProgress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetTemperature(ref AtmosphereState gridInfo, float seasonFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetHumidity(ref AtmosphereState gridInfo, float seasonFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Vec2 GetWindForPosition(CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetWaveStrengthForPosition(CampaignVec2 position)
	{
		throw null;
	}
}
