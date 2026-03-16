using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Objects.Usables;

public class RemoveExtraWeaponOnStopUsageComponent : UsableMissionObjectComponent
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnUseStopped(Agent userAgent, bool isSuccessful = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RemoveExtraWeaponOnStopUsageComponent()
	{
		throw null;
	}
}
