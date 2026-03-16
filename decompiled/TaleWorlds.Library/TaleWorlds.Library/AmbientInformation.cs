using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct AmbientInformation
{
	public float EnvironmentMultiplier;

	public Vec3 AmbientColor;

	public float MieScatterStrength;

	public float RayleighConstant;

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
