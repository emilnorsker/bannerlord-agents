using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace SandBox.GameComponents;

public class SandboxAutoBlockModel : AutoBlockModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override UsageDirection GetBlockDirection(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandboxAutoBlockModel()
	{
		throw null;
	}
}
