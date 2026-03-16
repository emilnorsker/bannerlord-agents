using System.Runtime.CompilerServices;

namespace psai.net;

public class SoundtrackInfo
{
	public int themeCount;

	public int[] themeIds;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SoundtrackInfo()
	{
		throw null;
	}
}
