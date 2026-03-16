using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TaleWorlds.ActivitySystem;

public class TestActivityService : IActivityService
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IActivityService.StartActivity(string activityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IActivityService.EndActivity(string activityId, ActivityOutcome outcome)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<Activity> IActivityService.GetActivity(string activityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IActivityService.SetAvailability(string activityId, bool isAvailable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IActivityService.IsInitializationCompleted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ActivityTransition GetActivityTransition(string activityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TestActivityService()
	{
		throw null;
	}
}
