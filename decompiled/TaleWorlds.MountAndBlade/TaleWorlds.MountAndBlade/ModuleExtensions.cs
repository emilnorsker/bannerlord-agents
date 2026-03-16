using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class ModuleExtensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<UsableMachine> GetUsedMachines(this Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartUsingMachine(this Formation formation, UsableMachine usable, bool isPlayerOrder = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StopUsingMachine(this Formation formation, UsableMachine usable, bool isPlayerOrder = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WorldPosition ToWorldPosition(this Vec3 rawPosition)
	{
		throw null;
	}
}
