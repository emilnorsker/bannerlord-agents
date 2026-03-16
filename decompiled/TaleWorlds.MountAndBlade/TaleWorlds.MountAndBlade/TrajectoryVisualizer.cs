using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class TrajectoryVisualizer : ScriptComponentBehavior
{
	private struct TrajectoryParams
	{
		public Vec3 MissileShootingPositionOffset;

		public float MissileSpeed;

		public float VerticalAngleMinInDegrees;

		public float VerticalAngleMaxInDegrees;

		public float HorizontalAngleRangeInDegrees;

		public float AirFrictionConstant;

		public bool IsValid;
	}

	public bool ShowTrajectory;

	private GameEntity _trajectoryMeshHolder;

	private TrajectoryParams _trajectoryParams;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTrajectoryParams(Vec3 missileShootingPositionOffset, float missileSpeed, float verticalAngleMinInDegrees, float verticalAngleMaxInDegrees, float horizontalAngleRangeInDegrees, float airFrictionConstant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TrajectoryVisualizer()
	{
		throw null;
	}
}
