using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct TimeInformation
{
	public float TimeOfDay;

	public float NightTimeFactor;

	public float DrynessFactor;

	public float WinterTimeFactor;

	public int Season;

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
