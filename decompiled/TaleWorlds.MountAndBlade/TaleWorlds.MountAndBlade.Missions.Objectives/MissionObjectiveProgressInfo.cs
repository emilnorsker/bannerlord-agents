using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Missions.Objectives;

public struct MissionObjectiveProgressInfo
{
	public int RequiredProgressAmount;

	public int CurrentProgressAmount;

	public bool HasProgress
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}
}
