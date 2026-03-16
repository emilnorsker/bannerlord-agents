using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class AnimatedFlag : ScriptComponentBehavior
{
	private float _prevTheta;

	private float _prevSkew;

	private Vec3 _prevFlagMeshFrame;

	private float _time;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AnimatedFlag()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SmoothTheta(ref float theta, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override bool IsOnlyVisual()
	{
		throw null;
	}
}
