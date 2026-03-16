using System.Runtime.CompilerServices;
using Galaxy.Api;

namespace TaleWorlds.PlatformService.GOG;

public class StatsAndAchievementsStoreListener : GlobalStatsAndAchievementsStoreListener
{
	public delegate void UserStatsAndAchievementsStored(bool success, FailureReason? failureReason);

	public event UserStatsAndAchievementsStored OnUserStatsAndAchievementsStored
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUserStatsAndAchievementsStoreFailure(FailureReason failureReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUserStatsAndAchievementsStoreSuccess()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StatsAndAchievementsStoreListener()
	{
		throw null;
	}
}
