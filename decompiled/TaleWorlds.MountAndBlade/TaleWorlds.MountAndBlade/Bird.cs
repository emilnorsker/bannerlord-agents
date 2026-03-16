using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class Bird : MissionObject
{
	private enum State
	{
		TakingOff,
		Airborne,
		Landing,
		Perched
	}

	[EditableScriptComponentVariable(true, "")]
	private float _flyingSpeedInKph;

	[EditableScriptComponentVariable(true, "")]
	private string _idleAnimation;

	[EditableScriptComponentVariable(true, "")]
	private string _landingAnimation;

	[EditableScriptComponentVariable(true, "")]
	private string _takingOffAnimation;

	[EditableScriptComponentVariable(true, "")]
	private string _flyCycleAnimation;

	[EditableScriptComponentVariable(true, "")]
	private bool _canLand;

	public bool CanFly;

	private State _state;

	private BasicMissionTimer _timer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private State ComputeInitialState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetState(State newState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnStateChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyFlyingMovement(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyAnimationDisplacement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bird()
	{
		throw null;
	}
}
