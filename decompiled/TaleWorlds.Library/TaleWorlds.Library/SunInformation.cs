using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct SunInformation
{
	public float Altitude;

	public float Angle;

	public Vec3 Color;

	public float Brightness;

	public float MaxBrightness;

	public float Size;

	public float RayStrength;

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
