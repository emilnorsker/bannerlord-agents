using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace TaleWorlds.MountAndBlade;

public class CustomBattleAutoBlockModel : AutoBlockModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Agent.UsageDirection GetBlockDirection(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomBattleAutoBlockModel()
	{
		throw null;
	}
}
