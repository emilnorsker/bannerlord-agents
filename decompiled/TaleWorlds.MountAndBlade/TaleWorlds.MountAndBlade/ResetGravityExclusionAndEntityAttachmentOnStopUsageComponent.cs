using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class ResetGravityExclusionAndEntityAttachmentOnStopUsageComponent : UsableMissionObjectComponent
{
	public Action<Agent> OnUseAction;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ResetGravityExclusionAndEntityAttachmentOnStopUsageComponent(Action<Agent> onUseAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnUse(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnUseStopped(Agent userAgent, bool isSuccessful = true)
	{
		throw null;
	}
}
