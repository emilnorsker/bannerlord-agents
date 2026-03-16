using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View.Scripts;

public class PopupSceneSequence : ScriptComponentBehavior
{
	public float InitialActivationTime;

	public float PositiveActivationTime;

	public float NegativeActivationTime;

	protected AgentVisuals _agentVisuals;

	protected float _time;

	protected bool _triggered;

	protected int _state;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeWithAgentVisuals(AgentVisuals visuals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PopupSceneSequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnInitialState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnPositiveState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnNegativeState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInitialState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPositiveState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNegativeState()
	{
		throw null;
	}
}
