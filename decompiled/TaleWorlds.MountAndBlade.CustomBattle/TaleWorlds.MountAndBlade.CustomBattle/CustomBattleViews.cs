using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace TaleWorlds.MountAndBlade.CustomBattle;

[ViewCreatorModule]
public class CustomBattleViews
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	[ViewMethod("CustomBattle")]
	public static MissionView[] OpenCustomBattleMission(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[ViewMethod("CustomSiegeBattle")]
	public static MissionView[] OpenCustomSiegeBattleMission(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[ViewMethod("CustomBattleLordsHall")]
	public static MissionView[] OpenCustomBattleLordsHallMission(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomBattleViews()
	{
		throw null;
	}
}
