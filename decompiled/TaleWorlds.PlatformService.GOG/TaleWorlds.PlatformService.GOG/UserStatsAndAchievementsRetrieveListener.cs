using System.Runtime.CompilerServices;
using Galaxy.Api;

namespace TaleWorlds.PlatformService.GOG;

public class UserStatsAndAchievementsRetrieveListener : GlobalUserStatsAndAchievementsRetrieveListener
{
	public delegate void UserStatsAndAchievementsRetrieved(GalaxyID userID, bool success, FailureReason? failureReason);

	public event UserStatsAndAchievementsRetrieved OnUserStatsAndAchievementsRetrieved
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
	public override void OnUserStatsAndAchievementsRetrieveSuccess(GalaxyID userID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUserStatsAndAchievementsRetrieveFailure(GalaxyID userID, FailureReason failureReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UserStatsAndAchievementsRetrieveListener()
	{
		throw null;
	}
}
