using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace psai.net;

public class Theme
{
	public int id;

	public string Name;

	public ThemeType themeType;

	public int priority;

	public int restSecondsMax;

	public int restSecondsMin;

	public List<Segment> m_segments;

	public float intensityAfterRest;

	public int musicDurationGeneral;

	public int musicDurationAfterRest;

	public Weighting weightings;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ThemeInterruptionBehaviorRequiresEvaluationOfSegmentCompatibilities(ThemeInterruptionBehavior interruptionBehavior)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ThemeTypeToString(ThemeType themeType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ThemeInterruptionBehavior GetThemeInterruptionBehavior(ThemeType sourceThemeType, ThemeType targetThemeType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Theme()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BuildSequencesToEndSegmentForAllSnippets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTheNextSnippetToShortestEndSequenceForAllSourceSnippetsOfTheSnippetsInThisList(Segment[] listOfSnippetsWithValidEndSequences)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BuildSequencesToTargetThemeForAllSegments(Soundtrack soundtrack, Theme targetTheme)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<Segment> GetSetOfAllSourceSegmentsCompatibleToSegment(Segment targetSnippet, float minCompatibilityThreshold, SegmentSuitability doNotIncludeSegmentsWithThisSuitability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTheNextSegmentToShortestTransitionSequenceToTargetThemeForAllSourceSegmentsOfTheSegmentsInThisList(Segment[] listOfSnippetsWithValidTransitionSequencesToTargetTheme, Soundtrack soundtrack, Theme targetTheme)
	{
		throw null;
	}
}
