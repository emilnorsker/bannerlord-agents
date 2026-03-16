using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Objects;

public class SwingingObject : MissionObject
{
	[EditableScriptComponentVariable(true, "Damping")]
	public float _damping;

	[EditableScriptComponentVariable(true, "Center of Mass Height")]
	public float _centerOfMassHeight;

	[EditableScriptComponentVariable(true, "Mass")]
	public float _mass;

	[EditableScriptComponentVariable(true, "Moment Of Inertia")]
	public float _momentOfInertia;

	[EditableScriptComponentVariable(true, "Reset Simulation")]
	public SimpleButton _resetSimulation;

	[EditableScriptComponentVariable(true, "Test Collision")]
	public SimpleButton _testCollision;

	private Vec2 _currSwing;

	private Vec2 _prevSwing;

	private Vec2 _swingVelocity;

	private float _minLimitXRotation;

	private Vec3 _accumulatedAcceleration;

	private WeakGameEntity _swingingEntity;

	private Vec3 _parentPrevVelocity;

	private MatrixFrame _frameWrtDynamicRoot;

	private Scene _ownerSceneCached;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal SwingingObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DummyFunc()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnParallelFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleSwingMotion(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnHit(Agent attackerAgent, int damage, Vec3 impactPosition, Vec3 impactDirection, in MissionWeapon weapon, int affectorWeaponSlotOrMissileIndex, ScriptComponentBehavior attackerScriptComponentBehavior, out bool reportDamage, out float finalDamage)
	{
		throw null;
	}
}
