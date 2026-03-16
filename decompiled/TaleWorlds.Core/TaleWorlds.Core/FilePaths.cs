using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Core;

public static class FilePaths
{
	public const string SaveDirectoryName = "Game Saves";

	public const string RecordingsDirectoryName = "Recordings";

	public const string StatisticsDirectoryName = "Statistics";

	public static PlatformDirectoryPath SavePath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static PlatformDirectoryPath RecordingsPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static PlatformDirectoryPath StatisticsPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}
}
