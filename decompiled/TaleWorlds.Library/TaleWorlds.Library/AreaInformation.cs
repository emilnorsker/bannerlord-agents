using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct AreaInformation
{
	public float Temperature;

	public float Humidity;

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
