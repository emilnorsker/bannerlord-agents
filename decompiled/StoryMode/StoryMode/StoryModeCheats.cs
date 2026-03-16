using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace StoryMode;

public static class StoryModeCheats
{
	public const string NotStoryMode = "Game mode is not correct!";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckCheatUsage(ref string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("add_family_members", "storymode")]
	public static string AddFamilyMembers(List<string> strings)
	{
		throw null;
	}
}
