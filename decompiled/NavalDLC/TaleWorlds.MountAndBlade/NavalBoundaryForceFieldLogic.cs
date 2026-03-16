using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class NavalBoundaryForceFieldLogic : MissionLogic
{
	private const float SoftStart = 20f;

	private const float HardStop = 0.25f;

	private const float MaxAcceleleration = 6f;

	private const float VRef = 3f;

	private const float SeparationVelocityGain = 4f;

	private const float Damping = 2f;

	private MBList<Vec2> _hardBoundaryPoints;

	private NavalShipsLogic _navalShipsLogic;

	public MBReadOnlyList<Vec2> HardBoundaryPoints
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFixedMissionTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalBoundaryForceFieldLogic()
	{
		throw null;
	}
}
