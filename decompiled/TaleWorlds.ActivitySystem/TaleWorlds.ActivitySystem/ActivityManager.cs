using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TaleWorlds.ActivitySystem;

public class ActivityManager
{
	public static IActivityService ActivityService
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ActivityManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool StartActivity(string activityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool EndActivity(string activityId, ActivityOutcome outcome)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SetActivityAvailability(string activityId, bool isAvailable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Task<Activity> GetActivity(string activityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ActivityTransition GetActivityTransition(string activityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ActivityManager()
	{
		throw null;
	}
}
