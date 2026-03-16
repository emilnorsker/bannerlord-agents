using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

[ViewCreatorModule]
public class OtherMissionViews
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	[ViewMethod("BattleChallenge")]
	public static MissionView[] OpenBattleChallengeMission(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OtherMissionViews()
	{
		throw null;
	}
}
