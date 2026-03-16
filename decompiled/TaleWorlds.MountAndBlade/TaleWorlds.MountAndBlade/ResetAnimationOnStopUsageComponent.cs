using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class ResetAnimationOnStopUsageComponent : UsableMissionObjectComponent
{
	private ActionIndexCache _successfulResetAction;

	private readonly bool _alwaysResetWithAction;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ResetAnimationOnStopUsageComponent(ActionIndexCache successfulResetActionCode, bool alwaysResetWithAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateSuccessfulResetAction(ActionIndexCache successfulResetActionCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnUseStopped(Agent userAgent, bool isSuccessful = true)
	{
		throw null;
	}
}
