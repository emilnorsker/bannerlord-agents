using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Engine;

public class Highlights
{
	public enum Significance
	{
		None = 0,
		ExtremelyBad = 1,
		VeryBad = 2,
		Bad = 4,
		Neutral = 0x10,
		Good = 0x100,
		VeryGood = 0x200,
		ExtremelyGoods = 0x400,
		Max = 0x800
	}

	public enum Type
	{
		None = 0,
		Milestone = 1,
		Achievement = 2,
		Incident = 4,
		StateChange = 8,
		Unannounced = 0x10,
		Max = 0x20
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenGroup(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CloseGroup(string id, bool destroy = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SaveScreenshot(string highlightId, string groupId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SaveVideo(string highlightId, string groupId, int startDelta, int endDelta)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenSummary(List<string> groups)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddHighlight(string id, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemoveHighlight(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Highlights()
	{
		throw null;
	}
}
