using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.NavalPhysics;

public class NavalPhysicsAgentCollisionSolver : ScriptComponentBehavior
{
	private const float CutoffDistance = 0.6f;

	private const float CollisionAcceleration = 2f;

	private NavalPhysics _floatableEntityNavalPhysicsScript;

	private MBList<Agent> _nearbyAgentsCache;

	private Vec3[] _floatableMeshBoundingBoxGlobalVertices;

	private Vec3 _forceToBeAppliedOnFixedTick;

	private Vec3 _torqueToBeAppliedOnFixedTick;

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
	private bool IsPointInsideLocalBoundingBox(MatrixFrame globalFrame, Vec3 point, float margin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateFloatableMeshBoundingBoxGlobalVertices(MatrixFrame globalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnParallelFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalPhysicsAgentCollisionSolver()
	{
		throw null;
	}
}
