using System.Runtime.CompilerServices;

namespace psai.net;

public class SegmentInfo
{
	public int id;

	public int segmentSuitabilitiesBitfield;

	public float intensity;

	public int themeId;

	public int playcount;

	public string name;

	public int fullLengthInMilliseconds;

	public int preBeatLengthInMilliseconds;

	public int postBeatLengthInMilliseconds;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SegmentInfo()
	{
		throw null;
	}
}
