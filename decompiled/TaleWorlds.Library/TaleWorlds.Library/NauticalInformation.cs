using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct NauticalInformation
{
	public float WaveStrength;

	public Vec2 WindVector;

	public int CanUseLowAltitudeAtmosphere;

	public int UseSceneWindDirection;

	public int IsRiverBattle;

	public int IsInsideStorm;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeserializeFrom(IReader reader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SerializeTo(IWriter writer)
	{
		throw null;
	}
}
