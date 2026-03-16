using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct FogInformation
{
	public float Density;

	public Vec3 Color;

	public float Falloff;

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
