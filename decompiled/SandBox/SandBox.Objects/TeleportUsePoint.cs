using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects;

public class TeleportUsePoint : StandingPoint
{
	public enum TeleportType
	{
		Lair,
		Door,
		Gate
	}

	public TeleportType TypeOfTeleport;

	public string TargetPointTag;

	public bool IsLeave;

	private const float LairInteractionDistance = 0.5f;

	private const float GateInteractionDistance = 2.5f;

	public override bool HasAIMovingTo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TeleportUsePoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsAIMovingTo(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsUsableByAgent(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsDisabledForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUse(Agent userAgent, sbyte agentBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Activate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFocusGain(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetInteractionDistance()
	{
		throw null;
	}
}
