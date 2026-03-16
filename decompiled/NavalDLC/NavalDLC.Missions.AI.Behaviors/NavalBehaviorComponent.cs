using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.AI.Behaviors;

public abstract class NavalBehaviorComponent : BehaviorComponent
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalBehaviorComponent(Formation formation)
	{
		throw null;
	}

	public abstract void RefreshShipReferences();
}
