using System.Runtime.CompilerServices;

namespace psai.net;

public class ThemeInfo
{
	public int id;

	public ThemeType type;

	public int[] segmentIds;

	public string name;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ThemeInfo()
	{
		throw null;
	}
}
