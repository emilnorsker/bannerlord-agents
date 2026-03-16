using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace psai.net;

public class Soundtrack
{
	public Dictionary<int, Theme> m_themes;

	public Dictionary<int, Segment> m_snippets;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Soundtrack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Theme getThemeById(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Segment GetSegmentById(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SoundtrackInfo getSoundtrackInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ThemeInfo getThemeInfo(int themeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SegmentInfo getSegmentInfo(int snippetId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateMaxPreBeatMsOfCompatibleMiddleOrBridgeSnippets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BuildAllIndirectionSequences()
	{
		throw null;
	}
}
