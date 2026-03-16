using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TaleWorlds.AchievementSystem;

namespace TaleWorlds.PlatformService.Epic;

internal class EpicAchievementService : IAchievementService
{
	private EpicPlatformServices _epicPlatformServices;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EpicAchievementService(EpicPlatformServices epicPlatformServices)
	{
		throw null;
	}

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
}
