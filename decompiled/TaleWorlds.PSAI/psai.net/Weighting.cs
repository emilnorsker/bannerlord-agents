using System.Runtime.CompilerServices;

namespace psai.net;

public class Weighting
{
	public float switchGroups;

	public float intensityVsVariety;

	public float lowPlaycountVsRandom;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Weighting()
	{
		throw null;
	}
}
