using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

internal class DropExtraWeaponOnStopUsageComponent : UsableMissionObjectComponent
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnUseStopped(Agent userAgent, bool isSuccessful = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DropExtraWeaponOnStopUsageComponent()
	{
		throw null;
	}
}
