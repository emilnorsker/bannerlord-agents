using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

public struct BannerDebugInfo
{
	public enum SourceTypes
	{
		Undefined,
		Widget,
		Manual
	}

	public SourceTypes SourceType;

	public string SourceName;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BannerDebugInfo CreateManual(string sourceName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BannerDebugInfo CreateWidget(string sourceName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string CreateName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetSourceTypeName(SourceTypes type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}
}
