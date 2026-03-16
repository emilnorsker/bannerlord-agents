using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class OverrideStrikeAndDeathActionDuringUsageComponent : UsableMissionObjectComponent
{
	private readonly ActionIndexCache _strikeAction;

	private readonly ActionIndexCache _deathAction;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OverrideStrikeAndDeathActionDuringUsageComponent(in ActionIndexCache strikeAction, in ActionIndexCache deathAction)
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
