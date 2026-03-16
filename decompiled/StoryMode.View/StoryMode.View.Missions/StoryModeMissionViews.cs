using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace StoryMode.View.Missions;

[ViewCreatorModule]
public class StoryModeMissionViews
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	[ViewMethod("TrainingField")]
	public static MissionView[] OpenVillageMission(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[ViewMethod("SneakIntoTheVillaMission")]
	public static MissionView[] OpenSneakIntoTheVillaMission(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StoryModeMissionViews()
	{
		throw null;
	}
}
