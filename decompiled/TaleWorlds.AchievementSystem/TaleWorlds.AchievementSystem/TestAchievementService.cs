using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TaleWorlds.AchievementSystem;

public class TestAchievementService : IAchievementService
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IAchievementService.SetStat(string name, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<int> IAchievementService.GetStat(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<int[]> IAchievementService.GetStats(string[] names)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IAchievementService.IsInitializationCompleted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TestAchievementService()
	{
		throw null;
	}
}
