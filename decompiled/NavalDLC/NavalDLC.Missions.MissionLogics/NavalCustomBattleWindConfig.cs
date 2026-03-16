using System.Runtime.CompilerServices;

namespace NavalDLC.Missions.MissionLogics;

public class NavalCustomBattleWindConfig
{
	public enum Direction
	{
		TowardsDefender,
		TowardsAttacker,
		Side,
		Random
	}

	public static Direction WindDirection;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalCustomBattleWindConfig()
	{
		throw null;
	}
}
