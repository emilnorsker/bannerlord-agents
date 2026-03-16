using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.Missions.NavalPhysics;

public class CustomNavalPhysicsParameters : ScriptComponentBehavior
{
	public bool BehaveLikeShip;

	public float FloatingForceMultiplier;

	public float LinearFrictionMultiplierRight;

	public float LinearFrictionMultiplierLeft;

	public float LinearFrictionMultiplierForward;

	public float LinearFrictionMultiplierBackward;

	public float LinearFrictionMultiplierUp;

	public float LinearFrictionMultiplierDown;

	public Vec3 AngularFrictionMultiplier;

	public float ContinuousDriftSpeed;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomNavalPhysicsParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}
}
