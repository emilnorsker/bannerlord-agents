using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct PostProcessInformation
{
	public float MinExposure;

	public float MaxExposure;

	public float BrightpassThreshold;

	public float MiddleGray;

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
