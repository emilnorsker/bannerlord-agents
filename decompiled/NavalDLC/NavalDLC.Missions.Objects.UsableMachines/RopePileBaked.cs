using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.Missions.Objects.UsableMachines;

public class RopePileBaked : ScriptComponentBehavior
{
	public const float HookLength = 0.5f;

	private const int NumberOfPoints = 64;

	private const int PaddedNumberOfPoints = 72;

	private const int NumberOfDataPerFrame = 12;

	private Mesh _ropeMesh;

	private BoundingBox _localUpdatedBoundingBox;

	private BoundingBox _ropePileBaseBoundingBox;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBoundingBoxValidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame UpdateRopeMeshVisualAccordingToTargetPoint(in Vec3 sourceGlobalPosition, in Vec3 targetGlobalPosition, in Vec3 globalVelocity, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 UpdateRopeMeshVisualAccordingToTargetPointLinear(in Vec3 sourceGlobalPosition, in Vec3 targetGlobalPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 UpdateRopeMeshVisualAccordingToTargetPointLinearWithoutBoundingBoxUpdate(in Vec3 sourceGlobalPosition, in Vec3 targetGlobalPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetPositionAtProjectileCurveProgress(in Vec3 globalVelocity, in Vec3 sourceGlobalPosition, float time, int progressInterval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 ComputeFreeFallPointsLinearWithoutBoundingBoxUpdate(in Vec3 sourceGlobalPosition, in Vec3 targetGlobalPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 ComputeFreeFallPointsLinear(in Vec3 sourceGlobalPosition, in Vec3 targetGlobalPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateRopeLocalBoundingBox(in BoundingBox candidateLocalBoundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRopeBoundingBoxToInitialState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame ComputeFreeFallPoints(in Vec3 sourceGlobalPosition, in Vec3 targetGlobalPosition, in Vec3 globalVelocity, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RopePileBaked()
	{
		throw null;
	}
}
