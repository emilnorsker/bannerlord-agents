using System.Runtime.CompilerServices;

namespace psai.net;

internal class FadeData
{
	public int voiceNumber;

	public int delayMillis;

	public float fadeoutDeltaVolumePerUpdate;

	public float currentVolume;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FadeData()
	{
		throw null;
	}
}
