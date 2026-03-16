using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class StandingPointWithVolumeBox : StandingPointWithWeaponRequirement
{
	private const float MaxUserAgentDistance = 10f;

	private const float MaxUserAgentElevation = 2f;

	public string VolumeBoxTag;

	public override Agent.AIScriptedFrameFlags DisableScriptedFrameFlags
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsDisabledForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StandingPointWithVolumeBox()
	{
		throw null;
	}
}
