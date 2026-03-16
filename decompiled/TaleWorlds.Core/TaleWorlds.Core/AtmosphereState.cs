using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Core;

public class AtmosphereState
{
	public Vec3 Position;

	public float TemperatureAverage;

	public float TemperatureVariance;

	public float HumidityAverage;

	public float HumidityVariance;

	public float distanceForMaxWeight;

	public float distanceForMinWeight;

	public string ColorGradeTexture;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AtmosphereState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AtmosphereState(Vec3 position, float tempAv, float tempVar, float humAv, float humVar, string colorGradeTexture)
	{
		throw null;
	}
}
